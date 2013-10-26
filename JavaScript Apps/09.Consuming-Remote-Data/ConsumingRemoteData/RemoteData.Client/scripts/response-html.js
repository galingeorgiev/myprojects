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
				document.getElementById("http-response").innerHTML = httpRequest.responseText;
				success(httpRequest.responseText);
			}
			else {
				document.getElementById("http-response").innerHTML = "<div><h1 style='color:#f00'>Error happened</h1>" + httpRequest.responseText + "</div>";
			}
		}
	}

	httpRequest.open("GET", "partial.html", true);
	httpRequest.setRequestHeader("Content-type", "application/json");

	httpRequest.send(null);
}());