<%@ Control Language="C#" AutoEventWireup="true" CodeFile="banner-ana-sayfa.ascx.cs" Inherits="banner_ana_sayfa" %>
<div class="banner-set load" data-carousel-autoplay="true">
  <div class="container">
	<div class="banners">
        
        
        
        
        
        
        
        
        
        
        
        

	  <a href="/Urunler/Master-Album/1" class="banner">                 
		<img class="replace-2x" src="/images/banner-ana-sayfa/master-seri-ana-sayfa-<%=randomSayi() %>.jpg" width="253" height="158" alt="">
		<h2 class="title"><asp:Literal ID="banneranasayfamaster3" runat="server" Text="<%$Resources:strings, banneranasayfamaster3 %>"/> </h2>
		<div class="description"><asp:Literal ID="banneranasayfamaster4" runat="server" Text="<%$Resources:strings, banneranasayfamaster4 %>"/> </div>
	  </a>

<%--                	  <a href="/Urunler/Premium-Plus-Album/2" class="banner">                 
		<img class="replace-2x" src="/images/banner-ana-sayfa/premium-plus-seri-ana-sayfa-<%=randomSayi() %>.jpg" width="253" height="158" alt="">
		<h2 class="title"><asp:Literal ID="banneranasayfaluna3" runat="server" Text="<%$Resources:strings, banneranasayfaPPTitle %>"/></h2>
		<div class="description"><asp:Literal ID="banneranasayfaluna4" runat="server" Text="<%$Resources:strings, banneranasayfaPPAciklama %>"/></div>
	  </a>--%>

        	  <a href="/Urunler/Premium-Album/3" class="banner">                 
		<img class="replace-2x" src="/images/banner-ana-sayfa/premium-seri-ana-sayfa-<%=randomSayi() %>.jpg" width="253" height="158" alt="">
		<h2 class="title"><asp:Literal ID="banneranasayfapre3" runat="server" Text="<%$Resources:strings, banneranasayfapre3 %>"/></h2>
		<div class="description"><asp:Literal ID="banneranasayfapre4" runat="server" Text="<%$Resources:strings, banneranasayfapre4 %>"/></div>
	  </a>

<%--                	  <a href="/Urunler/Kristal-Plus-Album/7" class="banner">                 
		<img class="replace-2x" src="/images/banner-ana-sayfa/kristal-plus-seri-ana-sayfa-<%=randomSayi() %>.jpg" width="253" height="158" alt="">
		<h2 class="title"><asp:Literal ID="banneranasayfanova3" runat="server" Text="<%$Resources:strings, banneranasayfaKPTitle %>"/></h2>
		<div class="description"><asp:Literal ID="banneranasayfanova4" runat="server" Text="<%$Resources:strings, banneranasayfaKPAciklama %>"/></div>
	  </a>--%>

        	  <a href="/Urunler/Kristal-Album/4" class="banner">                 
		<img class="replace-2x" src="/images/banner-ana-sayfa/kristal-seri-ana-sayfa-<%=randomSayi() %>.jpg" width="253" height="158" alt="">
		<h2 class="title"><asp:Literal ID="banneranasayfakris3" runat="server" Text="<%$Resources:strings, banneranasayfakris3 %>"/></h2>
		<div class="description"><asp:Literal ID="banneranasayfakris4" runat="server" Text="<%$Resources:strings, banneranasayfakris4 %>"/></div>
	  </a>

	  <a href="/Urunler/Standart-Panoramik-Album/5" class="banner">                 
		<img class="replace-2x" src="/images/banner-ana-sayfa/standart-seri-ana-sayfa-<%=randomSayi() %>.jpg" width="253" height="158" alt="">
		<h2 class="title"><asp:Literal ID="banneranasayfapan3" runat="server" Text="<%$Resources:strings, banneranasayfapan3 %>"/></h2>
		<div class="description"><asp:Literal ID="banneranasayfapan4" runat="server" Text="<%$Resources:strings, banneranasayfapan4 %>"/></div>
	  </a>

        	  <a href="/Urunler/Kampanyali-Panoramik-Albumler/6" class="banner">                 
		<img class="replace-2x" src="/images/banner-ana-sayfa/kampanyali-seri-ana-sayfa-<%=randomSayi() %>.jpg" width="253" height="158" alt="">
		<h2 class="title"><asp:Literal ID="Literal1" runat="server" Text="<%$Resources:strings, banneranasayfaKampTitle %>"/></h2>
		<div class="description"><asp:Literal ID="Literal2" runat="server" Text="<%$Resources:strings, banneranasayfaKampAciklama %>"/></div>
	  </a>


	</div><!-- .banners -->
	<div class="clearfix"></div>
  </div>
  <div class="nav-box">
	<div class="container">
	  <a class="prev" href="#"><span class="glyphicon glyphicon-arrow-left"></span></a>
	  <div class="pagination switches"></div>
	  <a class="next" href="#"><span class="glyphicon glyphicon-arrow-right"></span></a>	
	</div>
  </div>
</div><!-- .banner-set -->