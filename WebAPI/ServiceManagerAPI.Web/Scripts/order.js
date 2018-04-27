$(function () {
    $("body").children().each(function () {
        $(this).html($(this).html().replace(new RegExp('element', 'g'), 'new'));
    });
});
