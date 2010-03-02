using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Xml;

namespace RockAndRoll2
{
    public class ApplicationConfig
    {
        public StringCollection RecentFiles { get; set; }
        string configurationFilename;

        public ApplicationConfig(string filename)
        {
            configurationFilename = filename;
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
                }
            }
        }
    }
}
