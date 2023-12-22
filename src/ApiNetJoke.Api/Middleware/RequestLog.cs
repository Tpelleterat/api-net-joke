namespace ApiNetJoke.Api.Middleware
{
    internal class RequestLog
    {
        public required string RequestMethod { get; set; }
        public required string RequestPath { get; set; }
        public required string QueryString { get; set; }
        public required int StatusCode { get; set; }
        public required string ResponseBody { get; set; }
    }
}
