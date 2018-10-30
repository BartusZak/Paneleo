using System;

namespace Paneleo.API.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime LastActive { get; set; }
        public string Name { get; set; }
        public string Forname { get; set; }
    }
}