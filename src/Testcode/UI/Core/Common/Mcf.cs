//-------------------------------------------------------------------
// <copyright file="Mcf.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Contains Wrapped MCF calls to get values from varmap, commandline, etc.
// </summary>
// 
//  <history>
//  [mbickle] 17NOV05:  Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Common
{
    #region Using directives

    using System;
    using System.Collections.Generic;
    using System.Text;
    using Infra.Frmwrk;
    using System.Xml;
    using System.Globalization;
    using Microsoft.EnterpriseManagement.Configuration;
    using System.Collections;

    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    /// ManagedCodeFramework - Contains common methods for accessing 
    /// VarMaps, etc.
    /// </summary>
    /// <history>
    /// [mbickle] 17NOV05: Created
    /// [barryw]  30NOV05  Added some of the core methods and classes used
    ///                    in the Monitoring Configuration space. 
    /// </history>
    /// ------------------------------------------------------------------
    public sealed class Mcf
    {
        #region Member Variables
        
        /// <summary>
        /// Cached MCF Context reference
        /// </summary>
        private static IContext frameworkContext;

        #endregion

        #region Properties

        /// ------------------------------------------------------------------
        /// <summary>
        /// Property for MCF Context
        /// </summary>
        /// <history>
        ///     [mbickle] 18NOV03 Created
        ///     [billhodg] 21SEP09 Modified to add utlities calls in constuctor
        /// </history>
        /// ------------------------------------------------------------------
        public static IContext FrameworkContext
        {
            get
            {
                return frameworkContext;
            }

            set
            {
                if (value == null)
                {
                    // Legacy areas do not always set the context, therefore we cannot throw here.
                    Utilities.LogMessage("Mcf.FrameworkContext: someone is setting context to NULL!!");
                }
                else
                {
                    Utilities.Seed = value.Framework.GetSeed();
                    frameworkContext = value;
                }
            }
        }

        #endregion  // Properties

        #region Public Methods

        #region VarMap Methods.

        #region GetValueFromParameterList
        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the command line parameter list.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <param name="defValue">Default Value</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromParameterList(IContext context, string key, string defValue)
        {
            string retValue = null;
            if (context.Framework.HasKey(key))
            {
                retValue = context.Framework.GetValue(key);
            }
            else
            {
                retValue = defValue;
            }
            return retValue;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the command line parameter list.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromParameterList(IContext context, string key)
        {
            return GetValueFromParameterList(context, key, null);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the command line parameter list.
        /// Uses global FrameworkContext.
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 01SEP05 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromParameterList(string key)
        {
            return GetValueFromParameterList(FrameworkContext, key, null);
        }
        #endregion

        #region GetValueFromRecords
        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML Record Set or uses a default value.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <param name="defValue">Default Value</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromRecords(IContext context, string key, string defValue)
        {
            string retValue = null;
            if (context.Records.HasKey(key))
            {
                retValue = context.Records.GetValue(key);
            }
            else
            {
                retValue = defValue;
            }
            return retValue;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML Record Set.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromRecords(IContext context, string key)
        {
            return GetValueFromRecords(context, key, null);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML Record Set.
        /// uses global FrameworkContext
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 09SEP05 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromRecords(string key)
        {
            return GetValueFromRecords(FrameworkContext, key, null);
        }
        #endregion

        #region GetValueFromFncRecords
        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML FncRecord Set or uses Default Value
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <param name="defValue">Default Value</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromFncRecords(IContext context, string key, string defValue)
        {
            string retValue = null;
            if (context.FncRecords.HasKey(key))
            {
                retValue = context.FncRecords.GetValue(key);
            }
            else
            {
                retValue = defValue;
            }
            return retValue;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML FncRecord Set.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromFncRecords(IContext context, string key)
        {
            return GetValueFromFncRecords(context, key, null);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML FncRecord Set.
        /// uses global FrameworkContext
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 01SEP05 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromFncRecords(string key)
        {
            return GetValueFromFncRecords(FrameworkContext, key, null);
        }
        #endregion

        #region GetValueFromStartState
        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML StartState or Default Value
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <param name="defValue">Default Value</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromStartState(IContext context, string key, string defValue)
        {
            string retValue = null;
            if (context.StartStates.HasKey(key))
            {
                retValue = context.StartStates.GetValue(key);
            }
            else
            {
                retValue = defValue;
            }
            return retValue;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML StartState.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromStartState(IContext context, string key)
        {
            return GetValueFromStartState(context, key, null);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML StartState.
        /// Uses global FrameworkContext
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromStartState(string key)
        {
            return GetValueFromStartState(FrameworkContext, key, null);
        }
        #endregion

        #region GetValueFromEndState
        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML EndState or Default Value
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <param name="defValue">Default Value</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromEndState(IContext context, string key, string defValue)
        {
            string retValue = null;
            if (context.EndStates.HasKey(key))
            {
                retValue = context.EndStates.GetValue(key);
            }
            else
            {
                retValue = defValue;
            }
            return retValue;
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML EndState.
        /// </summary>
        /// <param name="context">Framework Context</param>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromEndState(IContext context, string key)
        {
            return GetValueFromEndState(context, key, null);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// Takes a value from the XML EndState.
        /// uses global FrameworkContext
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>String Value</returns>
        /// <history>
        ///     [mbickle] 25MAR04 - Created
        /// </history>
        /// ------------------------------------------------------------------
        public static string GetValueFromEndState(string key)
        {
            return GetValueFromEndState(FrameworkContext, key, null);
        }
        #endregion

        #region GetVarmapRecordValue

        /// -------------------------------------------------------------------
        /// <summary>
        /// This function is designed to return a single record value 
        /// from the varmap.  Single test data records are used 
        /// provide a single values within a single test var
        /// permutation.
        /// </summary>
        /// <param name="recordKey">The name of the key to the varmap record.</param>
        /// <returns>A varmap values for the specified item.</returns>
        /// <exception cref="VarmapValidationException">
        /// Throws VarmapValidationException if the test data is missing.</exception>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        /// </history>
        /// -------------------------------------------------------------------
        public static string GetVarmapRecordValue(
            string recordKey)
        {
            return GetVarmapRecordValue(
                recordKey,
                null);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This function is designed to return a single record value 
        /// from the varmap.  Single test data records are used 
        /// provide a single values within a single test var
        /// permutation.
        /// </summary>
        /// <param name="recordKey">The name of the key to the varmap record.</param>
        /// <param name="recordDescription">A friendly description of the record.</param>
        /// <returns>A varmap values for the specified item.</returns>
        /// <exception cref="VarmapValidationException">
        /// Throws VarmapValidationException if the test data is missing.</exception>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        ///     [barryw] 01DEC05 - Replaced local constant with 
        ///                        'global' Constants.MultipleValues.
        /// </history>
        /// -------------------------------------------------------------------
        public static string GetVarmapRecordValue(
            string recordKey,
            string recordDescription)
        {
            ArrayList dataArray = GetVarmapRecords(
                recordKey,
                recordDescription,
                Constants.SingleValue);

            // return first value in the array.
            return dataArray[0].ToString();
        }

        #endregion  // GetVarmapRecordValue

        #region GetVarmapRecords

        /// -------------------------------------------------------------------
        /// <summary>
        /// This function is designed to return a list of multiple values 
        /// for repeated test data records from the varmap.  Repeated test data 
        /// records are used to provide multiple values within a single test var
        /// permutation, e.g., a list of items to select.
        /// </summary>
        /// <param name="recordKey">The name of the key to the varmap record.</param>
        /// <returns>A list of one or more varmap values for the specified
        /// item.</returns>
        /// <exception cref="VarmapValidationException">
        /// Throws VarmapValidationException if the test data is missing.</exception>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        ///     [barryw] 01DEC05 - Using Constants.MultipleValues.
        /// </history>
        /// -------------------------------------------------------------------
        public static ArrayList GetVarmapRecords(
            string recordKey)
        {
            return GetVarmapRecords(
                recordKey,
                null,
                Constants.MultipleValues);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This function is designed to return a list of multiple values 
        /// for repeated test data records from the varmap.  Repeated test data 
        /// records are used to provide multiple values within a single test var
        /// permutation, e.g., a list of items to select.
        /// </summary>
        /// <param name="recordKey">The name of the key to the varmap record.</param>
        /// <param name="recordDescription">A friendly description of the record.</param>
        /// <returns>A list of one or more varmap values for the specified
        /// item.</returns>
        /// <exception cref="VarmapValidationException">
        /// Throws VarmapValidationException if the test data is missing.</exception>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        ///     [barryw] 01DEC05 - Using Constants.MultipleValues.
        /// </history>
        /// -------------------------------------------------------------------
        public static ArrayList GetVarmapRecords(
            string recordKey,
            string recordDescription)
        {
            return GetVarmapRecords(
                recordKey,
                recordDescription,
                Constants.MultipleValues);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This function is designed to return one
        /// or many (in the case of repeated records) test data 
        /// values from the varmap regardless of whether they are of type
        /// REC or RECM for the specified key name.
        /// </summary>
        /// <param name="recordKey">The name of the key to the varmap record.</param>
        /// <param name="recordDescription">A friendly description of the record.</param>
        /// <param name="multipleValues">Multiple record values are expected.</param>
        /// <returns>A list of one or more varmap values for the specified
        /// item.</returns>
        /// <exception cref="VarmapValidationException">
        /// Throws VarmapValidationException if the test data is missing.</exception>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        ///     [barryw] 07DEC05 - Replaced parameter with class member variable:
        ///                        'frameworkContext'
        /// </history>
        /// -------------------------------------------------------------------
        public static ArrayList GetVarmapRecords(
            string recordKey,
            string recordDescription,
            bool multipleValues)
        {
            if (null == recordDescription)
            {
                recordDescription = "test value(s)";
            }

            Utilities.LogMessage("Mcf.GetVarmapData:: " +
                "recordDescription: " +
                recordDescription);
            Utilities.LogMessage("Mcf.GetVarmapData:: " +
                "recordKey: " +
                recordKey);

            // Create a temporary string array
            string[] data = new string[100];

            ////Todo: Might throw exception if greater 
            ////      than 100 record values.
            ////Todo: Add check for command line override, to also 
            ////      support setup team needs.
            if (frameworkContext.Records.HasKey(recordKey))
            {
                data = frameworkContext.Records.GetValues(recordKey);

                ////Todo: remove next diagnostic log statement.
                Utilities.LogMessage("Mcf.GetVarmapData:: " +
                    recordDescription + ": " +
                    data.ToString());
                if ((!multipleValues) && (data.Length > 1))
                {
                    throw new VarmapValidationException(
                        "This record unexpectedly has multiple values.");
                }

                // Convert to arraylist for easier use.
                ArrayList values = new ArrayList();
                for (int i = 0; i < data.Length; i++)
                {
                    // Add current value to the list.
                    values.Add(data[i]);
                    Utilities.LogMessage("Mcf.GetVarmapData:: " +
                        recordDescription +
                        "[" + data[i].ToString() + "]: " +
                        data.ToString());
                }
                Utilities.LogMessage("Mcf.GetVarmapData:: " +
                    "Test data collected for: " +
                    recordKey + ", " +
                    recordDescription);
                return values;
            }
            else
            {
                // Display list of varmap keys
                foreach (string key in frameworkContext.Framework.GetKeys())
                {
                    Utilities.LogMessage("Mcf.GetVarmapData:: " + 
                        "Key: " + key);
                }
                throw new VarmapValidationException("Mcf.GetVarmapData:: " +
                    "Varmap is missing record: " +
                    recordDescription + ": " +
                    recordKey);
            }
        }

        #endregion  // GetVarmapRecords

        #region GetBuildExpressionFromXml method

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method override is designed to process the row action portion of
        /// an individual build expression varmap record in Xml form. Each
        /// record corresponds to a row in the build rexpression grid.
        /// </summary>
        /// <param name="xmlText">Xml string</param>
        /// <returns>Data for a Build Expression grid row</returns>
        /// <exception cref="XmlException">Unexpected varmap value.</exception>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        /// </history>
        /// -------------------------------------------------------------------
        public static BuildExpression GetBuildExpressionFromXml(
            string xmlText)
        {
            Utilities.LogMessage("Mcf.GetBuildExpressionFromXml(string xmlText) ");

            // Initialize values.
            string gridColumnName = null;
            BuildExpression buildExpression = new BuildExpression();
            buildExpression = GetBuildExpressionFromXml(xmlText, gridColumnName);
            return buildExpression;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// This method is designed to process an individual 
        /// build expression varmap record in Xml form. Each record
        /// corresponds to a row in the build rexpression grid.
        /// This method may be called multiple times to process the complete 
        /// build expression.
        /// </summary>
        /// <param name="xmlText">Xml string</param>
        /// <param name="gridColumnName">column name</param>
        /// <returns>Data for a Build Expression grid row</returns>
        /// <exception cref="XmlException">Unexpected varmap value.</exception>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        /// </history>
        /// -------------------------------------------------------------------
        public static BuildExpression GetBuildExpressionFromXml(
            string xmlText,
            string gridColumnName)
        {
            Utilities.LogMessage("Mcf.GetBuildExpressionFromXml(...) ");

            // Initialize values.
            BuildExpression buildExpression = new BuildExpression();
            XmlDocument nameData = new XmlDocument();
            nameData.LoadXml(xmlText);
            foreach (XmlNode node in nameData.ChildNodes)
            {
                ////Todo: This method only handles one row at a time, add
                ////      validation to ensure the xml conforms to that.

                #region Process rows
                ////Todo: constants for xml node names.
                if (node.Name == "row")
                {
                    Utilities.LogMessage(
                        "Mcf.GetBuildExpressionFromXml:: " +
                        "Found 'row' node.");
                    #region Process row data

                    foreach (XmlAttribute rowAttribute in node.Attributes)
                    {
                        switch (rowAttribute.Name)
                        {
                            case "action":
                                {
                                    buildExpression.action = rowAttribute.Value;
                                    break;
                                }
                            case "index":
                                {
                                    buildExpression.rowIndex = Convert.ToInt32(rowAttribute.Value);
                                    break;
                                }
                            case "actiontype":
                                {
                                    buildExpression.actionType = rowAttribute.Value;
                                    break;
                                }
                            case "method":
                                {
                                    buildExpression.actionMethod = rowAttribute.Value;
                                    break;
                                }
                            case "reposition":
                                {
                                    buildExpression.reposition = rowAttribute.Value;
                                    break;
                                }
                            default:
                                {
                                    throw new XmlException(
                                        "Mcf.GetBuildExpressionFromXml :: " +
                                        "Unexpected varmap value: " +
                                        rowAttribute.Name);
                                }
                        }   // end switch (rowAttribute.Name).
                    }   // end foreach  

                    #endregion

                    #region Process column data

                    // process the columns if column specified
                    if (null != gridColumnName)
                    {
                        XmlNode desiredNode = null;

                        #region Get node with matching attribute name value

                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            // Make sure we are getting the column data if present.
                            if (childNode.Name == "column")
                            {
                                Utilities.LogMessage("Mcf.GetBuildExpressionFromXml :: " +
                                    "Found 'column' node, now looking for column 'name' attribute.");

                                // Determine if this is the column name specified.
                                foreach (XmlAttribute attribute in childNode.Attributes)
                                {
                                    const bool ignoreCase = false;
                                    if (String.Compare(attribute.Name, "name", ignoreCase, CultureInfo.CurrentCulture) == 0)
                                    {
                                        Utilities.LogMessage("Mcf.GetBuildExpressionFromXml:: " +
                                        "Column name wanted=" + gridColumnName + " current=" + attribute.Value);

                                        if (String.Compare(attribute.Value, gridColumnName, ignoreCase, CultureInfo.CurrentCulture) == 0)
                                        {
                                            Utilities.LogMessage("Mcf.GetBuildExpressionFromXml:: " +
                                                "Matched on column name " + gridColumnName);
                                            buildExpression.editValue = childNode.InnerText;
                                            desiredNode = childNode;
                                            break;
                                        }
                                    }
                                }   // End foreach (XmlAttribute attribute in childNode.Attributes)

                                // if we have found the desired node break out of loop
                                if (null != desiredNode) break;
                            }
                            else
                            {
                                throw new XmlException(
                                            "Mcf.GetBuildExpressionFromXml :: " +
                                            "Unexpected varmap value: " +
                                            childNode.Name);
                            }   // end if (childNode.Name == "column")
                        } // end foreach "column"

                        #endregion

                        if (null != desiredNode)
                        {
                            #region collect data

                            // collect the other data.
                            foreach (XmlAttribute attribute in desiredNode.Attributes)
                            {
                                switch (attribute.Name)
                                {
                                    case "name":
                                        {
                                            Utilities.LogMessage("Mcf.GetBuildExpressionFromXml :: " +
                                                "Column name xref is: " + attribute.Value);

                                            #region Column display name

                                            // Save xref column display name to data structure
                                            switch (attribute.Value)
                                            {
                                                case Values.PropertyColumnName:
                                                case Values.OperatorColumnName:
                                                case Values.ValueColumnName:
                                                    {
                                                        buildExpression.columnName = attribute.Value;
                                                        string infoMessage = "Added expected column xref name: " + buildExpression.columnName;
                                                        Utilities.LogMessage("Mcf.GetBuildExpressionFromXml :: " + infoMessage);
                                                    }
                                                    break;
                                                default:
                                                    {
                                                        string errorMessage = "Unexpected column xref name: " + attribute.Value;
                                                        Utilities.LogMessage("Mcf.GetBuildExpressionFromXml :: " + errorMessage);
                                                        throw new VarmapValidationException(errorMessage);
                                                    }
                                            }

                                            #endregion  // Column display name

                                            break;
                                        }
                                    case "type":
                                        {
                                            buildExpression.dataType = attribute.Value;
                                            Utilities.LogMessage("Mcf.GetBuildExpressionFromXml :: " +
                                                gridColumnName + " type is: " + buildExpression.dataType);
                                            break;
                                        }
                                    case "method":
                                        {
                                            buildExpression.editMethod = attribute.Value;
                                            Utilities.LogMessage("Mcf.GetBuildExpressionFromXml :: " +
                                                gridColumnName + " method is: " + buildExpression.editMethod);
                                            break;
                                        }
                                    case "random":
                                        {
                                            buildExpression.randomData = Convert.ToBoolean(attribute.Value);
                                            Utilities.LogMessage("Mcf.GetBuildExpressionFromXml :: " +
                                                gridColumnName + " random is: " + buildExpression.randomData.ToString());
                                            break;
                                        }
                                    default:
                                        {
                                            throw new XmlException(
                                                "Mcf.GetBuildExpressionFromXml :: " +
                                                "Unexpected varmap attribute name: " +
                                                attribute.Name);
                                        }
                                }   // end switch (attribute.Name).
                            } // end foreach "collumn attributes"
                            #endregion
                        }
                        else
                        {
                            Utilities.LogMessage("Mcf.GetBuildExpressionFromXml :: " +
                                "Column name not found: " + gridColumnName);
                        }   // end if (found).
                    }   // end if (null != gridColumnName)

                    #endregion  // Process column data
                }
                else
                {
                    throw new XmlException(
                        "Mcf.GetBuildExpressionFromXml:: " +
                        "Row data not found.");
                }   // end if
                break;

                #endregion  // Process rows
            }   // foreach(...)

            ////Todo: catch other xml exceptions.
            return buildExpression;
        }

        #endregion

        #region RandomStringPerXml

        /// <summary>
        /// Parses the Xml data and passes the length specifications to the CreateRandomString method.
        /// </summary>
        /// <param name="xmlText">Xml text specifying the random string specifications</param>
        /// <param name="minLength">Minimum length</param>
        /// <param name="maxLength">Maximum length</param>
        /// <param name="context">test infrastructure</param>
        /// <returns>Random string</returns>
        public static string RandomStringPerXml(
            string xmlText,
            int minLength,
            int maxLength,
            IContext context)
        {
            return RandomStringPerXml(xmlText, minLength, maxLength, "".ToCharArray(), context);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Parses the Xml data and passes the length specifications
        /// to the CreateRandomString method.
        /// </summary>
        /// <param name="xmlText">Xml text specifying the random string specifications</param>
        /// <param name="minLength">Minimum length</param>
        /// <param name="maxLength">Maximum length</param>
        /// <param name="excludeCharacters">Characters to exclude.</param>
        /// <param name="context">test infrastructure</param>
        /// <returns>Random string</returns>
        /// <remarks>Boundary limits, e.g., minLength, may be obtained from the
        /// respective dialog's Boundaries class's constants, e,g, 
        /// CreateRuleWizardNameDialog.Boundaries.MinLengthName.</remarks>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        /// </history>
        /// -------------------------------------------------------------------
        public static string RandomStringPerXml(
            string xmlText,
            int minLength,
            int maxLength,
            char[] excludeCharacters,
            IContext context)
        {
            Utilities.LogMessage("Mcf.RandomStringPerXml(...) ");

            // Initialize values.
            string randomString = "";
            string dataType = "unknown";
            XmlDocument nameData = new XmlDocument();
            
            ////Todo: implement a branch for whether the varmap value is xml
            ////      to support specific strings for regression tests.
            nameData.LoadXml(xmlText);
            foreach (XmlNode node in nameData.ChildNodes)
            {
                if (node.Name == "data")
                {
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        if (childNode.Name == "random")
                        {
                            foreach (XmlAttribute attribute in childNode.Attributes)
                            {
                                ////Todo: Create swicth cases to specify the datatype, 
                                ////      including specifying unsigned numerics.
                                switch (attribute.Name)
                                {
                                    case "type":
                                        {
                                            dataType = attribute.Value;
                                            break;
                                        }
                                    default:
                                        {
                                            throw new VarmapValidationException(
                                                "Mcf.RandomStringPerXml :: " +
                                                "Unexpected varmap value: " +
                                                dataType);
                                        }
                                }
                            }

                            if (dataType == "string")
                            {
                                // Generate Random String.
                                RandomStrings randomNames = new RandomStrings(context.Framework.GetSeed());
                                randomString = randomNames.CreateRandomString(
                                    minLength, 
                                    maxLength,
                                    excludeCharacters);
                                Utilities.LogMessage(
                                    "Mcf.RandomStringPerXml :: " +
                                    "Random string = " + randomString);
                                Utilities.LogMessage(
                                    "Mcf.RandomStringPerXml :: " +
                                    "length : " + randomString.Length);
                            }
                        }
                    }
                }
            }

            ////Todo: catch other xml exceptions and return original string.
            return randomString;
        }

        #endregion        #endregion // Varmap methods

        #endregion  // VarMap Methods.

        #endregion // Public Methods

        #region Structs section

        /// -------------------------------------------------------------------
        /// <summary>
        /// This structure holds the build expression row action 
        /// and a column's metadata.
        /// </summary>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        /// </history>
        /// -------------------------------------------------------------------
        public struct BuildExpression
        {
            /// <summary>
            /// Row action, e.g., insert, edit, delete.
            /// </summary>
            public string action;

            /// <summary>
            /// Row index
            /// </summary>
            public int rowIndex;

            /// <summary>
            /// What type of data is being acted upon. e.g., a property or a parameter.
            /// </summary>
            public string actionType;

            /// <summary>
            /// Method of row action, e.g., by button click, contents menu, etc.
            /// </summary>
            public string actionMethod;

            /// <summary>
            /// Reposition cursor, e.g., to row header, etc.
            /// </summary>
            public string reposition;

            /// <summary>
            /// Column name
            /// </summary>
            public string columnName;

            /// <summary>
            /// Cell data type
            /// </summary>
            public string dataType;

            /// <summary>
            /// Method of editing cell
            /// </summary>
            public string editMethod;

            /// <summary>
            /// Value in cell
            /// </summary>
            public string editValue;

            /// <summary>
            /// Data is randomly generated
            /// </summary>
            public bool randomData;
        }

        #endregion

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for varmap CollectionRules values.
        /// </summary>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        /// </history>
        /// -------------------------------------------------------------------
        public sealed class Values
        {
            #region Constants section
            ////Todo: Use tilde's to identify replaceable values in mcf-varmaps, e.g., "~HardwareManagementPack~".

            #region Constants for Management Pack cross-reference names.

            /// <summary>
            /// Constant for a varmap value for the HardwareManagementPack.
            /// </summary>
            public const string HardwareManagementPack = "HardwareManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MicrosoftImagesManagementPack.
            /// </summary>
            public const string MicrosoftImagesManagementPack = "MicrosoftImagesManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MOMAEMManagementPack.
            /// </summary>
            public const string MOMAEMManagementPack = "MOMAEMManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MOMBackwardCompatibilityManagementPack.
            /// </summary>
            public const string MOMBackwardCompatibilityManagementPack = "MOMBackwardCompatibilityManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MOMManagementPack.
            /// </summary>
            public const string MOMManagementPack = "MOMManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MOMNotificationManagementPack.
            /// </summary>
            public const string MOMNotificationManagementPack = "MOMNotificationManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MyDefaultManagementPack.
            /// </summary>
            public const string MyDefaultManagementPack = "MyDefaultManagementPack";

            /// <summary>
            /// Constant for a varmap value for the SystemManagementPack.
            /// </summary>
            public const string SystemManagementPack = "SystemManagementPack";

            /// <summary>
            /// Constant for a varmap value for the SystemWebMonitoringManagementPack.
            /// </summary>
            public const string SystemWebMonitoringManagementPack = "SystemWebMonitoringManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MicrosoftWindowsIISManagementPack.
            /// </summary>
            public const string MicrosoftWindowsIISManagementPack = "MicrosoftWindowsIISManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MicrosoftSystemServiceTypeLibrary.
            /// </summary>
            public const string MicrosoftSystemServiceTypeLibrary = "MicrosoftSystemServiceTypeLibrary";

            /// <summary>
            /// Constant for a varmap value for the MicrosoftWindowsServerADManagementPack.
            /// </summary>
            public const string MicrosoftWindowsServerADManagementPack = "MicrosoftWindowsServerADManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MicrosoftBaseOSManagementPack.
            /// </summary>
            public const string MicrosoftBaseOSManagementPack = "MicrosoftBaseOSManagementPack";

            /// <summary>
            /// Constant for a varmap value for the MicrosoftSQLServer2005ManagementPack.
            /// </summary>
            public const string MicrosoftSQLServer2005ManagementPack = "MicrosoftSQLServer2005ManagementPack";

            /// <summary>
            /// Constant for a varmap value for the WindowsSystemManagementPack.
            /// </summary>
            public const string WindowsSystemManagementPack = "WindowsSystemManagementPack";

            #endregion
            
            #region Constants for Cross-reference Managed entity types

            /// <summary>
            /// Constant for a varmap value for the Windows NT Service managed entity type.
            /// </summary>
            /// <history>
            /// 	[barryw] 29DEC05 Using tilde's to identify replaceable values in mcf-varmaps.
            /// </history>
            public const string NTService = "~WindowsNTService~";

            /// <summary>
            /// Constant for a varmap value for the Windows Computer managed entity type.
            /// </summary>
            /// <history>
            /// 	[barryw] 29DEC05 Using tilde's to identify replaceable values in mcf-varmaps.
            /// </history>
            public const string WindowsComputer = "~WindowsComputer~";

            #endregion  // Managed entity types

            #region Build expression grid

            /// <summary>
            /// Constant for a varmap value for the filter grid's 'Property' column name.
            /// </summary>
            public const string PropertyColumnName = "Property";

            /// <summary>
            /// Constant for a varmap value for the filter grid's 'Property' column name.
            /// </summary>
            public const string OperatorColumnName = "Operator";

            /// <summary>
            /// Constant for a varmap value for the filter grid's 'Property' column name.
            /// </summary>
            public const string ValueColumnName = "Value";

            /// <summary>
            /// Constant for a varmap value for the action to 'Edit' a build expression row.
            /// </summary>
            public const string Edit = "Edit";

            /// <summary>
            /// Constant for a varmap value for the action to 'Insert' a build expression row.
            /// </summary>
            public const string Insert = "Insert";

            /// <summary>
            /// Constant for a varmap value for the action to 'Delete' a build expression row.
            /// </summary>
            public const string Delete = "Delete";

            #endregion  // Build expression grid

            #region Event properties

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: EventGuid.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string EventGuid = "EventGuid";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: PublisherGuid.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string PublisherGuid = "PublisherGuid";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: EventPublisherName.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string EventPublisherName = "EventPublisherName";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: Logname/Channel.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string LognameChannel = "LognameChannel";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: Logging Computer.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string LoggingComputer = "LoggingComputer";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: EventNumber.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string EventNumber = "EventNumber";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: FullEventNumber.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string FullEventNumber = "FullEventNumber";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: EventCategory.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string EventCategory = "EventCategory";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: EventLevel.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string EventLevel = "EventLevel";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: User.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string User = "User";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property name: Description.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string Description = "Description";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property datatype: DataTypeProperty.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string DataTypeProperty = "property";

            /// -----------------------------------------------------------------------------
            /// <summary>
            /// Constant for a varmap value for the event property datatype: DataTypeParameter.
            /// </summary>
            /// -----------------------------------------------------------------------------
            public const string DataTypeParameter = "parameter";

            #endregion  // Event properties

            #region Operator Expressions

            /// <summary>
            /// Constant for a varmap cross-reference value for - Equals .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string Equality = "Equals";

            /// <summary>
            /// Constant for a varmap cross-reference value for - NotEquals .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string NotEquals = "NotEquals";

            /// <summary>
            /// Constant for a varmap cross-reference value for - Contains .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string Contains = "Contains";

            /// <summary>
            /// Constant for a varmap cross-reference value for - NotContains .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string NotContains = "NotContains";

            /// <summary>
            /// Constant for a varmap cross-reference value for - GreaterThan .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string GreaterThan = "GreaterThan";

            /// <summary>
            /// Constant for a varmap cross-reference value for - GreaterThanOrEqualTo .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string GreaterThanOrEqualTo = "GreaterThanOrEqualTo";

            /// <summary>
            /// Constant for a varmap cross-reference value for - LessThan .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string LessThan = "LessThan";

            /// <summary>
            /// Constant for a varmap cross-reference value for - LessThanOrEqualTo .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string LessThanOrEqualTo = "LessThanOrEqualTo";

            /// <summary>
            /// Constant for a varmap cross-reference value for - MatchesWildcard .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string MatchesWildcard = "MatchesWildcard";

            /// <summary>
            /// Constant for a varmap cross-reference value for - NotMatchesWildcard .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string NotMatchesWildcard = "NotMatchesWildcard";

            /// <summary>
            /// Constant for a varmap cross-reference value for - MatchesRegularExpression .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string MatchesRegularExpression = "MatchesRegularExpression";

            /// <summary>
            /// Constant for a varmap cross-reference value for - NotMatchesRegularExpression .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string NotMatchesRegularExpression = "NotMatchesRegularExpression";

            #endregion

            #region Constants for Replaceable Expressions

            /// <summary>
            /// Constant for a varmap replaceable value: ReplaceWithFullyQualifiedDomainName.
            /// </summary>
            /// <remarks>Special value that indicates to replace with the 
            /// local computer's fully qualified domain name.
            /// </remarks>
            public const string ReplaceWithFullyQualifiedDomainName = "#REPLACEWITHFQDN#";

            /// <summary>
            /// Constant for a varmap replaceable value: ReplaceWithNetBiosName.
            /// </summary>
            /// <remarks>Special value that indicates to replace with the local computer's 
            /// NetBios name.
            /// </remarks>
            public const string ReplaceWithNetBiosName = "#REPLACEWITHHOST#";

            #endregion

            #region Constants for Cross-reference rule types dialog
            
            ////Todo: Localization: Mcf.Values
            ////      Consider using tildes on other cross-reference values,
            ////      e.g., ~xref-value~ to clearly show in varmap which 
            ////      values are xrefs.

            /// <summary>
            /// Constant for a varmap cross-reference value for - EventCollection .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string EventCollection = "~EventCollection~";

            /// <summary>
            /// Constant for a varmap cross-reference value for - PerformanceDataCollection .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string PerformanceDataCollection = "~PerformanceDataCollection~";

            /// <summary>
            /// Constant for a varmap cross-reference value for - WindowsEvents .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string WindowsEvents = "~WindowsEvents~";

            /// <summary>
            /// Constant for a varmap cross-reference value for - WindowsPerformanceCounter .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string WindowsPerformanceCounter = "~WindowsPerformanceCounter~";

            /// <summary>
            /// Constant for a varmap cross-reference value for - OptimizedWindowsPerformanceCounter .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string OptimizedWindowsPerformanceCounter = "~OptimizedWindowsPerformanceCounter~";

            #endregion	// Constants for Cross-reference rule types dialog

            #region Constants for Cross-references for log name dialog 
            
            /// <summary>
            /// Constant for a varmap cross-reference value for - ApplicationLogName .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string ApplicationLogName = "~ApplicationLogName~";

            /// <summary>
            /// Constant for a varmap cross-reference value for - SystemLogName .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string SystemLogName = "~SystemLogName~";

            /// <summary>
            /// Constant for a varmap cross-reference value for - SecurityLogName .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string SecurityLogName = "~SecurityLogName~";

            /// <summary>
            /// Constant for a varmap cross-reference value for - MonadLogName .
            /// </summary>
            /// <remarks>Created using 'Test Data Cross-reference Expression' snippet</remarks>
            public const string MonadLogName = "~MonadLogName~";

            #endregion	// Constants for Cross-references for log name dialog 

            #endregion

            #region Methods section

            #region Public static methods section

            /// -------------------------------------------------------------------
            /// <summary>
            /// Recursively searches for known replaceable expressions and
            /// returns the string containing the real values.
            /// </summary>
            /// <param name="value">String to search</param>
            /// <returns>Expression containing the real values</returns>
            /// -------------------------------------------------------------------
            public static string ReplaceExpressions(string value)
            {
                Utilities.LogMessage("Mcf.Values.ReplaceExpressions:: " +
                    "value: " + value);
                string replacementExpression = null;

                ArrayList replaceableExpressions = new ArrayList();
                replaceableExpressions.Add(Values.ReplaceWithFullyQualifiedDomainName);
                replaceableExpressions.Add(Values.ReplaceWithNetBiosName);

                foreach (string replaceableExpression in replaceableExpressions)
                {
                    if (value.Contains(replaceableExpression))
                    {
                        switch (replaceableExpression)
                        {
                            case Values.ReplaceWithFullyQualifiedDomainName:
                                {
                                    Utilities.LogMessage("Mcf.Values.ReplaceExpressions:: " +
                                        "Found replaceable expression: " + replaceableExpression);
                                    ////Todo: add code to get Fully Qualified Domain Name
                                    replacementExpression = "NOT IMPLEMENTED";
                                    Utilities.LogMessage("Mcf.Values.ReplaceExpressions:: " +
                                        "Replacement expression: " + replacementExpression);

                                    // Replace the value and reform the expression.
                                    value = value.Replace(replaceableExpression, replacementExpression);
                                    Utilities.LogMessage("Mcf.Values.ReplaceExpressions:: " +
                                        "Result of replacement: " + value);
                                    break;
                                }
                            case Values.ReplaceWithNetBiosName:
                                {
                                    Utilities.LogMessage("Mcf.Values.ReplaceExpressions:: " +
                                        "Found replaceable expression: " + replaceableExpression);
                                    ////Todo: add code to get Net Bios Name
                                    replacementExpression = "NOT IMPLEMENTED";
                                    Utilities.LogMessage("Mcf.Values.ReplaceExpressions:: " +
                                        "Replacement expression: " + replacementExpression);

                                    // Replace the value and reform the expression.
                                    value = value.Replace(replaceableExpression, replacementExpression);
                                    Utilities.LogMessage("Mcf.Values.ReplaceExpressions:: " +
                                        "Result of replacement: " + value);
                                    break;
                                }
                            default:
                                {
                                    // Unknown replaceable expression. throw exception.
                                    throw new ArgumentException(
                                        "Mcf.ReplaceExpressions:: " +
                                        "A replacement expression has not been defined " + 
                                        "for this replaceable expression: " +
                                        replaceableExpression);
                                }
                        }
                    }
                }
                Utilities.LogMessage("Mcf.Values.ReplaceExpressions:: " +
                    "Returning value: " + value);
                return value;
            }

            /// -------------------------------------------------------------------
            /// <summary>
            /// Gets the real name for a varmap Managed Entiry Type (class) name 
            /// cross-reference value, or if not recognised returns the orginal value.
            /// </summary>
            /// <param name="testDataManagedEntityTypeName">The varmap value reference
            /// term for the Managed Entiry Type (class) name</param>
            /// <returns>actual Managed Entiry Type (class) name</returns>
            /// -------------------------------------------------------------------
            public static string GetManagedEntityTypeName(string testDataManagedEntityTypeName)
            {
                Utilities.LogMessage("Mcf.Values.GetManagedEntityTypeName(...)");

                Utilities.LogMessage("Mcf.Values.GetManagedEntityTypeName :: " +
                    "testDataManangementPackName: = " + testDataManagedEntityTypeName);

                // Retrieve the localized Management Entity Type name from the database.
                string managedEntityTypeName = null;
                ////Todo: Add other test data ME values as needed by varmap/test data.
                switch (testDataManagedEntityTypeName)
                {
                    case Mcf.Values.NTService:
                        {
                            managedEntityTypeName = Utilities.GetEntityName(SystemMonitoringClass.NTService);
                            break;
                        }
                    case Mcf.Values.WindowsComputer:
                        {
                            managedEntityTypeName = Utilities.GetEntityName(SystemMonitoringClass.WindowsComputer);
                            break;
                        }
                    default:
                        {
                            Utilities.LogMessage("Mcf.Values.GetManagedEntityTypeName :: " +
                                "Unknown Managed Entity Type (class) test data name, " +
                                "this may be by design, returning name unchanged.");
                            managedEntityTypeName = testDataManagedEntityTypeName;
                            break;
                        }
                }
                Utilities.LogMessage("Mcf.Values.GetManagedEntityTypeName :: " +
                    "Returning actual Managed Entity Type (class) name: = " + managedEntityTypeName);
                return managedEntityTypeName;
            }

            #endregion // Public static methods section

            #endregion  // Methods section
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Class to contain constants for varmap CollectionRules key names.
        /// </summary>
        /// <history>
        ///     [barryw] 01MAR05 - Created
        /// </history>
        /// -------------------------------------------------------------------
        public sealed class Keys
        {
            #region Constants section

            #region Constants for Management Pack key names

            /// <summary>
            /// Constant for a varmap key for the StartingManagementPackName.
            /// </summary>
            public const string StartingManagementPackName = "StartingManagementPackName";

            /// <summary>
            /// Constant for a varmap key for the GroupManagementPackName.
            /// </summary>
            public const string GroupManagementPackName = "GroupManagementPackName";

            #endregion  // Constants for Management Pack key names

            /// <summary>
            /// Constant for a varmap key for the StartingEntityPath.
            /// </summary>
            /// <remarks>The entity path may comprize multiple nodes if 
            /// naviagating from the inhieritence tree</remarks>
            public const string StartingEntityPath = "StartingEntityPath";

            #region Rule type constants

            /// <summary>
            /// Collection Rule Category, e.g., Event, Performance. 
            /// </summary>
            public const string CollectionRuleCategory = "RuleCategory";

            /// <summary>
            /// Collection Rule type, e.g., Windows Events, Windows Performance Counter. 
            /// </summary>
            public const string CollectionRuleType = "RuleType";

            #endregion  //  Rule type constants

            /// <summary>
            /// Array containing filter expression with action to perform, e.g., edit/add/insert/delete. 
            /// </summary>
            public const string RuleBuildExpressionRow = "RuleBuildExpressionRow";

            #region Constants for cross-reference for Windows Event Log dialog

            /// <summary>
            /// Constant for a varmap key for the EventLogName.
            /// </summary>
            public const string EventLogName = "EventLogName";

            /// <summary>
            /// Constant for a varmap key for the RuleName.
            /// </summary>
            public const string CollectionRuleName = "RuleName";

            /// <summary>
            /// Constant for a varmap key for the RuleDescription.
            /// </summary>
            public const string CollectionRuleDescription = "RuleDescription";

            #endregion  // Constants for cross-reference for Windows Event Log dialog

            #region Constants for ConfigurationGroups key cross-reference names

            /// <summary>
            /// Constant for a varmap key for the GroupName.
            /// </summary>
            public const string GroupName = "GroupName";

            /// <summary>
            /// Constant for a varmap key for the GroupDescription.
            /// </summary>
            public const string GroupDescription = "GroupDescription";

            /// <summary>
            /// Management Pack used in selecting static members of the group.
            /// </summary>
            public const string MembersManagementPackDisplayName = "MembersManagementPackName";

            /// <summary>
            /// Class name used in selecting static members of the group.
            /// </summary>
            public const string MembersManagedEntityTypeDisplayName = "MembersClassName";

            /// <summary>
            /// Management Pack Name to which this group will belong. 
            /// </summary>
            /// 
            public const string TargetManagementPackName = "TargetManagementPackName";

            #endregion

            #region Constants for Monitors key cross-reference names

            /// <summary>
            /// Constant for a varmap key for - ApplicationMonitorName.
            /// </summary>
            public const string ApplicationMonitorName = "ApplicationMonitorName";

            /// <summary>
            /// Constant for a varmap key for - ApplicationMonitorDescription.
            /// </summary>
            public const string ApplicationMonitorDescription = "ApplicationMonitorDescription";

            /// <summary>
            /// Constant for a varmap key for - ApplicationMonitorEnabled.
            /// </summary>
            public const string ApplicationMonitorEnabled = "ApplicationMonitorEnabled";

            #endregion	// Constants for Monitors key cross-reference names

            #endregion  // Constants section
        }
    }
}