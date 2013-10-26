(function () {

	var httpRequest;
	if (window.XMLHttpRequest) {
		httpRequest = new XMLHttpRequest();
	}
	else if (window.ActiveXObject) {
		httpRequest = new ActiveXObject("Msxml2.XMLHTTP");
	}

	httpRequest.onreadystatechange = function () {
		switch (httpRequest.readyState) {
			case 1: appendText("#http-response", "request in loading state"); break;
			case 2: appendText("#http-response", "request in loaded state"); break;
			case 3: appendText("#http-response", "request in interactive state"); break;
			case 4: appendText("#http-response", "request in complete state"); break;
		}
	}
	httpRequest.open("GET", "http://minkov.it/xmlrpc212i3klaasdklas.php", true);

	httpRequest.send(null);

	function appendText(selector, text) {
		var element = document.querySelector(selector);
		element.innerHTML += "<div>" + text + "</div>";
	}
}());