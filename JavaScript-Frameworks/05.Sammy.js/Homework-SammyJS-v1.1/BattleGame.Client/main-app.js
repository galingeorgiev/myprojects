/// <reference path="Scripts/require.js" />
/// <reference path="AppScripts/ui.js" />
/// <reference path="AppScripts/persister.js" />
(function () {
    requirejs.config({
        paths: {
            jquery: 'Scripts/jquery-2.0.3',
            rsvp: 'Scripts/rsvp',
            mustache: 'Scripts/mustache',
            underscore: 'Scripts/underscore',
            sammy: 'Scripts/sammy-0.7.4',
            httpRequester: 'Scripts/http-requester',
            Class: 'Scripts/class',
            controller: 'AppScripts/controller',
            persister: 'AppScripts/persister',
            cryptoJS: 'http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1',
            ui: 'AppScripts/ui',
            validationControler: 'AppScripts/validation-controler'
        }
    });

    requirejs(['jquery', 'persister', 'controller', 'ui'], function ($, persister, controller, ui) {
        $(document).ready(function () {
            var myMainPersister = persister.mainPersister('http://localhost:22954/api');

            // Check is user logged in
            if (localStorage.getItem('authCode') == '' || localStorage.getItem('authCode') == null || localStorage.getItem('authCode') == undefined) {
                $('#login-container').html(ui.drawLogIn());
            }
            else {
                $('#login-container').html(ui.drawLoggedIn());
                $('#main-game-container').html(ui.drawUserInteraction());
                ui.drawSidebars(myMainPersister);
            }

            var int = self.setInterval(function () {
                if (localStorage.getItem('authCode') != '') {
                }
                else {
                    window.clearInterval(int);
                }
            }, 5000);

            // Adding events
            controller.addEvents(myMainPersister);
        });
    });
}());