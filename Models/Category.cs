using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    [Table("Category")]
    public class Category
    {
        [Column("CategoryId")]
        public byte Id { get; set; }
        [Column("CategoryName")]
        public string Name { get; set; } 

        //self Join
        public byte? ParentId { get; set; }
        public Category Parent { get; set; }

        public List<Category> Children { get; set; }
        public List<Product> Products { get; set; }

    }
}