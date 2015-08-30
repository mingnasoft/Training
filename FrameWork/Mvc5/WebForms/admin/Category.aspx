<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/admin/admin.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Mvc5.WebForms.admin.Category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div id="cc" class="easyui-layout" style="width: 100%; min-height: 500px;">
        <div data-options="region:'center',title:'账号列表',noheader:true,border:false" style="padding: 0px; background: #fff;">
            <div style="margin-bottom: 10px;">

                <input id="leibieselect" name="dept" value="" />

                <input id="dd" type="text" class="easyui-datebox" data-options="required:true,prompt:'请选择日期'"/>
                
                <input  value="0" type="radio"  name="cks"/> <input  value="1" type="radio"  name="cks"/> <input id="Checkbox1" type="checkbox" name="checkb" />
                 


                <script>

                    $(function () {


                        bind1();

                    })
                    function msgV2(msg, miao, tubiao, url) {
                        layer.closeAll();

                        layer.msg(msg, { icon: tubiao });
                        bind1();
                        if (url != "") jump(0, url)


                    }
                    function bind1() {
                        var _proclass = "";
                        $('#leibieselect').combotree({
                            url: '/Category/combotree',
                            required: true,
                            lines: true, prompt: '请选择分类',
                            onlyLeafCheck: true, checkbox: true, multiple: false,
                            onLoadSuccess: function (node, data) {
                                if ($.trim(_proclass) != "") {
                                    $('#leibieselect').combotree('setValue', _proclass);
                                    //  $('#proclass').combotree('disable');
                                    bind(_proclass);
                                }
                            },
                            onSelect: function (node) {
                                //console.log(node.children.length);  //这里是点选文字的时候才会触发,它不关你事勾还是不勾,点击文字就触发
                                //if (node.children.length > 0) {
                                //    $.show_warning("提示", "只能选择末级节点");
                                //    $('#proclass').combotree('clear');
                                //    return;
                                //}
                                ///  设置规则

                                bind(node.id);
                                ///
                            }
                        });
                    }
                </script>


            </div>

            <table id="dg"></table>
            <script>
                function bind(rowid) {
                    $('#dg').datagrid({
                        pagination: true, showFooter: true, width: '100%', checkbox: true,
                        singleSelect: true,

                        selectOnCheck: true,

                        checkOnSelect: true,
                        url: '/Category/datagrid?parentRowID=' + rowid,
                        columns: [[
                            { field: 'ck', checkbox: true },
                            { field: 'title', title: '名称', width: 100 },
                            { field: 'SeqNo', title: '排序', width: 100, align: 'right' },

                                   { field: 'ltime', title: '日期', width: 100, align: 'right' }
                        ]],
                        toolbar: [{
                            iconCls: 'icon-add',
                            handler: function () {
                                //////

                                showuser("");
                                ///////////////////
                            }
                        }, '-', {
                            iconCls: 'icon-edit',
                            handler: function () {
                                var checkedItems = $('#dg').datagrid('getChecked');
                                showuser(checkedItems[0].RowID);
                            }
                        }, '-', {
                            iconCls: 'icon-remove',
                            handler: function () {
                                var checkedItems = $('#dg').datagrid('getChecked');
                                del(checkedItems[0].RowID);
                            }
                        }],
                        onDblClickRow: function (rowIndex, rowData) {

                            showuser(rowData.RowID);
                        }

                    });
                }
            </script>

        </div>
    </div>
    <%-- 添加开始--%>
    <script>
        var indexLoad;
        function showuser(rowid) {


            parent.layer.open({
                type: 2,
                area: ['600px', '320px'],
                shade: true,
                closeBtn: 1,
                title: "分类管理", //false不显示标题
                content: '/Category/loadItem?rowid=' + rowid,
                cancel: function (index) {
                    layer.close(index);
                    reloadDG();
                }
            });

    
        }

        function del(rowid) {
            layer.confirm('您确定要删除？', {
                btn: ['确定', '取消'], //按钮
                shade: false //不显示遮罩
            }, function () {

                $.post('/Category/del', { rowid: rowid }, function (data) {

                    layer.msg(data.msg, { icon: 1 });
                    if (data.type == 1)
                    { reloadDG(); }
                });

            }, function () {

            });




        }
        function reloadDG() {
            $('#dg').datagrid('reload');
        }

    </script>
</asp:Content>



