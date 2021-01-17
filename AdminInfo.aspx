<%@ Page Title="" Language="C#" MasterPageFile="~/Arman.Master" AutoEventWireup="true" CodeBehind="AdminInfo.aspx.cs" Inherits="Arman_Web_App.AdminInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $('.table').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({/* "scrollX": true, */"scrollY": 300 });
        });
        if (window.history.replaceState) {
            window.history.replaceState(null, null, window.location.href);
        }
        $("#Content2").submit(function (e) {
            e.preventDefault();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-fluid">
        <div class="row">
            <%-- Left Card (Admin Details) --%>
            <div class="col-lg-5">
                <div class="card bg-dark">
                    <div class="card-body">

                        <%-- Title Admin Details --%>
                        <div class="row">
                            <div class="col text-center">
                                <h4>Admin Details</h4>
                            </div>
                        </div>
                        <%-- Admins Icon --%>
                        <div class="row">
                            <div class="col text-center">
                                <i class="fas fa-users-cog fa-6x"></i>
                            </div>
                        </div>
                        <%-- Horizontal Rule --%>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <%-- Admin ID and Name Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="txtAdminID" placeholder="Admin ID" runat="server"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:Button ID="btnPGo" CssClass="btn btn-secondary" runat="server" Text="Go" OnClick="btnPGo_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAdminName" placeholder="Admin Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- Login Credentials Pill --%>
                        <div class="row">
                            <div class="col text-center">
                                <span class="badge badge-pill badge-primary">Login credentials</span>
                            </div>
                        </div>
                        <%-- Break --%>
                        <div class="row">
                            <div class="col">
                                <br />
                            </div>
                        </div>
                        <%-- Admin Email Row --%>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAdminEmail" placeholder="Admin Email" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- Admin Username And Password Row --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAdminUsername" placeholder="Username" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAdminPassword" placeholder="Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- Buttons Row --%>
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Button ID="btnAdd" CssClass="btn btn-success btn-block" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnUpdate" CssClass="btn btn-warning btn-block" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnDelete" CssClass="btn btn-danger btn-block" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <%-- All the alerts --%>
                <div>
                    <%-- Added Alert --%>
                    <div class="alert alert-success alert-dismissible fade show" role="alert" id="alertSuccess" runat="server">
                        <strong>Admin Added! </strong>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <%-- Updated Alert --%>
                    <div class="alert alert-warning alert-dismissible fade show" role="alert" id="alertUpdate" runat="server">
                        <strong>Admin Updated! </strong>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <%-- Deleted Alert --%>
                    <div class="alert alert-danger alert-dismissible fade show" role="alert" id="alertDeleted" runat="server">
                        <strong>Admin Deleted! </strong>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <%-- Fill in Alert --%>
                    <div class="alert alert-info alert-dismissible fade show" role="alert" id="alertInfo" runat="server">
                        <p id="alertInfoText" runat="server"></p>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                </div>
                <%--<a href="HomePage.aspx">Back to Home Page</a>--%>
            </div>
            <%-- Right Card (Admins List) --%>
            <div class="col-lg-7">
                <div class="card">
                    <div class="card-body">
                        <%-- Title Admins List --%>
                        <div class="row">
                            <div class="col text-center">
                                <h4 style="color:black">Admins List</h4>
                            </div>
                        </div>
                        <%-- Horizontal Rule --%>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <%-- Admin List GridView --%>
                        <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="gvAdmins" runat="server" AutoGenerateColumns="False" DataKeyNames="AdminID" DataSourceID="AdminGV">
                                    <Columns>
                                        <asp:BoundField DataField="AdminID" HeaderText="Admin ID" ReadOnly="True" SortExpression="AdminID" />
                                        <asp:BoundField DataField="AdminName" HeaderText="Admin Name" SortExpression="AdminName" />
                                        <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                                        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                                        <asp:BoundField DataField="AdminEmail" HeaderText="Admin Email" SortExpression="AdminEmail" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="AdminGV" runat="server" ConnectionString="<%$ ConnectionStrings:ArmanCon %>" SelectCommand="SELECT * FROM [Admins]"></asp:SqlDataSource>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
