/// <reference path="libs/require.js" />
/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="libs/jquery-2.0.3.js" />


(function () {

	require.config({
		paths: {
			jquery: "libs/jquery-2.0.3",
			sammy: "libs/sammy-0.7.4"
		}
	})

	require(["jquery", "sammy"], function ($, sammy) {
		var app = sammy("#main-content",function () {
			this.get("#/", function () {
				alert("In home");
				$("body").append(
					)
			});

			this.get("#/about", function () {
				//alert("In about");				
			navigate("#/item/5")
			});

			this.get("#/item/:id", function (id) {
				alert("In item with id: " + this.params["id"]);
			});
		});
		app.run("#/");		
		
	});
}());