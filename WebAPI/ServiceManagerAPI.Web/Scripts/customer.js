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

function getDataFromDB() {
    var customerId = $('#customerId').val();

    $.ajax({
        type: 'GET',
        url: uri + '/' + customerId + '/GetCustomerOrders',
        contentType: 'application/json',
        dataType: 'json',
        success: function (data) {
            $();
            var json = $.parseJSON(JSON.stringify(data));
            var html = '';
            for (var i = 0; i < json.length; i++) {
                html += '<tr class="orderRow">';
                $.each(json[i], function (key, value) {
                    var name = '';
                    var description = '';
                    if (key === 'OrderName' || key === 'CustomerName') {
                        name = value;
                    } else if (key === 'Description') {
                        description = value;
                    }
                    html += '<td>' + name + '</td>'
                    html += '<td>' + description + '</td>'
                });
                html += '</tr>';
            }
            $('#tableOrders').append(html);
            $('#tableOrders').removeAttr('hidden')
        },
        error: function (ex) {
            var r = $.parseJSON(response.responseText);
            alert("Message: " + r.Message);
        }
    });
}