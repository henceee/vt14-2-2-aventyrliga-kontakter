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
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        <asp:ListView ID="ListView1" runat="server"
            ItemType="Äventyrliga_Kontakter.Model.Contact"
            SelectMethod="ListView1_GetData"
            InsertMethod="ListView1_InsertItem"
            UpdateMethod="ListView1_UpdateItem"
            DeleteMethod="ListView1_DeleteItem"
            DataKeyNames="ContactID"
            InsertItemPosition="FirstItem">
          

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
                        <asp:Label ID="EmailLabel" runat="server" Text="<%#: Item.EmailAddress %>"></asp:Label>
                    </td>

                    <td>
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Ta Bort" CausesValidation="false"/>
                        <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false"/>
                    </td>
                </tr>
                

            </ItemTemplate>
            <InsertItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Text='<%#: BindItem.FirstName %>'></asp:TextBox>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" Text='<%#: BindItem.LastName %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddress" runat="server" Text='<%#: BindItem.EmailAddress %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till"/>
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false"/>
                    </td>
                        
                </tr>
                
            </InsertItemTemplate>

            <EditItemTemplate>

                 <tr>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Text='<%#: BindItem.FirstName %>'></asp:TextBox>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" Text='<%#: BindItem.LastName %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddress" runat="server" Text='<%#: BindItem.EmailAddress %>'></asp:TextBox>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara"/>
                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false"/>
                    </td>
                        
                </tr>

            </EditItemTemplate>

            <EmptyDataTemplate>

                <p> Kontakter Saknas</p>

            </EmptyDataTemplate>

        </asp:ListView>


    </div>
    </form>
</body>
</html>
