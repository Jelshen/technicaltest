var currentSoOrder;
var id;
var orderData;
var order;

$(document).ready(async function () {
    await populateCustomerDropdown();

    orderData = $("#orderData").val();

    if (orderData) {
        console.log("inside the orderData if clause");
        order = JSON.parse(orderData);

        // Populate fields
        $("#salesOrderNumber").val(order.orderNo);
        $("#customerDropdown").val(order.comCustomerId).trigger("change");
        $("#orderDate").val(formatDate(order.orderDate));
        $("#address").val(order.address);
    }

    id = order ? order.soOrderId : 0;
    console.log(id);

    let table = $("#itemsTable").DataTable({
        "destroy": true,
        "ajax": {
            "url": "/api/SalesOrderItems/GetSoOrder?soOrderId=" + id,
            "type": "GET",
            "datatype": "json",
            "dataSrc": function (json) {
                return json.data || [];
            }
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
                "data": null, "render": function () {
                    return `<button id="editSalesOrderItem" class="bg-green-500 text-white px-2 py-1 rounded hover:bg-green-600">Edit</button>
                            <button id="deleteSalesOrderItem" class="bg-red-500 text-white px-2 py-1 rounded hover:bg-red-600">Delete</button>`;
                }
            },
            { "data": "itemName" },
            { "data": "quantity" },
            { "data": "price" },
            {
                "data": "total",
                "render": function (data, type, row) {
                    let quantity = row.quantity || 0;
                    let price = row.price || 0;
                    return quantity * price;
                }
            }
        ],
        "responsive": true,
        "language": {
            "emptyTable": "No orders available"
        },
        searching: true
    });

    $("#addNewData").on("click", function () {
        addNewData(table);
    });

    $("#close").on("click", function () {
        console.log('close button clicked');
        window.location.href = "/SalesOrder/Index";
    });
});

function getCurrentSoOrder(soOrderName) {
    return new Promise((resolve) => {

        if (!soOrderName) {
            resolve(null);
            return;
        }

        $.ajax({
            url: "/api/SalesOrder/GetOrderByName?soOrderName=" + soOrderName,
            type: "GET",
            success: function (data) {
                resolve(data);
            },
            error: function (xhr, status, error) {
                resolve(null);
            }
        });
    })
}

function addNewData(table) {
    table.row.add({
        "itemName": '<input type="text" class="itemName" placeholder="Enter Item Name">',
        "quantity": '<input type="number" class="qty" placeholder="Qty" min="1">',
        "price": '<input type="number" class="price" placeholder="Price" min="0">',
        "total": '<span class="total">0</span>',
        "actions": '<button class="saveRowBtn">Save</button> <button class="deleteRowBtn">Delete</button>'
    }).draw(false);
}

function populateCustomerDropdown() {
    $.ajax({
        url: "/api/SalesOrderItems/GetCustomers",
        type: "GET",
        success: function (data) {
            var dropdown = $("#customerDropdown");
            dropdown.empty();
            dropdown.append('<option selected disabled>Select a Customer</option>');

            $.each(data, function (index, customer) {
                dropdown.append($('<option></option>').val(customer.id).text(customer.name));
            });
        },
        error: function (xhr, status, error) {
            alert("Error fetching customers:", error);
        }
    });
}

function formatDate(dateTimeString) {
    // Handle empty values
    if (!dateTimeString) return ""; 

    let date = new Date(dateTimeString);

    // Return original if invalid date
    if (isNaN(date.getTime())) return dateTimeString; 

    let year = date.getFullYear();
    let month = (date.getMonth() + 1).toString().padStart(2, "0"); // Months are 0-based
    let day = date.getDate().toString().padStart(2, "0");

    return `${year}-${month}-${day}`; // Format for HTML date input
}
