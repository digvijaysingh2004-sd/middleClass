$('#SaveUpdate').click(function () {
    debugger;
    var material = {
        ID: $('#HID').val(),
        MaterialName: $('#MaterialName').val(),
    };

    $.ajax({
        url: 'SaveMaterialUpdate',
        type: 'POST',
        data: material,
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
            alert("An error occurred while saving the Material");
        }
    });
});

function Edit(ID) {
    debugger;
    var ID = ID;
    $.ajax({
        url: 'GetMaterialById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                $('#HID').val(data.ID);
                $('#MaterialName').val(data.MaterialName);
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
        url: 'DeleteMaterialById',
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