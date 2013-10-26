/// <reference path="../../HTMLs/user-loged-in.js" />
/// <reference path="../jquery-2.0.2.js" />
var BullsAndCows = BullsAndCows || {};

BullsAndCows.DrawUI = {
    drawLogIn: function (conatiner) {
        $(conatiner).load('login.html');
    },

    drawRegister: function (conatiner) {
        $(conatiner).load('register.html');
    },

    drawLogedIn: function (conatiner, name) {
        var logedInHtml = GenerateLogedIn(name);
        console.log(logedInHtml);
        $(conatiner).html(logedInHtml);
    }
};

BullsAndCows.DrawUI.drawLogedIn('#loged-in-conatiner', 'Pesho');