function getCookies() {
    var cookies = [];
    var arr = new Array();
    if (document.cookie && document.cookie != '') {
        var split = document.cookie.split(';');
        for (var i = 0; i < split.length; i++) {
                var name_value = split[i].split("=");
                name_value[0] = name_value[0].replace(/^ /, '');
                if (name_value[0] != "_culture")
                {
                    name_value[1] = JSON.parse(name_value[1]);
                    cookies.push({ key: decodeURIComponent(name_value[0]), value: name_value[1] });
                }
        }
    }
    return cookies;
}

function checkCookie(cname, cvalue) {
    var cookies = getCookies();
    $.each(cookies, function (index, cookie) {
        if (cookie.key == cname) {
            cvalue["quantity"] += 1;
        }
    });
    var expires = new Date();
    expires.setTime(expires.getTime() + (7 * 24 * 60 * 60 * 1000));
    document.cookie = cname + "=" + JSON.stringify(cvalue) + "; expires=" + expires.toGMTString();
}

function deleteCookieLi(el) {
    if (el.value != null) {
        var expires = new Date();
        expires.setTime(expires.getTime() - 1);
        document.cookie = el.value + "=; expires=" + expires.toGMTString();

        while (el && el.nodeName.toLowerCase() != 'li') {
            el = el.parentNode;
        }
            el.parentNode.removeChild(el);
    }
}

function deleteCookieTr(el) {
    if (el.value != null) {
        var expires = new Date();
        expires.setTime(expires.getTime() - 1);
        document.cookie = el.value + "=; expires=" + expires.toGMTString();
        while (el && el.nodeName.toLowerCase() != 'tr') {
            el = el.parentNode;
        }
        el.parentNode.removeChild(el);
    }
}

function createOrder() {
    var cookies = getCookies();
    var orderItems = [];
    $.each(cookies, function (index, cookie) {
        orderItems.push({
            ProductID: cookie.value["productID"],
            SelectedColor: cookie.value["productColor"],
            SelectedSize: cookie.value["productSize"],
            Quantity: cookie.value["quantity"]
        })
    });

    $.ajax({
        url: $("#orderUrl").val(),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify({ list: orderItems }),
        success: function (result) {
            alert("success")
        },
        error: function () {
            alert("error");
        }
        });
}

function clearOrder() {
    var cookies = getCookies();
    $.each(cookies, function (index, cookie) {
        var expires = new Date();
        expires.setTime(expires.getTime() - 1);
        document.cookie = cookie.key + "=; expires=" + expires.toGMTString();
    });
    var table = document.getElementById('OrderTable');
    while (table.parentNode && table.parentNode.rows.length > 0)
        table.parentNode.removeChild(table);
}

function totalPrice() {
    var cookies = getCookies();
    var tp = 0;
    $.each(cookies, function (index, cookie) {
        tp += parseFloat(cookie.value["productPrice"]) * cookie.value["quantity"];
    });
    return tp;
}

function onAjaxBegin() {
    $("#filter").disabled = true;;
}

function onAjaxComplete() {
    $("#filter").disabled = false;
}

//function CategoryMenuFilter(el) {
//    var id = el.id;
//    $.ajax({
//        url: $("#menuCategoryUrl").val(),
//        type: "GET",
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            CategoryFilter(el);
//        },
//        error: function () {
//            alert("error");
//        }
//    });
//}
function CategoryFilter(el) {
    onAjaxBegin();
    var id = el.id;
    $.ajax({
        url: $("#categoryUrl").val(),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ CategoryId: id }),
        dataType: "json",
        success: function (result) {
            updateProductsList(result);
            onAjaxComplete();
        },
        error: function () {
            alert("error");
            onAjaxComplete();
        }
    });
}

function BrendFilter(el) {
    var id = el.id;
    onAjaxBegin();
    $.ajax({
        url: $("#brendUrl").val(),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ BrendId: id }),
        dataType: "json",
        success: function (result) {
            updateProductsList(result);
            onAjaxComplete();
        },
        error: function () {
            alert("error");
            onAjaxComplete();
        }
    });
}
function ColorFilter(el) {
    onAjaxBegin();
    var id = el.id;
    $.ajax({
        url: $("#colorUrl").val(),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ ColorId: id }),
        dataType: "json",
        success: function (result) {
            updateProductsList(result);
            onAjaxComplete();
        },
        error: function () {
            alert("error");
            onAjaxComplete();
        }
    });
}
function SizeFilter(el) {
    onAjaxBegin();
    var id = el.id;
    $.ajax({
        url: $("#sizeUrl").val(),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ SizeId: id }),
        dataType: "json",
        success: function (result) {
            updateProductsList(result);
            onAjaxComplete();
        },
        error: function () {
            alert("error");
            onAjaxComplete();
        }
    });
}