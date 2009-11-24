using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace RockAndRoll
{
    public class ApplicationConfig
    {
        public StringCollection RecentFiles { get; set; }
        public Color EnemyColour { get; set; }
        public Color SpecialObjectColour { get; set; }
        public Color BeamDownColour { get; set; }
        public Color SelectedTileLeftColour { get; set; }
        public Color SelectedTileMiddleColour { get; set; }
        string configurationFilename;

        public ApplicationConfig(string filename)
        {
            configurationFilename = filename;

            EnemyColour = Color.Black;
            SpecialObjectColour = Color.Orange;
            BeamDownColour = Color.Purple;
            SelectedTileLeftColour = Color.Red;
            SelectedTileMiddleColour = Color.Green;

            RecentFiles = new StringCollection();
        }

        public void AddToRecentFiles(string filename)
        {
            if (RecentFiles == null)
            {
                RecentFiles = new StringCollection();
            }

            // Check that the list of recent files contains the filename already present,
            // and if it does, remove it (as it needs to be inserted at the top of the list).
            if (RecentFiles.Contains(filename))
            {
                RecentFiles.Remove(filename);
            }

            // Now add the filename at the top of the list.
            RecentFiles.Insert(0, filename);
        }

        public void SaveConfiguration()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", null, null));

            // First, we have to create the <config> node.
            XmlElement configNode = xmlDoc.CreateElement("config");

            // Recent files.
            if (RecentFiles != null)
            {
                // Now, we create within that, the <recentfiles> node.
                XmlElement recentFilesNode = xmlDoc.CreateElement("recentfiles");

                // Now, loop through the recent files list and create nodes for each of those.
                foreach (string recentFile in RecentFiles)
                {
                    XmlElement recentFileNode = xmlDoc.CreateElement("recentfile");
                    recentFileNode.InnerText = recentFile;
                    recentFilesNode.AppendChild(recentFileNode);
                }

                configNode.AppendChild(recentFilesNode);
            }

            // Enemy Colour.
            XmlElement enemyColourNode = xmlDoc.CreateElement("enemycolour");
            enemyColourNode.InnerText = ColorTranslator.ToHtml(EnemyColour);
            configNode.AppendChild(enemyColourNode);

            // Special Objects Colour.
            XmlElement specObjColourNode = xmlDoc.CreateElement("specobjcolour");
            specObjColourNode.InnerText = ColorTranslator.ToHtml(SpecialObjectColour);
            configNode.AppendChild(specObjColourNode);

            // Beam Down Colour.
            XmlElement beamDownColourNode = xmlDoc.CreateElement("beamdowncolour");
            beamDownColourNode.InnerText = ColorTranslator.ToHtml(BeamDownColour);
            configNode.AppendChild(beamDownColourNode);

            // Selected Tile Left Colour.
            XmlElement leftColourNode = xmlDoc.CreateElement("leftcolour");
            leftColourNode.InnerText = ColorTranslator.ToHtml(SelectedTileLeftColour);
            configNode.AppendChild(leftColourNode);

            // Selected Tile Middle Colour.
            XmlElement middleColourNode = xmlDoc.CreateElement("middlecolour");
            middleColourNode.InnerText = ColorTranslator.ToHtml(SelectedTileMiddleColour);
            configNode.AppendChild(middleColourNode);

            xmlDoc.AppendChild(configNode);
            xmlDoc.Save(configurationFilename);
        }

        public void LoadConfiguration()
        {
            if (System.IO.File.Exists(configurationFilename) == true)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(configurationFilename);

                RecentFiles = new StringCollection();

                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    // Look up the recent files 
                    if (node.Name == "recentfiles")
                    {
                        foreach (XmlNode recentfile in node.ChildNodes)
                        {
                            if (recentfile.Name == "recentfile")
                            {
                                RecentFiles.Add(recentfile.InnerText);
                            }
                        }
                    }
                    else if (node.Name == "enemycolour")
                    {
                        EnemyColour = ColorTranslator.FromHtml(node.InnerText);
                    }
                    else if (node.Name == "specobjcolour")
                    {
                        SpecialObjectColour = ColorTranslator.FromHtml(node.InnerText);
                    }
                    else if (node.Name == "beamdowncolour")
                    {
                        BeamDownColour = ColorTranslator.FromHtml(node.InnerText);
                    }
                    else if (node.Name == "leftcolour")
                    {
                        SelectedTileLeftColour = ColorTranslator.FromHtml(node.InnerText);
                    }
                    else if (node.Name == "middlecolour")
                    {
                        SelectedTileMiddleColour = ColorTranslator.FromHtml(node.InnerText);
                    }
                }
            }
        }
    }
}
