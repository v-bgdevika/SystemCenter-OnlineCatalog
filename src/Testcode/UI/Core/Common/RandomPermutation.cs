// ----------------------------------------------------------------------------
// <copyright file="RandomPermutation.cs" company="Microsoft">
//  Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// 
// <summary>
// Random get Recm value from group method
// </summary>
// 
// <history>
//[v-yoz]  22-May-09   Created.
// </history>
// 
// ----------------------------------------------------------------------------

namespace Mom.Test.UI.Core.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// RandomPermutation
    /// </summary>
    public class RandomPermutation
    {
        #region Private Members

        /// <summary>
        /// The random index of recm value
        /// </summary>
        static private int randomIndex = -1; 

        #endregion

        #region Public Methods
        /// <summary>
        /// Method to get a random value from recm group value
        /// </summary>
        /// <param name="recmValue">
        /// A set of recm values separated by semicolon.        
        /// </param>
        /// <returns>
        /// A random value from recm group value.
        /// </returns>
        static public string GetRandomRecmValueFromGroup(string recmValue)
        {
            return GetRandomRecmValueFromGroup(recmValue, ';');
        }
        /// <summary>
        /// Method to get a random value from recm group value
        /// </summary>
        /// <param name="recmValue">
        /// A set of recm values separated by split Char.     
        /// </param>
        /// <param name="separater">
        /// A split char to split recm string. 
        /// </param>
        /// <returns>
        /// A random value from recm group value.
        /// </returns>
        static public string GetRandomRecmValueFromGroup(string recmValue, char separater)
        {
            if (String.IsNullOrEmpty(recmValue))
            {
                return recmValue;
            }

            Core.Common.Utilities.LogMessage(
                "GetRandomRecmValueFromGroup::GetRandomRecmGroup...");

            Core.Common.Utilities.LogMessage(
                "GetRandomRecmValueFromGroup::Recm group is " +
                recmValue);

            //separater the recm value by separater parameter
            string[] arrayOfRecmValue = recmValue.Split(separater);

            Core.Common.Utilities.LogMessage(
                "GetRandomRecmValueFromGroup::Checking for valid array...");

            if (null != arrayOfRecmValue)
            {
                //Generate a random number
                if (randomIndex == -1)
                {
                    Random ra = new Random();
                    randomIndex = ra.Next(0, arrayOfRecmValue.Length);
                }

                if (randomIndex < arrayOfRecmValue.Length)
                {
                    Core.Common.Utilities.LogMessage(
                    "GetRandomRecmValueFromGroup::Random Recm item is " +
                    arrayOfRecmValue[randomIndex]);

                    return arrayOfRecmValue[randomIndex];
                }
                else
                {
                    Core.Common.Utilities.LogMessage(
                    "GetRandomRecmValueFromGroup::Random Recm item is " +
                    arrayOfRecmValue[0]);

                    return arrayOfRecmValue[0];
                }

            }
            else
            {
                Core.Common.Utilities.LogMessage(
                    "GetRandomRecmValueFromGroup::Random Recm item is " +
                    String.Empty);

                return String.Empty;
            }
        }
        /// <summary>
        /// Method to Reset random seed
        /// </summary>
        static public void ResetRandomSeed()
        {
            randomIndex = -1;
        }
        #endregion
    }

    
}
