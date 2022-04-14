var dataTable;

$(document).ready(function () {
    debugger;
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_LOAD').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype":"json"
        },
        "columns": [
            { "data": "Id", "width": "30%" },
            { "data": "Name", "width": "30%" },
            { "data": "Author", "width": "30%" },
            { "data": "Quantity", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            < div class="text-center" >
                                <a href="Books/EditBook?id=${data}" class="btn btn-success text-white" style="cursor:pointer;width:100px;">Edit</a>
                                &nbsp;&nbsp;
                            <a href="Books/DeleteBook?id=${data}" class="btn btn-danger text-white" style="cursor:pointer;width:100px;">Delete</a>
                            </div>
                            `
                },"width":"30%"
            }
        ],
        "language": {
            "emptyTable":"no data found"
        },
        "width":"100%"
    });
}