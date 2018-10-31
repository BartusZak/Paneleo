namespace Paneleo.API.Dtos
{
    public class UserForUpdateDto
    {
        public string knownAs { get; set; }
        public string Name { get; set; }
        public string Forename { get; set; }
        public string Password { get; set; }
        public string RepeatedPassword { get; set; }
    }
}