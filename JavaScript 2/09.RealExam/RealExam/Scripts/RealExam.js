(function () {
    /*------------------------ Escaping of the strings ------------------------*/
    String.prototype.escape = function () {
        var tagsToReplace = {
            '&': '&amp;',
            '<': '&lt;',
            '>': '&gt;'
        };
        return this.replace(/[&<>]/g, function (tag) {
            return tagsToReplace[tag] || tag;
        });
    }

    /*Without this throw exception because Numbers haven't method escape.*/
    Number.prototype.escape = function () {
        return this;
    }

    /*------------------------ Grid view ------------------------*/
    function GridView() {
        var header;
        var rows = [];
        var selector;
        this.header = header;
        this.rows = rows;
        this.selector = selector;
    }

    GridView.prototype.insertTo = function (selector) {
        this.selector = selector;
    }

    GridView.prototype.addHeader = function () {
        var header = new Header();
        header.addHeader(arguments);

        this.header = header;
    }

    GridView.prototype.addRow = function () {
        var newRow = new Row();
        var currentRowElements = newRow.addElements(arguments);

        this.rows.push(currentRowElements);

        return newRow;
    }

    GridView.prototype.render = function () {
        var gridHolder = document.querySelector(this.selector);

        /*Used for nested grid, because we haven't selector*/
        if (!this.selector) {
            gridHolder = document.createElement('div');
            gridHolder.className = 'nested-grid-view';
        }

        if (this.header) {
            var headerElement = this.header.render();
            gridHolder.appendChild(headerElement);
        }

        if (this.rows.length > 0) {
            for (var i = 0; i < this.rows.length; i++) {
                var currRow = this.rows[i].render();
                gridHolder.appendChild(currRow);
            }
        }

        /*Used for nested grid, because we have not selector*/
        if (!this.selector) {
            return gridHolder;
        }
    }

    /*------------------------ Header ------------------------*/
    function Header() {
        var headerElements = [];
        this.headerElements = headerElements;
    }

    Header.prototype.addHeader = function (args) {
        for (var i = 0; i < args.length; i++) {
            this.headerElements.push(args[i]);
        }

        return this;
    }

    Header.prototype.render = function () {
        var headerContainer = document.createElement('div');
        headerContainer.className = 'grid-header';
        
        if (this.headerElements.length > 0) {
            for (var i = 0; i < this.headerElements.length; i++) {
                var headerElemetn = document.createElement('div');
                headerElemetn.className = 'header-element';
                headerElemetn.innerHTML = this.headerElements[i].escape();
                headerContainer.appendChild(headerElemetn);
            }
        }

        return headerContainer;
    }

    /*------------------------ Rows ------------------------*/
    function Row() {
        var rowElements = [];
        this.rowElements = rowElements;
        var nestedGridView;
        this.nestedGridView = nestedGridView;
    }

    Row.prototype.addElements = function (args) {
        for (var i = 0; i < args.length; i++) {
            this.rowElements.push(args[i]);
        }

        return this;
    }

    Row.prototype.render = function () {
        var rowContainer = document.createElement('div');
        rowContainer.className = 'grid-row collapsed';

        /*add function for collapse-expand*/
        rowContainer.addEventListener('click', function (ev) {
            if (!ev) {
                ev = window.event;
            }
            ev.stopPropagation();
            ev.preventDefault();

            if (rowContainer.className == 'grid-row collapsed') {
                rowContainer.className = 'grid-row expanded';
            }
            else {
                rowContainer.className = 'grid-row collapsed';
            }
        }, false);

        if (this.rowElements.length > 0) {
            for (var i = 0; i < this.rowElements.length; i++) {
                var rowElemetn = document.createElement('div');
                rowElemetn.className = 'row-element';
                rowElemetn.innerHTML = this.rowElements[i].escape();
                rowContainer.appendChild(rowElemetn);
            }
        }

        /*Check for nested grid*/
        if (this.nestedGridView) {
            var nestedGrid = this.nestedGridView.render();
            rowContainer.appendChild(nestedGrid);
        }
        
        return rowContainer;
    }

    Row.prototype.addNestedGridView = function () {
        var nestedGrid = new GridView();
        this.nestedGridView = nestedGrid;
        
        return nestedGrid;
    }

    /*------------------------ Test tasks 1, 2, 3 ------------------------*/
    var schoolGrid = new GridView();
    schoolGrid.insertTo('#grid-view-holder');
    schoolGrid.addHeader('Name <hr />', 'Logation', 'Total Students', 'Speciality');
    schoolGrid.addRow('PMG', 'Burgas', '400', 'Math');
    schoolGrid.addRow('Telerik Academy', 'Sofia', '400', 'Math');
    schoolGrid.addRow('Tues', 'Sofia', '500', 'Math');
    /*Add nested grid*/
    var rowWithNestedGrid = schoolGrid.addRow('UNSS', 'Sofia', '1000', 'Math');
    var nestedGridView = rowWithNestedGrid.addNestedGridView();
    nestedGridView.addHeader('Name', 'Logation', 'Total Students', 'Speciality');
    nestedGridView.addRow('PMG', 'Burgas', '400', 'Math');
    nestedGridView.addRow('Telerik Academy', 'Sofia', '400', 'Math');
    nestedGridView.addRow('Tues', 'Sofia', '500', 'Math');

    schoolGrid.render();

    /*------------------------ Task 4 ------------------------*/
    function school(name, location, numberOfCourses, speciality, setOfCorses) {
        this.schoolName = name;
        this.schoolLocation = location
        this.numberOfCourses = numberOfCourses;
        this.speciality = speciality;
        this.setOfCorses = setOfCorses;
    }

    function course(title, startDate, totalStudents, setOfStudents) {
        this.courseTitle = title;
        this.startDate = startDate;
        this.totalStudents = totalStudents;
        this.setOfStudents = setOfStudents;
    }

    function student(firstName, lastName, grade, mark) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.grade = grade;
        this.mark = mark;
    }

    function schoolsRepository() {
        this.school = [];
    }

    schoolsRepository.prototype.save = function (repositoryName, schoolData) {
        var jsonObjToStr = JSON.stringify(schoolData);
        this.school[repositoryName] = jsonObjToStr;
    }

    schoolsRepository.prototype.load = function (repositoryName) {
        var convertToJson = JSON.parse(this.school[repositoryName]);
        return convertToJson;
    }

    /*------------------------ Task 4 tests ------------------------*/
    var students = [];
    var firstStudent = new student('Georgi', 'Georgiev', 'math', 6);
    var secondStudent = new student('Ivan', 'Ivanov', 'math', 6);
    students.push(firstStudent);
    students.push(secondStudent);
    //console.log(students);

    var courses = [];
    var firstCourse = new course('C#', '15 january', 2, students);
    var secondCourse = new course('JS', '15 january', 2, students);
    courses.push(firstCourse);
    courses.push(secondCourse);
    //console.log(courses);
    var schoolRepository = new schoolsRepository();

    var schools = [];
    var testSchoolData = new school('Telerik Academy', 'Sofia', 2, 'programing', courses);
    schools.push(testSchoolData);
    schools.push(testSchoolData); // added two times because I want to have at least two rows in new table. I use this array in task 6.
    //console.log(testSchoolData);

    schoolRepository.save('schools-repository', testSchoolData);
    var data = schoolRepository.load('schools-repository');
    console.log('Task 4');
    console.log(data);
    console.log('---------------------------------------------------------------------------------------------');

    /*------------------------ Task 5 ------------------------*/
    GridView.prototype.getGridViewData = function () {
        if (this.rows) {
            var allGridData = [];
            for(var i = 0; i < this.rows.length; i++) {
                var currentSchoolData = this.rows[i].rowElements;
                var currentSchool;
                if (currentSchoolData.length == 4) {
                    currentSchool = new school(currentSchoolData[0], currentSchoolData[1], currentSchoolData[2], currentSchoolData[3]);
                }

                if (currentSchoolData.length == 5) {
                    currentSchool = new school(currentSchoolData[0], currentSchoolData[1], currentSchoolData[2], currentSchoolData[3], currentSchoolData[4]);
                }

                allGridData.push(currentSchool);
            }

            return allGridData;
        }
    }

    /*------------------------ Task 5 tests ------------------------*/
    var dataFromGridView = schoolGrid.getGridViewData();
    schoolRepository.save('school-repository-data-from-grid-view', dataFromGridView);

    console.log('Task 5');
    console.log('Used function schoolRepository.load.');
    console.log(schoolRepository.load('school-repository-data-from-grid-view'));

    console.log('Used function getGridViewData.');
    console.log(dataFromGridView);
    console.log('---------------------------------------------------------------------------------------------');

    /*------------------------ Task 6 ------------------------*/
    GridView.prototype.buildGridView = function (selector, schoolsData) {
        var newGrid = new GridView();
        newGrid.insertTo(selector);
        newGrid.addHeader('Name', 'Logation', 'Total Students', 'Speciality');

        if (schoolsData) {
            for (var i = 0; i < schoolsData.length; i++) {
                var currntRow = newGrid.addRow(schoolsData[i].schoolName,
                    schoolsData[i].schoolLocation,
                    schoolsData[i].numberOfCourses,
                    schoolsData[i].speciality);

                if (schoolsData[i].setOfCorses) {
                    var coursesNestedGrid = currntRow.addNestedGridView();
                    coursesNestedGrid.addHeader('Name', 'Start date', 'Total Students');

                    for (var j = 0; j < schoolsData[i].setOfCorses.length; j++) {
                        var coursesNestedGridRow = coursesNestedGrid.addRow(schoolsData[i].setOfCorses[j].courseTitle,
                            schoolsData[i].setOfCorses[j].startDate,
                            schoolsData[i].setOfCorses[j].totalStudents);

                        if (schoolsData[i].setOfCorses[j].setOfStudents) {
                            var studentNestedGrid = coursesNestedGridRow.addNestedGridView();
                            studentNestedGrid.addHeader('First name', 'Last Name', 'Grade', 'Mark');

                            for (var z = 0; z < schoolsData[i].setOfCorses[j].setOfStudents.length; z++) {
                                studentNestedGrid.addRow(schoolsData[i].setOfCorses[j].setOfStudents[z].firstName,
                                    schoolsData[i].setOfCorses[j].setOfStudents[z].lastName,
                                    schoolsData[i].setOfCorses[j].setOfStudents[z].grade,
                                    schoolsData[i].setOfCorses[j].setOfStudents[z].mark);
                            }
                        }
                    }
                }
            }
        }
        
        newGrid.render();
    }

    /*------------------------ Task 6 tests ------------------------*/
    var schoolTestGridView = new GridView();
    schoolTestGridView.buildGridView('#grid-view-holder-schools-test', schools)
    //console.log(schools);
}());