var uri = "";

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
    var order = new Object();
    order.OrderName = serviceName;
    order.Description = description;
    var json = JSON.stringify(service);

    //var uri = loadUri('services')
    if (uri.includes('orders')) {
        $.ajax({
            url: uri + '/' + id,
            type: 'PUT',
            dataType: 'json',
            data: { orderName: serviceName, description: description },
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
    } else if (uri.includes('services')) {
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
    
}

function findServiceByID() {
    //var uri = loadUri('services');
    var id = $('#serviceId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#service').text(formatItem(data));
            if (data.ServiceName !== undefined) {
                $('#serviceName').val(data.ServiceName);
            } else if (data.OrderName !== undefined) {
                $('#serviceName').val(data.OrderName);
            } else if (data.CustomerName !== undefined) {
                $('#serviceName').val(data.CustomerName);
            } else if (data.EmployeeName !== undefined) {
                $('#serviceName').val(data.EmployeeName);
            }
            
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
    } else if (item.OrderName !== undefined) {
        return item.OrderName + ': ' + item.Description;
    } else if (item.CustomerName !== undefined) {
        return item.CustomerName;
    } else if (item.EmployeeName !== undefined) {
        return item.EmployeeName;
    }
    return "Item's property was not found";
}