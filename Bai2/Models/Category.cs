using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thứ tự")]
        public int DisplayOrder { get; set; }
    }
}
