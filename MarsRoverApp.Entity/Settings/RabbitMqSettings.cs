using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Entity.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public class RabbitMqSettings
    {
        public string Host { get; set; }
        public string VirtualHost { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
