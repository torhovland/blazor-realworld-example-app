using System;
using BlazorRealworld.Model;

namespace BlazorRealworld
{
    public class AppState
    {
        public UserModel User { get; set; }

        public bool IsSignedIn => User?.token != null;
    }
}
