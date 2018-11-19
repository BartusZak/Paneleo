using System;
using System.ComponentModel.DataAnnotations;

namespace Paneleo.API.Models.Model
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

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