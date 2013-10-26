$(document).ready(function () {
    var Student = function (firstName, lastName, grade) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.grade = grade;
    }

    // Create array of students
    var peter = new Student('Peter', 'Ivanov', 3);
    var milena = new Student('Milena', 'Grigorova', 6);
    var gergana = new Student('Gergana', 'Borisova', 12);
    var boyko = new Student('Boyko', 'Petrov', 7);

    var students = [peter, milena, gergana, boyko];

    var table = document.createElement('table');
    $('#tableContainer').append(table);
    $('#tableContainer table').append("<thead><td>First name</td><td>Last name</td><td>Grade</td></thead>");
    
    for (var i = 0; i < students.length; i++) {
        $('#tableContainer table').append("<tr><td>"
            + students[i].firstName + "</td><td>"
            + students[i].lastName + "</td><td>"
            + students[i].grade + "</td></tr>");
    }
});