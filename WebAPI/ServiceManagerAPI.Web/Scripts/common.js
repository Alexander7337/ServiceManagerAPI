var uri = "";

//$(document).ready(function () {
//    uri = loadUri('services');
//    loadServices(uri)
//});

function loadServices(input) {
    //var uri = loadUri(input);

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
            url: uri,
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
};

function loadUri(uri) {
    return 'api/' + uri;
}

function updateItem() {
    var id = $('#serviceId').val();
    var serviceName = $('#serviceName').val();
    var description = $('#description').val();
    var service = new Object();
    service.ServiceName = serviceName;
    service.Description = description;
    var json = JSON.stringify(service);

    //var uri = loadUri('services')
    $.ajax({
        url: uri + '/' + id,
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
    //var uri = loadUri('services');
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
    //var uri = loadUri('services');

    $.ajax({
        url: uri + '/' + id,
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
    if (item.ServiceName !== undefined) {
        return item.ServiceName + ': ' + item.Description;
    }
    return item.OrderName + ': ' + item.Description;
}