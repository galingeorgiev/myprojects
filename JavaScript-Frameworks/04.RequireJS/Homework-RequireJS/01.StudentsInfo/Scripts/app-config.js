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

require(["jquery", "mustache", "app/data-persister", "app/controls"], function ($, mustache, data, controls) {
    data.getStudents()
		.then(function (students) {
		    var studentBasic = "<li data-student-id='{{id}}'>{{name}} - Grade: {{grade}}</li>";
		    var studentsMarks = "<li>Subject: {{subject}} - score: {{score}}</li>";
		    var studentBasicTemplate = mustache.compile(studentBasic);
		    var studentMarksTemplate = mustache.compile(studentsMarks);

		    function showAllStuents() {
		        var listView = controls.listView(students);
		        var listViewHtml = listView.render(studentBasicTemplate);
		        $("#student-basic").html(listViewHtml);
		        $("#back").css({ "display": "none" });
		    }

		    showAllStuents();

		    $("#back").on("click", function () {
		        showAllStuents();
		    })
		    
		    $("#student-basic").on("click", "ul li", function () {
		        var studentId = $(this).attr("data-student-id");
		        data.getMarks(studentId).then(function (student) {
		            var listViewMarks = controls.listView(student);
		            var listViewHtmlMarks = listViewMarks.render(studentMarksTemplate);
		            $("#student-basic").html(listViewHtmlMarks);
		            $("#back").css({ "display": "block" });
		        });
		    })
		}, function (err) {
		    console.error(err);
		});
});