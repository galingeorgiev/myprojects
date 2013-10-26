/// <reference path="Scripts/_references.js" />

(function () {
    var mainLayoutHtml = '<div id="header"></div><div id="main-container"></div><div id="transaction-logs"></div><div id="footer"></div>';
    var appLayout = new kendo.Layout(mainLayoutHtml);

    var data = persisters.get("api/");
    viewModelsFactory.setPersister(data);

    var router = new kendo.Router();

    router.route("/login", function () {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {
            if (checkForMenu()) {
                buildMenu();
            }

            viewsFactory.getLoginView()
            .then(function (loginViewHtml) {
                var mainVM = viewModelsFactory.getLoginVM();

                var view = new kendo.View(loginViewHtml,
                                          { model: mainVM });
                appLayout.showIn("#main-container", view);
            });
        }
        else {
            router.navigate("/accounts");
        }
    });

    // api/users/register
    router.route("/register", function () {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {
            if (checkForMenu()) {
                buildMenu();
            }

            viewsFactory.getRegisterView()
            .then(function (registerViewHtml) {
                var mainVM = viewModelsFactory.getRegisterViewModel();

                var view = new kendo.View(registerViewHtml,
                                          { model: mainVM });
                appLayout.showIn("#main-container", view);
            });
        }
        else {
            router.navigate("/accounts");
        }
    });

    $(function () {
        appLayout.render("#wrapper");
        router.start();
    });
}());