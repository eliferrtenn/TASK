using System.ComponentModel.DataAnnotations.Schema;
using VardabitCore.Common.EntityModel;

namespace VardabitCore.Data.Models
{
    [Table("Musteri")]
    public class Musteri : EntityBase
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
    }
}