using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using Microsoft.ManagementPackCatalog.Admin.Access;
using Microsoft.ManagementPackCatalog.Admin.Classes;
using Telerik.WebControls;
using Telerik.Web.UI;

namespace Microsoft.ManagementPackCatalog.Admin.UI
{
    public class VendorControl
    {
        private class InternalVendorGridClass
        {
            private string vendorName;
            private string vendorLink;

            public string VendorName
            {
                get { return this.vendorName; }
                set { this.vendorName = value; }
            }

            public string VendorLink
            {
                get { return this.vendorLink; }
                set { this.vendorLink = value; }
            }


        }

        private static VendorControl internalControl;


        /// <summary>
        /// vendor list
        /// </summary>
        private Collection<CatalogVendor> vendors;

        /// <summary>
        /// Initializes a new instance of the VendorControl class.
        /// </summary>
        private VendorControl()
        {
            this.Refresh();
        }

        public static VendorControl getInstance()
        {

            if (internalControl == null)
            {
                internalControl = new VendorControl();
            }
            return internalControl;
        }

        public void Refresh()
        {
            CatalogVendorGetOperation vendorGet = new CatalogVendorGetOperation();
            vendorGet.SetParameters(0,"ENU");
            vendorGet.Execute();
            this.vendors = vendorGet.VendorList;

        }

        public void UpdateDropDownList(RadComboBox vendorList)
        {
            vendorList.Items.Clear();

            RadComboBoxItem noneItem = new RadComboBoxItem("None", "0");
            vendorList.Items.Add(noneItem);

            foreach (CatalogVendor vendor in this.vendors)
            {
                RadComboBoxItem item = new RadComboBoxItem(vendor.VendorName + " " + vendor.VendorLink, vendor.VendorId.ToString());
                vendorList.Items.Add(item);
            }
            vendorList.DataBind();
        }

        public void UpdateLocDropDownList(RadComboBox languageList, int vendorId)
        {
            languageList.Items.Clear();


            CatalogVendorLocGetOperation op = new CatalogVendorLocGetOperation();
            op.SetParameters(vendorId);
            op.Execute();

            Collection<string> languages = op.LanguageList;

            foreach (string language in languages)
            {
                RadComboBoxItem item = new RadComboBoxItem(language,language);
                languageList.Items.Add(item);
            }
            languageList.DataBind();
        }


        public void UpdateGrid(RadGrid vendorGrid)
        {
            Collection<InternalVendorGridClass> prods = new Collection<InternalVendorGridClass>();
            foreach (CatalogVendor vendor in this.vendors)
            {
                InternalVendorGridClass prod = new InternalVendorGridClass();
                prod.VendorName = vendor.VendorName;
                prod.VendorLink = vendor.VendorLink;
                prods.Add(prod);
            }
            vendorGrid.DataSource = prods;

            vendorGrid.Rebind();

        }

        public void AddVendor(string vendorName, string vendorLink)
        {
            CatalogVendorSetOperation vendorSet = new CatalogVendorSetOperation();
            CatalogVendor vendor = new CatalogVendor();
            vendor.VendorName = vendorName;
            vendor.VendorLink = vendorLink;
            vendorSet.SetParameters(vendor);
            vendorSet.Execute();
            this.Refresh();
        }

        public CatalogVendor GetVendor(int vendorId, string threeLetterLanguageCode)
        {

            CatalogVendorGetOperation vendorGet = new CatalogVendorGetOperation();
            vendorGet.SetParameters(vendorId, threeLetterLanguageCode);
            vendorGet.Execute();
            return vendorGet.VendorList[0]; ;
        }

        public void UpdateLocVendor(CatalogVendor vendor, string threeLetterLanguageCode)
        {
            CatalogVendorLocSetOperation vendorSet = new CatalogVendorLocSetOperation();
            vendorSet.SetParameters(vendor, threeLetterLanguageCode);
            vendorSet.Execute();
        }


        public string GetLocalizeXml(int vendorId, string threeLetterLanguageCode)
        {
            CatalogVendor vendor = this.GetVendor(vendorId, threeLetterLanguageCode);
            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("Vendor");
            XmlAttribute language = doc.CreateAttribute("Language");
            language.Value = threeLetterLanguageCode;
            root.Attributes.Append(language);

            XmlNode vendorIdNode = doc.CreateElement("Id");
            vendorIdNode.InnerText = vendor.VendorId.ToString();
            root.AppendChild(vendorIdNode);

            XmlNode vendorNameNode = doc.CreateElement("Name");
            vendorNameNode.InnerText = vendor.VendorName;
            root.AppendChild(vendorNameNode);

            XmlNode vendorLinkNode = doc.CreateElement("Link");
            vendorLinkNode.InnerText = vendor.VendorLink;
            root.AppendChild(vendorLinkNode);

            doc.AppendChild(root);

            return doc.InnerXml;
        }
    }
}
