(function () {

	var httpRequest;
	if (window.XMLHttpRequest) {
		httpRequest = new XMLHttpRequest();
	}
	else if (window.ActiveXObject) {
		httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
	}

	httpRequest.onreadystatechange = function () {
		if (httpRequest.readyState === 4) {
			if (httpRequest.status === 200) {
				appendText("#http-response","The request is successfull");
			}
			else {
				appendText("#http-response", "The request failed with statusCode: " + httpRequest.status);
			}
		}
	}

	httpRequest.open("GET", "scripts/data.js", true);
	httpRequest.send(null);

	function appendText(selector, text) {
		var element = document.querySelector(selector);
		element.innerHTML += "<div>" + text + "</div>";
	}
}());