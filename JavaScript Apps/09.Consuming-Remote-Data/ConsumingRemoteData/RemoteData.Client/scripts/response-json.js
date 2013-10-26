(function () {

	var httpRequest;
	if (window.XMLHttpRequest) {
		httpRequest = new XMLHttpRequest();
	}
	else if (window.ActiveXObject) {
		try {
			httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
		}
		catch (e) {
			try {
				httpRequest = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e) {

			}
		}
	}

	httpRequest.onreadystatechange = function () {
		if (httpRequest.readyState === 4) {
			if (httpRequest.status === 200) {
				success(JSON.parse(httpRequest.responseText));
			}
			else {
				error(httpRequest.responseText);
			}
		}
	}

	httpRequest.open("GET", "scripts/data.js", true);
	httpRequest.setRequestHeader("Content-type", "application/json");

	httpRequest.send(null);


	function error(err) {
		document.getElementById("http-response").innerHTML = "<div><h1 style='color:#f00'>Error happened</h1>" + err + "</div>";
	}

	function success(response) {
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