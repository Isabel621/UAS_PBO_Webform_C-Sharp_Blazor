using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace BlazorApp1.Data
{
    [Table("mtrtable", Schema = "public")]
    public class MtrClass
    {
        [Key]

        public int kontenid { get; set; }   

        public string kelas { get; set; }

        public string materi { get; set; }

        public string penjelasan { get; set; }  
    }
}
