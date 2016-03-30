using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace ReadBooksEasy.Domain.Entities
{
    public class Book
    {
        public Book()
        {
            this.Bookmarks = new HashSet<Bookmark>();
            this.UsersBooks = new HashSet<UsersBook>();
        }
        [Key]
        [HiddenInput(DisplayValue=false)]
        public int idBook { get; set; }
        public string nameOfBook { get; set; }
        public string genreOfBook { get; set; }
        public byte[] fileOfBook { get; set; }
        public Nullable<double> ratingOfBook { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<UsersBook> UsersBooks { get; set; }
        /*
        [Key]
        public int idBook { get; set; }
        public string nameOfBook { get; set; }
        public string genreOfBook { get; set; }
        public object fileOfBook { get; set; }
        public double ratingOfBook { get; set; }*/
    }
}
