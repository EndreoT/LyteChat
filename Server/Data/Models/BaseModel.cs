using System;
using System.ComponentModel.DataAnnotations;

namespace LyteChat.Server.Data.Models
{
    public abstract class BaseModel
    {
        public Guid Uuid { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        public BaseModel()
        {
            Uuid = Guid.NewGuid();
            CreatedOn = DateTime.Now;
        }
    }
}
