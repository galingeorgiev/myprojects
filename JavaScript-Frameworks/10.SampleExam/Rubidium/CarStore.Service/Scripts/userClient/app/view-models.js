/// <reference path="dataPersister.js" />
/// <reference path="../../libs/_references.js" />

window.viewModelsFactory = (function () {

    var dataPersister = persisters.getPersister("api/");
    var start;
    var end;

    function errorsDiv(data) {
        $(".error").remove();
        var div = $("<div />").html(data).addClass("error");
        $("#main-content").append(div);
    }

    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: "",
            password: "",
            nickname: "",

            login: function () {
                username = this.get("username");
                password = this.get("password");
                dataPersister.users.login(username, password)
                    .then(function () {
                            successCallback();
                    });
            },
            logout: function () {
                dataPersister.users.logout()
                    .then(function () {
                            successCallback();
                    });
            }
        };

        return kendo.observable(viewModel);
    }

    function getRegisterViewModel(successCallback) {
        var viewModel = {
            username: "",
            password: "",
            nickname: "",

            register: function () {
                username = this.get("username");
                password = this.get("password");
                nickname = this.get("nickname");
                
                dataPersister.users.register(username, password, nickname)
                    .then(function () {
                        if (successCallback()) {
                            successCallback();
                        }
                    });
                        }
        };

        return kendo.observable(viewModel);
    }

   
    function getCarViewById(id) {
        var self = this;
        return dataPersister.cars.getById(id)
            .then(function (carData) {
                //debugg
                if (carData.extras != null) {
                    if (!carData.extras.airCondition) {
                    carData.extras.airCondition = "No";
                }
                if (!carData.extras.audioSystem) {
                    carData.extras.audioSystem = "No";
                }
                if (!carData.extras.automaticTransmission) {
                    carData.extras.automaticTransmission = "No";
                }
                if (!carData.extras.crouseControl) {
                    carData.extras.crouseControl = "No";
                }
                if (!carData.extras.parktronic) {
                    carData.extras.parktronic = "No";
                }
                if (!carData.extras.powerLock) {
                    carData.extras.powerLock = "No";
                }
                if (!carData.extras.powerWindows) {
                    carData.extras.powerWindows = "No";
                }
                }
                var viewModel = {
                    car: carData,
                    mystartDate: "",
                    myendDate: "",
                    rent: function () {
                        var startDay = this.get("mystartDate");
                        var endDay = this.get("myendDate");
                        var carId = $(".div-one-car").attr("id");
                        var rentCar = {
                            pickUpDate: startDay,
                            dropOffDate: endDay,
                            id: carId
                        };
                        
                        if (dataPersister.isUserLoggedIn()) {
                            var pricePerday = $("#pricePerDay").data("priceperday");
                            var days = ((((endDay - startDay) / 1000) / 3600) / 24);
                            var amount = localStorage.getItem("amount");
                            var change = amount - (pricePerday * days);
                            if (change >= 0) {
                                dataPersister.cars.rent(rentCar).then(function() {
                                    localStorage.setItem("amount", change);
                                    errorsDiv("Your amount now is " + change);
                                }, function(error) {
                                    console.log(error);
                                });
                            }
                        }
                        else {
                            errorsDiv("Please login first");
                        }

                    },
                    buy: function () {
                    }
                };

                return kendo.observable(viewModel);
            });
    }

    function getCarsViewModel() {

        return dataPersister.cars.all()
            .then(function (cars) {
                var viewModel = {
                    cars: cars,
                    message: ""
                };

                return kendo.observable(viewModel);
            });
    }
    
    function getStoresViewModel() {
        return dataPersister.stores.all()
            .then(function (stores) {
                var viewModel = {
                    stores: stores
                };

                return kendo.observable(viewModel);
            });
    }

    function getStoreViewById(id) {
        return dataPersister.stores.getById(id)
            .then(function (storeData) {
                var viewModel = {
                    store: storeData
                };

                return kendo.observable(viewModel);
            });
    }



    function datePicker() {
        function startChange() {
            var startDate = start.value(),
            endDate = end.value();

            if (startDate) {
                startDate = new Date(startDate);
                startDate.setDate(startDate.getDate());
                end.min(startDate);
            } else if (endDate) {
                start.max(new Date(endDate));
            } else {
                endDate = new Date();
                start.max(endDate);
                end.min(endDate);
            }
        }

        function endChange() {
            var endDate = end.value(),
            startDate = start.value();

            if (endDate) {
                endDate = new Date(endDate);
                endDate.setDate(endDate.getDate());
                start.max(endDate);
            } else if (startDate) {
                end.min(new Date(startDate));
            } else {
                endDate = new Date();
                start.max(endDate);
                end.min(endDate);
            }
        }

        start = $("#start").kendoDatePicker({
            change: startChange,
            format: "yyyy/MM/dd"
        }).data("kendoDatePicker");

        end = $("#end").kendoDatePicker({
            change: endChange,
            format: "yyyy/MM/dd"
        }).data("kendoDatePicker");

        start.max(end.value());
        end.min(start.value());
    }

    return {
        getLoginViewModel: getLoginViewModel,
        getCarsViewModel: getCarsViewModel,
        getCarViewById: getCarViewById,
        getStoresViewModel: getStoresViewModel,
        getStoreViewById: getStoreViewById,
        getRegisterViewModel: getRegisterViewModel,
        datePicker: datePicker
    }

}());