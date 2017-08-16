jQuery.support.cors = true;
var ApiUrl = "http://localhost:53262/";
$(function () {

   
    //查询
    $.ajax({
        type: "get",
        url: ApiUrl + "api/city/get",
        data: {},
        success: function (data, status) {
            if (status == "success") {
                console.log(data);

                //$('#demo').html('<table class="table table-bordered table-hover" cellpadding="0" cellspacing="0" border="0" class="display" id="example"></table>');
                $('#example').dataTable({
                    "paging": true,
                    "lengthChange": false,
                    "searching": false,
                    "ordering": true,
                    "info": true,
                    "autoWidth": false,
                    "data": data,
                    "columns": [
                        { "data": "CityId" },
                        { "data": "CityName" },
                        { "data": "ParentId" },
                    ]
                });
            }
        },
        error: function (e) {
        },
        complete: function () {

        }
    });

});


function create() {

    console.log(JSON.stringify($('#cityfrom').serializeJSON()));

    //待调整
    //swalSuccess () {
    //    swal('Good job!', 'You clicked the button!', 'success')
    //}

    //添加
    $.ajax({
        type: "POST",
        url: ApiUrl + "api/city/add",
        contentType: "application/json",
        data: JSON.stringify($('#cityfrom').serializeJSON()),
        success: function (data, status) {
            if (status == "success") {
                alert("ok");
                console.log('ok');
            }
        },
        error: function (e) {
            console.log('error');
        },
        complete: function () {

        }
    });

}