//-------------------------------------------------------------------
// <copyright file="CoreManager.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   MomConsole Application Core Code.
// </summary>
//  <history>
//   [mbickle] 02DEC04: Created
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Console
{
    #region Using directives
    
    using System;
    
    #endregion

    /// ------------------------------------------------------------------
    /// <summary>
    ///     Global References. 
    /// </summary>
    /// <history>
    ///     [mbickle] 02DEC04: Created
    ///     [billhodg] 04MAY10: Changed from singleton to array to support multiple consoles
    /// </history>
    /// ------------------------------------------------------------------
    public class CoreManager
    {
        /// <summary>
        /// support multiple consoles
        /// the internal store is currently an array, though it could be anything.
        /// its initialized to have a single null entry
        /// </summary>
        private static MomConsoleApp[] consoles = new MomConsoleApp[0];

        /// <summary>
        /// Gets the MomConsoleApp identified by Id
        /// </summary>
        /// <param name="i">the ID if the console app</param>
        /// <returns>a MomConsole instance</returns>
        public static MomConsoleApp GetConsole(int Id)
        {
            MomConsoleApp app = null;
            if (consoles.Length > Id)
            {
                app = consoles[Id];
            }
            return app;
        }

        /// <summary>
        /// Adds a new MomConsoleApp to the class store
        /// </summary>
        /// <param name="app">The app to add</param>
        /// <returns>an Id for the App</returns>
        public static int AddConsole(MomConsoleApp app)
        {
            //look for the first availble position
            int availablePosition = consoles.Length;
            for (int i = 0; i <= consoles.Length - 1; i++)
            {
                if (consoles[i] == null)
                {
                    availablePosition = i;
                    break;
                }
            }

            //if no positions are available add to the end of the array
            if (availablePosition == consoles.Length)
            {
                Array.Resize<MomConsoleApp>(ref consoles, consoles.Length + 1);
            }
            consoles[availablePosition] = app;
            return availablePosition;
        }

        /// <summary>
        /// Removes the MomConsoleApp from the store
        /// </summary>
        /// <param name="Id">the Id of the MomConsoleApp</param>
        public static void RemoveConsole(int Id)
        {
            //set the instance to null
            CoreManager.consoles[Id] = null;

            //count all null apps back from the end of the array
            int newLength = consoles.Length;
            for (int item = consoles.Length - 1; item >= 0; item--)
            {
                if (consoles[item] == null)
                {
                    newLength = item;
                }
                else
                {
                    //stop at the first non-null item
                    break;
                }
            }

            //make the array smaller elminating as many freed up objects as we can.
            if (consoles.Length != newLength)
                Array.Resize<MomConsoleApp>(ref consoles, newLength);
        }

        /// <summary>
        /// MomConsole Application
        /// is null if not set
        /// </summary>
        public static MomConsoleApp MomConsole
        {
            get
            {
                return CoreManager.GetConsole(0);
            }

            set
            {
                if (consoles.Length == 0)
                {
                    Array.Resize<MomConsoleApp>(ref consoles, 1);
                }
                consoles[0] = value;
            }
        }
    }
}
