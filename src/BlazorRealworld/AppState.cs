using System;
using BlazorRealworld.Model;

namespace BlazorRealworld
{
    public class AppState
    {
        private readonly ApiClient api;

        public AppState(ApiClient api)
        {
            this.api = api;
            User = new UserModel();
        }

        public event Action OnUserChange;

        private void NotifyUserChanged() => OnUserChange?.Invoke();

        public ErrorsModel Errors { get; private set; }
        public UserModel User { get; private set; }

        public bool IsSignedIn => User?.token != null;

        public void UpdateUser(UserModel user)
        {
            User = user;
            var token = User?.token;

            if (token != null)
                api.SetToken(token);

            NotifyUserChanged();
        }
    }
}
