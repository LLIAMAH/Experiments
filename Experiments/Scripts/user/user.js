/// <reference path="../jquery-3.4.1.intellisense.js" />

function filterData(id) {
    let value = $(id).val();

    $.ajax({
        type: "POST",
        url: "Home/Filter",
        data: {
            "filter": value
        },
        async: false,
        success: function (result) {
            $("#tableOutput").html(result);
        }
    });
}