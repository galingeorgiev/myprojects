/// <reference path="Class.js" />
var studentVizualizationTest = (function(){
    var Person = Class.create({
        init: function (firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        },
        draw: function (container) {
            var element = $(container).append($("<li />").html(this.firstName + this.lastName));
            return element;
        }
    });

    var Student = Person.extend({
        init: function (firstName, lastName, mark) {
            this._super(firstName, lastName)
            this.mark = mark;
        },
        draw: function (container) {
            $(container).append(
                $("<ul />")
                .append($("<li />")
                .html(this.firstName + this.lastName + this.mark)));
        }
    });

    var pesho = new Student();
    pesho.init("Pesho", "Petrov", 3);
    pesho.draw("#data");

    var ivan = new Person();
    ivan.init("ivan", "ivanov");
    ivan.draw("#data");


    var response = '';

    //$.ajax({
    //    type: "POST",
    //    url: "http://localhost:50735/api/datav/add",
    //    data: JSON.stringify({hdkashd: "alabalanica"}),
    //    contentType: "application/json"
    //    //async: false,
    //    //success: function (text) {
    //    //    response = text;
    //    //}
    //});

    //$.ajax({
    //    type: "GET",
    //    url: "http://localhost:50735/api/datav/getstudents",
    //    async: false,
    //    success: function (text) {
    //        //response = text;
    //        console.log(text);
    //        response = JSON.parse(text);
    //        console.log(response);
    //        $('#data').append($('<ul />'));
    //        if (text) {
    //            for (var i = 0; i < response.length; i++) {
    //                $('#data ul').append($('<li />').text(response[i]));
    //            }
    //        }
    //    }
    //});

    //$("#data").text(response);
}());