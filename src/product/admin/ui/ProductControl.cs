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
using Microsoft.ManagementPackCatalog.Admin.Access;
using Microsoft.ManagementPackCatalog.Admin.Classes;
using Telerik.WebControls;
using Telerik.Web.UI;

namespace Microsoft.ManagementPackCatalog.Admin.UI
{
    public class ProductControl
    {
        private class InternalProductGridClass
        {
            private string productName;
            private string productVersion;

            public string ProductName
            {
                get { return this.productName; }
                set { this.productName = value; }
            }

            public string ProductVersion
            {
                get { return this.productVersion; }
                set { this.productVersion = value; }
            }


        }

        private static ProductControl internalControl;

        /// <summary>
        /// product list
        /// </summary>
        private Collection<CatalogProduct> products;

        /// <summary>
        /// Initializes a new instance of the ProductListControl class.
        /// </summary>
        private ProductControl()
        {
            this.Refresh();
        }

        public static ProductControl getInstance()
        {

            if(internalControl == null)
            {
                internalControl = new ProductControl();
            }
            return internalControl;
        }

        public void Refresh()
        {
            CatalogProductGetOperation productGet = new CatalogProductGetOperation();
            productGet.SetParameters(0);
            productGet.Execute();
            this.products = productGet.ProductList;
        }

        public void UpdateList(RadComboBox productList)
        {
            productList.Items.Clear();

            foreach (CatalogProduct product in this.products)
            {
                RadComboBoxItem item = new RadComboBoxItem(product.ProductName + " " + product.ProductVersion, product.ProductId.ToString());
                productList.Items.Add(item);
            }
            productList.DataBind();

        }

        public void UpdateGrid(RadGrid productGrid)
        {
            Collection<InternalProductGridClass> prods = new Collection<InternalProductGridClass>();
            foreach (CatalogProduct product in this.products)
            {
                InternalProductGridClass prod = new InternalProductGridClass();
                prod.ProductName = product.ProductName;
                prod.ProductVersion = product.ProductVersion.ToString();
                prods.Add(prod);
            }
            productGrid.DataSource = prods;

            productGrid.Rebind();

        }

        public void AddProduct(string productName, Version productVersion)
        {
            CatalogProductSetOperation productSet = new CatalogProductSetOperation();
            CatalogProduct product = new CatalogProduct();
            product.ProductName = productName;
            product.ProductVersion = productVersion.ToString();
            productSet.SetParameters(product);
            productSet.Execute();

            this.Refresh();
        }
    }
}
