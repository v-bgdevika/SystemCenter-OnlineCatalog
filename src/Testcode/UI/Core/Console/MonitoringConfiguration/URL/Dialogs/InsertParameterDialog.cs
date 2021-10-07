// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="InsertParameterDialog.cs">
// 	Copyright (c) Microsoft Corporation 2009
// </copyright>
// <project>
// 	TODO:  Enter project title here.
// </project>
// <summary>
// 	TODO:  Brief summary of the project and its objectives.
// </summary>
// <history>
// 	[v-eryon] 7/28/2009 Created
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.URL.Dialogs
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    
    #region Interface Definition - IInsertParameterDialogControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IInsertParameterDialogControls, for InsertParameterDialog.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    /// 	[v-eryon] 7/28/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IInsertParameterDialogControls
    {
        /// <summary>
        /// Read-only property to access ParametersList
        /// </summary>
        ListBox ParametersList
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access CancelButton
        /// </summary>
        Button CancelButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access OKButton
        /// </summary>
        Button OKButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ParametersStaticControl
        /// </summary>
        StaticControl ParametersStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access InsertButton
        /// </summary>
        Button InsertButton
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access UrlStringBox
        /// </summary>
        TextBox UrlStringBox
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StringStaticControl
        /// </summary>
        StaticControl StringStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access ClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam
        /// </summary>
        StaticControl ClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access RequestURLStaticControl
        /// </summary>
        StaticControl RequestURLStaticControl
        {
            get;
        }
        
        /// <summary>
        /// Read-only property to access StringNameStaticControl
        /// </summary>
        StaticControl StringNameStaticControl
        {
            get;
        }
    }
    #endregion
    
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// TODO: Add dialog functionality description here.
    /// </summary>
    /// <history>
    /// 	[v-eryon] 7/28/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class InsertParameterDialog : Dialog, IInsertParameterDialogControls
    {
        #region Private Constants

        /// <summary>
        /// Timeout value used by initialization methods
        /// </summary>
        private const int Timeout = 3000;
        #endregion
        
        #region Private Member Variables

        /// <summary>
        /// Cache to hold a reference to ParametersList of type ListBox
        /// </summary>
        private ListBox cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedListBox;
        
        /// <summary>
        /// Cache to hold a reference to CancelButton of type Button
        /// </summary>
        private Button cachedCancelButton;
        
        /// <summary>
        /// Cache to hold a reference to OKButton of type Button
        /// </summary>
        private Button cachedOKButton;
        
        /// <summary>
        /// Cache to hold a reference to ParametersStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedParametersStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to InsertButton of type Button
        /// </summary>
        private Button cachedInsertButton;
        
        /// <summary>
        /// Cache to hold a reference to UrlStringBox of type TextBox
        /// </summary>
        private TextBox cachedATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtracedTextBox;
        
        /// <summary>
        /// Cache to hold a reference to StringStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStringStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to ClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam of type StaticControl
        /// </summary>
        private StaticControl cachedClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam;
        
        /// <summary>
        /// Cache to hold a reference to RequestURLStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedRequestURLStaticControl;
        
        /// <summary>
        /// Cache to hold a reference to StringNameStaticControl of type StaticControl
        /// </summary>
        private StaticControl cachedStringNameStaticControl;
        #endregion
        
        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Add a description for your constructor.
        /// </summary>
        /// <param name='app'>
        /// Owner of InsertParameterDialog of type ExtractionRuleFormDialog
        /// </param>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public InsertParameterDialog(MomConsoleApp app)
            : base(app, new Window(new QID(";[UIA]AutomationId='InsertParameterForm'"), Window.DefaultWaitTimeout))
        {
            // TODO: Add Constructor logic here. 
        }
        #endregion
        
        #region IInsertParameterDialog Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this dialog
        /// </summary>
        /// <value>An interface that groups all of the dialog's control properties together</value>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IInsertParameterDialogControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion
        
        #region Text Field Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to set/get the text in control UrlStringBoxText
        /// </summary>
        /// <value>TODO: specify the value</value>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual string UrlStringBoxText
        {
            get
            {
                return this.Controls.UrlStringBox.Text;
            }
            
            set
            {
                this.Controls.UrlStringBox.Text = value;
            }
        }
        #endregion
        
        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersList control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ListBox IInsertParameterDialogControls.ParametersList
        {
            get
            {
                if ((this.cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedListBox == null))
                {
                    this.cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedListBox = new ListBox(this, InsertParameterDialog.ControlIDs.ParametersList);
                }
                
                return this.cachedATextDelimiterThatOccursImmediatelyAfterTheTextToBeExtractedListBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the CancelButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IInsertParameterDialogControls.CancelButton
        {
            get
            {
                if ((this.cachedCancelButton == null))
                {
                    this.cachedCancelButton = new Button(this, InsertParameterDialog.ControlIDs.CancelButton);
                }
                
                return this.cachedCancelButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the OKButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IInsertParameterDialogControls.OKButton
        {
            get
            {
                if ((this.cachedOKButton == null))
                {
                    this.cachedOKButton = new Button(this, InsertParameterDialog.ControlIDs.OKButton);
                }
                
                return this.cachedOKButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ParametersStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInsertParameterDialogControls.ParametersStaticControl
        {
            get
            {
                if ((this.cachedParametersStaticControl == null))
                {
                    this.cachedParametersStaticControl = new StaticControl(this, InsertParameterDialog.ControlIDs.ParametersStaticControl);
                }
                
                return this.cachedParametersStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the InsertButton control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IInsertParameterDialogControls.InsertButton
        {
            get
            {
                if ((this.cachedInsertButton == null))
                {
                    this.cachedInsertButton = new Button(this, InsertParameterDialog.ControlIDs.InsertButton);
                }
                
                return this.cachedInsertButton;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the UrlStringBox control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IInsertParameterDialogControls.UrlStringBox
        {
            get
            {
                if ((this.cachedATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtracedTextBox == null))
                {
                    this.cachedATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtracedTextBox = new TextBox(this, InsertParameterDialog.ControlIDs.UrlStringBox);
                }
                
                return this.cachedATextDelimiterThatOccursImmediatelyBeforeTheTextToBeExtracedTextBox;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StringStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInsertParameterDialogControls.StringStaticControl
        {
            get
            {
                if ((this.cachedStringStaticControl == null))
                {
                    this.cachedStringStaticControl = new StaticControl(this, InsertParameterDialog.ControlIDs.StringStaticControl);
                }
                
                return this.cachedStringStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the ClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInsertParameterDialogControls.ClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam
        {
            get
            {
                if ((this.cachedClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam == null))
                {
                    this.cachedClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam = new StaticControl(this, InsertParameterDialog.ControlIDs.ClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam);
                }
                
                return this.cachedClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the RequestURLStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInsertParameterDialogControls.RequestURLStaticControl
        {
            get
            {
                if ((this.cachedRequestURLStaticControl == null))
                {
                    this.cachedRequestURLStaticControl = new StaticControl(this, InsertParameterDialog.ControlIDs.RequestURLStaticControl);
                }
                
                return this.cachedRequestURLStaticControl;
            }
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the StringNameStaticControl control
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        StaticControl IInsertParameterDialogControls.StringNameStaticControl
        {
            get
            {
                if ((this.cachedStringNameStaticControl == null))
                {
                    this.cachedStringNameStaticControl = new StaticControl(this, InsertParameterDialog.ControlIDs.StringNameStaticControl);
                }
                
                return this.cachedStringNameStaticControl;
            }
        }
        #endregion
        
        #region Click Methods

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Cancel
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickCancel()
        {
            this.Controls.CancelButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button OK
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickOK()
        {
            this.Controls.OKButton.Click();
        }
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Routine to click on button Insert
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual void ClickInsert()
        {
            this.Controls.InsertButton.Click();
        }
        #endregion
        
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// This function will attempt to find a showing instance of the dialog.
        /// </summary>
        /// <returns>A reference to the dialog's Window</returns>
        /// <param name="app">ExtractionRuleFormDialog owning the dialog.</param>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private static Window Init(MomConsoleApp app)
        {
            // First check if the dialog is already up.
            Window tempWindow = null;
            try
            {
                // Try to locate an existing instance of a dialog
                tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.ExactMatch, WindowClassNames.WinForms10Window8, StringMatchSyntax.ExactMatch, app.MainWindow, Timeout);
            }
            catch (Exceptions.WindowNotFoundException windowNotFound)
            {
                // Reset the window reference
                tempWindow = null;

                // Maximum number of tries to find window
                int maxTries = 5;

                // Try several more times to find the window
                for (int numberOfTries = 0; ((null == tempWindow) 
                            && (numberOfTries < maxTries)); numberOfTries = (numberOfTries + 1))
                {
                    try
                    {
                        // Try to locate an existing instance of the window
                        tempWindow = new Window(app.GetIntlStr(Strings.DialogTitle), StringMatchSyntax.WildCard);

                        // Wait for the window to become ready
                        UISynchronization.WaitForUIObjectReady(tempWindow, Timeout);
                    }
                    catch (Exceptions.WindowNotFoundException )
                    {
                        // log the unsuccessful attempt

                        // wait for a moment before trying again
                        Maui.Core.Utilities.Sleeper.Delay(Timeout);
                    }
                }
                
                // check for success
                if ((null == tempWindow))
                {
                    // log the failure

                    // rethrow the original exception
                    throw windowNotFound;
                }
            }
            
            return tempWindow;
        }
        
        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// TODO: Remove unused definitions.
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// <summary>
            /// Resource string for Insert Parameter
            /// </summary>
            // Insert Parameter
            public const string ResourceDialogTitle = ";Insert Parameter;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;M" +
                "icrosoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.InsertParameterForm;$" +
                "this.Text";
            
            /// <summary>
            /// Resource string for Cancel
            /// </summary>
            // &Cancel
            public const string Cancel = ";&Cancel;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.Diagra" +
                "mTemplateProperties;cancelButton.Text";
            
            /// <summary>
            /// Resource string for OK
            /// </summary>
            // &OK
            public const string OK = ";&OK;ManagedString;Corgent.Diagramming.Dom.dll;Corgent.Diagramming.Dom.DiagramTem" +
                "plateProperties;okButton.Text";
            
            /// <summary>
            /// Resource string for Parameters:
            /// </summary>
            // &Parameters:
            public const string Parameters = ";&Parameters:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.Pages.ParametersDialog;lblParame" +
                "ters.Text";
            
            /// <summary>
            /// Resource string for Insert
            /// </summary>
            // I&nsert
            public const string Insert = ";I&nsert;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft." +
                "EnterpriseManagement.Internal.UI.Authoring.WebApp.InsertParameterForm;buttonInse" +
                "rt.Text";
            
            /// <summary>
            /// Resource string for String:
            /// </summary>
            // &String:
            public const string String = ";&String:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft" +
                ".EnterpriseManagement.Internal.UI.Authoring.WebApp.InsertParameterForm;labelStri" +
                "ng.Text";
            
            /// <summary>
            /// Resource string for Click in the string below to choose an insertion point for the parameter, or select text you want to replace with the parameter. Then select a parameter and click Insert. You can repeat the process to insert additional parameters.
            /// </summary>
            // Click in the string below to choose an insertion point for the parameter, or select text you want to replace with the parameter. Then select a parameter and click Insert. You can repeat the process to insert additional parameters.
            public const string ClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam = @";Click in the string below to choose an insertion point for the parameter, or select text you want to replace with the parameter. Then select a parameter and click Insert. You can repeat the process to insert additional parameters.;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Microsoft.EnterpriseManagement.Internal.UI.Authoring.WebApp.InsertParameterForm;labelDescription.Text";
            
            /// <summary>
            /// Resource string for Request URL
            /// </summary>
            // Request URL
            public const string RequestURL = ";Request URL;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micros" +
                "oft.EnterpriseManagement.Internal.UI.Authoring.WebApp.WebApplicationResources;Ta" +
                "rgetStringUrl";
            
            /// <summary>
            /// Resource string for String name:
            /// </summary>
            // String name:
            public const string StringName = ";String name:;ManagedString;Microsoft.EnterpriseManagement.UI.Authoring.dll;Micro" +
                "soft.EnterpriseManagement.Internal.UI.Authoring.WebApp.InsertParameterForm;label" +
                "StringName.Text";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource the window or dialog title
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedDialogTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the DialogTitle translated resource string
            /// </summary>
            /// <history>
            /// 	[v-eryon] 7/29/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string DialogTitle
            {
                get
                {
                    if ((cachedDialogTitle == null))
                    {
                        cachedDialogTitle = CoreManager.MomConsole.GetIntlStr(ResourceDialogTitle);
                    }

                    return cachedDialogTitle;
                }
            }

            #endregion
        }
        #endregion
        
        #region Control ID's

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for all control ID's.
        /// </summary>
        /// <history>
        /// 	[v-eryon] 7/28/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {
            /// <summary>
            /// Control ID for ParametersList
            /// </summary>
            public const string ParametersList = "listBoxParameterNames";
            
            /// <summary>
            /// Control ID for CancelButton
            /// </summary>
            public const string CancelButton = "buttonCancel";
            
            /// <summary>
            /// Control ID for OKButton
            /// </summary>
            public const string OKButton = "buttonOk";
            
            /// <summary>
            /// Control ID for ParametersStaticControl
            /// </summary>
            public const string ParametersStaticControl = "labelParameters";
            
            /// <summary>
            /// Control ID for InsertButton
            /// </summary>
            public const string InsertButton = "buttonInsert";
            
            /// <summary>
            /// Control ID for UrlStringBox
            /// </summary>
            public const string UrlStringBox = "textBoxTargetString";
            
            /// <summary>
            /// Control ID for StringStaticControl
            /// </summary>
            public const string StringStaticControl = "labelString";
            
            /// <summary>
            /// Control ID for ClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam
            /// </summary>
            public const string ClickInTheStringBelowToChooseAnInsertionPointForTheParameterOrSelectTextYouWantToReplaceWithTheParam = "labelDescription";
            
            /// <summary>
            /// Control ID for RequestURLStaticControl
            /// </summary>
            public const string RequestURLStaticControl = "labelStringNameValue";
            
            /// <summary>
            /// Control ID for StringNameStaticControl
            /// </summary>
            public const string StringNameStaticControl = "labelStringName";
        }
        #endregion
    }
}
