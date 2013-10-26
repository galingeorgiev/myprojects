/// <reference path="libs/require.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="libs/http-requester.js" />
/// <reference path="libs/jquery-2.0.3.js" />

(function () {
	require.config({
		paths: {
			jquery: "libs/jquery-2.0.3",
			mustache: "libs/mustache",
			sammy: "libs/sammy-0.7.4",
			rsvp: "libs/rsvp.min",
			"http-requester": "libs/http-requester"
		}
	})

	require(["jquery", "sammy", "mustache", "rsvp", "http-requester"],
					function ($, sammy, mustache, rsvp, request) {
						var app = sammy("#main-content", function () {
							this.get("#/", function () {
								$("#main-content").html("View the students page");
							});

							this.get("#/about", function () {
								$("#main-content").html("View the students page");
							});

							this.get("#/students", function () {
								request.getJSON("api/students")
									.then(function (data) {
										var studentsList = $("<ul />");
										var templateString = $("#student-template").html();
										var template = mustache.compile(templateString);
										for (var i in data) {
											var student = data[i];
											var templatedStudent = template(student);
											studentsList.append(templatedStudent);
										}
										$("#main-content").html(studentsList);
									});
							});

							this.get("#/student/:id", function () {
								request.getJSON("api/students/" + this.params["id"] + "/marks")
									.then(function (marks) {
										var marksList = $("<ul />");
										var templateString = $("#mark-template").html();
										var template = mustache.compile(templateString);
										for (var i in marks) {
											var mark = marks[i];
											var templatedMark = template(mark);
											marksList.append(templatedMark);
										}
										$("#main-content").html(marksList);
									});
							});
							

						});

						app.run("#/");
					});
}());