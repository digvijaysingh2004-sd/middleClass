$(document).ready(function () {
    $('#Category').select2({
        placeholder: "Select Category"
    });
    $('#Material').select2({
        placeholder: "Select Material"
    });

    $.ajax({
        type: "GET",
        url: "GetSize",
        dataType: "json",
        success: function (data) {
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].SizeName + '</option>';
            }
            $("#Size").html(s);
        }
    });

    $.ajax({
        type: "GET",
        url: "GetCategory",
        dataType: "json",
        success: function (data) {
            var s = '<option value="" selected disabled>Select Category</option>'; // Hidden placeholder
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].CategoryName + '</option>';
            }
            $("#Category").html(s);
        }
    });

    $.ajax({
        type: "GET",
        url: "GetMaterial",
        dataType: "json",
        success: function (data) {
            var s = '<option value="" selected disabled>Select Febric</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].MaterialName + '</option>';
            }
            $("#Material").html(s);
        }
    });

    $.ajax({
        type: "GET",
        url: "GetColor",
        dataType: "json",
        success: function (data) {
            var s = '';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].ID + '">' + data[i].ColorName + '</option>';
            }
            $("#Color").html(s);
        }
    });
});


$('#SaveUpdate').click(function (event) {
    event.preventDefault(); // Prevent default form submission

    var validation = validateForm(); // Ensure this function is defined
    if (!validation) return; // Stop execution if validation fails

    var formData = new FormData();
    formData.append('ID', $('#HID').val());
    formData.append('ProductId', $('#ProductId').val());
    formData.append('Quantity', $('#Quantity').val());
    formData.append('ProductName', $('#ProductName').val());
    formData.append('Material', $('#Material').val() ? $('#Material').val() : '');
    formData.append('Category', $('#Category').val() ? $('#Category').val() : '');
    formData.append('Description', $('#Description').val());
    formData.append('Price', $('#Price').val());
    formData.append('Badge', $('#Badge').val());
    formData.append('DiscountPercentage', $('#DiscountPercentage').val());
    formData.append('DiscountPrice', $('#DiscountedPrice').val());

    // ✅ Convert multiple selected Color IDs into a comma-separated string
    var selectedColors = $('#Color').val();
    var colorString = selectedColors ? selectedColors.join(',') : '';
    formData.append('Color', colorString);

    // ✅ Convert multiple selected Size IDs into a comma-separated string
    var selectedSizes = $('#Size').val();
    var sizeString = selectedSizes ? selectedSizes.join(',') : '';
    formData.append('Size', sizeString);

    var fileInput = document.getElementById('ProductImage');
    if (fileInput.files.length > 0) {
        for (let i = 0; i < fileInput.files.length; i++) {
            formData.append('Images[]', fileInput.files[i]); // Append all images
        }
    }

    $.ajax({
        url: 'SaveUpdateProduct',
        type: 'POST',
        data: formData,
        contentType: false,
        processData: false,
        success: function (response) {
            if (response) {
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
                    text: "Error in process!",
                    icon: "error"
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    }
                });
            }
        },
        error: function (error) {
            Swal.fire({
                title: "Oops!",
                text: "Error in data!",
                icon: "error"
            }).then((result) => {
                if (result.isConfirmed) {
                    location.reload();
                }
            });
        }
    });
});


let existingImages = []; // Global array to store existing image URLs

