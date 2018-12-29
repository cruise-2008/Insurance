var _osago = {};

_osago.modes = {
    auto: "auto",
    moto: "moto",
    lorry: "lorry",
    bus: "bus",
    trailer: "trailer"
};

_osago.calc = {
    place: 1,
    mode: 1,
    taxi: 1,
    privilege: 1
}

_osago.priceUpdate = function () {
    var price = (_osago.calc.place * _osago.calc.mode * _osago.calc.taxi * _osago.calc.privilege).toFixed(2);
    $('#span_price').text(price);
}

_osago.volumeClick = function (k) {
    _osago.calc.mode = k;
    _osago.priceUpdate();
}

_osago.settaxi = function () {
    _osago.calc.taxi = 0.9;
    _osago.priceUpdate();
}

_osago.settaxi = function () {
    debugger;
    if ($('#taxi').is(':checked')) {
        _osago.calc.taxi = 0.9;
        _osago.priceUpdate();

    }
    else {
        _osago.setmode(_osago.modes.auto);
      //  _osago.setmode("auto");
    }

}
_osago.setprivilege = function () {
    debugger;
    if ($('#privileges').is(':checked')) {
        _osago.calc.taxi = 0.9;
        _osago.priceUpdate();

    }
    else {
        _osago.setmode(_osago.modes.auto);
        //  _osago.setmode("auto");
    }

}
_osago.ISEU = function () {

    if ($('#EU').is(':checked')) {
        var Europe = $('#EU').val();
   
      
        $.ajax({
            type: "POST",
            url: "/Osago/GetEU",
            data: '{eu: "' + Europe + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                //alert("Hello: " + response.Name + " .\nCurrent Date and Time: " + response.DateTime);
            },
          
        });
    }
}
_osago.build = {};
_osago.build.volumeItem = function (item) {
    return "<div class='item2'>" +
        "<label class='db rL'>" +
        "<input type='radio' name='2' class='db box inputbox'>" +
        "<b class='db' onclick='_osago.volumeClick(" + item.K + ")'>" + item.Text + "</b>" +
        "</label>" +
        "</div>";
}

_osago.setmode = function (mode) {
    var divgroups = $('#div_groups');
    divgroups.empty();
    $.each(_data.Groups, function (i, v) {
        if (v.Mode === mode) {
            var item = _osago.build.volumeItem(v);
            divgroups.append(item);
        }
    });
    $('.item2 b').first().click();
}

_osago.setmodeDefault = function () {
    $('.item1 b').first().click();
}

_osago.setCurrentPlace = function () {
    var callBack = function (places) {
        var isPlaceFound = 0;
        $.each(places, function (i, v) {
            $.each(_data.Companies, function (j, w) {
                $.each(w.Places, function (y, g) {
                    //  alert($('#inpt_osago_gsearch').val());
                    if (v.place_id === g.PlaceGoogleId) {
                        isPlaceFound = 1;
                      //  alert($('#inpt_osago_gsearch').val());
                        $('#inpt_osago_gsearch').val(g.Name);
                        $('#p_choosen_place').text(g.Name);
                        _osago.calc.place = g.K;
                        _osago.priceUpdate();
                        return;
                    }
                });
            });
        });
        if (isPlaceFound === 0) {
            if ($('#inpt_osago_gsearch').val() !== '') {
                alert('Enter the place of registration of the vehicle')
            }
        }
    }
    _gsearch.getCurrentPlace(callBack);
}

_osago.setPlace = function (place) {
    console.log(place);
}

_osago.init = function () {
    _gsearch.init("inpt_osago_gsearch", _osago.setPlace);
    _osago.setmodeDefault();
    _osago.setCurrentPlace();
}();