<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Microsoft.ManagementPackCatalog.Admin.UI.dll" Inherits="Microsoft.ManagementPackCatalog.Admin.UI._Default" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadInput.NET2" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadComboBox.NET2" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadGrid.NET2" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadTabStrip.NET2" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadTreeView.NET2" %>
<%@ Register TagPrefix="rad" Namespace="Telerik.WebControls" Assembly="RadUpload.NET2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Management Pack Catalog Admin UI</title>
</head>
<body>
    <form id="MainForm" runat="server">
        <rad:RadTabStrip ID="MainTabStrip" runat="server" MultiPageID="MainMultiPage">
            <Tabs>
                <rad:Tab Text="Category" PageViewID="EmptyPage">
                    <Tabs>
                        <rad:Tab Text="Create" PageViewID="CategoryCreate_Page"></rad:Tab>
                        <rad:Tab Text="Edit" PageViewID="CategoryEdit_Page"></rad:Tab>
                        <rad:Tab Text="Associate" PageViewID="CategoryAssociate_Page"></rad:Tab>
                        <rad:Tab Text="Assign MPs" PageViewID="CategoryAssignMps_Page"></rad:Tab>
                        <rad:Tab Text="Localize" PageViewID="CategoryLocalize_Page"></rad:Tab>
                    </Tabs>
                </rad:Tab>
                <rad:Tab Text="ManagementPack" PageViewID="EmptyPage">
                    <Tabs>
                        <rad:Tab Text="Add" PageViewID="ManagementPackAdd_Page"></rad:Tab>
                        <rad:Tab Text="Edit" PageViewID="ManagementPackEdit_Page"></rad:Tab>
                        <rad:Tab Text="Associate" PageViewID="ManagementPackAssociate_Page"></rad:Tab>
                        <rad:Tab Text="Localize" PageViewID="ManagementPackLocalize_Page"></rad:Tab>
                    </Tabs>
                </rad:Tab>
                <rad:Tab Text="Product" PageViewID="EmptyPage">
                    <Tabs>
                        <rad:Tab Text="Create" PageViewID="ProductCreate_Page"></rad:Tab>
                    </Tabs>
                </rad:Tab>
                <rad:Tab Text="Vendor" PageViewID="EmptyPage">
                    <Tabs>
                        <rad:Tab Text="Create" PageViewID="VendorCreate_Page"></rad:Tab>
                        <rad:Tab Text="Localize" PageViewID="VendorLocalize_Page"></rad:Tab>
                    </Tabs>
                </rad:Tab>
                <rad:Tab Text="Localization" PageViewID="EmptyPage">
                    <Tabs>
                        <rad:Tab Text="Upload" PageViewID="LocalizationUpload_Page"></rad:Tab>
                    </Tabs>
                </rad:Tab>
            </Tabs>
        </rad:RadTabStrip>

        <rad:RadMultiPage ID="MainMultiPage" runat="server">
            
            <rad:PageView ID="EmptyPage" runat="server"></rad:PageView>
            
            <rad:PageView ID="CategoryCreate_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="CategoryCreate_Refresh" runat="server" />
                <table>
                    <tr>
                        <td>Technology Name : </td>
                        <td><rad:RadTextBox ID="CategoryCreate_TechnologyName_TextBox" runat="server"></rad:RadTextBox></td>
                        <td><rad:RadComboBox ID="CategoryCreate_TechnologyName_DropDown" runat="server" OnSelectedIndexChanged="CategoryCreate_TechnologyName_DropDown_OnSelectedIndexChanged" AutoPostBack="true"></rad:RadComboBox></td>
                    </tr>
                    <tr>
                        <td>Product Name : </td>
                        <td><rad:RadTextBox ID="CategoryCreate_ProductName_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                        <td><rad:RadComboBox ID="CategoryCreate_ProductName_DropDown" runat="server" Enabled="false" OnSelectedIndexChanged="CategoryCreate_ProductName_DropDown_OnSelectedIndexChanged" AutoPostBack="true"></rad:RadComboBox></td>
                    </tr>
                    <tr>
                        <td>Language Pack :</td>
                        <td><asp:CheckBox ID="CategoryCreate_LanguagePack_CheckBox" runat="server" Enabled="false" Checked="false"/></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td><asp:Button Text="Create" runat="server" OnClick="CategoryCreate_Button_Click"/></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
                <asp:Label ID="CategoryCreate_Status" runat="server"></asp:Label>
            </rad:PageView>
            
            <rad:PageView ID="CategoryEdit_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="CategoryEdit_Refresh" runat="server" />
                <table>
                    <tr>
                        <td valign="top">
                            <rad:RadTreeView ID="CategoryEdit_Existing_TreeView" runat="server" AutoPostBack="true" OnNodeClick="CategoryEdit_Existing_TreeView_NodeClick"></rad:RadTreeView>
                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>Category id : </td>
                                    <td><rad:RadTextBox ID="CategoryEdit_CategoryId_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Parent category id : </td>
                                    <td><rad:RadTextBox ID="CategoryEdit_ParentCategoryId_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Display name : </td>
                                    <td><rad:RadTextBox ID="CategoryEdit_DisplayName_TextBox" runat="server"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Description : </td>
                                    <td><textarea ID="CategoryEdit_Description_TextArea" runat="server" rows="10" cols="50"></textarea></td>
                                </tr>
                                <tr>
                                    <td>Guide uri text : </td>
                                    <td><rad:RadTextBox ID="CategoryEdit_GuideUriText_TextBox" runat="server"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Guide uri link : </td>
                                    <td><rad:RadTextBox ID="CategoryEdit_GuideUriLink_TextBox" runat="server"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Published? : </td>
                                    <td><asp:CheckBox ID="CategoryEdit_Published_CheckBox" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="CategoryEdit_Submit_Button" runat="server" Text="Save" OnClick="CategoryEdit_Submit_Button_Click"/></td>
                                    <td></td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="CategoryEdit_Status" runat="server"></asp:Label>
            </rad:PageView>

            <rad:PageView ID="CategoryAssociate_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="CategoryAssociate_Refresh" runat="server" />
                <table>
                    <tr>
                        <td valign="top">
                            <rad:RadTreeView ID="CategoryAssociate_Existing_TreeView" runat="server" AutoPostBack="true" OnNodeClick="CategoryAssociate_Existing_TreeView_NodeClick"></rad:RadTreeView>
                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>Category id : </td>
                                    <td><rad:RadTextBox ID="CategoryAssociate_CategoryId_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Parent category id : </td>
                                    <td><rad:RadTextBox ID="CategoryAssociate_ParentId_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Display name : </td>
                                    <td><rad:RadTextBox ID="CategoryAssociate_DisplayName_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Associated Products : </td>
                                    <td>
                                        <rad:RadComboBox ID="CategoryAssociate_Associated_ComboBox" runat="server" Enabled="false"></rad:RadComboBox>                                    
                                        <asp:Button ID="CategoryAssociate_UnAssociate_Button" runat="server" Text="Unassociate" Enabled="false" OnClick="CategoryAssociate_UnAssociate_Button_Click" />
                                    </td>                               
                                </tr>
                                <tr>
                                    <td>Unassociated Products : </td>
                                    <td>
                                        <rad:RadComboBox ID="CategoryAssociate_UnAssociated_ComboBox" runat="server" Enabled="false"></rad:RadComboBox>                                    
                                        <asp:Button ID="CategoryAssociate_Associate_Button" runat="server" Text="Associate" Enabled="false" OnClick="CategoryAssociate_Associate_Button_Click" />
                                    </td>                               
                                </tr>
                                                               
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="CategoryAssociate_Status" runat="server"></asp:Label>
            </rad:PageView>

            <rad:PageView ID="CategoryAssignMps_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="CategoryAssignMps_Refresh" runat="server" />
                <table>
                    <tr>
                        <td valign="top">
                            <rad:RadTreeView ID="CategoryAssignMps_Existing_Category_TreeView" runat="server" AutoPostBack="true" OnNodeClick="CategoryAssignMps_Existing_Category_TreeView_NodeClick"></rad:RadTreeView>
                        </td>

                        <td valign="top">
                            <table>
                                <tr>
                                    <td>Category id : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_Category_Id_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Parent category id : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_Category_ParentId_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Display name : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_Category_DisplayName_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <rad:RadGrid ID="CategoryAssignMps_Existing_Assigned_ManagementPacks_Grid" runat="server" AllowPaging="false" ClientSettings-EnablePostBackOnRowClick="true" OnItemCommand="CategoryAssignMps_Existing_Assigned_ManagementPacks_Grid_OnItemCommand">
                                <MasterTableView CanRetrieveAllData="true" DataKeyNames="ManagementPackId"></MasterTableView>
                                <ClientSettings><Selecting AllowRowSelect="true" /></ClientSettings>
                            </rad:RadGrid>

                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>Id : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_Assigned_ManagementPacks_Id_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>System name : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_Assigned_ManagementPacks_SystemName_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Public key : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_Assigned_ManagementPacks_PublicKey_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Version : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_Assigned_ManagementPacks_Version_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="CategoryAssignMps_RemoveMp_Button" Text="Remove" Enabled="false" runat="server" OnClick="CategoryAssignMps_RemoveMp_Button_OnClick" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <rad:RadGrid ID="CategoryAssignMps_Existing_UnAssigned_ManagementPacks_Grid" runat="server" AllowPaging="false" ClientSettings-EnablePostBackOnRowClick="true" OnItemCommand="CategoryAssignMps_Existing_UnAssigned_ManagementPacks_Grid_OnItemCommand">
                                <MasterTableView CanRetrieveAllData="true" DataKeyNames="ManagementPackId"></MasterTableView>
                                <ClientSettings><Selecting AllowRowSelect="true" /></ClientSettings>
                            </rad:RadGrid>

                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>Id : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_UnAssigned_ManagementPacks_Id_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>System name : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_UnAssigned_ManagementPacks_SystemName_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Public key : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_UnAssigned_ManagementPacks_PublicKey_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Version : </td>
                                    <td><rad:RadTextBox ID="CategoryAssignMps_UnAssigned_ManagementPacks_Version_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="CategoryAssignMps_AddMp_Button" Text="Add" Enabled="false" runat="server" OnClick="CategoryAssignMps_AddMp_Button_OnClick"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    
                </table>
                <asp:Label ID="CategoryAssignMps_Status" runat="server"></asp:Label>
            </rad:PageView>

            <rad:PageView ID="CategoryLocalize_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="CategoryLocalize_Refresh" runat="server" />
                <table>
                    <tr>
                        <td valign="top">
                            <rad:RadTreeView ID="CategoryLocalize_Existing_TreeView" runat="server" AutoPostBack="true" OnNodeClick="CategoryLocalize_Existing_TreeView_NodeClick"></rad:RadTreeView>
                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>Category id : </td>
                                    <td><rad:RadTextBox ID="CategoryLocalize_Id_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Parent category id : </td>
                                    <td><rad:RadTextBox ID="CategoryLocalize_ParentId_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Display name : </td>
                                    <td><rad:RadTextBox ID="CategoryLocalize_Name_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Language : </td>
                                    <td><rad:RadComboBox ID="CategoryLocalize_Languages_ComboBox" runat="server" Enabled="false"></rad:RadComboBox></td>
                                </tr>

                                <tr>
                                    <td><asp:Button ID="CategoryLocalize_Submit_Button" runat="server" Text="Export" Enabled="false" OnClick="CategoryLocalize_Submit_Button_Click"/></td>
                                    <td></td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="CategoryLocalize_Status" runat="server"></asp:Label>
            </rad:PageView>
            
            <rad:PageView ID="ManagementPackAdd_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="ManagementPackAdd_Refresh" runat="server" />
                <table>
                    <tr>
                        <td>Enter MP URL : </td>
                        <td><rad:RadTextBox ID="ManagementPackAdd_Url_TextBox" runat="server"></rad:RadTextBox></td>
                        <td><asp:Button ID="ManagementPackAdd_Upload_Button" runat="server" Text="Upload" OnClick="ManagementPackAdd_Upload_Button_Click" /></td>
                        <td><asp:Button ID="ManagementPackAdd_Clear_Button" runat="server" Text="Clear"  OnClick="ManagementPackAdd_Clear_Button_Click"/></td>
                    </tr>
                    <tr>
                        <td>System Name : </td>
                        <td><rad:RadTextBox ID="ManagementPackAdd_SystemName_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td>Version : </td>
                        <td><rad:RadTextBox ID="ManagementPackAdd_Version_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td>Public Key : </td>
                        <td><rad:RadTextBox ID="ManagementPackAdd_PublicKey_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td>Vendor : </td>
                        <td><rad:RadComboBox ID="ManagementPackAdd_Vendor_DropDown" runat="server" Enabled="true"></rad:RadComboBox></td>
                    </tr>
                    
                    <tr>
                        <td><asp:Button ID="ManagementPackAdd_Submit_Button" Text="Add" runat="server" Enabled="false" OnClick="ManagementPackAdd_Submit_Button_Click"/></td>
                    </tr>
                </table>
                <rad:RadTextBox ID="ManagementPackAdd_TempFile_TextBox_Hidden" runat="server" Visible="false" Enabled="false"></rad:RadTextBox>
                <asp:Label ID="ManagementPackAdd_Status" runat="server"></asp:Label>
            </rad:PageView>

            <rad:PageView ID="ManagementPackEdit_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="ManagementPackEdit_Refresh" runat="server" />
                <table>
                    <tr>
                        <td valign="top">
                            <rad:RadGrid ID="ManagementPackEdit_Existing_Grid" runat="server" AllowPaging="true" PageSize="50" ClientSettings-EnablePostBackOnRowClick="true" OnItemCommand="ManagementPackEdit_Existing_Grid_OnItemCommand">
                                <MasterTableView CanRetrieveAllData="true" DataKeyNames="ManagementPackId"></MasterTableView>
                                <ClientSettings><Selecting AllowRowSelect="true" /></ClientSettings>
                            </rad:RadGrid>
                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>Id : </td>
                                    <td><rad:RadTextBox ID="ManagementPackEdit_Id_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>System name : </td>
                                    <td><rad:RadTextBox ID="ManagementPackEdit_SystemName_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Public key : </td>
                                    <td><rad:RadTextBox ID="ManagementPackEdit_PublicKey_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Version : </td>
                                    <td><rad:RadTextBox ID="ManagementPackEdit_Version_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                    <rad:RadTextBox ID="ManagementPackEdit_VersionIndependentGuid_TextBox" runat="server" Enabled="false" Visible="false"></rad:RadTextBox>
                                    <rad:RadTextBox ID="ManagementPackEdit_VendorId_TextBox" runat="server" Enabled="false" Visible="false"></rad:RadTextBox>
                                </tr>
                                <tr>
                                    <td>Download url : </td>
                                    <td><rad:RadTextBox ID="ManagementPackEdit_DownloadUrl_TextBox" runat="server" Enabled="true"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Display name : </td>
                                    <td><rad:RadTextBox ID="ManagementPackEdit_DisplayName_TextBox" runat="server"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Description : </td>
                                    <td><textarea ID="ManagementPackEdit_Description_TextArea" runat="server" rows="10" cols="50"></textarea></td>
                                </tr>
                                <tr>
                                    <td>Release date : </td>
                                    <td><rad:RadTextBox ID="ManagementPackEdit_ReleaseDate_TextBox" runat="server"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Eula indicator : </td>
                                    <td><asp:CheckBox ID="ManagementPackEdit_Eula_CheckBox" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>Eula : </td>
                                    <td><textarea ID="ManagementPackEdit_Eula_TextArea" runat="server" rows="10" cols="50"></textarea></td>
                                </tr>
                                <tr>
                                    <td>Knowledge : </td>
                                    <td><textarea ID="ManagementPackEdit_Knowledge_TextArea" runat="server" rows="10" cols="50" disabled="disabled"></textarea></td>
                                </tr>
                                <tr>
                                    <td>Security indicator : </td>
                                    <td><asp:CheckBox ID="ManagementPackEdit_Security_CheckBox" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td>Published? : </td>
                                    <td><asp:CheckBox ID="ManagementPackEdit_Published_CheckBox" runat="server" /></td>
                                </tr>                                                                                              
                                
                                <tr>
                                    <td><asp:Button ID="ManagementPackEdit_Submit_Button" runat="server" Text="Save" Enabled="false" OnClick="ManagementPackEdit_Submit_Button_Click"/></td>
                                    <td></td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="ManagementPackEdit_Status" runat="server"></asp:Label>
            </rad:PageView>

            <rad:PageView ID="ManagementPackAssociate_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="ManagementPackAssociate_Refresh" runat="server" />
                <table>
                    <tr>
                        <td valign="top">
                            <rad:RadGrid ID="ManagementPackAssociate_Existing_Grid" runat="server" AllowPaging="true" PageSize="50" ClientSettings-EnablePostBackOnRowClick="true" OnItemCommand="ManagementPackAssociate_Existing_Grid_OnItemCommand">
                                <MasterTableView CanRetrieveAllData="true" DataKeyNames="ManagementPackId"></MasterTableView>
                                <ClientSettings><Selecting AllowRowSelect="true" /></ClientSettings>
                            </rad:RadGrid>

                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>Id : </td>
                                    <td><rad:RadTextBox ID="ManagementPackAssociate_Id_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>System name : </td>
                                    <td><rad:RadTextBox ID="ManagementPackAssociate_SystemName_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Public key : </td>
                                    <td><rad:RadTextBox ID="ManagementPackAssociate_PublicKey_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Version : </td>
                                    <td><rad:RadTextBox ID="ManagementPackAssociate_Version_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Associated Products : </td>
                                    <td>
                                        <rad:RadComboBox ID="ManagementPackAssociate_Associated_ComboBox" runat="server" Enabled="false"></rad:RadComboBox>                                    
                                        <asp:Button ID="ManagementPackAssociate_UnAssociate_Button" runat="server" Text="Unassociate" Enabled="false" OnClick="ManagementPackAssociate_UnAssociate_Button_Click" />
                                    </td>                               
                                </tr>
                                <tr>
                                    <td>Unassociated Products : </td>
                                    <td>
                                        <rad:RadComboBox ID="ManagementPackAssociate_UnAssociated_ComboBox" runat="server" Enabled="false"></rad:RadComboBox>                                    
                                        <asp:Button ID="ManagementPackAssociate_Associate_Button" runat="server" Text="Associate" Enabled="false" OnClick="ManagementPackAssociate_Associate_Button_Click" />
                                    </td>                               
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="ManagementPackAssociate_Status" runat="server"></asp:Label>
            </rad:PageView>

            <rad:PageView ID="ManagementPackLocalize_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="ManagementPackLocalize_Refresh" runat="server" />
                <table>
                    <tr>
                        <td valign="top">
                            <rad:RadGrid ID="ManagementPackLocalize_Existing_Grid" runat="server" AllowPaging="true" PageSize="50" ClientSettings-EnablePostBackOnRowClick="true" OnItemCommand="ManagementPackLocalize_Existing_Grid_OnItemCommand">
                                <MasterTableView CanRetrieveAllData="true" DataKeyNames="ManagementPackId"></MasterTableView>
                                <ClientSettings><Selecting AllowRowSelect="true" /></ClientSettings>
                            </rad:RadGrid>
                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>MP id : </td>
                                    <td><rad:RadTextBox ID="ManagementPackLocalize_ID_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>SystemName : </td>
                                    <td><rad:RadTextBox ID="ManagementPackLocalize_SystemName_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>Version : </td>
                                    <td><rad:RadTextBox ID="ManagementPackLocalize_Version_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>
                                <tr>
                                    <td>PublicKey : </td>
                                    <td><rad:RadTextBox ID="ManagementPackLocalize_PublicKey_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                                </tr>                                
                                <tr>
                                    <td>Language : </td>
                                    <td><rad:RadComboBox ID="ManagementPackLocalize_Languages_ComboBox" runat="server" Enabled="false"></rad:RadComboBox></td>
                                </tr>
                                <tr>
                                    <td><asp:Button ID="ManagementPackLocalize_Submit_Button" runat="server" Text="Export" Enabled="false" OnClick="ManagementPackLocalize_Submit_Button_Click"/></td>
                                    <td></td>
                                </tr>
                                
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="ManagementPackLocalize_Status" runat="server"></asp:Label>
            </rad:PageView>
            
            <rad:PageView ID="ProductCreate_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="ProductCreate_Refresh" runat="server" />
                <table>
                    <tr>
                        <td>Product Name : </td>
                        <td><rad:RadTextBox ID="ProductCreate_Name_TextBox" runat="server"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td>Product Build Version : </td>
                        <td><rad:RadTextBox ID="ProductCreate_Version_TextBox" runat="server"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="ProductCreate_Button" runat="server" Text="Create" OnClick="ProductCreate_Button_Click"/></td>
                    </tr>
                </table>
                <asp:Label ID="ProductCreate_Status" runat="server"></asp:Label>
                <rad:RadGrid ID="ProductCreate_Existing_Grid" runat="server"></rad:RadGrid>
            </rad:PageView>
            
            <rad:PageView ID="VendorCreate_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="VendorCreate_Refresh" runat="server" />
                <table>
                    <tr>
                        <td>Vendor Name : </td>
                        <td><rad:RadTextBox ID="VendorCreate_Name_TextBox" runat="server"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td>Vendor Link : </td>
                        <td><rad:RadTextBox ID="VendorCreate_Link_TextBox" runat="server"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="VendorCreate_Button" runat="server" Text="Create" OnClick="VendorCreate_Button_Click"/></td>
                    </tr>
                </table>
                <asp:Label ID="VendorCreate_Status" runat="server"></asp:Label>
                <rad:RadGrid ID="VendorCreate_Existing_Grid" runat="server"></rad:RadGrid>
            </rad:PageView>

            <rad:PageView ID="VendorLocalize_Page" runat="server">
                <asp:Button Text="Refresh" OnClick="VendorLocalize_Refresh" runat="server" />
                <table>
                    <tr>
                        <td>Pick vendor : </td>
                        <td><rad:RadComboBox ID="VendorLocalize_Existing_ComboBox" runat="server" AutoPostBack="true" Value="0" OnSelectedIndexChanged="VendorLocalize_Existing_ComboBox_OnSelectedIndexChanged"></rad:RadComboBox></td>
                    </tr>

                    <tr>
                        <td>Id : </td>
                        <td><rad:RadTextBox ID="VendorLocalize_Id_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td>Name : </td>
                        <td><rad:RadTextBox ID="VendorLocalize_Name_TextBox" runat="server" Enabled="false"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td>Link : </td>
                        <td><rad:RadTextBox ID="VendorLocalize_Link" runat="server" Enabled="false"></rad:RadTextBox></td>
                    </tr>
                    <tr>
                        <td>Language : </td>
                        <td><rad:RadComboBox ID="VendorLocalize_Languages_ComboBox" runat="server" Enabled="false"></rad:RadComboBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="VendorLocalize_Submit_Button" Text="Export" runat="server" Enabled="false" OnClick="VendorLocalize_Submit_Button_Click"/></td>
                        <td></td>
                    </tr>                                
                </table>
                <asp:Label ID="VendorLocalize_Status" runat="server"></asp:Label>
            </rad:PageView>

            <rad:PageView ID="LocalizationUpload_Page" runat="server">
                <rad:RadUpload ID="LocalizationUpload_FileUpload" runat="server" MaxFileInputsCount="20" OverwriteExistingFiles="true" />                
                <asp:Button ID="LocalizationUpload_Submit_Button" runat="server" Text="Upload" onclick="LocalizationUpload_Submit_Button_Click"/>
                <asp:Label ID="LocalizationUpload_Status" runat="server"></asp:Label>
            </rad:PageView>
            
         
        </rad:RadMultiPage>
    </form>
</body>
</html>
