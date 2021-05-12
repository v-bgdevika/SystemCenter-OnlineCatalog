using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;

using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;

using Microsoft.ManagementPackCatalog.Admin.Classes;

namespace Microsoft.ManagementPackCatalog.Admin.UI
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.CategoryCreate_Page.PreRender += CategoryCreate_Refresh;

            //this.CategoryEdit_Page.PreRender += CategoryEdit_Refresh;

            //this.CategoryAssociate_Page.PreRender += CategoryAssociate_Refresh;

            //this.CategoryAssignMps_Page.PreRender += CategoryAssignMps_Refresh;

            //this.CategoryLocalize_Page.PreRender += CategoryLocalize_Refresh;

            //this.ManagementPackAdd_Page.PreRender += ManagementPackAdd_Refresh;

            //this.ManagementPackEdit_Page.PreRender += ManagementPackEdit_Refresh;

            //this.ManagementPackAssociate_Page.PreRender += ManagementPackAssociate_Refresh;

            //this.ManagementPackLocalize_Page.PreRender += ManagementPackLocalize_Refresh;

            //this.ProductCreate_Page.PreRender += ProductCreate_Refresh;

            //this.VendorCreate_Page.PreRender += VendorCreate_Refresh;

            //this.VendorLocalize_Page.PreRender += VendorLocalize_Refresh;

            //this.LocalizationUpload_Page.PreRender += LocalizationUpload_Refresh;

        }

        protected void CategoryCreate_Refresh(object sender, EventArgs e)
        {
            CategoryControl.getInstance().UpdateList(this.CategoryCreate_TechnologyName_DropDown,0);
            this.CategoryCreate_TechnologyName_DropDown.Enabled = true;
            this.CategoryCreate_TechnologyName_DropDown.SelectedIndex = 0;
            this.CategoryCreate_TechnologyName_TextBox.Enabled = true;
            this.CategoryCreate_ProductName_DropDown.Enabled = false;
            this.CategoryCreate_ProductName_DropDown.SelectedIndex = 0;
            this.CategoryCreate_ProductName_TextBox.Enabled = false;
            this.CategoryCreate_LanguagePack_CheckBox.Checked = false;
        }

        protected void CategoryEdit_Refresh(object sender, EventArgs e)
        {
            CategoryControl.getInstance().UpdateTree(this.CategoryEdit_Existing_TreeView);
        }

        protected void CategoryAssociate_Refresh(object sender, EventArgs e)
        {
            CategoryControl.getInstance().UpdateTree(this.CategoryAssociate_Existing_TreeView);
        }

        protected void CategoryAssignMps_Refresh(object sender, EventArgs e)
        {
            CategoryControl.getInstance().UpdateTree(this.CategoryAssignMps_Existing_Category_TreeView);
        }

        protected void CategoryLocalize_Refresh(object sender, EventArgs e)
        {
            CategoryControl.getInstance().UpdateTree(this.CategoryLocalize_Existing_TreeView);
        }

        protected void ManagementPackAdd_Refresh(object sender, EventArgs e)
        {
            VendorControl.getInstance().UpdateDropDownList(this.ManagementPackAdd_Vendor_DropDown);
        }

        protected void ManagementPackEdit_Refresh(object sender, EventArgs e)
        {
            ManagementPackControl.getInstance().UpdateGrid(this.ManagementPackEdit_Existing_Grid);
        }

        protected void ManagementPackAssociate_Refresh(object sender, EventArgs e)
        {
            ManagementPackControl.getInstance().UpdateGrid(this.ManagementPackAssociate_Existing_Grid);
        }

        protected void ManagementPackLocalize_Refresh(object sender, EventArgs e)
        {
            ManagementPackControl.getInstance().UpdateGrid(this.ManagementPackLocalize_Existing_Grid);
        }

        protected void ProductCreate_Refresh(object sender, EventArgs e)
        {
            ProductControl.getInstance().UpdateGrid(this.ProductCreate_Existing_Grid);
        }

        protected void VendorCreate_Refresh(object sender, EventArgs e)
        {
            VendorControl.getInstance().UpdateGrid(this.VendorCreate_Existing_Grid);
        }

        protected void VendorLocalize_Refresh(object sender, EventArgs e)
        {
            VendorControl.getInstance().UpdateDropDownList(this.VendorLocalize_Existing_ComboBox);
        }

        protected void LocalizationUpload_Refresh(object sender, EventArgs e)
        {
            this.LocalizationUpload_FileUpload.TargetPhysicalFolder = System.IO.Path.GetTempPath();
        }


        protected void CategoryCreate_TechnologyName_DropDown_OnSelectedIndexChanged(object o, Telerik.WebControls.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (this.CategoryCreate_TechnologyName_DropDown.SelectedValue == "0")
            {
                this.CategoryCreate_TechnologyName_TextBox.Enabled = true;
                this.CategoryCreate_ProductName_TextBox.Enabled = false;
                this.CategoryCreate_ProductName_DropDown.Enabled = false;
                this.CategoryCreate_LanguagePack_CheckBox.Checked = false;
            }
            else
            {
                this.CategoryCreate_TechnologyName_TextBox.Enabled = false;
                this.CategoryCreate_ProductName_TextBox.Enabled = true;
                this.CategoryCreate_ProductName_DropDown.Enabled = true;
                this.CategoryCreate_LanguagePack_CheckBox.Checked = false;
                CategoryControl.getInstance().UpdateList(this.CategoryCreate_ProductName_DropDown, System.Convert.ToInt32(this.CategoryCreate_TechnologyName_DropDown.SelectedValue));

            }
            this.CategoryCreate_TechnologyName_DropDown.SelectedValue = this.CategoryCreate_TechnologyName_DropDown.SelectedValue;
        }

        protected void CategoryCreate_ProductName_DropDown_OnSelectedIndexChanged(object o, Telerik.WebControls.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (this.CategoryCreate_ProductName_DropDown.SelectedValue == "0")
            {
                this.CategoryCreate_ProductName_TextBox.Enabled = true;
                this.CategoryCreate_LanguagePack_CheckBox.Checked = false;
            }
            else
            {
                this.CategoryCreate_ProductName_TextBox.Enabled = false;
                this.CategoryCreate_LanguagePack_CheckBox.Checked = true;
                this.CategoryCreate_ProductName_DropDown.Enabled = true;
            }

            this.CategoryCreate_TechnologyName_DropDown.SelectedValue = this.CategoryCreate_TechnologyName_DropDown.SelectedValue;
            this.CategoryCreate_ProductName_DropDown.SelectedValue = this.CategoryCreate_ProductName_DropDown.SelectedValue;

        }


        protected void CategoryCreate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string displayName;
                int parentId;
                if (this.CategoryCreate_LanguagePack_CheckBox.Checked == true)
                {
                    displayName = "Language Pack";
                    parentId = System.Convert.ToInt32(this.CategoryCreate_ProductName_DropDown.SelectedValue);
                }
                else if (this.CategoryCreate_ProductName_TextBox.Enabled == true)
                {
                    displayName = this.CategoryCreate_ProductName_TextBox.Text;
                    parentId = System.Convert.ToInt32(this.CategoryCreate_TechnologyName_DropDown.SelectedValue);
                }
                else
                {
                    displayName = this.CategoryCreate_TechnologyName_TextBox.Text;
                    parentId = 0;
                }

                if (String.IsNullOrEmpty(displayName))
                {
                    throw new Exception("Null or empty display name passed");
                }

                CategoryControl.getInstance().AddCategory(displayName, parentId);

                this.CategoryCreate_Status.ForeColor = System.Drawing.Color.Green;
                this.CategoryCreate_Status.Text = "Successfully created category with display name : " + displayName + " and parent category id : " + parentId;


                this.CategoryCreate_TechnologyName_TextBox.Text = "";
                this.CategoryCreate_ProductName_TextBox.Text = "";


            }
            catch (Exception ex)
            {
                this.CategoryCreate_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryCreate_Status.Text = ex.Message;
            }
            this.CategoryCreate_TechnologyName_DropDown.SelectedValue = this.CategoryCreate_TechnologyName_DropDown.SelectedValue;
            this.CategoryCreate_ProductName_DropDown.SelectedValue = this.CategoryCreate_ProductName_DropDown.SelectedValue;
        }

        protected void CategoryEdit_Existing_TreeView_NodeClick(object o, Telerik.WebControls.RadTreeNodeEventArgs e)
        {
            try
            {
                int categoryId = System.Convert.ToInt32(this.CategoryEdit_Existing_TreeView.SelectedNode.Value);

                CatalogCategory category = CategoryControl.getInstance().getCategory(categoryId, "ENU");
                CatalogCategoryExtendedInfo info = CategoryControl.getInstance().getCategoryExtendedInfo(categoryId, "ENU");

                this.CategoryEdit_CategoryId_TextBox.Text = category.CategoryId.ToString();
                this.CategoryEdit_ParentCategoryId_TextBox.Text = category.ParentCategoryId.ToString();
                this.CategoryEdit_DisplayName_TextBox.Text = category.DisplayName;
                this.CategoryEdit_Description_TextArea.Value = info.Description;
                this.CategoryEdit_GuideUriLink_TextBox.Text = category.GuideUriLink;
                this.CategoryEdit_GuideUriText_TextBox.Text = category.GuideUriText;
                this.CategoryEdit_Published_CheckBox.Checked = category.PublishedInd;
            }
            catch (Exception ex)
            {
                this.CategoryEdit_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryEdit_Status.Text = ex.Message;
            }
        }


        protected void CategoryEdit_Submit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogCategory category = new CatalogCategory();
                CatalogCategoryExtendedInfo info = new CatalogCategoryExtendedInfo();
                category.CategoryId = System.Convert.ToInt32(this.CategoryEdit_CategoryId_TextBox.Text);
                category.DisplayName = this.CategoryEdit_DisplayName_TextBox.Text;
                category.GuideUriLink = this.CategoryEdit_GuideUriLink_TextBox.Text;
                category.GuideUriText = this.CategoryEdit_GuideUriText_TextBox.Text;
                category.ParentCategoryId = System.Convert.ToInt32(this.CategoryEdit_ParentCategoryId_TextBox.Text);
                category.PublishedInd = this.CategoryEdit_Published_CheckBox.Checked;

                info.CategoryId = System.Convert.ToInt32(this.CategoryEdit_CategoryId_TextBox.Text);
                info.Description = this.CategoryEdit_Description_TextArea.Value;

                CategoryControl.getInstance().UpdateCategory(category, info);

                CategoryControl.getInstance().UpdateTree(this.CategoryEdit_Existing_TreeView);
            }
            catch (Exception ex)
            {
                this.CategoryEdit_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryEdit_Status.Text = ex.Message;
            }
        }

        protected void CategoryAssociate_Existing_TreeView_NodeClick(object o, Telerik.WebControls.RadTreeNodeEventArgs e)
        {
            try
            {
                int categoryId = System.Convert.ToInt32(this.CategoryAssociate_Existing_TreeView.SelectedNode.Value);

                CatalogCategory category = CategoryControl.getInstance().getCategory(categoryId, "ENU");
                CatalogCategoryExtendedInfo info = CategoryControl.getInstance().getCategoryExtendedInfo(categoryId, "ENU");

                this.CategoryAssociate_CategoryId_TextBox.Text = category.CategoryId.ToString();
                this.CategoryAssociate_ParentId_TextBox.Text = category.ParentCategoryId.ToString();
                this.CategoryAssociate_DisplayName_TextBox.Text = category.DisplayName;

                CategoryControl.getInstance().UpdateAssociatedProductList(this.CategoryAssociate_Associated_ComboBox, categoryId);
                CategoryControl.getInstance().UpdateUnAssociatedProductList(this.CategoryAssociate_UnAssociated_ComboBox, categoryId);

                this.CategoryAssociate_Associate_Button.Enabled = true;
                this.CategoryAssociate_UnAssociate_Button.Enabled = true;

                this.CategoryAssociate_Associated_ComboBox.Enabled = true;
                this.CategoryAssociate_UnAssociated_ComboBox.Enabled = true;

            }
            catch (Exception ex)
            {
                this.CategoryAssociate_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryAssociate_Status.Text = ex.Message;
            }
        }

        protected void CategoryAssociate_Associate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = System.Convert.ToInt32(this.CategoryAssociate_CategoryId_TextBox.Text);
                int productId = System.Convert.ToInt32(this.CategoryAssociate_UnAssociated_ComboBox.SelectedValue);

                if (categoryId == 0 || productId == 0) return;

                Microsoft.ManagementPackCatalog.Admin.Access.CatalogProductCatalogItemSetOperation op = new Microsoft.ManagementPackCatalog.Admin.Access.CatalogProductCatalogItemSetOperation();
                op.SetParameters(categoryId, productId);
                op.Execute();

                this.CategoryAssociate_Status.ForeColor = System.Drawing.Color.Green;
                this.CategoryAssociate_Status.Text = "Associated product : " + this.CategoryAssociate_UnAssociated_ComboBox.SelectedItem.Text + " with category "+ this.CategoryAssociate_DisplayName_TextBox.Text;

                CategoryControl.getInstance().UpdateAssociatedProductList(this.CategoryAssociate_Associated_ComboBox, categoryId);
                CategoryControl.getInstance().UpdateUnAssociatedProductList(this.CategoryAssociate_UnAssociated_ComboBox, categoryId);

            }
            catch (Exception ex)
            {
                this.CategoryAssociate_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryAssociate_Status.Text = ex.Message;
            }
        }


        protected void CategoryAssociate_UnAssociate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int categoryId = System.Convert.ToInt32(this.CategoryAssociate_CategoryId_TextBox.Text);
                int productId = System.Convert.ToInt32(this.CategoryAssociate_Associated_ComboBox.SelectedValue);

                if (categoryId == 0 || productId == 0) return;

                Microsoft.ManagementPackCatalog.Admin.Access.CatalogProductCatalogItemUnSetOperation op = new Microsoft.ManagementPackCatalog.Admin.Access.CatalogProductCatalogItemUnSetOperation();
                op.SetParameters(categoryId, productId);
                op.Execute();

                this.CategoryAssociate_Status.ForeColor = System.Drawing.Color.Green;
                this.CategoryAssociate_Status.Text = "UnAssociated product : " + this.CategoryAssociate_Associated_ComboBox.SelectedItem.Text + " with category " + this.CategoryAssociate_DisplayName_TextBox.Text;

                CategoryControl.getInstance().UpdateAssociatedProductList(this.CategoryAssociate_Associated_ComboBox, categoryId);
                CategoryControl.getInstance().UpdateUnAssociatedProductList(this.CategoryAssociate_UnAssociated_ComboBox, categoryId);

            }
            catch (Exception ex)
            {
                this.CategoryAssociate_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryAssociate_Status.Text = ex.Message;
            }
        }

        protected void CategoryAssignMps_Existing_Category_TreeView_NodeClick(object o, Telerik.WebControls.RadTreeNodeEventArgs e)
        {
            try
            {
                int categoryId = System.Convert.ToInt32(this.CategoryAssignMps_Existing_Category_TreeView.SelectedNode.Value);

                CatalogCategory category = CategoryControl.getInstance().getCategory(categoryId, "ENU");
                CatalogCategoryExtendedInfo info = CategoryControl.getInstance().getCategoryExtendedInfo(categoryId, "ENU");

                this.CategoryAssignMps_Category_Id_TextBox.Text = category.CategoryId.ToString();
                this.CategoryAssignMps_Category_ParentId_TextBox.Text = category.ParentCategoryId.ToString();
                this.CategoryAssignMps_Category_DisplayName_TextBox.Text = category.DisplayName;

                ManagementPackControl.getInstance().UpdateCategoryAssignedMpGrid(this.CategoryAssignMps_Existing_Assigned_ManagementPacks_Grid, categoryId);
                ManagementPackControl.getInstance().UpdateCategoryUnAssignedMpGrid(this.CategoryAssignMps_Existing_UnAssigned_ManagementPacks_Grid, categoryId);

                this.CategoryAssignMps_Assigned_ManagementPacks_Id_TextBox.Text = "";
                this.CategoryAssignMps_Assigned_ManagementPacks_SystemName_TextBox.Text = "";
                this.CategoryAssignMps_Assigned_ManagementPacks_PublicKey_TextBox.Text = "";
                this.CategoryAssignMps_Assigned_ManagementPacks_Version_TextBox.Text = "";
                this.CategoryAssignMps_RemoveMp_Button.Enabled = false;

                this.CategoryAssignMps_UnAssigned_ManagementPacks_Id_TextBox.Text = "";
                this.CategoryAssignMps_UnAssigned_ManagementPacks_SystemName_TextBox.Text = "";
                this.CategoryAssignMps_UnAssigned_ManagementPacks_PublicKey_TextBox.Text = "";
                this.CategoryAssignMps_UnAssigned_ManagementPacks_Version_TextBox.Text = "";
                this.CategoryAssignMps_AddMp_Button.Enabled = false;

            }
            catch (Exception ex)
            {
                this.CategoryAssignMps_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryAssignMps_Status.Text = ex.Message;
            }
        }


        protected void CategoryAssignMps_Existing_Assigned_ManagementPacks_Grid_OnItemCommand(object source, Telerik.WebControls.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "RowClick" && e.Item is Telerik.WebControls.GridDataItem)
                {

                    e.Item.Selected = true;

                    int mpId = System.Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ManagementPackId"].ToString());

                    CatalogManagementPack mp = ManagementPackControl.getInstance().getManagementPack(mpId, "ENU");
                    CatalogManagementPackExtendedInfo info = ManagementPackControl.getInstance().getManagementPackExtendedInfo(mpId, "ENU");

                    this.CategoryAssignMps_Assigned_ManagementPacks_Id_TextBox.Text = mp.ManagementPackId.ToString();

                    this.CategoryAssignMps_Assigned_ManagementPacks_SystemName_TextBox.Text = mp.SystemName;
                    this.CategoryAssignMps_Assigned_ManagementPacks_PublicKey_TextBox.Text = mp.PublicKey;
                    this.CategoryAssignMps_Assigned_ManagementPacks_Version_TextBox.Text = mp.Version.ToString();

                    this.CategoryAssignMps_RemoveMp_Button.Enabled = true;
               }
            }
            catch (Exception ex)
            {
                this.CategoryAssignMps_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryAssignMps_Status.Text = ex.Message;
            }
        }

        protected void CategoryAssignMps_Existing_UnAssigned_ManagementPacks_Grid_OnItemCommand(object source, Telerik.WebControls.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "RowClick" && e.Item is Telerik.WebControls.GridDataItem)
                {

                    e.Item.Selected = true;

                    int mpId = System.Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ManagementPackId"].ToString());

                    CatalogManagementPack mp = ManagementPackControl.getInstance().getManagementPack(mpId, "ENU");
                    CatalogManagementPackExtendedInfo info = ManagementPackControl.getInstance().getManagementPackExtendedInfo(mpId, "ENU");

                    this.CategoryAssignMps_UnAssigned_ManagementPacks_Id_TextBox.Text = mp.ManagementPackId.ToString();

                    this.CategoryAssignMps_UnAssigned_ManagementPacks_SystemName_TextBox.Text = mp.SystemName;
                    this.CategoryAssignMps_UnAssigned_ManagementPacks_PublicKey_TextBox.Text = mp.PublicKey;
                    this.CategoryAssignMps_UnAssigned_ManagementPacks_Version_TextBox.Text = mp.Version.ToString();

                    this.CategoryAssignMps_AddMp_Button.Enabled = true;

                }


            }
            catch (Exception ex)
            {
                this.CategoryAssignMps_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryAssignMps_Status.Text = ex.Message;
            }
        }


        protected void CategoryAssignMps_AddMp_Button_OnClick(object sender, EventArgs e)
        {

            try
            {
                int categoryId = System.Convert.ToInt32(this.CategoryAssignMps_Category_Id_TextBox.Text);
                int mpId = System.Convert.ToInt32(this.CategoryAssignMps_UnAssigned_ManagementPacks_Id_TextBox.Text);

                Microsoft.ManagementPackCatalog.Admin.Access.CatalogManagementPackCategorySetOperation op = new Microsoft.ManagementPackCatalog.Admin.Access.CatalogManagementPackCategorySetOperation();
                op.SetParameters(categoryId, mpId);
                op.Execute();

                this.CategoryAssignMps_Status.ForeColor = System.Drawing.Color.Green;
                this.CategoryAssignMps_Status.Text = "Added MP " + this.CategoryAssignMps_UnAssigned_ManagementPacks_SystemName_TextBox.Text + " to category " + this.CategoryAssignMps_Category_DisplayName_TextBox.Text;

                this.CategoryAssignMps_AddMp_Button.Enabled = false;

                ManagementPackControl.getInstance().UpdateCategoryAssignedMpGrid(this.CategoryAssignMps_Existing_Assigned_ManagementPacks_Grid, categoryId);
                ManagementPackControl.getInstance().UpdateCategoryUnAssignedMpGrid(this.CategoryAssignMps_Existing_UnAssigned_ManagementPacks_Grid, categoryId);


            }
            catch (Exception ex)
            {
                this.CategoryAssignMps_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryAssignMps_Status.Text = ex.Message;

            }
        }


        protected void CategoryAssignMps_RemoveMp_Button_OnClick(object sender, EventArgs e)
        {

            try
            {
                int categoryId = System.Convert.ToInt32(this.CategoryAssignMps_Category_Id_TextBox.Text);
                int mpId = System.Convert.ToInt32(this.CategoryAssignMps_Assigned_ManagementPacks_Id_TextBox.Text);

                Microsoft.ManagementPackCatalog.Admin.Access.CatalogManagementPackCategoryUnSetOperation op = new Microsoft.ManagementPackCatalog.Admin.Access.CatalogManagementPackCategoryUnSetOperation();
                op.SetParameters(categoryId, mpId);
                op.Execute();

                this.CategoryAssignMps_Status.ForeColor = System.Drawing.Color.Green;
                this.CategoryAssignMps_Status.Text = "Removed MP " + this.CategoryAssignMps_Assigned_ManagementPacks_SystemName_TextBox.Text + " to category " + this.CategoryAssignMps_Category_DisplayName_TextBox.Text;

                this.CategoryAssignMps_RemoveMp_Button.Enabled = false;

                ManagementPackControl.getInstance().UpdateCategoryAssignedMpGrid(this.CategoryAssignMps_Existing_Assigned_ManagementPacks_Grid, categoryId);
                ManagementPackControl.getInstance().UpdateCategoryUnAssignedMpGrid(this.CategoryAssignMps_Existing_UnAssigned_ManagementPacks_Grid, categoryId);


            }
            catch (Exception ex)
            {
                this.CategoryAssignMps_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryAssignMps_Status.Text = ex.Message;

            }
        }




        protected void CategoryLocalize_Existing_TreeView_NodeClick(object o, Telerik.WebControls.RadTreeNodeEventArgs e)
        {
            try
            {
                int categoryId = System.Convert.ToInt32(this.CategoryLocalize_Existing_TreeView.SelectedNode.Value);

                CatalogCategory category = CategoryControl.getInstance().getCategory(categoryId, "ENU");

                this.CategoryLocalize_Id_TextBox.Text = category.CategoryId.ToString();
                this.CategoryLocalize_ParentId_TextBox.Text = category.ParentCategoryId.ToString();
                this.CategoryLocalize_Name_TextBox.Text = category.DisplayName;

                CategoryControl.getInstance().UpdateLocDropDownList(this.CategoryLocalize_Languages_ComboBox, category.CategoryId);

                this.CategoryLocalize_Languages_ComboBox.Enabled = true;
                this.CategoryLocalize_Submit_Button.Enabled = true;
            }
            catch (Exception ex)
            {
                this.CategoryLocalize_Status.ForeColor = System.Drawing.Color.Red;
                this.CategoryLocalize_Status.Text = ex.Message;
            }
        }


        protected void CategoryLocalize_Submit_Button_Click(object sender, EventArgs e)
        {
            this.CategoryLocalize_Languages_ComboBox.SelectedValue = this.CategoryLocalize_Languages_ComboBox.SelectedValue;


            int categoryId = System.Convert.ToInt32(this.CategoryLocalize_Id_TextBox.Text);
            string threeLetterLanguageCode = this.CategoryLocalize_Languages_ComboBox.SelectedValue;

            string locString = CategoryControl.getInstance().GetLocalizeXml(categoryId, threeLetterLanguageCode);

            string filename = "Category_" + categoryId + "_" + threeLetterLanguageCode + ".xml";

            this.DownloadLocContent(filename, locString);
        }


        protected void ManagementPackAdd_Upload_Button_Click(object sender, EventArgs e)
        {
            
            try
            {
                string url = this.ManagementPackAdd_Url_TextBox.Text;

                if (String.IsNullOrEmpty(url))
                {
                    throw new Exception("Management Pack Url is null or empty");
                }
                WebClient client = new WebClient();
                
                string filename = System.IO.Path.GetFileName(url);
                string tempfile = System.IO.Path.GetTempPath() + "\\" + filename;
            
                               
                client.DownloadFile(url, tempfile);

                ManagementPack mp = new ManagementPack(tempfile);
                this.ManagementPackAdd_SystemName_TextBox.Text = mp.Name;
                this.ManagementPackAdd_Version_TextBox.Text = mp.Version.ToString();
                this.ManagementPackAdd_PublicKey_TextBox.Text = mp.KeyToken;
                this.ManagementPackAdd_TempFile_TextBox_Hidden.Text = tempfile;
                this.ManagementPackAdd_Url_TextBox.Enabled = false;
                this.ManagementPackAdd_Submit_Button.Enabled = true;
                this.ManagementPackAdd_Status.Text = "";

            }
            catch (Exception ex)
            {
                this.ManagementPackAdd_Status.ForeColor = System.Drawing.Color.Red;
                this.ManagementPackAdd_Status.Text = ex.Message;
            }
            this.ManagementPackAdd_Vendor_DropDown.SelectedValue = this.ManagementPackAdd_Vendor_DropDown.SelectedValue;
        }

        protected void ManagementPackAdd_Clear_Button_Click(object sender, EventArgs e)
        {
            this.ManagementPackAdd_Url_TextBox.Enabled = true;
            this.ManagementPackAdd_Url_TextBox.Text = "";
            this.ManagementPackAdd_TempFile_TextBox_Hidden.Text = "";
            this.ManagementPackAdd_PublicKey_TextBox.Text = "";
            this.ManagementPackAdd_SystemName_TextBox.Text = "";
            this.ManagementPackAdd_Version_TextBox.Text = "";
            this.ManagementPackAdd_Submit_Button.Enabled = false;
        }

        protected void ManagementPackAdd_Submit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ManagementPackAdd_Vendor_DropDown.SelectedValue == "0")
                {
                    throw new Exception("Please select a vendor");
                }

                ManagementPackControl.getInstance().AddManagementPack(this.ManagementPackAdd_Url_TextBox.Text, this.ManagementPackAdd_TempFile_TextBox_Hidden.Text, System.Convert.ToInt32(this.ManagementPackAdd_Vendor_DropDown.SelectedValue));

                this.ManagementPackAdd_Status.ForeColor = System.Drawing.Color.Green;
                this.ManagementPackAdd_Status.Text = "Successfully added MP : " + this.ManagementPackAdd_SystemName_TextBox.Text;
                this.ManagementPackAdd_Url_TextBox.Enabled = true;
                this.ManagementPackAdd_Url_TextBox.Text = "";
                this.ManagementPackAdd_TempFile_TextBox_Hidden.Text = "";
                this.ManagementPackAdd_PublicKey_TextBox.Text = "";
                this.ManagementPackAdd_SystemName_TextBox.Text = "";
                this.ManagementPackAdd_Version_TextBox.Text = "";
                this.ManagementPackAdd_Submit_Button.Enabled = false;

            }
            catch (Exception ex)
            {
                this.ManagementPackAdd_Status.ForeColor = System.Drawing.Color.Red;
                this.ManagementPackAdd_Status.Text = ex.Message;
            }

        }

        protected void ManagementPackEdit_Existing_Grid_OnItemCommand(object source, Telerik.WebControls.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "RowClick" && e.Item is Telerik.WebControls.GridDataItem)
                {

                    e.Item.Selected = true;

                    int mpId = System.Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ManagementPackId"].ToString());

                    CatalogManagementPack mp = ManagementPackControl.getInstance().getManagementPack(mpId, "ENU");
                    CatalogManagementPackExtendedInfo info = ManagementPackControl.getInstance().getManagementPackExtendedInfo(mpId, "ENU");

                    this.ManagementPackEdit_Id_TextBox.Text = mp.ManagementPackId.ToString();

                    this.ManagementPackEdit_SystemName_TextBox.Text = mp.SystemName;
                    this.ManagementPackEdit_PublicKey_TextBox.Text = mp.PublicKey;
                    this.ManagementPackEdit_Version_TextBox.Text = mp.Version.ToString();

                    this.ManagementPackEdit_VersionIndependentGuid_TextBox.Text = mp.VersionIndependentGuid.ToString();
                    this.ManagementPackEdit_DownloadUrl_TextBox.Text = mp.DownloadUri;
                    this.ManagementPackEdit_DisplayName_TextBox.Text = mp.DisplayName;
                    this.ManagementPackEdit_Description_TextArea.Value = info.Description;
                    this.ManagementPackEdit_ReleaseDate_TextBox.Text = mp.ReleaseDate.ToString();
                    this.ManagementPackEdit_Eula_CheckBox.Checked = mp.EulaInd;
                    this.ManagementPackEdit_Eula_TextArea.Value = info.Eula;
                    this.ManagementPackEdit_Knowledge_TextArea.Value = info.Knowledge;
                    this.ManagementPackEdit_Security_CheckBox.Checked = mp.SecurityInd;
                    this.ManagementPackEdit_Published_CheckBox.Checked = mp.PublishedInd;
                    this.ManagementPackEdit_VendorId_TextBox.Text = mp.VendorId.ToString();


                    this.ManagementPackEdit_Submit_Button.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                this.ManagementPackEdit_Status.ForeColor = System.Drawing.Color.Red;
                this.ManagementPackEdit_Status.Text = ex.Message;
            }


        }

        protected void ManagementPackAssociate_Existing_Grid_OnItemCommand(object source, Telerik.WebControls.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "RowClick" && e.Item is Telerik.WebControls.GridDataItem)
                {

                    e.Item.Selected = true;

                    int mpId = System.Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ManagementPackId"].ToString());

                    CatalogManagementPack mp = ManagementPackControl.getInstance().getManagementPack(mpId, "ENU");
                    CatalogManagementPackExtendedInfo info = ManagementPackControl.getInstance().getManagementPackExtendedInfo(mpId, "ENU");

                    this.ManagementPackAssociate_Id_TextBox.Text = mp.ManagementPackId.ToString();

                    this.ManagementPackAssociate_SystemName_TextBox.Text = mp.SystemName;
                    this.ManagementPackAssociate_PublicKey_TextBox.Text = mp.PublicKey;
                    this.ManagementPackAssociate_Version_TextBox.Text = mp.Version.ToString();

                    ManagementPackControl.getInstance().UpdateAssociatedProductList(this.ManagementPackAssociate_Associated_ComboBox, mpId);
                    ManagementPackControl.getInstance().UpdateUnAssociatedProductList(this.ManagementPackAssociate_UnAssociated_ComboBox, mpId);


                    this.ManagementPackAssociate_Associated_ComboBox.Enabled = true;
                    this.ManagementPackAssociate_UnAssociated_ComboBox.Enabled = true;

                    this.ManagementPackAssociate_Associate_Button.Enabled = true;
                    this.ManagementPackAssociate_UnAssociate_Button.Enabled = true;

                }


            }
            catch (Exception ex)
            {
                this.ManagementPackEdit_Status.ForeColor = System.Drawing.Color.Red;
                this.ManagementPackEdit_Status.Text = ex.Message;
            }


        }


        protected void ManagementPackAssociate_Associate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int mpId = System.Convert.ToInt32(this.ManagementPackAssociate_Id_TextBox.Text);
                int productId = System.Convert.ToInt32(this.ManagementPackAssociate_UnAssociated_ComboBox.SelectedValue);

                if (mpId == 0 || productId == 0) return;

                Microsoft.ManagementPackCatalog.Admin.Access.CatalogProductCatalogItemSetOperation op = new Microsoft.ManagementPackCatalog.Admin.Access.CatalogProductCatalogItemSetOperation();
                op.SetParameters(mpId, productId);
                op.Execute();

                this.ManagementPackAssociate_Status.ForeColor = System.Drawing.Color.Green;
                this.ManagementPackAssociate_Status.Text = "Associated product : " + this.ManagementPackAssociate_UnAssociated_ComboBox.SelectedItem.Text + " with mp " + this.ManagementPackAssociate_SystemName_TextBox.Text;

                ManagementPackControl.getInstance().UpdateAssociatedProductList(this.ManagementPackAssociate_Associated_ComboBox, mpId);
                ManagementPackControl.getInstance().UpdateUnAssociatedProductList(this.ManagementPackAssociate_UnAssociated_ComboBox, mpId);

            }
            catch (Exception ex)
            {
                this.ManagementPackAssociate_Status.ForeColor = System.Drawing.Color.Red;
                this.ManagementPackAssociate_Status.Text = ex.Message;
            }
        }


        protected void ManagementPackAssociate_UnAssociate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                int mpId = System.Convert.ToInt32(this.ManagementPackAssociate_Id_TextBox.Text);
                int productId = System.Convert.ToInt32(this.ManagementPackAssociate_Associated_ComboBox.SelectedValue);

                if (mpId == 0 || productId == 0) return;

                Microsoft.ManagementPackCatalog.Admin.Access.CatalogProductCatalogItemUnSetOperation op = new Microsoft.ManagementPackCatalog.Admin.Access.CatalogProductCatalogItemUnSetOperation();
                op.SetParameters(mpId, productId);
                op.Execute();

                this.ManagementPackAssociate_Status.ForeColor = System.Drawing.Color.Green;
                this.ManagementPackAssociate_Status.Text = "UnAssociated product : " + this.ManagementPackAssociate_Associated_ComboBox.SelectedItem.Text + " with mp " + this.ManagementPackAssociate_SystemName_TextBox.Text;

                ManagementPackControl.getInstance().UpdateAssociatedProductList(this.ManagementPackAssociate_Associated_ComboBox, mpId);
                ManagementPackControl.getInstance().UpdateUnAssociatedProductList(this.ManagementPackAssociate_UnAssociated_ComboBox, mpId);

            }
            catch (Exception ex)
            {
                this.ManagementPackAssociate_Status.ForeColor = System.Drawing.Color.Red;
                this.ManagementPackAssociate_Status.Text = ex.Message;
            }
        }




        protected void ManagementPackEdit_Submit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                CatalogManagementPack mp = new CatalogManagementPack();
                CatalogManagementPackExtendedInfo info = new CatalogManagementPackExtendedInfo();

                mp.ManagementPackId = System.Convert.ToInt32(this.ManagementPackEdit_Id_TextBox.Text);
                mp.SystemName = this.ManagementPackEdit_SystemName_TextBox.Text;
                mp.PublicKey = this.ManagementPackEdit_PublicKey_TextBox.Text;
                mp.Version = new Version(this.ManagementPackEdit_Version_TextBox.Text);
                mp.VersionIndependentGuid = new Guid(this.ManagementPackEdit_VersionIndependentGuid_TextBox.Text);
                mp.DownloadUri = this.ManagementPackEdit_DownloadUrl_TextBox.Text;
                mp.DisplayName = this.ManagementPackEdit_DisplayName_TextBox.Text;
                info.Description = this.ManagementPackEdit_Description_TextArea.Value;
                mp.ReleaseDate = DateTime.Now;//TODO: Fix this (this.ManagementPackEditReleaseDate.Text);
                mp.EulaInd = this.ManagementPackEdit_Eula_CheckBox.Checked;
                info.Eula = this.ManagementPackEdit_Eula_TextArea.Value;
                info.Knowledge = this.ManagementPackEdit_Knowledge_TextArea.Value;
                mp.SecurityInd = this.ManagementPackEdit_Security_CheckBox.Checked;
                mp.PublishedInd = this.ManagementPackEdit_Published_CheckBox.Checked;
                mp.VendorId = System.Convert.ToInt32(this.ManagementPackEdit_VendorId_TextBox.Text);

                ManagementPackControl.getInstance().UpdateManagementPack(mp, info);

            }
            catch (Exception ex)
            {
                this.ManagementPackEdit_Status.ForeColor = System.Drawing.Color.Red;
                this.ManagementPackEdit_Status.Text = ex.Message;
            }
        }

        protected void ManagementPackLocalize_Existing_Grid_OnItemCommand(object source, Telerik.WebControls.GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "RowClick" && e.Item is Telerik.WebControls.GridDataItem)
                {

                    e.Item.Selected = true;

                    int mpId = System.Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ManagementPackId"].ToString());

                    CatalogManagementPack mp = ManagementPackControl.getInstance().getManagementPack(mpId, "ENU");

                    this.ManagementPackLocalize_ID_TextBox.Text = mp.ManagementPackId.ToString();

                    this.ManagementPackLocalize_SystemName_TextBox.Text = mp.SystemName;
                    this.ManagementPackLocalize_PublicKey_TextBox.Text = mp.PublicKey;
                    this.ManagementPackLocalize_Version_TextBox.Text = mp.Version.ToString();

                    ManagementPackControl.getInstance().UpdateLocDropDownList(this.ManagementPackLocalize_Languages_ComboBox, mpId);
                    this.ManagementPackLocalize_Languages_ComboBox.Enabled = true;

                    this.ManagementPackLocalize_Submit_Button.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                this.ManagementPackLocalize_Status.ForeColor = System.Drawing.Color.Red;
                this.ManagementPackLocalize_Status.Text = ex.Message;
            }


        }


        protected void ManagementPackLocalize_Submit_Button_Click(object sender, EventArgs e)
        {
            this.ManagementPackLocalize_Languages_ComboBox.SelectedValue = this.ManagementPackLocalize_Languages_ComboBox.SelectedValue;


            int mpId = System.Convert.ToInt32(this.ManagementPackLocalize_ID_TextBox.Text);
            string threeLetterLanguageCode = this.ManagementPackLocalize_Languages_ComboBox.SelectedValue;

            string locString = ManagementPackControl.getInstance().GetLocalizeXml(mpId, threeLetterLanguageCode);

            string filename = "ManagementPack_" + mpId + "_" + threeLetterLanguageCode + ".xml";

            this.DownloadLocContent(filename, locString);
        }


        protected void ProductCreate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.ProductCreate_Name_TextBox.Text) || String.IsNullOrEmpty(this.ProductCreate_Version_TextBox.Text))
                {
                    throw new Exception("Null or empty product name or version passed");
                }

                ProductControl.getInstance().AddProduct(this.ProductCreate_Name_TextBox.Text, new Version(this.ProductCreate_Version_TextBox.Text));
                ProductControl.getInstance().UpdateGrid(this.ProductCreate_Existing_Grid);

                this.ProductCreate_Status.ForeColor = System.Drawing.Color.Green;
                this.ProductCreate_Status.Text = "Successfully created product with name : " + this.ProductCreate_Name_TextBox.Text + " and version : " + this.ProductCreate_Version_TextBox.Text;

                this.ProductCreate_Name_TextBox.Text = "";
                this.ProductCreate_Version_TextBox.Text = "";


            }
            catch (Exception ex)
            {
                this.ProductCreate_Status.ForeColor = System.Drawing.Color.Red;
                if(ex.Message.Contains("Version string portion was too short or too long.")==true)
                {
                    this.ProductCreate_Status.Text = String.Format("Incorrect format for product version, correct format is A.B.C.D where A,B,C and D are numbers between 0 and 9999 (Eg: 6.0.6278.0)");
                }
                else
                {
                    this.ProductCreate_Status.Text = ex.Message;
                }
            }
        }

        protected void VendorCreate_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.VendorCreate_Name_TextBox.Text) || String.IsNullOrEmpty(this.VendorCreate_Link_TextBox.Text))
                {
                    throw new Exception("Null or empty vendor name or link passed");
                }

                VendorControl.getInstance().AddVendor(this.VendorCreate_Name_TextBox.Text,this.VendorCreate_Link_TextBox.Text);
                VendorControl.getInstance().UpdateGrid(this.VendorCreate_Existing_Grid);

                this.VendorCreate_Status.ForeColor = System.Drawing.Color.Green;
                this.VendorCreate_Status.Text = "Successfully created vendor with name : " + this.VendorCreate_Name_TextBox.Text + " and link : " + this.VendorCreate_Link_TextBox.Text;

                this.VendorCreate_Name_TextBox.Text = "";
                this.VendorCreate_Link_TextBox.Text = "";


            }
            catch (Exception ex)
            {
                this.VendorCreate_Status.ForeColor = System.Drawing.Color.Red;
                this.VendorCreate_Status.Text = ex.Message;
            }
        }

        protected void VendorLocalize_Existing_ComboBox_OnSelectedIndexChanged(object o, Telerik.WebControls.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            if (this.VendorLocalize_Existing_ComboBox.SelectedValue == "0")
            {
                this.VendorLocalize_Languages_ComboBox.Enabled = false;
                this.VendorLocalize_Submit_Button.Enabled = false;

                this.VendorLocalize_Id_TextBox.Text = "";
                this.VendorLocalize_Name_TextBox.Text = "";
                this.VendorLocalize_Link.Text = "";

            }
            else
            {
                int vendorId = System.Convert.ToInt32(this.VendorLocalize_Existing_ComboBox.SelectedValue);

                CatalogVendor vendor = VendorControl.getInstance().GetVendor(vendorId, "ENU");

                this.VendorLocalize_Id_TextBox.Text = vendor.VendorId.ToString();
                this.VendorLocalize_Name_TextBox.Text = vendor.VendorName;
                this.VendorLocalize_Link.Text = vendor.VendorLink;

                VendorControl.getInstance().UpdateLocDropDownList(this.VendorLocalize_Languages_ComboBox, vendorId);

                this.VendorLocalize_Languages_ComboBox.Enabled = true;
                this.VendorLocalize_Submit_Button.Enabled = true;

            }
            this.VendorLocalize_Existing_ComboBox.SelectedValue = this.VendorLocalize_Existing_ComboBox.SelectedValue;

        }

        protected void VendorLocalize_Submit_Button_Click(object sender, EventArgs e)
        {
            this.VendorLocalize_Existing_ComboBox.SelectedValue = this.VendorLocalize_Existing_ComboBox.SelectedValue;
            this.VendorLocalize_Languages_ComboBox.SelectedValue = this.VendorLocalize_Languages_ComboBox.SelectedValue;


            int vendorId = System.Convert.ToInt32(this.VendorLocalize_Existing_ComboBox.SelectedValue);
            string threeLetterLanguageCode = this.VendorLocalize_Languages_ComboBox.SelectedValue;

            string locString = VendorControl.getInstance().GetLocalizeXml(vendorId, threeLetterLanguageCode);

            string filename = "Vendor_" + vendorId + "_" + threeLetterLanguageCode + ".xml";

            this.DownloadLocContent(filename,locString);
        }


        protected void LocalizationUpload_Submit_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.LocalizationUpload_Status.Text = String.Empty;
                for (int i = 0; i < this.LocalizationUpload_FileUpload.UploadedFiles.Count; i++)
                {
                    if (this.LocalizationUpload_FileUpload.UploadedFiles[i].ContentType == "text/xml")
                    {

                        XmlDocument doc = new XmlDocument();
                        doc.Load(this.LocalizationUpload_FileUpload.UploadedFiles[i].InputStream);
                        
                        
                        //Update categories                        
                        XmlNodeList categoryList = doc.SelectNodes("//Category");

                        foreach (XmlNode categoryNode in categoryList)
                        {
                            int categoryId = System.Convert.ToInt32(categoryNode.SelectSingleNode("Id").InnerText);
                            string threeLetterLanguageCode = categoryNode.Attributes["Language"].Value;

                            CatalogCategory category = new CatalogCategory();
                            CatalogCategoryExtendedInfo info = new CatalogCategoryExtendedInfo();

                            category.CategoryId = categoryId;
                            info.CategoryId = categoryId;

                            category.DisplayName = categoryNode.SelectSingleNode("Name").InnerText;
                            category.GuideUriText = categoryNode.SelectSingleNode("GuideUriText").InnerText;
                            category.GuideUriLink = categoryNode.SelectSingleNode("GuideUriLink").InnerText;

                            info.Description = categoryNode.SelectSingleNode("Description").InnerText;
                           

                            try
                            {
                                CategoryControl.getInstance().UpdateLocCategory(category, info, threeLetterLanguageCode);
                                this.LocalizationUpload_Status.ForeColor = System.Drawing.Color.Green;
                                this.LocalizationUpload_Status.Text += "<pre>" + "Localized Category "+category.CategoryId+" in language code : "+threeLetterLanguageCode+"</pre>";

                            }
                            catch (Exception ex)
                            {
                                this.LocalizationUpload_Status.ForeColor = System.Drawing.Color.Red;
                                this.LocalizationUpload_Status.Text += "\n"+ex.Message + ex.InnerException;

                            }
                        }

                        //Update management packs                        
                        XmlNodeList mpList = doc.SelectNodes("//ManagementPack");

                        foreach (XmlNode mpNode in mpList)
                        {
                            int mpId = System.Convert.ToInt32(mpNode.SelectSingleNode("Id").InnerText);
                            string threeLetterLanguageCode = mpNode.Attributes["Language"].Value;

                            CatalogManagementPack mp = new CatalogManagementPack();
                            CatalogManagementPackExtendedInfo info = new CatalogManagementPackExtendedInfo();
                            

                            mp.ManagementPackId = mpId;
                            info.ManagmentPackId = mpId;

                            mp.DisplayName = mpNode.SelectSingleNode("Name").InnerText;

                            info.Description = mpNode.SelectSingleNode("Description").InnerText;
                            info.Knowledge = mpNode.SelectSingleNode("Knowledge").InnerText;
                            info.Eula = mpNode.SelectSingleNode("Eula").InnerText;


                            try
                            {
                                ManagementPackControl.getInstance().UpdateLocManagementPack(mp, info, threeLetterLanguageCode);
                                this.LocalizationUpload_Status.ForeColor = System.Drawing.Color.Green;
                                this.LocalizationUpload_Status.Text += "\n" + "Localized MP " + mp.ManagementPackId + " in language code : " + threeLetterLanguageCode;

                            }
                            catch (Exception ex)
                            {
                                this.LocalizationUpload_Status.ForeColor = System.Drawing.Color.Red;
                                this.LocalizationUpload_Status.Text += "\n" + ex.Message + ex.InnerException;

                            }
                        }


                        // Update vendor
                        XmlNodeList vendorList = doc.SelectNodes("//Vendor");

                        foreach (XmlNode vendorNode in vendorList)
                        {
                            int vendorId = System.Convert.ToInt32(vendorNode.SelectSingleNode("Id").InnerText);
                            string threeLetterLanguageCode = vendorNode.Attributes["Language"].Value;

                            CatalogVendor vendor = new CatalogVendor();

                            vendor.VendorId = vendorId;

                            vendor.VendorName = vendorNode.SelectSingleNode("Name").InnerText;
                            vendor.VendorLink = vendorNode.SelectSingleNode("Link").InnerText;


                            try
                            {
                                VendorControl.getInstance().UpdateLocVendor(vendor, threeLetterLanguageCode);
                                this.LocalizationUpload_Status.ForeColor = System.Drawing.Color.Green;
                                this.LocalizationUpload_Status.Text += "\n" + "Localized vendor " + vendor.VendorId + " in language code : " + threeLetterLanguageCode;

                            }
                            catch (Exception ex)
                            {
                                this.LocalizationUpload_Status.ForeColor = System.Drawing.Color.Red;
                                this.LocalizationUpload_Status.Text += "\n" + ex.Message + ex.InnerException;

                            }
                        }
                    }
                }
                         
            }
            catch (Exception ex)
            {
                this.LocalizationUpload_Status.ForeColor = System.Drawing.Color.Red;
                this.LocalizationUpload_Status.Text = ex.Message;
            }
        }


        private void DownloadLocContent(string filename, string content)
        {
            string type = "text/xml";
                Response.AppendHeader("content-disposition",
                    "attachment; filename=" + filename);
                Response.ContentType = type;

            Response.Write(content);
            Response.End();
        }

    }
}
