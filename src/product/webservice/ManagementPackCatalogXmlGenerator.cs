//-----------------------------------------------------------------------
// <copyright file="ManagementPackCatalogXmlGenerator.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Microsoft.ManagementPackCatalog.WebService
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Configuration;
    using System.Data;
    using System.Xml;
    using Microsoft.ManagementPackCatalog.Classes;

    /// <summary>
    /// This class is used to generate the Xml needed by the access functions from catalog management pack classes.
    /// </summary>
    internal class ManagementPackCatalogXmlGenerator
    {
        /// <summary>
        /// This method retuns the ManagementPackXml for a given list of management pack identities
        /// </summary>
        /// <param name="managementPackIdentities">Given management pack identities</param>
        /// <returns>A string representing the management pack identities as xml</returns>
        public string ManagementPackXmlGet(Collection<CatalogManagementPackIdentity> managementPackIdentities)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("ManagementPacks");

            for (int i = 0; i < managementPackIdentities.Count; i++)
            {
                XmlNode child = doc.CreateElement("ManagementPack");
                XmlAttribute guid = doc.CreateAttribute("VersionIndependentGuid");
                guid.InnerText = managementPackIdentities[i].VersionIndependentGuid.ToString();
                XmlAttribute version = doc.CreateAttribute("Version");
                version.InnerText = managementPackIdentities[i].Version;

                child.Attributes.Append(guid);
                child.Attributes.Append(version);

                root.AppendChild(child);
            }

            doc.AppendChild(root);

            return doc.InnerXml;
        }

        /// <summary>
        /// This method returns catalogItemXml for a given list of catalog item ids.
        /// </summary>
        /// <param name="catalogItemIds">Given list of catalog item ids.</param>
        /// <returns>A string representing the given catalog item ids as xml</returns>
        public string CatalogItemXmlGet(Collection<int> catalogItemIds)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("CatalogItems");

            for (int i = 0; i < catalogItemIds.Count; i++)
            {
                XmlNode child = doc.CreateElement("CatalogItem");
                XmlAttribute id = doc.CreateAttribute("ID");
                id.InnerText = catalogItemIds[i].ToString(System.Globalization.CultureInfo.InvariantCulture);

                child.Attributes.Append(id);

                root.AppendChild(child);
            }

            doc.AppendChild(root);

            return doc.InnerXml;
        }
    }
}