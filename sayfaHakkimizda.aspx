<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="sayfaHakkimizda.aspx.cs" Inherits="sayfaHakkimizda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" Runat="Server">
    
    <section id="page-title">

        <div class="container clearfix">
            <h1>Hakkımızda</h1>
            
        </div>

    </section>
    
    <!-- Content
    ============================================= -->
    <section id="content">

        <div class="content-wrap">

            <div class="container clearfix">

                <div class="row clearfix">

                    <div class="col-md-12">

                        <div class="clear"></div>

                        <div class="row clearfix">

                            <div class="col-lg-12" align="left">
    
    
                                <strong class="text-left"> <asp:Literal ID="lithakkimizda" runat="server"></asp:Literal></strong>
        

                            </div>
    
                        </div>

                    </div>

                </div>



            </div>

        </div>



    </section><!-- #content end -->

    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBottom" Runat="Server">
</asp:Content>

