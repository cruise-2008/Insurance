var _osago = {};
_osago.defaultLoading = true;

_osago.modes = {
    auto: "auto",
    moto: "moto",
    lorry: "lorry",
    bus: "bus",
    trailer: "trailer"
};

_osago.calc = {
    place: "",
    groupId: "",
    taxi: false,
    privilege: false,
    eu: false
}

_osago.priceUpdate = function () {
    $.each(_data.Companies, function(i, v) {
        v.Price = _data.Bp;
        if (_osago.calc.taxi) {
            v.Price *= v.Ktaxi;
        }
        if (_osago.calc.privilege) {
            v.Price *= v.Kprivileges;
        }
        if (_osago.calc.eu) {
            v.Price *= v.PlaceEu;
        }
        else {
            if (_osago.calc.place === "") {
                v.Price *= v.PlaceDefault;
            } else {
                var plaseMatch = false;
                $.each(v.Places, function(j, w) {
                    if (w.PlaceGoogleId === _osago.calc.place) {
                        v.Price *= w.K;
                        plaseMatch = true;
                    }
                });
                if (!plaseMatch) {
                    v.Price *= v.PlaceDefault;
                }
            }
        }
        $.each(v.Groups, function (j, w) {
            if (w.GroupId === _osago.calc.groupId) {
                v.Price *= w.K;
            }
        });
        v.Price = v.Price.toFixed(2);
    });

    var price;
    $.each(_data.Companies, function (i, v) {
        if (price === undefined) {
            price = v.Price;
        } 
        else if (v.Price < price) {
            price = v.Price;
        }
    });
    $("#span_price").text(price);
}


_osago.volumeClick = function (groupId) {
    _osago.calc.groupId = groupId;
    _osago.priceUpdate();
}

_osago.setTaxi = function () {
    _osago.calc.taxi = !_osago.calc.taxi;
    _osago.priceUpdate();
}

_osago.setPrivilege = function () {
    _osago.calc.privilege = !_osago.calc.privilege;
    _osago.priceUpdate();
}

_osago.setEu = function () {
    _osago.calc.eu = !_osago.calc.eu;
    if (_osago.calc.eu) {
        $("#inpt_osago_gsearch").attr("disabled", true);
        $("#inpt_osago_gsearch").val("");
        $("#p_choosen_place").text("EU");
        _osago.calc.place = "";
    } else {
        $("#p_choosen_place").text("");
        $("#inpt_osago_gsearch").attr("disabled", false);
    }
    _osago.priceUpdate();
}

_osago.build = {};
_osago.build.volumeItem = function (item) {
    return "<div class='item2'>" + 
                    "<label class='db rL'>" +
                    "<input type='radio' name='2' class='db box inputbox'>" +
                    "<b class='db' onclick='_osago.volumeClick(" + item.Id + ")'>" + item.Text + "</b>" +
                "</label>" +
            "</div>";
}


_osago.managePrevAndTaxi = function (mode) {
    var divtaxi = $("#div_taxi");
    var divprev = $("#div_prev");

    var taxi = divtaxi.find("input");
    var prev = divprev.find("input");

    if (mode !== _osago.modes.auto) {
        if (_osago.calc.privilege) {
            prev.click();
        }
        divprev.addClass("muted");
        prev.attr("disabled", true);

        if (mode !== _osago.modes.bus) {
            if (_osago.calc.taxi) {
                taxi.click();
            }
            divtaxi.addClass("muted");
            taxi.attr("disabled", true);
        } else {
            divtaxi.removeClass("muted");
            taxi.attr("disabled", false);
        }
    } else {
        divprev.removeClass("muted");
        prev.attr("disabled", false);
        divtaxi.removeClass("muted");
        taxi.attr("disabled", false);
    }
}


_osago.setmode = function (mode) {
    var divgroups = $("#div_groups");
    divgroups.empty();
    $.each(_data.Groups, function (i, v) {
        if (v.Mode === mode) {
            var item = _osago.build.volumeItem(v);
            divgroups.append(item);
        }
    });
    $(".item2 b").first().click();
    _osago.managePrevAndTaxi(mode);
}

_osago.setmodeDefault = function () {
    $(".item1 b").first().click();
}

_osago.setCurrentPlace = function () {
    var callBack = function (places) {
        $.each(places, function (i, v) {
            var types = ["locality", "political"];
            var isPoint = (v.types.length === types.length) && v.types.every(function (element, index) {
                return element === types[index];
            });
            if (isPoint) {
                var cityName = v.formatted_address.split(",")[0];
                $("#inpt_osago_gsearch").val(cityName);
                $("#p_choosen_place").text(cityName);
                _osago.calc.place = v.place_id;
                _osago.priceUpdate();
                return;
            }
        });
    }
    _gsearch.getCurrentPlace(callBack);
}

_osago.setPlace = function (place) {
    _osago.calc.place = place.place_id;
    $("#p_choosen_place").text(place.formatted_address.split(",")[0]);
    _osago.priceUpdate();
}

_osago.init = function() {
    _gsearch.init("inpt_osago_gsearch", _osago.setPlace);
    _osago.setCurrentPlace();
    _osago.setmodeDefault();
}();