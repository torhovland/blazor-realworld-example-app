using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRealworld
{
    public class AppState
    {
        public string Token { get; set; }

        public bool IsSignedIn => Token != null;
    }
}
