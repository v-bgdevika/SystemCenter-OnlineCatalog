using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public class MsiToCategoriesMapping
    {
        private string DataExceptionFilePath;
        private Dictionary<string, List<string>> msiAndCategoriesMap = new Dictionary<string, List<string>>();

        /// <summary>
        /// Constructor
        /// </summary>
        public MsiToCategoriesMapping()
        {
            this.DataExceptionFilePath = Common.MSI_CATEGORY_MAPPING_EXCEPTION_FILE_PATH;
            ProcessDataFile();
        }

        /// <summary>
        /// Prcoess data file to get cache it
        /// </summary>
        private void ProcessDataFile()
        {
            //Process 1:M case (1-MSI having Many Categories)
            string[] exceptionLines = System.IO.File.ReadAllLines(this.DataExceptionFilePath);

            foreach (string line in exceptionLines)
            {
                string[] cells = line.Split(',');
                string productID = cells[0];
                string msiUrl = cells[1];
                string categoryID = cells[4];
                if(!string.IsNullOrEmpty(msiUrl))
                {
                    if (this.msiAndCategoriesMap.ContainsKey(msiUrl))
                    {
                        this.msiAndCategoriesMap[msiUrl].Add(categoryID);
                    }
                    else
                    {
                        List<string> categoryList = new List<string>();
                        categoryList.Add(categoryID);
                        this.msiAndCategoriesMap.Add(msiUrl, categoryList);
                    }
                }
            }
        }


        /// <summary>
        /// Gets category related detail
        /// </summary>
        /// <param name="msiUrl">string</param>
        /// <returns>List<string></returns>
        public List<string> GetDetails(string msiUrl)
        {
            if(!string.IsNullOrEmpty(msiUrl) && this.msiAndCategoriesMap.ContainsKey(msiUrl) )
            {
                return this.msiAndCategoriesMap[msiUrl];
            }
            
            return null;
        }
    }
}
