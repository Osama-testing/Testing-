$(function () {
    $("#copy").click(function () {
        var getSelectedRows = $("#MainTbl input:checked").parents("tr").clone();

        // $("#example2 tbody").append(getSelectedRows);
        console.log(getSelectedRows.length)
        var name = $(getSelectedRows).find("td")[1].innerHTML;
        var designation = $(getSelectedRows).find("td")[2].innerHTML;
        var email = $(getSelectedRows).find("td")[3].innerHTML;
        console.log(name); console.log(email);
        var Param = {
            name: name,
            designation: designation,
            email: email
        };
        $.ajax({
            type: "POST",
            url: "/Account/Register",
            data: JSON.stringify(Param),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                LoadIdentityUsers();

            },
            failure: function (response) {
                LoadIdentityUsers();
                console.log(response);
            },
            error: function (response) {
                LoadIdentityUsers();
                console.log(response);
            }
        });

    });
});