using System;
namespace web
{
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }

    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
