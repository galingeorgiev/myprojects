/// <reference path="jquery-2.0.2.js" />

var BullsAndCows = BullsAndCows || {};

BullsAndCows.ui = (function () {
    var generateLoginHtml = function () {
        return '<div id="register-container">'+
        '    <label for="register-username-input">Username: </label>'+
        '    <input type="text" id="register-username-input" />'+
        '    <label for="register-nickname-input">Nickname: </label>'+
        '    <input type="text" id="register-nickname-input" />'+
        '    <label for="register-password-input">Password: </label>'+
        '    <input type="password" id="register-password-input" />'+
        '    <button id="register-button">Register</button>'+
        '</div>'+
        '<div id="login-container" class="hidden">'+
        '    <label for="login-username-input">Username: </label>'+
        '    <input type="text" id="login-username-input" />'+
        '    <label for="login-password-input">Password: </label>'+
        '    <input type="password" id="login-password-input" />'+
        '    <button id="login-buton">Login</button>'+
        '</div>'
    }

    return {
        loginHtml: generateLoginHtml
    }
}());