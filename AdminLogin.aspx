<%@ Page Title="" Language="C#" MasterPageFile="~/Arman.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Arman_Web_App.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card bg-dark text-light">
                    <div class="card-body">
                        <div class="row">
                            <div class="col text-center">
                                <img width="150" src="All necessary Images/imgs/adminuser.png" alt="General User" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <h3>Admin Login</h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtUsername" placeholder="Username or Email" runat="server" required></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPassword" placeholder="Password" runat="server" TextMode="Password" required></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="btnLogin" CssClass="btn btn-success btn-block" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                </div>
                                <div class="form-group text-center">
                                    <asp:Label ID="lblMessage" CssClass="alert-danger" runat="server" Text="Message will display here."></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <a class="text-light" href="HomePage.aspx">Back to Home Page</a>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
