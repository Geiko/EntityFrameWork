using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Linq_One2M
{
    [Table("TradeMark")]
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Column("Manufacturer Country")]
        public string Country { get; set; }

        public virtual ICollection<Model> Models{ get; set; }
        public Brand ( )
        {
            Models = new List<Model>();
        }
        public override string ToString ( )
        {
            return Name;
        }
    }
}
