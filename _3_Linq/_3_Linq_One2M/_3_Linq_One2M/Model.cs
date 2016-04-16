using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Linq_One2M
{
    [Table("Type")]
    public class Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[MaxLength(8)]
        public double Price { get; set; }

        [Column("BrandName")]
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
