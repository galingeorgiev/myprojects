function clickOnTheButton() {
    var myWindow = window;
    var browser = myWindow.navigator.appCodeName;
    var isMozilla = false;
    if (browser === "Mozilla") {
        isMozilla = true;
    }
    if (isMozilla) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}