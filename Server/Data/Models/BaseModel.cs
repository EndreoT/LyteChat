using System;

namespace LyteChat.Server.Data.Models
{
    public abstract class BaseModel
    {
        public Guid Uuid { get; set; }

        public BaseModel()
        {
            Uuid = Guid.NewGuid();
        }
    }
}
