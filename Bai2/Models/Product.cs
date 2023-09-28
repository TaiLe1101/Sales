using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Models
{
    //944/1
    public class Product
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public string Name { set; get; }

        public string Description { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        public double Price { set; get; }

        [ForeignKey("CategoryId")]
        public int CategoryId { set; get; }

        public Category Category { set; get; } //khai báo thuộc tính mối kết hợp

        public string ImageUrl { set; get; }
    }
}
