using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Storages
{
    class StorageReader
    {
        static public List<Page> getPages(string pathToFile, KeyValuePair<Size, int> paperFormat)
        {
            List<Page> pages = new List<Page>();
            
            string[] bookRows = FileReader.ReadTxtFile(pathToFile);
            int maxLetter = paperFormat.Value;

            int counter = 0;
            while (counter < bookRows.Length)
            {
                Page page = new Page();
                    while (page.Write(bookRows[counter], maxLetter))
                    {
                        counter++;
                        if (counter == bookRows.Length) break;
                    }
                pages.Add(page);
            }
            return pages;
        }
    }
}
