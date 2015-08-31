<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/admin/admin.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="Mvc5.WebForms.admin.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-inline" style="padding-top: 10px; padding-bottom: 10px;">
        <div class="form-group">
          
            <input type="text" class="form-control" id="name" placeholder="请输入客户名" />
        </div>
        <div class="form-group">
            <input type="email" class="form-control" id="contact" placeholder="请输入联系人" />
        </div>
        <button type="button" onclick="Bind();" class="btn btn-primary">查询</button>
    </div>

    <div id="cc" class="easyui-layout" style="width: 100%; min-height: 500px;">

      
        <div data-options="region:'center',title:'账号列表',noheader:true,border:false" style="padding: 0px; background: #fff;">

            <table id="dg"></table>
            <script>
                $(function () {

                    Bind();

                })

                function Bind() {

                    $('#dg').datagrid({
                        pagination: true, showFooter: false, width: '100%', checkbox: true,
                        singleSelect: true, selectOnCheck: true, checkOnSelect: true,
                        queryParams: {
                            name: $("#name").val(),
                            contact: $("#contact").val()
                        },
                        url: '/customer/index',
                        columns: [[
                            { field: 'ck', checkbox: true },
                             { field: 'CustomreNo', title: '编号', width: 100 },
                            { field: 'CustomreName', title: '名称', width: 100 },
                            { field: 'ShortName', title: '简称', width: 100, align: 'right' },
                            { field: 'Contact1', title: '联系人1', width: 100, align: 'right' },
                            { field: 'Contact2', title: '联系人2', width: 100, align: 'right' },
                            { field: 'Tel1', title: '电话1', width: 100, align: 'right' },
                            { field: 'Tel2', title: '电话2', width: 100, align: 'right' },
                            { field: 'Address', title: '地址', width: 100, align: 'right' },
                            { field: 'ctime', title: '创建日期', width: 100, align: 'right' }
                        ]],
                        toolbar: [{
                            iconCls: 'icon-add',
                            handler: function () {
                                showuser(0);
                            }
                        }, '-', {
                            iconCls: 'icon-edit',
                            handler: function () {
                                var checkedItems = $('#dg').datagrid('getChecked');
                                showuser(checkedItems[0].ID);
                            }
                        }, '-', {
                            iconCls: 'icon-remove',
                            handler: function () {
                                var checkedItems = $('#dg').datagrid('getChecked');
                                del(checkedItems[0].ID);
                            }
                        }],
                        onDblClickRow: function (rowIndex, rowData) {

                            showuser(rowData.ID);
                        }

                    });
                }
            </script>

        </div>
    </div>

    <script>

        function showuser(ID) {

            //$("form").removeData("validator").removeData("unobtrusiveValidation");
            //$.validator.unobtrusive.parse($("form"));

            parent.layer.open({
                type: 2,
                area: ['800px', '580px'],
                shade: true,
                closeBtn: 1,
                title: "客户管理", //false不显示标题
                content: '/customer/loadItem?id=' + ID,
                cancel: function (index) {
                    layer.close(index);
                   // reloadDG();
                }
            });

        }

        function del(ID) {
            layer.confirm('您确定要删除？', {
                btn: ['Yes', 'NO'],
                shade: false //不显示遮罩
            },
            function () {
                $.post('/customer/del', { ID: ID }, function (data) {

                    layer.msg(data.msg, { icon: 1 });
                    if (data.type == 1)
                    {
                        reloadDG();
                    }
                });
            },
            function () {

            });

        }
        function reloadDG() {
            $('#dg').datagrid('reload');
        }

    </script>

</asp:Content>
