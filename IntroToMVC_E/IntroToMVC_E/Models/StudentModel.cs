namespace IntroToMVC_E.Models
{
    public class StudentModel
    {
        public string? id { get; set; }
        public required string name { get; set; }
        public int? age { get; set; }
        public required float cgpa { get; set; }
        public string? phone { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
    }
}
