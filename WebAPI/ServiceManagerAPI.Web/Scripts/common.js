$(function () {
    var uri = 'api/services';

    $(document).ready(function () {
        $.getJSON(uri)
            .done(function (data) {
                // On success, 'data' contains a list of services.
                $.each(data, function (key, item) {
                    // Add a list item for the services.
                    var serviceId = getItemID(item);
                    $('<li onclick="deleteItemByID(' + serviceId + ')">').text(formatItem(item)).attr({ id: serviceId }).appendTo($('#services'));
                });
            });
    });

    $("#serviceForm").submit(function () {
        $.ajax({
            url: 'api/services',
            type: 'POST',
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                var loc = jqxhr.getResponseHeader('Location');
                var a = $('<a/>', { href: loc, text: loc });
                $('#message').html(a);
            },
            error: function () {
                $('#message').html("Error posting the update.");
            }
        });
        return false;
    });
});

function updateItem() {
    var id = $('#serviceId').val();
    var serviceName = $('#serviceName').val();
    var description = $('#description').val();
    var service = new Object();
    service.ServiceName = serviceName;
    service.Description = description;
    var json = JSON.stringify(service);

    $.ajax({
        url: 'api/services/' + id,
        type: 'PUT',
        dataType: 'json',
        data: { serviceName: serviceName, description: description },
        success: function (data, textStatus, jqxhr) {
            console.log(data);
            setTimeout(function () {
                location.reload();
            }, 1000);
        },
        error: function (jqxhr, textStatus, error) {
            console.log(error);
        }
    })
}

function findServiceByID() {
    var uri = 'api/services';
    var id = $('#serviceId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#service').text(formatItem(data));
            $('#serviceName').val(data.ServiceName);
            $('#description').val(data.Description);
        })
        .fail(function (jqxhr, textStatus, errorThrown) {
            $('#service').text('Error: ' + errorThrown);
        });
}

function deleteItemByID(serviceId) {
    var id = serviceId;

    $.ajax({
        url: 'api/services/' + id,
        type: 'DELETE',
        dataType: 'json',
        data: id,
        success: function (data, textStatus, jqxhl) {
            setTimeout(function () {
                location.reload();
            }, 1000);
        },
        error: function (jqxhr, textStatus, errorThrown) {
            console.log('Error: ' + errorThrown);
        }
    });
}

function getItemID(item) {
    return item.Id;
}

function formatItem(item) {
    return item.ServiceName + ': ' + item.Description;
}