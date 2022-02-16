<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="siparisnew.aspx.cs" Inherits="siparisnew"%>

<%@ Register Src="~/memberRightBar.ascx" TagPrefix="uc1" TagName="memberRightBar"%>
<%@ Register Src="~/updateProgress.ascx" TagPrefix="uc2" TagName="updateProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" Runat="Server">




        <link rel="stylesheet" href="/css/customizer/pages.css">
        <link rel="stylesheet" href="/css/customizer/shop-pages-customizer.css">
        <link href="/css/costum.css" rel="stylesheet" />


<%--        <script type="text/javascript">

        function fade(divId) {
            $(document).ready(function () {            
                $("#" + divId).fadeToggle(0);
        })
        }

        function fadeOUT(divId) {
            $(document).ready(function () {
                $("#" + divId).fadeOut(500);
            })
        }

</script>--%>

        <script type="text/javascript">
            var scrollToAnchor = function (id) {

                // grab the element to scroll to based on the name
                var elem = $("a[name='" + id + "']");

                // if that didn't work, look for an element with our ID
                if (typeof (elem.offset()) === "undefined") {
                    elem = $("#" + id);
                }

                // if the destination element exists
                if (typeof (elem.offset()) !== "undefined") {

                    // do the scroll
                    $('html, body').animate({
                        scrollTop: elem.offset().top
                    }, 1000);

                }
            };

            // bind to click event
            function moveTo(moveID) {
                $(document).ready(function() {
                    var href = $(moveID);
                    scrollToAnchor(moveID);
                });
            }

        </script>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" Runat="Server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="breadcrumb-box">
  <div class="container">
    <ul class="breadcrumb">
      <li><asp:HyperLink ID="hyperBroadHome" runat="server"><asp:Literal ID="litBreadAnaSayfa" runat="server" Text=" <%$Resources:strings, loginBread2 %>"></asp:Literal></asp:HyperLink></li>
      <li class="active"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisVerBaslik %>"></asp:Literal></li>
    </ul>	
  </div>
</div><!-- .breadcrumb-box -->

<section id="main" class="page">

  <div class="container">
    <div class="row">
      <article class="col-sm-9 col-md-9 content">
		<div class="my-account">

                      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

<%--                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
            <asp:Panel ID="pnlOlculer" runat="server">


            <asp:Repeater ID="rptGoldSeri" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisGoldSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisGoldSeriOlcuList %>"></asp:Literal></strong></h2>
                                    </div>
<%--                        <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisKampanyaliSeriOlcuList %>"></asp:Literal></h1>
                        </div>        --%>               
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">

<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-warning btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                                
                                
                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>




            <asp:Repeater ID="rptYeniKampanyali" runat="server" OnItemCommand="paketGetir">

                <HeaderTemplate>
                    <div class="clearfix"></div>
                    <div class="title-box">
                        <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisYeniKampanliOlcuList" runat="server" Text=" <%$Resources:strings, siparisYeniKampanyaliOlcuList %>"></asp:Literal></strong></h2>
                    </div>
                    <%-- <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisMasterSeriOlcuList %>"></asp:Literal></h1>
                        </div>   --%>                    
                    <div class="row list-images no-responsive">   
                </HeaderTemplate>

                <ItemTemplate>

                    <div class="col-sm-4 col-md-3 siparisimgMarg">


                        <%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-red btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                  


                    </div>

                </ItemTemplate>

                <FooterTemplate>
                </div>
                </FooterTemplate>
            </asp:Repeater>    
			

            <asp:Repeater ID="rptEkoKampanyali" runat="server" OnItemCommand="paketGetir">

                <HeaderTemplate>
                    <div class="clearfix"></div>
                    <div class="title-box">
                        <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisYeniKampanliOlcuList" runat="server" Text=" <%$Resources:strings, siparisEkoKampanyaliOlcuList %>"></asp:Literal></strong></h2>
                    </div>
                    <%-- <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisMasterSeriOlcuList %>"></asp:Literal></h1>
                        </div>   --%>                    
                    <div class="row list-images no-responsive">   
                </HeaderTemplate>

                <ItemTemplate>

                    <div class="col-sm-4 col-md-3 siparisimgMarg">


                        <%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-olive-cs btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                  


                    </div>

                </ItemTemplate>

                <FooterTemplate>
                </div>
                </FooterTemplate>
            </asp:Repeater>     

            
            <asp:Repeater ID="rptSTDSeries" runat="server" OnItemCommand="paketGetir">

                <HeaderTemplate>
                    <div class="clearfix"></div>
                    <div class="title-box">
                        <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisSTDOlcuList" runat="server" Text=" <%$Resources:strings, siparisSTDSeriOlcuList %>"></asp:Literal></strong></h2>
                    </div>
                    <%-- <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisMasterSeriOlcuList %>"></asp:Literal></h1>
                        </div>   --%>                    
                    <div class="row list-images no-responsive">   
                </HeaderTemplate>

                <ItemTemplate>

                    <div class="col-sm-4 col-md-3 siparisimgMarg">


                        <%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-savethedate btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                  


                    </div>

                </ItemTemplate>

                <FooterTemplate>
                </div>
                </FooterTemplate>
            </asp:Repeater>     
            
            <asp:Repeater ID="rptVintageSeri" runat="server" OnItemCommand="paketGetir">

                <HeaderTemplate>
                    <div class="clearfix"></div>
                    <div class="title-box">
                        <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisSTDOlcuList" runat="server" Text=" <%$Resources:strings, siparisVintageSeriOlcuList %>"></asp:Literal></strong></h2>
                    </div>
                    <%-- <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisMasterSeriOlcuList %>"></asp:Literal></h1>
                        </div>   --%>                    
                    <div class="row list-images no-responsive">   
                </HeaderTemplate>

                <ItemTemplate>

                    <div class="col-sm-4 col-md-3 siparisimgMarg">


                        <%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-warning btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                  


                    </div>

                </ItemTemplate>

                <FooterTemplate>
                </div>
                </FooterTemplate>
            </asp:Repeater>  
                
                
                            <asp:Repeater ID="rpyp19Seri" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litssiparisPremiumSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisyenipremium19olculist %>"></asp:Literal></strong></h2>
                                    </div>
