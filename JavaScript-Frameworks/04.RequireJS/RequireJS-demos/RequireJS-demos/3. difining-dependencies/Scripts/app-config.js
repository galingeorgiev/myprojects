/// <reference path="libs/require.js" />
require.config({
	paths: {
		jquery: "libs/jquery-2.0.3",
		rsvp: "libs/rsvp.min",
		httpRequester: "libs/http-requester",
		mustache: "libs/mustache"
	}
});

require(["jquery","mustache", "app/data-persister", "app/controls"], function ($, mustache, data, controls) {
	data.people()
		.then(function (people) {
			
			var personTemplateString = $("#person-template").html();

			var template = mustache.compile(personTemplateString);

			var listView = controls.listView(people);
			var listViewHtml = listView.render(template);

			$("body").append(listViewHtml);

		}, function (err) {
			console.error(err);
		});
});