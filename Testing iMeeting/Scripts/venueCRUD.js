$(document).ready(function () {


    // $('#example2').DataTable();
    toastr.options.timeOut = 1500; // 1.5s
    LoadData();
    LoadUsers();
    clearTextBox();
    LoadIdentityUsers();

});
function LoadUsers() {
    $.ajax({
        url: "https://mocki.io/v1/47d6bde5-cbbf-4788-8066-6feaa4cbb286",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {


                console.log(result.length)
                //debugger
                html += '<tr>';
                html += '<td>' + '<input type="checkbox" />' + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '<td>' + item.Designation + '</td>';
                html += '<td>' + item.Email + '</td>';
                //html += '<td>' + item.Department + '</td>';
                html += '<td>' + item.name + '</td>';
                html += '</tr>';
            });

            $('.tbody1').html(html);
            $('#MainTbl').DataTable();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });



}
function LoadData() {
    // debugger
    $.ajax({
        url: "http://localhost:52092/api/VenueApi/Get",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {

                //debugger
                html += '<tr>';
                html += '<td>' + item.ID + '</td>';
                html += '<td>' + item.RoomName + '</td>';
                html += '<td>' + item.Location + '</td>';
                html += '<td>' + item.Limit + '</td>';
                html += '<td><i class="fa fa-edit" onclick="return getbyID(' + item.ID + ')" style="font-size:22px;color:#0d6efd"></i> | <i class="fa fa-trash" style="font-size:22px;color:#0d6efd" onclick="Delele(' + item.ID + ')"></i></td>';
                html += '</tr>';
                //console.log(item.id)
            });

            $('.tbody').html(html);
            $('#example').DataTable();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });



}
function Add(e) {
    e.preventDefault();
    debugger
    var Param = {
        //ID: $('#ID').val(),
        RoomName: $('#RoomName').val(),
        Location: $('#Location').val(),
        Limit: $('#Limit').val()
    };
    console.log(Param.Limit);
    if (Param.RoomName == "" || Param.Location == "" || Param.Limit == 0) { console.log("Validation Error !!") }
    else {
        $.ajax({

            url: "http://localhost:52092/api/VenueApi/Add/" + Param,
            data: JSON.stringify(Param),
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {

                $('#exampleModal').modal('hide');
               
                clearTextBox();
                toastr.success('Added Successfully !!');
                LoadData();
            },
            error: function (errormessage) {
                console.log(errormessage.responseText);
            }
        });
    }
}
function clearTextBox() {
    $('#ID').val("");
    $('#RoomName').val("");
    $('#Location').val("");
    $('#Limit').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();

}
function Delele(ID) {
    var a = "All"
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        // debugger
        $.ajax({
            url: "http://localhost:52092/Api/VenueApi/Delete/" + ID,
            type: "DELETE",
            //contentType: "text/plain",
            //dataType: "json",
            success: function (result) {
                LoadData();
                toastr.info('Deleted Successfully !!');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function getbyID(ID) {
    // debugger
    $.ajax({

        url: "http://localhost:52092/Api/VenueApi/GetById/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#RoomName').val(result.RoomName);
            $('#Location').val(result.Location);
            $('#Limit').val(result.Limit);


            $('#exampleModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
            console.log(result);

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Update() {

    var Param = {
        ID: $('#ID').val(),
        RoomName: $('#RoomName').val(),
        Location: $('#Location').val(),
        Limit: $("#Limit").val()
    };
    console.log(Param)
    $.ajax({
        url: "http://localhost:52092/Api/VenueApi/UpdateVenue",
        data: JSON.stringify(Param),
        type: "Put",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#exampleModal').modal('hide');
            toastr.info('Updated Successfully !!');
            LoadData();
            clearTextBox();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function LoadIdentityUsers() {
    $.ajax({
        url: "http://localhost:52092/api/VenueApi/GetUsersData",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var id = item.Id;
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.FullName + '</td>';
                html += '<td>' + item.Designation + '</td>';
                html += '<td>' + item.Email + '</td>';/*onclick='gothere(\""+f+"\");'*/
                html += '<td><i id="user" class="fa fa-trash" style="font-size:22px;color:#0d6efd" onclick="DeleteUser(\'' + item.Id + '\')" ></i></td>';
                html += '</tr>';
                console.log(id);
            });

            $('.tbody2').html(html);
            $('#example2').DataTable();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });



}
function DeleteUser(Id) {
    //debugger
    console.log(Id);
    var ans = confirm("Are you sure you want to delete this Record?");
    //let Id = $(event.relatedTarget).find('#user');
    // console.log(Id);

    if (ans) {
        $.ajax({
            url: "http://localhost:52092/api/VenueApi/DellUsersData?Id=" + Id,
            type: "DELETE",
            success: function (result) {
                LoadIdentityUsers();
                toastr.info('Deleted Successfully !!');
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}