using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorRealworld
{
    public class AppState
    {
        public SignedInUser User { get; set; }

        public bool IsSignedIn => User?.token != null;
    }

    public class SignedInUser
    {
        public string username { get; set; }
        public string token { get; set; }
    }
}
