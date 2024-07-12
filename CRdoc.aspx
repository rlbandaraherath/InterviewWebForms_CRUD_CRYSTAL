<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRdoc.aspx.cs" Inherits="Interview01.About" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <br />
    <div>
        <h2><%: Title %>.
      <hr/>
            <br />
            <asp:Button ID="btncr" runat="server" Text="Crystal Report" CssClass="btn btn-primary" OnClick="btncr_Click" />
        </h2>
    </div>
    <hr />
    <br />


    <div>

     <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" DisplayToolbar="true" Height="300px" ReportSourceID="CrystalReportSource2" ToolPanelWidth="200px" Width="1104px" />
<CR:CrystalReportSource ID="CrystalReportSource2" runat="server">
    <Report FileName="CrystalReport5.rpt">
    </Report>
</CR:CrystalReportSource>

        <br>
    </div>
</asp:Content>
