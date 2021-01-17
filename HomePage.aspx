<%@ Page Title="" Language="C#" MasterPageFile="~/Arman.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Arman_Web_App.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />

    <section>
        <div class="container">
            <div class="row">
                <div class="col-md-12 text-center">
                    <h2>Augmented Reality Mapping and Navigation</h2>
                    <p><b>Features of this website</b></p>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 text-center">
                    <h1 id="iconRooms" ><i class="fas fa-door-open"></i></h1>
                    <h4>Managing Rooms</h4>
                    <p class="text-justify">The admin of the application can add, update, or delete a room from the application. The changes are then reflected on the Android application and affects how and where the users can navigate to.</p>
                </div> 
                <div class="col-lg-6 text-center">
                    <h1 id="iconAdmins" ><i class="fas fa-users-cog"></i></h1>
                    <h4>Managing Admins</h4>
                    <p class="text-justify">This panel allows you to add, update, or remove an admin's details. This affects the access to the website of the users.</p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
