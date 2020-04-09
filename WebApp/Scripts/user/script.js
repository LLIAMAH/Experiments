/// <reference path="../jquery-3.4.1.intellisense.js" />

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