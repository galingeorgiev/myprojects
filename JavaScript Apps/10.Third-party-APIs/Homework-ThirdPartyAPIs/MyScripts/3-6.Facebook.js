/// <reference path="../Scripts/jquery-2.0.2.js" />
var token;
window.fbAsyncInit = function () {
    FB.init({
        appId: '513620688687046',
        channelUrl: '//http://localhost:51379/HTML/3-6.Facebook.html',
        status: true, // check login status
        cookie: true, // enable cookies to allow the server to access the session
        xfbml: true // parse XFBML
    });

    FB.login(function (response) {
        if (response.authResponse) {
            token = response.authResponse.accessToken;
            getProfileInfo();
            getFriends();
            $('#fbLogout').css("display", "inline-block");
        } else {
            console.log('User cancelled login or did not fully authorize.');
        }
    }, { scope: 'read_friendlists,user_photos, user_birthday, user_location' });
};

// Load the SDK asynchronously
(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement('script'); js.id = id; js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));


function getProfileInfo() {
    FB.api('/me', function (response) {
        var holder = $("#profile");
        var name = response.name;
        var birthday = response.birthday;
        //var location = response.location.name;
        var url = "https://graph.facebook.com/" + response.id + "/picture";
        holder.append($('<img />').attr('src', url))
        .append($('<p />').text(name))
        .append($('<p />').text('Born date: ' + birthday))
        .append($('<p />').text(location));
    });
    $("#log").css("display", "none");
}

function getFriends() {
    FB.api('/me/friends?access_token=' + token, function (response) {
        var friendsHolder = $('#friends');
        for (i = 0; i < response.data.length; i++) {
            var friendPictureUrl = 'https://graph.facebook.com/' + response.data[i].id + '/picture?width=200&height=200';
            var friendName = response.data[i].name;
            friendsHolder.append("<img src =" + friendPictureUrl + " title=" + friendName + "/>");
        }
        //photos();
    });
}

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=395337783908870";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

function fbLogout() {
    FB.logout(function (response) {
        $('#disconnect').hide('slow');
        $('#profile').hide('slow');
        $('#friends').hide('slow');
        $('#log').show();
        $('#fbLogout').css("display", "none");
        window.location.reload();
    });
}

$(document).ready(function () {

    setTimeout(function () {
        $('#wrapper #friends').on('click', 'img', function () {
            if ($(this).height() == 500) {
                $('#wrapper #friends img').removeAttr('style');
            }
            else {
                $('#wrapper #friends img').removeAttr('style');
                $(this).css({ 'width': '98%', 'height': '500px' });
            }
        });
    }, 3000);
}());