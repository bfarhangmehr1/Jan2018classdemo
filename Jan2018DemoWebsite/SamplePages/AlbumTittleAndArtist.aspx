<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumTittleAndArtist.aspx.cs" Inherits="Jan2018DemoWebsite.SamplePages.AlbumTittleAndArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Enter  track lower limit"></asp:Label>&nbsp;
    <asp:TextBox ID="TrackCountlimit" runat="server" TextMode="Number"></asp:TextBox>&nbsp;
    <asp:Button ID="DisplayAlbumTitleID" runat="server" Text="Display Album Title and Artist" Class="btn btn-primary" />
    <br />



<h1> Repeater for Albums showing title and artist</h1>
    <asp:Repeater ID="AlbumTitleList" runat="server"
        ItemType="Chinook.Data.DTOs.ArtistTitle" 
        DataSourceID="AlbumTitleListODS">
        <HeaderTemplate>
            <h3>Album showing Tracks</h3>
        </HeaderTemplate>
        <ItemTemplate>
      <div class="row">
          <div class="col-md-5">
              <%# Item.title %> ( <%# Item.artist %>)
              <asp:GridView ID="AlbumTitleListGV" runat="server"
                   DataSource="<%# Item.songsTrack %>">
              </asp:GridView>
          </div>
          <div class="col-md-5">
           <asp:ListView ID="ListView1" runat="server"
                DataSource="<%# Item.songsTrack %>">   
                <ItemTemplate>
                             <tr style="background-color: #DCDCDC; color: #000000;">
                    <td>
                        <asp:Label Text='<%# Eval("Songtitle") %>' runat="server" ID="SongtitleLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("length") %>' runat="server" ID="lengthLabel" /></td>    

                </tr>
                        </ItemTemplate>
                <LayoutTemplate>
                             <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                                    <th runat="server">Songtitle</th>
                                    <th runat="server">length</th>                                

                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                            <asp:DataPager runat="server" ID="DataPager1">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True"></asp:NextPreviousPagerField>
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
                        </LayoutTemplate>
               
                   
           </asp:ListView>

          </div>
          
      </div>
            </ItemTemplate>
    </asp:Repeater>
    <asp:ObjectDataSource ID="AlbumTitleListODS" runat="server"
         OldValuesParameterFormatString="original_{0}" 
        SelectMethod="Album_GetTitleAndArtist" 
        TypeName="ChinookSystem.BLL.AlbumTracksCoutroller">
        <SelectParameters>
            <asp:ControlParameter 
                ControlID="TrackCountlimit" 
                PropertyName="Text"
                 Name="TrackCountlimit" 
                Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
