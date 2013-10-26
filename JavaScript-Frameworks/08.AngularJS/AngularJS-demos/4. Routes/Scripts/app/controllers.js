/// <reference path="../libs/underscore.js" />

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
	});
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
}

function SinglePostController($scope, $http, $routeParams) {
	var id = $routeParams.id;
	$http.get("scripts/data/posts.js")
	.success(function (posts) {
		var post = _.first(_.where(posts, { "id": parseInt(id) }));
		debugger;
		$scope.post = post;
	})
}

function CategoryController($scope, $http, $routeParams) {
	var categoryName = $routeParams.name;

	$http.get("scripts/data/posts.js")
	.success(function (posts) {
		var category = {
			name: categoryName,
			posts: []
		};
		_.chain(posts)
		.where({ "category": categoryName })
		.each(function (post) {
			category.posts.push({
				id: post.id,
				title: post.title,
				content: post.content
			});
		})
		$scope.category = category;
	})
};