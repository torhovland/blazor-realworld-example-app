Blazor.registerFunction('saveToken', token => {
    window.localStorage.setItem('jwt', token);
    console.log("Authentication token has been stored.");
    return true;
});

Blazor.registerFunction('getStoredToken', () => {
    var token = window.localStorage.getItem('jwt');
    console.log(token ? "Autentication token read from storage." : "No authentication token found in storage.");
    return token;
});

Blazor.registerFunction('deleteStoredToken', () => {
    window.localStorage.removeItem('jwt');
    console.log("Authentication token has been deleted.");
    return true;
});

Blazor.registerFunction('showRawHtml', (elementId, html) => {
    var el = document.getElementById(elementId);
    el.innerHTML = html;
    return true;
});
