/// <reference path="ModelFactory.js" />
/// <reference path="../Scripts/jquery-2.0.3.js" />
/// <reference path="../Scripts/everlive.all.js" />
/// <reference path="../Scripts/sammy-0.7.4.js" />
/// <reference path="ui-templates.js" />
(function () {
    $(document).ready(function () {
        var el = new Everlive('PjSkuI87DgiWJomN');

        var app = Sammy('#wrapper', function () {
            this.get('#/', function () {
                $('#user-container').html(uiTemplates.drawLogIn());
                $('#posts-container').html('');
            });

            this.get('#/register', function () {
                $('#user-container').html(uiTemplates.drawRegister());
            });

            this.get('#/loggedin/:nickname', function () {
                var nickname = this.params['nickname'];
                $('#user-container').html(uiTemplates.drawLoggedIn(nickname));
            });

            this.get('#/home', function () {
                $('#user-container').html(uiTemplates.drawLoggedIn(localStorage.getItem('username')));
                $('#posts-container').html('');
            });

            // show posts
            this.get('#/posts', function () {
                $('#user-container').html(uiTemplates.drawLoggedIn(localStorage.getItem('username')));
                el.setup.token = localStorage.getItem('accessToken');
                el.data('Posts')
                    .get()
                    .then(function (data) {
                        console.log(data);
                        $('#posts-container').html(uiTemplates.drawAllPosts(data));
                        $("#accordion").accordion({
                            collapsible: true
                        });
                    });
            });

            // show post by Id
            this.get('#/post/:postId', function () {
                $('#user-container').html(uiTemplates.drawLoggedIn(localStorage.getItem('username')));
                var postId = this.params['postId'];
                el.setup.token = localStorage.getItem('accessToken');
                el.data('Posts')
                    .getById(postId)
                    .then(function (data) {
                        console.log(data);
                        $('#posts-container').html(uiTemplates.drawAllPosts(data));
                        $("#accordion").accordion({
                            collapsible: true
                        });
                    });
            });

            // comment post
            this.get('#/post/:postId/comment', function () {
                $('#user-container').html(uiTemplates.drawLoggedIn(localStorage.getItem('username')));
                var postId = this.params['postId'];
                el.setup.token = localStorage.getItem('accessToken');
                el.data('Posts')
                    .getById(postId)
                    .then(function (data) {
                        console.log(data);
                        $('#posts-container').html(uiTemplates.drawAllPosts(data));
                        $("#accordion").accordion({
                            collapsible: true
                        });
                    },
                    function (err) {
                        console.log(err);
                    });
            });
        });

        app.run('#/');

        // login
        $('#wrapper').on('click', '#button-log-in', function () {
            var username = $('#login-user-nickname').val();
            var password = $('#login-user-password').val();
            el.Users.login(username, password)
                .then(function (data) {
                    console.log(data);
                    console.log(el);
                    window.location = '#/loggedin/' + username;
                    localStorage.setItem('accessToken', data.result.access_token);
                    localStorage.setItem('username', username);
                },
                function (err) {
                    console.log(err)
                });
        });

        // register
        $('#wrapper').on('click', '#button-register', function () {
            var username = $('#register-user-nickname').val();
            var nickname = $('#register-user-nickname').val();
            var password = $('#register-user-password').val();
            var passwordRe = $('#register-user-password-re').val();

            if (password == passwordRe) {
                el.Users.register(username, password, { DispayName: nickname, Role: 'User' })
                .then(function (data) {
                    console.log(data);
                    window.location = '#/loggedin/' + username;
                    localStorage.setItem('username', username);
                },
                function (err) {
                    console.log(err)
                });
            }
            else {
                console.log('Wrong password.');
            }
        });

        // logout
        $('#wrapper').on('click', '#user-loged-in #button-logout', function () {
            el.setup.token = localStorage.getItem('accessToken');
            el.Users
                .logout()
                .then(
                function () {
                    window.location = '#/';
                    localStorage.setItem('accessToken', '')
                }
                , function (err) {
                    console.log(err);
                });
        });

        // show posts
        $('#wrapper').on('click', '#user-loged-in #button-show-comments', function () {
            window.location = '#/posts';
        });

        // comment post
        $('#wrapper').on('click', '#accordion div button', function () {
            var postId = $(this).attr('data-post-id');
            var commentText = $(this).siblings('input').val();
            //var comment = ModelFactory.comment(commentText, postId);
            $(this).siblings('input').val('');

            el.setup.token = localStorage.getItem('accessToken');
            el.data('Posts').getById(postId)
                .then(function (data) {
                    console.log(data);
                    var postContent = data.result.Comments.content;
                    console.log(postContent);

                    var newPostContent = [];

                    if (postContent) {
                        for (var i = 0; i < postContent.length; i++) {
                            newPostContent.push(postContent[i]);
                        }

                        console.log(newPostContent);
                    }

                    newPostContent.push(commentText);
                    
                    var comment = ModelFactory.comment(newPostContent, postId);

                    el.data('Posts')
                        .updateSingle({ Id: postId, Comments: comment })
                        .then(function () {
                            console.log(postId);
                            location.reload();
                            window.location = '#/post/' + postId;
                        },
                        function (err) {
                            console.log(err);
                        });
                },
                function (err) {
                    console.log(err);
                });
        });

        // show post by id
        $('#wrapper').on('click', '#accordion h3', function () {
            var postId = $(this).next('div').children('button').attr('data-post-id');
            window.location = '#/post/' + postId + '/comment';
        });

        $('#wrapper').on('click', '#user-loged-in #button-home', function () {
            window.location = '#/home';
        });
    });
}());