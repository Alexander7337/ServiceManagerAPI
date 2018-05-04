$(function () {
    $("body").children().each(function () {
        $(this).html($(this).html().replace(new RegExp('Services', 'g'), 'Customers'));
        $(this).html($(this).html().replace(new RegExp('Service Name', 'g'), 'Customers Name'));
        $(this).html($(this).html().replace(new RegExp('/api/services', 'g'), '/api/customers'));
        $(this).html($(this).html().replace(new RegExp('a Service', 'g'), 'a Customer'));
    });
});

$(document).ready(function () {
    uri = loadUri('customers');
    loadServices(uri)
});