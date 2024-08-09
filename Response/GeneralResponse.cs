namespace Cyrus_Technology_Task.Response
{
    public class GeneralResponse
    {
        public bool IsSuccess { get; set; }
        public dynamic? Data { get; set; }

        public string? Message { get; set; } = string.Empty;

        public int Status { get; set; }

        public string? Token { get; set; } = null;

        public DateTime? Expired { get; set; } = null;


    }
}
