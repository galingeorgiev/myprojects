/// <reference path="../Scripts/class.js" />
var ModelFactory = function () {
    var Post = Class.create({
        init: function (title, content, tags) {
            this.title = title;
            this.content = content;
            this.tags = tags;
        }
    });

    var Comment = Class.create({
        init: function (content, postId) {
            this.content = content;
            this.postId = postId;
        },
        toString: function () {
            return this.content;
        }
    });

    return {
        post: function (title, content, tags) { return new Post(title, content, tags) },
        comment: function (content, postId) { return new Comment(content, postId) }
    }
}();