<%--                        <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisPremiumSeriOlcuList %>"></asp:Literal></h1>
                        </div>        --%>               
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">

<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-danger btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                                
                                
                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>                               
            
                            <asp:Repeater ID="rptPremiumSeri" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litssiparisPremiumSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisPremiumSeriOlcuList %>"></asp:Literal></strong></h2>
                                    </div>
<%--                        <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisPremiumSeriOlcuList %>"></asp:Literal></h1>
                        </div>        --%>               
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">

<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-default btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                                
                                
                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
  
            
            <asp:Repeater ID="rptBabyKidsSerisi" runat="server" OnItemCommand="paketGetir">

                <HeaderTemplate>
                    <div class="clearfix"></div>
                    <div class="title-box">
                        <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisBKBeniusOlcuList" runat="server" Text=" <%$Resources:strings, siparisBabyKidsBeniusOlcuList %>"></asp:Literal></strong></h2>
                    </div>
                    <%-- <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisMasterSeriOlcuList %>"></asp:Literal></h1>
                        </div>   --%>                    
                    <div class="row list-images no-responsive">   
                </HeaderTemplate>

                <ItemTemplate>

                    <div class="col-sm-4 col-md-3 siparisimgMarg">


                        <%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-olive-cs btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                  


                    </div>

                </ItemTemplate>

                <FooterTemplate>
                </div>
                </FooterTemplate>
            </asp:Repeater>   





                <asp:Repeater ID="rptPremiumPlusSeri" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisPremiumPlusSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisPremiumPlusSeriOlcuList %>"></asp:Literal></strong></h2>
                                    </div>

<%--                        <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisPremiumPlusSeriOlcuList %>"></asp:Literal></h1>
                        </div>     --%>                  
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">

<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-default btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                                 
                                
                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>




            <asp:Repeater ID="rptTekAlbumKampanyali" runat="server" OnItemCommand="paketGetir">

                <HeaderTemplate>
                    <div class="clearfix"></div>
                    <div class="title-box">
                        <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisTAKSOlcuList" runat="server" Text=" <%$Resources:strings, siparisTekAlbumKaOlcuList %>"></asp:Literal></strong></h2>
                    </div>
                    <%-- <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisMasterSeriOlcuList %>"></asp:Literal></h1>
                        </div>   --%>                    
                    <div class="row list-images no-responsive">   
                </HeaderTemplate>

                <ItemTemplate>

                    <div class="col-sm-4 col-md-3 siparisimgMarg">


                        <%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-magenta-cs btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                  


                    </div>

                </ItemTemplate>

                <FooterTemplate>
                </div>
                </FooterTemplate>
            </asp:Repeater>   

                <asp:Repeater ID="rptKristalPlusSeri" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisKristalPlusSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisKristalPlusSeriOlcuList %>"></asp:Literal></strong></h2>
                                    </div>
<%--                        <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisKristalSeriOlcuList %>"></asp:Literal></h1>
                        </div>     --%>                  
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">

<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-inverse btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                                   
                                
                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>


                <asp:Repeater ID="rptMasterSeri" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisMasterSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisMasterSeriOlcuList %>"></asp:Literal></strong></h2>
                                    </div>
                       <%-- <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisMasterSeriOlcuList %>"></asp:Literal></h1>
                        </div>   --%>                    
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">


<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-primary btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                  


                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>



                <asp:Repeater ID="rptKristalSeri" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisKristalSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisKristalSeriOlcuList %>"></asp:Literal></strong></h2>
                                    </div>
<%--                        <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisKristalSeriOlcuList %>"></asp:Literal></h1>
                        </div>     --%>                  
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">

<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-success btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                                  
                                
                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rptStandartSeri" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisStandartSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisStandartSeriOlcuList %>"></asp:Literal></strong></h2>
                                    </div>
<%--                        <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisStandartSeriOlcuList %>"></asp:Literal></h1>
                        </div>      --%>                 
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">

<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-warning btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                                   
                                
                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rptKampanyaliSeri" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisKampanyaliSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisKampanyaliSeriOlcuList %>"></asp:Literal></strong></h2>
                                    </div>
<%--                        <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisKampanyaliSeriOlcuList %>"></asp:Literal></h1>
                        </div>        --%>               
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">

<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-danger btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                                
                                
                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rptJumbo" runat="server" OnItemCommand="paketGetir">

                    <HeaderTemplate>
                        <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisJumboSeriOlcuList" runat="server" Text=" <%$Resources:strings, siparisJumboSeriOlcuList %>"></asp:Literal></strong></h2>
                                    </div>

<%--                        <div class="row">
                           <h1 style="text-align:center"><asp:Literal ID="litBreadLogin" runat="server" Text=" <%$Resources:strings, siparisPremiumPlusSeriOlcuList %>"></asp:Literal></h1>
                        </div>     --%>                  
                        <div class="row list-images no-responsive">   
                    </HeaderTemplate>

                    <ItemTemplate>

                            <div class="col-sm-4 col-md-3 siparisimgMarg">

