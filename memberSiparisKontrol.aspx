<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="memberSiparisKontrol.aspx.cs" Inherits="memberSiparisKontrol" %>
<%@ Register Src="~/memberRightBar.ascx" TagPrefix="uc1" TagName="memberRightBar" %>
<%@ Register Src="~/updateProgress.ascx" TagPrefix="uc2" TagName="updateProgress" %>


<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" Runat="Server">
        
        <link rel="stylesheet" href="/css/customizer/pages.css">
        <link rel="stylesheet" href="/css/customizer/shop-pages-customizer.css">
        <script src="/js/costum-js.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" Runat="Server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


<section id="main" class="page ">

  <div class="container">
    <div class="row">
      <article class="col-sm-9 col-md-9 content">
		<div class="my-account">


              <div class="col-xs-12 col-sm-12 col-md-12 box register">
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>



                <asp:Panel ID="pnlSepet" runat="server" Visible="true">
                    
                                    <div class="title-box" id="siparisOzet">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisozetii" runat="server" Text=" <%$Resources:strings, siparisOzeti %>"></asp:Literal></strong></h2>
                                    </div>
                    
                    <asp:Panel runat="server" Visible="False" ID="panelProgress">

                    		  <div class="progress progress-striped active hover  border-radius" data-appear-progress-animation="100%" id="divIptal" runat="server" visible="false">
			                    <div class="progress-bar progress-bar-danger"><asp:Label ID="lblIpdal" runat="server" Text="<%$Resources:strings, sipDetayIptalEdildi %>"></asp:Label></div>
		                      </div>

                    		  <div class="progress progress-striped active hover  border-radius" data-appear-progress-animation="20%" id="divOnayBekliyor" runat="server" visible="false">
			                    <div class="progress-bar progress-bar-warning"><asp:Label ID="Label1" runat="server" Text="<%$Resources:strings, sipDetayOnayBekliyor %>"></asp:Label></div>
		                      </div>

                    		  <div class="progress progress-striped active hover  border-radius" data-appear-progress-animation="25%" id="divOnaylandi" runat="server" visible="false">
			                    <div class="progress-bar progress-bar-warning"><asp:Label ID="Label11" runat="server" Text="<%$Resources:strings, sipDetayOnaylandi %>"></asp:Label></div>
		                      </div>

                    		  <div class="progress progress-striped active hover  border-radius" data-appear-progress-animation="35%" id="divPhotoshopBolumu" runat="server" visible="false">
			                    <div class="progress-bar progress-bar-info"><asp:Label ID="Label5" runat="server" Text="<%$Resources:strings, sipDetayPhotoshopda %>"></asp:Label></div>
		                      </div>

                    		  <div class="progress progress-striped active hover  border-radius" data-appear-progress-animation="40%" id="divBaskiBolumu" runat="server" visible="false">
			                    <div class="progress-bar progress-bar-info"><asp:Label ID="Label6" runat="server" Text="<%$Resources:strings, sipDetayBaskida %>"></asp:Label></div>
		                      </div>

                    		  <div class="progress progress-striped active hover  border-radius" data-appear-progress-animation="60%" id="divImalatta" runat="server" visible="false">
			                    <div class="progress-bar progress-bar-default"><asp:Label ID="Label7" runat="server" Text="<%$Resources:strings, sipDetayImalatta %>"></asp:Label></div>
		                      </div>

                    		  <div class="progress progress-striped active hover  border-radius" data-appear-progress-animation="85%" id="divPaketlemede" runat="server" visible="false">
			                    <div class="progress-bar progress-bar-primary"><asp:Label ID="Label8" runat="server" Text="<%$Resources:strings, sipDetayPaketleme %>"></asp:Label></div>
		                      </div>

                    		  <div class="progress progress-striped active hover  border-radius" data-appear-progress-animation="90%" id="divGonderiBekliyor" runat="server" visible="false">
			                    <div class="progress-bar progress-bar-info"><asp:Label ID="Label9" runat="server" Text="<%$Resources:strings, sipDetayGonderiBekliyor %>"></asp:Label></div>
		                      </div>


                    		  <div class="progress progress-striped active hover  border-radius" data-appear-progress-animation="100%" id="divGonderildi" runat="server" visible="false">
			                    <div class="progress-bar progress-bar-success"><asp:Label ID="Label10" runat="server" Text="<%$Resources:strings, sipDetayGonderildi %>"></asp:Label></div>
		                      </div>


                    </asp:Panel>


			            <div class="table-responsive">
			              <table class="table table-hover" runat="server">
				            
				            <tbody>

				              <tr>
					            <td class="text-left"><asp:Label ID="lblOzetPaketAdi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblOzetPaketFiyati" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="sayfaTipiOzet" runat="server" visible="true">
					            <td class="text-left"><asp:Label ID="lblOzetSayfaTipi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle">
                                    <asp:Label ID="lblOzetSayfaTipiFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="yaprakSayisiOzet" runat="server" visible="true">
					            <td class="text-left">
                                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:strings, siparisYaprakSayisi %>"></asp:Literal> : <asp:Label ID="lblOzetYaprakSayisi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle">
                                    <asp:Label ID="lblOzetYaprakSayisiFiyat" runat="server" Text=""></asp:Label>
                                    </td>
				              </tr>

                              <tr id="kagitSayisiOzet" runat="server" visible="true">
					            <td class="text-left"><asp:Label ID="lblKagitYazi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle">
                                    <asp:Label ID="lblKagitFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="saatOzet" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblOzetSaatAdi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblOzetSaatFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="cantaOzet" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblOzetCantaAdi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblOzetCantaFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="aileOzet" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblOzetAileAdi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblOzetAileFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="cepOzet" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblOzetCepAdi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblOzetCepFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="buyukOzet" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblOzetBuyukAdi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblOzetBuyukFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="calismaOzet" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblOzetCalismaAdi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblOzetCalismaFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="buyukEbatYazisi" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblBuyukEbatYazisi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="kapakYazisi" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblkapakYazisi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="musteriNotu" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblmusteriNotu" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="secilenKapakModeli" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblKapakModelAdi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblKapakModelFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="calismaGenelToplam" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblGenelToplam" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblGenelToplamFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>


				            </tbody>
			              </table>



                        <div class="margin-top-30 clearfix">

  <table class="table table-hover" runat="server">
				            
				            <tbody>



				            </tbody>
			              </table>

			            </div>
                    
