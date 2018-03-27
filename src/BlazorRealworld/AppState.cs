using System;
using System.Threading.Tasks;
using BlazorRealworld.Model;

namespace BlazorRealworld
{
    public class AppState
    {
        public AppState()
        {
            User = new UserModel();
        }

        public UserModel User { get; set; }

        public bool IsSignedIn => User?.token != null;

        public async Task UntilUserSetAsync()
        {
            while (User.token == null)
                await Task.Delay(1);
        }
    }
}
