//-------------------------------------------------------------------
// <copyright file="RandomStrings.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <summary>
//   Random String Generation Methods.
// </summary>
// 
//  <history>
//  [mbickle] 01JAN05:  Created
//  [ruhim]   08NOV05:  Updated CreateRandomString method to check for a single
//                      space returned
//  </history>
//-------------------------------------------------------------------
namespace Mom.Test.UI.Core.Common
{
    #region Using directives
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;
    using Infra.Frmwrk;
    #endregion

    #region Globalization Random Strings
    /// ------------------------------------------------------------------
    /// <summary>
    /// RandomStrings for Globalization Testing.
    /// </summary>
    /// <history>
    ///     [rvaughn] 25AUG03   Created
    /// </history>
    /// ------------------------------------------------------------------
    public class RandomStrings
    {
        /// <summary>
        /// International Strings Reference
        /// </summary>
        private Maui.Core.International.IntlStrings intlStrings;

        /// ------------------------------------------------------------------
        /// <summary>
        /// CreateRandomStrings
        /// </summary>
        /// <history>
        ///     [rvaughn] 25AUG03   Created
        /// </history>
        /// ------------------------------------------------------------------
        public RandomStrings()
        {
            this.intlStrings =
                new Maui.Core.International.IntlStrings(Utilities.Seed);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// CreateRandomStrings
        /// </summary>
        /// <param name="seed">random seed</param>
        /// <history>
        ///     [billhodg] 21SEP09   Created
        /// </history>
        /// ------------------------------------------------------------------
        public RandomStrings(int seed)
        {
            this.intlStrings =
                new Maui.Core.International.IntlStrings(Utilities.Seed);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// CreateRandomStrings
        /// </summary>
        /// <param name="context">Context</param>
        /// <history>
        ///     [rvaughn] 25AUG03   Created
        /// </history>
        /// ------------------------------------------------------------------
        [Obsolete("Please use  RandomStrings(int seed) or  RandomStrings()")]
        public RandomStrings(IContext context)
        {
            this.intlStrings =
                new Maui.Core.International.IntlStrings(context.Framework.GetSeed());
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// CreateRandomStrings
        /// </summary>
        /// <param name="minLength">Min Length</param>
        /// <param name="maxLength">Max Length</param>
        /// <returns>String</returns>
        /// <history>
        ///    [rvaughn] 25AUG03   Created
        /// </history>
        /// ------------------------------------------------------------------
        public string CreateRandomString(int minLength, int maxLength)
        {
            string cultureInfo =
                System.Globalization.CultureInfo.CurrentCulture.Name;
            return this.CreateRandomString(
                minLength,
                maxLength,
                "".ToCharArray(),
                cultureInfo);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// CreateRandomStrings
        /// </summary>
        /// <param name="minLength">Min Length</param>
        /// <param name="maxLength">Max Length</param>
        /// <param name="excludeCharacter">Exclude Character</param>
        /// <returns>String</returns>
        /// <history>
        ///     [rvaughn] 25AUG03   Created
        /// </history>
        /// ------------------------------------------------------------------
        public string CreateRandomString(int minLength, int maxLength, char[] excludeCharacter)
        {
            string cultureInfo = System.Globalization.CultureInfo.CurrentCulture.Name;
            return this.CreateRandomString(minLength, maxLength, excludeCharacter, cultureInfo);
        }

        /// ------------------------------------------------------------------
        /// <summary>
        /// CreateRandomStrings
        /// </summary>
        /// <param name="minLength">Min Length</param>
        /// <param name="maxLength">Max Length</param>
        /// <param name="excludeCharacter">Exclude Character</param>
        /// <param name="cultureInfo">Culture</param>
        /// <returns>String</returns>
        /// <history>
        ///     [rvaughn] 25AUG03   Created
        /// </history>
        /// ------------------------------------------------------------------
        public string CreateRandomString(
            int minLength,
            int maxLength,
            char[] excludeCharacter,
            string cultureInfo)
        {
            string newRandomString;

            //Log the min and max length
            Utilities.LogMessage("RandomStrings.CreateRandomString:: random string minLength : "
                + minLength);
            Utilities.LogMessage("RandomStrings.CreateRandomString:: random string maxLength : "
                + maxLength);

            // Generate Random String Based of User Local.
            newRandomString = this.intlStrings.GetRandomString(
                minLength,
                maxLength,
                excludeCharacter,
                new CultureInfo(cultureInfo));
            
            
            // If the random string generated contains only white spaces
            // and if minLength is set to 1 then we generate another random string 
            if ((minLength == 1) && (newRandomString.Trim().Length == 0))
            {
                Utilities.LogMessage("RandomStrings.CreateRandomString:: RandomString generated was : '"
                + newRandomString + "'");
                newRandomString = this.intlStrings.GetRandomString(
                minLength,
                maxLength,
                excludeCharacter,
                new CultureInfo(cultureInfo));

                Utilities.LogMessage("RandomStrings.CreateRandomString:: Regenerating the RandomString resulted in : '"
                + newRandomString + "'");                
            }
            //Log the length of the string created
            Utilities.LogMessage("RandomStrings.CreateRandomString:: Regenerated RandomString length is : "
                + newRandomString.Length.ToString());

            //If newly generated string went over the max length
    //        if (newRandomString.Trim().Length > maxLength)
    //        {
    //            newRandomString = newRandomString.Substring(0, maxLength);
    //            Utilities.LogMessage("RandomStrings.CreateRandomString:: New RandomString, substring of maxLength resulted in : '"
    //+ newRandomString + "'");
    //            Utilities.LogMessage("RandomStrings.CreateRandomString:: New RandomString's length is : '"
    //                + newRandomString.Length.ToString() + "'");
    //        }
            //return Maui.Core.Keyboard.EscapeSpecialCharacters(newRandomString.Trim());
            //removed EscapeSpecialCharacters since it was changing the length of the string
            return newRandomString.Trim();
        }
    }
    #endregion
}