</asp:Panel>
                
                <asp:Panel ID="pnlKargoDetay" runat="server" Visible="false">
                             <div class="title-box" id="siparisKargo">
                                <h2 class="title" style="color:#40499B"><strong><asp:Label ID="Label12" runat="server" Text="<%$Resources:strings, memberDTKargoBilgiTitle %>"></asp:Label></strong></h2> 
                            </div>

                            <div class="table-responsive" runat="server" id="arasKargoTakip" visible="false">
			                <table class="table table-hover" runat="server">
				            
				                <tbody>
				                    
                                    
                                    <tr>
                                        <td class="text-left">
                                            <strong>İrsaliye No</strong>
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblirsaliyeNo" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td class="text-left">
                                            <strong>Takip No</strong>
                                        </td>

                                        <td class="text-left">
                                            <asp:HyperLink ID="hypArasLink" runat="server" Target="_blank" CssClass="text-danger"><asp:Label ID="lblKargoLinkNo" runat="server" Text=""></asp:Label> (Buraya tıklayarak kargonuzu Aras Kargo websitesi üzerinden takip edebilirsiniz.)
                                            </asp:HyperLink>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="text-left">
                                            <strong>Gönderen</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblGonderen" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td class="text-left">
                                            <strong>Alıcı</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblAlici" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="text-left">
                                            <strong>Çıkış Şubesi</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblCikisSube" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td class="text-left">
                                            <strong>Varış Şubesi</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblVarisSubesi" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="text-left">
                                            <strong>Kargo Tarihi</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblKargoTarih" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td class="text-left">
                                            <strong>Kargo Adeti</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblAdet" runat="server" Text=""></asp:Label>
                                        </td>                                 
                                    </tr>

                                    <tr>
                                        <td class="text-left">
                                            <strong>Ödeme Tipi</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblOdemeTipi" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td class="text-left">
                                            <strong>Kargo Desi</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblDesi" runat="server" Text=""></asp:Label>
                                        </td>                                 
                                    </tr>

                                    <tr>
                                        <td class="text-left">
                                            <strong>Kargo Durumu</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblKargoDurumu" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td class="text-left">
                                            <strong>Teslim Edecek Şube Kodu</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblTeslimSubeKodu" runat="server" Text=""></asp:Label>
                                        </td>                                 
                                    </tr>

                                    <tr runat="server" id="teslimBolumu" visible="false">
                                        <td class="text-left">
                                            <strong>Teslim Alan</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblTeslimAlan" runat="server" Text=""></asp:Label>
                                        </td>

                                        <td class="text-left">
                                            <strong>Teslim Tarihi</strong> 
                                        </td>

                                        <td class="text-left">
                                            <asp:Label ID="lblTeslimTarihi" runat="server" Text=""></asp:Label>
                                        </td>                                 
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="4" class="text-left"><strong class="text-info">Kargo bilgileriniz Aras Kargo websitesinden alınmaktadır. Yukarıdaki kargo bilgileri bilgilendirme amaçlı olup, yukarıdaki bilgilerde herhangi bir hata olması Çizgi Albüm 'ü bağlayıcılığı yoktur. Kargonuzun yanlış gönderildiğini düşünüyorsanız lütfen Çizgi Albüm ile irtibat kurun. Güncel kargo bilgilerini almak için sayfayı tekrardan yükleyebilirsiniz.</strong></td>
                                    </tr>

                                </tbody>

                                
                            </table>
                        </div>



          <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>

