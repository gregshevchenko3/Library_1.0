using Library.Models.Persons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Storages
{
    
    abstract class StorageInfo
    {
        private string _paperFormat;
        
        private string _title;
        public Genres Genre { get; set; }
        public Langs Lang { get; set; }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value; 
            }
        }
        private DateTime _dateOfPublished;

        private string _publisher;                  
        private List<Author> _authors;              
        private List<Page> _pages;
        public StorageInfo(string pathToFile, string title, Genres genre, Langs lang, string paperFormat, string publisher, DateTime dateOfPublished)
        {
            Title = title;
            Genre = genre;
            Publisher = publisher;
            _authors = new List<Author>();
            _paperFormat = paperFormat;
            _pages = StorageReader.getPages(pathToFile, PaperStrogeStandarts.getPaperInfo(_paperFormat));
        }
        public List<Author> Authors
        {
            get
            {
                return _authors;
            }
        }
        public StorageInfo(string pathToFile, string title, Genres genre, Langs lang, string paperFormat, string publisher, DateTime dateOfPublished, List<Author> authors)
        {
            _authors = authors;
            _paperFormat = paperFormat;
            _pages = StorageReader.getPages(pathToFile, PaperStrogeStandarts.getPaperInfo(_paperFormat));
        }
        public string Publisher
        {
            get
            {
                return _publisher;
            }
            set
            {
                if(value.Length >= 3)
                {
                    _publisher = value;
                }
                else
                {
                    throw new ArgumentException("Некорректный издатель");
                }
            }
        }
        public Page GetPage(int index)
        {
            return _pages[index];
        }
        public DateTime DaTePublish
        {
            protected set
            {
                if (value < DateTime.Now)
                {
                    _dateOfPublished = value;
                } else
                {
                    throw new ArgumentException("Книга из будущего");
                }
            }
            get
            {
                return _dateOfPublished;
            }
        }
    }
}
