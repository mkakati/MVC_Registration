function imgchange(f) {
    var filePath = $('input[type=file]').val();
    var reader = new FileReader();
    reader.onload = function (e) {
        $('#imagess').attr('src', e.target.result);
    };
    reader.readAsDataURL(f.files[0]);
}

$(document).ready(function () {


    $("#btnSubmit").on('click', function () {
        var flag = 0;
        if ($("#txtFullName").val() === "") {
            $("#txtFullName").addClass("validate-input");
            flag = 1;
        }
        else
            $("#txtFullName").removeClass("validate-input");

        if ($("#txtEmail").val() === "") {
            $("#txtEmail").addClass("validate-input");
            flag = 1;
        }
        else
            $("#txtEmail").removeClass("validate-input");

        if ($("#txtDateofBirth").val() == "" || $("#txtDateofBirth").val() == undefined) {
            $("#txtDateofBirth").addClass("validate-input");
            flag = 1;
        }
        else
            $("#txtDateofBirth").removeClass("validate-input");

        if ($("#CountryId").val() === "") {
            $("#CountryId").addClass("validate-input");
            flag = 1;
        }
        else
            $("#CountryId").removeClass("validate-input");

        if ($("#StateId").val() === "") {
            $("#StateId").addClass("validate-input");
            flag = 1;
        }
        else
            $("#StateId").removeClass("validate-input");

        if ($("#txtAddress").val() === "") {
            $("#txtAddress").addClass("validate-input");
            flag = 1;
        }
        else
            $("#txtAddress").removeClass("validate-input");
        if (flag === 0) {
            alert("Data SuccesFully Inserted");
            return true;
        }
        else
            return false;
    });

    var filename = '';

    $("#txtDateofBirth").datepicker({
        maxDate: new Date(),
        dateFormat: 'dd-mm-yy'
    });


    $("#CountryId").on('change', function () {
        var countryId = $(this).val();
        $.ajax({
            type: "get",
            url: "/Employee/GetStateList?CountryId=" + countryId,
            contentType: "JSON",
            success: function (response) {
                $("#StateId").empty();
                var htmldata = "";
                $.each(response.data, function (i, v) {
                    htmldata = htmldata + '<option value="' + v.Value + '">' + v.Text + '</option>';
                });
                $("#StateId").append(htmldata)
            }
        })
    })
})