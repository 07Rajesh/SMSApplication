
$(function () {
    GetEmployees();
})

function GetEmployees() {
    ApiCallAjax("Employee/GetEmployees", null, "GET", true, function (result) {
       // console.log(result)
        //-----destroyed table ------
        $('#tblEmployees').DataTable().destroy(); 

        $('#tblEmployees').DataTable({
            "paging": true,
            "lengthChange": false,
            "searching": true,
            "ordering": true,
            "info": true,
            "autoWidth": false,
            "responsive": true,
            "data": result.data,
            "columns": [
                {"data":"id"},
                { "data": "firstName"},
                { "data": "lastName"},
                { "data": "gender"},
                { "data": "email"},
                { "data": "password"},
                { "data": "mobile"},
                { "data": "address1"},
                { "data": "address2"},
                { "data": "pincode"},
                { "data": "isActive"},
                { "data": "empCode" },

                {
                    "data": "id","class":"text-center", "render": function (id) {
                        var btn = "<a><i class='fa fa-edit'></i></a> &nbsp;&nbsp;&nbsp;";
                        btn += "<a onclick='deleteRecord(" + id + ")'><i class='fa fa-trash'></i></a>";
                        return btn
                    }
                }
            ]
        });
    })
}

function deleteRecord(id) {
    console.log(id)
    ApiCallAjaxGet("Employee/DeleteEmployees", { "id": id }, true, function (result) {
        //console.log(result);
        if (result.ok) {
            alert(result.message)
            GetEmployees();
        }
        else {
            alert(result.message)
        }
    })
}