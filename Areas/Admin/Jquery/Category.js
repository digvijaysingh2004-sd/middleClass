$('#SaveUpdate').click(function () {
    debugger;
    var category = {
        ID: $('#HID').val(),
        CategoryName: $('#CategoryName').val(),
    };

    $.ajax({
        url: 'SaveCategoryUpdate',
        type: 'POST',
        data: category,
        success: function (response) {
            Swal.fire({
                title: "Good job!",
                text: "Added successfully!",
                icon: "success"
            }).then((result) => {
                if (result.isConfirmed) {
                    location.reload();
                }
            });
        },
        error: function (response) {
            alert("An error occurred while saving the Category");
        }
    });
});

function Edit(ID) {
    debugger;
    var ID = ID;
    $.ajax({
        url: 'GetCategoryById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#CategoryName').val(data.CategoryName);
                $('#SaveUpdate').text('Update').removeClass('btn-soft-primary fa-light fa-plus').addClass('btn-soft-info bi bi-arrow-clockwise');
            } else {
                Swal.fire({
                    title: "Oops!",
                    text: "Not Found!",
                    icon: "danger"
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    }
                });
            }
        },
        error: function (error) {
            alert('Error: ' + error);
        }
    });
}

function Delete(ID) {
    var ID = ID;
    $.ajax({
        url: 'DeleteCategoryById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            Swal.fire({
                title: "Good job!",
                text: "Deleted successfully!",
                icon: "success"
            }).then((result) => {
                if (result.isConfirmed) {
                    location.reload();
                }
            });
        },
        error: function (status, error) {
            Swal.fire({
                title: "Oops!",
                text: status + "" + error,
                icon: "danger"
            });
        }
    });
}