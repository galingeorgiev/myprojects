var httpRequest = (function () {
	function getHttpRequest() {
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
		return httpRequest;
	}
	
	function makeRequest(options) {
		var requestUrl = options.url;
		var httpRequest = getHttpRequest();
		httpRequest.onreadystatechange = function () {
			if (httpRequest.readyState === 4) {
				if (httpRequest.status === 200) {
					if (options.success) {
						if (httpRequest.responseText) {
							options.success(httpRequest.responseText);
						}
						else {
							options.success();
						}
					}
				}
				else if (options.error) {
					options.error(httpRequest.responseText);
				}
			}
		}
		httpRequest.open(options.type ? options.type : "GET", requestUrl, true);
		if (options.contentType) {
			httpRequest.setRequestHeader("Content-Type", options.contentType);
		}
		if (options.accept) {
			httpRequest.setRequestHeader("Accept", options.accept);
		}
		//var postData = null;
		//if(options.data){
		//	postData = JSON.stringify(options.data);
		//}
		var postData = options.data ? JSON.stringify(options.data) : null;
		httpRequest.send(postData);
	}

	function getJSON(url, success, error) {
		makeRequest({
			url: url,
			type: "GET",
			contentType: "application/json",
			accept: "application/json",
			success: function (data) {
				if (data) {
					success(JSON.parse(data));
				}
				else {
					success();
				}
			},
			error: function (err) {
				if (error) {
					if (err) {
						error(JSON.parse(err));
					}
					else {
						error();
					}
				}
			},
		});
	}

	function postJSON(url, data, success, error) {
		makeRequest({
			url: url,
			type: "POST",
			contentType: "application/json",
			accept: "application/json",
			data: data,
			success: function (data) {
				if (data) {
					success(JSON.parse(data));
				}
				else {
					success();
				}
			},
			error: function (err) {
				error(JSON.parse(err));
			},
		});
	}

	return {
		make: makeRequest,
		getJSON: getJSON,
		postJSON: postJSON
	};
}());