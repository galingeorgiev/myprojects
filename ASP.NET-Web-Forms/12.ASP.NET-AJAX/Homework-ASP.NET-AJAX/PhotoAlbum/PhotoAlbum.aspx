<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoAlbum.aspx.cs" Inherits="PhotoAlbum.PhotoAlbum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Photo Album</title>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="server"></ajaxToolkit:ToolkitScriptManager>

        <div id="Content-Container">
            <asp:Label runat="Server" ID="ImageTitle" CssClass="Image-Info" />
            <asp:Image ImageUrl="~/Images/Albania.jpg" runat="server" ID="ImageContainer" Width="500" Height="300" CssClass="Image-Galery" />
            <asp:Label runat="server" ID="ImageDescription" CssClass="Image-Info"></asp:Label>
            <div id="Buttons-Container">
                <asp:Button Text="Prev" ID="ButtonPrev" runat="server" />
                <asp:Button Text="Play" ID="ButtonPlay" runat="server" />
                <asp:Button Text="Next" ID="ButtonNext" runat="server" />
            </div>
        </div>

        <ajaxToolkit:SlideShowExtender
            ID="SlideShowExtenderPhotoGalery"
            TargetControlID="ImageContainer"
            runat="server"
            SlideShowServiceMethod="GetSlides"
            AutoPlay="false"
            ImageDescriptionLabelID="ImageDescription"
            ImageTitleLabelID="ImageTitle"
            NextButtonID="ButtonNext"
            PreviousButtonID="ButtonPrev"
            PlayButtonID="ButtonPlay"
            PlayButtonText="Play"
            StopButtonText="Stop"
            Loop="true">
        </ajaxToolkit:SlideShowExtender>

    </form>
</body>
</html>
