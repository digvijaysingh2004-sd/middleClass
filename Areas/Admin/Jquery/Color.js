$('#SaveUpdate').click(function () {
    debugger;
    var color = {
        ID: $('#HID').val(),
        ColorName: $('#ColorName').val(),
        ColorCode: $('#ColorCode').val()
    };

    $.ajax({
        url: 'SaveColorUpdate',
        type: 'POST',
        data: color,
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
            alert("An error occurred while saving the Color");
        }
    });
});

function Edit(ID) {
    debugger;
    var ID = ID;
    $.ajax({
        url: 'GetColorById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#ColorName').val(data.ColorName);
                $('#ColorCode').val(data.ColorCode);
                $('#SaveUpdate').text('Update').removeClass('btn-outline-purple fa-light fa-plus').addClass('btn-outline-info bi bi-arrow-clockwise');
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
        url: 'DeleteColorById',
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