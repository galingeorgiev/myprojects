/// <reference path="libs/require.js" />
/// <reference path="libs/jquery-2.0.3.js" />

require.config({
    paths: {
        jquery: "libs/jquery-2.0.3",
        rsvp: "libs/rsvp.min",
        httpRequester: "libs/http-requester",
        mustache: "libs/mustache"
    }
});

require(["jquery", "mustache", "app/controls"], function ($, mustache, controls) {
    var people = [
            { id: 0, name: "Doncho Minkov", age: 18, avatarUrl: "images/minkov.jpg" },
            { id: 1, name: "Georgi Georgiev", age: 19, avatarUrl: "images/joreto.jpg" }];

    var comboBox = controls.ComboBox(people);
    var template =
    '<div class="person-item" data-person-id="{{id}}">' +
    '<strong class="person-name">{{name}}</strong><p class="person-age">{{age}}</p>' +
    '<img src="{{avatarUrl}}" width="100px" />' +
    '</div>';
    var compiledTemplate = mustache.compile(template);
    var comboBoxHtml = comboBox.render(compiledTemplate);
    $("#combo-box").html(comboBoxHtml);

    $("#combo-box").on("click", ".person-item", function () {
        if ($("#combo-box").css("overflow") == "visible") {
            $("#combo-box").css({ "overflow": "hidden" });

            var currentStudentId = $(this).attr("data-person-id");
            var currentStudent = people[currentStudentId];
            var currentStudentHtml = compiledTemplate(currentStudent);
            $("#combo-box").html(currentStudentHtml);
        }
        else {
            $("#combo-box").css({ "overflow": "visible" });
            var comboBoxHtml = comboBox.render(compiledTemplate);
            $("#combo-box").html(comboBoxHtml);
        }
    });
});