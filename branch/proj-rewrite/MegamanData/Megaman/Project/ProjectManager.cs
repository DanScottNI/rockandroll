using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using ROMHackLib.Project;

namespace MegamanData.Megaman.Project
{
    /// <summary>
    /// Class that manages projects.
    /// </summary>
    public class ProjectManager : IXMLProject
    {
        #region IXMLProject Members

        /// <summary>
        /// Creates an XML element.
        /// </summary>
        /// <returns>
        /// A XElement object that is used to persist the project's settings.
        /// </returns>
        public XElement CreateItem()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads a project item from an XElement object.
        /// </summary>
        /// <param name="item">The XElement object to load the project item from.</param>
        public void LoadItem(XElement item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
