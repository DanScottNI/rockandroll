using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using ROMClass;
using ROMClass.NES;

namespace MegamanData.Music.CapcomEngine
{
    /// <summary>
    /// Class used to produce a disassembly of the music data for early Capcom games.
    /// </summary>
    /// <remarks>
    /// According to bbitmaster, this engine is used in the following games:
    /// 1943
    /// Bionic Commando
    /// Commando
    /// Destiny of an Emperor
    /// Gun Smoke
    /// Higemaru Makaijima - Nanatsu no Shima Dai Bouken
    /// Hitler no Fukkatsu - Top Secret
    /// Ide Yousuke Meijin no Jissen Mahjong
    /// Legendary Wings
    /// Mega Man
    /// Mega Man 2
    /// Pro Yakyuu Satsujin Jiken! (J)
    /// Rockman
    /// Rockman 2
    /// Section Z
    /// Senjou no Ookami
    /// Tenchi wo Kurau
    /// Trojan
    /// Willow
    /// </remarks>
    public class MusicDisassemble
    {
        /// <summary>
        /// The ROM that contains the music tracks.
        /// </summary>
        private INESROMImage rom;

        /// <summary>
        /// The music opcodes.
        /// </summary>
        private Dictionary<byte, MusicOpcodeFormat> musicOpcodes;

        /// <summary>
        /// The sound effect opcodes.
        /// </summary>
        private Dictionary<byte, MusicOpcodeFormat> soundEffectOpcodes;

        /// <summary>
        /// The offset for the music table.
        /// </summary>
        private int musicTableOffset;

        /// <summary>
        /// Initializes a new instance of the MusicDisassemble class.
        /// </summary>
        /// <param name="fileName">The filename of the ROM.</param>
        /// <param name="tableOffset">The offset in the ROM for the music\sound effects table.</param>
        public MusicDisassemble(string fileName, int tableOffset)
        {
            // Load in the NES ROM.
            this.rom = new INESROMImage(fileName);

            // Store the music table offset.
            this.musicTableOffset = tableOffset;

            // Load in the music opcodes.
            this.LoadMusicOpcodes();

            // Load in the sound effect opcodes.
            this.LoadSoundEffectOpcodes();
        }

        /// <summary>
        /// Retrieves the track information.
        /// </summary>
        /// <returns>A List of MusicTrackInfo objects that contain information on the music tracks in this game.</returns>
        public List<MusicTrackInfo> RetrieveTrackInformation()
        {
            // We need to find where the track table ends, so we store
            // the offset of the very first track.
            int lowestTrackOffset = -1;
            int trackIndex = 0;

            // We need to store a dictionary of the track indexes, and their own particular offsets.
            List<int> musicTrackOffsets = new List<int>();

            // Okay, now we need to iterate through the table, finding the offsets of all the tracks.
            // This loop should technically never end, as want to iterate through it until we find
            // the
            for (int i = 0; true; i = i + 2)
            {
                int musicOffset = this.rom.PointerToOffset(this.musicTableOffset + i);

                // If this is the first offset, store the offset.
                // If it isn't, but the offset from the pointer is less than that stored
                // in the lowest track offset, store the current pointer.
                if (lowestTrackOffset == -1)
                {
                    lowestTrackOffset = musicOffset;
                }
                else if (musicOffset < lowestTrackOffset)
                {
                    lowestTrackOffset = musicOffset;
                }

                trackIndex++;

                // If the current offset matches the track offset
                if ((this.musicTableOffset + i) == lowestTrackOffset)
                {
                    break;
                }
                else
                {
                    // Add the location, and track index to the list.
                    musicTrackOffsets.Add(musicOffset);
                }
            }

            // Work out the number of tracks.
            int numberOfTracks = (lowestTrackOffset - this.musicTableOffset) / 2;

            List<MusicTrackInfo> trackList = new List<MusicTrackInfo>();

            for (int i = 0; i < musicTrackOffsets.Count; i++)
            {
                int trackOffset = musicTrackOffsets[i];
                if ((this.rom[trackOffset] & 0xF0) > 00)
                {
                    trackList.Add(new MusicTrackInfo(i, trackOffset, MusicTrackType.SoundEffect));
                }
                else
                {
                    trackList.Add(new MusicTrackInfo(i, trackOffset, MusicTrackType.MusicTrack));
                }
            }

            return trackList;
        }

