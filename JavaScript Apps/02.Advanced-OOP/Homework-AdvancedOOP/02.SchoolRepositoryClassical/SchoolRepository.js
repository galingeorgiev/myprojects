(function () {
    /*---------------------------Create classes --------------------------*/
    var School = function (name, town, classes) {
            this.name = name;
            this.town = town;
            this.classes = classes;
    }

    var Classes = function (name, capacity, setOfStudents, formTeacher) {
            this.name = name;
            this.capacity = capacity;
            this.setOfStudents = setOfStudents;
            this.formTeacher = formTeacher;
    }

    var Person = function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
    };

    Person.prototype.introduce = function () {
        return "Name: " + this.firstName + " " + this.lastName + ", age: " + this.age;
    }

    var Student = function (firstName, lastName, age, grade) {
        Person.apply(this, arguments);
        this.grade = grade;
    }

    Student.prototype.introduce = function () {
        return "Name: " + this.firstName + " " + this.lastName + ", age: " + this.age + ", grade: " + this.grade;
    }

    Student.inherit(Person);

    var Teacher = function (firstName, lastName, age, speciality) {
        Person.apply(this, arguments);
        this.speciality = speciality;
    }

    Teacher.prototype.introduce = function () {
        return "Name: " + this.firstName + " " + this.lastName + ", age: " + this.age + ", speciality: " + this.speciality;
    }

    Teacher.inherit(Person);

    /*---------------------------Test classes functionality --------------------------*/
    var formTeacher = new Teacher("Doncho", "Minkov", 20, "JS");

    var firstStudent = new Student("Georgi", "Georgiev", 25, 3);
    var secondStudent = new Student("Ivan", "Ivanov", 35, 4);
    var thirdStudent = new Student("Nikolay", "Nikolov", 45, 5);
    var fourthStudent = new Student("Petyr", "Petrov", 55, 6);
    var students = [firstStudent, secondStudent, thirdStudent, fourthStudent];

    var jsAppsClass = new Classes("JS-Apps", 150, students, formTeacher);
    var telerikAcademy = new School("Telerik Academy", "Sofia", jsAppsClass);

    // Print teacher and students.
    console.log(formTeacher.introduce());
    console.log(firstStudent.introduce());
    console.log(secondStudent.introduce());
    console.log(thirdStudent.introduce());
    console.log(fourthStudent.introduce());
}());