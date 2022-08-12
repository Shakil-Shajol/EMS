namespace EMS.Client.Models
{
    public class ResponseDetail<T>
    {
        public T Data { get; set; } = default(T)!;
        public bool Success { get; set; }
        public Exception Exception { get; set; } = null!;
        public MessageType MessageType { get; set; }
        public int Count { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
