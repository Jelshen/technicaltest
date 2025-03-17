var customerMap = {}; 

$(document).ready(function () {
    var originalDate;

    fetchCustomers();

    var table = $('#salesTable').DataTable({
        "ajax": {
            "url": "/api/SalesOrder/",
            "type": "GET",
            "datatype": "json",
            "dataSrc": ""
        },
        "dom": "lrtip",
        "columnDefs": [
            { "className": "text-center", "targets": "_all" }
        ],
        "columns": [
            {
                "data": null, "render": function (data, type, row, meta) {
                    return meta.row + 1;
                }
            },
            {
                "data": null, "render": function (data, type, row) {
                    return `<button id="editSalesOrder" class="bg-green-500 text-white px-2 py-1 rounded hover:bg-green-600">Edit</button>
                            <button id="deleteSalesOrder" class="bg-red-500 text-white px-2 py-1 rounded hover:bg-red-600">Delete</button>`;
                }
            },
            { "data": "orderNo" },
            {
                "data": "orderDate",
                "render": function (data, type, row) {
                    originalDate = data.split('T')[0];
                    return formatDate(originalDate);
                }
            },
            {
                "data": "comCustomerId",
                "render": function (data) {
                    return getCustomerName(data);
                }
            }
        ],
        "responsive": true,
        "language": {
            "emptyTable": "No orders available"
        },
        searching: true
    });

    $('#searchBtn').on('click', function () {
        searchTable(table);
    });

    $('#salesTable').on('click', '#editSalesOrder', function () {
        var data = $("#salesTable").DataTable().row($(this).parents("tr")).data();

        if (data) {
            window.location.href = "/SalesOrder/AddNewData?soOrderId=" + data.soOrderId;
        }
    });

});

function searchTable(table) {
    var keyword = $('#keywordSearch').val().trim();
    var orderDate = $('#orderDate').val().trim();

    console.log("Searching... Keyword:", keyword, "Order Date:", orderDate);

    // Clear previous searches
    table.search('').columns().search('');

    // Apply search filters
    table
        .search(keyword || "")
        .columns(3).search(orderDate ? formatDate(orderDate) : "")
        .draw();
}

function formatDate(dateTimeString) {
    if (!dateTimeString) return ""; // Handle empty values

    let date = new Date(dateTimeString);

    // Return original if invalid date
    if (isNaN(date.getTime())) return dateTimeString;

    let day = date.getDate().toString().padStart(2, "0");
    let month = (date.getMonth() + 1).toString().padStart(2, "0"); // Months are 0-based
    let year = date.getFullYear();

    return `${day}/${month}/${year}`;
}
function fetchCustomers() {
    $.ajax({
        url: "/api/SalesOrderItems/GetCustomers",
        type: "GET",
        success: function (data) {
            customerMap = Object.fromEntries(data.map(customer => [customer.id, customer.name]));
        },
        error: function (xhr, status, error) {
            console.error("Error fetching customers:", error);
        }
    });
}

function getCustomerName(customerId) {
    return customerMap[customerId] || "Unknown Customer";
}
