


function getApi(url, success, error) {
    $.ajax({
        type: "GET",
        url: url,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            success(data)
        },

        failure: function (data) {
            error(data)
        },
        error: function (data) {
            error(data)
        }

    });
}

function convertDate(date) {
    let current_datetime = new Date(date);
    return current_datetime.getDate() + "-" + (current_datetime.getMonth()+1) + "-" + current_datetime.getFullYear();
}

