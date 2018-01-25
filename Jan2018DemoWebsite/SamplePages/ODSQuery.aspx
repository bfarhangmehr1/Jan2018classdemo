<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ODSQuery.aspx.cs" Inherits="Jan2018DemoWebsite.SamplePages.ODSQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>ODS Query</h3>
    <div class="row">
        <asp:GridView ID="AlbumList" runat="server"
             AutoGenerateColumns="False"
             DataSourceID="AlbumListODS"
             AllowPaging="True"  PageSize="15"
             BorderStyle="None" 
            GridLines="Horizontal"
            CellPadding ="5" CellSpacing="0" OnSelectedIndexChanged="AlbumList_SelectedIndexChanged" CssClass="table tabel-hover tabel stripped">
            <Columns>
                <asp:TemplateField HeaderText="Id" SortExpression="AlbumId">
                    
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("AlbumId") %>' ID="AlbumId"></asp:Label>&nbsp;&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                   
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Title") %>' ID="Label2"></asp:Label>&nbsp;&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Artist" SortExpression="ArtistId">
                   
                    <ItemTemplate>
                        <asp:DropDownList ID="ArtistList" runat="server"
                             DataSourceID="ArtistListODS"
                             DataTextField="Name" 
                            DataValueField="ArtistId" 
                            selectedvalue='<%# Eval("ArtistId") %>' 
                            Width="300px"></asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Year" SortExpression="ReleaseYear">
                  
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("ReleaseYear") %>' ID="Label4"></asp:Label>&nbsp;&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Label" SortExpression="ReleaseLabel">
                  
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("ReleaseLabel") %>' ID="Label5"></asp:Label>&nbsp;&nbsp;
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:CommandField SelectText="View" ShowSelectButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="AlbumListODS" runat="server"
            OldValuesParameterFormatString="original_{0}" 
           SelectMethod="Albums_List"
          TypeName="ChinookSystem.BLL.AlbumController"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ArtistListODS" runat="server" 
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="Artists_List" 
           TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
    </div>
</asp:Content>
