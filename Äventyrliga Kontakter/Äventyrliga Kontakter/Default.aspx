<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Äventyrliga_Kontakter.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1> Äventyrliga Kontakter</h1>

        <asp:ListView ID="ListView1" runat="server"
            ItemType="Äventyrliga_Kontakter.Model.Contact"
            SelectMethod="ListView1_GetData"
            DataKeyNames="ContactID">
          

            <LayoutTemplate>
                <table>

                    <tr>
                         <th>
                             Förnamn
                         </th>
                        <th>
                             Efternamn
                         </th>
                        <th>
                             Epost
                         </th>
                    </tr>

                    <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>

                </table>
            </LayoutTemplate>

            
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="FnameLabel" runat="server" Text="<%#: Item.FirstName %>"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LnameLabel" runat="server" Text="<%#: Item.LastName %>"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="EmailLabel" runat="server" Text="<%#: Item.EmailAdress %>"></asp:Label>
                    </td>
                </tr>
                

            </ItemTemplate>

            <EmptyDataTemplate>

                <p> Kontakter Saknas</p>

            </EmptyDataTemplate>

        </asp:ListView>


    </div>
    </form>
</body>
</html>
