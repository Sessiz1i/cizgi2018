<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>

<%@ Register Src="~/updateProgress.ascx" TagPrefix="uc2" TagName="updateProgress" %>


<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" runat="Server">

    <link rel="stylesheet" type="text/css" href="/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="/css/animate.css">
    <link rel="stylesheet" type="text/css" href="/order.css">
    <link rel="stylesheet" href="/css/fontawesome/css/all.min.css">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" runat="Server">

<!-- Content ============================================= -->

<asp:ScriptManager ID="ScriptManager1" runat="server">

</asp:ScriptManager>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>


<!-- Content
============================================= -->
<section id="content">

<div class="content-wrap notoppadding">

<div class="container clearfix">

<div class="row">
    <div class="col-md-12 clearfix">
        <div id="processTabs">
            <ul class="order-process-steps process-9">
                <li runat="server" id="process1">
                    <asp:Label ID="lnkBtnProcess1" runat="server" CssClass="active icb divcenter">1</asp:Label>
                    <h5>Seriler</h5>
                </li>
                <li runat="server" id="process2">
                    <asp:Label ID="lnkBtnProcess2" runat="server" CssClass="icb divcenter">2</asp:Label>
                    <h5>Ölçüler</h5>
                </li>
                <li runat="server" id="process3">
                    <asp:Label ID="lnkBtnProcess3" runat="server" CssClass="icb divcenter">3</asp:Label>
                    <h5>Paketler</h5>
                </li>
                <li runat="server" id="process4">
                    <asp:Label ID="lnkBtnProcess4" runat="server" CssClass="icb divcenter">4</asp:Label>
                    <h5>Kapaklar</h5>
                </li>
                <li runat="server" id="process5">
                    <asp:Label ID="lnkBtnProcess5" runat="server" CssClass="icb divcenter">5</asp:Label>
                    <h5>Kumaşlar</h5>
                </li>
                <li runat="server" id="process6">
                    <asp:Label ID="lnkBtnProcess6" runat="server" CssClass="icb divcenter">6</asp:Label>
                    <h5>Ekstralar</h5>
                </li>
                <li runat="server" id="process7">
                    <asp:Label ID="lnkBtnProcess7" runat="server" CssClass="icb divcenter">7</asp:Label>
                    <h5>Bilgiler</h5>
                </li>
                <li runat="server" id="process8">
                    <asp:Label ID="lnkBtnProcess8" runat="server" CssClass="icb divcenter">8</asp:Label>
                    <h5>Adres</h5>
                </li>
                <li runat="server" id="process9">
                    <asp:Label ID="lnkBtnProcess9" runat="server" CssClass="icb divcenter">9</asp:Label>
                    <h5>Onay</h5>
                </li>
            </ul>
            <div class="line line-sm notopmargin"></div>
        </div>
    </div>
</div>
<div class="row">
<i class="fa-solid fa-cart-circle-plus"></i>
<!-- Left Content
============================================= -->
<!-- Seriler List Panel  -->
<asp:Panel CssClass="col-md-8 clearfix bottommargin-sm" ID="pnlSeriList" runat="server" Visible="true">
    <div class="row">
        <asp:Repeater ID="rptSeriList" runat="server" OnItemCommand="seriSec">
            <ItemTemplate>
                <div class="col-md-6">
                    <asp:LinkButton ID="lnkButtonSeriSec" runat="server" CommandName="seriEkle" CommandArgument='<%#Eval("polcu_kategori_id") + "," + Eval("polcu_kategori_adi") %>' CssClass="btn-serial-size"><%#Eval("polcu_kategori_adi") %></asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="col-md-12">
            <div class="line line-sm"></div>
            <asp:LinkButton Enabled="False" ID="lnkIlerle1" runat="server" CssClass="button button-deactive button-red button-3d fright" OnClick="lnkIlerle1_Click">Seçim Yapınız...</asp:LinkButton>
        </div>
    </div>
