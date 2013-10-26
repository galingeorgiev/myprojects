/// <reference path="../libs/jquery-2.0.3.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/rsvp.min.js" />

define(["httpRequester"], function (httpRequester) {
	function getStudents() {		
	    return httpRequester.getJSON("http://localhost:51971/api/students");
	}
	function getMarks(studentId) {
	    var data = httpRequester.getJSON("http://localhost:51971/api/students/" + studentId + "/marks");
	    return data;
	}
	return {
	    getStudents: getStudents,
	    getMarks: getMarks
	}
});