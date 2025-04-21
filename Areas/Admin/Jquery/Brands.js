/*$('#BrandsImage').on('change', function () {
    var file = this.files[0];
    var reader = new FileReader();
    reader.onload = function (e) {
        var img = new Image();
        img.onload = function () {
            var canvas = document.getElementById('canva');
            var ctx = canvas.getContext('2d');
            ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
        }
        img.src = e.target.result;
    }
    reader.readAsDataURL(file);
});*/

$('#SaveUpdate').on('click', function () {
    debugger;
    var validation = validateForm();
    var formData = new FormData();
    var fileInput = $('#BrandsImage')[0].files[0];
    var name = $('#BrandsName').val();
    var ID = $('#HID').val();

    formData.append("imageFile", fileInput);
    formData.append("BrandsName", name);
    formData.append("ID", ID);
    if (validation == true) {
        $.ajax({
            url: 'SaveUpdateBrands',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.success) {
                    Swal.fire({
                        title: "Good job!",
                        text: "Saved successfully!",
                        icon: "success"
                    }).then((result) => {
                        if (result.isConfirmed) {
                            location.reload();
                        }
                    });
                } else {
                    Swal.fire({
                        title: "Oops!",
                        text: "Something Wrong!",
                        icon: "danger"
                    });
                }
            },
            error: function (xhr, status, error) {
                Swal.fire({
                    title: "Oops!",
                    text: status + "" + error,
                    icon: "danger"
                });
                /* alert("An error occurred: " + status + " " + error);*/
            }
        });
    }
});


function Edit(ID) {
    var ID = ID;
    $.ajax({
        url: 'GetBrandsById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            $('#HID').val(data.ID);
            $('#BrandsName').val(data.BrandsName);
            if (data.BrandsImage) {
                let encodedImageUrl = encodeURI(data.BrandsImage);
                $('#canva').css({
                    'background-image': 'url(' + encodedImageUrl + ')',
                    'background-repeat': 'no-repeat',
                    'background-position': 'center',
                    'background-size': 'contain'
                });
            }
            $('#SaveUpdate').text(' Update').removeClass('btn-soft-primary').addClass('btn-soft-info');
            window.scrollTo(0, 0);
        },
        error: function (xhr, status, error) {
            alert('Error: ' + error);
        }
    });
}
function Delete(ID) {
    var ID = ID;
    $.ajax({
        url: 'DeleteBrandsById',
        type: 'POST',
        data: { ID: ID },
        success: function (data) {
            Swal.fire({
                title: "Great !",
                text: "Data Deleted Successfully!",
                icon: "success"
            }).then(() => {
                location.reload();
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                title: "Oops!",
                text: "Error!",
                icon: "danger"
            }).then((result) => {
                if (result.isConfirmed) {
                    location.reload();
                }
            });
        }
    });
}

function validateForm() {
    var isvalid = true;
    
    if ($("#BrandsName").val() == "") {
        $("#BrandsName").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#BrandsName").css('border-color', '');
    }
   
    return isvalid;
}
