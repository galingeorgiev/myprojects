var Class = (function() {
  function createClass(properties) {
    var f = function() {
      this.init.apply(this, arguments);
     }

    for (var prop in properties) {
      f.prototype[prop] = properties[prop];
    }
    if (!f.prototype.init) {
      f.prototype.init = function() {}
    }
    return f;
  }

  return {
    create: createClass,
  };
}());

var Person = Class.create({
  init: function(fname, lname, nickname) {
    this.fname = fname;
    this.lname = lname;
    this.nickname = nickname;
  },
  toString: function() {
    return "Name: " + this.fname + " " + this.lname + ", aka. " + this.nickname;
  }
});

var pesho = new Person("Peter", "Petrov", "Pesho Vodkata");
console.log(pesho.toString());