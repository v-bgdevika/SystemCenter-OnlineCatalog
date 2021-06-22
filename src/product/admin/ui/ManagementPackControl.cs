using System;
using System.Data;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.ManagementPackCatalog.Admin.Access;
using Microsoft.ManagementPackCatalog.Admin.Classes;
using Telerik.WebControls;
using Telerik.Web.UI;

namespace Microsoft.ManagementPackCatalog.Admin.UI
{
    public class ManagementPackControl
    {

        private class ManagementPackEntry
        {
            private int mpId;
            private string displayName;
            private Version version;
            private DateTime releaseDate;
            private bool published;

            public int ManagementPackId
            {
                get { return this.mpId; }
                set { this.mpId = value; }
            }

            public string DisplayName
            {
                get { return this.displayName; }
                set { this.displayName = value; }
            }

            public DateTime ReleaseDate
            {
                get { return this.releaseDate; }
                set { this.releaseDate = value; }
            }

            public string Version
            {
                get { return this.version.ToString(); }
                set { this.version = new Version(value); }
            }

            public bool Published
            {
                get { return this.published; }
                set { this.published = value; }
            }



        }

        /// <summary>
        /// mp list
        /// </summary>
        private Collection<CatalogManagementPack> mps;


        /// <summary>
        /// Internal control
        /// </summary>
        private static ManagementPackControl internalControl;


        /// <summary>
        /// Gets an instance of management pack control
        /// </summary>
        /// <returns>return management pack control</returns>
        public static ManagementPackControl getInstance()
        {
            if (ManagementPackControl.internalControl == null)
            {
                ManagementPackControl.internalControl = new ManagementPackControl();
            }
            return ManagementPackControl.internalControl;
        }

        /// <summary>
        /// Initializes a new instance of the ManagementPackControl class.
        /// </summary>
        private ManagementPackControl()
        {
            this.Refresh();
        }

        public void Refresh()
        {
            CatalogManagementPackGetOperation mpGet = new CatalogManagementPackGetOperation();
            mpGet.SetParameters(0, "ENU");
            mpGet.Execute();
            this.mps = mpGet.ManagementPackList;            
        }

        public void UpdateGrid(RadGrid mpGrid)
        {

            this.Refresh();

            Collection<ManagementPackEntry> mpEntries = new Collection<ManagementPackEntry>();

            foreach (CatalogManagementPack mp in this.mps)
            {
                ManagementPackEntry mpEntry = new ManagementPackEntry();
                mpEntry.DisplayName = mp.DisplayName;
                if (String.IsNullOrEmpty(mp.DisplayName))
                {
                    mpEntry.DisplayName = mp.SystemName;
                }
                mpEntry.ManagementPackId = mp.ManagementPackId;
                mpEntry.Version = mp.Version.ToString();
                mpEntry.ReleaseDate = mp.ReleaseDate.Date;
                mpEntry.Published = mp.PublishedInd;
                mpEntries.Add(mpEntry);
            }
            
            mpGrid.DataSource = mpEntries;
            mpGrid.DataBind();

        }


        public void UpdateCategoryAssignedMpGrid(RadGrid mpGrid, int categoryId)
        {

            Collection<ManagementPackEntry> mpEntries = new Collection<ManagementPackEntry>();

            CatalogCategoryAssignedManagementPackGetOperation op = new CatalogCategoryAssignedManagementPackGetOperation();
            op.SetParameters(categoryId);
            op.Execute();

            foreach (CatalogManagementPack mp in op.ManagementPackList)
            {
                ManagementPackEntry mpEntry = new ManagementPackEntry();
                mpEntry.DisplayName = mp.DisplayName;
                if (String.IsNullOrEmpty(mp.DisplayName))
                {
                    mpEntry.DisplayName = mp.SystemName;
                }
                mpEntry.ManagementPackId = mp.ManagementPackId;
                mpEntry.Version = mp.Version.ToString();
                mpEntry.ReleaseDate = mp.ReleaseDate.Date;
                mpEntry.Published = mp.PublishedInd;
                mpEntries.Add(mpEntry);
            }

            mpGrid.DataSource = mpEntries;
            mpGrid.DataBind();

        }

