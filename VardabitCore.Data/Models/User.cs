using System.ComponentModel.DataAnnotations.Schema;
using VardabitCore.Common.EntityModel;

namespace VardabitCore.Data.Models
{
    [Table("User")]
    public class User : EntityBase
	{
        public string Email { get; set; }
        public string Password { get; set; }
    }
}