</asp:Panel>                                                   
                <asp:Panel ID="pnlKargoDetayYurtdisi" runat="server" Visible="false">
                             <div class="title-box" id="siparisKargoYurtdisi">
                                <h2 class="title" style="color:#40499B"><strong><asp:Label ID="Label13" runat="server" Text="<%$Resources:strings, memberDTKargoBilgiTitle %>"></asp:Label></strong></h2>
                                 
                            </div>
                    <p><strong><asp:Label ID="lblKargoYurtdisi" runat="server" Text="" CssClass="text-info"></asp:Label></strong></p> 
                </asp:Panel>

                <asp:Panel ID="pnlKargoDetayYurtici" runat="server" Visible="false">
                             <div class="title-box" id="siparisKargoYurtici">
                                <h2 class="title" style="color:#40499B"><strong><asp:Label ID="Label14" runat="server" Text="<%$Resources:strings, memberDTKargoBilgiTitle %>"></asp:Label></strong></h2>
                                 
                            </div>
                    <p><strong><asp:Label ID="lblKargoYurtici" runat="server" Text="" CssClass="text-info"></asp:Label></strong></p> 
                </asp:Panel>

                <asp:Panel ID="kargoBekliyor" runat="server" Visible="false">
                             <div class="title-box" id="siparisKargoBekliyor">
                                <h2 class="title" style="color:#40499B"><strong><asp:Label ID="Label15" runat="server" Text="<%$Resources:strings, memberDTKargoBilgiTitle %>"></asp:Label></strong></h2>
                                 
                            </div>
                    <p><strong><asp:Label ID="lblKargoBekliyor" runat="server" Text="" CssClass="text-danger"></asp:Label></strong></p> 
                </asp:Panel>

                <asp:Panel ID="pnlKargoEski" runat="server" Visible="false">
                             <div class="title-box" id="siparisKargoEski">
                                <h2 class="title" style="color:#40499B"><strong><asp:Label ID="Label16" runat="server" Text="<%$Resources:strings, memberDTKargoBilgiTitle %>"></asp:Label></strong></h2>
                                 
                            </div>
                    <p><strong><asp:Label ID="lblKargoEski" runat="server" Text="" CssClass="text-danger"></asp:Label></strong></p> 
                </asp:Panel>
                




                <div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10%;">
                    <div class="modal-dialog modal-dialog-center25">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                                <h5 class="modal-title"><asp:Literal ID="litHataTitle" runat="server"></asp:Literal></h5>
                            </div>
                            <div class="modal-body">
                                <p><asp:Label ID="regFormErrList" runat="server" Text=""></asp:Label>                                   
                                </p>
                            </div>
                            <div class="modal-footer">
                                <button data-dismiss="modal" class="btn btn-default">OK</button>
                            </div>
                        </div>
                    </div>
                </div>

                              </ContentTemplate>
                    </asp:UpdatePanel>  	  
		  </div>

               
        








		</div>
      </article><!-- .content -->
	  
        

    </div>
  </div>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" >

            <ProgressTemplate>

                <uc2:updateProgress runat="server" ID="updateProgress" />

            </ProgressTemplate>

        </asp:UpdateProgress>

</section><!-- #main -->

</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="contentBottom" Runat="Server">
</asp:Content>

