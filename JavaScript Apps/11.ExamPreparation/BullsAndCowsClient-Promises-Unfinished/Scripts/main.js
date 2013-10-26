/// <reference path="controller.js" />
/// <reference path="data-persister.js" />

$(function () {
    var serviceRoot = "http://localhost:40643/api/"

    var localPersister = BullsAndCows.persisters.getPersister(serviceRoot);

    var accessController = BullsAndCows.controller.getAccessController(localPersister);
});