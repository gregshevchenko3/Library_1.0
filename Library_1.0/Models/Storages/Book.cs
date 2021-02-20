using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Storages
{
    class Book : StorageInfo, IPrinted
    {
        public Book(string pathToFile, string title, Genres genre, Langs lang, string paperFormat, string publisher, DateTime dateOfPublished) 
            : base(pathToFile, title, genre, lang, paperFormat, publisher, dateOfPublished)
        {

        }

        public void PrintToImg(int index)
        {
            throw new NotImplementedException();
        }

        public void Show(int index)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return $"Book: " +
                $"\n\t Tilte: {Title};" +
                $"\n\t Genre: {Genre};" +
                $"\n\t Lang: {Lang};" +
                $"\n\t Publisher: {Publisher};" +
                $"\n\t Date of published: {DaTePublish};";
        }
    }
}
