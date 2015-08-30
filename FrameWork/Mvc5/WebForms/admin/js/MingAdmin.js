//iframe自适应高度
function dyniframesize(iframename) {
    // $(iframename).attr("width", "100%");
    //   $(iframename).css({ width: "100%", background: "blue" });
    //取到窗口的高度 
    var winH = $(window).height() - 70;
    //取到页面的高度 
    var bodyH = $(document).height() - 70;
    if (bodyH > winH) {
        document.getElementById($(iframename).attr("id")).height = bodyH + "px";
    } else {
        document.getElementById($(iframename).attr("id")).height = winH + "px";
    }

}

/**
* @author ming
*
* 接收一个以逗号分割的字符串，返回List，list里每一项都是一个字符串（做编辑功能的时候 传入id 然后自动勾选combo系列组件）
*
* @returns list
*/ 
//用法   $('#zhengyijigou').combogrid('setValues', stringToList(QiTaJiGou));
stringToList = function (value) {
    if (value != undefined && value != '') {
        var values = [];
        var t = value.split(',');
        for (var i = 0; i < t.length; i++) {
            values.push('' + t[i]); /* 避免将ID当成数字 */
        }
        return values;
    } else {
        return [];
    }
};


////////////////////////////////
//几秒后跳转
function jump(count, url) {
    window.setTimeout(function () {
        count--;
        if (count > 0) {
            //  $('#num').attr('innerHTML', count);
            jump(count, url);
        } else {

            window.location.href = url;
        }
    }, 1000);
}

/////


function openShowModalDialog(url, param, whparam, e) {

    // 传递至子窗口的参数   
    var paramObj = param || {};

    // 模态窗口高度和宽度   
    var whparamObj = whparam || { width: 500, height: 500 };

    // 相对于浏览器的居中位置   
    //var bleft = ($(window).width() - whparamObj.width) / 2;   
    //var btop = ($(window).height() - whparamObj.height) / 2;  
    var btop = (window.screen.availHeight - 20 - whparamObj.height) / 2;
    var bleft = (window.screen.availWidth - 10 - whparamObj.width) / 2;

    //var iTop = (window.screen.availHeight - 20 - iHeight) / 2;
    //var iLeft = (window.screen.availWidth - 10 - iWidth) / 2;

    // 根据鼠标点击位置算出绝对位置   
    //var tleft = e.screenX - e.clientX;   
    //var ttop = e.screenY - e.clientY;   

    // 最终模态窗口的位置   
    //var left = bleft + tleft;   
    //var top = btop + ttop;  
    var left = bleft;
    var top = btop;

    // 参数   
    var p = "help:no;status:no;center:yes;scroll:yes;";
    p += 'dialogWidth:' + (whparamObj.width) + 'px;';
    p += 'dialogHeight:' + (whparamObj.height) + 'px;';
    p += 'dialogLeft:' + left + 'px;';
    p += 'dialogTop:' + top + 'px;';

    
    if (typeof showModalDialog !== "function") {

        window.open(url, 'uploadpic', "height=" + whparamObj.height + ",width=" + whparamObj.width + ",top=" + top + ",left=" + left + ",menubar=no,scrollbars=yes, resizable=no,location=no,status=no")

    }
    else {

        return window.showModalDialog(url, paramObj, p);
    }
    
}

//扩展Jquery    /// <屏幕居中>
///////////////////////////////////
jQuery.fn.center = function () {
    this.css("position", "absolute");
    this.css("top", Math.max(0, (($(window).height() - this.outerHeight()) / 2) +
                                                $(window).scrollTop()) + "px");
    this.css("left", Math.max(0, (($(window).width() - this.outerWidth()) / 2) +
                                                $(window).scrollLeft()) + "px");
    return this;
}

///////////////////////////////////////
///////////////////////////

function showloading(alertstr, loadingSeconds) {

    $("body").append("<div id='loading'></div>");
    /// <屏幕居中>
    $("#loading").center();
    /// </屏幕居中结束>

    $("#loading").text(alertstr);
    $("#loading").show();
    if ($.isNumeric(loadingSeconds) && loadingSeconds > 0) {
        setTimeout(function () { hideloading(); }, loadingSeconds * 1000);
    }
}
function hideloading() {
    $("#loading").empty();
    $("#loading").hide();
}




function DrawImage(ImgD,iwidth,iheight){ //参数(图片,允许的宽度,允许的高度) 
    var image = new Image(); image.src = ImgD.src;
    if (image.width > 0 && image.height > 0) {
        if (image.width / image.height >=  iwidth / iheight) {
            if (image.width > iwidth) {
                ImgD.width = iwidth;
                ImgD.height = (image.height * iwidth) / image.width;
            } else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
        } else {
            if (image.height > iheight) {
                ImgD.height = iheight;
                ImgD.width = (image.width * iheight) / image.height;
            } else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
        }
    }
} 



