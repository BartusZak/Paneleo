using System;
using System.ComponentModel.DataAnnotations;

namespace Paneleo.Models.Model
{
    public class Entity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public User CreatedBy { get; set; }

        public Entity()
        {
            var now = DateTime.Now;
            CreatedAt = now;
            ModifiedAt = now;
        }

        public void SetModifiedDate()
        {
            ModifiedAt = DateTime.Now;
        }
    }
}