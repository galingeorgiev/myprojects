/// <reference path="../libs/underscore.js" />
/// <reference path="../libs/angular.js" />

angular.module("forum", [])
	.config(["$routeProvider", function ($routeProvider) {
		$routeProvider
			.when("/", { templateUrl: "scripts/partials/all-posts.html", controller: PostsController })
			.when("/post/:id", { templateUrl: "scripts/partials/single-post.html", controller: SinglePostController })
			.when("/category/:name", { templateUrl: "scripts/partials/category.html", controller: CategoryController })
			.otherwise({ redirectTo: "/" });
	}]);
