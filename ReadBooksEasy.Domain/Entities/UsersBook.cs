using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReadBooksEasy.Domain.Entities
{
    public class UsersBook
    {
        [Key]
        [Column(Order = 0)]
        public int IdUsers { get; set; }
        [Key]
        [Column(Order = 1)]
        public int idBooks { get; set; }
        public Nullable<bool> usingFieldRating { get; set; }
        public Nullable<double> ratingForBook { get; set; }

        public virtual Book Book { get; set; }
    }
}