        /// <summary>
        /// Disassembles the music table, and all the music and sound effects.
        /// </summary>
        /// <returns>A string containing the disassembly.</returns>
        public Dictionary<int, string> Disassemble()
        {
            Dictionary<int, string> trackDisassemblies = new Dictionary<int, string>();

            List<MusicTrackInfo> musicTrackInfo = this.RetrieveTrackInformation();

            // Work out the number of tracks.
            int numberOfTracks = musicTrackInfo.Count;

            for (int i = 0; i < musicTrackInfo.Count; i++)
            {
                MusicTrackInfo currentTrack = musicTrackInfo[i];

                int trackOffset = currentTrack.TrackOffset;
                if ((this.rom[trackOffset] & 0xF0) > 00)
                {
                    // Disassemble the sound effect.
                    trackDisassemblies.Add(currentTrack.TrackIndex, this.DisassembleSoundEffect(ref currentTrack));
                }
                else
                {
                    // Disassemble the music track.
                    trackDisassemblies.Add(currentTrack.TrackIndex, this.DisassembleMusicTrack(ref currentTrack));
                }
            }

            return trackDisassemblies;
        }

        /// <summary>
        /// Disassembles the sound effect.
        /// </summary>
        /// <param name="trackInfo">The MusicTrackInfo object used to retrieve track information.</param>
        /// <returns>An annotated disassembly of the sound effect.</returns>
        private string DisassembleSoundEffect(ref MusicTrackInfo trackInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("TRACK{0}START:", trackInfo.TrackIndex));

            // The format of a sound effect is:
            // Priority Byte
            // Channel Usage
            // Sound Effect data.
            int currentPos = trackInfo.TrackOffset;

            sb.AppendLine(string.Format(".byte ${0} ;priority. Lo=music priority, Hi=sfx priority", this.rom[currentPos].ToHex()));
            currentPos++;

            sb.AppendLine(string.Format(".byte ${0} ;channel usage", this.rom[currentPos].ToHex()));
            currentPos++;

            sb.AppendLine(this.DisassembleSoundEffectData(trackInfo.TrackIndex, currentPos));

            return sb.ToString();
        }

        /// <summary>
        /// Disassembles the music track.
        /// </summary>
        /// <param name="trackInfo">The MusicTrackInfo object used to retrieve track information.</param>
        /// <returns>An annotated disassembly of the music track.</returns>
        private string DisassembleMusicTrack(ref MusicTrackInfo trackInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("TRACK{0}START:", trackInfo.TrackIndex));

            // The format of the music track is as follows:
            // Priority Byte
            // Channel 0 Pointer - Maybe 0000 to denote not used.
            // Channel 1 Pointer - Maybe 0000 to denote not used.
            // Channel 2 Pointer - Maybe 0000 to denote not used.
            // Channel 3 Pointer - Maybe 0000 to denote not used. Terminated with the end of data opcode.
            // Vibrato Table Pointer - Maybe 0000 to denote not used. To work out how many groups of 4 bytes there
            // are, the SetVibratoIndex command is tracked.
            int currentPos = trackInfo.TrackOffset;

            sb.AppendLine(string.Format(".byte ${0} ;priority. Lo=music priority, Hi=sfx priority", this.rom[currentPos].ToHex()));
            currentPos++;

            // Channel 0
            if (this.rom[currentPos] + this.rom[currentPos + 1] > 0)
            {
                sb.AppendLine(".word Lbl_Track" + trackInfo.TrackIndex + "_Channel0");
            }
            else
            {
                sb.AppendLine(".word $0000");
            }
            currentPos += 2;

            // Channel 1
            if (this.rom[currentPos] + this.rom[currentPos + 1] > 0)
            {
                sb.AppendLine(".word Lbl_Track" + trackInfo.TrackIndex + "_Channel1");
            }
            else
            {
                sb.AppendLine(".word $0000");
            }
            currentPos += 2;

            // Channel 2
            if (this.rom[currentPos] + this.rom[currentPos + 1] > 0)
            {
                sb.AppendLine(".word Lbl_Track" + trackInfo.TrackIndex + "_Channel2");
            }
            else
            {
                sb.AppendLine(".word $0000");
            }
            currentPos += 2;

            // Channel 3
            if (this.rom[currentPos] + this.rom[currentPos + 1] > 0)
            {
                sb.AppendLine(".word Lbl_Track" + trackInfo.TrackIndex + "_Channel3");
            }
            else
            {
                sb.AppendLine(".word $0000");
            }
            currentPos += 2;

