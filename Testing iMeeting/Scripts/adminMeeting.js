$(document).ready(function () {
    LoadMeetingsData();
    $("#hide").click(function () {
        $("#table").hide();
        $("#ShowGrid").show();
        DatatableHide();
        $("#today,#Tomorrow,#Week,#Month,#All,#datepicker,#Show").hide();

    });
    $("#show").click(function () {
        $("#hide").show();
        $("#ShowGrid").hide();
        $("#table").show();
        $("#today,#Tomorrow,#Week,#Month,#All,#datepicker,#Show").show();
        $('#table').DataTable();

    });
    $("#datepicker").datepicker();
    $("#ShowGrid").hide();
    LoadMeetingInGrid();
    LocationDropDown();
    ParticipantsDropDown()
});

function CreaeMeeting() {

    debugger
    if ($('#Duration').val() == "Y") {
        var Param = {
            //ID: $('#ID').val(),
            Title: $('#Title').val(),
            Agenda: $('#Agenda').val(),
            Notes: $('#Notes').val(),
            File: $('#File').val(),
            Links: $('#Url').val(),
            DateTime: $('#DateTime').val(),
            Duration: $('#Duration_one').val(),
            Location: $('#locality-dropdown').val(),
            //  Participants: $('#Users-dropdown').val(),
            IsActive: 1
        };
    }
    else {
        var Param = {
            //ID: $('#ID').val(),
            Title: $('#Title').val(),
            Agenda: $('#Agenda').val(),
            Notes: $('#Notes').val(),
            File: $('#File').val(),
            Links: $('#Url').val(),
            DateTime: $('#DateTime').val(),
            Duration: $('#Duration').val(),
            Location: $('#locality-dropdown').val(),
            // Participants: $('#Users-dropdown').val(),
            IsActive: 1
        };
    }
    if (Param.Title == "" || Param.Agenda == "" || Param.Notes == "") { console.log("Validation Error !!") }
    else {
        var a = $('#Users-dropdown').val();
        $.ajax({
            url: "http://localhost:52092/api/AdminMeetingApi/CreateMeeting?Title=" + Param.Title + "&Agenda=" + Param.Agenda + "&Notes=" + Param.Notes + "&Links=" + Param.Links + "&DateTime=" + Param.DateTime + "&Duration=" + Param.Duration + "&Location=" + Param.Location,
            data: JSON.stringify(a), //stringify is important
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                $('#exampleModal').modal('hide');
                ClearTextBox();
                toastr.success('Added Successfully !!');
                LoadMeetingsData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function DatatableHide() {
    $('#table').DataTable({
        destroy: true,
        searching: false,
        paging: false, info: false
    });
}
function GetDateTime() {
    var jsDate = $('#datepicker').val();
    LoadMeetingsByDate(jsDate);
}
function LoadMeetingInGrid(val) {
    $.ajax({
        url: "http://localhost:52092/api/AdminMeetingApi/MeetingListByAdmin?Filter=" + val,
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var comingDate = item.DateTime
                var changeDateFormat = moment(comingDate).format('D-MMM');
                var time = moment(comingDate).format("HH:mm A");
                if (item.Participants != null) {
                    var _participants = '<i class="fas fa-user-alt" style="float:left">' +
                        '<i class="fa fa-plus" aria-hidden="true"></i>' +
                        '</i>'
                }
                else {
                    var _participants = '<i style="color:firebrick;">No Participant Attending</i>'
                }
                html +=

                    '<div class="text-center" style="display: inline-block; ">' +
                    '<div style="display: inline-block">' +
                    '<div style="width: 20rem;">' +
                    '<div class="card text-dark bg-light mb-3" style="max-width: 18rem;">' +
                    '<div class="card-header"><b> ' + item.Title + '</b></div>' +
                    '<div class="card-body">' +
                    ' <h5 class="card-title"></h5>' +
                    '<p class="card-text"></p>' +
                    '<i class="fas" style="float:right"> ' + changeDateFormat + ' </i>' +
                    '<i  style="float:left"> ' + _participants + ' </i>' +
                    ' <br/><br/><br/><hr> <i class="fa fa-map-marker" style="color:green;float:left"> &nbsp;&nbsp;&nbsp;' + item.Location + '</i>' +
                    ' </div>' +
                    '</div>' +
                    '</div>' +
                    '<br />' +
                    '</div>' +
                    '</div>'
            });
            $('#ShowGrid').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
function LoadMeetingsData(val) {
    $.ajax({
        url: "http://localhost:52092/api/AdminMeetingApi/MeetingListByAdmin?Filter=" + val,
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var currentTime = moment().format('YYYY-MM-DD' + 'T' + 'HH:mm:ss');

                if (currentTime >= item.DateTime && currentTime <= item.EndTime && item.IsActive == 1) {
                    var _meetingStatus = '<span class="badge bg-primary">In-Progress</span>'
                }
                else if (currentTime > item.EndTime && item.IsActive == 1) {
                    var _meetingStatus = '<span class="badge bg-warning text-dark">Completed</span>'
                }
                else if (item.IsActive == 0) {
                    var _meetingStatus = '<span class="badge rounded-pill bg-secondary">Cancelled</span>'
                }
                else {
                    var _meetingStatus = '<span class="badge bg-success">Scheduled</span>'
                }
                var comingDate = item.DateTime
                var changeDateFormat = moment(comingDate).format('D-MMM-yyyy');
                var time = moment(comingDate).format("HH:mm A");
                html += '<tr>';
                html += '<td>' + item.Title + '</td>';
                html += '<td>' + _meetingStatus + '</td>';
                html += '<td>' + item.Location + '</td>';
                html += '<td>' + item.DateTime + '</td>';
                html += '<td>' + '<i class="fas fa-user-alt" style="float:left">' +
                    '<i class="fa fa-plus" aria-hidden="true"></i>' +
                    '</i>    ' +
                    '<a href=""  class="fst-italic" data-bs-toggle="modal" data-bs-target="#exampleModal1" onclick="GetParticipants(' + item.Id + ')">' +
                    'View Participants'+
                    '</a >'+
                    '</td>';
                html += '<td>' + '<div class="dropdown menu-icon-wrappe">' +
                    '  <i class="btn btn-secondary dropdown-toggle fas fa-ellipsis-v"  id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">' +
                    ' </i>' +
                    '  <ul class="dropdown-menu r" aria-labelledby="dropdownMenuButton1">' +
                    '  <li><a class="dropdown-item" onclick="CancelMeeting(\'' + item.Id + '\');">Cancel Meeting</a></li>' +
                    '  <li><a class="dropdown-item" onclick="EndMeeting(\'' + item.Id + '\');">End Meeting</a></li>' +
                    '   </ul>' +
                    '</div>' + '</td>';
                html += '</tr>';

            });
            $('.tbody').html(html);
            $('#table').DataTable();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
function GetParticipants(Id) {
    // AJAX request
    $.ajax({
        type: 'GET',
        url: 'http://localhost:52092/api/AdminMeetingApi/FetchParticipants/'+Id,
        success: result => {
            console.log(result);
            $('.modal-body1').html(result);          
        }
    });

}
function LoadMeetingsByDate(val) {
    console.log(val);
    debugger
    let Url = 'http://localhost:52092/api/AdminMeetingApi/MeetingFilter?Filter=' + val
    // console.log(Url);
    $.ajax({

        url: Url,
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var currentTime = moment().format('YYYY-MM-DD' + 'T' + 'HH:mm:ss');
                if (currentTime >= item.DateTime && currentTime <= item.EndTime) {
                    var _meetingStatus = '<span class="badge bg-primary">In-Progress</span>'
                }
                else if (currentTime > item.EndTime) {
                    var _meetingStatus = '<span class="badge bg-warning text-dark">Completed</span>'
                }
                else {
                    var _meetingStatus = '<span class="badge bg-success">Scheduled</span>'
                }
                html += '<tr>';
                html += '<td>' + item.Title + '</td>';
                html += '<td>' + _meetingStatus + '</td>';
                html += '<td>' + item.Location + '</td>';
                html += '<td>' + item.DateTime + '</td>';
                html += '<td>' + '<i class="fas fa-user-alt" style="float:left">' +
                    '<i class="fa fa-plus" aria-hidden="true"></i>' +
                    '</i>    ' +
                    '<a href=""  class="fst-italic" data-bs-toggle="modal" data-bs-target="#exampleModal1" onclick="GetParticipants(' + item.Id + ')">' +
                    'View Participants' +
                    '</a >' +
                    '</td>';
                html += '<td>' + '<div class="dropdown menu-icon-wrappe">' +
                    '  <i class="btn btn-secondary dropdown-toggle fas fa-ellipsis-v"  id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">' +
                    ' </i>' +
                    '  <ul class="dropdown-menu r" aria-labelledby="dropdownMenuButton1">' +
                    '  <li><a class="dropdown-item" onclick="CancelMeeting(\'' + item.Id + '\');">Cancel Meeting</a></li>' +
                    '  <li><a class="dropdown-item" onclick="EndMeeting(\'' + item.Id + '\');">End Meeting</a></li>' +
                    '   </ul>' +
                    '</div>' + '</td>';
                html += '</tr>';
                console.log(item.id)
            });
            $('.tbody').html(html);
            $('#table').DataTable();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
function LocationDropDown() {
    let dropdown = $('#locality-dropdown');
    dropdown.empty();
    dropdown.append('<option selected="true" disabled>Choose Room/Location</option>');
    dropdown.prop('selectedIndex', 0);
    const url = 'http://localhost:52092/api/VenueApi/Get';
    // Populate dropdown with list of provinces
    $.getJSON(url, function (data) {
        $.each(data, function (key, entry) {
            dropdown.append($('<option></option>').attr('value', entry.RoomName).text(entry.RoomName + '--Limit (' + entry.Limit + ')'));
        })
    });
}
function ParticipantsDropDown() {

    let dropdown = $('#Users-dropdown');
    dropdown.empty();
    dropdown.append('<option selected="true" disabled>Choose People/Participants</option>');
    dropdown.prop('selectedIndex', 0);
    const url = 'http://localhost:52092/api/VenueApi/GetUsersData';
    // Populate dropdown with list of provinces
    $.getJSON(url, function (data) {

        $.each(data, function (key, entry) {
            console.log(entry);
            //  dropdown.append($('<option></option>').attr('value', entry.Id).text(entry.Name +'--Limit ('+ entry.Limit +')'));

            dropdown.append("<option value='" + entry.Id + "'>" + entry.FullName + "</option>");
        })
    });
}
function ClearTextBox() {
    $('#Title').val("");
    $('#Agenda').val("");
    $('#Notes').val("");
    $('#File').val("");
    $('#Url').val("");
    $('#DateTime').val("");

    //$('#btnUpdate').hide();

}
function EndMeeting(Id) {
    debugger
    let Url = "http://localhost:52092/api/AdminMeetingApi/EndMeeting?Id=" + Id
    var ans = confirm("Are you sure you want to End this Meeting?");
    if (ans) {
        $.ajax({

            url: Url,
            type: "Get",
            contentType: "application/json",
            dataType: "json",
            success: function (result) {
                LoadMeetingsData();
                toastr.info('End Successfully !!');

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}
function CancelMeeting(Id) {
    debugger
    let Url = "http://localhost:52092/api/AdminMeetingApi/CancelMeeting/" + Id
    $.ajax({

        url: Url,
        type: "Get",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            LoadMeetingsData();
            toastr.info('Cancel Successfully !!');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
$(function () {
    $("#Duration").change(function () {
        if ($(this).val() == "Y") {
            $("#CustomDuration").show();
        } else {
            $("#CustomDuration").hide();
        }
    });
});

