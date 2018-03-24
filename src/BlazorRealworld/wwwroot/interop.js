Blazor.registerFunction('consoleLog', message => {
    console.log(message);
    return true;
});