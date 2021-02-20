using Library.Models.Persons;
using Library.Models.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    struct Record{
        private DateTime _getBookDate;
        private DateTime _returnBookDate;
        public DateTime GetBookDate { 
            get => _getBookDate;
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("Date of getting book is invalid!");
                _getBookDate = value;
            }
        }
        public DateTime ReturnBookDate {
            get => _returnBookDate;
            set
            {
                if (value < DateTime.Now)
                    throw new Exception("Date of returning book is invalid!");
                _returnBookDate = value;
            }
        }
        public StorageInfo Storage { get; set; }

    }
    class ReaderCard
    {
        public Reader Reader { get; private set; }
        List<Record> _archive, _records;
        public ReaderCard(Reader reader)
        {
            Reader = reader;
            _archive = new List<Record>();
            _records = new List<Record>();
            
        }
        public void AddRecord(StorageInfo obj)
        {
            _records.Add(new Record { Storage = obj, GetBookDate = DateTime.Now });
        }
        public void DelRecord(StorageInfo obj)
        {
            int rec = _records.FindIndex(x => obj.Equals(x.Storage));
            if (rec >= 0)
            {
                Record rc = _records[rec];
                rc.ReturnBookDate = DateTime.Now;
                _records.RemoveAt(rec);
                _archive.Add(rc);
            }
        }
        private string list_to_str(List<Record> list)
        {
            string recs = "";
            foreach (var item in list)
            {
                recs += $"GetBookDate: {item.GetBookDate}\n" +
                    $"ReturnBookDate: {item.ReturnBookDate}\n " +
                    $"What:\n\t {item.Storage}\n";
            }
            return recs;
        }
        override public string ToString()
        {
            string 
            recs = "-------------------------------HISTORY--------------------------------------------------\n";
            recs += list_to_str(ArchiveRecords);
            recs += "------------------------------ACTIVE----------------------------------------------------\n";
            recs += list_to_str(Records);
            recs += "------------------------------END-------------------------------------------------------\n";
            return recs;
        }
        public List<Record> ArchiveRecords
        {
            get
            {
                return _archive;
            }
        }
        public List<Record> Records
        {
            get
            {
                return _records;
            }
        }
    }
}