<%--                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# string.Format("~/images/olcufotograf/{0}",Eval("paketolcu_fotograf"))%>'  Height="175" Width="175" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="imageborderer"/>         --%>  
                                
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="paketGoster" CommandArgument='<%#Eval("paketolcu_id")%>' CssClass="btn btn-lg btn-default btn-block"><%#Eval("paketolcu_ebat") %><br /><%#Eval("paketolcu_maciklama") %> </asp:LinkButton>                                 
                                
                            </div>

                    </ItemTemplate>

                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>

                </asp:Panel>

                <asp:Panel ID="pnlPaketler" runat="server">

                    <asp:Repeater ID="rptPaketler" runat="server" OnItemCommand="paketSec">
                        <HeaderTemplate>
                            <div class="clearfix"></div>
                                    <div class="title-box" id="paketler">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparissiparisOlcuyeUygun" runat="server" Text=" <%$Resources:strings, siparisOlcuyeUygun %>"></asp:Literal></strong></h2>
                                    </div>
                        </HeaderTemplate>

                        <ItemTemplate>

                                <div class="row">

                                     <div class="col-sm-12 col-md-12">
                                         <p><strong><%# GetGlobalResourceObject("strings", Eval("paket_languageStr").ToString()) %></strong></p>
                                         </div>
                                     <div class="col-sm-6 col-md-6">

                                        <asp:ImageButton ID="imageBtnPaketList" runat="server" ImageUrl='<%# string.Format("~/images/paketfotolar/{0}",Eval("paket_fotonew"))%>' CommandName="paketSec" CommandArgument='<%#Eval("paket_id")%>'/>                  

                                </div>
                                     <div class="col-sm-6 col-md-6">


                                         <%# paketAltGetir(Convert.ToInt32(Eval("paket_id"))) %>

