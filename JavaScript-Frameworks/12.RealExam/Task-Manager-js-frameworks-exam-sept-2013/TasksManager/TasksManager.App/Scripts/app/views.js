/// <reference path="../_references.js" />

window.viewsFactory = (function () {
    var rootUrl = "Scripts/partials/";

    var templates = {};

    function getTemplate(name) {
        var promise = new RSVP.Promise(function (resolve, reject) {
            if (templates[name]) {
                resolve(templates[name])
            }
            else {
                $.ajax({
                    url: rootUrl + name + ".html",
                    type: "GET",
                    success: function (templateHtml) {
                        templates[name] = templateHtml;
                        resolve(templateHtml);
                    },
                    error: function (err) {
                        reject(err)
                    }
                });
            }
        });
        return promise;
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getRegisterView() {
        return getTemplate("register-form");
    }

    function getAllAppointmentsView() {
        return getTemplate("all-appointments-view");
    }

    function getCommingAppointmentsView() {
        return getTemplate("comming-appointments-view");
    }

    function getCurrentAppointmentsView() {
        return getTemplate("current-appointments-view");
    }

    function getTodayAppointmentsView() {
        return getTemplate("today-appointments-view");
    }

    function getTotoListAllView() {
        return getTemplate("todo-list-all-view");
    }
    
    function getTotoListByIdView() {
        return getTemplate("todo-list-by-id-view");
    }
    
    function getTotoListCreateView() {
        return getTemplate("todo-list-create-view");
    }

    function getTotoCreateView() {
        return getTemplate("todo-todo-create-view");
    }

    function getMainMenuView() {
        return getTemplate("main-nav-menu");
    }
    
    function geCreateAppointmentView() {
        return getTemplate("create-apploinment-view");
    }

    function getAppointmentByDateView() {
        return getTemplate("by-date-appointments");
    }

    return {
        getLoginView: getLoginView,
        getRegisterView: getRegisterView,
        getAllAppointmentsView: getAllAppointmentsView,
        getCommingAppointmentsView: getCommingAppointmentsView,
        getCurrentAppointmentsView: getCurrentAppointmentsView,
        getTodayAppointmentsView: getTodayAppointmentsView,
        getTotoListAllView: getTotoListAllView,
        getTotoListByIdView: getTotoListByIdView,
        getTotoListCreateView: getTotoListCreateView,
        getTotoCreateView: getTotoCreateView,
        getMainMenuView: getMainMenuView,
        geCreateAppointmentView: geCreateAppointmentView,
        getAppointmentByDateView: getAppointmentByDateView
    };
}());