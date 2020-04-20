/// <reference path="../jquery-3.5.0.intellisense.js" />

function filterData(id) {
    let value = $(id).val();

    $.ajax({
        type: "post",
        url: window.urls.getFiltered,
        data: {
            filter:value
        },
        async: false,
        success: function(result) {
            $("#tableOutput").html(result);
        }
    });
}

(function ($) {
    // Populates a select drop-down with options in a list 
    $.fn.populate = function (list) {
        return this.append(list.map(item => $('<option>', {
            text: item.Text,
            value: item.Value,
            selected: item.Selected
        })));
    };
})(jQuery);

function dropdownSelect(element) {
    let value = $(element).val();

    $.ajax({
        type: "post",
        url: window.urls.getDependent,
        data: {
            dependentId: value
        },
        async: false,
        success: function (result) {
            $("#DependentId").empty().populate(result);
        }
    });
}

function getSubItems(element, parentId) {
    if (OpenedForEdit) {
        alert("Item opened for edit - close it first.");
        return;
    }
    let el = $(element);
    let row = el.closest("tr");

    $.ajax({
        type: "post",
        url: window.urls.getSubItems,
        data: {
            dependentId: parentId
        },
        async: false,
        success: function (result) {
            row.after("<tr id='row_" + parentId + "'><td colspan='14'>" + result + "</td></tr>");
            el.hide();
            $("#buttonCloseSub_" + parentId).show();
        }
    });
}

function closeSubItems(element, parentId) {
    if (OpenedForEdit) {
        alert("Item opened for edit - close it first.");
        return;
    }

    let el = $(element);
    $("#row_" + parentId).remove();
    el.hide();
    $("#buttonOpenSub_" + parentId).show();
}

var OpenedForEdit = false;

function editItemOpen(element, id) {
    OpenedForEdit = true;
    let el = $(element);
    let ctrl = $("#editItem_" + id);
    $("#editOpen_" + id).hide();
    $("#editClose_" + id).show();
    ctrl.show();
    
}

function editItemClose(element, id) {
    OpenedForEdit = false;
    let el = $(element);
    let ctrl = $("#editItem_" + id);
    $("#editOpen_" + id).show();
    $("#editClose_" + id).hide();
    ctrl.hide();
}

function deleteItem(element, id) {

}

function editTableRowSuccess(data, id) {
    var result = $(data);
    var current = $("#editItem_" + id);
    $(current).attr("id", "temp");
    $(current).insertBefore(result);
    $(current).remove();
}

function hasHash(id) {
    if (id == null || id.length < 1)
        return "";

    if (id[0] !== '#')
        id = '#' + id;

    return id;
}