</asp:Panel>
<!-- Ölçüler List Panel  -->
<asp:Panel CssClass="col-md-8 clearfix bottommargin-sm" ID="pnlOlculer" runat="server" Visible="false">
    <div class="row">
        <asp:Repeater ID="rptOlculer" runat="server" OnItemCommand="olcuSec">
            <ItemTemplate>
                <div class="col-md-6">
                    <asp:LinkButton ID="lnkButtonOlcuSec" runat="server" CommandName="olcuEkle" CommandArgument='<%#Eval("paketolcu_id") + "," + Eval("paketolcu_isim") %>' CssClass='<%# isActive(secilenOlcu, Convert.ToInt32(Eval("paketolcu_id"))) %>'><%#Eval("paketolcu_isim") %></asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="col-md-12">
            <div class="line line-sm"></div>
            <asp:LinkButton ID="lnkGerile2" runat="server" CssClass="button button-3d" OnClick="lnlGerile2_Click">&lArr; ÖNCEKİ ADIM</asp:LinkButton>
            <asp:LinkButton ID="lnkIlerle2" runat="server" CssClass="button button-deactive button-red button-3d" OnClick="lnkIlerle2_Click">SONRAKİ ADIM &rArr;</asp:LinkButton>
        </div>
    </div>
</asp:Panel>
<%-- Paketler List Panel  --%>
<asp:Panel CssClass="col-md-8 clearfix bottommargin-sm " ID="pnlPaketler" runat="server" Visible="false">
    <div class="row">
        <asp:Repeater ID="rptPaketler" runat="server" OnItemCommand="paketSec">
            <ItemTemplate>
                <div class=" col-sm-12 pulse">
                    <asp:Panel id="paketPanel" CssClass="paket-card" runat="server">
                        <asp:ImageButton ImageUrl='https://picsum.photos/500' CssClass="imgBtnPaketSec" ID="imgBtnPaketSec" runat="server" CommandName="paketEkle" CommandArgument='<%#Eval("paket_id") %>'/>
                        <div class="row" style="padding: 0 15px">
                            <div class="col-sm-4 no-padding">
                                <img class="img-fluid" height="100%" src="https://picsum.photos/500"/>
                                <%-- <img class="img-fluid" height="100%" src="<%# string.Format("/images/paketfotolar/{0}", Eval("paket_fotonew")) %>"/> --%>
                            </div>
                            <div class="col-sm-8 no-padding">
                                <div class="paket-card-body">
                                    <asp:Label runat="server" ID="CartTitle" Text='<%#Eval("paket_adi_tr") %>' CssClass="card-title"/>
                                    <div class="line nomargin"></div>
                                    <%# paketAltGetir(Convert.ToInt32(Eval("paket_id"))) %>
                                    <div class="body-bottom">
                                        <strong><%# fiyatlar.fiyatBul.paketFiyat(Convert.ToInt32(Eval("paket_id")), Convert.ToInt32(memberID), "TL", 1) %></strong>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="col-sm-12">
            <div class="line line-sm"></div>
            <asp:LinkButton ID="lnkGerile3" runat="server" CssClass="button button-3d fleft" OnClick="lnlGerile3_Click">&lArr; ÖNCEKİ ADIM</asp:LinkButton>
            <asp:LinkButton ID="lnkIlerle3" runat="server" CssClass="button button-deactive button-red button-3d fright" OnClick="lnkIlerle3_Click">SONRAKİ ADIM &rArr;</asp:LinkButton>
        </div>
    </div>
