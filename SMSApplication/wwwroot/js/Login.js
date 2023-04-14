
var basepath = "https://localhost:44395/"

$(document).ready(function () {
    $("#btnLogin").click(function(){
        LoginUser();
    })
})

function LoginUser() {
    var user = { "Email": $("#txtEmail").val(), "Password": $("#txtPassword").val() }

    $.ajax({
        url: basepath + "api/Account/Login",
        data: JSON.stringify(user),
        type: "POST",
        contentType:"application/json; charset=utf-8",
        dataType:"json",
        success: function (response) {
          //  console.log(response)
            if (response.ok) {
                delete user.Password
                localStorage.setItem("user", JSON.stringify(user))
                localStorage.setItem("token", response.token)
                $("#lblmsg").text("Login Successfull....").css("color", "green")
                setTimeout(function () {
                    window.location.href = "/Home/Index"
                }, 1000)
            }
            else {
                $("#lblmsg").text("Login failed Invalid email address or password....").css("color", "red")
            }
        }
    })
}