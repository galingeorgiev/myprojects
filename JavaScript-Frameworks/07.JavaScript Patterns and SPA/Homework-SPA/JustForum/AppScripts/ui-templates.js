var uiTemplates = function () {
    function drawLogInForm() {
        return '<fieldset id="login-user-container">' +
                    '<legend>Log In</legend>' +
                    '<label for="login-user-nickname">Nickname</label>' +
                    '<input id="login-user-nickname" type="text" name="name" value="" placeholder="Enter your nickname" autofocus="true" />' +
                    '<label for="login-user-password">Password</label>' +
                    '<input id="login-user-password" type="password" name="name" value="" placeholder="Enter your password" />' +
                    '<button id="button-log-in">Log In</button>' +
                    '<a id="register-now" href="#/register">Register now</a>' +
                '</fieldset>';
    }

    function drawRegisterForm() {
        return '<fieldset id="register-user-container">' +
                    '<legend>Register</legend>' +
                    '<label for="register-user-name">Name</label>' +
                    '<input id="register-user-name" type="text" name="name" value="" placeholder="Enter your first and last name" autofocus="true" />' +
                    '<label for="register-user-nickname">Nickname</label>' +
                    '<input id="register-user-nickname" type="text" name="name" value="" placeholder="Enter your nickname" />' +
                    '<label for="register-user-password">Password</label>' +
                    '<input id="register-user-password" type="password" name="name" value="" placeholder="Enter your password" />' +
                    '<label for="register-user-password-re">Password</label>' +
                    '<input id="register-user-password-re" type="password" name="name" value="" placeholder="Confirm your password" />' +
                    '<a id="back-to-homepage" href="#/" >Back</a>' +
                    '<button id="button-register">Register</button>' +
                '</fieldset>';
    }

    function drawLoggedInForm(username) {
        return '<div id="user-loged-in">' +
                    '<p id="greetings">Hello, ' + username + '</p>' +
                    '<button id="button-logout">Log out</button>' +
                    '<button id="button-home">Home</button>' +
                    '<button id="button-show-comments">Show posts</button>' +
                '</div>';
    }

    function drawAllPostsForm(data) {
        
        var template = '<div id="accordion">' +
            '{{#result}}' +
                '<h3>{{Title}}</h3>' +
                '<div>' +
                    '<p>{{Content}}</p>' +
                    '<p>Tags: {{#Tags}} {{.}} {{/Tags}}{{^Tags}}No tags found for this post.{{/Tags}}</p>' +
                    '<ul>' +
                        '{{#Comments}}<li>{{#content}}<li>{{.}}</li>{{/content}}{{/Comments}}{{^Comments}}<li>No comments for this post.</li>{{/Comments}}' +
                    '</ul>' +
                    '<input type="text" name="name" value="" placeholder="Enter comment here" />' +
                    '<button data-post-id="{{Id}}">Comment</button>' +
                '</div>' +
            '{{/result}}' +
        '</div>';

        var output = Mustache.render(template, data);
        return output;
    }

    return {
        drawLogIn: drawLogInForm,
        drawRegister: drawRegisterForm,
        drawLoggedIn: drawLoggedInForm,
        drawAllPosts: drawAllPostsForm
    }
}();