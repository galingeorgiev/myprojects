(function () {
	var httpRequest = new XMLHttpRequest();	
	httpRequest.onreadystatechange = function () {
		if (httpRequest.readyState === 4 && httpRequest.status === 200) {
			renderHttpResponse(JSON.parse(httpRequest.responseText));
		}
	}

	httpRequest.open("GET", "scripts/data.js", true);
	httpRequest.setRequestHeader("Content-type", "application/json");

	httpRequest.send(null);

	function renderHttpResponse(response) {
		var list = "<ul>";
		for (var i = 0; i < response.length; i += 1) {
			var person = response[i];
			list +=
				"<li>" +
					person.fname + " " + person.lname +
				"</li>";
		}
		document.getElementById("http-response").innerHTML = list;
	}
}());