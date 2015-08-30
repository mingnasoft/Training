<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/Site1.Master" AutoEventWireup="true"
    CodeBehind="default.aspx.cs" Inherits="Mvc5.WebForms._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </form>

    <form id="form2" action="/user/add" method="post" data-ajax="true">
        <input name="name" type="text" />

        <input name="Psword" type="text" />
        <input id="Submit1" type="submit" value="submit" />
    </form>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <table id="dg"></table>
    <script>
        layer.alert('内容')
        //$('#dg').datagrid({
        //    pagination: true, showFooter: true,
        //    url: '/user/index',
        //    columns: [[
        //        { field: 'Name', title: 'Name', width: 100 },
        //        { field: 'Psword', title: 'Price', width: 100, align: 'right' }
        //    ]]
        //});
    </script>

    <form action="" method="post" class="basic-grey">
        <h1>Contact Form
            <span>Please fill all the texts in the fields.</span>
        </h1>
  
       <table><tr><td class="td1">Message :</td><td><select name="selection">
                <option value="Job Inquiry">Job Inquiry</option>
                <option value="General Question">General Question</option>
            </select></td></tr>

           <tr><td class="td1">Message :</td><td>  <textarea id="Textarea1" name="message" placeholder="Your Message to Us"></textarea></td></tr>

       </table>

    
        <label>
            <span>&nbsp;</span>
            <input type="button" class="button" value="Send" />
        </label>
    </form>
</asp:Content>
