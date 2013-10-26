function Person(fname, lname) {
  this.fname = fname;
  this.lname = lname;
}
Person.prototype.introduce = function() {
  return "Hello! My name is " + this.fname + " " + this.lname;
}

function Student(fname, lname, grade) {
  Person.apply(this, arguments);
  this.grade = grade;
}

Student.prototype = new Person();
Student.prototype.constructor = Student;

Student.prototype.getGrade = function() {
  return grade;
}

var cecoTroikata = new Student("Ceco", "Troikata", 3);
var mitkoZubara = new Student("Mitko", "Zubara", 6);

//The methods are identical and they are created only once in memory
console.log(cecoTroikata.getGrade === mitkoZubara.getGrade);
console.log(cecoTroikata.introduce === mitkoZubara.introduce);