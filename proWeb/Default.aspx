<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p>
            Code &nbsp;<asp:TextBox ID="text_Code" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>
        <p>
            Name &nbsp;<asp:TextBox ID="text_Name" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>
        <p>
             Amount &nbsp;<asp:TextBox ID="text_Amount" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>
         <p>
             Category &nbsp; <asp:DropDownList ID="DropDownList" runat="server" Height="25px" Width="210px" Style="margin-top: 5px; margin-left: 25px;" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                <asp:ListItem Text="Computing" Value="Computing"></asp:ListItem>
                <asp:ListItem Text="Telephony" Value="Telephony"></asp:ListItem>
                <asp:ListItem Text="Gaming" Value="Gaming"></asp:ListItem>
                <asp:ListItem Text="Home Appliances" Value="HomeAppliances"></asp:ListItem>
                </asp:DropDownList>
        </p>
         <p>
            Price &nbsp;<asp:TextBox ID="text_Price" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>
         <p>
            Creation Date &nbsp;<asp:TextBox ID="text_CreationDate" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:TextBox>
        </p>

    </div>

    <asp:Button text="Create" onClick="onCreate" ID="buttom_Create" runat="server"  />
    <asp:Button text="Update" onClick="onUpdate" ID="buttom_Update" runat="server" />
    <asp:Button text="Delete" onClick="onDelete" ID="buttom_Delete" runat="server" />
    <asp:Button text="Read" onClick="onRead" ID="buttom_Read" runat="server" />
    <asp:Button text="Read First" onClick="onReadFirst" ID="buttom_ReadFirst" runat="server" />
    <asp:Button text="Read Prev" onClick="onReadPrev" ID="buttom_ReadPrev" runat="server" />
    <asp:Button text="Read Next" onClick="onReadNext" ID="buttom_ReadNext" runat="server" />
    <asp:Label ID="outputMssg" runat="server"></asp:Label>
</asp:Content>
