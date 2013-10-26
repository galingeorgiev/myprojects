/// <reference path="libs/_references.js" />
/// <reference path="../userClient/app/views.js" />
/// <reference path="../userClient/app/view-models.js" />

(function () {

    /* Routes */

    //passing parameters router.route("/:id", function() { ... })
    //getting parameters router.route("/", function(id) { ... }) 

    var dataPersister = persisters.getPersister("/api/");

    var appLayout =
        new kendo.Layout('<div id="main-content"></div>');

    var router = new kendo.Router();

    

    
    router.route("/UserIndex.html", function () {
        if (!dataPersister.isUserLoggedIn()) {
            $("#btn-logout").addClass("hidden");
        };
        router.navigate("/login");
    });

    router.route("/home", function () {
        if (dataPersister.isUserLoggedIn()) {
            $("#btn-logout").addClass("hidden");
        }
        viewsFactory.getHomeView() // getting html template here
            .then(function (homeViewHtml) {
                var view = new kendo.View(homeViewHtml);
                appLayout.showIn("#main-content", view);

            }, function (err) {
                //TODO
            });
    });

    router.route("/login", function () {
        if (dataPersister.isUserLoggedIn()) {
            router.navigate("/cars");
            $("#btn-logout").removeClass("hidden");
        } else {
            viewsFactory.getLoginView() // getting html template here
                .then(function (loginViewHtml) {
                    var loginViewModel = viewModelsFactory.getLoginViewModel(function () {
                        router.navigate("/cars");
                        $("#btn-logout").removeClass("hidden");
                    }); //data model

                    $("#main-content").empty();
                    var view = new kendo.View(loginViewHtml, { model: loginViewModel }); //view 
                    appLayout.showIn("#main-content", view);
                });
        }
    });

    router.route("/logout", function () {
        dataPersister.users.logout().then(function () {
            $("#main-content").empty();
            $("#btn-logout").addClass("hidden");
            router.navigate("/about");
        });

    });

    router.route("/register", function () {
        viewsFactory.getRegisterView() // getting html template here
            .then(function (registerViewHtml) {
                var registerViewModel = viewModelsFactory.getRegisterViewModel(function () {
                    router.navigate("/cars");
                }); //data model
                $("#btn-logout").removeClass("hidden");
                var view = new kendo.View(registerViewHtml, { model: registerViewModel }); //view 
                appLayout.showIn("#main-content", view);
            });
    });

    router.route("/special", function () {
        //if (!dataPersister.isUserLoggedIn()) {
        //    router.navigate("/login");
        //}
    });

    router.route("/cars", function () {
        if (dataPersister.isUserLoggedIn()) {
            $("#btn-logout").removeClass("hidden");
        }
        viewsFactory.getCarsView()
            .then(function (carsViewHtml) {
                viewModelsFactory.getCarsViewModel()
                    .then(function (carViewModel) {
                        //kendo.bind($("#cars-container"), carViewModel);
                        var view = new kendo.View(carsViewHtml, { model: carViewModel });
                        $("#main-content").empty();
                        appLayout.showIn("#main-content", view);
                    }, function (err) {
                        console.log(err);
                    });
            });
    });

    router.route("/about", function () {
        if (dataPersister.isUserLoggedIn()) {
            $("#btn-logout").removeClass("hidden");
        }
        viewsFactory.getAboutView()
            .then(function (AboutViewHTML) {
                $("#main-content").empty(),
                $("#main-content").html(AboutViewHTML)
            }
        );
    });

    router.route("/cars/:id", function (id) {
        if (dataPersister.isUserLoggedIn()) {
            $("#btn-logout").removeClass("hidden");
        }
        viewsFactory.getOneCarView()
            .then(function (carViewHtml) {
                viewModelsFactory.getCarViewById(id)
                    .then(function (carData) {
                        var view = new kendo.View(carViewHtml, { model: carData });
                        appLayout.showIn("#main-content", view);
                        viewModelsFactory.datePicker();
                    }, function (err) {
                        console.log(err);
                    });
            });

    });

    router.route("/stores", function () {
        if (dataPersister.isUserLoggedIn()) {
            $("#btn-logout").removeClass("hidden");
        }
        viewsFactory.getStoresView()
            .then(function (storeHtml) {
                viewModelsFactory.getStoresViewModel()
                    .then(function (storeViewModel) {
                        var view1 = new kendo.View(storeHtml, { model: storeViewModel });
                        $("#main-content").empty();
                        appLayout.showIn("#main-content", view1);
                    }, function (err) {
                        console.log(err);
                    });
            });
    });

    router.route("/stores/:id", function (id) {
        //if (dataPersister.isUserLoggedIn()) {
        //    $(".logout").removeClass("hidden");
        //}
        viewsFactory.getStoreView()
            .then(function (storeViewHtml) {
                viewModelsFactory.getStoreViewById(id)
                    .then(function (storeData) {
                        var view = new kendo.View(storeViewHtml, { model: storeData });
                        appLayout.showIn("#main-content", view);
                    }, function (err) {
                        console.log(err);
                    });
            });
    });

    $(function () {
        appLayout.render("#app");
        router.start();
    });
}());