            // Vibrato
            if (this.rom[currentPos] + this.rom[currentPos + 1] > 0)
            {
                sb.AppendLine(".word Lbl_Track" + trackInfo.TrackIndex + "_Vibrato");
            }
            else
            {
                sb.AppendLine(".word $0000");
            }
            currentPos += 2;

            // Reset the track pointer.
            currentPos = trackInfo.TrackOffset + 1;
            int vibratoTracks = -1;

            // Channel 0
            sb.Append(this.DisassembleMusicChannelData(trackInfo.TrackIndex, currentPos, ref vibratoTracks, 0));
            currentPos += 2;

            // Channel 1
            sb.Append(this.DisassembleMusicChannelData(trackInfo.TrackIndex, currentPos, ref vibratoTracks, 1));
            currentPos += 2;

            // Channel 2
            sb.Append(this.DisassembleMusicChannelData(trackInfo.TrackIndex, currentPos, ref vibratoTracks, 2));
            currentPos += 2;

            // Channel 3
            sb.Append(this.DisassembleMusicChannelData(trackInfo.TrackIndex, currentPos, ref vibratoTracks, 3));
            currentPos += 2;

            // Vibrato
            if (vibratoTracks > -1)
            {
                sb.Append(this.DisassembleMusicVibrato(trackInfo.TrackIndex, vibratoTracks, currentPos));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Disassembles the sound effect data.
        /// </summary>
        /// <param name="trackIndex">Index of the track.</param>
        /// <param name="soundEffectOffset">The sound effect offset.</param>
        /// <returns>A string containing the disassembled sound effect data.</returns>
        private string DisassembleSoundEffectData(int trackIndex, int soundEffectOffset)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<int, string> addressLabels = new Dictionary<int, string>();

            bool quitLoop = false;
            int firstPass = soundEffectOffset;

            while (quitLoop == false)
            {
                byte currentByte = this.rom[firstPass];

                // Check if the current position in the ROM is for a known opcode,
                // or just a standard note.
                if (this.soundEffectOpcodes.ContainsKey(currentByte))
                {
                    int currentAddress = 0;

                    for (int i = 0; i < this.soundEffectOpcodes[currentByte].Length; i++)
                    {
                        MusicOpcodeType opcodeType = this.soundEffectOpcodes[currentByte].OpcodeTypes[i];

                        if (opcodeType == MusicOpcodeType.End)
                        {
                            quitLoop = true;
                        }
                        if (opcodeType == MusicOpcodeType.Address)
                        {
                            currentAddress = this.rom.PointerToOffset(firstPass);
                            firstPass++;
                            firstPass++;
                            break;
                        }

                        firstPass++;
                    }

                    if (currentAddress > 0 && addressLabels.ContainsKey(currentAddress) == false)
                    {
                        addressLabels.Add(currentAddress, "Lbl_" + currentAddress.ToHex());
                    }
                }
                else
                {
                    firstPass++;
                }
            }

            quitLoop = false;

            // Now we have the address label information, we can start to 
            while (quitLoop == false)
            {
                byte currentByte = this.rom[soundEffectOffset];

                // If the current offset has a label for it, then we should 
                if (addressLabels.ContainsKey(soundEffectOffset) == true)
                {
                    sb.AppendLine(addressLabels[soundEffectOffset] + ":");
                }

                // Check if the current position in the ROM is for a known opcode,
                // or just a standard note.
                if (this.soundEffectOpcodes.ContainsKey(currentByte))
                {
                    sb.Append(".byte ");

                    for (int i = 0; i < this.soundEffectOpcodes[currentByte].Length; i++)
                    {
                        MusicOpcodeType opcodeType = this.soundEffectOpcodes[currentByte].OpcodeTypes[i];

                        if (opcodeType == MusicOpcodeType.End)
                        {
                            sb.Append(this.soundEffectOpcodes[currentByte].Name);
                            quitLoop = true;
                        }
                        else if (opcodeType == MusicOpcodeType.Command)
                        {
                            sb.Append(this.soundEffectOpcodes[currentByte].Name);
                        }
                        else if (opcodeType == MusicOpcodeType.Data)
                        {
                            sb.Append(", $" + this.rom[soundEffectOffset].ToHex());
                        }
                        else if (opcodeType == MusicOpcodeType.Address)
                        {
                            if (addressLabels.ContainsKey(this.rom.PointerToOffset(soundEffectOffset)) == false)
                            {
                                sb.Append(", $" + this.rom[soundEffectOffset].ToHex());
                            }
                            else
                            {
                                sb.Append(", " + addressLabels[this.rom.PointerToOffset(soundEffectOffset)]);
                                soundEffectOffset++;
                                soundEffectOffset++;
                                break;
                            }
                        }
                        soundEffectOffset++;
                    }
                    sb.Append(Environment.NewLine);
                }
                else
                {
                    sb.AppendLine(".byte $" + currentByte.ToHex());
                    soundEffectOffset++;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Disassembles the music channel data.
        /// </summary>
        /// <param name="trackIndex">Index of the track.</param>
        /// <param name="entryOffset">The entry offset.</param>
        /// <param name="vibratoTracks">The vibrato tracks.</param>
        /// <param name="channelIndex">Index of the channel.</param>
        /// <returns>A string containing the disassembly.</returns>
        private string DisassembleMusicChannelData(int trackIndex, int entryOffset, ref int vibratoTracks, int channelIndex)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<int, string> addressLabels = new Dictionary<int, string>();

            // Look up the channel pointer.
            if (this.rom[entryOffset] + this.rom[entryOffset + 1] > 0)
            {
                int channelOffset = this.rom.PointerToOffset(entryOffset);
                bool quitLoop = false;
                int firstPass = channelOffset;

                sb.AppendLine("Lbl_Track" + trackIndex + "_Channel" + channelIndex + ":");

                while (quitLoop == false)
                {
                    byte currentByte = this.rom[firstPass];

                    // Check if the current position in the ROM is for a known opcode,
                    // or just a standard note.
                    if (this.musicOpcodes.ContainsKey(currentByte))
                    {
                        int currentAddress = 0;

                        for (int i = 0; i < this.musicOpcodes[currentByte].Length; i++)
                        {
                            MusicOpcodeType opcodeType = this.musicOpcodes[currentByte].OpcodeTypes[i];

                            if (opcodeType == MusicOpcodeType.End)
                            {
                                quitLoop = true;
                            }
                            if (opcodeType == MusicOpcodeType.Address)
                            {
                                currentAddress = this.rom.PointerToOffset(firstPass);
                                firstPass++;
                                firstPass++;
                                break;
                            }

                            firstPass++;
                        }

                        if (currentAddress > 0 && addressLabels.ContainsKey(currentAddress) == false)
                        {
                            addressLabels.Add(currentAddress, "Lbl_" + currentAddress.ToHex());
                        }
                    }
                    else
                    {
                        firstPass++;
                    }
                }

                quitLoop = false;

                // Now we have the address label information, we can start to 
                while (quitLoop == false)
                {
                    byte currentByte = this.rom[channelOffset];

                    // If the current offset has a label for it, then we should 
                    if (addressLabels.ContainsKey(channelOffset) == true)
                    {
                        sb.AppendLine(addressLabels[channelOffset] + ":");
                    }

                    // Check if the current position in the ROM is for a known opcode,
                    // or just a standard note.
                    if (this.musicOpcodes.ContainsKey(currentByte))
                    {
                        sb.Append(".byte ");

                        for (int i = 0; i < this.musicOpcodes[currentByte].Length; i++)
                        {
                            MusicOpcodeType opcodeType = this.musicOpcodes[currentByte].OpcodeTypes[i];

                            if (opcodeType == MusicOpcodeType.End)
                            {
                                sb.Append(this.musicOpcodes[currentByte].Name);
                                quitLoop = true;
                            }
                            else if (opcodeType == MusicOpcodeType.Command)
                            {
                                sb.Append(this.musicOpcodes[currentByte].Name);
                            }
                            else if (opcodeType == MusicOpcodeType.Data)
                            {
                                sb.Append(", $" + this.rom[channelOffset].ToHex());
                            }
                            else if (opcodeType == MusicOpcodeType.Address)
                            {
                                if (addressLabels.ContainsKey(this.rom.PointerToOffset(channelOffset)) == false)
                                {
                                    sb.Append(", $" + this.rom[channelOffset].ToHex());
                                }
                                else
                                {
                                    sb.Append(", " + addressLabels[this.rom.PointerToOffset(channelOffset)]);
                                    channelOffset++;
                                    channelOffset++;
                                    break;
                                }
                            }
                            else if (opcodeType == MusicOpcodeType.VibratoIndexReference)
                            {
                                sb.Append(", $" + this.rom[channelOffset].ToHex());
                                if (this.rom[channelOffset] > vibratoTracks)
                                {
                                    vibratoTracks = this.rom[channelOffset];
                                }
                            }
                            channelOffset++;
                        }
                        sb.Append(Environment.NewLine);
                    }
                    else
                    {
                        sb.AppendLine(".byte $" + currentByte.ToHex());
                        channelOffset++;
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Disassembles the music vibrato section.
        /// </summary>
        /// <param name="trackIndex">Index of the track.</param>
        /// <param name="numberVibrato">The number vibrato.</param>
        /// <param name="entryOffset">The entry offset.</param>
        /// <returns>An annotated disassembly of the music track's vibrato section.</returns>
        private string DisassembleMusicVibrato(int trackIndex, int numberVibrato, int entryOffset)
        {
            StringBuilder sb = new StringBuilder();
            int numberVibratoEntries = numberVibrato;

            // Look up the channel pointer.
            if (this.rom[entryOffset] + this.rom[entryOffset + 1] > 0)
            {
                int vibratoOffset = this.rom.PointerToOffset(entryOffset);

                // Take the number of vibrato, and add one.
                numberVibratoEntries++;

                sb.AppendLine("Lbl_Track" + trackIndex + "_Vibrato:");

                for (int i = 0; i < numberVibratoEntries; i++)
                {
                    sb.Append(".byte ");
                    sb.Append("$" + this.rom[vibratoOffset].ToHex() + ", ");
                    sb.Append("$" + this.rom[vibratoOffset + 1].ToHex() + ", ");
                    sb.Append("$" + this.rom[vibratoOffset + 2].ToHex() + ", ");
                    sb.Append("$" + this.rom[vibratoOffset + 3].ToHex());
                    sb.Append(Environment.NewLine);
                    vibratoOffset += 4;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Loads the music opcodes.
        /// </summary>
        private void LoadMusicOpcodes()
        {
            this.musicOpcodes = this.LoadOpcodeDefinitionFile("MegamanData.Music.CapcomEngine.musicopcodes.dat");
        }

        /// <summary>
        /// Loads the sound effect opcodes.
        /// </summary>
        private void LoadSoundEffectOpcodes()
        {
            this.soundEffectOpcodes = this.LoadOpcodeDefinitionFile("MegamanData.Music.CapcomEngine.seopcodes.dat");
        }

        /// <summary>
        /// Loads the opcode definition file.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <returns>A List of MusicOpcodeFormat objects.</returns>
        private Dictionary<byte, MusicOpcodeFormat> LoadOpcodeDefinitionFile(string resourceName)
        {
            Assembly _assembly;
            _assembly = Assembly.GetExecutingAssembly();
            Dictionary<byte, MusicOpcodeFormat> opcodes = new Dictionary<byte, MusicOpcodeFormat>();
            MusicOpcodeFormat opcode = null;

            TextReader textReader = new StreamReader(_assembly.GetManifestResourceStream(resourceName));
            string line = string.Empty;

            while ((line = textReader.ReadLine()) != null)
            {
                // Ignore all lines beginning with the semi-colon character.
                if (line.StartsWith(";") == false)
                {
                    opcode = new MusicOpcodeFormat();

                    // Split the line into the fields by the comma character.
                    string[] fields = line.Split(',');

                    if (fields.Length == 3)
                    {
                        opcode.Name = fields[1];
                        opcode.ID = fields[0].HexValueToByte();
                        opcode.Length = Convert.ToByte(fields[2].Length / 2);
                        opcode.OpcodeTypes = new Dictionary<int, MusicOpcodeType>();

                        // Parse the third field, for the opcode types, and the
                        // the length.
                        for (int i = 0; i < fields[2].Length; i = i + 2)
                        {
                            string opcodecharacters = fields[2].Substring(i, 2);
                            MusicOpcodeType opcodetype = MusicOpcodeType.Data;
                            switch (opcodecharacters)
                            {
                                case "AA":
                                    opcodetype = MusicOpcodeType.Address;
                                    break;
                                case "CC":
                                    opcodetype = MusicOpcodeType.Command;
                                    break;
                                case "DD":
                                    opcodetype = MusicOpcodeType.Data;
                                    break;
                                case "EE":
                                    opcodetype = MusicOpcodeType.End;
                                    break;
                                case "VV":
                                    opcodetype = MusicOpcodeType.VibratoIndexReference;
                                    break;
                                default:
                                    break;
                            }
                            opcode.OpcodeTypes.Add((i / 2), opcodetype);
                        }
                    }
                    opcodes.Add(fields[0].HexValueToByte(), opcode);
                }
            }
            return opcodes;
        }
    }
}