<%--                                                 <ul>
                                                    <li><strong>1 Adet 35x65 Premium Plus Albüm<strong></li>
                                                    <li><strong>2 Adet Aile Albümü<strong></li>
                                                    <li><strong>1 Adet Cep<strong></li>
                                                    <li><strong>1 Adet 50x60 veya 50x75<strong></li>
                                                 </ul>--%>
                                     </div>

                                    <div class="col-sm-12 col-md-12">
                                        <p style="text-align:right">
                                            
                                            <%# fiyatlar.fiyatBul.paketFiyat(Convert.ToInt32(Eval("paket_id")), Convert.ToInt32(musteriID),Eval("currency_simge").ToString(), 0) %>
                                            
                                            
                                            <%--<asp:Literal ID="litPaketFiyat" runat="server" Text=" <%$Resources:strings, siparisPaketFiyat %>"></asp:Literal> <%#Convert.ToDouble(Eval("paket_fiyat")).ToString("N") %> <%# paraBirimi = Eval("currency_simge").ToString() %>--%> <div style="display:none"><%# paraBirimi = Eval("currency_simge").ToString() %><%# seciliBolge = Convert.ToInt32(Eval("bolge_id")) %> </div></p>
                                        </div>

                                    <div class="col-sm-12 col-md-12">
                                        <p style="text-align:center">

                                            <asp:LinkButton ID="linkBtnPaketSec" runat="server" Text="<%$Resources:strings, siparisPaketSecBtn %>" CommandName="paketSec" CommandArgument='<%#Eval("paket_id")%>'></asp:LinkButton>

                                        </p>
                                        </div>

                                </div>

                        </ItemTemplate>

                        <FooterTemplate>

                        </FooterTemplate>
                        <SeparatorTemplate><hr class="hrSiparis"></SeparatorTemplate>

                    </asp:Repeater>

                </asp:Panel>


                <asp:Panel ID="pnlKapaklar" runat="server">

                    <div class="col-sm-12 col-md-12">

                    <asp:Repeater ID="rptKapakNormal" runat="server" OnItemCommand="kapakSec">

                        <HeaderTemplate>
                            <div class="clearfix"></div>
                                    <div class="title-box" id="kapakNormal">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisPaketinKapaklari" runat="server" Text=" <%$Resources:strings, siparisPaketinKapaklari %>"></asp:Literal></strong></h2>
                                    </div>

                            <div class="row">
                        </HeaderTemplate>

                        <ItemTemplate>

                            <%#premiumPlusFoto(Convert.ToInt32(Eval("id"))) %>
                            
                            <div class="col-sm-4 col-md-4 text-center siparisimgMarg2">
                                <a class="gallery-images" rel="fancybox" href="/images/urunler/<%#imageBigger(Eval("image_path").ToString()) %>">
                                <img src="/images/urunler/<%#Eval("image_path") %>" alt="<%#Eval("ad") %>" width="216" height="238" />
                                <p class="siparisMargTop"><%#Eval("ad") %></p></a>

                                <p class="siparisMargTop"><strong><asp:LinkButton ID="linkBtnKapakEkle" runat="server" Text="<%$Resources:strings, siparisKapakEkle %>" CommandName="kapakSec" CommandArgument='<%#Eval("id")%>'></asp:LinkButton></strong><span style="text-align:right"><%#kapakDownload(Convert.ToInt32(Eval("id"))) %></span> </p>
                            </div>

                        </ItemTemplate>

                        <FooterTemplate>
                            </div>
                        </FooterTemplate>

                    </asp:Repeater>


                    <asp:Repeater ID="rptKapakYatay" runat="server" OnItemCommand="kapakSec">

                        <HeaderTemplate>
                            <div class="clearfix"></div>
                                    <div class="title-box" id="kapakYatay">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisPaketinKapaklari" runat="server" Text=" <%$Resources:strings, siparisPaketinKapaklari %>"></asp:Literal></strong></h2>
                                    </div>
                            <div class="row">
                        </HeaderTemplate>

                        <ItemTemplate>
                            
                            <%#premiumPlusFoto(Convert.ToInt32(Eval("id"))) %>
                            
                            <div class="col-sm-6 col-md-6 text-center siparisimgMargYatay">
                                <a class="gallery-images" rel="fancybox" href="/images/urunler/<%#imageBigger(Eval("image_path").ToString()) %>">
                                <img src="/images/urunler/<%#Eval("image_path") %>" alt="<%#Eval("ad") %>" width="339" height="209" />
                                <p class="siparisMargTop"><%#Eval("ad") %></p></a>

                                <p class="siparisMargTop"><strong><asp:LinkButton ID="linkBtnKapakEkle" runat="server" Text="<%$Resources:strings, siparisKapakEkle %>" CommandName="kapakSec" CommandArgument='<%#Eval("id")%>'></asp:LinkButton></strong><span style="text-align:right"><%#kapakDownload(Convert.ToInt32(Eval("id"))) %></span> </p>
                            </div>

                        </ItemTemplate>

                        <FooterTemplate>
                            </div>
                        </FooterTemplate>

                    </asp:Repeater>


                    <asp:Repeater ID="rptKapakDikey" runat="server" OnItemCommand="kapakSec">

                        <HeaderTemplate>
                            <div class="clearfix"></div>
                                    <div class="title-box" id="kapakDikey">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisPaketinKapaklari" runat="server" Text=" <%$Resources:strings, siparisPaketinKapaklari %>"></asp:Literal></strong></h2>
                                    </div>
                            <div class="row">
                        </HeaderTemplate>

                        <ItemTemplate>
                            
                            <div class="col-sm-6 col-md-6 text-center siparisimgMargYatay">
                                <a class="gallery-images" rel="fancybox" href="/images/urunler/<%#imageBigger(Eval("image_path").ToString()) %>">
                                <img src="/images/urunler/<%#Eval("image_path") %>" alt="<%#Eval("ad") %>" width="216" height="456" />
                                <p class="siparisMargTop"><%#Eval("ad") %></p></a>

                                <p class="siparisMargTop"><strong><asp:LinkButton ID="linkBtnKapakEkle" runat="server" Text="<%$Resources:strings, siparisKapakEkle %>" CommandName="kapakSec" CommandArgument='<%#Eval("id")%>'></asp:LinkButton></strong><span style="text-align:right"><%#kapakDownload(Convert.ToInt32(Eval("id"))) %></span> </p>
                            </div>

                        </ItemTemplate>

                        <FooterTemplate>
                            </div>
                        </FooterTemplate>

                    </asp:Repeater>



                        </div>

                </asp:Panel>

                <div class="clearfix"></div>

                <asp:Panel ID="pnlForm" runat="server" Visible="false" DefaultButton="btnFormuGonder">

                                    <div class="title-box" id="musteriFormSecimler">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litsiparisBilgilerForm" runat="server" Text=" <%$Resources:strings, siparisBilgilerForm %>"></asp:Literal></strong></h2>
                                    </div>                                   

                    <div id="musteriForm" runat="server" visible="true" class="form-horizontal">


                            <div class="form-group">
                              <label for="drpSayfaTipi" class="col-sm-2 control-label"><asp:Literal ID="litSayfaTipi" runat="server" Text=" <%$Resources:strings, siparisSayfaTipi %>"></asp:Literal></label>
                              <div class="col-sm-10">
	                            <asp:DropDownList ID="drpSayfaTipi" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="input-lg form-control"></asp:DropDownList>   
                              </div>
                            </div>

                            <div class="form-group">
                              <label for="drpYaprakSayisi" class="col-sm-2 control-label"><asp:Literal ID="Literal1" runat="server" Text=" <%$Resources:strings, siparisYaprakSayisi %>"></asp:Literal></label>
                              <div class="col-sm-10">
	                            <asp:DropDownList ID="drpYaprakSayisi" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="input-lg form-control"></asp:DropDownList>
                              </div>
                            </div>

                            <div class="form-group">
                              <label for="litCalismaSekli" class="col-sm-2 control-label"><asp:Literal ID="litCalismaSekli" runat="server" Text=" <%$Resources:strings, siparisCalismaSekli %>"></asp:Literal></label>
                              <div class="col-sm-10">
	                                <asp:RadioButton id="calisma1" runat="server" GroupName="calismaSekliGrup" CssClass="radio" Text="<%$Resources:strings, siparisCalismaSekliSecim1 %>"></asp:RadioButton>
                                    <asp:RadioButton id="calisma2" runat="server" GroupName="calismaSekliGrup" CssClass="radio" Text="<%$Resources:strings, siparisCalismaSekliSecim2 %>"></asp:RadioButton>
                              </div>
                            </div>


                            <div class="form-group">
                              <label for="txtBuyukEbat" class="col-sm-2 control-label"><asp:Literal ID="Literal2" runat="server" Text=" <%$Resources:strings, siparisBuyukEbat %>"></asp:Literal></label>
                              <div class="col-sm-10">
	                            <asp:TextBox ID="txtBuyukEbat" runat="server" CssClass="input-lg form-control"></asp:TextBox>
                                  <asp:Literal ID="Literal3" runat="server" Text=" <%$Resources:strings, siparisBuyukEbat2 %>"></asp:Literal>
                              </div>
                            </div>

                            <div class="form-group">
                              <label for="litAhsapSec" class="col-sm-2 control-label"><asp:Literal ID="Literal888" runat="server" Text=" <%$Resources:strings, siparisAhsapTipiSec %>"></asp:Literal></label>
                              <div class="col-sm-10">
	                              <asp:RadioButton id="ahsap0" runat="server" GroupName="ahsapGrup" CssClass="radio" Text="" Visible="true" Checked="true"></asp:RadioButton>
                                  <asp:RadioButton id="ahsap1" runat="server" GroupName="ahsapGrup" CssClass="radio" Text="" Visible="true" Enabled="false"></asp:RadioButton>
                                  <asp:RadioButton id="ahsap2" runat="server" GroupName="ahsapGrup" CssClass="radio" Text="" Visible="true" Enabled="false"></asp:RadioButton>
                                  <asp:RadioButton id="ahsap3" runat="server" GroupName="ahsapGrup" CssClass="radio" Text="" Visible="true" Enabled="false"></asp:RadioButton>
                              </div>
                            </div>

                            <div class="form-group">
                              <label for="txtKapakYazisi" class="col-sm-2 control-label"><asp:Literal ID="Literal4" runat="server" Text=" <%$Resources:strings, siparisKapakYazisi %>"></asp:Literal></label>
                              <div class="col-sm-10">
	                            <asp:TextBox ID="txtKapakYazisi" runat="server" CssClass="input-lg form-control"></asp:TextBox>
                                  <asp:Literal ID="Literal5" runat="server" Text=" <%$Resources:strings, siparisKapakYazisi2 %>"></asp:Literal>
                              </div>
                            </div>

