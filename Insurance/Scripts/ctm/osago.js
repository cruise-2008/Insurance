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
    taxi: false,// 1 means yes and 0 means no
    privilege: false,// 1 means yes and 0 means no
    isEU: false, // 1 means yes and 0 means no
    selectPlaceID: 1
}

_osago.UpdateEU = function (data) {
    debugger;
    if (data !== null) {
        var amount = (180 * data.coefficient * data.K * data.osago.K1000 * data.osago.K1000 * data.osago.Commission * data.osago.Ktaxi * data.osago.Kprivileges).toFixed(2);
        $('#span_price').text(amount);
    }
    else {
        var price = (_osago.calc.place * _osago.calc.mode * _osago.calc.taxi * _osago.calc.privilege).toFixed(2);
        $('#span_price').text(price);
    }
}
_osago.priceUpdate = function () {
    debugger;
    // get company coefficient from _data
    // _osago.calc.isEU calculation pending
    var data1 = { isEU: _osago.calc.isEU, isTaxi: _osago.calc.taxi, isPrivilege: _osago.calc.privilege, placeId: _osago.calc.selectPlaceID, groupK: _osago.calc.mode };

    $.ajax({
        type: "get",
        url: "/Osago/CalculateCoefficient",
        data: {isEU: _osago.calc.isEU , isTaxi:_osago.calc.taxi,isPrivilege: _osago.calc.privilege,placeId:_osago.calc.selectPlaceID ,groupK: _osago.calc.mode },
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            debugger;
            if (response !== null) {
                //alert("coefficient : " + response.coefficient);
                //_osago.UpdateEU(response);
                $('#span_price').text(response.data);
            } else {
                alert("Something went wrong");
            }
        },

      
    });

    //var price = 180 * (_osago.calc.place * _osago.calc.mode * _osago.calc.taxi * _osago.calc.privilege).toFixed(2);
    //$('#span_price').text(price);
}

_osago.volumeClick = function (k) {
    _osago.calc.mode = k;
    _osago.priceUpdate();
}


_osago.settaxi = function () {

    if ($('#taxi').is(':checked')) {
        _osago.calc.taxi =true;
        _osago.priceUpdate();

    }
    else {
     
        _osago.calc.taxi = false;
        _osago.priceUpdate();

    }

}
_osago.setprivilege = function () {
    
    if ($('#privileges').is(':checked')) {
        _osago.calc.privilege = true;
        _osago.priceUpdate();

    }
    else {
        _osago.calc.privilege = false;
        _osago.priceUpdate();
    }

}



_osago.ISEU = function () {
   
    if ($('#EU').is(':checked')) {
        _osago.calc.isEU = true;
        _osago.priceUpdate();        
    }
    else {
        _osago.calc.isEU = false;
        _osago.priceUpdate();
    }

} 



//_osago.ISEU2 = function () {
//    debugger;
//    if ($('#EU').is(':checked')) {
//        var Europe = $('#EU').is(':checked');
//        var a = $("div.item1 b.db").text();
//        var selValue = $('div.item1').find('b.db').text('');
//        //var selValue = $("div.item1 b.db").val(); 
//        alert(selValue);
       
//        $.ajax({
//            type: "POST",
//            url: "/Osago/Index",
//            data: '{eu: "' + Europe + '" }',
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            success: function (response) {
//                debugger;
//                if (response !== null) {
//                   //alert("coefficient : " + response.coefficient);
//                    _osago.UpdateEU(response);
//                } else {
//                    alert("Something went wrong");
//                }
//            },
       
//            error: function (response) {
//                alert("error");
//            }
//        });
//    }
//} 




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
            _osago.calc.selectPlaceID = v.place_id;

            $.each(_data.Companies, function (j, w) {
                $.each(w.Places, function (y, g) {
                    //  alert($('#inpt_osago_gsearch').val());
                    if (_osago.calc.isEU == 1) {
                        if (v.place_id === g.PlaceGoogleId && g.IsEU == true) {
                            isPlaceFound = 1;
                            //  alert($('#inpt_osago_gsearch').val());
                            $('#inpt_osago_gsearch').val(g.Name);
                            $('#p_choosen_place').text(g.Name);
                           // _osago.calc.place = g.K;
                          //  _osago.priceUpdate();
                            return;
                        }
                    }
                    else {
                        if (v.place_id === g.PlaceGoogleId && g.IsEU == false) {
                            isPlaceFound = 1;
                            //  alert($('#inpt_osago_gsearch').val());
                            $('#inpt_osago_gsearch').val(g.Name);
                            $('#p_choosen_place').text(g.Name);
                           // _osago.calc.place = g.K;
                         //   _osago.priceUpdate();
                            return;
                        }
                    }
                   
                });
            });
        });
        _osago.priceUpdate();
        if (isPlaceFound === 0) {
            if ($('#inpt_osago_gsearch').val() == '') {
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