$(document).ready(function () {

    // var a = "AW12";
    $("#datepicker").datepicker();
    $("#btn").click(function () {
        $("#table").table2excel({
            // exclude CSS class
            // exclude: ".noExl",
            name: "Worksheet Name",
            filename: "Meeting List", //do not include extension
            fileext: ".xls" // file extension
        });
    });
    LoadMeetingsData();
});
function GetDateTime() {
    var jsDate = $('#datepicker').val();
    LoadMeetingsByDate(jsDate);
}
function LoadMeetingsData(val) {
    $.ajax({
        url: "http://localhost:52092/api/UserPanelApi/Filters?Filter=" + val,
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                var currentTime = moment().format('YYYY-MM-DD' + 'T' + 'HH:mm:ss');

                var accept = 1;
                var reject = 0;
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
                html += '<td>' + item.Duration + '    Minutes' + '</td>';
                html += '<td>' + '<i class="fas fa-user-alt" style="float:left">' +
                    '<i class="fa fa-plus" aria-hidden="true"></i>' +
                    '</i>    ' +
                    '<a href=""  class="fst-italic" data-bs-toggle="modal" data-bs-target="#exampleModal1" onclick="GetParticipants(' + item.Id + ')" >' +
                    'View' +
                    '</a >' +
                    '</td>';
                html += '<td>' + '<button type="button" class="btn btn-success btn-sm" onclick="AcceptMeeting(\'' + item.Id + '\',\'' + accept + '\');" >Accept</button> <button type="button"  class="btn btn-danger btn-sm" onclick="AcceptMeeting(\'' + item.Id + '\',\'' + reject + '\');">Decline</button>' + '</td>';
                html += '</tr>';
                console.log(item.Duration)
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
        url: 'http://localhost:52092/api/AdminMeetingApi/FetchParticipants/' + Id,
        success: result => {
            console.log(result);
            $('.modal-body1').html(result);
        }
    });

}
function LoadMeetingsByDate(val) {
    //debugger
    console.log(val);
    let Url = 'http://localhost:52092/api/UserPanelApi/FilterByDate?Filter=' + val
    // let Url = 'http://localhost:52092/api/UserPanelApi/FilterByDatetest?Filter=Wed Aug 11 2021 00:00:00 GMT+0500 (Pakistan Standard Time)';
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
                //var dateTime = moment(item.DateTime).format('YYYY-MM-DD' + 'T' + 'HH:mm:ss');
                //var futureTime = moment(item.DateTime).add(item.Duration, 'minutes').format('YYYY-MM-DD' + ' ' + 'HH:mm:ss.SS');
                var accept = 1;
                var reject = 0;
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
                html += '<td>' + item.Status + '</td>';
                html += '<td>' + item.Location + '</td>';
                html += '<td>' + item.DateTime + '</td>';
                html += '<td>' + item.Duration + '    Minutes' + '</td>';
                //html += '<td>' + item.Participants + '</td>';
                html += '<td>' + '<i class="fas fa-user-alt" style="float:left">' +
                    '<i class="fa fa-plus" aria-hidden="true"></i>' +
                    '</i>' + '</td>';
                html += '<td>' + '<button type="button" class="btn btn-success btn-sm" onclick="AcceptMeeting(\'' + item.Id + '\',\'' + accept + '\');" >Accept</button> <button type="button"  class="btn btn-danger btn-sm" onclick="AcceptMeeting(\'' + item.Id + '\',\'' + reject + '\');">Decline</button>' + '</td>';
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
function AcceptMeeting(Id, Value) {
    debugger
    let Url = "http://localhost:52092/api/UserPanelApi/UpdateMeetingStatus?Meeting_Id=" + Id + "&Status=" + Value
    $.ajax({

        url: Url,
        type: "Post",
        contentType: "application/json",
        dataType: "json",
        success: function (result) {
            toastr.info('Updated Successfully !!');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}