using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeLovers.Repo.Model
{
    [Table("ShoeSize")]
    public class ShoeSizeEntity : BaseEntity
    {
        public double Size { get; set; }
        public int GenderId { get; set; }
    }
}
