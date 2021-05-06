using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Onion.HospitalContract
{
    [Table("Hospital-onion")]
    public class Hospital
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("location")]
        [Range(0.0, 100.0)]
        public string Location { get; set; }
        [Required]
        [Column("head")]
        [Range(0.0, 100.0)]
        public string Head { get; set; }
        [Required]
        [Column("count")]
        public int Count { get; set; }
    }
}
