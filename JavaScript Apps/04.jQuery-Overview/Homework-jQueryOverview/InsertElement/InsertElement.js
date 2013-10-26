$(document).ready(function () {
    var counter = 1;
    var beforeElement = $('<div>Insert Before</div>').bind('click', function () {
        $('<p>' + counter++ + '</p>').insertBefore(this);
    });
    var afterElement = $('<div>Insert After</div>').bind('click', function () {
        $('<p>' + counter++ + '</p>').insertAfter(this);
    });
    var contentElement = $('<div>0</div>');
    $('body').append(contentElement);
    $(beforeElement).insertBefore('div');
    $(afterElement).insertAfter('div:last-of-type');
});