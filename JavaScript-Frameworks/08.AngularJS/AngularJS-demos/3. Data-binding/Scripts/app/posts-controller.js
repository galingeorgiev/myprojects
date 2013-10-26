/// <reference path="../libs/underscore.js" />
/// <reference path="../libs/angular.js" />
/// 
function PostsController($scope, $http) {

	$scope.newPost = {
		title: "",
		content: "",
		category: ""
	};

	$http.get("scripts/data/posts.js")
		.success(function (posts) {
			$scope.posts = posts;
			$scope.categories = _.uniq(_.pluck(posts, "category"));
			$scope.selectedCategory = $scope.categories[0];

			$scope.addPost = function () {
				$scope.posts.push($scope.newPost);
				var category = $scope.newPost.category;
				if (!_.contains($scope.categories, category)) {
					$scope.categories.push(category);
				}

				$scope.newPost = {
					title: "",
					content: "",
					category: ""
				};
			}
		});
}
