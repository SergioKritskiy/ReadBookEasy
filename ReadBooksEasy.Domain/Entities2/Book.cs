//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReadBooksEasy.Domain.Entities2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.Bookmarks = new HashSet<Bookmark>();
            this.UsersBooks = new HashSet<UsersBook>();
        }
    
        public int idBook { get; set; }
        public string nameOfBook { get; set; }
        public string genreOfBook { get; set; }
        public byte[] fileOfBook { get; set; }
        public Nullable<double> ratingOfBook { get; set; }
    
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<UsersBook> UsersBooks { get; set; }
    }
}