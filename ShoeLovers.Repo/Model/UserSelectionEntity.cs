using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoeLovers.Repo.Model
{
    [Table("UserSelection")]
    public class UserSelectionEntity 
    {
        public Guid UserId { get; set; }
        public int ShoeSizeId { get; set; }
    }
}
