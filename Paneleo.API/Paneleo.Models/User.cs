using System;

namespace Paneleo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PaswordHash { get; set; }
        public byte[] PaswordSalt { get; set; }
        public DateTime LastActive { get; set; }
        public string KnownAs { get; set; }
        public string Name { get; set; }
        public string Forename { get; set; }
    }
}