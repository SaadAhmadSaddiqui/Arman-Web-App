<%@ Page Title="" Language="C#" MasterPageFile="~/Arman.Master" AutoEventWireup="true" CodeBehind="UglyBird.aspx.cs" Inherits="Arman_Web_App.UglyBird" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="container">
        <div class="card bg-dark text-center">
            <div class="card-header">
                Featured
            </div>
            <div class="card-body">
                <h5 class="card-title">Ugly Bird</h5>
                <p class="card-text">By Saad Ahmad Saddiqui.</p>
                <div class="resp-container">
                    <center><iframe class="resp-iframe" src="https://i.simmer.io/@SaadTruth/uglybird"></iframe></center>
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
