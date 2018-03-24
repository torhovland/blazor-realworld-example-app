using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRealworld
{
    public class AppState
    {
        public User User { get; set; }

        public bool IsSignedIn => User?.token != null;
    }

    public class User
    {
        public string username { get; set; }
        public string token { get; set; }
    }
}
