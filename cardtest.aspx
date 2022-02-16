<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="cardtest.aspx.cs" Inherits="cardtest" %>
<%@ MasterType VirtualPath="~/cizgi.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" Runat="Server">

    <link rel="stylesheet" href="/css/customizer/pages.css">
    <link rel="stylesheet" href="/css/customizer/shop-pages-customizer.css">
    <link href="/css/costum.css" rel="stylesheet" />
    
    
    <script type="text/javascript">    
        function masking(input, textbox) {
            if (input.length == 4 || input.length == 9 || input.length == 14) {
                input = input + ' ';
                textbox.value = input;
            }
        }
    </script>   

    <script src="/js/costum-js.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
<section id="content">

    <div class="content-wrap">

    <div class="container">

        <div class="row clearfix">

            <div class="col-md-12">
                

            
            <header class="page-header">
                <div class="container">
                    <h1 class="title">Kredi Kartı Ödeme Sayfası</h1>
                </div>	
            </header>
            
                <asp:Panel ID="pnlAna" runat="server" Visible="True">
                                <asp:Panel ID="pnlSepet" runat="server" Visible="True">

                                    <div class="alert alert-success" role="alert" runat="server" id="cardCekildi" Visible="False">
                                        <h5 class="text-center"><strong><asp:Label ID="lblBasarili" runat="server" Text=""></asp:Label></strong></h5>
                                    </div>    
                                    
                                    <div class="alert alert-danger" role="alert" runat="server" id="cardBasarisiz" Visible="False">
                                        <h5 class="text-center"><strong><asp:Label ID="lblBasarisiz" runat="server" Text=""></asp:Label></strong></h5>
                                    </div>                                        
                                    


                                    <div class="title-box" id="siparisOzet">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisozetii" runat="server" Text=" <%$Resources:strings, siparisOzeti %>"></asp:Literal></strong></h2>
                                    </div>

			            <div class="table-responsive">
			              <table class="table table-hover" runat="server">
				            
				            <tbody>
				              <tr>
					            <td class="text-left"><asp:Label ID="lblOzetPaketAdi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblOzetPaketFiyati" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="sayfaTipiOzet" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblOzetSayfaTipi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle">
                                    <asp:Label ID="lblOzetSayfaTipiFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

				              <tr id="yaprakSayisiOzet" runat="server" visible="false">
					            <td class="text-left">
                                    <asp:Literal ID="Literal6" runat="server" Text="<%$ Resources:strings, siparisYaprakSayisi %>"></asp:Literal> : <asp:Label ID="lblOzetYaprakSayisi" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle">
                                    <asp:Label ID="lblOzetYaprakSayisiFiyat" runat="server" Text=""></asp:Label>
                                    </td>
				              </tr>

                              <tr id="kagitSayisiOzet" runat="server" visible="false">
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

                              <tr id="buyukEkstra" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblBuyukEkstra" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblBuyukEkstraFiyat" runat="server" Text=""></asp:Label></td>
				              </tr>

                              <tr id="indirimTutari" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblindirimTutari" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblindirimTutariToplam" runat="server" Text=""></asp:Label></td>
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

				              <tr id="webccIndirim" runat="server" visible="false">
					            <td class="text-left"><asp:Label ID="lblwebccIndirimName" runat="server" Text=""></asp:Label></td>
					            <td class="text-right" style="vertical-align:middle"><asp:Label ID="lblwebccIndirimTutar" runat="server" Text=""></asp:Label></td>
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

				              <tr>
					            <td>

				            </td>
					            <td>


					            </td>
				              </tr>


				            </tbody>
			              </table>

			            </div>



                </asp:Panel>

            <div id="musteriForm" runat="server" visible="true" class="form-horizontal">

