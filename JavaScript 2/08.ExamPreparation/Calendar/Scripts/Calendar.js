(function () {
    /*------------------ Calendar ------------------*/
    function Calendar(name) {
        var months = [];
        this.months = months;
        this.name = name;
    }

    Calendar.prototype.addMonth = function (month) {
        this.months.push(month);
    }

    Calendar.prototype.addInSite = function (selector) {
        var calendarPlace = document.querySelector(selector);
        if (this.months.length > 0) {
            for (var i = 0; i < this.months.length; i++) {
                var monthElement = this.months[i].render(7);
                calendarPlace.appendChild(monthElement);
            }
        }
    }

    /*------------------ MONTH ------------------*/
    function Month(name) {
        var days = [];
        this.days = days;
        this.name = name;
    }

    Month.prototype.create = function (numberOfDays) {
        for (var i = 0; i < (numberOfDays * 1); i++) {
            var newDay = new Day(i + 1);
            this.days.push(newDay);
        }

        return this;
    }

    Month.prototype.render = function (numberOfElementsInRow) {
        var divMonthName = document.createElement('div');
        divMonthName.innerHTML = this.name;

        var divMonthContainer = document.createElement('div');
        divMonthContainer.className = 'month';
        divMonthContainer.appendChild(divMonthName);

        if (this.days.length > 0) {
            for (var i = 0; i < this.days.length; i++) {
                var divMonthRowContainer = document.createElement('div');
                for (var j = 0; j < (numberOfElementsInRow * 1) && i < this.days.length; j++, i++) {
                    var dayElement = this.days[i].render();
                    divMonthRowContainer.appendChild(dayElement);
                }
                i--;
                divMonthContainer.appendChild(divMonthRowContainer);
            }
        }

        return divMonthContainer;
    }

    /*------------------ DAY ------------------*/
    function Day(dayOfMonth) {
        var dayEvents = [];
        this.dayEvents = dayEvents;
        //var dayOfMonth;
        this.dayOfMonth = dayOfMonth;
    }

    //Day.prototype.create = function (dayOfMonth) {
    //    var newDay = new Day();
    //    newDay.dayOfMonth = dayOfMonth;
    //}

    Day.prototype.addEvent = function (eventDescription) {
        this.dayEvents.push(eventDescription);
    }

    Day.prototype.render = function () {
        var divElement = document.createElement('div');
        divElement.className = 'day';

        var anchorElement = document.createElement('a');
        anchorElement.innerHTML = this.dayOfMonth;
        anchorElement.href = '#';
        anchorElement.addEventListener('click', function (ev) {
            var currentElement = ev.target;
            var dayEvent = prompt('Enter your event here.');
            console.log(this);
            console.log(currentElement);
        }, false);

        if (this.dayEvents.length > 0) {
            anchorElement.style.cssText = 'color: red;';
        }

        divElement.appendChild(anchorElement);
        divElement.style.cssText = 'display: inline-block';
        return divElement;
    }

    /*------------------ COMMON FUNCTION ------------------*/
    function showEvents() {

    }

    /*------------------ TESTS ------------------*/

    var monthTest = new Month('January');
    var justMonth = monthTest.create(31);

    var monthTest1 = new Month('February');
    var justMonth1 = monthTest1.create(29);

    var monthTest2 = new Month('March');
    var justMonth2 = monthTest2.create(30);

    var justCalendar = new Calendar('justCalendar');
    justCalendar.addMonth(justMonth);
    justCalendar.addMonth(justMonth1);
    justCalendar.addMonth(justMonth2);
    justCalendar.addInSite('#calendar-holder', 2);
}());