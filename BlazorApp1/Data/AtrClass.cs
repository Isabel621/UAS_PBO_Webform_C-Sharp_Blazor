using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlazorApp1.Data
{
    [Table("author", Schema = "public")]
    public class AtrClass
    {
        [Key]

        public int authorid { get; set; }

        public string nama { get; set; }

        public string email { get; set; }

    }
}