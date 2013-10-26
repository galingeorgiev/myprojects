/// <reference path="Scripts/_references.js" />

// main angular module here for the admin app
var adminIndexModule = angular.module("admin-index", []);

var sessionKey = localStorage.getItem("sessionKey");
//"1FjxqVsxSMjpIhtKnpRvgbycBTjlGQsMDxmQyBPnGQSXWpDOmk";

// routing and configuration
adminIndexModule.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/users", {
        controller: UsersController,
        templateUrl: "Templates_Angular/all-users.html"
    });

    $routeProvider.when("/users/:id", {
        controller: AccountsController,
        templateUrl: "Templates_Angular/accounts.html"
    });

    $routeProvider.otherwise({ redirectTo: "/users" });
}]);

// data module as a service via the module.factory method
adminIndexModule.factory("admin-data-service", ["$http", "$q", function ($http, $q) {
    var requestConfiguration = {
        headers: { "X-SessionKey": sessionKey }
    };

    var _users = [];
    var _accounts = [];

    var _getUsers = function () {
        var deferred = $q.defer();

        var getUsersUrl = "/api/users"
        $http.get(getUsersUrl, requestConfiguration)
          .then(function (result) {
              // Successful
              angular.copy(result.data, _users);
              deferred.resolve(_users);
          },
          function () {
              // Error
              deferred.reject();
          });

        return deferred.promise;
    };

    var _getAccountsByUserId = function (id) {
        var deferred = $q.defer();
        var getAccountsByUserIdUrl = "/api/accounts?userId=" + id;
        $http.get(getAccountsByUserIdUrl, requestConfiguration)
          .then(function (result) {
              // Successful
              angular.copy(result.data, _accounts);
              // console.log(JSON.stringify(_users))
              deferred.resolve(_accounts);
          },
          function () {
              // Error
              deferred.reject();
          });

        return deferred.promise;
    }

    var _updateUserAccount = function (accountId, modifiedAccount) {
        var deferred = $q.defer();

        var updateUserAccountUrl = "/api/accounts/" + accountId;
        $http.put(updateUserAccountUrl, modifiedAccount, requestConfiguration)
          .then(function (result) {
              // Successful
              angular.copy(result.data, _accounts);
              // console.log(JSON.stringify(_users))
              deferred.resolve(_accounts);
          },
          function () {
              // Error
              deferred.reject();
          });

        return deferred.promise;
    }

    return {
        users: _users,
        getUsers: _getUsers,
        getAccountsByUserId: _getAccountsByUserId,
        updateUserAccount: _updateUserAccount
    };
}]);

// controllers 
var UsersController = ["$scope", "$http", "admin-data-service",
  function ($scope, $http, adminDataService) {
      adminDataService.getUsers().then(function (users) {
          $scope.users = users;
      }, function (reason) {
          console.log(JSON.stringify(reason));
      });
  }];

var AccountsController = ["$scope", "$http", "admin-data-service", "$routeParams",
  function ($scope, $http, adminDataService, $routeParams) {
      $scope.topic = null;
      $scope.currentUser = null;
      var userId = $routeParams.id;
      adminDataService.getAccountsByUserId(userId)
        .then(
        function (topic) {
            // success
            $scope.topic = topic;
        },
        function () {
            // error
            window.location = "#/";
        })
          .then(
        function () {
            adminDataService.getUsers().then(function (users) {
                var usersArray = users;

                for (var i = 0; i < usersArray.length; i++) {
                    if (usersArray[i].id == userId) {
                        $scope.currentUser = usersArray[i];
                        break;
                    }
                }

                console.log($scope.currentUser.firstName);
                loadGrid("#accounts", $scope.topic);
            });
        },

        function () {
            console.log("Could not load grid")
        });

      function onGridRowSave(e) {
          var modifiedAccount = e.sender._data[0];
          var accountId = modifiedAccount.id;
          var accountData = {
              interestRate: modifiedAccount.interestRate,
              balance: modifiedAccount.balance,
              iban: modifiedAccount.iban,
              description: modifiedAccount.description,
              currencyId: modifiedAccount.currency.id,
              typeId: modifiedAccount.type.id
          }
          adminDataService.updateUserAccount(accountId, accountData)
      }

      function loadGrid(selector, items) {
          $(selector).kendoGrid({
              dataSource: {
                  data: items,
                  pageSize: 10
              },
              groupable: false,
              sortable: true,
              pageable: {
                  refresh: true,
              },
              save: onGridRowSave,
              editable: "inline",
              columns: [
                  { field: "description", width: 140, title: "Description" },
                  { field: "iban", width: 120, title: "IBAN" },
                  { field: "interestRate", width: 60, title: "Interest rate", format: "{0} %" },
                  { field: "balance", width: 60, title: "Balance" },
                  { field: "currency.name", width: 50, title: "Currrency" },
                  { field: "type.name", width: 60, title: "Type" },
                  { command: ["edit"], title: "&nbsp;", width: "172px" },
              ]
          });
      }
  }];