<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Admin_Home.aspx.cs" Inherits="Flipcart.Admin_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 161px;
        }
        .auto-style2 {
            width: 158px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style1">
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" Text="Category Manage"></asp:Label>
            </td>
            <td class="auto-style2">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Black" Text="Product Manage"></asp:Label>
            </td>
            <td>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black" Text="Manage Users"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Add_Category.aspx">Add Category</asp:HyperLink>
            </td>
            <td class="auto-style2">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Add_Product.aspx">Add Product</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/View_User_Deatails.aspx">Manage User</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Edit_Category.aspx">Edit Category</asp:HyperLink>
            </td>
            <td class="auto-style2">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Edit_Product.aspx">Edit Product</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
