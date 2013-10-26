if (!Object.prototype.extend) {
  Object.prototype.extend = function(properties) {
    function f() {};
    f.prototype = Object.create(this);
    for (var prop in properties) {
      f.prototype[prop] = properties[prop];
    }
    f.prototype._super = this;
    return new f();
  }
}

var Person = {
  init: function(fname, lname, nickname) {
    this.fname = fname;
    this.lname = lname;
    this.nickname = nickname;
  },
  introduce: function() {
    return this.fname + " " + this.lname + " aka " + this.nickname;
  }
};

var Student = Person.extend({
  init: function(fname, lname, nickname, grade) {
    this._super.init(fname, lname, nickname);
    this.grade = grade;
  },
  introduce: function(){
    return this._super.introduce() + ", grade: " + this.grade;
  }
});

var joro = Object.create(Student);
joro.init("Georgi", "Georgiev", "Joro Mentata", 4);

var pesho = Object.create(Student);
pesho.init("Pesho", "Peshev", "Pesho Kirkata", 3);

console.log(joro.introduce === pesho.introduce);