function Person(fname, lname){
  this.introduce = function(){
    return "Hello! My name is " + fname + " " + lname;
  }
}

function Student(fname, lname, grade){
  Person.apply(this, arguments);

  this.getGrade = function(){
    return grade;
  }
}

Student.prototype = new Person();
Student.prototype.constructor = Student;

var cecoTroikata = new Student("Ceco", "Troikata", 3);

console.log("cecoTroikata instanceof Student? " + (cecoTroikata instanceof Student));
console.log("cecoTroikata instanceof Person? " + (cecoTroikata instanceof Person));
console.log("cecoTroikata is in " + cecoTroikata.getGrade() + " grade");


