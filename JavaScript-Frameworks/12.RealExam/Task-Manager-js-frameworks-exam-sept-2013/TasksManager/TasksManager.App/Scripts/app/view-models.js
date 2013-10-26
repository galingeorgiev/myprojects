/// <reference path="../_references.js" />

window.viewModelsFactory = (function () {
    var data = null;

    // Login
    function getLoginViewModel() {
        var viewModel = {
            username: null,
            password: null,
            errMsg: "",
            login: function () {
                var self = this;
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    window.location.href = "#/appointments/all";
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            },
            register: function () {
                window.location.href = "#/register";
            }
        };

        return kendo.observable(viewModel);
    };

    // Register
    function getRegisterViewModel(successCallback) {
        var viewModel = {
            username: null,
            password: null,
            email: null,
            errMsg: "",
            register: function () {
                var self = this;
                var userData = {
                    username: this.get("username"),
                    authCode: this.get("password"),
                    email: this.get("email")
                }

                data.users.register(userData)
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        };

        return kendo.observable(viewModel);
    };

    // Logout
    function getLogoutViewModel() {
        var viewModel = {
            errMsg: "",
            logout: function () {
                var self = this;
                data.users.logout()
					.then(function () {
					    window.location.href = "#/home";
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        };

        return kendo.observable(viewModel);
    };

    // Public Main Page
    function getMainPageViewModel() {
        var viewModel = {
            home: function () {
                window.location.href = "#/home";
            },
            login: function () {

                window.location.href = "#/login";
            },
            register: function () {

                window.location.href = "#/register";
            }
        }

        return kendo.observable(viewModel);
    }





    // Get all appointments
    function getCreateApploinmentViewModel() {
        var viewModel = {
            subject: "",
            description: "",
            appointmentDate: "",
            duration: "",
            errMsg: "",
            create: function (e) {
                var self = this;
                var userData = {
                    subject: this.get("subject"),
                    description: this.get("description"),
                    appointmentDate: this.get("appointmentDate"),
                    duration: this.get("duration")
                };
                data.appointments.create(userData)
					.then(function () {
					    window.location.href = "#/appointments/all";
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        };

        return kendo.observable(viewModel);
    };

    function getCreateApploinmentByDateViewModel() {
        var viewModel = {
            day: "",
            month: "",
            year: "",
            errMsg: "",
            data: "",
            create: function (e) {
                var self = this;
                var userData = {
                    day: this.get("day"),
                    month: this.get("month"),
                    year: this.get("year")
                };
                data.appointments.byDate(userData.day, userData.month, userData.year)
					.then(function (appl) {
					    var other = self;
					    other.set('data', appl);
					},
                    function (err) {
                        console.log('here');
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        };

        return kendo.observable(viewModel);
    };

    // Get all appointments
    function getAllAppointmentsViewModel() {
        return data.appointments.all()
			.then(function (appointments) {
			    var viewModel = {
			        appointments: appointments,
			        errMsg: "",
			    };

			    return kendo.observable(viewModel);
			},
            function (err) {
                var self = this;
                self.set("errMsg", JSON.parse(err.responseText).Message);
                var other = self;
                setTimeout(function () {
                    other.set("errMsg", "");
                }, 5000);
            });
    }

    // Get comming appointments
    function getCommingAppointmentsViewModel() {
        return data.appointments.comming()
			.then(function (appointments) {
			    var viewModel = {
			        appointments: appointments,
			        errMsg: "",
			    };

			    return kendo.observable(viewModel);
			},
            function (err) {
                var self = this;
                self.set("errMsg", JSON.parse(err.responseText).Message);
                var other = self;
                setTimeout(function () {
                    other.set("errMsg", "");
                }, 5000);
            });
    }

    // Get current appointments
    function getCurrentAppointmentsViewModel() {
        return data.appointments.current()
			.then(function (appointments) {
			    var viewModel = {
			        appointments: appointments,
			        errMsg: "",
			    };

			    return kendo.observable(viewModel);
			},
            function (err) {
                var self = this;
                self.set("errMsg", JSON.parse(err.responseText).Message);
                var other = self;
                setTimeout(function () {
                    other.set("errMsg", "");
                }, 5000);
            });
    }

    // Get today appointments
    function getTodayAppointmentsViewModel() {
        return data.appointments.today()
			.then(function (appointments) {
			    var viewModel = {
			        appointments: appointments,
			        errMsg: "",
			    };

			    return kendo.observable(viewModel);
			},
            function (err) {
                var self = this;
                self.set("errMsg", JSON.parse(err.responseText).Message);
                var other = self;
                setTimeout(function () {
                    other.set("errMsg", "");
                }, 5000);
            });
    }

    // Get all todos
    function getAllTodosViewModel() {
        return data.todos.all()
			.then(function (todos) {
			    var viewModel = {
			        todos: todos,
			        errMsg: "",
			    };
			    
			    return kendo.observable(viewModel);
			},
            function (err) {
                var self = this;
                self.set("errMsg", JSON.parse(err.responseText).Message);
                var other = self;
                setTimeout(function () {
                    other.set("errMsg", "");
                }, 5000);
            });
    }

    // Get todos by Id
    function getTodosByIdViewModel(id) {
        return data.todos.byId(id)
			.then(function (todos) {
			    var viewModel = {
			        todos: todos.todos,
			        errMsg: "",
			    };

			    return kendo.observable(viewModel);
			},
            function (err) {
                var self = this;
                self.set("errMsg", JSON.parse(err.responseText).Message);
                var other = self;
                setTimeout(function () {
                    other.set("errMsg", "");
                }, 5000);
            });
    }

    // Create todo list
    function getCreateListViewModel(successCallback) {
        var viewModel = {
            title: null,
            errMsg: "",
            save: function () {
                var self = this;
                //var todoList = {
                //    title: self.get("title")
                //}

                data.todos.create(self.get("title"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        };

        return kendo.observable(viewModel);
    };

    // Create todo
    function getCreateTodoViewModel(id, successCallback) {
        var viewModel = {
            text: null,
            errMsg: "",
            save: function () {
                var self = this;
                //var todoList = {
                //    title: self.get("text")
                //}

                data.todos.createTodo(id, self.get("text"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        };

        return kendo.observable(viewModel);
    };


    function getMainMenuViewModel() {
        var viewModel = {
            errMsg: null,
            newAppontment: function () {
                window.location.href = "#/appointments/create";
            },
            allAppointments: function () {

                window.location.href = "#/appointments/all";
            },
            comming: function () {

                window.location.href = "#/appointments/comming";
            },
            byDate: function () {

                window.location.href = "#/appointments/bydate";
            },
            today: function () {

                window.location.href = "#/appointments/today";
            },
            current: function () {

                window.location.href = "#/appointments/current";
            },
            allTodos: function () {
                window.location.href = "#/todo-lists/all";
            },
            newTodo: function () {

                window.location.href = "#/todo-lists/create";
            },
            logout: function () {

                data.users.logout()
					.then(function () {
					    window.location.href = "#/appoinments/byDate";
					},
                    function (err) {
                        self.set("errMsg", JSON.parse(err.responseText).Message);
                        var other = self;
                        setTimeout(function () {
                            other.set("errMsg", "");
                        }, 5000);
                    });
            }
        }

        return kendo.observable(viewModel);
    }

    // Get todos by Id
    function getAppointmentsByDateViewModel() {
        return data.todos.byId(id)
			.then(function (todos) {
			    var viewModel = {
			        todos: todos.todos,
			        errMsg: "",
			    };

			    return kendo.observable(viewModel);
			},
            function (err) {
                var self = this;
                self.set("errMsg", JSON.parse(err.responseText).Message);
                var other = self;
                setTimeout(function () {
                    other.set("errMsg", "");
                }, 5000);
            });
    }

    return {
        getLoginVM: getLoginViewModel,
        getRegisterViewModel: getRegisterViewModel,
        getLogoutViewModel: getLogoutViewModel,
        getMainPageViewModel: getMainPageViewModel,
        getAllAppointmentsViewModel: getAllAppointmentsViewModel,
        getCommingAppointmentsViewModel: getCommingAppointmentsViewModel,
        getCurrentAppointmentsViewModel: getCurrentAppointmentsViewModel,
        getTodayAppointmentsViewModel: getTodayAppointmentsViewModel,
        getAllTodosViewModel: getAllTodosViewModel,
        getTodosByIdViewModel: getTodosByIdViewModel,
        getCreateListViewModel: getCreateListViewModel,
        getCreateTodoViewModel: getCreateTodoViewModel,
        getMainMenuViewModel: getMainMenuViewModel,
        getCreateApploinmentViewModel: getCreateApploinmentViewModel,
        getCreateApploinmentByDateViewModel: getCreateApploinmentByDateViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
}());