/// <reference path="Scripts/_references.js" />

(function () {
    var mainLayoutHtml = '<div id="header"></div><div id="main-container"></div><div id="transaction-logs"></div><div id="footer"></div>';
    var appLayout = new kendo.Layout(mainLayoutHtml);

    var data = persisters.get("api/");
    viewModelsFactory.setPersister(data);

    var router = new kendo.Router();

    // build Menu on pages
    var buildMenu = (function () {
        viewsFactory.getPublicMenuView()
				.then(function (menuViewHtml) {
				    var mainVM = viewModelsFactory.getMainPageViewModel();

				    var view = new kendo.View(menuViewHtml,
						{ model: mainVM });
				    appLayout.showIn("#header", view);
				    $("#menu").kendoMenu();
				});
    });

    var userMenu = [];

    // check if user is admin
    var checkAdmin = function () {
        if (data.users.currentUserRole() !== "Admin") {
            $("#admin").css('display', 'none');
        }
    };

    function clearTransactionsContainer() {
        $('#transaction-logs').html('');
    };

    var checkForMenu = (function myfunction() {
        if ($("#menu").children().length <= 0) {
            return true;
        }

        return false;
    })


    var buildUserMenu = (function () {

        viewsFactory.getUserMenuView()
				.then(function (menuViewHtml) {
				    var mainVM = viewModelsFactory.getUserPageViewModel();

				    var view = new kendo.View(menuViewHtml,
						{ model: mainVM });
				    appLayout.showIn("#header", view);
				    userMenu = $("#menu").kendoMenu();
				    checkAdmin();
				});
    });

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

    //only for registered users
    router.route("/special", function () {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
    });

    //empty #
    router.route("/", function () {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {

            router.navigate("/home");
        }
        else {
            router.navigate("/accounts");
        }
    });

    //home
    router.route("/home", function () {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {
            buildMenu();

            viewsFactory.getHomeView()
				.then(function (homeViewHtml) {
				    var mainVM = viewModelsFactory.getHomeViewModel();

				    var view = new kendo.View(homeViewHtml,
						{ model: mainVM });
				    appLayout.showIn("#main-container", view);
				});

        }
        else {
            router.navigate("/accounts");
        }
    });

    //Profile
    router.route("/profile", function () {
        clearTransactionsContainer();
        if (data.users.currentUser()) {
            buildUserMenu();

            viewsFactory.getProfileView()
				.then(function (profileViewHtml) {
				    viewModelsFactory.getUserProfileViewModel().then(function (mainVM) {
				        var view = new kendo.View(profileViewHtml,
                                    { model: mainVM });
				        appLayout.showIn("#main-container", view);
				    })

				});

        }
        else {
            router.navigate("/login");
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

    // api/accounts
    router.route("/accounts", function () {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {
            if (checkForMenu()) {
                buildUserMenu();
            }
            else {
                if ($("#bank-menu-public").children().length > 0) {
                    buildUserMenu();
                }
            }

            checkAdmin();

            viewsFactory.getAccountView()
			.then(function (accountsViewHtml) {
			    viewModelsFactory.getAllAccountsViewModel()
				.then(function (vm) {
				    var view =
						new kendo.View(accountsViewHtml,
						{ model: vm });

				    //console.log(vm);
				    appLayout.showIn("#main-container", view);
				}, function (err) {
				    console.log(err);
				    //...
				});
			},
            function (err) {
                console.log(err);
            });
        }
    });

    // api/accounts
    router.route("/accounts/create", function () {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {
            if (checkForMenu()) {
                buildUserMenu();
            }
            else {
                if ($("#bank-menu-public").children().length > 0) {
                    buildUserMenu();
                }
            }

            viewsFactory.getCreateAccountView()
				.then(function (createAccountViewHtml) {

				    viewModelsFactory.getCreateAccountViewModel()
				    .then(function (mainVM) {
				        var view = new kendo.View(createAccountViewHtml,
                            { model: mainVM });
				        appLayout.showIn("#main-container", view);
				    });
				});
        }
    });

    // api/accounts/:id
    router.route("/accounts/:id", function (id) {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {

            if (checkForMenu()) {
                buildUserMenu();
            }

            viewsFactory.getAccountDetailsView()
                .then(function (accountDetailsViewHtml) {
                    viewModelsFactory.getAccountDetailsViewModel(id)
                .then(function (vmDetails) {
                    viewsFactory.getTransactionsView().then(function (transactionsViewHtml) {
                        viewModelsFactory.getAccountTransactionsViewModel(id)
                        .then(function (vmTransactions) {
                            var view =
                                    new kendo.View(accountDetailsViewHtml,
                                    { model: vmDetails });

                            var viewTransactions =
                            new kendo.View(transactionsViewHtml,
                                { model: vmTransactions });

                            appLayout.showIn("#main-container", view);
                            appLayout.showIn("#transaction-logs", viewTransactions);
                        }, function (err) {
                            console.log(err);
                            //...
                        });
                    },
                    function (err) {
                        console.log(err);
                    });
                })
                })
        }
    });


    // Transfer
    router.route("/transfer", function () {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {
            if (checkForMenu()) {
                buildUserMenu();
            }
            else {
                if ($("#bank-menu-public").children().length > 0) {
                    buildUserMenu();
                }
            }

            viewsFactory.getTransferView()
                .then(function (transferViewHtml) {
                    viewModelsFactory.getTransferViewModel()
                    .then(function (vm) {
                        var view =
                            new kendo.View(transferViewHtml,
                            { model: vm });


                        appLayout.showIn("#main-container", view);
                        $("#panelbar").kendoPanelBar({
                            animation: {
                                open: { effects: "fadeIn" }
                            }, expandMode: "single"
                        });
                    }, function (err) {
                        console.log(err);
                    });
                },
                function (err) {
                    console.log(err);
                });
        }
    });

    // Transfer is OK
    router.route("/accounts/transfer/success", function (id) {
        $('#main-container').html('Transfer is successful!');

        setTimeout(function () {
            $('#main-container').html("");
            router.navigate("/accounts");
        }, 3000);
    });

    // api/accounts/:id/transfer
    router.route("/accounts/:id/transfer", function (id) {
        clearTransactionsContainer();
        if (!data.users.currentUser()) {
            router.navigate("/login");
        }
        else {
            if (checkForMenu()) {
                buildUserMenu();
            }
            else {
                if ($("#bank-menu-public").children().length > 0) {
                    buildUserMenu();
                }
            }

            viewsFactory.getTransferFromCurrentAccountView()
                .then(function (transferViewHtml) {

                    viewModelsFactory.getTransferFromCurrentAccountViewModel(id)
                    .then(function (vm) {
                        var view =
                            new kendo.View(transferViewHtml,
                            { model: vm });

                        appLayout.showIn("#main-container", view);
                        $("#panelbar-current-account").kendoPanelBar({
                            animation: {
                                open: { effects: "fadeIn" }
                            }, expandMode: "single"
                        });
                    }, function (err) {
                        console.log(err);
                        //...
                    });
                },
                function (err) {
                    console.log(err);
                });
        }
    });

    // api/calculator
    router.route("/calculator", function () {
        clearTransactionsContainer();
    });

    $(function () {
        appLayout.render("#wrapper");
        router.start();
    });
}());