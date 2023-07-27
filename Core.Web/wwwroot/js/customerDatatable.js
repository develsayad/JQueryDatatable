$(document).ready(function () {


    $('#customerDatatable').DataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/home/GetAllCustomers",
            "type": "post",
            "dataType": "json",

        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": true,
                "searchable": false
            }
        ],
        "columns": [
            { "data": "id", "name": "Id", "autoWidth": true },
            { "data": "firstName", "name": "First Name", "autoWidth": true },
            { "data": "lastName", "name": "Last Name", "autoWidth": true },
            { "data": "contact", "name": "Contact", "autoWidth": true },
            { "data": "email", "name": "Email", "autoWidth": true },
            { "data": "dateOfBirth", "name": "Date Of Birth", "autoWidth": true },
            {
                "render": function (data, row) {
                    var btnDelete = `<a class='btn btn-danger btn-xs' onclick="alert(${row})""> Delete</a>`
                    return btnDelete;
                }
            },
        ]



    });

});