

window.onload = function(){
	$('#loading-mask').fadeOut();
}

var onlyOpenTitle="欢迎使用";//不允许关闭的标签的标题

$(function(){
	InitLeftMenu();
	tabClose();
	tabCloseEven();

/* 选择TAB时刷新内容
	$('#tabs').tabs({
        onSelect: function (title) {
            var currTab = $('#tabs').tabs('getTab', title);
            var iframe = $(currTab.panel('options').content);

			var src = iframe.attr('src');
			if(src)
				$('#tabs').tabs('update', { tab: currTab, options: { content: createFrame(src)} });

        }
    });
*/
})

//初始化左侧
function InitLeftMenu() {
	$("#nav").accordion({animate:false,fit:true,border:false});
	var selectedPanelname = '';
    $.each(_menus.menus, function(i, n) {
		var menulist ='';
		menulist +='<ul class="navlist">';
        $.each(n.menus, function(j, o) {
			menulist += '<li><div ><a ref="'+o.menuid+'" href="#" rel="' + o.url + '" ><span class="icon '+o.icon+'" >&nbsp;</span><span class="nav">' + o.menuname + '</span></a></div> ';

			if(o.child && o.child.length>0)
			{
				//li.find('div').addClass('icon-arrow');

				menulist += '<ul class="third_ul">';
				$.each(o.child,function(k,p){
					menulist += '<li><div><a ref="'+p.menuid+'" href="#" rel="' + p.url + '" ><span class="icon '+p.icon+'" >&nbsp;</span><span class="nav">' + p.menuname + '</span></a></div> </li>'
				});
				menulist += '</ul>';
			}

			menulist+='</li>';
        })
		menulist += '</ul>';

		$('#nav').accordion('add', {
            title: n.menuname,
            content: menulist,
				border:false,
            iconCls: 'icon ' + n.icon
        });

		if(i==0)
			selectedPanelname =n.menuname;

    });
	$('#nav').accordion('select',selectedPanelname);



	$('.navlist li a').click(function(){
		var tabTitle = $(this).children('.nav').text();

		var url = $(this).attr("rel");
		var menuid = $(this).attr("ref");
		var icon = $(this).find('.icon').attr('class');

		var third = find(menuid);
		if(third && third.child && third.child.length>0)
		{
			$('.third_ul').slideUp();

			var ul =$(this).parent().next();
			if(ul.is(":hidden"))
				ul.slideDown();
			else
				ul.slideUp();



		}
		else {
		    /////////////////////////////////
		    if (tabTitle == "添加商品") {
		        var DialogWidth = "1200";
		        var DialogHeight = "608";


		        var stuObj = { name: "xy", age: 22 };
		        var whObj = { width: DialogWidth, height: DialogHeight };
		        openShowModalDialog("pro.aspx", stuObj, whObj);
		        return  false;
		    }
            ////////////////////////////////////////



			addTab(tabTitle,url,icon);
			$('.navlist li div').removeClass("selected");
			$(this).parent().addClass("selected");
		}
	}).hover(function(){
		$(this).parent().addClass("hover");
	},function(){
		$(this).parent().removeClass("hover");
	});





	//选中第一个
	//var panels = $('#nav').accordion('panels');
	//var t = panels[0].panel('options').title;
    //$('#nav').accordion('select', t);
}
//获取左侧导航的图标
function getIcon(menuid){
	var icon = 'icon ';
	$.each(_menus.menus, function(i, n) {
		 $.each(n.menus, function(j, o) {
		 	if(o.menuid==menuid){
				icon += o.icon;
			}
		 })
	})

	return icon;
}

function find(menuid){
	var obj=null;
	$.each(_menus.menus, function(i, n) {
		 $.each(n.menus, function(j, o) {
		 	if(o.menuid==menuid){
				obj = o;
			}
		 });
	});

	return obj;
}

function addTab(subtitle,url,icon){
	if(!$('#tabs').tabs('exists',subtitle)){
		$('#tabs').tabs('add',{
			title:subtitle,
			content:createFrame(url),
			closable:true,
			icon:icon
		});
	}else{
		$('#tabs').tabs('select',subtitle);
		$('#mm-tabupdate').click();
	}
	tabClose();
}

