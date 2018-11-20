using System;

namespace Paneleo.Models.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string KnownAs { get; set; }
        public string Username { get; set; }
        public DateTime LastActive { get; set; }
        public string Name { get; set; }
        public string Forename { get; set; }
    }
}