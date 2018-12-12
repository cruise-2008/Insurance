var _inputphone = $('#inputphone');

var _a_phone_wrong = $('#a_phone_wrong');
var _a_phone_abscent = $('#a_phone_abscent');

$(".sms").mask("9        9         9        9");

$(".modal").click(function () {
    $("#modal").arcticmodal();
});

var stateClean = function () {
    _inputphone.removeClass("red");
    _a_phone_wrong.addClass("g-hidden");
    _a_phone_abscent.addClass("g-hidden");
    return;
}

// BALLANCE CONTROL
$('#a_ballance').click(function() {
    _common.post(_route.ballanceClick, {}, function () { _common.page.reload(); });
});


// VALIDATION
$(document).ready(function () {
    _inputphone
        .keydown(rejectNonNumeric)
        .keyup(function (ev) {
            stateClean();
            if (event.key === "Backspace") {
                return;
            }
            var phone = _inputphone.val();

            mask(phone, ev);

            if (validatePhone(phone)) {
                _common.post(_route.login, { Phone: phone }, function () { _common.page.reload(); });
            } else {
                if (phone.length === 11) {
                    _inputphone.addClass('red');
                    _a_phone_wrong.removeClass('g-hidden');
                }
            }
        });
});

var keys = {
    UP: 38,
    DOWN: 40,
    ENTER: 13,
    ESC: 27,
    PLUS: 43,
    A: 65,
    Z: 90,
    ZERO: 48,
    NINE: 57,
    SPACE: 32,
    BSPACE: 8,
    TAB: 9,
    DEL: 46,
    CTRL: 17,
    CMD1: 91, // Chrome
    CMD2: 224 // FF
};

function validatePhone(phone) {

    var filter = /^(50|63|66|67|73|91|92|93|94|95|96|97|98|99)-?(\d{3})-?(\d{4})$/;
    if (filter.test(phone)) {
        return true;
    } else {
        return false;
    }
}

function rejectNonNumeric(event) {
    if (event.keyCode === keys.BSPACE) {
        _inputphone.val(_inputphone.val().slice(0, -1));
        event.preventDefault();
        return false;
    }
    return (isFinite(event.key) ||
            event.keyCode === keys.DEL ||
            event.keyCode === keys.TAB ||
            event.keyCode === keys.UP ||
            event.keyCode === keys.DOWN ||
            event.keyCode === keys.LEFT ||
            event.keyCode === keys.RIGHT
        );
}

function mask(phone) {
    var tel = "";
    var val = phone.replace(/[^\d]*/g, "").split("");
    var len = val.length;

    for (var i = 0; i < len; i++) {
        if (i === 1) {
            val[i] = val[i] + "-";
        }
        else if (i === 4) {
            val[i] = val[i] + "-";
        }
        tel = tel + val[i];
    }
    _inputphone.val(tel);
}