</asp:Panel>
<%-- Kapaklar List Panel  --%>
<asp:Panel CssClass="col-md-8 clearfix bottommargin-sm" ID="pnlKapaklar" runat="server" Visible="false">
    <div class="row">
        <div class="col-sm-6 form-group-lg search" style="margin-bottom: 20px">
            <input role="button" type="search" id="search" class="sm-form-control tleft default" onkeyup="handelSearch()" placeholder="Kapak Ara..." autocomplete="off" value="" runat="server"/>
            <i class="icon-search3"></i>
        </div>
    </div>
    <div class="row">
        <asp:Repeater ID="rptKapaklar" runat="server" OnItemCommand="kapakSec">
            <ItemTemplate>
                <div class="col-md-6 col-sm-6 ">
                    <asp:Panel ID="kapakPanel" runat="server" CssClass="order-kapak">
                        <%-- <asp:ImageButton CssClass="kapak-image" ID="imgBtnKapakFoto" runat="server" ImageUrl='<%# string.Format("/images/nurun/{0}", Eval("nurunimage_path")) %>' CommandName="kapakEkle" CommandArgument='<%#Eval("nurun_id") + "," + Eval("nurun_adi") %>'/> --%>
                        <asp:ImageButton CssClass="kapak-image" ID="imgBtnKapakFoto" runat="server" ImageUrl='https://picsum.photos/500/400' CommandName="kapakEkle" CommandArgument='<%#Eval("nurun_id") + "," + Eval("nurun_adi") %>'/>
                        <div class="card-body p-0">
                            <asp:Label CssClass="kapak-title" ID="kapakLabel" runat="server" Text='<%#Eval("nurun_adi") %>'/>
                            <div class="kapak-btn-grp" role="group">
                                <asp:LinkButton runat="server" ID="lnkKapakDetay" CommandName="kapakDetay" CssClass="kapak-btn" CommandArgument='<%#Eval("nurun_id") %>' Text='<i style="pointer-events: none" class="fas fa-search-plus fa-lg"></i>&nbsp;Detay'/>
                                <asp:LinkButton CssClass="kapak-btn" ID="lnkBtnKapakYazi" runat="server" Text='<i style="pointer-events: none" class="fas fa-cart-plus fa-lg"></i>&nbsp;Ekle' CommandName="kapakEkle" CommandArgument='<%#Eval("nurun_id") + "," + Eval("nurun_adi") %>'/>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="col-sm-12">
            <div class="line line-sm"></div>
            <asp:LinkButton ID="lnkGerile4" runat="server" CssClass="button button-3d fleft" OnClick="lnlGerile4_Click">&lArr; ÖNCEKİ ADIM</asp:LinkButton>
            <asp:LinkButton ID="lnkIlerle4" runat="server" CssClass="button button-deactive button-red button-3d fright" OnClick="lnkIlerle4_Click">SONRAKİ ADIM &rArr;</asp:LinkButton>
        </div>
    </div>
</asp:Panel>
<%-- Kumaşlar List Panel  --%>
<asp:Panel CssClass="col-md-8 clearfix bottommargin-sm" ID="pnlKumaslar" runat="server" Visible="false">
    <div class="row">
        <div class="col-md-12">
            <div class="kumaslar-title">
                <h4>Kumaş Seçimi</h4>
            </div>
            <div class="kumaslar">
                <asp:Repeater ID="rptKumaslar" runat="server" OnItemCommand="kumasSec">
                    <ItemTemplate>
                        <asp:Panel CssClass="kumas" runat="server" ID="kumas">
                            <asp:ImageButton CssClass="image" ID="imgBtnKumas" runat="server" ImageUrl='<%# string.Format("/images/nkumaslar/{0}", Eval("nkumaslar_path")) %>' CommandName="kumasEkle" CommandArgument='<%#Eval("nkumaslar_id") + "," + Eval("nkumaslar_adi") %>'/>
                            <asp:LinkButton CssClass="kumas-title" ID="lnkBtnKumas" runat="server" Text='<%#Eval("nkumaslar_adi") %>' CommandName="kumasEkle" CommandArgument='<%#Eval("nkumaslar_id") + "," + Eval("nkumaslar_adi") %>'/>
                            <img class="big-image" src="/images/nkumaslar/<%#Eval("nkumaslar_path") %>">
                        </asp:Panel>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div style="padding-bottom: 25px"></div>
        </div>
        <div class="col-md-12" id="ahsaplar" runat="server">
            <div class="kumaslar-title">
                <h4>Ahşap Seçimi</h4>
            </div>
            <div class="row row-cols-1 row-cols-sm-3 mx-0">
                <asp:Repeater ID="rptAhsap" runat="server" OnItemCommand="ahsapSec">
                    <ItemTemplate>
                        <div class="col-sm-4 px-2">
                            <asp:Panel CssClass="order-kapak mb-sm-0" runat="server" ID="ahsapPanel">
                                <asp:ImageButton CssClass="ahsap-image" ID="imgBtnAhsap" runat="server" ImageUrl='<%# string.Format("/images/nahsap/{0}", Eval("nahsap_image")) %>' CommandName="ahsapEkle" CommandArgument='<%#Eval("nahsap_id") + "," + Eval("nahsap_kisaad") %>'/>
                                <div class="card-body p-0">
                                    <asp:LinkButton CssClass="ahsap-title" ID="lnkBtnAhsap" runat="server" Text='<%#Eval("nahsap_kisaad") %>' CommandName="ahsapEkle" CommandArgument='<%#Eval("nahsap_id") + "," + Eval("nahsap_kisaad") %>'/>
                                </div>
                            </asp:Panel>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="col-sm-12">
            <div class="line line-sm"></div>
            <asp:LinkButton ID="lnkGerile5" runat="server" CssClass="button button-3d fleft" OnClick="lnlGerile5_Click">&lArr; ÖNCEKİ ADIM</asp:LinkButton>
            <asp:LinkButton ID="lnkIlerle5" runat="server" CssClass="button button-deactive button-red button-3d fright" OnClick="lnlIlerle5_Click">SONRAKİ ADIM &rArr;</asp:LinkButton>
        </div>
    </div>
