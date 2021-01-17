<%@ Page Title="" Language="C#" MasterPageFile="~/Arman.Master" AutoEventWireup="true" CodeBehind="RoomInfo.aspx.cs" Inherits="Arman_Web_App.RoomInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
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
            <%-- Left Card (Room Details) --%>
            <div class="col-lg-5">
                <div class="card bg-dark">
                    <div class="card-body">
                        <%-- Room Details --%>
                        <div class="row">
                            <div class="col text-center">
                                <h4>Room Details</h4>
                            </div>
                        </div>
                        <%-- Room Icon --%>
                        <div class="row">
                            <div class="col text-center">
                                <i class="fas fa-door-open fa-6x"></i>
                            </div>
                        </div>
                        <%-- Horizontal Line --%>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <%-- Room ID, Name --%>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtRoomID" placeholder="Room ID" CssClass="form-control" runat="server"></asp:TextBox>
                                        <div class="input-group-append">
                                            <asp:Button ID="btnGo" CssClass="btn btn-secondary" runat="server" Text="Go" OnClick="btnGo_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtRoomName" placeholder="Room Name" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- The Positions Row --%>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtRoomX" placeholder="X Position" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtRoomY" placeholder="Y Position" CssClass="form-control" runat="server" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtRoomZ" placeholder="Z Position" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
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
                        <strong>Room Added! </strong>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <%-- Updated Alert --%>
                    <div class="alert alert-warning alert-dismissible fade show" role="alert" id="alertUpdate" runat="server">
                        <strong>Room Updated! </strong>
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <%-- Deleted Alert --%>
                    <div class="alert alert-danger alert-dismissible fade show" role="alert" id="alertDeleted" runat="server">
                        <strong>Room Deleted! </strong>
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
            </div>
            <%-- Right Card --%>
            <div class="col-lg-7">
                <div class="card">
                    <div class="card-body">
                        
                         <%-- Title Rooms List --%>
                        <div class="row">
                            <div class="col text-center">
                                <h4 style="color:black">Rooms List</h4>
                            </div>
                        </div>
                        <%-- Horizontal Rule --%>
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                            <asp:GridView CssClass="table table-striped table-bordered" ID="gvRooms" runat="server">
                            </asp:GridView>          
                    </div>
                </div>
            </div>
        </div>
    </div>
     <br />
    <div class="container">
        <div class="card bg-dark text-center">
            <div class="card-header">
                <h5 class="card-title">Location Selector</h5>
            </div>
            <div class="card-body">
                <div class="resp-container">
                    <center><iframe class="resp-iframe" src="https://i.simmer.io/@SaadTruth/~6bbd0434-ec8e-fcbe-16c0-0ce060b47da1"></iframe></center>
                </div>
            </div>
            <div class="card-footer text-light">
                Created with Unity <i class="fab fa-unity fa-2x"></i>
            </div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>