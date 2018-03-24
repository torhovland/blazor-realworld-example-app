using System;

namespace BlazorRealworld
{
    public class AppState
    {
        public User User { get; set; }

        public bool IsSignedIn => User?.token != null;
    }
}
