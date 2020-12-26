<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopulationStatistics.aspx.cs" Inherits="WebApplication.Views.PopulationStatistics" MasterPageFile="~/Views/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Chart ID="Chart1" runat="server" CssClass="chart_scroll" Width="500px">
            <Titles>
                <asp:Title Text="Country Population" />
            </Titles>
            <Series>
                <asp:Series ChartType="Spline" Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX Title="Year" />
                    <AxisY Title="Population" />
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <br />
    <div style="padding-left: 5%">
        <asp:DropDownList ID="DropDownListCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListCountry_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    <br />
    <br />
    <div>
        <asp:Chart ID="Chart2" runat="server" CssClass="chart_scroll" Width="500px">
            <Titles>
                <asp:Title Text="Compare Countries Population" />
            </Titles>
            <Series>
                <asp:Series ChartType="Pie" Name="Series1">
                </asp:Series>
            </Series>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Legend" LegendStyle="Row" />
            </Legends>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX Title="Country" />
                    <AxisY Title="Population" />
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    <br />
    <div style="padding-left: 5%">
        <asp:DropDownList ID="DropDownListYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPieChart_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:DropDownList ID="DropDownList0" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPieChart_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPieChart_SelectedIndexChanged">
        </asp:DropDownList>
        <br/>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPieChart_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPieChart_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
</asp:Content>