function Edit(ID) {
    $.ajax({
        url: 'GetProductById',
        type: 'GET',
        data: { ID: ID },
        success: function (data) {
            if (data) {
                // Set form fields
                $('#HID').val(data.ID);
                $('#ProductId').val(data.ProductId);
                $('#Quantity').val(data.Quantity);
                $('#ProductName').val(data.ProductName);
                $('#Badge').val(data.Badge);
                $('#Description').val(data.Description);
                $('#Price').val(data.Price);
                $('#DiscountPercentage').val(data.DiscountPercentage);
                $('#DiscountedPrice').val(data.DiscountPrice);

                // Set Select2 dropdowns
                $('#Material').val(data.Material).trigger('change');
                $('#Category').val(data.Category).trigger('change');
                $('#Size').val(Array.isArray(data.Size) ? data.Size : (data.Size ? data.Size.toString().split(',') : [])).trigger('change');
                $('#Color').val(Array.isArray(data.Color) ? data.Color : (data.Color ? data.Color.toString().split(',') : [])).trigger('change');

                // Handle images
                let previewContainer = $('#image-preview');
                previewContainer.empty();
                existingImages = [];

                // Load Single Image
                if (data.Images) {
                    existingImages.push(data.Images);
                    addImageToPreview(data.Images);
                }

                // Load Multiple Images
                if (data.AllImages) {
                    let imageUrls = data.AllImages.split(',').map(url => url.trim());
                    imageUrls.forEach(url => {
                        existingImages.push(url);
                        addImageToPreview(url);
                    });
                }

                // Remove Individual Image Logic
                $(document).off('click', '.remove-image').on('click', '.remove-image', function () {
                    let imgWrapper = $(this).closest('.preview-wrapper');
                    let imgSrc = imgWrapper.find('img').attr('src');
                    existingImages = existingImages.filter(img => img !== imgSrc);
                    imgWrapper.remove();
                });

                // Update Button UI
                $('#SaveUpdate').text('Update').removeClass('btn-outline-primary').addClass('btn-outline-info');
                window.scrollTo(0, 0);
            } else {
                alert('Product not found');
            }
        },
        error: function (xhr, status, error) {
            alert('Error: ' + error);
        }
    });
}

// Function to Add Image to Preview
function addImageToPreview(imageSrc) {
    let previewContainer = $('#image-preview');

    let imgWrapper = `
        <div class="preview-wrapper position-relative d-inline-block">
            <img src="${imageSrc}" class="preview-image" style="width: 100px; height: 100px; object-fit: cover; border-radius: 8px;">
            <button type="button" class="btn btn-sm position-absolute top-0 end-0 remove-image" style="padding: 0px 4px; background: transparent; border: none;">
                <i class="fa-regular fa-xmark"></i>
            </button>
        </div>
    `;
    previewContainer.append(imgWrapper);
}

function Delete(ID) {
    var ID = ID;
    $.ajax({
        url: 'DeleteProductById',
        type: 'POST',
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

function validateForm() {
    var isvalid = true;
    if ($("#Quantity").val() == '') {
        $("#Quantity").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#Quantity").css('border-color', '');
    }

    if ($("#ProductName").val() == "") {
        $("#ProductName").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#ProductName").css('border-color', '');
    }

    if ($("#ProductId").val() == "") {
        $("#productId").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#ProductId").css('border-color', '');
    }

    if ($("#Material").val() == "-1") {
        $("#Material").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#Material").css('border-color', '');
    }
    if ($("#Color").val() == "-1") {
        $("#Color").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#Color").css('border-color', '');
    }

    if ($("#Size").val() == "-1") {
        $("#Size").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#Size").css('border-color', '');
    }

    if ($("#Description").val() == "") {
        $("#Description").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#Description").css('border-color', '');
    }

    if ($("#Price").val() == "") {
        $("#Price").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#Price").css('border-color', '');
    }
    if ($("#DiscountPercentage").val() == "") {
        $("#DiscountPercentage").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#DiscountPercentage").css('border-color', '');
    }

    if ($("#DiscountedPrice").val() == "") {
        $("#DiscountedPrice").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#DiscountedPrice").css('border-color', '');
    }

    if ($("#ProductImage").val() == "") {
        $("#ProductImage").css('border-color', 'red');
        isvalid = false;
    }
    else {
        $("#ProductImage").css('border-color', '');
    }

    return isvalid;
}

function calculateDiscountedPrice() {

    const mrp = parseFloat(document.getElementById("Price").value);
    const dp = parseFloat(document.getElementById("DiscountPercentage").value);
    if (!isNaN(mrp) && !isNaN(dp)) {
        const discountedPrice = mrp - (mrp * dp / 100);
        document.getElementById("DiscountedPrice").value = discountedPrice.toFixed(2);
    } else {
        document.getElementById("DiscountedPrice").value = "";
    }
}

// Add event listeners to calculate the discount on keyup or input
document.getElementById("Price").addEventListener("input", calculateDiscountedPrice);
document.getElementById("DiscountPercentage").addEventListener("input", calculateDiscountedPrice);