        public void UpdateCategoryUnAssignedMpGrid(RadGrid mpGrid, int categoryId)
        {

            Collection<ManagementPackEntry> mpEntries = new Collection<ManagementPackEntry>();

            CatalogCategoryUnAssignedManagementPackGetOperation op = new CatalogCategoryUnAssignedManagementPackGetOperation();
            op.SetParameters(categoryId);
            op.Execute();

            foreach (CatalogManagementPack mp in op.ManagementPackList)
            {
                ManagementPackEntry mpEntry = new ManagementPackEntry();
                mpEntry.DisplayName = mp.DisplayName;
                if (String.IsNullOrEmpty(mp.DisplayName))
                {
                    mpEntry.DisplayName = mp.SystemName;
                }
                mpEntry.ManagementPackId = mp.ManagementPackId;
                mpEntry.Version = mp.Version.ToString();
                mpEntry.ReleaseDate = mp.ReleaseDate.Date;
                mpEntry.Published = mp.PublishedInd;
                mpEntries.Add(mpEntry);
            }

            mpGrid.DataSource = mpEntries;
            mpGrid.DataBind();

        }



        public void UpdateLocDropDownList(RadComboBox languageList, int mpId)
        {
            languageList.Items.Clear();

            CatalogManagementPackLocGetOperation op = new CatalogManagementPackLocGetOperation();
            op.SetParameters(mpId);
            op.Execute();

            Collection<string> languages = op.LanguageList;

            foreach (string language in languages)
            {
                RadComboBoxItem item = new RadComboBoxItem(language, language);
                languageList.Items.Add(item);
            }
            languageList.DataBind();
        }


        public void AddManagementPack(string downloadUrl, string localMpLocation, int vendorId)
        {
            ManagementPack mPack = new ManagementPack(localMpLocation);

            CatalogManagementPack mp = new CatalogManagementPack();
            CatalogManagementPackExtendedInfo info = new CatalogManagementPackExtendedInfo();

            if (String.IsNullOrEmpty(mPack.DisplayName) == false)
            {
                mp.DisplayName = mPack.DisplayName;
            }
            else
            {
                mp.DisplayName = "";
            }

            mp.DownloadUri = downloadUrl;
            mp.EulaInd = false;
            mp.ManagementPackId = 0;
            mp.PublicKey = mPack.KeyToken;
            mp.PublishedInd = false;
            mp.ReleaseDate = DateTime.Now;
            mp.SecurityInd = false;////set default value here. Real calculation done below
            mp.SystemName = mPack.Name;
            mp.VendorId = vendorId;
            mp.Version = mPack.Version;
            mp.VersionIndependentGuid = mPack.Id;


            if (String.IsNullOrEmpty(mPack.Description) == false)
            {
                info.Description = mPack.Description;
            }
            else
            {
                info.Description = "";
            }

            info.Eula = "";
            if (mPack.GetKnowledgeArticle("ENU") != null && mPack.GetKnowledgeArticle("ENU").MamlContent != null)
            {
                info.Knowledge = mPack.GetKnowledgeArticle("ENU").MamlContent;
            }
            else
            {
                info.Knowledge = "";
            }

            info.ManagmentPackId = 0;

            ////Calculate if MP needs a security indicator
            ManagementPackElementCollection<ManagementPackRule> rules = mPack.GetRules();
            foreach (ManagementPackRule rule in rules)
            {
                ManagementPackSubElementCollection<ManagementPackWriteActionModule> waModules = rule.WriteActionCollection;
                foreach (ManagementPackWriteActionModule waModule in waModules)
                {
                    if (waModule.Target != null)
                    {
                        mp.SecurityInd = true;
                        break;
                    }
                }
            }


            CatalogManagementPackSetOperation mpSet = new CatalogManagementPackSetOperation();
            mpSet.SetParameters(mp, info);
            mpSet.Execute();

            int mpId = mpSet.ManagementPackId;

            foreach (ManagementPackReference mpref in mPack.References.Values)
            {

                CatalogManagementPackIdentity iden = new CatalogManagementPackIdentity();

                CatalogManagementPackDependencySetOperation depOp = new CatalogManagementPackDependencySetOperation();
                iden.VersionIndependentGuid = mpref.Id;
                iden.Version = mpref.Version.ToString();
                depOp.SetParameters(mpId, iden);
                depOp.Execute();
            }
        }


