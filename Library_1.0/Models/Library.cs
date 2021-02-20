using Library.Models.Persons;
using Library.Models.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class Library
    {
        private SortedDictionary<char, SortedList<Author, List<Book>>> _library;
        private SortedDictionary<char, List<ReaderCard>> _readercards;

        public Library()
        {
            _library = new SortedDictionary<char, SortedList<Author, List<Book>>>(); //пока пусто!!!
            _readercards = new SortedDictionary<char, List<ReaderCard>>(); 

            for (int i = 65; i < 91; i++)
            {
                _library.Add((char)i, new SortedList<Author, List<Book>>());
                _readercards.Add((char)i, new List<ReaderCard>());
            }
            for (int i = 1040; i < 1072; i++)
            {
                _library.Add((char)i, new SortedList<Author, List<Book>>());
                _readercards.Add((char)i, new List<ReaderCard>());
            }
        }
        public void addBook(Book book)
        {
            string surname = book.Authors.First<Author>().Surname.ToUpper(); //получаем фамилию первого автора
            char firstLetter = surname[0]; //первая буква фамилии
            if (_library.ContainsKey(firstLetter))
            {
                if (!_library[firstLetter].ContainsKey(book.Authors.First<Author>()))
                {
                    _library[firstLetter].Add(book.Authors.First<Author>(), new List<Book>());
                }
                _library[firstLetter][book.Authors.First<Author>()].Add(book);
            }
        }
        public List<Book> getAutorWorks(Author author)
        {
            char symb = author.Surname.ToUpper()[0];
            if (_library[symb].ContainsKey(author))
            {
                return _library[symb][author];
            }
            return new List<Book>();
        }
        public Book getBook(Author author, string title)
        {
            char symb = author.Surname.ToUpper()[0];
            if (_library[symb].ContainsKey(author))
            {
                foreach (Book book in _library[symb][author])
                {
                    if (book.Title.ToLower().Equals(title.ToLower()))
                    {
                        return book;
                    }
                }
            }
            return null;
        }
        public List<Book> getBooks(string title)
        {
            List<Book> books = new List<Book>();
            foreach (var author in _library.Values)
            {
                foreach (List<Book> list in author.Values)
                {
                    foreach (Book book in list)
                    {
                        if (book.Title.ToLower().Equals(title.ToLower()))
                        {
                            books.Add(book);
                        }
                    }
                }
            }
            return books;
        }
        public void addReaderCard(ReaderCard card)
        {
            char ch = card.Reader.Surname.ToUpper()[0];
            if (!_readercards.ContainsKey(ch))
            {
                _readercards.Add(ch, new List<ReaderCard>);
            }
            _readercards[ch].Add(card);
        }
        public ReaderCard getReaderCard(Reader reader)
        {
            char ch = reader.Surname.ToUpper()[0];
            if (!_readercards.ContainsKey(ch)) return null;
            int pos = _readercards[ch].FindIndex(item => reader.Surname == item.Reader.Surname && 
                                                          reader.Name == item.Reader.Name && 
                                                          reader.BirthDate == item.Reader.BirthDate);
            if (pos == -1) return null;
            return _readercards[ch][pos];
        }
        public bool deleteReaderCard(Reader reader)
        {
            char ch = reader.Surname.ToUpper()[0];
            if (!_readercards.ContainsKey(ch)) return false;
            int pos = _readercards[ch].FindIndex(item => reader.Surname == item.Reader.Surname &&
                                                          reader.Name == item.Reader.Name &&
                                                          reader.BirthDate == item.Reader.BirthDate);
            if (pos == -1) return false;
            _readercards[ch].RemoveAt(pos);
            return true;
            
        }
    }
}
