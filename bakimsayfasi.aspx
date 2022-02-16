<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bakimsayfasi.aspx.cs" Inherits="bakimsayfasi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bakımda</title>

    <style>
        body, html {
	font-family: Arial, sans-serif;
	font-size: 16px;
	color: #666666;

	height: 100%;
	background-color: #fff;
    background-image:url("/images/bg-bakimda.jpg");
    background-size: cover;
	-webkit-box-sizing: border-box;
	-moz-box-sizing: border-box;
	box-sizing: border-box;
    }

        .yazi {
    width: 98%;
    position: relative;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
}

    .div {
        height: 99%;
        width: 99%;
        position: absolute;

    }
    </style>

</head>
<body>
    <form id="form1" runat="server">


         <div class="div">
            <div class="yazi">
                <img src="/images/logo.png" />
                <div><h1>Sitemizde şu an bakım çalışması yapılmaktadır!</h1></div>                
            </div>
        </div>


    </form>
</body>
</html>
