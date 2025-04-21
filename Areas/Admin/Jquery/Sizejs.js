$('#SaveUpdate').click(function () {
    debugger;
    var size = {
        ID: $('#HID').val(),
        SizeName: $('#SizeName').val(),
        SizeValue: $('#SizeValue').val()
    };

    $.ajax({
        url: 'SaveSizeUpdate',
        type: 'POST',
        data: size,
        success: function (data) {
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
        error: function (data) {
            alert("An error occurred while saving the Size");
        }
    });
});

function Edit(ID) {
    debugger;
    var ID = ID;
    $.ajax({
        url: 'GetSizeById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#SizeName').val(data.SizeName);
                $('#SizeValue').val(data.SizeValue);
                $('#SaveUpdate').text('Update').removeClass('btn-soft-primary fa-light fa-plus').addClass('btn-soft-info fa-light fa-rotate-right');
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
        url: 'DeleteSizeById',
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