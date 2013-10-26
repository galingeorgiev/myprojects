/// <reference path="../Scripts/mustache.js" />
/// <reference path="../Scripts/underscore.js" />
/// <reference path="../Scripts/jquery-2.0.3.js" />
var Student = Class.create({
    init: function (fname, lname, marks, city, facultyNumber) {
        this.fname = fname;
        this.lname = lname
        this.marks = marks;
        this.city = city;
        this.facultyNumber = facultyNumber;
    },
    fullname: function () {
        return this.fname + " " + this.lname;
    }
});

var Mark = Class.create({
    init: function (subject, score) {
        this.subject = subject;
        this.score = score;
    }
});

var people = {
    students: [
                new Student("Doncho", "Minkov", [new Mark("Math", 4), new Mark("JavaScript", 6)], "Burgas", 12345),
                new Student("Nikolay", "Kostov", [new Mark("MVC", 6), new Mark("JavaScript", 5)], "Sofia", 34545),
                new Student("Ivaylo", "Kendov", [new Mark("OOP", 4), new Mark("C#", 6)], "Plovdiv", 78656),
                new Student("Svetlin", "Nakov", [new Mark("Unit Testing", 5), new Mark("WPF", 6)], "Sofia", 68768),
                new Student("Asya", "Georgieva", [new Mark("Automation Testing", 6), new Mark("Manual Testing", 4)], "Stara Zagora", 76987),
                new Student("Georgi", "Georgiev", [new Mark("Automation Testing", 4), new Mark("Manual Testing", 6)], "Stara Zagora", 87865)
    ]
};

var i = 0;

var studentBasicTemplate =
    "{{#students}}<ul>"
    + "<li data-position='{{fullname}}'>{{fullname}}</li>"
    + "</ul>{{/students}}";

var studentsDetailInfo =
    "<ul><li>Name: {{fullname}}</li>" +
    "<li>City: {{city}}</li>" +
    "<li>Faculty number: {{facultyNumber}}</li>" +
        "<li>Marks" +
            "{{#marks}}" +
                "<ul>" +
                    "<li>" +
                        "Subject: {{subject}} - score: {{score}}" +
                    "</li>" +
                "</ul>" +
            "{{/marks}}" +
        "</li>" +
    "</ul>";

var basicInfoOutput = Mustache.render(studentBasicTemplate, people);

$(document).ready(function ($) {
    $("#student-basic").html(basicInfoOutput);

    $("#student-basic").on("click", "ul li", function () {
        var fullName = $(this).attr("data-position");
        var currentStudent = _.chain(people.students)
            .filter(function (student) {
            return student.fullname() == fullName;
            })
            .first()
            .value();

        var studentDetails = Mustache.render(studentsDetailInfo, currentStudent);
        $("#student-details").html(studentDetails);
    })
});