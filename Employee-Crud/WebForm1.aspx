<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Employee_Crud.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel ="stylesheet" href ="style.css" />
    <link href="https://fonts.googleapis.com/css?family=Josefin+Sans&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    </head>
<body>
   <form id="form1" runat="server">
       <header>
           <div class ="logo">
               <h2 class ="text-center">Employee Crud Application</h2>
           </div>
       </header>
        <div class ="container">
            <table>
                <tr>
                    <td>
                        <asp:HiddenField ID="HFEmployeeID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
                    </td>
                    <td> <asp:TextBox ID="fnameTxt" runat="server"></asp:TextBox>
                        
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Last Name"></asp:Label>
                    </td>
                    <td> <asp:TextBox ID="lnameTxt" runat="server"></asp:TextBox>
                           
                    </td>
                </tr>
                 <tr>
                    <td>
                       <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td> <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
                      
                    </td>
                </tr>
                 <tr>
                    <td></td>
                    <td><asp:Button ID="Savebnt" runat="server" Text="Save" OnClick="Savebnt_Click" />
                        <asp:Button ID="Deletebnt" runat="server" Text="Delete" OnClick="Deletebnt_Click"/>
                        <asp:Button ID="Resetbnt" runat="server" Text="Reset" OnClick="Resetbnt_Click" />
                    </td>
                </tr>
                <tr>
                <td></td>
                <td><asp:Label ID="SucessMessage" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                <td></td>
                <td>  <asp:RegularExpressionValidator ID="EmailValidator" runat="server" ErrorMessage="Enter a Valid Email Address"
                    ControlToValidate="emailTxt" ValidationExpression ="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"></asp:RegularExpressionValidator></td>
                </tr>
            </table>
            
             <asp:GridView ID="PersonView" runat="server" AutoGenerateColumns ="false">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="last Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="ViewBnt" runat="server" CommandArgument='<%# Eval("EmployeeID")%>' OnClick="ViewBnt_Click">View</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
