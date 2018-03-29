using System;
using BlazorRealworld.Model;

namespace BlazorRealworld
{
    public class AppState
    {
        public event Action OnChange;
        public event Action OnUserLoaded;

        private UserModel _user;

        public AppState()
        {
            User = new UserModel();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
        private void NotifyUserLoaded() => OnUserLoaded?.Invoke();

        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                NotifyUserLoaded();
            }
        }

        public bool IsSignedIn => User?.token != null;
    }
}
