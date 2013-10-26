/// <reference path="Scripts/_references.js" />

(function () {
    var mainLayoutHtml = '<div id="header"></div><div id="main-container"></div><div id="transaction-logs"></div><div id="footer"></div>';
    var appLayout = new kendo.Layout(mainLayoutHtml);

    var data = persisters.get("api/");
    viewModelsFactory.setPersister(data);

    var router = new kendo.Router();

    router.route("/", function () {
        router.navigate('/login');
    });

    // build Menu on pages
    var buildMenu = (function () {
        viewsFactory.getMainMenuView()
			.then(function (menuViewHtml) {
			    var mainVM = viewModelsFactory.getMainMenuViewModel();

			    var view = new kendo.View(menuViewHtml, { model: mainVM });
			    appLayout.showIn("#header", view);
			    $("#menu").kendoMenu();
			});
    });

    // login
    router.route("/login", function () {
        $('#header').html('');
        viewsFactory.getLoginView()
        .then(function (loginViewHtml) {
            var mainVM = viewModelsFactory.getLoginVM();

            var view = new kendo.View(loginViewHtml, { model: mainVM });
            appLayout.showIn("#main-container", view);
        });
    });

    // api/users/register
    router.route("/register", function () {
        if (!data.users.currentUser()) {
            viewsFactory.getRegisterView()
            .then(function (registerViewHtml) {
                var mainVM = viewModelsFactory.getRegisterViewModel(function () {
                    router.navigate('/appointments/all');
                });

                var view = new kendo.View(registerViewHtml, { model: mainVM });
                appLayout.showIn("#main-container", view);
            });
        }
        else {
            router.navigate("/login");
        }
    });

    // api/appointments/create
    router.route("/appointments/create", function () {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.geCreateAppointmentView()
            .then(function (createAppointmentsViewHtml) {
                var mainVM = viewModelsFactory.getCreateApploinmentViewModel();
                var view = new kendo.View(createAppointmentsViewHtml, { model: mainVM });
                appLayout.showIn("#main-container", view);
            });
        }
        else {
            router.navigate("/login");
        }
    });

    // api/appointments/all
    router.route("/appointments/all", function () {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.getAllAppointmentsView()
            .then(function (allAppointmentsViewHtml) {
                viewModelsFactory.getAllAppointmentsViewModel().then(function (mainVM) {
                    var view = new kendo.View(allAppointmentsViewHtml, { model: mainVM });
                    appLayout.showIn("#main-container", view);
                },
                function (err) {
                    console.log(err);
                });
            });
        }
        else {
            router.navigate("/login");
        }
    });

    // api/appointments/comming
    router.route("/appointments/comming", function () {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.getCommingAppointmentsView()
            .then(function (commingAppointmentsViewHtml) {
                viewModelsFactory.getCommingAppointmentsViewModel().then(function (mainVM) {
                    var view = new kendo.View(commingAppointmentsViewHtml, { model: mainVM });
                    appLayout.showIn("#main-container", view);
                },
                function (err) {
                    console.log(err);
                });
            });
        }
        else {
            router.navigate("/login");
        }
    });

    // api/appointments/current
    router.route("/appointments/current", function () {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.getCurrentAppointmentsView()
            .then(function (currentAppointmentsViewHtml) {
                viewModelsFactory.getCurrentAppointmentsViewModel().then(function (mainVM) {
                    var view = new kendo.View(currentAppointmentsViewHtml, { model: mainVM });
                    appLayout.showIn("#main-container", view);
                },
                function (err) {
                    console.log(err);
                });
            });
        }
        else {
            router.navigate("/login");
        }
    });

    // api/appointments/today
    router.route("/appointments/today", function () {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.getTodayAppointmentsView()
            .then(function (todayAppointmentsViewHtml) {
                viewModelsFactory.getTodayAppointmentsViewModel().then(function (mainVM) {
                    var view = new kendo.View(todayAppointmentsViewHtml, { model: mainVM });
                    appLayout.showIn("#main-container", view);
                },
                function (err) {
                    console.log(err);
                });
            });
        }
        else {
            router.navigate("/login");
        }
    });

    // api/appointments/bydate
    router.route("/appointments/bydate", function () {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.getAppointmentByDateView()
            .then(function (todayAppointmentsViewHtml) {
                var mainVM = viewModelsFactory.getCreateApploinmentByDateViewModel();
                var view = new kendo.View(todayAppointmentsViewHtml, { model: mainVM });
                appLayout.showIn("#main-container", view);
            });
        }
        else {
            router.navigate("/login");
        }
    });

    // Show all todos
    router.route("/todo-lists/all", function () {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.getTotoListAllView()
            .then(function (allTodosViewHtml) {
                viewModelsFactory.getAllTodosViewModel().then(function (mainVM) {
                    //debugger;
                    var view = new kendo.View(allTodosViewHtml, { model: mainVM });
                    appLayout.showIn("#main-container", view);
                },
                function (err) {
                    console.log(err);
                });
            });
        }
        else {
            router.navigate("/login");
        }
    });

    // Show todos by Id
    router.route("/todo-lists/:id/todos/show", function (id) {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.getTotoListByIdView()
            .then(function (allTodosViewHtml) {
                viewModelsFactory.getTodosByIdViewModel(id).then(function (mainVM) {

                    var view = new kendo.View(allTodosViewHtml, { model: mainVM });
                    appLayout.showIn("#main-container", view);
                },
                function (err) {
                    console.log(err);
                });
            });
        }
        else {
            router.navigate("/login");
        }
    });

    // Create new todo list
    router.route("/todo-lists/create", function () {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.getTotoListCreateView()
            .then(function (registerViewHtml) {
                var mainVM = viewModelsFactory.getCreateListViewModel(function () {
                    router.navigate('/login');
                    $("#main-container").text('Todo list is created');
                    setTimeout(function () {
                        router.navigate('/todo-lists/all');
                    }, 3000);
                });

                var view = new kendo.View(registerViewHtml, { model: mainVM });
                appLayout.showIn("#main-container", view);
            });
        }
        else {
            router.navigate("/login");
        }
    });

    router.route("/todo-lists/:id/create/todo", function (id) {
        if (data.users.currentUser()) {
            buildMenu();
            viewsFactory.getTotoCreateView()
            .then(function (registerViewHtml) {
                var mainVM = viewModelsFactory.getCreateTodoViewModel(id, function () {

                    $("#main-container").text('Todo list is created');
                    setTimeout(function () {
                        router.navigate('/todo-lists/all');
                    }, 3000);
                });

                var view = new kendo.View(registerViewHtml, { model: mainVM });
                appLayout.showIn("#main-container", view);
            });
        }
        else {
            router.navigate("/login");
        }
    });

    $(function () {
        appLayout.render("#wrapper");
        router.start();
    });
}());