</asp:Panel>
<%-- Extralar List Panel  --%>
<asp:Panel CssClass="col-md-8 clearfix bottommargin-sm" ID="pnlEkstralar" runat="server" Visible="false">
    <div class="row">
        <div class="col-sm-12">
            <div class="tabs clearfix ui-tabs ui-widget ui-widget-content ui-corner-all">
                <ul class="tab-nav tab-nav2 clearfix ui-tabs-nav ui-helper-reset ui-helper-clearfix ui-widget-header ui-corner-all" role="tablist">
                    <asp:Repeater ID="rptEkstraGruplar" runat="server">
                        <ItemTemplate>
                            <li id="tab-btn-<%#Eval("npaketextragruplar_id") %>" class="tab-button ui-state-default ui-corner-top" role="tab" tabindex="-1" aria-controls="tabs-10" aria-labelledby="ui-id-22" aria-selected="false" aria-expanded="false">
                                <a class="ui-tabs-anchor cursor uppercase" role="presentation" tabindex="-1" onclick="extraTab('<%#Eval("npaketextragruplar_id") %>')">
                                    <%#Eval("npaketextragruplar_adi") %>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="tab-container">
                    <asp:Repeater ID="ParentRepeater" runat="server" OnItemDataBound="ItemBound">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnPaketGruplarID" runat="server" Value='<%#Eval("npaketextragruplar_id") %>'/>
                            <asp:HiddenField ID="hdnPaketGruplarIDAdi" runat="server" Value='<%#Eval("npaketextragruplar_aciklama") %>'/>
                            <div class="tab-content clearfix ui-tabs-panel ui-widget-content ui-corner-bottom" id="tab-content-<%#Eval("npaketextragruplar_id") %>" aria-labelledby="ui-id-22" role="tabpanel" aria-hidden="true" style="display: none;">
                                <div class="row">
                                    <asp:Repeater ID="ChildRepeater" runat="server" OnItemCommand="ekstraSec">
                                        <ItemTemplate>
                                            <div class="col-md-6 col-sm-6 col-xs-12">
                                                <asp:Panel id="extraPanel" CssClass="extra-card" runat="server">
                                                    <div class="row" style="padding: 0 15px">
                                                        <div class="col-md-4 no-padding">
                                                            <img class="img-fluid" src="https://picsum.photos/150" alt="<%#Eval("paketextra_adi") %>" width="100%"/>
                                                        </div>
                                                        <div class="col-md-8 no-padding">
                                                            <div class="extra-card-body">
                                                                <div class="body-top">
                                                                    <asp:Label runat="server" ID="CartTitle" Text='<%#Eval("paketextra_adi") %>' CssClass="extra-card-title"/>
                                                                    <%--<p class="extra-card-desc"><%#Eval("paketextra_aciklama") %></p>--%>
                                                                </div>

                                                                <div class="body-bottom">
                                                                    <div class="extra-card-qty-price">
                                                                        <div class="quantity">
                                                                            <asp:LinkButton ID="lnlEkstraSil" runat="server" CssClass="cart-minus fa fa-minus" CommandName="ekstraSil" CommandArgument='<%#Eval("paketextra_id") %>'/>
                                                                            <asp:LinkButton ID="lblEkstraSayi" CssClass="cart-qty" Enabled="False" runat="server" Text='<%#mevcutEkstraSayi(Convert.ToInt32(Eval("paketextra_id"))) %>'/>
                                                                            <asp:LinkButton ID="lblEkstraEkle" CssClass="cart-plus fa fa-plus" runat="server" CommandName="ekstraEkle" CommandArgument='<%#Eval("paketextra_id") %>'/>
                                                                        </div>
                                                                        <div class="extra-item-quantity">
                                                                            <span id="iFiyat" class="iscfyt"><%#ekstraFiyatKarsilastir(Eval("paketextra_fiyatYeni").ToString(), fiyatlar.fiyatBul.paketExtraFiyat(secilenPaket, Convert.ToInt32(Eval("paketextra_id")), Convert.ToInt32(memberID), "TL", 2)) %></span>
                                                                            <span id="nFiyat" style="color: green"><%# Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(secilenPaket, Convert.ToInt32(Eval("paketextra_id")), Convert.ToInt32(memberID), "TL", 2)).ToString("N") %>&nbsp;<i class="fa fa-try"></i></span>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div class="col-sm-12">
            <div class="line line-sm"></div>
            <asp:LinkButton ID="lnkGerile6" runat="server" CssClass="button button-3d" OnClick="lnlGerile6_Click">&lArr; ÖNCEKİ ADIM</asp:LinkButton>
            <asp:LinkButton ID="lnkIlerle6" runat="server" CssClass="button button-deactive button-red button-3d fright" OnClick="lnlIlerle6_Click">SONRAKİ ADIM &rArr;</asp:LinkButton>
        </div>
    </div>
