/// <reference path="../libs/angular.js" />
/// 
function PostsController($scope, $http) {
	$http.get("scripts/data/posts.js")
		.success(function (posts) {
			$scope.posts = posts;
			$scope.categories = posts

		});
}
