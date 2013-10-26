/// <reference path="../_references.js" />

window.viewModelsFactory = (function () {
    var data = null;

    // Login
    function getLoginViewModel(successCallback) {
        var viewModel = {
            username: null,
            password: null,
            errMsg: "",
            login: function () {
                var self = this;
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					    window.location.href = "#/accounts";
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

    // Register
    function getRegisterViewModel(successCallback) {
        var viewModel = {
            username: null,
            password: null,
            firstName: null,
            lastName: null,
            errMsg: "",
            register: function () {
                var self = this;
                var userData = {
                    username: this.get("username"),
                    password: this.get("password"),
                    firstName: this.get("firstName"),
                    lastName: this.get("lastName"),
                }

                data.users.register(userData)
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }

					    window.location.href = "#/accounts";
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

    // User Main Page
    function getUserPageViewModel() {
        var viewModel = {
            accounts: function () {
                window.location.href = "#/accounts";
            },
            newAccount: function () {

                window.location.href = "#/accounts/create";
            },
            transfer: function () {

                window.location.href = "#/transfer";
            },
            profile: function () {

                window.location.href = "#/profile";
            },
            admin: function () {

                window.location.href = "/admin-index.html";
            },
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
        }

        return kendo.observable(viewModel);
    }

    // Home
    function getHomeViewModel() {
        // empty for now
        var viewModel = {};

        return kendo.observable(viewModel);
    }

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

    // Profile
    function getUserProfileViewModel() {
        return data.users.profile()
			.then(function (profile) {
			    var viewModel = {
			        profile: profile,
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
    };

    // Accounts
    function getAllAccountsViewModel() {
        return data.accounts.getAllAccounts()
			.then(function (account) {
			    var viewModel = {
			        account: account,
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

    // Create Account
    function getCreateAccountViewModel(successCallback) {

        return data.accountTypes.getAll()
            .then(function (typesData) {
                return data.currencies.getAll()
                    .then(
                       function (currenciesData) {
                           var viewModel = {
                               type: null,
                               balance: null,
                               description: null,
                               currency: null,
                               types: typesData,
                               currencies: currenciesData,
                               agreed: false,
                               errMsg: "",
                               createAccount: function () {
                                   if (this.get("type") === null) {
                                       this.set("errMsg", "Please select Type of Account");
                                       var other = this;
                                       setTimeout(function () {
                                           other.set("errMsg", "");
                                       }, 5000);

                                       return;
                                   }
                                   if (this.get("balance") <= 0) {
                                       this.set("errMsg", "Please select positive balance of Account");
                                       var other = this;
                                       setTimeout(function () {
                                           other.set("errMsg", "");
                                       }, 5000);

                                       return;
                                   }
                                   if (this.get("currency") === null) {
                                       this.set("errMsg", "Please select Currency of Account");
                                       var other = this;
                                       setTimeout(function () {
                                           other.set("errMsg", "");
                                       }, 5000);

                                       return;
                                   }

                                   var accountData = {
                                       description: this.get("description"),
                                       balance: this.get("balance"),
                                       type: this.get("type"),
                                       currency: this.get("currency")
                                   }

                                   data.accounts.createAccount(accountData)
                                       .then(function () {
                                           if (successCallback) {
                                               successCallback();
                                           }

                                           window.location.href = "#/accounts";
                                       });
                               }
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
            });
    };

    // api/accounts/:id
    function getAccountDetailsViewModel(accountId) {
        return data.accounts.getAccountById(accountId)
			.then(function (account) {
			    var viewModel = {
			        account: account,
			        errMsg: "",
			        printDetails: function () {
			            console.log(this.get('account'));
			        }
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

    // api/accounts/:id/transactionlogs
    function getAccountTransactionsViewModel(accountId) {
        return data.accounts.getAccountTransactions(accountId)
			.then(function (transactions) {
			    var viewModel = {
			        transactions: transactions,
			        errMsg: ""
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

    // api/accounts/:id/transfer
    function getAccountTransferViewModel(accountId) {
        return data.accounts.getAccountByIdForTransfer(accountId)
			.then(function (transactionLogs) {
			    var viewModel = {
			        receiverIban: '',
			        amount: '',
			        transactionLogs: transactionLogs,
			        errMsg: "",
			        showTest: function () {
			            console.log(this.message);
			        }
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

    // Transfer
    function getTransferViewModel() {

        return data.accounts.getAllAccounts()
            .then(function (accounts) {
                var viewModel = {
                    FromMyAccounts: accounts,
                    FromAccounts: accounts,
                    ToAccounts: accounts,
                    ibanFrom: null,
                    ibanTo: null,
                    ibanFromMyAccounts: null,
                    ibanToMyAccounts: null,
                    balance: 0,
                    errMsg: "",
                    transferFromMyAccounts: function () {
                        if ((this.get("ibanFromMyAccounts") === this.get("ibanToMyAccounts"))
                            || this.get("ibanToMyAccounts") === null
                            || this.get("ibanFromMyAccounts") === null) {

                            this.set("errMsg", "The Accounts You have chosen are not valid.");
                            var self = this;

                            setTimeout(function () {
                                self.set("errMsg", "");
                            }, 3000)

                            return;
                        }
                        else if (this.get("balance") <= 0) {
                            this.set("errMsg", "Entered balance sum must be greater than 0.");
                            var self = this;

                            setTimeout(function () {
                                self.set("errMsg", "");
                            }, 3000);

                            return;
                        }
                        else {
                            var currentAcc = (this.get("ibanFromMyAccounts"));

                            var index = -1;
                            for (var i = 0; i < accounts.length; i++) {
                                if (currentAcc === accounts[i].iban) {
                                    index = i;
                                }
                            }

                            if (accounts[index].balance < this.get("balance")) {
                                this.set("errMsg", "Not enough money for transfer!!!");
                                var self = this;

                                setTimeout(function () {
                                    self.set("errMsg", "");
                                }, 3000);


                                return;
                            }
                        }

                        var transferData = {
                            "amount": this.get("balance"),
                            "fromAccount": this.get("ibanFromMyAccounts"),
                            "toAccount": this.get("ibanToMyAccounts")
                        }

                        data.accounts.putTransfer(transferData).then(
                            function () {
                                window.location.href = "#/accounts/transfer/success";
                            })
                    },
                    transfer: function () {
                        if ((this.get("ibanFrom") === this.get("ibanTo"))
                            || this.get("ibanTo") === null
                            || this.get("ibanFrom") === null || this.get("ibanTo").trim().length < 22) {

                            this.set("errMsg", "The Accounts You have chosen are not valid.");
                            var self = this;

                            setTimeout(function () {
                                self.set("errMsg", "");
                            }, 3000)

                            return;
                        }
                        else if (this.get("balance") <= 0) {
                            this.set("errMsg", "Entered balance sum must be greater than 0.");
                            var self = this;

                            setTimeout(function () {
                                self.set("errMsg", "");
                            }, 3000);

                            return;
                        }
                        else {
                            var currentAcc = (this.get("ibanFrom"));

                            var index = -1;
                            for (var i = 0; i < accounts.length; i++) {
                                if (currentAcc === accounts[i].iban) {
                                    index = i;
                                }
                            }

                            if (accounts[index].balance < this.get("balance")) {
                                this.set("errMsg", "Not enough money for transfer!!!");
                                var self = this;

                                setTimeout(function () {
                                    self.set("errMsg", "");
                                }, 3000);


                                return;
                            }
                        }

                        var transferData = {
                            "amount": this.get("balance"),
                            "fromAccount": this.get("ibanFrom"),
                            "toAccount": "",
                            "toIban": this.get("ibanTo")
                        }

                        data.accounts.putTransfer(transferData).then(
                            function () {
                                window.location.href = "#/accounts/transfer/success";
                            })
                    }
                };
                return kendo.observable(viewModel);
            },
            function (err) {
                debugger;
                var self = this;
                self.set("errMsg", JSON.parse(err.responseText).Message);
                var other = self;
                setTimeout(function () {
                    other.set("errMsg", "");
                }, 5000);
            });
    };

    // Transfer From current account
    function getTransferFromCurrentAccountViewModel(id) {
        var accounts;
        return data.accounts.getAllAccounts()
            .then(function (accs) {
                accounts = accs;
                return data.accounts.getAccountById(id);
            }, function (err) {
                console.log(err);
            })
            .then(function (acc) {
                var toAcc = accounts;
                function cascade() {
                    var index = -1;
                    for (var i = 0; i < accounts.length; i++) {
                        if (acc.iban === accounts[i].iban) {
                            index = i;
                        }
                    }

                    if (index >= 0) {
                        toAcc.splice(index, 1);
                    }
                }

                cascade();

                var viewModel = {
                    myIban: acc.iban,
                    myBalance: acc.balance,
                    ToAccounts: toAcc,
                    ibanTo: null,
                    ibanToMyAccounts: null,
                    balance: 0,
                    errMsg: "",
                    transferFromMyAccounts: function () {
                        if ((this.get("myIban") === this.get("ibanToMyAccounts"))
                            || this.get("ibanToMyAccounts") === null
                            || this.get("myIban") === null) {

                            this.set("errMsg", "The Accounts You have chosen are not valid.");
                            var self = this;

                            setTimeout(function () {
                                self.set("errMsg", "");
                            }, 3000)

                            return;
                        }
                        else if (this.get("balance") <= 0) {
                            this.set("errMsg", "Entered balance sum must be greater than 0.");
                            var self = this;

                            setTimeout(function () {
                                self.set("errMsg", "");
                            }, 3000);

                            return;
                        }
                        else {
                            if (acc.balance < this.get("balance")) {
                                this.set("errMsg", "Not enough money for transfer!!!");
                                var self = this;

                                setTimeout(function () {
                                    self.set("errMsg", "");
                                }, 3000);


                                return;
                            }
                        }

                        var transferData = {
                            "amount": this.get("balance"),
                            "fromAccount": this.get("myIban"),
                            "toAccount": this.get("ibanToMyAccounts"),
                        }

                        data.accounts.putTransfer(transferData).then(
                            function () {
                                window.location.href = "#/accounts/transfer/success";
                            });
                    },
                    transfer: function () {

                        if ((this.get("myIban") === this.get("ibanTo"))
                            || this.get("ibanTo") === null
                          || this.get("myIban") === null || this.get("ibanTo").trim().length < 22) {

                            this.set("errMsg", "The Accounts You have chosen are not valid.");
                            var self = this;

                            setTimeout(function () {
                                self.set("errMsg", "");
                            }, 3000)

                            return;
                        }
                        else if (this.get("balance") <= 0) {
                            this.set("errMsg", "Entered balance sum must be greater than 0.");
                            var self = this;

                            setTimeout(function () {
                                self.set("errMsg", "");
                            }, 3000);

                            return;
                        }
                        else {
                            if (acc.balance < this.get("balance")) {
                                this.set("errMsg", "Not enough money for transfer!!!");
                                var self = this;

                                setTimeout(function () {
                                    self.set("errMsg", "");
                                }, 3000);


                                return;
                            }
                        }

                        var transferData = {
                            "amount": this.get("balance"),
                            "fromAccount": this.get("myIban"),
                            "toAccount": "",
                            "toIban": this.get("ibanTo")
                        }

                        data.accounts.putTransfer(transferData).then(
                            function () {
                                window.location.href = "#/accounts/transfer/success";
                            });
                    }
                };

                return kendo.observable(viewModel);
            }, function (err) {
                console.log(err);
            });
    };

    return {
        getLoginVM: getLoginViewModel,
        getAccountDetailsViewModel: getAccountDetailsViewModel,
        getAllAccountsViewModel: getAllAccountsViewModel,
        getMainPageViewModel: getMainPageViewModel,
        getAccountTransactionsViewModel: getAccountTransactionsViewModel,
        getHomeViewModel: getHomeViewModel,
        getRegisterViewModel: getRegisterViewModel,
        getUserPageViewModel: getUserPageViewModel,
        getCreateAccountViewModel: getCreateAccountViewModel,
        getTransferViewModel: getTransferViewModel,
        getTransferFromCurrentAccountViewModel: getTransferFromCurrentAccountViewModel,
        getUserProfileViewModel: getUserProfileViewModel,
        setPersister: function (persister) {
            data = persister
        }

    };
}());