</asp:Panel>


<div class="col-md-4 clearfix">
    <%--  <div class="row">
        <asp:Panel CssClass="col-sm-12 py-4 py-sm-5" ID="pnlKumasImg" runat="server" Visible="false">
            <div class="card custCarousel shadow">
                <div id="custCarousel" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner">
                        <asp:Repeater ID="rptKumasKapak" runat="server">
                            <ItemTemplate>
                                <div class="carousel-item" data-interval="2000">
                                    <img style="width:100%" src="/images/nurun/<%#Eval("nurunimage_path") %>" title="<%#Eval("nurunimage_path") %>" alt="<%#Eval("nurunimage_path") %>">
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <!-- Left right -->
                        <a class="carousel-control-prev" href="#custCarousel" data-slide="prev">
                            <span class="carousel-control-prev-icon"></span>
                        </a>
                        <a class="carousel-control-next" href="#custCarousel" data-slide="next">
                            <span class="carousel-control-next-icon"></span>
                        </a> <!-- Thumbnails -->
                    </div>
                    <div>
                        <h3 style="text-align: center">Kapak Adı</h3>
                    </div>
                    <ol class="carousel-indicators list-inline">
                        <asp:Repeater ID="rptKumasKapak1" runat="server">
                            <ItemTemplate>
                                <li class="list-inline-item">
                                    <a id="carousel-selector-<%# Container.ItemIndex %>" data-slide-to="<%# Container.ItemIndex %>" data-target="#custCarousel">
                                        <img src="/images/nurun/<%#Eval("nurunimage_path") %>" title="<%#Eval("nurunimage_path") %>" alt="<%#Eval("nurunimage_path") %>" class="img-fluid">
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ol>
                </div>
            </div>
        </asp:Panel>
    </div>--%>
    <div class="row">
        <div class="col-sm-12">
            <div class="order-cart bottom-padding">
                <div class="cart-title">
                    <h4>Sipariş Bilgileriniz</h4>
                </div>
                <div class="cart-items">
                    <div class="cart-item noborder clearfix" runat="server" id="emptyCart" visible="true">
                        <div class="cart-title noborder">
                            <h4 class="noborder text-danger">Sepetiniz Boş...</h4>
                        </div>
                    </div>
                    <div class="cart-item clearfix" runat="server" id="dvSeriAdi" visible="false">
                        <div class="cart-item-desc">
                            <div class="desc-title">
                                <span class="desc-title">Seri : <asp:Label ID="sepetSeriAdi" runat="server" Text=""/></span>
                            </div>
                        </div>
                    </div>
                    <div class="cart-item clearfix" runat="server" id="dvOlcuAdi" visible="false">
                        <div class="cart-item-desc">
                            <div class="desc-title">
                                <span class="desc-title">Ölçü : <asp:Label ID="sepetOlcuAdi" runat="server" Text=""/></span>
                            </div>
                        </div>
                    </div>
                    <div class="cart-item clearfix" runat="server" id="dvPaketAdi" visible="false">
                        <div class="cart-item-desc">
                            <div class="desc-title">
                                <asp:Label CssClass="d-block" ID="sepetPaketAdi" runat="server" Text=""/>
                            </div>
                            <div class="cart-qty-price">
                                <span class="cart-item-price">
                                    <div class="quantity">
                                    </div>
                                </span>
                                <span class="cart-item-quantity">
                                    <asp:Label CssClass="iscfyt" ID="sepetPaketFiyat1" ForeColor="red" runat="server" Text=""/>
                                    <asp:Label CssClass="extra-price" ID="sepetPaketFiyat2" ForeColor="green" runat="server" Text=""/>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="cart-item clearfix" runat="server" id="dvKapakAdi" visible="false">
                        <div class="cart-item-desc">
                            <div class="desc-title">
                                <span class="fleft">Kapak : <asp:Label CssClass="" ID="sepetKapakAdi" runat="server" Text=""/></span>
                            </div>
                        </div>
                    </div>
                    <div class="cart-item clearfix" runat="server" id="dvKumasAdi" visible="false">
                        <div class="cart-item-desc">
                            <div class="desc-title">
                                <span class="fleft">Kumaş : <asp:Label CssClass="" ID="sepetKumasAdi" runat="server" Text=""/></span>
                            </div>
                        </div>
                    </div>
                    <div class="cart-item clearfix" runat="server" id="dvAhsapAdi" visible="false">
                        <div class="cart-item-desc">
                            <div class="desc-title">
                                <span class="fleft">Ahşap : <asp:Label CssClass="" ID="sepetAhsapAdi" runat="server" Text=""/></span>
                            </div>
                        </div>
                    </div>
                    <asp:Panel CssClass="cart-item" ID="pnlEkstraAdi" runat="server" Visible="false">
                        <asp:Repeater ID="rptEkstraAdi" runat="server" OnItemCommand="ekstraSecCart">
                            <ItemTemplate>
                                <div class="cart-item clearfix">
                                    <div class="cart-item-desc">
                                        <div class="desc-title">
                                            <span style="display: block"><%#Eval("ordercartekstra_ekstraadi") %></span>
                                        </div>
                                        <div class="cart-qty-price">
                                            <span class="cart-item-price">
                                                <div class="quantity">
                                                    <asp:LinkButton ID="lnlEkstraSilCart" runat="server" CssClass="cart-minus fa fa-minus" CommandName="ekstraSilCart" CommandArgument='<%#Eval("ordercartekstra_ekstraid") %>'/>
                                                    <asp:LinkButton ID="lblEkstraSayiCart" CssClass="cart-qty" Enabled="False" runat="server" Text='<%#Eval("ordercartekstra_adet") %>'/>
                                                    <asp:LinkButton ID="lblEkstraEkleCart" CssClass="cart-plus fa fa-plus" runat="server" CommandName="ekstraEkleCart" CommandArgument='<%#Eval("ordercartekstra_ekstraid") %>'/>
                                                </div>
                                            </span>
                                            <span class="cart-item-quantity">
                                                <span class="iscfyt" id="iFiyat"><%#ekstraFiyatKarsilastir(Eval("ordercartekstra_nfiyat").ToString(), Eval("ordercartekstra_ifiyat").ToString()) %></span>
                                                <span id="nFiyat" class="extra-price" style="color: green"><%#Convert.ToDouble(Eval("ordercartekstra_ifiyat")).ToString("N") %>&nbsp;<i class="fa fa-try"></i></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                </div>
                <div class="cart-action clearfix">
                    <span style="font-weight: bold" class="checkout-price fright"></span>
                    <%-- <i class="fa fa-try checkout-price fright" style="font-size: 22px;"></i> --%>
                </div>
            </div>
        </div>
    </div>
