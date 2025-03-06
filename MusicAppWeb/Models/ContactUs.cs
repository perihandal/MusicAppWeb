namespace MusicAppWeb.Models
{
    public class ContactUs:BaseEntity
    {
        public string Name { get; set; }
        public string Mail{ get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
