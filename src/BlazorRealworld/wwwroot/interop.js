Blazor.registerFunction('saveToken', token => {
    window.localStorage.setItem('jwt', token);
    console.log("Authentication token has been stored.");
    return true;
});