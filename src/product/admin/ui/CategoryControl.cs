using System;
using System.Collections.Generic;
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
    public class CategoryControl
    {
        private static CategoryControl internalControl;

        /// <summary>
        /// category list
        /// </summary>
        private Collection<CatalogCategory> categories;

        /// <summary>
        /// Initializes a new instance of the CategoryControl class.
        /// </summary>
        private CategoryControl()
        {
            this.Refresh();
        }

        public static CategoryControl getInstance()
        {

            if (internalControl == null)
            {
                internalControl = new CategoryControl();
            }
            return internalControl;
        }

        public void Refresh()
        {
            CatalogCategoryGetOperation categoryGet = new CatalogCategoryGetOperation();
            categoryGet.SetParameters(0,"ENU");
            categoryGet.Execute();
            this.categories = categoryGet.CategoryList;
        }

        public void UpdateList(RadComboBox categoryList, int parentId)
        {
            categoryList.Items.Clear();
            RadComboBoxItem noneItem = new RadComboBoxItem("None","0");
            categoryList.Items.Add(noneItem);

            foreach (CatalogCategory category in this.categories)
            {
                if (category.ParentCategoryId == parentId)
                {
                    RadComboBoxItem item = new RadComboBoxItem(category.DisplayName, category.CategoryId.ToString());
                    categoryList.Items.Add(item);
                }
            }
            categoryList.DataBind();


        }

        public void UpdateAssociatedProductList(RadComboBox productList, int categoryId)
        {
            productList.Items.Clear();
            RadComboBoxItem noneItem = new RadComboBoxItem("None", "0");
            productList.Items.Add(noneItem);

            CatalogItemAssociatedProductGetOperation op = new CatalogItemAssociatedProductGetOperation();
            op.SetParameters(categoryId);
            op.Execute();

            foreach (CatalogProduct product in op.ProductList)
            {
                RadComboBoxItem item = new RadComboBoxItem(product.ProductName + " " + product.ProductVersion, product.ProductId.ToString());
                productList.Items.Add(item);
            }
            productList.DataBind();
        }

        public void UpdateUnAssociatedProductList(RadComboBox productList, int categoryId)
        {
            productList.Items.Clear();
            RadComboBoxItem noneItem = new RadComboBoxItem("None", "0");
            productList.Items.Add(noneItem);

            CatalogItemUnAssociatedProductGetOperation op = new CatalogItemUnAssociatedProductGetOperation();
            op.SetParameters(categoryId);
            op.Execute();

            foreach (CatalogProduct product in op.ProductList)
            {
                RadComboBoxItem item = new RadComboBoxItem(product.ProductName + " " + product.ProductVersion, product.ProductId.ToString());
                productList.Items.Add(item);
            }
            productList.DataBind();
        }



        public void UpdateLocDropDownList(RadComboBox languageList, int categoryId)
        {
            languageList.Items.Clear();

            CatalogCategoryLocGetOperation op = new CatalogCategoryLocGetOperation();
            op.SetParameters(categoryId);
            op.Execute();

            Collection<string> languages = op.LanguageList;

            foreach (string language in languages)
            {
                RadComboBoxItem item = new RadComboBoxItem(language, language);
                languageList.Items.Add(item);
            }
            languageList.DataBind();
        }



        public CatalogCategory getCategory(int categoryId, string threeLetterLanguageCode)
        {
            CatalogCategoryGetOperation catGet = new CatalogCategoryGetOperation();
            catGet.SetParameters(categoryId, threeLetterLanguageCode);
            catGet.Execute();
            return catGet.CategoryList[0];
        }

        public CatalogCategoryExtendedInfo getCategoryExtendedInfo(int categoryId, string threeLetterLanguageCode)
        {
            CatalogCategoryExtendedInfoGetOperation catExGet = new CatalogCategoryExtendedInfoGetOperation();
            catExGet.SetParameters(categoryId, threeLetterLanguageCode);
            catExGet.Execute();
            return catExGet.CategoryExtendedInfoList[0];
        }


        public void UpdateTree(RadTreeView categoryTree)
        {
            categoryTree.Nodes.Clear();

            Dictionary<int, RadTreeNode> treeNodes = new Dictionary<int, RadTreeNode>();

            foreach (CatalogCategory catalogCategory in this.categories)
            {
                RadTreeNode item = new RadTreeNode(catalogCategory.DisplayName, catalogCategory.CategoryId.ToString());
                if (catalogCategory.PublishedInd == false)
                {
                    item.Text += " (Unpublished)";
                }
                treeNodes[catalogCategory.CategoryId] = item;
            }

            foreach (CatalogCategory category in this.categories)
            {
                if (category.ParentCategoryId != 0)
                {
                    treeNodes[category.ParentCategoryId].Nodes.Add(treeNodes[category.CategoryId]);
                }
            }

            foreach (RadTreeNode node in treeNodes.Values)
            {
                if (node.Parent == null)
                {
                    categoryTree.Nodes.Add(node);
                }
            }

            categoryTree.DataBind();

        }

        public void AddCategory(string displayName, int parentId)
        {

            foreach (CatalogCategory catalogCategory in this.categories)
            {
                if(catalogCategory.ParentCategoryId == parentId && catalogCategory.DisplayName == displayName)
                {
                    throw new Exception("A category with display name : "+displayName+" belonging to parent category id : "+parentId.ToString()+" already exists");
                }
            }


            CatalogCategorySetOperation categorySet = new CatalogCategorySetOperation();
            CatalogCategory category = new CatalogCategory();
            category.CategoryId = 0;
            category.DisplayName = displayName;
            category.ParentCategoryId = parentId;
            category.GuideUriLink = "";
            category.GuideUriText = "";
            category.PublishedInd = false;


            CatalogCategoryExtendedInfo info = new CatalogCategoryExtendedInfo();
            info.CategoryId = 0;
            info.Description = "";
            categorySet.SetParameters(category, info);
            categorySet.Execute();

            this.Refresh();
        }

        public void UpdateCategory(CatalogCategory category, CatalogCategoryExtendedInfo categoryInfo)
        {
            CatalogCategorySetOperation catSetOp = new CatalogCategorySetOperation();
            catSetOp.SetParameters(category, categoryInfo);
            catSetOp.Execute();
            this.Refresh();
        }

        public void UpdateLocCategory(CatalogCategory category, CatalogCategoryExtendedInfo categoryInfo, string threeLetterLanguageCode)
        {
            CatalogCategoryLocSetOperation catLocSetOp = new CatalogCategoryLocSetOperation();
            catLocSetOp.SetParameters(category, categoryInfo,threeLetterLanguageCode);            
            catLocSetOp.Execute();
            this.Refresh();
        }


        public string GetLocalizeXml(int categoryId, string threeLetterLanguageCode)
        {
            CatalogCategory category = this.getCategory(categoryId, threeLetterLanguageCode);
            CatalogCategoryExtendedInfo info = this.getCategoryExtendedInfo(categoryId, threeLetterLanguageCode);

            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("Category");
            XmlAttribute language = doc.CreateAttribute("Language");
            language.Value = threeLetterLanguageCode;
            root.Attributes.Append(language);

            
            XmlNode categoryIdNode = doc.CreateElement("Id");
            categoryIdNode.InnerText = category.CategoryId.ToString();
            root.AppendChild(categoryIdNode);

            XmlNode categoryNameNode = doc.CreateElement("Name");
            categoryNameNode.InnerText = category.DisplayName;
            root.AppendChild(categoryNameNode);

            XmlNode categoryDescNode = doc.CreateElement("Description");
            categoryDescNode.InnerText = info.Description;
            root.AppendChild(categoryDescNode);


            XmlNode categoryGuideUriTextNode = doc.CreateElement("GuideUriText");
            categoryGuideUriTextNode.InnerText = category.GuideUriText;
            root.AppendChild(categoryGuideUriTextNode);

            XmlNode categoryGuideUriLinkNode = doc.CreateElement("GuideUriLink");
            categoryGuideUriLinkNode.InnerText = category.GuideUriLink;
            root.AppendChild(categoryGuideUriLinkNode);


            doc.AppendChild(root);

            return doc.InnerXml;
        }

    }
}
