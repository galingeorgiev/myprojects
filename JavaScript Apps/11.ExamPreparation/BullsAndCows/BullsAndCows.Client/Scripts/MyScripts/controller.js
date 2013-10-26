/// <reference path="Class.js" />
/// <reference path="../jquery-2.0.2.js" />
/// <reference path="persister.js" />
/// <reference path="ui.js" />

$(document).ready(function () {
    var myMainPersister = persister.mainPersister('http://localhost:40643/api');
    //var myMainPersister = persister.mainPersister('http://bullsandcows.apphb.com/api');
    ui.addEvents(myMainPersister);
    //myMainPersister.user.logout();
    //myMainPersister.user.login('lidia', '12345');
    var sesionKey = localStorage.getItem('authCode');
    
    // Check is user logged in
    
    if (localStorage.getItem('authCode') == '' || localStorage.getItem('authCode') == null || localStorage.getItem('authCode') == undefined) {
        $('#login-container').html(ui.drawLogIn());
    }
    else {
        $('#login-container').html(ui.drawLoggedIn());
        ui.drawSidebars(myMainPersister);
        $('#make-guess').html(ui.drawUserInteraction());
    }

    var int = self.setInterval(function () {
        if (localStorage.getItem('authCode') != '') {
            ui.drawSidebars(myMainPersister);
        }
        else {
            window.clearInterval(int);
        }
    }, 5000);
});