using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Orchestrators.Patient
{
    [Table("Patient")]
    public class Patient
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("surname")]
        public string SurName { get; set; }
        [Required]
        [Column("birthday")]
        public string Birthday { get; set; }
        [Required]
        [Column("sum")]
        public int Sum { get; set; }
    }
}
