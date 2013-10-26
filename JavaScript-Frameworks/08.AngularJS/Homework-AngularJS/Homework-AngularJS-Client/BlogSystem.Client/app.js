/// <reference path="app/scripts/persister.js" />
/// <reference path="Scripts/angular.js" />
/// <reference path="Scripts/angular.js" />

var app = angular.module('BlogApp', []);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when('/posts',
            {
                controller: 'PostsController',
                templateUrl: '/app/partials/all-posts.html'
            })
        .when('/categories/:categoryId/posts',
            {
                controller: 'PostsByCategoryController',
                templateUrl: '/app/partials/all-posts.html'
            })
        .when('/posts/add',
            {
                controller: 'PostsController',
                templateUrl: '/app/partials/add-post.html'
            })
        .when('/category/select',
            {
                controller: 'PostsByCategoryController',
                templateUrl: '/app/partials/select-category.html'
            })
        .when('/post/created',
            {
                controller: 'PostsByCategoryController',
                templateUrl: '/app/partials/post-created.html'
            })
        .otherwise({ redirectTo: '/index.html' });
}]);

app.controller('PostsController', function ($scope, $http) {
    var mainUrl = 'http://localhost:51950/api'
    $scope.posts = {};

    $http.get(mainUrl + '/posts')
        .success(function (data) {
            $scope.posts = data;
        })
        .error(function (err) {
            console.log(err);
        });

    var newPost = {};
    var newCategory = {};

    $scope.addPost = function () {
        newPost.title = $scope.newPost.title;
        newPost.content = $scope.newPost.content;
        newCategory.name = $scope.newPost.category;
        newPost.category = newCategory;

        $http.post(mainUrl + '/posts', newPost);
        window.location = '#/post/created';
    };
});

app.controller('PostsByCategoryController', function ($scope, $http, $routeParams) {
    var id = $routeParams.categoryId;
    var mainUrl = 'http://localhost:51950/api'
    $scope.posts = {};
    $scope.categories = {};

    $http.get(mainUrl + '/posts/' + id)
        .success(function (data) {
            $scope.posts = data;
        })
        .error(function (err) {
            console.log(err);
        });

    $http.get(mainUrl + '/categories')
        .success(function (data) {
            $scope.categories = data;
        })
        .error(function (err) {
            console.log(err);
        });
});