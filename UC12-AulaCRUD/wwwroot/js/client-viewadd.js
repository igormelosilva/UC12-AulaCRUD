$(document).ready(function () {

    $('#frmClients').on('submit', function (e) {
        Add(e);
    });
});

function Add(e){
    e.preventDefault();

    var operation = $('#btnSave').attr('operation');
    var itemId = $('#btnSave').attr('itemId');
    var commandUrl = '';

    if (operation == 'add') {
        commandUrl = '/Client/Add';
    }
    else if (operation == 'upd') {
        commandUrl = '/Client/Update';
    }

    var formData = {
        id: parseInt(itemId),
        name: $('#txtName').val(),
        phone: $('#txtPhone').val(),
        email: $('#txtEmail').val()
    };

    $.ajax({
        url: commandUrl,
        type: 'POST',
        data: JSON.stringify(formData),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',

        success: function (data) {

            alert(data.message);

            if (data.success)
                window.open('/Client/ViewList');
        }
    });
}