namespace LyteChat.Server.Data.Models
{
    public class ErrorViewModel
    {
        public required string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
