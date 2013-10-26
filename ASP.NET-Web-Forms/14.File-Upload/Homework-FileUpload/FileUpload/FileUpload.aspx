<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="FileUpload.FileUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/kendo/2013.2.716/kendo.common.min.css" rel="stylesheet" />
    <link href="Content/kendo/2013.2.716/kendo.default.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js"></script>
    <script src="Scripts/kendo/2013.2.716/kendo.web.min.js"></script>
</head>
<body>
    <input name="uploaded" id="uploaded" type="file" runat="server" />

    <div runat="server" id="uploadedStuff">
        <%= FileOutput %>
    </div>

    <script>
        function onUpload(e) {
            var files = e.files;
            $.each(files, function () {
                if (this.extension.toLowerCase() != ".zip") {
                    alert("Only .zip files can be uploaded");
                    e.preventDefault();
                }
            });
        }

        $(document).ready(function () {
            $("#uploaded").kendoUpload({
                async: {
                    saveUrl: "Upload.aspx",
                    autoUpload: true,
                },
                upload: onUpload
            });
        });
    </script>
</body>
</html>
