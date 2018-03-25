Blazor.registerFunction('consoleLog', (message) => {
    console.log(message);
    return true;
});

Blazor.registerFunction('saveToken', token => {
    window.localStorage.setItem('token', token);
    console.log("Authentication token has been stored.");
    return true;
});

Blazor.registerFunction('getStoredToken', () => {
    var token = window.localStorage.getItem('token');
    console.log(token ? "Autentication token read from storage." : "No authentication token found in storage.");
    return token;
});

Blazor.registerFunction('deleteStoredToken', () => {
    window.localStorage.removeItem('token');
    console.log("Authentication token has been deleted.");
    return true;
});