<%--                        <div class="alert alert-info">
			              <strong>ÇANTA SEÇENEKLERİ</strong>
			            </div>--%>


                           <div class="form-group">
                              <label for="litKagitSec" class="col-sm-2 control-label"><asp:Literal ID="Literal16" runat="server" Text=" <%$Resources:strings, siparisKagitTipi %>"></asp:Literal></label>
                              <div class="col-sm-10">
	                              <asp:RadioButton id="kagit1" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit2" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit3" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit5" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit6" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit7" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit8" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit9" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit10" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit11" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit12" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit13" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit14" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit15" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                                  <asp:RadioButton id="kagit16" runat="server" GroupName="kagitGrup" CssClass="radio" Text="" Visible="false"></asp:RadioButton>
                              </div>
                            </div>



                        <asp:Repeater ID="rptSaatler" runat="server" OnItemCommand="saatSec">
                            <HeaderTemplate>
                                <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litSaatSecenekleri" runat="server" Text=" <%$Resources:strings, siparisSaatSecenekleri %>"></asp:Literal></strong></h2>
                                    </div>
                            </HeaderTemplate>

                            <ItemTemplate>

                        <div class="row">

                             <div class="col-sm-8 col-md-8">
                                 <p><strong><%#Eval("paketextra_adi")%></strong> (<%# fiyatlar.fiyatBul.paketExtraFiyat(paketNo, Convert.ToInt32(Eval("paketextra_id")), Convert.ToInt32(musteriID), paraBirimi.ToString(), 0) %>)<br></br>
                                <span><%#Eval("paketextra_aciklama") %></span></p>
                                 <p class="text-center"><strong><asp:LinkButton ID="linkBtnSaatEkle" runat="server" Text="<%$Resources:strings, siparisEkleBtnGenel %>" CommandName="saatEkle" CommandArgument='<%#Eval("paketextra_id")%>'></asp:LinkButton></strong></p>

                             </div>

                             <div class="col-sm-4 col-md-4">
                                 <img src="/images/paketextra/<%#Eval("paketextra_image") %>" />
                             </div>

                        </div>

                            </ItemTemplate>

                            <SeparatorTemplate>
                                <hr>
                            </SeparatorTemplate>


                        </asp:Repeater>

                        <asp:Repeater ID="rptCantalar" runat="server" OnItemCommand="cantaSec">
                            <HeaderTemplate>
                                <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litCantaSecenekleri" runat="server" Text=" <%$Resources:strings, siparisCantaSecenekleri %>"></asp:Literal></strong></h2>
                                    </div>
                            </HeaderTemplate>

                            <ItemTemplate>

                        <div class="row">

                             <div class="col-sm-8 col-md-8">
                                 <p><strong><%#Eval("paketextra_adi")%></strong> (<%# fiyatlar.fiyatBul.paketExtraFiyat(paketNo, Convert.ToInt32(Eval("paketextra_id")), Convert.ToInt32(musteriID), paraBirimi.ToString(), 0) %>)<br></br>
                                <span><%#Eval("paketextra_aciklama") %></span></p>
                                 <p class="text-center"><strong><asp:LinkButton ID="linkBtnCantaEkle" runat="server" Text="<%$Resources:strings, siparisEkleBtnGenel %>" CommandName="cantaEkle" CommandArgument='<%#Eval("paketextra_id")%>'></asp:LinkButton></strong></p>

                             </div>

                             <div class="col-sm-4 col-md-4">
                                 <img src="/images/paketextra/<%#Eval("paketextra_image") %>" />
                             </div>

                        </div>

                            </ItemTemplate>

                            <SeparatorTemplate>
                                <hr>
                            </SeparatorTemplate>

                        </asp:Repeater>

                        <asp:Repeater ID="rptAile" runat="server" OnItemCommand="aileSec">
                            <HeaderTemplate>
                                <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litAileSecenekleri" runat="server" Text=" <%$Resources:strings, siparisAileSecenekleri %>"></asp:Literal></strong></h2>
                                    </div>
                            </HeaderTemplate>

                            <ItemTemplate>

                        <div class="row">

                             <div class="col-sm-8 col-md-8">
                                 <p><strong><%#Eval("paketextra_adi")%></strong> (<%# fiyatlar.fiyatBul.paketExtraFiyat(paketNo, Convert.ToInt32(Eval("paketextra_id")), Convert.ToInt32(musteriID), paraBirimi.ToString(), 0) %>)<br></br>
                                <span><%#Eval("paketextra_aciklama") %></span></p>
                                 <p class="text-center"><strong><asp:LinkButton ID="linkBtnAileEkle" runat="server" Text="<%$Resources:strings, siparisEkleBtnGenel %>" CommandName="aileEkle" CommandArgument='<%#Eval("paketextra_id")%>'></asp:LinkButton></strong></p>

                             </div>

                             <div class="col-sm-4 col-md-4">
                                 <img src="/images/paketextra/<%#Eval("paketextra_image") %>" />
                             </div>

                        </div>

                            </ItemTemplate>

                            <SeparatorTemplate>
                                <hr>
                            </SeparatorTemplate>

                        </asp:Repeater>

                        <asp:Repeater ID="rptCep" runat="server" OnItemCommand="cepSec">
                            <HeaderTemplate>
                                <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litCepSecenekleri" runat="server" Text=" <%$Resources:strings, siparisCepSecenekleri %>"></asp:Literal></strong></h2>
                                    </div>
                            </HeaderTemplate>

                            <ItemTemplate>

                        <div class="row">

                             <div class="col-sm-8 col-md-8">
                                 <p><strong><%#Eval("paketextra_adi")%></strong> (<%# fiyatlar.fiyatBul.paketExtraFiyat(paketNo, Convert.ToInt32(Eval("paketextra_id")), Convert.ToInt32(musteriID), paraBirimi.ToString(), 0) %>)<br></br>
                                <span><%#Eval("paketextra_aciklama") %></span></p>
                                 <p class="text-center"><strong><asp:LinkButton ID="linkBtnCepEkle" runat="server" Text="<%$Resources:strings, siparisEkleBtnGenel %>" CommandName="cepEkle" CommandArgument='<%#Eval("paketextra_id")%>'></asp:LinkButton></strong></p>

                             </div>

                             <div class="col-sm-4 col-md-4">
                                 <img src="/images/paketextra/<%#Eval("paketextra_image") %>" />
                             </div>

                        </div>

                            </ItemTemplate>

                            <SeparatorTemplate>
                                <hr>
                            </SeparatorTemplate>

                        </asp:Repeater>

                        <asp:Repeater ID="rptBuyuk" runat="server" OnItemCommand="buyukSec">
                            <HeaderTemplate>
                                <div class="clearfix"></div>
                                    <div class="title-box">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="litBuyukSecenekleri" runat="server" Text=" <%$Resources:strings, siparisBuyukSecenekleri %>"></asp:Literal></strong></h2>
                                    </div>
                            </HeaderTemplate>

                            <ItemTemplate>

                        <div class="row">

                             <div class="col-sm-8 col-md-8">
                                 <p><strong><%#Eval("paketextra_adi")%></strong> (<%# fiyatlar.fiyatBul.paketExtraFiyat(paketNo, Convert.ToInt32(Eval("paketextra_id")), Convert.ToInt32(musteriID), paraBirimi.ToString(), 0) %>)<br></br>
                                <span><%#Eval("paketextra_aciklama") %></span></p>
                                 <p class="text-center"><strong><asp:LinkButton ID="linkBtnBuyukEkle" runat="server" Text="<%$Resources:strings, siparisEkleBtnGenel %>" CommandName="buyukEkle" CommandArgument='<%#Eval("paketextra_id")%>'></asp:LinkButton></strong></p>

                             </div>

                             <div class="col-sm-4 col-md-4">
                                 <img src="/images/paketextra/<%#Eval("paketextra_image") %>" />
                             </div>

                        </div>

                            </ItemTemplate>

                            <SeparatorTemplate>
                                <hr>
                            </SeparatorTemplate>

                        </asp:Repeater>







