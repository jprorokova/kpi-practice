using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Data.Patients
{
    [Table("Patient")]
    public class Patient
    {
        [Required]
        [Column("id")]
        [Range(0.0, 1000.0)]
        public int Id { get; set; }
        [Required]
        [Column("name")]
      
        public string Name { get; set; }
        [Required]
        [Column("surname")]
        
        public string SurName { get; set; }
        [Required]
        [Column("birthday")]

        public System.DateTime Birthday { get; set; }
       
      
        [Required]
        [Column("sum")]
        public int Sum { get; set; }
    }
}
