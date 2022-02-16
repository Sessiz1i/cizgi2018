<%@ Control Language="C#" AutoEventWireup="true" CodeFile="topLoginPanel.ascx.cs" Inherits="topLoginPanel" %>

    <nav class="collapse collapsing navbar-collapse">
        <asp:Panel ID="pnlNotLogin" runat="server">
			  <ul class="nav navbar-nav navbar-right">
				<%--<li><a href="shop-account.html"><asp:Label ID="lblUyeSayfam" runat="server" Text="<%$ Resources:strings, headeruyesayfam%>"></asp:Label></a></li>--%>
<%--				<li><a href="#"><i class="fa fa-heart"></i> My Wishlist</a></li>
				<li><a href="#">My Cart <span class="count">2</span></a></li>
				<li><a href="#">Checkout</a></li>--%>
                <li><asp:HyperLink ID="hyperKayit" runat="server"><asp:Label ID="lblKayitOl" runat="server" Text="<%$ Resources:strings, headerkayitol%>"></asp:Label><i class="fa fa-user after"></i></asp:HyperLink></li>
				<li><asp:HyperLink ID="hyperLogin" runat="server"><asp:Label ID="lblGirisYap" runat="server" Text="<%$ Resources:strings, headergirisyap%>"></asp:Label><i class="fa fa-lock after"></i></asp:HyperLink></li>
			  </ul>
        </asp:Panel>

        <asp:Panel ID="pnlLoggedIn" runat="server" Visible="false">
            <ul class="nav navbar-nav navbar-right">
              <li><asp:HyperLink ID="hyperUyeSayfam" runat="server"><asp:Label ID="lblUyeSayfam" runat="server" Text="<%$ Resources:strings, headeruyesayfam%>"></asp:Label><i class="fa fa-user after"></i></asp:HyperLink></li>
              <li><asp:HyperLink ID="hyperLogout" runat="server"><asp:Label ID="lblLogout" runat="server" Text="<%$ Resources:strings, headerLogout%>"></asp:Label><i class="fa fa-ban after"></i></asp:HyperLink></li>
            </ul>
        </asp:Panel>


    </nav>