<%--                        <div class="row">

                             <div class="col-sm-8 col-md-8">
                                 <p>35x65 Standart Kutu (60,00 TL)</br>
                                 Seçilen Albümün Renklerine Uygun Olarak Sunulan Kutudur. İstenildiği Takdirde Dekor Kutu Özelliği Seçilebilir</p>
                                 <p class="text-center"><a href="/">Siparişe Ekle</a></p>

                             </div>

                             <div class="col-sm-4 col-md-4">
                                 <img src="http://www.mertalbum.com/images/paketextra/standart-kutu.png" />
                             </div>

                        </div>--%>
                            



                        <div class="margin-top-30 clearfix">
                            <div class="form-group">
                              <label for="txtMusteriNotu" class="col-sm-2 control-label"><asp:Literal ID="litMusteriNote" runat="server" Text="<%$Resources:strings, siparisMusteriNotu %>"></asp:Literal></label>
                              <div class="col-sm-10">
	                            <asp:TextBox ID="txtMusteriNotu" runat="server" CssClass="input-lg form-control" TextMode="MultiLine"></asp:TextBox>                                  
                              </div>
                            </div>
                        </div>
                            
                        
                            <div class="form-group">
                              <div class="col-sm-offset-2 col-sm-10">
                                  <asp:Button ID="btnFormuGonder" runat="server" Text="<%$Resources:strings, siparisFormuGonder %>" CssClass="btn btn-default" OnClick="btnFormuGonder_Click" />                                   
                              </div>
                            </div>

                         

                    </div>






                </asp:Panel>


                <div class="clearfix"></div>

                <asp:Panel ID="pnlSepet" runat="server" Visible="false">
                    
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

				              <tr>
					            <td>

                                    <div class="form-group">
                                      <div class="col-sm-offset-2 col-sm-10">
                                          <asp:Button ID="Button1" runat="server" Text="<%$Resources:strings, siparisFinalBtnGeri %>" CssClass="btn btn-danger" OnClick="btnSiparisDuzelt_Click" />                                   
                                      </div>
                                    </div>



					            </td>
					            <td>

                                    <div class="form-group">
                                      <div class="col-sm-offset-2 col-sm-10">
                                          <asp:Button ID="Button2" runat="server" Text="<%$Resources:strings, siparisFinalBtnFrw %>" CssClass="btn btn-default" OnClick="btnSiparisDevam_Click" />                                   
                                      </div>
                                    </div>


					            </td>
				              </tr>


				            </tbody>
			              </table>

			            </div>



                </asp:Panel>



 
                <asp:Panel ID="pnlDone" runat="server" Visible="false">

                                        <div class="title-box" id="siparisBasarili">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="Literal15" runat="server" Text=" <%$Resources:strings, siparisDoneTitle %>"></asp:Literal></strong></h2>
                                    </div>
	<div class="row text-center">

        <img src="/img/check.png" />


          </div>


                    <ul class="list-unstyled">
                        <li><asp:Literal ID="ltsiparisDoneYazi1" runat="server" Text=""></asp:Literal></li>
                        <li><asp:Literal ID="ltsiparisDoneYazi2" runat="server" Text=""></asp:Literal></li>
                        <li><asp:Literal ID="ltsiparisDoneYazi3" runat="server" Text=""></asp:Literal></li>
                        <li><asp:Literal ID="ltsiparisDoneYazi4" runat="server" Text=""></asp:Literal></li>
                        <li><asp:Literal ID="ltsiparisDoneYazi5" runat="server" Text=""></asp:Literal></li>
<%--                        <li><asp:Literal ID="Literal16" runat="server" Text=""></asp:Literal></li>
                        <li><asp:Literal ID="sipDataSession" runat="server" Text=""></asp:Literal></li>
                        <li><asp:Literal ID="sipDataEnc" runat="server" Text=""></asp:Literal></li>
                        <li><asp:Literal ID="sess" runat="server" Text=""></asp:Literal></li>--%>
                        <li></br><h5><a href="#" id="sipKKOdeme" runat="server">
                            <asp:Literal ID="litKKOdeme" runat="server"></asp:Literal></a></h5></li>
                    </ul>

                </asp:Panel> 


                <asp:Panel ID="pnlError" runat="server" Visible="false">

                                        <div class="title-box" id="siparisBasarisiz">
		                                    <h2 class="title" style="color:#40499B"><strong><asp:Literal ID="Literal17" runat="server" Text=" <%$Resources:strings, siparisErrTitle %>"></asp:Literal></strong></h2>
                                    </div>

	      <div class="row text-center">

             <img src="/img/sip-err.png" />

          </div>

                    <ul class="list-unstyled">
                        <li><asp:Literal ID="Literal18" runat="server" Text=""></asp:Literal></li>
                        <li><asp:Literal ID="Literal19" runat="server" Text=""></asp:Literal></li>
                        <li><asp:Literal ID="Literal20" runat="server" Text=""></asp:Literal></li>

                    </ul>

                </asp:Panel> 



