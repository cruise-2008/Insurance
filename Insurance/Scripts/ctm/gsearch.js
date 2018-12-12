//https://jsfiddle.net/upsidown/q8XS6/

_gsearch = {};
_gsearch.autocomplete = {};

_gsearch.geolocate = function () {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var geolocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            _gsearch.autocomplete.setBounds(new google.maps.LatLngBounds(geolocation, geolocation));
        });
    }
}

_gsearch.init = function (id, callback) {
    $("#" + id).on('focus', function () {
        _gsearch.geolocate();
    });

    var options = {
        types: ['(cities)'],
        componentRestrictions: { country: "UA" }
    };

    _gsearch.autocomplete = new google.maps.places.Autocomplete((document.getElementById(id)), options);

    google.maps.event.addListener(_gsearch.autocomplete, 'place_changed', function () {
        var place = _gsearch.autocomplete.getPlace();
        callback(place);
    });
}

_gsearch.getCurrentPlace = function (callback) {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var geocoder = new google.maps.Geocoder();
            var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
            geocoder.geocode({ 'latLng': latlng }, function (results, status) {
                if (status === "OK") {
                    callback(results);
                }
            });
        });
    }
}