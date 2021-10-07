// -----------------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation" file="WordDocument.cs">
//   Copyright (c) Microsoft Corporation 2009
// </copyright>
//
// <summary>
//   WordDocument support for KnowledgeEditing
//   This file is written manually because UI tools could not capture Word document controls
// </summary>
// <history>
//   [v-waltli] 5/31/2009 Created. Adding methods capturing active word document.
//                        Adding methods adding and clearing knowledge content
// </history>
// -----------------------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Console.MonitoringConfiguration.Knowledge
{
    using Maui.Core;
    using Maui.Core.WinControls;
    using Maui.Core.Utilities;
    using System.ComponentModel;
    using Maui.Core.HtmlControls;
    using Word = Microsoft.Office.Interop.Word;
    using System.Runtime.InteropServices;
    using System;
    using Mom.Test.UI.Core.Console;
    using Mom.Test.UI.Core.Common;

    #region Interface Definition - IWordDocumentControls

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Interface definition, IWordDocumentControls, for WordDocument.
    /// Defines properties for accessing UI controls.
    /// </summary>
    /// <history>
    ///   [v-waltli] 5/31/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IWordDocumentControls
    {
        /// <summary>
        /// Read-only property to access LinkTypeComboBox
        /// </summary>
        ComboBox LinkTypeComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access LinkComboBox
        /// </summary>
        ComboBox LinkComboBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AddLinkControlNameTextBox
        /// </summary>
        TextBox AddLinkControlNameTextBox
        {
            get;
        }

        /// <summary>
        /// Read-only property to access AddLinkButton
        /// </summary>
        Button AddLinkButton
        {
            get;
        }
    }
    #endregion

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// Class to encapsulate the functionality of the WordDocument window.
    /// </summary>
    /// <history>
    /// 	[v-waltli] 5/31/2009 Created
    /// </history>
    /// -----------------------------------------------------------------------------
    public class WordDocument : IWordDocumentControls
    {
        #region Enums

        /// <summary>
        /// The knowledge sections
        /// </summary>
        private enum KnowledgeSection
        {
            /// <summary>
            /// The summary section
            /// </summary>
            Summary,

            /// <summary>
            /// The configuration section
            /// </summary>
            Configuration,

            /// <summary>
            /// The causes section, per monitor state
            /// </summary>
            Causes,

            /// <summary>
            /// The resolutions section, per monitor state
            /// </summary>
            /// 
            Resolutions,

            /// <summary>
            /// The Additional Information section
            /// </summary>
            Additional,

            /// <summary>
            /// The External Knowledge Sources section
            /// </summary>
            External
        }

        #endregion

        #region Constants

        /// <summary>
        /// Word Window Class Name
        /// </summary>
        private const string WordWindowClassName = "OpusApp";

        /// <summary>
        /// Word Application
        /// </summary>
        private const string WordApplicationInterfaceName = "Word.Application";

        /// <summary>
        /// Maximum number of tries to find document
        /// </summary>
        private const int MaxRetry = 5;

        /// <summary>
        /// Sleep time to wait
        /// </summary>
        private const int Timeout = 5;

        #endregion

        #region Private Member Variables

        /// <summary>
        /// The Word application.
        /// </summary>
        private Word.Application wordApp = null;

        /// <summary>
        /// The Word document.
        /// </summary>
        private Word.Document wordDoc = null;

        /// <summary>
        /// The Word document window
        /// </summary>
        private Window wordDocumentWindow = null;

        /// <summary>
        /// Cache to hold a reference to LinkTypeComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedLinkTypeComboBox;

        /// <summary>
        /// Cache to hold a reference to LinkComboBox of type ComboBox
        /// </summary>
        private ComboBox cachedLinkComboBox;

        /// <summary>
        /// Cache to hold a reference to AddLinkControlNameTextBox of type TextBox
        /// </summary>
        private TextBox cachedAddLinkControlNameTextBox;

        /// <summary>
        /// Cache to hold a reference to AddLinkButton of type Button
        /// </summary>
        private Button cachedAddLinkButton;

        #endregion

        #region Constructors

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Default constructor.
        /// Loop to wait for the word document appear and capture main window
        /// </summary>
        /// <history>
        /// 	[v-waltli] 5/31/2009 Created
        ///     [a-joelj]   16OCT09 Maui 2.0 Required Change: Calling the Window constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        public WordDocument()
        {
            Utilities.LogMessage("WordDocument:: Looping to check for Word document instance appearing...");

            // Loop to wait for the word document to appear
            for (int numberOfTries = 0; numberOfTries < MaxRetry && this.wordDoc == null; numberOfTries++)
            {
                Utilities.LogMessage("WordDocument:: Marshal word document current retry attempt := " + (numberOfTries + 1));

                try
                {

                    // Capture the word application
                    this.wordApp = Marshal.GetActiveObject(WordDocument.WordApplicationInterfaceName) as Word.Application;

                    // Get Active document
                    this.wordDoc = this.wordApp.ActiveDocument;

                }
                catch (System.Runtime.InteropServices.COMException comEx)
                {
                    Utilities.LogMessage("WordDocument:: Caught COMException; should be ok to continue : " + comEx.ToString());

                    // Need to wait 15 seconds between each attempt for Word to load
                    Maui.Core.Utilities.Sleeper.Delay(Constants.DefaultDialogTimeout);
                }
            }

            if (this.wordDoc != null)
            {
                Utilities.LogMessage("WordDocument:: wordDoc Activate() initiated");

                // Activate the Word Document
                this.wordDoc.Activate();
            }

            Utilities.LogMessage("WordDocument:: Looping to check for Word document window appearing...");

            // [a-joelj] - Maui 2.0 Required Change: Calling the Window using WindowParameters was not working. 
            // Using a QID to get the correct window
            QID queryIdDoc = new QID(";[Window, VisibleOnly] Name ='" + string.Format("{0} - {1}", this.wordDoc.ActiveWindow.Caption, this.wordApp.Caption) + "' && Class='" + WordDocument.WordWindowClassName + "' && Role='window'");

            // Loop to capture the window
            for (int numberOfTries = 0; numberOfTries <= MaxRetry && this.wordDocumentWindow == null; numberOfTries++)
            {
                Utilities.LogMessage("WordDocument:: Capture window current retry attempt := " + (numberOfTries + 1));
                try
                {
                    this.wordDocumentWindow = new Window(queryIdDoc, Constants.DefaultDialogTimeout);
                }
                catch (Window.Exceptions.WindowNotFoundException e)
                {
                    Utilities.LogMessage("WordDocument:: Caught WindowNotFoundException; should be ok to continue : " + e.ToString());

                    // Need to wait 15 seconds between each attempt for Word to load
                    Maui.Core.Utilities.Sleeper.Delay(Constants.DefaultDialogTimeout);
                }

            }

            if (!this.wordDocumentWindow.ScreenElement.HasFocus)
            {
                Utilities.LogMessage("WordDocument:: Word document does not have focus - calling BringUp");
                this.wordDocumentWindow.ScreenElement.BringUp();

                if (this.wordDocumentWindow.ScreenElement.HasFocus)
                {
                    Utilities.LogMessage("WordDocuemnt:: After using BringUp to bring the Word document to foreground the Word Window has focus!");
                }
            }

        }
        #endregion

        #region IWordDocumentControls Controls Property

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Exposes access to the raw controls for this document
        /// </summary>
        /// <value>An interface that groups all of the document's control properties together</value>
        /// <history>
        /// 	[v-waltli] 5/31/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public virtual IWordDocumentControls Controls
        {
            get
            {
                return this;
            }
        }
        #endregion

        #region Control Properties

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkTypeComboBox control
        /// </summary>
        /// <history>
        /// 	[v-waltli] 5/31/2009 Created
        ///     [a-joelj]   12OCT09 Maui 2.0 Required Change: Calling the ComboBox constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWordDocumentControls.LinkTypeComboBox
        {
            get
            {
                if ((this.cachedLinkTypeComboBox == null))
                {

                    // [a-joelj] - Maui 2.0 Required Change: Calling the ComboBox constructor with the localized string and not the ControlID
                    // is not returning the correct ComboBox. Switching over to the UIA tree and using a QID with the AutomationId to
                    // get the correct ComboBox.

                    QID queryId = new QID(";[UIA] AutomationId=\'" + WordDocument.ControlIDs.LinkTypeComboBox + "\'");
                    this.cachedLinkTypeComboBox = new ComboBox(this.wordDocumentWindow, queryId, Constants.DefaultDialogTimeout);
                }
                return this.cachedLinkTypeComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the LinkComboBox control
        /// </summary>
        /// <history>
        /// 	[v-waltli] 5/31/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        ComboBox IWordDocumentControls.LinkComboBox
        {
            get
            {
                if ((this.cachedLinkComboBox == null))
                {
                    this.cachedLinkComboBox = new ComboBox(this.wordDocumentWindow, WordDocument.Strings.LinkComboBox);
                }
                return this.cachedLinkComboBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddLinkControlNameTextBox control
        /// </summary>
        /// <history>
        /// 	[v-waltli] 5/31/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        TextBox IWordDocumentControls.AddLinkControlNameTextBox
        {
            get
            {
                if ((this.cachedAddLinkControlNameTextBox == null))
                {
                    this.cachedAddLinkControlNameTextBox = new TextBox(this.wordDocumentWindow, WordDocument.Strings.AddLinkControlNameTextBox);
                }
                return this.cachedAddLinkControlNameTextBox;
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Exposes access to the AddLinkButton control
        /// </summary>
        /// <history>
        /// 	[v-waltli] 5/31/2009 Created
        ///     [a-joelj]   09OCT09 Maui 2.0 Required Change: Calling the Button constructor with a QID.
        /// </history>
        /// -----------------------------------------------------------------------------
        Button IWordDocumentControls.AddLinkButton
        {
            get
            {
                if ((this.cachedAddLinkButton == null))
                {
                    // [a-joelj] - Maui 2.0 Required Change: Calling the button constructor with 'this' and the ControlID 
                    // is not returning the correct Button. Switching over to the UIA tree and using a QID with the AutomationId to
                    // get the correct button.

                    QID queryId = new QID(";[UIA]AutomationId='" + WordDocument.ControlIDs.AddLinkButton + "' && Name='" + WordDocument.Strings.AddLinkButton + "' && Role='push button'");
                    this.cachedAddLinkButton = new Button(this.wordDocumentWindow, queryId, Constants.DefaultContextMenuTimeout);
                }
                return this.cachedAddLinkButton;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Add Knowledge Text To All Sections 
        /// </summary>
        /// <param name="text">Text to be added to  All Sections</param>
        /// <history>                
        /// [v-waltli] 5/26/2009 Created
        /// </history>
        public void AddKnowledgeTextToAllSections(string text)
        {
            // Add Knowledge Text To Each Section
            foreach (string sectionName in Enum.GetNames(typeof(KnowledgeSection)))
            {
                // Get each section's xpath
                string xpath = string.Format("//ns0:knowledge/ns0:{0}/ns0:body", sectionName.ToLowerInvariant());

                // Get section body
                Word.XMLNode sectionBodyNode = this.wordDoc.SelectSingleNode(xpath, "xmlns:ns0='http://tempuri.org/XMLSchema1.xsd' ", false);

                // Get section body start range
                object start = sectionBodyNode.Range.Start;
                object end = start;
                Word.Range range = this.wordDoc.Range(ref start, ref end);

                // Select the range
                range.Select();
                // Insert text after the start range
                range.InsertAfter(text);
            }
        }

        /// <summary>
        /// Add Knowledge Link To All Sections
        /// </summary>
        /// <param name="linkType">Link Type</param>
        /// <param name="linkDisplayName">Link Display Name</param>
        /// <exception cref="ComboBox.Exceptions.InvalidIndexException">
        /// Throws ComboBox.Exceptions.InvalidIndexException if Link Combo Box has no items
        /// </exception>
        /// <history>
        /// [v-waltli] 5/26/2009 Created
        /// </history>
        public void AddKnowledgeLinkToAllSections(string linkType, ref string linkDisplayName)
        {
            // Add Knowledge Link To Each Section
            foreach (string sectionName in Enum.GetNames(typeof(KnowledgeSection)))
            {
                // Get each section's xpath
                string xpath = string.Format("//ns0:knowledge/ns0:{0}/ns0:body", sectionName.ToLowerInvariant());

                // Get section body
                Word.XMLNode sectionBodyNode = this.wordDoc.SelectSingleNode(xpath, "xmlns:ns0='http://tempuri.org/XMLSchema1.xsd' ", false);

                // Get section body start range
                object start = sectionBodyNode.Range.Start;
                object end = start;
                Word.Range range = this.wordDoc.Range(ref start, ref end);

                // Select the range
                range.Select();


                Utilities.LogMessage("Selecting Link type: " + linkType);
                this.Controls.LinkTypeComboBox.SelectByText(linkType);

                Utilities.LogMessage("Checking LinkComboBox item count");
                if (this.Controls.LinkComboBox.Count == 0)
                {
                    throw new ComboBox.Exceptions.InvalidIndexException("The Link Combo Box items count is 0!");
                }
                else
                {
                    Utilities.LogMessage("The Link Combo Box items count is " + this.Controls.LinkComboBox.Count);
                    Utilities.LogMessage("Getting the first link full name item");
                    string itemText = this.Controls.LinkComboBox.get_Text(0);

                    Utilities.LogMessage("Selecting the first link full name item: " + itemText);
                    this.Controls.LinkComboBox.SelectByText(itemText);

                    // Get link display name
                    linkDisplayName = this.Controls.AddLinkControlNameTextBox.Text;

                    // Insert link after the start range
                    this.Controls.AddLinkButton.Click();
                }
            }

        }

        /// <summary>
        /// Clear All Knowledge Sections
        /// </summary>
        /// <history>                
        /// [v-waltli] 5/26/2009 Created
        /// </history>
        public void ClearAllKnowledgeSections()
        {
            // Clear Knowledge in each Section
            foreach (string sectionName in Enum.GetNames(typeof(KnowledgeSection)))
            {
                // Get each section's xpath
                string xpath = string.Format("//ns0:knowledge/ns0:{0}/ns0:body", sectionName.ToLowerInvariant());
                // Get section body
                Word.XMLNode sectionBodyNode = this.wordDoc.SelectSingleNode(xpath, "xmlns:ns0='http://tempuri.org/XMLSchema1.xsd' ", false);
                // Clear the secton content
                sectionBodyNode.Range.Text = "";
            }
        }

        /// <summary>
        /// Close Word Document
        /// </summary>
        /// <param name="save">If save the document</param>
        /// <history>                
        /// [v-waltli] 5/26/2009 Created
        /// </history>
        public void CloseWordDocument(bool save)
        {
            Utilities.LogMessage("CloseWordDocument:: Try to activate the word document");
            try
            {
                this.wordApp.Activate();
            }
            catch (Exception e)
            {
                Utilities.LogMessage("CloseWordDocument:: Caught Exception; should be ok continue : " + e.ToString());
            }

            //Bug#190931
            int maxRetries = Constants.DefaultMaxRetry;
            int retries = 0;
            while (retries < maxRetries)
            {
                this.wordDoc.Select();
                Utilities.LogMessage("CloseWordDocument:: Close the window by send key");
                Keyboard.SendKeys(Core.Common.KeyboardCodes.CloseWindow);
                Sleeper.Delay(Constants.DefaultContextMenuTimeout);

                Utilities.LogMessage("CloseWordDocument:: Try to find the Confirm choice dialog. Attempt " + retries + " of " + maxRetries);
                Window dialogWindow = null;
                try
                {
                    dialogWindow = new Maui.Core.Window(
                            Strings.ConfirmSaveWordDocumentTitle,
                            StringMatchSyntax.ExactMatch);
                }
                catch (Window.Exceptions.WindowNotFoundException)
                {
                    Utilities.LogMessage("CloseWordDocument:: Confirm choice dialog not found. Try again.");
                    retries++;
                }

                if (dialogWindow != null)
                {
                    Utilities.LogMessage("CloseWordDocument:: Confirm choice dialog found.");
                    break;
                }
            }

            if (save)
            {
                CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.Yes, Strings.ConfirmSaveWordDocumentTitle, StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);
            }
            else
            {
                CoreManager.MomConsole.ConfirmChoiceDialog(MomConsoleApp.ButtonCaption.No, Strings.ConfirmSaveWordDocumentTitle, StringMatchSyntax.ExactMatch, MomConsoleApp.ActionIfWindowNotFound.Ignore);
            }

            Utilities.LogMessage("CloseWordDocument:: Wait for Word document window to close");
            // Wait some seconds
            CoreManager.MomConsole.WaitForDialogClose(this.wordDocumentWindow, Timeout * 2);

            Utilities.LogMessage("CloseWordDocument:: Release reference resource of the word document");
            Marshal.FinalReleaseComObject(this.wordDoc);
            this.wordDoc = null;
            this.wordApp = null;

            Utilities.LogMessage("CloseWordDocument:: Activate Mom Console");
            CoreManager.MomConsole.BringToForeground();

            Utilities.LogMessage("CloseWordDocument:: Make sure the Console status is ready");
            CoreManager.MomConsole.Waiters.WaitForStatusReady();

        }

        #endregion

        #region ControlIDs Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ControlID Class 
        /// </summary>
        /// <history>
        /// 	[a-joelj] 08OCT09 Created for Maui 2.0 Required Change: AddLinkButton ControlID
        ///                       was needed to access the button properly using a QID
        /// </history>
        /// -----------------------------------------------------------------------------
        public class ControlIDs
        {

            /// <summary>
            /// Control ID for AddLinkButton
            /// </summary>
            public const string AddLinkButton = "addLink";

            /// <summary>
            /// Control ID for LinkTypeCombobox
            /// </summary>
            public const string LinkTypeComboBox = "linkTypeCombo";

        }

        #endregion

        #region Strings Class

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// String resource definitions.
        /// </summary>
        /// <history>
        /// 	[v-waltli] 5/31/2009 Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public class Strings
        {
            #region Constants

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LinkTypeComboBox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLinkTypeComboBox = ";linkTypeCombo;ManagedString;Microsoft.Mom.UI.KnowledgeWordTemplate.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Knowledge.AddLinkControl;>>linkTypeCombo.Name";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LinkComboBox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLinkComboBox = ";linkCombo;ManagedString;Microsoft.Mom.UI.KnowledgeWordTemplate.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Knowledge.AddLinkControl;>>linkCombo.Name";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddLinkControlNameTextBox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddLinkControlNameTextBox = ";nameBox;ManagedString;Microsoft.Mom.UI.KnowledgeWordTemplate.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Knowledge.AddLinkControl;>>nameBox.Name";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  AddLinkButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceAddLinkButton = ";Add Link;ManagedString;Microsoft.Mom.UI.KnowledgeWordTemplate.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Knowledge.AddLinkControl;addLink.Text";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  LinkControlNameTextBox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceLinkControlNameTextBox = ";nameBox;ManagedString;Microsoft.Mom.UI.KnowledgeWordTemplate.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Knowledge.LinkControl;>>nameBox.Name";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Contains resource string for:  Save Word Document Confirm Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private const string ResourceConfirmSaveWordDocumentTitle = ";Microsoft Office Word;ManagedString;Microsoft.Mom.UI.KnowledgeWordTemplate.dll;Microsoft.EnterpriseManagement.Mom.Internal.UI.Knowledge.KnowledgeResources;MicrosoftWord";

            #endregion

            #region Private Members

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LinkTypeComboBox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLinkTypeComboBox;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  LinkComboBox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedLinkComboBox;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddLinkControlNameTextBox
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddLinkControlNameTextBox;
            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  AddLinkButton
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedAddLinkButton;

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Caches the translated resource string for:  Save Word Document Confirm Dialog
            /// </summary>
            /// -----------------------------------------------------------------------------
            private static string cachedConfirmSaveWordDocumentTitle;

            #endregion

            #region Properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LinkTypeComboBox translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/31/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LinkTypeComboBox
            {
                get
                {
                    if ((cachedLinkTypeComboBox == null))
                    {
                        cachedLinkTypeComboBox = CoreManager.MomConsole.GetIntlStr(ResourceLinkTypeComboBox);
                    }
                    return cachedLinkTypeComboBox;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the LinkComboBox translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/31/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string LinkComboBox
            {
                get
                {
                    if ((cachedLinkComboBox == null))
                    {
                        cachedLinkComboBox = CoreManager.MomConsole.GetIntlStr(ResourceLinkComboBox);
                    }
                    return cachedLinkComboBox;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddLinkControlNameTextBox translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/31/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddLinkControlNameTextBox
            {
                get
                {
                    if ((cachedAddLinkControlNameTextBox == null))
                    {
                        cachedAddLinkControlNameTextBox = CoreManager.MomConsole.GetIntlStr(ResourceAddLinkControlNameTextBox);
                    }
                    return cachedAddLinkControlNameTextBox;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the AddLinkButton translated resource string
            /// </summary>
            /// <history>
            /// 	[v-waltli] 5/31/2009 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string AddLinkButton
            {
                get
                {
                    if ((cachedAddLinkButton == null))
                    {
                        cachedAddLinkButton = CoreManager.MomConsole.GetIntlStr(ResourceAddLinkButton);
                    }
                    return cachedAddLinkButton;
                }
            }

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Exposes access to the translated resource string for:  Save Word Document Confirm Dialog
            /// </summary>
            /// <history>
            /// 	[v-kayu] 24JAN10 Created
            /// </history>
            /// -----------------------------------------------------------------------------
            public static string ConfirmSaveWordDocumentTitle
            {
                get
                {
                    if ((cachedConfirmSaveWordDocumentTitle == null))
                    {
                        cachedConfirmSaveWordDocumentTitle = CoreManager.MomConsole.GetIntlStr(ResourceConfirmSaveWordDocumentTitle);
                    }
                    return cachedConfirmSaveWordDocumentTitle;
                }
            }
            #endregion
        }
        #endregion
    }
}
