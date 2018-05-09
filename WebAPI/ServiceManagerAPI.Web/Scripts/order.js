$(function () {
    $("body").children().each(function () {
        $(this).html($(this).html().replace(new RegExp('Services', 'g'), 'Orders'));
        $(this).html($(this).html().replace(new RegExp('Service Name', 'g'), 'Order Name'));
        $(this).html($(this).html().replace(new RegExp('/api/services', 'g'), '/api/orders'));
        $(this).html($(this).html().replace(new RegExp('a Service', 'g'), 'an Order'));
    });
});

$(document).ready(function () {
    uri = loadUri('orders');
    loadServices(uri)
});

