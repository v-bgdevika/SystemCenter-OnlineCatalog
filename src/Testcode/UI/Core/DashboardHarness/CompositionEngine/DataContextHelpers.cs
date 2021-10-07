using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Microsoft.EnterpriseManagement.CompositionEngine;
using Microsoft.EnterpriseManagement.Presentation.DataAccess;

namespace Mom.Test.UI.Core
{
    /// <summary>
    /// This can be used to debug the data context
    /// </summary>
    public static class DataContextHelpers
    {
        /// <summary>
        /// This dumps the content of the data context (and the child contexts recursively - Debug only).
        /// </summary>
        /// <param name="ctx"></param>
        public static void DumpContext(DataContext ctx)
        {
            Trace.WriteLine("--------------------------------------------------------------------------");

            try
            {
                // Write the name of the data context
                Trace.WriteLine("Name: " + (ctx.DataContextName ?? "<No Name>"));
                
                Trace.WriteLine("");
                
                // Write the contents of the data context
                Trace.WriteLine("CONTEXT ITEMS:");
                foreach (var key in ctx.Keys)
                {
                    var itemValue = ctx[key];
                    string itemValueAsString = "<null>";
                    if (itemValue != null)
                    {
                        itemValueAsString = itemValue.ToString();
                    }

                    Trace.WriteLine("ctx." + key + " = " + itemValueAsString);
                }

                var itemsFieldInfo = ctx.GetType().GetField("items", BindingFlags.NonPublic | BindingFlags.Instance);
                if (itemsFieldInfo != null)
                {
                    var pointers = itemsFieldInfo.GetValue(ctx) as Dictionary<string, Pointer>;
                    if (pointers != null)
                    {
                        Trace.WriteLine("");
                        Trace.WriteLine("POINTERS: ");
                        foreach (var item in pointers)
                        {
                            Trace.WriteLine(item.Key + ":" + item.GetType().Name);
                        }
                    }
                }

                Trace.WriteLine("");

                // Write out how the context values are bound to each other.
                Trace.WriteLine("BINDING DEFINITIONS: ");
                var fieldInfo = ctx.GetType().GetField("BindingDefinitions", BindingFlags.Instance | BindingFlags.NonPublic);
                if (fieldInfo == null)
                {
                    Trace.WriteLine("Did not find the BindingDefinitions field");
                    return;
                }

                var value = fieldInfo.GetValue(ctx);
                if (value == null)
                {
                    Trace.WriteLine("List<DataContextBindingDefinition> is empty");
                    return;
                }

                var bindingDefinitions = value as IList;
                if (bindingDefinitions == null)
                {
                    Trace.WriteLine("Value of ctx.BindingDefinitions is not a list. Its type is: " +
                                    value.GetType().FullName);
                }

                if (bindingDefinitions != null)
                {
                    foreach (var item in bindingDefinitions)
                    {
                        var dataContextBindingDefinition = item.GetType();
                        var sourcePropertyInfo = dataContextBindingDefinition.GetProperty("Source",
                                                                                          BindingFlags.Instance |
                                                                                          BindingFlags.GetProperty |
                                                                                          BindingFlags.Public);
                        if (sourcePropertyInfo == null)
                        {
                            Trace.WriteLine("Did not find the DataContextBindingDefinition.Source property");
                        }

                        var targetPropertyInfo = dataContextBindingDefinition.GetProperty("Target",
                                                                                          BindingFlags.Instance |
                                                                                          BindingFlags.GetProperty |
                                                                                          BindingFlags.Public);
                        if (targetPropertyInfo == null)
                        {
                            Trace.WriteLine("Did not find the DataContextBindingDefinition.Target property");
                        }

                        var source = sourcePropertyInfo.GetValue(item, null) as WeakReference;
                        string sourceContextName = "";
                        if (source.IsAlive)
                        {
                            var srcContext = source.Target as DataContext;
                            sourceContextName = srcContext.DataContextName;
                        }

                        var target = targetPropertyInfo.GetValue(item, null) as WeakReference;
                        string targetContextName = "";
                        if (target.IsAlive)
                        {
                            var tgtContext = target.Target as DataContext;
                            targetContextName = tgtContext.DataContextName;
                        }

                        Trace.WriteLine("Source: " + sourceContextName + " Target: " + targetContextName);
                    }
                }
            }
            finally
            {
                Trace.WriteLine("--------------------------------------------------------------------------");
            }
        }
    }
}
