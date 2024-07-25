using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace portfolioAPI.Models
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string Name { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; } = "";
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; } = "";

    }
}
