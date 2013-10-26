/// <reference path="../Scripts/jquery-2.0.2.js" />
$(document).ready(function () {
    var ListGenerator = function (listContent, numberOfElements) {
        var ulElement = $('<ul></ul>');
        var i = 0;
        for (i = 1; i <= numberOfElements; i++) {
            ulElement.append($('<li>' + listContent + i + '</li>'));
        }

        return ulElement;
    }

    var mainList = new ListGenerator('Item', 5);
    var subList = new ListGenerator('Sub Item', 4);
    var subSubItem = new ListGenerator('Sub sub item', 6);
    $('body').append(mainList);
    $('ul li').append(subList);
    $('ul li ul li').append(subSubItem);

    $('li').on('click', function () {
        event.stopPropagation();
        if (!($(this).children('ul')[0].className)) {
            $(this).children('ul').addClass('expanded');
        }
        else {
            $(this).children('ul').removeClass('expanded');
        }
    });
});