        public CatalogManagementPack getManagementPack(int mpId, string threeLetterLanguageCode)
        {
            CatalogManagementPackGetOperation mpGet = new CatalogManagementPackGetOperation();
            mpGet.SetParameters(mpId, threeLetterLanguageCode);
            mpGet.Execute();
            return mpGet.ManagementPackList[0];
        }

        public CatalogManagementPackExtendedInfo getManagementPackExtendedInfo(int mpId, string threeLetterLanguageCode)
        {
            CatalogManagementPackExtendedInfoGetOperation infoGet = new CatalogManagementPackExtendedInfoGetOperation();
            infoGet.SetParameters(mpId, threeLetterLanguageCode);
            infoGet.Execute();
            return infoGet.ManagementPackExtendedInfoList[0];
        }

        public void UpdateManagementPack(CatalogManagementPack mp, CatalogManagementPackExtendedInfo info)
        {
            CatalogManagementPackSetOperation mpSet = new CatalogManagementPackSetOperation();
            mpSet.SetParameters(mp, info);
            mpSet.Execute();
        }

        public void UpdateLocManagementPack(CatalogManagementPack mp, CatalogManagementPackExtendedInfo info, string threeLetterLanguageCode)
        {
            CatalogManagementPackLocSetOperation mpSet = new CatalogManagementPackLocSetOperation();
            mpSet.SetParameters(mp, info,threeLetterLanguageCode);
            mpSet.Execute();
        }


        public void UpdateAssociatedProductList(RadComboBox productList, int mpId)
        {
            productList.Items.Clear();
            RadComboBoxItem noneItem = new RadComboBoxItem("None", "0");
            productList.Items.Add(noneItem);

            CatalogItemAssociatedProductGetOperation op = new CatalogItemAssociatedProductGetOperation();
            op.SetParameters(mpId);
            op.Execute();

            foreach (CatalogProduct product in op.ProductList)
            {
                RadComboBoxItem item = new RadComboBoxItem(product.ProductName + " " + product.ProductVersion, product.ProductId.ToString());
                productList.Items.Add(item);
            }
            productList.DataBind();
        }

        public void UpdateUnAssociatedProductList(RadComboBox productList, int mpId)
        {
            productList.Items.Clear();
            RadComboBoxItem noneItem = new RadComboBoxItem("None", "0");
            productList.Items.Add(noneItem);

            CatalogItemUnAssociatedProductGetOperation op = new CatalogItemUnAssociatedProductGetOperation();
            op.SetParameters(mpId);
            op.Execute();

            foreach (CatalogProduct product in op.ProductList)
            {
                RadComboBoxItem item = new RadComboBoxItem(product.ProductName + " " + product.ProductVersion, product.ProductId.ToString());
                productList.Items.Add(item);
            }
            productList.DataBind();
        }


        public string GetLocalizeXml(int mpId, string threeLetterLanguageCode)
        {
            CatalogManagementPack mp = this.getManagementPack(mpId, threeLetterLanguageCode);
            CatalogManagementPackExtendedInfo info = this.getManagementPackExtendedInfo(mpId, threeLetterLanguageCode);

            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("ManagementPack");
            XmlAttribute language = doc.CreateAttribute("Language");
            language.Value = threeLetterLanguageCode;
            root.Attributes.Append(language);


            XmlNode mpIdNode = doc.CreateElement("Id");
            mpIdNode.InnerText = mp.ManagementPackId.ToString();
            root.AppendChild(mpIdNode);

            XmlNode mpNameNode = doc.CreateElement("Name");
            mpNameNode.InnerText = mp.DisplayName;
            root.AppendChild(mpNameNode);

            XmlNode mpDescNode = doc.CreateElement("Description");
            mpDescNode.InnerText = info.Description;
            root.AppendChild(mpDescNode);


            XmlNode mpKnowledgeNode = doc.CreateElement("Knowledge");
            mpKnowledgeNode.InnerText = info.Knowledge;
            root.AppendChild(mpKnowledgeNode);

            XmlNode mpEulaNode = doc.CreateElement("Eula");
            mpEulaNode.InnerText = info.Eula;
            root.AppendChild(mpEulaNode);


            doc.AppendChild(root);

            return doc.InnerXml;
        }

    }
}
