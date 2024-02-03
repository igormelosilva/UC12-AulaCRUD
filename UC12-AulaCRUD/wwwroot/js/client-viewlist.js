$(document).ready(function () {
    LoadProducts();
    $('#tbClients').on('click', '.btnDelete', function (e) {
        DeleteProduct(e);
    });
});

function LoadProducts() {
    new DataTable('#tbClients', {
        ajax: {
            url: '/Client/GetAll',
            type: 'GET'
        },
        columns: [
            { data: 'name' },
            { data: 'phone' },
            { data: 'email' },
            {
                data: '',
                render: (data, type, row) => {
                    return '<a href="/Client/Edit?id=' + row.id + '" class="btn btn-primary">Editar</a>\
                            <button type="submit" itemId="' + row.id + '" class="btn btn-danger btnDelete">Excluir</button>';
                }
            }
        ],

        ordering: true,
        paging: true
    });
}

function EditProduct(e) {
    var id = parseInt($(e.target).attr('itemId'));
    $.ajax({
        url: '/Client/Edit',
        type: 'POST',
        data: JSON.stringify(id),
        contentType: 'application/json; charset=utf-8'
    });
}
function DeleteProduct(e) {
    var id = ($(e.target).attr('itemId'));
    $.ajax({
        url: '/Client/Delete',
        type: 'POST',
        data: JSON.stringify(id),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',

        success: function (data) {
            if (data.success) {
                alert(data.message);
                window.location.href = '/Client/ViewList';
            }
        }
    });
}