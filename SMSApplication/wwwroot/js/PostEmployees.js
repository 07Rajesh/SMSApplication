$(function () {
    $("#btnSubmit").click(function () {
        
        PostEmployee();
    })
    
})

function PostEmployee() {

    var data = {
        "id":0,
        "firstName": $("#txtFName").val(),
        "lastName": $("#txtLName").val(),
        "gender": $("#ddlGender").val(),
        "email": $("#txtEmail").val(),
        "password": $("#txtPassword").val(),
        "mobile": $("#txtMobile").val(),
        "address1": $("#txtAddress1").val(),
        "address2": $("#txtAddress2").val(),
        "pincode": $("#txtPincode").val(),
        "isActive": $("#ddlIsActive").val() == "1" ? true : false,
        "EmpCode":"",

    }
    // ye form data post karne ka tarika h
    //var data2 = new FormData()
    //data2.append("firstName", $("#txtFName").val())

    ApiCallAjax("Employee/PostEmployees", JSON.stringify(data), "POST", true, function (result) {
        //console.log(result)
        if (result.ok) {
            alert(result.Message)
            setTimeout(() => {
                window.location.reload()
            }, 2000)
        }
        else {
            alert("Something went wrong!")
        }
    })
}