using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Services.MembaAPI.Models
{
    public class Error
    {
        public int ErrorId { get; set; }
        public object ErrorHeader { get; set; }
        public string ErrorMessage { get; set; }
    }
}
