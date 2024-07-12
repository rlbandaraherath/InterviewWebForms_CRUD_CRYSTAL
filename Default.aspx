<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Interview01._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center;">
        <h1>Submit Your Personal Data </h1>
    </div>
    <br/>
    <hr/>

    <!--Data input form start   -->


    <!--name  -->
    <div class="row">

        <div class="col-lg-3"></div>

        <div class="col-lg-2">Name With Initials</div>

        <div class="col-lg-4">
            <asp:TextBox ID="txtname" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvname" runat="server" ControlToValidate="txtname"
                Display="Dynamic" ErrorMessage="Please enter a name" CssClass="text-danger"  ValidationGroup="Group1"/>
        </div>

    </div>


    <!--address -->
    <div class="row">

        <div class="col-lg-3"></div>

        <div style="margin-top: 5px;" class="col-lg-2">Address</div>

        <div style="margin-top: 5px;" class="col-lg-4">
            <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvaddress" runat="server" ControlToValidate="txtaddress"
                Display="Dynamic" ErrorMessage="Please enter an address" CssClass="text-danger" ValidationGroup="Group1" />
        </div>

    </div>

    <!--age -->
    <div class="row">

        <div class="col-lg-3"></div>

        <div style="margin-top: 5px;" class="col-lg-2">Age</div>

        <div style="margin-top: 5px;" class="col-lg-4">
            <asp:TextBox ID="txtage" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvAgeRequired" runat="server" ControlToValidate="txtage"
                Display="Dynamic" ErrorMessage="Please enter an age" CssClass="text-danger" ValidationGroup="Group1" />
            <asp:RegularExpressionValidator ID="revAge" runat="server" ControlToValidate="txtage"
                Display="Dynamic" ErrorMessage="Please enter a valid age "
                ValidationExpression="^(?:[0-9]|[1-9][0-9]|100)$" CssClass="text-danger" ValidationGroup="Group1" />

        </div>

    </div>




    <!--nic with search-->
    <div class="row">

        <div class="col-lg-3"></div>

        <div style="margin-top: 5px;" class="col-lg-2">NIC</div>

        <div style="margin-top: 5px;" class="col-lg-4">
            <asp:TextBox ID="txtnic" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvnic" runat="server" ControlToValidate="txtnic"
                Display="Dynamic" ErrorMessage="Please enter a nic number" CssClass="text-danger"  ValidationGroup="Group1"/>
            <asp:RequiredFieldValidator ID="rfvnic2" runat="server" ControlToValidate="txtnic"
                Display="Dynamic" ErrorMessage="Please enter a nic number" CssClass="text-danger"  ValidationGroup="Group2"/>
        </div>
        <div class="col-lg-2">
            <asp:Button ID="btnnicsearch" runat="server" Text="Search by NIC" CssClass="btn btn-primary" OnClick="btnnicsearch_Click" CausesValidation="true" ValidationGroup="Group2"/>

        </div>


    </div>




    <!--gender-->
    <div class="row">

        <div class="col-lg-3"></div>

        <div style="margin-top: 5px;" class="col-lg-2">Gender</div>

        <div style="margin-top: 5px;" class="col-lg-2">

            <asp:DropDownList ID="ddlgender" runat="server">
              
                <asp:ListItem Text="Male" Value="Male" />
                <asp:ListItem Text="Female" Value="Female" />
            </asp:DropDownList>
        </div>


    </div>


    <!--buttons -->
    <div class="row">

        <div class="col-lg-5"></div>

        <div class="col-lg-5">
            <div class="row" style="margin-top: 10px;">
                <div class="col-lg-2">
                    <asp:Button ID="btninsert" runat="server" Text="Insert" CssClass="btn btn-primary" OnClick="btninsert_Click" CausesValidation="true" ValidationGroup="Group1"/>
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btnupdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnupdate_Click" CausesValidation="true"  ValidationGroup="Group1"/>
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="btndelete_Click" CausesValidation="true" ValidationGroup="Group2"/>
                </div>
                <div class="col-lg-2">
                    <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnreset_Click" />
                </div>


               
               
            </div>


        </div>



    </div>
    <!--Data input form Ends   -->


    <hr />



    <!--Data Grid view starts   -->
    <div style="display: flex; align-items: center; justify-content: center; height: 30vh; text-align: center;">

        <div style="text-align: left; display: inline-block;">

            <asp:GridView ID="GridView1" runat="server" PageSize="10" Width="800px" AutoGenerateColumns="True">
            </asp:GridView>

        </div>
    </div>
    <!--Data Grid view ends  -->






   

</asp:Content>