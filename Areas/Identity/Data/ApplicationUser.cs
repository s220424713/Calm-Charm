namespace ONP2023_Project.Areas.Identity.Data
{
    public class ApplicationUser
    {
        [key]
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }


    }
}