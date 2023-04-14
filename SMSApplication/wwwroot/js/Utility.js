

var BasePath = "https://localhost:44395/api/"

var ActionPath = "";


/* $('#divLoader').hide();
    //Attach the event handler to any element
    $(document)
    .ajaxStart(function () {
        //ajax request went so show the loading image
        ('#divLoader').show();
                     })
    .ajaxStop(function () {
        //got response so hide the loading image
        ('#divLoader').hide();
     });*/


function ApiCallAjax(url, data, type, async, fnresult, fnerror) {
    $.ajax({
        url: BasePath + url,
        data:data,
        type: type,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: async,
        headers: {
            "Authorization": "Bearer " + getToken()
        },
        Cache: false,
        success: function (response) {
            fnresult(response)
        },
        error: function (err) {
            console.log(err)
            switch (err.status) {
                case 401:
                    localStorage.removeItem("token");
                    localStorage.removeItem("user");
                    window.location.href = "/Home/Error"
                    
                    break;

            }
          //  fnerror(err)
        }
    })
}

//-------------------------------------
function ApiCallAjaxGet(url, data, async, fnresult, fnerror) {
    $.ajax({
        url: BasePath + url,
        data:data,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json", 
        async: async,
        headers: {
            "Authorization": "Bearer " + getToken()
        },
        
        success: function (response) {
            fnresult(response)
        },
        error: function (err) {
            console.log(err)
            switch (err.status) {
                case 401:
                    localStorage.removeItem("token");
                    localStorage.removeItem("user");
                    window.location.href = "/Home/Error"

                    break;

            }
            //  fnerror(err)
        }
    })
}

function getToken() {
    if (localStorage.getItem("token") != null) {
        return localStorage.getItem("token")
    }
    else {
        return null
    }
}