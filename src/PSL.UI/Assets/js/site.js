var ajax = {};

ajax.fetchHtml = function (url, container) {
    $.ajax({
        url: url,
        data: {},
        type: "GET",
        dataType: "html",
        beforeSend: function () {
            $(container).append('<div class="loading"></div>');
        },
        success: function (data, textStatus, jqXHR) {
            $(container).html(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error(jqXHR.status + "->" + jqXHR.responseText + "->" + errorThrown);

            $(container).find(".loading").remove();
        },
        complete: function () {
            $(container).find(".loading").remove();
        }
    });
};

ajax.fetchJson = function (url,data, callback) {
      
    $.ajax({
        url: url,
        data: JSON.stringify(data),
        type: "POST",
        contentType: "application/json",
        beforeSend: function () {
            $("body").append('<div class="loading"></div>');
        },
        success: function (data, textStatus, jqXHR) {

            if (callback && (typeof callback == "function"))
                callback(data);
            else {
                console.log(data);
            } 

        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.error(jqXHR.status + "->" + jqXHR.responseText + "->" + errorThrown);

            $("body .loading").remove();
        },
        complete: function () {
            $("body .loading").remove();
        }
    });

};