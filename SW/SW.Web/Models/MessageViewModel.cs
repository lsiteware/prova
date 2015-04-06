
namespace SW.Web.Models
{
    public class MessageViewModel
    {
        public MessageType Type { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public int Expires { get; set; }
    }
}