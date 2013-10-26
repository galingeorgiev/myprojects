(function () {
    /*---------------------------Create classes --------------------------*/
    var School = {
        init: function (name, town, classes) {
            this.name = name;
            this.town = town;
            this.classes = classes;
        }
    };

    var Classes = {
        init: function (name, capacity, setOfStudents, formTeacher) {
            this.name = name;
            this.capacity = capacity;
            this.setOfStudents = setOfStudents;
            this.formTeacher = formTeacher;
        }
    };

    var Person = {
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        },
        introduce: function () {
            return "Name: " + this.firstName + " " + this.lastName + ", age: " + this.age;
        }
    };

    var Student = Person.extend({
        init: function (firstName, lastName, age, grade) {
            Person.init.apply(this, arguments);
            this.grade = grade;
        },
        introduce: function () {
            return Person.introduce.apply(this, arguments) + ", grade: " + this.grade;
        }
    });

    var Teacher = Person.extend({
        init: function (firstName, lastName, age, speciality) {
            Person.init.apply(this, arguments);
            this.speciality = speciality;
        },
        introduce: function () {
            return Person.introduce.apply(this, arguments) + ", speciality: " + this.speciality;
        }
    });

    /*---------------------------Test classes functionality --------------------------*/
    // Create school, class and teacher.
    var telerikAcademy = Object.create(School);
    var jsAppsClass = Object.create(Classes);
    var formTeacher = Object.create(Teacher);
    formTeacher.init("Doncho", "Minkov", 20, "JS");

    // Create students and put it in array of students.
    var firstStudent = Object.create(Student);
    firstStudent.init("Georgi", "Georgiev", 25, 3);

    var secondStudent = Object.create(Student);
    secondStudent.init("Ivan", "Ivanov", 35, 4);

    var thirdStudent = Object.create(Student);
    thirdStudent.init("Nikolay", "Nikolov", 45, 5);

    var fourthStudent = Object.create(Student);
    fourthStudent.init("Petyr", "Petrov", 55, 6);

    var students = [firstStudent, secondStudent, thirdStudent, fourthStudent];

    // Init class and school.
    jsAppsClass.init("JS-Apps", 150, students, formTeacher);
    telerikAcademy.init("Telerik Academy", "Sofia", jsAppsClass);

    // Print teacher and students.
    console.log(formTeacher.introduce());
    console.log(firstStudent.introduce());
    console.log(secondStudent.introduce());
    console.log(thirdStudent.introduce());
    console.log(fourthStudent.introduce());
}());