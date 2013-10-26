/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/rsvp.min.js" />

define(["httpRequester"], function (httpRequester) {
	function getPeople() {		
		return httpRequester.getJSON("./scripts/data/people.js");
	}
	return {
		people: getPeople
	}
});