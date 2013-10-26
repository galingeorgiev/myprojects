function Person(fname, lname){
  this.introduce = function(){
    return "Hello! My name is " + fname + " " + lname;
  }
}
var joro = new Person("Joro", "Mentata");
var pesho = new Person("Pesho", "Vodkata");
console.log(joro.introduce()); 
//logs "Hello! My name is Joro Mentata"
console.log(pesho.introduce());
