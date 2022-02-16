<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="member.aspx.cs" Inherits="member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" Runat="Server">
    
    <!-- Content
		============================================= -->
		<section id="content">

			<div class="content-wrap">

				<div class="container clearfix">

					<div class="row clearfix">

						<div class="col-md-12">



							<img src="/images/icons/avatar.jpg" class="alignleft img-circle img-thumbnail notopmargin nobottommargin" alt="Avatar" style="max-width: 84px;">

							<div class="heading-block noborder">
								<h3>
                                    <asp:Literal ID="litMusteriAdi" runat="server"></asp:Literal> <a href="/uye-cikis">Çıkış Yap!</a></h3>
								    <span><asp:Literal ID="litFirmaBilgileri" runat="server"></asp:Literal></span>
							</div>



							<div class="clear"></div>
                            
                            <div class="heading-block noborder ">


							<div class="clear"></div>
                            
                            <div class="heading-block noborder">
                            <a href="/uye-sayfasi/bilgi-guncelle" class="button button-desc button-dark button-rounded"><div>Üye Bilgilerini Güncelle</div><span>Bilgilerinizi değiştirmek için tıklayın.</span></a>
                            <a href="/uye-sayfasi/sifre-guncelle" class="button button-desc button-dark button-rounded"><div>Şifre Güncelle</div><span>Şifrenizi değiştirin.</span></a>
                            <a href="/uye-sayfasi/mail-guncelle" class="button button-desc button-dark button-rounded"><div>Mail Güncelle</div><span>Mail adresinizi değiştirin.</span></a>
                                <br/>
                                </div>

							<div class="row clearfix">

								<div class="col-lg-12">
                                    


      

									<div class="tabs tabs-alt clearfix" id="tabs-profile">

										<ul class="tab-nav clearfix">
											<li><a href="#tab-siparisler"><i class="icon-cloudapp"></i> Aktif Siparişlerim</a></li>
                                            <li><a href="#tab-yuklemeler"><i class="icon-line-cloud-upload"></i> Yükleme Bekleyen Siparişlerim</a></li>
										</ul>

										<div class="tab-container">

											<div class="tab-content clearfix" id="tab-siparisler">

                                                <strong><asp:Literal ID="litSiparisAlinan" runat="server" Text=" <%$Resources:strings, yuklenenSiparis %>"></asp:Literal></strong>

												<table class="table table-bordered table-striped">
												  <thead>
													<tr>
													  <th>Sipariş Numarası</th>
													  <th>Tarih</th>
                                                      <th>Paket</th>
                                                        <th>Kapak</th>
                                                      <th>Sipariş Durumu</th>
                                                      <th>İşlem</th>
                                                        <th>Ödeme Durumu</th>
                                                    </tr>
												  </thead>
												  <tbody>
                                                  
                                                  <asp:Repeater ID="rptSiparislerim" runat="server">
                                                  <ItemTemplate>
                                                      <tr>
                                                          <td><code>PAN<%#Eval("id") %></code></td>
                                                          <td><%#Eval("m_tarih") %></td>
                                                          <td><%#Eval("paket_adi_tr") %></td>
                                                          <td><%#Eval("sipKapakYazi") %></td>
                                                          
                                                          <td><span class="price"><%#siparisDurumu(Convert.ToInt32(Eval("id"))) %></span></td>				    
                                                          <td class="text-center">
                                                              <div class="btn-group">
                                                                  <a href="/uye-sayfam/siparislerim/<%#Eval("id") %>" class="btn btn-sm btn-default"><asp:Literal ID="litSipIslem" runat="server" Text="<%$Resources:strings, memberSipDetay %>"></asp:Literal></a>
                                                                  <%--<a href="#" class="btn btn-sm btn-default">Reorder</a>--%>
                                                              </div>
                                                          </td>

                                                          <td class="text-center last">
                                                              <%#odemeKontrol(Convert.ToInt32(Eval("id"))) %>
                                                          </td>
                                                      </tr>         

                                                  </ItemTemplate>                                              
                                                  </asp:Repeater>

                                                    <tr id="siparisYok" runat="server" Visible="False">
                                                        <td colspan="5"><p>Gösterilecek sipariş bulunamadı!</p></td>
                                                    </tr>

												  </tbody>
												</table>

											</div>
                                        
                                        <div class="tab-content clearfix" id="tab-yuklemeler">

                                            <strong><asp:Literal ID="Literal1" runat="server" Text=" <%$Resources:strings, yuklenenBekleyenSiparis %>"></asp:Literal></strong>

                                           												<table class="table table-bordered table-striped">
												  <thead>
													<tr>
													  <th>Sipariş Numarası</th>
													  <th>Tarih</th>
                                                      <th>Paket</th>
                                                        <th>Kapak</th>
                                                      <th>İşlem</th>
                                                        <th>Sil</th>
                                                    </tr>
												  </thead>
												  <tbody>
                                                  
                                                  <asp:Repeater ID="rptYuklenecekSiparisler" runat="server" OnItemCommand="rptYuklenecekSiparisler_ItemCommand">
                                                  <ItemTemplate>
                                                      <tr>
                                                          <td><code>YUK<%#Eval("id") %></code></td>
                                                          <td><%#Eval("m_tarih") %></td>
                                                          <td><%#Eval("paket_adi_tr") %></td>
                                                          <td><%#Eval("sipKapakYazi") %></td>
                                                          <td class="text-center">
                                                              <div class="btn-group">
                                                                  <a href="/uye-sayfam/siparisyukle?yukle=<%#pwdHash.passwordHash.Sifrele(Eval("id").ToString())  %>" class="btn btn-sm btn-danger">Dosya Yükle</a>
                                                                  <%--<a href="#" class="btn btn-sm btn-default">Reorder</a>--%>
                                                              </div>
                                                          </td>


                                                          <td class="text-center last">
                                                                                                                              <div class="btn-group">
                                                                    <asp:LinkButton ID="LinkButton11" runat="server" CssClass="btn btn-sm btn-primary" CommandName="Sil" CommandArgument='<%#Eval("id") %>'>Sil</asp:LinkButton>
                                                                </div>

                                                          </td>

                                                      </tr>         

                                                  </ItemTemplate>                                              
                                                  </asp:Repeater>

                                                    <tr id="yuklemeBekleyenYok" runat="server" Visible="False">
                                                        <td colspan="5"><p>Yükleme bekleyen sipariş bulunamadı!</p></td>
                                                    </tr>

												  </tbody>
												</table>

                                        </div>                                        
                                        




										</div>

									</div>

								</div>

							</div>

						</div>



					</div>

				</div>

			</div>

		</section><!-- #content end -->

  



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBottom" Runat="Server">
    <!-- External JavaScripts
    ============================================= -->
    <script src="/js/jquery.js"></script>
    <script src="/js/plugins.js"></script>

    <!-- Footer Scripts
    ============================================= -->
    <script src="js/functions.js"></script>

    <script>
        jQuery( "#tabs-profile" ).on( "tabsactivate", function( event, ui ) {
            jQuery( '.flexslider .slide' ).resize();
        });
    </script>


</asp:Content>