<%--                <div class="row">

                     <div class="col-sm-12 col-md-12">
                         <p><strong>35x65 Premium Plus Paket</strong></p>
                         </div>
                     <div class="col-sm-6 col-md-6">
                         <img src="/images/paketfotolar/25x75-Metal-Label-Series.jpg"/>                  
                </div>
                     <div class="col-sm-6 col-md-6">

                         <ul>
                            <li><strong>1 Adet 35x65 Premium Plus Albüm<strong></li>
                            <li><strong>2 Adet Aile Albümü<strong></li>
                            <li><strong>1 Adet Cep<strong></li>
                            <li><strong>1 Adet 50x60 veya 50x75<strong></li>
                         </ul>
                     </div>

                    <div class="col-sm-12 col-md-12">
                        <p style="text-align:right">Paket Fiyatı : 340,00 TL</p>
                        </div>

                    <div class="col-sm-12 col-md-12">
                        <p style="text-align:center"><a href="#">Sipariş Paketi Olarak Seç</a></p>
                        </div>

                </div>--%>



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


                                           <div class="clearfix"></div>

                <div id="dosyaGonder">
                <asp:Panel ID="pnlUpload" runat="server" Visible="true">



                    <div id="uplForm" runat="server">

                    <div class="title-box" id="fileuplForm">
		                                    <h2 class="title"><strong><asp:Literal ID="Literal7" runat="server" Text=" <%$Resources:strings, siparisFileUplFormTitle %>"></asp:Literal></strong></h2>
                                    </div>
                

                        <ul>
                            <li><asp:Literal ID="Literal10" runat="server" Text=" <%$Resources:strings, siparisUploadyazi1 %>"></asp:Literal></li>
                            <li><asp:Literal ID="Literal11" runat="server" Text=" <%$Resources:strings, siparisUploadyazi2 %>"></asp:Literal></li>
                            <li><asp:Literal ID="Literal12" runat="server" Text=" <%$Resources:strings, siparisUploadyazi3 %>"></asp:Literal></li>
                            <li><asp:Literal ID="Literal13" runat="server" Text=" <%$Resources:strings, siparisUploadyazi4 %>"></asp:Literal></li>
                            <li class="text-danger"><asp:Literal ID="Literal14" runat="server" Text=" <%$Resources:strings, siparisUploadyazi5 %>"></asp:Literal></li>

                            
                        </ul>
                

                    <div class="clearfix" style="margin-bottom:25px"></div>





            <div id="uploader" style="width:100%">
            <p>You browser doesn't have Flash, Silverlight, Gears, BrowserPlus or HTML5 support.</p>
        </div>





                
                
                
               </div> 
                
                
                
                </asp:Panel>
                </div>





                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" >

            <ProgressTemplate>

                <uc2:updateProgress runat="server" ID="updateProgress" />

            </ProgressTemplate>

        </asp:UpdateProgress>

<%--                <div class="col-sm-4 col-md-2 siparisimgMarg">
                    <img src="images/Master-logo-30x90.JPG" data-appear-animation="fadeIn" />
                </div>

                <div class="col-sm-4 col-md-2 siparisimgMarg">
                    <img src="images/Master-logo-30x90.JPG"  data-appear-animation="fadeIn"/>
                </div>

                <div class="col-sm-4 col-md-2 siparisimgMarg">
                    <img src="images/Master-logo-30x90.JPG" data-appear-animation="fadeIn"/>
                </div>

                <div class="col-sm-4 col-md-2 siparisimgMarg">
                    <img src="images/Master-logo-30x90.JPG" data-appear-animation="fadeIn" />
                </div>

                <div class="col-sm-4 col-md-2 siparisimgMarg">
                    <img src="images/Master-logo-30x90.JPG" data-appear-animation="fadeIn" />
                </div>

                <div class="col-sm-4 col-md-2 siparisimgMarg">
                    <img src="images/Master-logo-30x90.JPG" data-appear-animation="fadeIn" />
                </div>--%>

            
		<div id="modalwait" class="modal" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog" aria-hidden="true" style="padding-top:15%; overflow-y:visible;">
		    <div class="modal-dialog modal-m">
		        <div class="modal-content">
		            <div class="modal-header"><h4 style="margin:0;"><asp:Literal ID="lttsiparisBitis" runat="server" Text="<%$Resources:strings, siparisBitisLoading %>"></asp:Literal></h4><br /></div>
		            <div class="modal-body">
		                <div class="progress progress-striped active" style="margin-bottom:0;"><div class="progress-bar" style="width: 100%"></div></div>
		            </div>
		        </div></div></div>

		  <div class="bottom-padding">

                    

		  </div>
		  

            
		</div>
      </article><!-- .content -->
	  
        <uc1:memberRightBar runat="server" ID="memberRightBar" aktifSekme="22" />


    </div>
  </div>
</section><!-- #main -->




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBottom" Runat="Server">
    

        <script type="text/javascript">

        function fade(divId) {
            $(document).ready(function() {
                $("#" + divId).fadeIn(1500);
            });
        }

        function fadeOUT(divId) {
            $(document).ready(function() {
                $("#" + divId).fadeOut(500);
            });
        }