<%--                     <div class="form-group">
                         <input ID="txtCardNumber" CssClass="input-lg form-control"  onblur="return masking(this.value,this);" onKeyPress="return masking(this.value,this);" />
                
                        
                     </div>--%>
                
                <div class="form-group">
                        
                    <div class="col-sm-3">
                        <p style="font-size: 20px; margin-top:5px">Kart Üzerindeki İsim ve Soyisim</p>
                    </div>

                    <div class="col-sm-6">
                        <asp:TextBox ID="txtCardHolder" runat="server" CssClass="input-lg form-control" MaxLength="100" Width="370px" style="font-size: 20px"></asp:TextBox>

                    </div>
                </div>


                    <div class="form-group">
                        
                            <div class="col-sm-3">
                                <p style="font-size: 20px; margin-top:5px">Kart Numaranız :</p>
                            </div>

                        <div class="col-sm-6">
                            <asp:TextBox ID="txtCardNumber" runat="server" CssClass="input-lg form-control" MaxLength="19" onblur="return masking(this.value,this);" onKeyPress="return masking(this.value,this);" Width="370px" style="font-size: 20px"></asp:TextBox>

                        </div>
                    </div>
                
                
                    <div class="form-group">
                        <div class="col-sm-3">
                            <p style="font-size: 20px; margin-top:5px">Son Kullanma Tarihi :</p>
                        </div>


                        <div class="col-sm-2">
                            <asp:DropDownList ID="drpCardAy" runat="server" CssClass="input-lg form-control" style="font-size: 20px"></asp:DropDownList>
                        </div>
                
                        <div class="col-sm-2">
                            <asp:DropDownList ID="drpCardYil" runat="server" CssClass="input-lg form-control" style="font-size: 20px"></asp:DropDownList>
                        </div>
                    </div>
          
                
                <div class="form-group">
                        
                    <div class="col-sm-3">
                        <p style="font-size: 20px; margin-top:5px">Kart Tipi :</p>
                    </div>

                    <div class="col-sm-2" style="margin-right: 45px">
                       
                            <label><asp:RadioButton ID="visa" runat="server" Text="" GroupName="cardType"/> Visa</label><br/>
                            <label><asp:RadioButton ID="masterCard" runat="server" Text="" GroupName="cardType"/> MasterCard</label><br/>

                    </div>
                </div>                  
                
                <div class="form-group">
                        
                    <div class="col-sm-3">
                        <p style="font-size: 20px; margin-top:5px">CVC No :</p>
                    </div>

                    <div class="col-sm-2">
                        <asp:TextBox ID="CVC" runat="server" CssClass="input-lg form-control" MaxLength="3" style="font-size: 20px"></asp:TextBox>
                    </div>
                </div>                
                

                <div class="form-group">
                    <div class="col-sm-3">
                        <p style="font-size: 20px; margin-top:5px">Bankanız Seçin :</p>
                    </div>


                    <div class="col-sm-4">
                        <asp:DropDownList ID="DropCardBank" runat="server" CssClass="input-lg form-control" style="font-size: 20px" OnSelectedIndexChanged="DropCardBank_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    </div>
                
                </div>
                
                
                <div class="form-group" id="halkbankSecimler" runat="server" Visible="False">
                    <div class="col-sm-3">
                        <p style="font-size: 20px; margin-top:5px">İşbank İçin Taksit Seçenekleri</p>
                    </div>

                    <div class="col-sm-4">
                       <label><asp:RadioButton ID="rdnHalkbankTekCekim" runat="server" Text="" GroupName="halkbankRadio" /> Tek Çekim 
                           <asp:Label ID="lblHalkTek" runat="server" Text=""></asp:Label>
                       </label><br/>
<%--                        <label><asp:RadioButton ID="rdnHalkbankTaksit3" runat="server" Text="" GroupName="halkbankRadio"/> 3 Taksit
                        <asp:Label ID="lblHalk3" runat="server" Text=""></asp:Label>
                        </label><br/>
                        <label><asp:RadioButton ID="rdnHalkbankTaksit6" runat="server" Text="" GroupName="halkbankRadio"/> 6 Taksit
                            <asp:Label ID="lblHalk6" runat="server" Text=""></asp:Label>
                        </label><br/>--%>
                    </div>
                </div>             
                
                <div class="form-group" id="digerBankaSecimler" runat="server" Visible="False">
                    <div class="col-sm-3">
                        <p style="font-size: 20px; margin-top:5px">Diğer Bankalar İçin Seçenekler</p>
                    </div>

                    <div class="col-sm-4">
                        <label><asp:RadioButton ID="rdnDigerBankaTekCekim" runat="server" Text="" GroupName="digerRadio" /> Tek Çekim
                            <asp:Label ID="lblDigerBankaTek" runat="server" Text=""></asp:Label>
                        </label><br/>
                    </div>
                </div>           
                
                <div class="form-group">
                        <div class="col-sm-3">
                            <label><asp:Literal ID="litMesafeliSatisSozlesme" runat="server" Text="Mesafeli Satış Sözleşmesi"></asp:Literal>: </label>
                        </div>
                            <div class="col-sm-8">
                            <asp:TextBox ID="txtMesafeliSatisSozlesme" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="True" Height="400"></asp:TextBox> 
                        </div>
                </div>   

                
                <div class="form-group">
                    <div class="col-sm-3">

                    </div>

                    <div class="col-sm-8">
                        <label class="checkbox">
                            <asp:CheckBox ID="chkMesafeliSatisSozlesme" runat="server" Text="Mesafeli Satış Sözleşmesini Okudum ve Kabul Ediyorum" />
                        </label>
                    </div>

                </div>
                

                    <div class="form-group">
                        <div class="col-sm-3">

                        </div>
                        <div class="col-sm-8">
                        <asp:Button ID="btnFormuGonder" runat="server" Text="<%$Resources:strings, siparisFormuGonder %>" CssClass="btn btn-default" OnClick="btnFormuGonder_Click" />         
                    </div>
                </div>
                
                <asp:Label ID="lblHata" runat="server" Text=""></asp:Label>

                </div>

                </asp:Panel>
                
                <asp:Panel ID="pnlHata" runat="server">
                    <asp:Label ID="lblHataSayfa" runat="server" Text=""></asp:Label>
                </asp:Panel>
            

            </div>
            



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

      </div><!-- .content -->
	  



    </div>
  </div>
</section><!-- #main -->
        
        
        
        

                </ContentTemplate>
            </asp:UpdatePanel>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBottom" Runat="Server">
    



</asp:Content>

