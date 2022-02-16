<%@ Control Language="C#" AutoEventWireup="true" CodeFile="memberRightBar.ascx.cs" Inherits="memberRightBar" %>

	  <div id="sidebar" class="sidebar col-sm-3 col-md-3">
		<aside class="widget menu">
		  <header>
			<h3 class="title"><asp:Literal ID="litHesabimTitle" runat="server" Text="<%$Resources:strings, memberHesabimTitle %>"></asp:Literal></h3>
		  </header>
		  <nav>
			<ul>
                
			  <li id="uyesayfam" runat="server">
				<a href="/uye-sayfam" id="memberPage" runat="server"><i class="fa fa-gears item-icon"></i><asp:Literal ID="lblUyeSayfam" runat="server" Text="<%$Resources:strings, memberUyeSayfam %>"></asp:Literal> </a>
			  </li>

<%--                <li id="smsSayfa" runat="server">
                    <a href="/uye-sayfam/SMS-Sistem-Bilgilerim" id="A1" runat="server"><i class="fa fa-envelope item-icon"></i><asp:Literal ID="litSMSPage" runat="server" Text="<%$Resources:strings, memberSMSLink %>"></asp:Literal> </a>
                </li>--%>
              
<%--              <li id="siparisler1" runat="server">
				<a href="/uye-sayfam/siparis"><i class="fa fa-shopping-cart item-icon"></i><asp:Literal ID="litSiparisGonder" runat="server" Text="<%$Resources:strings, siparisGonder %>"></asp:Literal></a>
			  </li>
                
			    <li id="siparisler2" runat="server">
			        <a href="/uye-sayfam/siparis-gonder"><i class="fa fa-shopping-cart item-icon"></i><asp:Literal ID="Literal2" runat="server" Text="<%$Resources:strings, siparisGonder2 %>"></asp:Literal></a>
			    </li>

              <li id="vitrinlikGonder" runat="server">
				<a href="https://eski.mertalbum.com/mer.asp"><i class="fa fa-share item-icon"></i><asp:Literal ID="Literal1" runat="server" Text="<%$Resources:strings, memberRightBarVitrinlik %>"></asp:Literal></a>
			  </li>
                
			    <li id="vitrinlikSiparisi" runat="server">
			        <a href="/uye-sayfam/vitrinlik-siparisi"><i class="fa fa-shopping-cart item-icon"></i><asp:Literal ID="Literal3" runat="server" Text="<%$Resources:strings, memberRightBarVitrinlikSip %>"></asp:Literal></a>
			    </li>
                
                


			   <li id="memberBilgiler" runat="server">
				<a href="/uye-sayfam/bilgilerimi-guncelle" id="memberBilgiDuz" runat="server"><i class="fa fa-user item-icon"></i><asp:Literal ID="lblBilgileriDuzenle" runat="server" Text="<%$Resources:strings, memberBilgileriDuzenle %>"></asp:Literal></a>
			  </li>
                
              <li id="memberSifre" runat="server">
				<a href="/uye-sayfam/sifremi-guncelle" id="memberSifreDuz" runat="server"><i class="fa fa-lock item-icon"></i><asp:Literal ID="litSifreDuzenle" runat="server" Text="<%$Resources:strings, memberSifreDuzenle %>"></asp:Literal></a>
			  </li>

                                			  <li id="memberMail" runat="server">
				<a href="/uye-sayfam/eposta-guncelle" id="memberMailDuz" runat="server"><i class="fa fa-envelope item-icon"></i><asp:Literal ID="litMailDuzenle" runat="server" Text="<%$Resources:strings, memberMailDuzenle %>"></asp:Literal></a>
			  </li>--%>


<%--			  <li>
				<a href="/" id="memberAdresDefter" runat="server"><i class="fa fa-pencil-square-o item-icon"></i><asp:Literal ID="litAdresDefteri" runat="server" Text="<%$Resources:strings, memberAdresDefteri %>"></asp:Literal></a>
			  </li>
			  <li>
				<a href="shop-account-orders.html"><i class="fa fa-shopping-cart item-icon"></i>My Orders</a>
			  </li>--%>
			</ul>
		  </nav>
		</aside><!-- .menu-->
	  </div>
