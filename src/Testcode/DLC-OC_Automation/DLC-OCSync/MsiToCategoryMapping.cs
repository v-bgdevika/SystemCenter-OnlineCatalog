using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLC_OCSync
{
    public class MsiToCategoryMapping
    {
        private string DataFilePath;
        private List<MsiToCategory> msiAndCategoryMap = new List<MsiToCategory>();

        /// <summary>
        /// Constructor
        /// </summary>
        public MsiToCategoryMapping()
        {
            this.DataFilePath = Common.MSI_CATEGORY_MAPPING_FILE_PATH;
            ProcessDataFile();
        }

        /// <summary>
        /// Prcoess data file to get cache it
        /// </summary>
        private void ProcessDataFile()
        {
            string[] lines = System.IO.File.ReadAllLines(this.DataFilePath);

            foreach(string line in lines)
            {
                string[] cells = line.Split(',');
                this.msiAndCategoryMap.Add(new MsiToCategory(cells[0], cells[1], cells[2], cells[3], cells[4], cells[5]));
            }
        }


        /// <summary>
        /// Gets category related detail
        /// </summary>
        /// <param name="productId">string</param>
        /// <param name="msiUrl">string</param>
        /// <returns>MsiToCategory</returns>
        public MsiToCategory GetDetails(string productId, string msiUrl)
        {
            if(!string.IsNullOrEmpty(productId) && !string.IsNullOrEmpty(msiUrl))
            {
                return this.msiAndCategoryMap.Find(x => x.ProductId == productId && x.MsiUrl == msiUrl);
            }
            else if (!string.IsNullOrEmpty(msiUrl))
            {
                return this.msiAndCategoryMap.Find(x => x.MsiUrl == msiUrl);
            }
            else if(!string.IsNullOrEmpty(productId))
            {
                return this.msiAndCategoryMap.Find(x => x.ProductId == productId);
            }

            return null;
        }
    }
}
