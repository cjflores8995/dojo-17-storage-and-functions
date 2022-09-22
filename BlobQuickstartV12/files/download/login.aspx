<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">    
    <script src="Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.8.21.custom.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="resources_archivos/theme.css.css">    

        <script type="text/javascript">
            var initcounter = 0;
            var errmessage = null;

            function pageLoad(sender, args) {
                $(function () {
                    initializedialog();
                    if (initcounter > 0) {
                        $("#error-messages").remove();
                        $("#error-messages").append(errmessage);
                        $("#error-messages").dialog('open');
                        initcounter = 0;
                        errmessage = null;
                    }
                });
            }
            function initializedialog() {
                $("#error-messages").dialog({
                    autoOpen: false,
                    hide: 'blind',
                    minHeight: 125,
                    maxWidth: 300,
                    show: 'blind',
                    title: 'Alerta(s)!'
                });
            }
            //This function is called from the script injected from code-behind.
            function showDialog(message) {
                initcounter++;
                errmessage = message;
            }
    </script>

    <title>Derechos</title>
    <style type="text/css">
        .auto-style1 {
            width: 800px;
            height: 590px;
        }

        .alinear {
            vertical-align : middle;
            text-align :center;
        }

        .auto-style2 {
            width: 60%;
        }

    </style>
</head>

<body style="background-color: #F8F8F8">
    
    <form id="form1" runat="server">
       
        <asp:scriptmanager id="scriptmanager" runat="server"></asp:scriptmanager>
        
        <div class="alinear">
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            
        <ContentTemplate>

            <table align="center" class="auto-style1" style="background-image: url('resources/images/fondo_login.png'); background-repeat: no-repeat; background-size: 800px 600px">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td valign="bottom">
                        <asp:Panel ID="Panel1" runat="server">
                            <table class="auto-style2" border="0">
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label1" runat="server" Font-Names="Verdana" Style="color: #FFFFFF; font-weight: 700; font-size: small" Text="Usuario :"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtUser" runat="server" Width="160px" CssClass="txt" MaxLength="50">
                                        </asp:TextBox>
                                    </td>
                                    <td style="text-align: left">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label4" runat="server" Font-Names="Verdana" Style="color: #FFFFFF; font-weight: 700; font-size: small" Text="Password :"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:TextBox ID="txtPwd" runat="server" Width="160px" TextMode="Password" CssClass="txt" MaxLength="50">
                                        </asp:TextBox>
                                    </td>
                                    <td style="text-align: left">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <asp:Label ID="Label5" runat="server" Font-Names="Verdana" Style="color: #FFFFFF; font-weight: 700; font-size: small" Text="Empresa :"></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:DropDownList ID="ddlCompany" runat="server" Width="160px" CssClass="dropdown">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="text-align:left">
                                        <asp:Label runat="server" ID="lblmensaje" ForeColor="Red" Font-Names="Verdana" Font-Bold="True"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        
            <div id="error-messages">
            </div>

        </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    </form>
</body>

</html>
