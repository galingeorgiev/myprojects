(function () {
    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        var prototype = new parent();
        this.prototype = Object.create(prototype);
        this.prototype._super = prototype;
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }
}());