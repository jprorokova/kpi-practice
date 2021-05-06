using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Data.Hospitals
{
    [Table("Hospital-onion")]
    public class Hospital
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("address")]
        [Range(0.0, 1000.0)]
        public string Address { get; set; }
        
        [Column("count")]
        public int Count { get; set; }
    }
}
