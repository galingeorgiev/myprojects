/// <reference path="../_references.js" />
window.persisters = (function () {

    function saveUserData(userData) {
        localStorage.setItem("id", userData.id);
        localStorage.setItem("username", userData.username);
        localStorage.setItem("accessToken", userData.accessToken);
    }
    function clearUserData() {
        localStorage.removeItem("id");
        localStorage.removeItem("username");
        localStorage.removeItem("accessToken");
    }

    var Users = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        login: function (username, authCode) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(authCode).toString()
            };

            // api/users/login
            return httpRequester.postJSON(this.apiUrl + "auth/token", user)
				.then(function (data) {
				    saveUserData(data); // receive: accessToken, id, username
				});
        },
        register: function (userData) {
            var user = {
                username: userData.username,
                authCode: CryptoJS.SHA1(userData.authCode).toString(),
                email: userData.email,
            };

            // api/users/register
            return httpRequester.postJSON(this.apiUrl + "users/register", user)
				.then(function (data) {
				    //saveUserData(data); TODO: receive id and username
				});
        },
        logout: function () {
            if (!localStorage.getItem("accessToken")) {
                console.log('Missing Access Token.');
            }

            var logoutHeaders = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            // api/users/logout
            return httpRequester.putJSON(this.apiUrl + "users", "", logoutHeaders)
                .then(function () {
                    clearUserData();
                },
                function (err) {
                    console.log(err);
                });
        },
        currentUser: function () {
            return localStorage.getItem("accessToken");
        }
    });

    var Appointments = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        create: function (appointment) {
            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.postJSON(this.apiUrl, appointment, headers);
        },
        all: function () {
            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.getJSON(this.apiUrl + 'all', headers);
        },
        comming: function () {
            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.getJSON(this.apiUrl + 'comming', headers);
        },
        byDate: function (day, month, year) {
            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            var date = day + '-' + month + '-' + year;
            
            return httpRequester.getJSON(this.apiUrl + '?date=' + date, headers);
        },
        today: function () {
            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.getJSON(this.apiUrl + 'today', headers);
        },
        current: function () {
            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.getJSON(this.apiUrl + 'current', headers);
        }
    });

    var Todos = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        create: function (title) {
            var todoList = {
                title: title,
                todos: []
            };

            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.postJSON(this.apiUrl, todoList, headers);
        },
        createTodo: function (listId, text) {
            var todoList = {
                text: text
            };

            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.postJSON(this.apiUrl + listId + '/todos', todoList, headers);
        },
        all: function () {
            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.getJSON(this.apiUrl, headers);
        },
        byId: function (id) {
            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.getJSON(this.apiUrl + id + '/todos', headers);
        },
        changeStatus: function (id, isDode) {
            var todo = {
                isDone: isDode
            }

            var headers = {
                "X-accessToken": localStorage.getItem("accessToken")
            };

            return httpRequester.putJSON('/todos' + id, todo, headers);
        }
    });



    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new Users(apiUrl);
            this.appointments = new Appointments(apiUrl + 'appointments/');
            this.todos = new Todos(apiUrl + 'lists/');
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());