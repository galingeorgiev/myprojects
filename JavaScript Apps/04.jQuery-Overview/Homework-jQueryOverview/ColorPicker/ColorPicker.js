$(document).ready(function () {
    $('body').bind('input', function () {
        $('body').load();
        var color = $("input").val();
        $("body").css({ 'background-color': color });
    });
});