</div>
</div>
</div>
</div><!-- .container end -->


<!-- Modal -->
<div class="modal fade in" id="kapakModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl modal-dialog-centered">
        <div class="modal-content">
            <div class="modal-header align-items-center">
                <div class="col-4">
                    <h2 class="modal-title" id="kapakModalSablonLink">
                        <a href="" runat="server" id="lblModalKapakSablon">Şablon İndir</a>
                    </h2>
                </div>
                <div class="col-4">
                    <h2 class="modal-title text-center" ID="lblModalKapakAdi" runat="server"></h2>
                </div>
                <div class="col-4">
                    <i role="button" class="close" data-dismiss="modal" aria-label="Close">&times;</i>
                </div>
            </div>
            <div class="modal-body p-0">
                <div class="custCarousel">
                    <div id="custCarousel" class="carousel slide" data-ride="carousel">
                        <div class="carousel-inner" data-interval="2000">
                            <asp:Repeater ID="rptKapakModal" runat="server">
                                <ItemTemplate>
                                    <div class="carousel-item">
                                        <img src="/images/nurun/<%#Eval("nurunimage_path") %>" class="w-100 h-75" style="max-height: 700px" alt="<%#Eval("nurunimage_path") %>">
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <button class="carousel-control-prev" data-target="#custCarousel" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </button>
                        <button class="carousel-control-next" data-target="#custCarousel" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </button>
                        <ol class="carousel-indicators list-inline">
                            <asp:Repeater ID="rptKapakModal2" runat="server">
                                <ItemTemplate>
                                    <li data-target="#custCarousel" data-slide-to="<%# Container.ItemIndex %>" class="list-inline-item active">
                                        <img src="/images/nurun/<%#Eval("nurunimage_path") %>" class="d-block w-50 h-50" alt="<%#Eval("nurunimage_path") %>">
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ol>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</section>
</ContentTemplate>
</asp:UpdatePanel>

<asp:UpdateProgress ID="UpdateProgress1" runat="server">
    <ProgressTemplate>
        <uc2:updateProgress runat="server" ID="updateProgress"/>
    </ProgressTemplate>
</asp:UpdateProgress>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="contentBottom" runat="Server">
    <script src="/bootstrap/js/bootstrap.bundle.js" type="text/javascript"></script>
    <script src="/bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script src="/order.js"></script>
    <script >
            $(document).ready(function (){
                console.log("değişti")
                var totalPrice;
                $(".extra-price").each(function (){
                    totalPrice += this.textContent
                })
                $(".checkout-price").innerText = totalPrice
            })
    var parameter = Sys.WebForms.PageRequestManager.getInstance();
    parameter.add_endRequest(async function () {
            $(document).ready(function (){
                console.log("değişti")
                var totalPrice;
                $(".extra-price").each(function (){
                    totalPrice += this.textContent
                })
                $(".checkout-price").innerHTML =`${totalPrice},00 <i class="fa fa-try"></i>`
            })
    })
    </script>
</asp:Content>