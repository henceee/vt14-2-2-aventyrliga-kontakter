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

        <asp:Panel ID="Sucess" runat="server" Visible="false">
            <p>Kontakten lades till</p>
        </asp:Panel>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Insert" />
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Edit" />

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

                     <asp:DataPager ID="DataPager" runat="server" PageSize="20">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText=" << "
                            ShowNextPageButton="False" ShowPreviousPageButton="False"  />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText=" >> "
                            ShowNextPageButton="False" ShowPreviousPageButton="False"  />
                    </Fields>
                </asp:DataPager>

                </table>
            </LayoutTemplate>

            
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="FnameLabel" runat="server" Text="<%#: Item.FirstName %>">
                            <asp:ImageMap ID="ImageMap1" runat="server"></asp:ImageMap></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="LnameLabel" runat="server" Text="<%#: Item.LastName %>"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="EmailLabel" runat="server" Text="<%#: Item.EmailAddress %>"></asp:Label>
                    </td>

                    <td>                                                                                                                                         
                        <asp:LinkButton runat="server" CommandName="Delete" Text="Ta Bort" CausesValidation="false" OnClientClick='<%# String.Format("return confirm(\"Ta bort {0} {1}?\")", Item.FirstName, Item.LastName)%>'/>
                        <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false"/>
                    </td>
                </tr>
                

            </ItemTemplate>
            <InsertItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox ID="FirstName" runat="server" Text='<%#: BindItem.FirstName %>' MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="Firstname"
                            runat="server" Text="*" ErrorMessage="Förnamn måste anges" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server" Text='<%#: BindItem.LastName %>' MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="Lastname"
                            runat="server" Text="*" ErrorMessage="Efternamn måste anges" ValidationGroup="Insert"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddress" runat="server" Text='<%#: BindItem.EmailAddress %>' MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="EmailAddress"
                            runat="server" Text="*" ErrorMessage="Emailadress måste anges" ValidationGroup="Insert"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="EmailAddress" Text="*"
                            runat="server" ErrorMessage="Fel format för emailadress"
                            ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$"
                            ValidationGroup="Insert"></asp:RegularExpressionValidator>
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
                        <asp:TextBox ID="FirstNameEdit" runat="server" Text='<%#: BindItem.FirstName %>' MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FirstNameEdit"
                            runat="server" Text="*" ErrorMessage="Förnamn måste anges" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                        
                    </td>
                    <td>
                        <asp:TextBox ID="LastNameEdit" runat="server" Text='<%#: BindItem.LastName %>' MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="LastNameEdit"
                            runat="server" Text="*" ErrorMessage="Efternamn måste anges" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddressEdit" runat="server" Text='<%#: BindItem.EmailAddress %>' MaxLength="50"></asp:TextBox>

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="EmailAddressEdit" runat="server"
                            Text="*" ErrorMessage="Emailadress måste anges" ValidationGroup="Edit"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="EmailAddressEdit" Text="*"
                            runat="server" ErrorMessage="Fel format för emailadress"  
                            ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$"
                            ValidationGroup="Edit">
                            
                        </asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" Text="Spara" />
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