function createFrame(url)
{
	var s = '<iframe scrolling="auto" frameborder="0"  src="'+url+'" style="width:100%;height:100%;"></iframe>';
	return s;
}

function tabClose()
{
	/*双击关闭TAB选项卡*/
	$(".tabs-inner").dblclick(function(){
		var subtitle = $(this).children(".tabs-closable").text();
		$('#tabs').tabs('close',subtitle);
	})
	/*为选项卡绑定右键*/
	$(".tabs-inner").bind('contextmenu',function(e){
		$('#mm').menu('show', {
			left: e.pageX,
			top: e.pageY
		});

		var subtitle =$(this).children(".tabs-closable").text();

		$('#mm').data("currtab",subtitle);
		$('#tabs').tabs('select',subtitle);
		return false;
	});
}


//绑定右键菜单事件
function tabCloseEven() {

    $('#mm').menu({
        onClick: function (item) {
            closeTab(item.id);
         
        }
    });

    return false;
}

function closeTab(action)
{
  
    var alltabs = $('#tabs').tabs('tabs');

    var currentTab =$('#tabs').tabs('getSelected');
	var allTabtitle = [];
	$.each(alltabs,function(i,n){
		allTabtitle.push($(n).panel('options').title);
	})


    switch (action) {
        case "tabupdate":
            var iframe = $(currentTab.panel('options').content);
            var src = iframe.attr('src');
            $('#tabs').tabs('update', {
                tab: currentTab,
                options: {
                    content: createFrame(src)
                }
            })
            break;
        case "close":
            var currtab_title = currentTab.panel('options').title;
            $('#tabs').tabs('close', currtab_title);
            break;
        case "closeall":
            $.each(allTabtitle, function (i, n) {
                if (n != onlyOpenTitle){
                    $('#tabs').tabs('close', n);
				}
            });
            break;
        case "closeother":
            var currtab_title = currentTab.panel('options').title;
            $.each(allTabtitle, function (i, n) {
                if (n != currtab_title && n != onlyOpenTitle)
				{
                    $('#tabs').tabs('close', n);
				}
            });
            break;
        case "closeright":
            var tabIndex = $('#tabs').tabs('getTabIndex', currentTab);

            if (tabIndex == alltabs.length - 1){
                alert('亲，后边没有啦 ^@^!!');
                return false;
            }
            $.each(allTabtitle, function (i, n) {
                if (i > tabIndex) {
                    if (n != onlyOpenTitle){
                        $('#tabs').tabs('close', n);
					}
                }
            });

            break;
        case "closeleft":
            var tabIndex = $('#tabs').tabs('getTabIndex', currentTab);
            if (tabIndex == 1) {
                alert('亲，前边那个上头有人，咱惹不起哦。 ^@^!!');
                return false;
            }
            $.each(allTabtitle, function (i, n) {
                if (i < tabIndex) {
                    if (n != onlyOpenTitle){
                        $('#tabs').tabs('close', n);
					}
                }
            });

            break;
        case "exit":
            $('#closeMenu').menu('hide');
            break;
    }
}


//弹出信息窗口 title:标题 msgString:提示信息 msgType:信息类型 [error,info,question,warning]
function msgShow(title, msgString, msgType) {
	$.messager.alert(title, msgString, msgType);
}


function refreshTab() {
 
    var index = $('#tabs').tabs('getTabIndex', $('#tabs').tabs('getSelected'));
  
    if (index != -1) {   
      //  console.log($('#tabs').tabs('getTab', index).panel());
        var mm = $('#tabs').tabs('getTab', index).panel()
        mm.panel('refresh');

      //  $('#tabs').tabs('getTab', index).panel('refresh');
    }
}

function closeTab2() {
    $('.tabs-inner span').each(function (i, n) {
        var t = $(n).text();
        if (t != '') {
            $('#tabs').tabs('close', t);
        }
    });
}

///////////////////////
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