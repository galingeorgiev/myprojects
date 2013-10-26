<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ChatApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <asp:ListView ID="ListViewMessages"
                ItemType="ChatApplication.Message"
                runat="server">

                <LayoutTemplate>
                    <h3>Messages</h3>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                </LayoutTemplate>

                <ItemSeparatorTemplate>
                    <hr />
                </ItemSeparatorTemplate>

                <ItemTemplate>
                    <div>
                        Message: <%#: Item.MessageText %>
                    </div>
                </ItemTemplate>

            </asp:ListView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="500" />
    <hr />
    <asp:TextBox runat="server" ID="TextBoxMessage" />
    <asp:Button Text="Add Message" runat="server" ID="ButtonAddMessage" OnClick="ButtonAddMessage_Click" />

</asp:Content>