</script>

    <script type="text/javascript">

    function KeepSession() {
    // A request to server
    $.post("/SessionCheck.aspx");

    //now schedule this process to happen in some time interval, in this example its 1 min
    setInterval(KeepSession, 920000);
}

    // First time call of function
    KeepSession(); 
 </script>
        <link rel="stylesheet" href="/plupload-latest/js/jquery.plupload.queue/css/jquery.plupload.queue.css" type="text/css" media="screen" />

<!-- production -->
<script type="text/javascript" src="/plupload-latest/js/plupload.full.min.js"></script>
<script type="text/javascript" src="/plupload-latest/js/jquery.plupload.queue/jquery.plupload.queue.js"></script>

<!-- debug 
<script type="text/javascript" src="/plupload-latest/js/moxie.js"></script>
<script type="text/javascript" src="/plupload-latest/js/plupload.dev.js"></script>
<script type="text/javascript" src="/plupload-latest/js/jquery.plupload.queue/jquery.plupload.queue.js"></script>
-->

    <script src="/plupload-latest/js/i18n/tr.js"></script>
    
    <script type="text/javascript">

    var maxfiles = 1;
    $('document').ready(function () {
        $("#uploader").pluploadQueue({
            // General settings
            runtimes: 'html5,flash,html4, silverlight',
            url: '/uploaderN.ashx',
            max_file_size : '2000mb',
            chunk_size: '1mb',
            max_retries: 10,
            max_file_count: maxfiles,
            unique_names: true,           
            multi_selection: false,           
            dragdrop: false,
            container: 'uploader',
            // Resize images on clientside if we can
            resize : {width : 320, height : 240, quality : 90},
            // Specify what files to browse for
            multipart_params : {
                "Code": "<%=siparisOzelCode%>"
            },
            filters : [
                //{title : "Image files", extensions : "jpg,gif,png"},
                {title : "Zip files", extensions : "zip,rar"}
            ],
            // Flash settings
            flash_swf_url: '/plupload-latest/js/Moxie.swf',
            // Silverlight settings
            silverlight_xap_url: '/plupload-latest/js/Moxie.xap',
            init: {
                FilesAdded: function (up, files) {
                    plupload.each(files, function (file) {
                        if (up.files.length > maxfiles) {
                            up.removeFile(file);
                        }
                        var upa = $('#uploader').plupload('getUploader');
                        var i = 0;
                        while (i <= upa.files.length) {
                            ultimo = upa.files.length;
                            if (ultimo > 1) {
                                if (i > 0) {
                                    ultimo2 = ultimo - 1;
                                    ii = i - 1;
                                    if (ultimo2 != ii) {
                                        if (up.files[ultimo - 1].name == upa.files[i - 1].name) {
                                            up.removeFile(file);
                                        }
                                    }
                                }
                            }
                            i++;
                        }
                    });
                    if (up.files.length >= maxfiles) {
                        $('#uploader_browse').hide("slow");
                    }
                },
                FilesRemoved: function (up, files) {
                    if (up.files.length < maxfiles) {
                        $('#uploader_browse').fadeIn("slow");
                    }
                }
            }
        });

        var uploader = $('#uploader').pluploadQueue();

        uploader.bind("FileUploaded", function (up, file, response) {
            if (uploader.files.length == (uploader.total.uploaded + uploader.total.failed)) {

                //var dataValue = { "dosyaAdi": response.response};
                openModalWait();
                var obj = jQuery.parseJSON(response.response);


                $.ajax({
                    type: "POST",
                    url: "/siparisnew.aspx/YeniBitis",
                    data: "{dosya:'" + obj.dosya + "', code:'"+ obj.code +"'}",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
                    },
                    success: function (result) {
                        openModalWaitHide();

                        var obje = JSON.parse(result.d);
                        //objFinal = JSON.parse(result);

                        if (obje.Hata == '1')
                        {
                            window.location = "/uye-sayfam/siparis-gonder?err=0";
                        }

                        else if (obje.Hata == '0')
                        {
                            window.location = "/uye-sayfam/siparis-gonder?code=" + obje.Code + "&err=1&siparis=" + obje.siparis;
                        }


                        //alert("We returned: " + obje.Code);
                    }
                });



                //alert(response.response);
            }
        });

        //uploader.bind("FileUploaded", function (up, file, response) {
        //    if (uploader.files.length == (uploader.total.uploaded + uploader.total.failed)) {

        //        //var dataValue = { "dosyaAdi": response.response};

        //        $.ajax({
        //            type: "POST",
        //            url: "siparisnew.aspx/YeniBitis",
        //            data: "{dosya:'" + response.response + "'}",
        //            contentType: 'application/json; charset=utf-8',
        //            dataType: 'json',
        //            error: function (XMLHttpRequest, textStatus, errorThrown) {
        //                alert("Request: " + XMLHttpRequest.toString() + "\n\nStatus: " + textStatus + "\n\nError: " + errorThrown);
        //            },
        //            success: function (result) {
        //                alert("We returned: " + result.d);
        //            }
        //        });



        //        //alert(response.response);
        //    }
        //});



        //// Client side form validation
        //$('form').submit(function(e) {
        //    var uploader = $('#uploader').pluploadQueue();
        //    // Validate number of uploaded files
        //    if (uploader.total.uploaded == 0) {
        //        // Files in queue upload them first
        //        if (uploader.files.length > 0) {
        //            // When all files are uploaded submit form
        //            uploader.bind('UploadProgress', function() {
        //                if (uploader.total.uploaded == uploader.files.length)                        
        //                    window.location = '[url]http://www.anotherpage.co.uk[/url]';
        //            });
        //            uploader.start();
        //        } else
        //            alert('You must at least upload one file.');
        //        e.preventDefault();
        //    }
        //});
    });


    $(document).ready(function() {
        $("#dosyaGonder").fadeOut(500);
    });

    function openModalWait() {
        $(document).ready(function() {
            $('#modalwait').modal("show");

        });
    };
    function openModalWaitHide() {
        $(document).ready(function() {
            $('#modalwait').modal("hide");

        });
    };
    function openModalWaitHide() {
        $(document).ready(function () {
            $('#modalwait').modal("hide");

        });
    };
    </script>
            <script src="/js/costum-js.js"></script>
</asp:Content>

