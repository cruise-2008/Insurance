var _common = {};
_common.msg = {};
_common.page = {};
_common.cookie = {};


_common.msg.success = function (msg) {
    toastr.success(msg);
}

_common.msg.error = function (msg) {
    toastr.error(msg);
}

_common.post = function (url, obj, success, successmsg, error, errormsg) {
    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify(obj),
        contentType: "application/json",
        error: function(data) {
            _common.msg.error(errormsg + ": " + data.statusText);
            if (error) {
                error();
            }
        },
        success: function (data) {
            if (successmsg != undefined && successmsg !== "") {
                _common.msg.success(successmsg);
            }
            if (success) {
                success(data);
            }
        }
    });
}

_common.page.reload = function() {
    location.reload();
}


_common.cookie.get = function (name) {
    var nameEq = name + "=";
    var ca = document.cookie.split(";");
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) === " ") c = c.substring(1, c.length);
        if (c.indexOf(nameEq) === 0) return c.substring(nameEq.length, c.length);
    }
    return null;
}

_common.cookie.set = function (name, value, minutes) {
    var expires = "";
    if (minutes) {
        var date = new Date();
        date.setTime(date.getTime() + (minutes * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

_common.cookie.removeAll = function () {
    var cookies = document.cookie.split(";");
    for (var i = 0; i < cookies.length; i++) {
        var equals = cookies[i].indexOf("=");
        var name = equals > -1 ? cookies[i].substr(0, equals) : cookies[i];
        document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
}