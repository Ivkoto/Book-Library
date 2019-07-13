using System;
using System.ComponentModel.DataAnnotations;

namespace Book_library.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string genre;
        private bool isShared;
        private string sharedWith;

        public Book()
        {

        }
        public Book(int id, string title, string author, bool isShared)
            : this()
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.IsShared = isShared;
        }

        public Book(int id, string title, string author, bool isShared, string sharedWith)
            : this(id, title, author, isShared)
        {
            this.SharedWith = sharedWith;
        }

        [Required]
        [Key]
        [MinLength(1, ErrorMessage = "ID must be a positive number!")]
        public int Id
        {
            get => this.id;
            private set
            {
                if (value >= 0)
                {
                    throw new NullReferenceException("ID can't be null or negative number!!!");
                }
                this.id = value;
            }
        }

        [MinLength(1, ErrorMessage = "Title must be at lest 1 symbol!!!")]
        public string Title
        {
            get => this.title;
            private set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException("Title must be at lest 1 symbol!!!");
                }
                this.title = value;
            }
        }

        [MinLength(1, ErrorMessage = "Name must be at lest 1 symbol!!!")]
        public string Author
        {
            get => this.author;
            private set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException("Name must be at lest 1 symbol!!!");
                }
                this.author = value;
            }
        }

        [MinLength(3, ErrorMessage = "Genre must be at lest 3 symols!!!")]
        public string Genre
        {
            get => this.genre;
            private set
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Genre must be at lest 3 symbols!!!");
                }
                this.genre = value;
            }
        }
        private bool IsShared
        {
            set
            {
                this.isShared = value;
            }
        }
        public string SharedWith
        {
            get => this.sharedWith;
            private set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException("Name must be at lest 1 symbol!!!");
                }
                this.sharedWith = value;
            }
        }
    }
}
