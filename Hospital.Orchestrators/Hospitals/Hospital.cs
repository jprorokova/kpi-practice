using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Orchestrators.Hospitals
{
    [Table("Hospital-onion")]
    public class Hospital
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("address")]
        public string Address { get; set; }
        [Column("count")]
        public int Count { get; set; }
    }
}
