<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/admin/admin.Master" AutoEventWireup="true" CodeBehind="role.aspx.cs" Inherits="Mvc5.WebForms.admin.User.role" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="cc" class="easyui-layout" style="width:100%; min-height:500px;">   
     
    <div data-options="region:'east',title:'说明',split:true," style="width:100px; padding:5px;">

      这里放使用书名书

    </div>   
  
    <div data-options="region:'center',title:'账号列表',noheader:true,border:false" style="padding:0px;background:#fff;">

          <table id="dg"></table>
             <script>

                 $('#dg').datagrid({
                     pagination: true, showFooter: true, width: '100%', checkbox: true,
                     singleSelect: true,
                     selectOnCheck: true,
                     checkOnSelect: true,
                     url: '/role/index',
                     columns: [[
                         { field: 'ck', checkbox: true },
                         { field: 'RoleName', title: '角色名', width: 100 },
                         { field: 'Brief', title: '备注', width: 100, align: 'right' }
                     ]],
                     toolbar: [{
                         iconCls: 'icon-add',
                         handler: function () {
                             //////
                             showuser(0);
                             ///////////////////
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
                     }]

                 });
    </script>
    </div>   
</div>  
<%-- 添加开始--%>
      <script>
          function showuser(id) {
              layer.load(0, { time: 2 * 1000 });
              $("#adduser").load("/role/loadRole", { roleid: id }, function () {
                  layer.open({
                      type: 1,
                      area: '300px',
                      shade: false,
                      title: false, //不显示标题
                      content: $('#adduser'), //捕获的元素
                      cancel: function (index) {
                          layer.close(index);
                          //  this.content.show();
                          //   layer.msg('捕获就是从页面已经存在的元素上，包裹layer的结构', { time: 5000 });

                          // reloadDG();

                      }
                  });
              });
          }

          function del(id) {
              $("#adduser").load("/role/del", { roleid: id }, function (data) {
                  $("#adduser").html("");
                  var obj = jQuery.parseJSON(data);
                  layer.msg(obj.msg, { icon: 1 });
                  if (obj.type == 1)
                  { reloadDG(); }

              });
          }
          function reloadDG() {
           
              $('#dg').datagrid('reload');
          }

      </script>
    <div id="adduser" >
         
     </div>

<%--    添加结束--%>
</asp:Content>
