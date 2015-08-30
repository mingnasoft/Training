///////////////////////////////
//easyUI日期格式化扩展
function formatShortDateX(value) {
    if (value != null && value != undefined) {
        value = value.replace(/[a-zA-Z]/g, " "); //防止有英文
        value = value.replace(/(\.+\d+)/g, ""); //去除毫秒
        value = value.replace(/\//g, "-"); //防止有/
        if (value.length >= 10)
            value = value.substr(0, 10);//只要日期
    }
    else
        value = "";
    return value;
}
////////////////////////////////
/** 
* 在iframe中调用，在父窗口中出提示框(herf方式不用调父窗口)
*/
$.extend({
    show_warning: function (strTitle, strMsg) {
        $.messager.show({
            title: strTitle,
            width: 300,
            height: 100,
            msg: strMsg,
            closable: true,
            style: {
                right: '',
                top: document.body.scrollTop + document.documentElement.scrollTop,
                bottom: ''
            }
        });
    }
});

/** 
* 弹框
*/
$.extend({
    show_alert: function (strTitle, strMsg) {
        $.messager.alert(strTitle, strMsg);
    }
});


String.format = function () {
    if (arguments.length == 0)
        return null;

    var str = arguments[0];
    for (var i = 1; i < arguments.length; i++) {
        var re = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
        str = str.replace(re, arguments[i]);
    }
    return str;
}

// extend the 'equals' rule    
$.extend($.fn.validatebox.defaults.rules, {
    equals: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: 'Field do not match.'
    }
});