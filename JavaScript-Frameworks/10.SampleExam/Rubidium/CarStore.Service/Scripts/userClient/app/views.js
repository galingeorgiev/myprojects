/// <reference path="view-models.js" />
/// <reference path="templatesLoader.js" />
/// <reference path="../libs/_references.js" />

window.viewsFactory = (function() {

    function getAboutView() {
        return templateLoader.loadTemplate("aboutView");
    }

    function getLoginView() {
        return templateLoader.loadTemplate("login-form");
    }

    function getRegisterView() {
        return templateLoader.loadTemplate("register-form");
    }

    function getCarsView() {
        return templateLoader.loadTemplate("cars");
    }
    
    function getHomeView() {
        return templateLoader.loadTemplate("home");
    }
    
    function getCarView() {
        return templateLoader.loadTemplate("one-car-view");
    }

    function getStoresView() {
        return templateLoader.loadTemplate("stores");
    }
    
    function getStoreView() {
        return templateLoader.loadTemplate("one-store-view");
    }

    return {
        getLoginView: getLoginView,
        getRegisterView:getRegisterView,
        getHomeView: getHomeView,
        getCarsView: getCarsView,
        getOneCarView: getCarView,
        getStoresView: getStoresView,
        getStoreView: getStoreView,
        getAboutView: getAboutView
    };
}());