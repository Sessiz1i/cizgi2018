<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" Runat="Server">

            <script type="text/javascript">
            function CallFunction() {

                $('#myModal').modal("show");

            }
        </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" Runat="Server">

		<section id="slider" class="slider-element slider-parallax revslider-wrap ohidden clearfix">

			<!--
			#################################
				- THEMEPUNCH BANNER -
			#################################
			-->
			<div id="rev_slider_ishop_wrapper" class="rev_slider_wrapper fullwidth-container" data-alias="default-slider" style="padding:0px;">
					<!-- START REVOLUTION SLIDER 5.1.4 fullwidth mode -->
				<div id="rev_slider_ishop" class="rev_slider fullwidthbanner" style="display:none;" data-version="5.1.4">
					<ul>    
						<!-- SLIDE  -->
<%--						<li data-transition="slideup" data-slotamount="1" data-masterspeed="1500" data-delay="5000"  data-saveperformance="off"  data-title="Yeni Album" style="background-color: #E9E8E3;">
							<!-- LAYERS -->

							<div class="tp-caption ltl tp-resizeme revo-slider-caps-text uppercase"
							data-x="730"
							data-y="125"
							data-transform_in="x:250;y:0;z:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;s:400;e:Power4.easeOutQuad;"
							data-speed="400"
							data-start="1000"
							data-easing="easeOutQuad"
							data-splitin="none"
							data-splitout="none"
							data-elementdelay="0.01"
							data-endelementdelay="0.1"
							data-endspeed="1000"
							data-endeasing="Power4.easeIn" style=""><img src="/images/slider/rev/cizgi/lena.jpg" alt="Lena"></div>


							<div class="tp-caption ltl tp-resizeme revo-slider-emphasis-text nopadding noborder"
							data-x="0"
							data-y="140"
							data-transform_in="x:0;y:150;z:0;rotationZ:0;scaleX:1.3;scaleY:1;skewX:0;skewY:0;opacity:0;s:700;e:Power4.easeOutQuad;"
							data-speed="700"
							data-start="1200"
							data-easing="easeOutQuad"
							data-splitin="none"
							data-splitout="none"
							data-elementdelay="0.01"
							data-endelementdelay="0.1"
							data-endspeed="1000"
							data-endeasing="Power4.easeIn" style=" color: #333; line-height: 1.15;">Lena Kapak Modelleri</div>

							<div class="tp-caption ltl tp-resizeme revo-slider-desc-text tleft"
							data-x="0"
							data-y="240"
							data-transform_in="x:0;y:150;z:0;rotationZ:0;scaleX:1.3;scaleY:1;skewX:0;skewY:0;opacity:0;s:700;e:Power4.easeOutQuad;"
							data-speed="700"
							data-start="1400"
							data-easing="easeOutQuad"
							data-splitin="none"
							data-splitout="none"
							data-elementdelay="0.01"
							data-endelementdelay="0.1"
							data-endspeed="1000"
							data-endeasing="Power4.easeIn" style=" color: #333; max-width: 550px; white-space: normal;">Lena albüm modellerini üye girişi yaparak sipariş verebilirsiniz.</div>




						</li>--%>
                        
                        <!-- SLIDE  -->
                        <li data-transition="slideup" data-slotamount="1" data-masterspeed="1500" data-delay="10000"  data-saveperformance="off"  data-title="Yeni Album" style="background-color: #000000;">
                            <!-- LAYERS -->

                                                        <div class="tp-caption ltl tp-resizeme revo-slider-caps-text uppercase"
                            data-x="400"
                            data-y="20"
                            data-transform_in="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;s:1200;e:Power3.easeOut"
                            data-transform_out="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;s:300;e:Power1.easeIn"
                            data-speed="400"
                            data-start="500"
                            data-easing="easeOutQuad"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0.01"
                            data-endelementdelay="0.1"
                            data-endspeed="1000"
                            data-endeasing="Power4.easeIn" style=""><img src="/images/slider/rev/cizgi/logo.png" alt=""></div>

                            <div class="tp-caption ltl tp-resizeme revo-slider-caps-text uppercase"
                            data-x="-80"
                            data-y="235"
                            data-transform_in="y:top;s:1000;e:Power4.easeOut"
                            data-transform_out="y:top;s:400;e:Power1.easeIn"
                            data-speed="400"
                            data-start="1000"
                            data-easing="easeOutQuad"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0.01"
                            data-endelementdelay="0.1"
                            data-endspeed="1000"
                            data-endeasing="Power4.easeIn" style=""><img src="/images/slider/rev/cc/yazi1.png" alt=""></div>

                            <div class="tp-caption ltl tp-resizeme revo-slider-caps-text uppercase"
                            data-x="-20"
                            data-y="340"
                            data-transform_in="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;s:1200;e:Power3.easeOut"
                            data-transform_out="x:0;y:0;z:0;rotationX:0;rotationY:0;rotationZ:0;scaleX:0;scaleY:0;skewX:0;skewY:0;opacity:0;transformPerspective:600;transformOrigin:50% 50%;s:300;e:Power1.easeIn"
                            data-speed="400"
                            data-start="1800"
                            data-easing="easeOutQuad"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0.01"
                            data-endelementdelay="0.1"
                            data-endspeed="1000"
                            data-endeasing="Power4.easeIn" style=""><img src="/images/slider/rev/cc/card.png" alt=""></div>

                            <div class="tp-caption ltl tp-resizeme revo-slider-caps-text uppercase"
                            data-x="-80"
                            data-y="310"
                            data-transform_in="x:left;s:1000;e:Power4.easeOut"
                            data-transform_out="x:left;s:400;e:Power1.easeIn"
                            data-speed="400"
                            data-start="2300"
                            data-easing="easeOutQuad"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0.01"
                            data-endelementdelay="0.1"
                            data-endspeed="1000"
                            data-endeasing="Power4.easeIn" style=""><img src="/images/slider/rev/cc/yazi2.png" alt=""></div>
                            
                            <div class="tp-caption ltl tp-resizeme revo-slider-caps-text uppercase"
                            data-x="-80"
                            data-y="385"
                            data-transform_in="x:right;s:1000;e:Power4.easeOut"
                            data-transform_out="x:right;s:400;e:Power1.easeIn"
                            data-speed="400"
                            data-start="3000"
                            data-easing="easeOutQuad"
                            data-splitin="none"
                            data-splitout="none"
                            data-elementdelay="0.01"
                            data-endelementdelay="0.1"
                            data-endspeed="1000"
                            data-endeasing="Power4.easeIn" style=""><img src="/images/slider/rev/cc/yazi3.png" alt=""></div>
                        </li>
                        						<!-- SLIDE  -->
						<li data-transition="slideup" data-slotamount="1" data-masterspeed="1500" data-delay="5000"  data-saveperformance="off"  data-title="Yeni Album" style="background-color: #000000;">
							<!-- LAYERS -->

							<div class="tp-caption ltl tp-resizeme revo-slider-caps-text uppercase"
							data-x="400"
							data-y="0"
							data-transform_in="x:250;y:0;z:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;s:400;e:Power4.easeOutQuad;"
							data-speed="400"
							data-start="1000"
							data-easing="easeOutQuad"
							data-splitin="none"
							data-splitout="none"
							data-elementdelay="0.01"
							data-endelementdelay="0.1"
							data-endspeed="1000"
							data-endeasing="Power4.easeIn" style=""><img src="/images/slider/rev/cizgi/logo.png" alt=""></div>


                            <div class="tp-caption ltl tp-resizeme revo-slider-caps-text uppercase"
                                 data-x="-80"
                                 data-y="325"
                                 data-transform_in="x:250;y:0;z:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;s:400;e:Power4.easeOutQuad;"
                                 data-speed="400"
                                 data-start="1000"
                                 data-easing="easeOutQuad"
                                 data-splitin="none"
                                 data-splitout="none"
                                 data-elementdelay="0.01"
                                 data-endelementdelay="0.1"
                                 data-endspeed="1000"
                                 data-endeasing="Power4.easeIn" style=""><img src="/images/slider/rev/cizgi/yazi.png" alt=""></div>
                            
                            <div class="tp-caption ltl tp-resizeme revo-slider-caps-text uppercase"
                                 data-x="-80"
                                 data-y="375"
                                 data-transform_in="x:250;y:0;z:0;rotationZ:0;scaleX:1;scaleY:1;skewX:0;skewY:0;opacity:0;s:400;e:Power4.easeOutQuad;"
                                 data-speed="400"
                                 data-start="1000"
                                 data-easing="easeOutQuad"
                                 data-splitin="none"
                                 data-splitout="none"
                                 data-elementdelay="0.01"
                                 data-endelementdelay="0.1"
                                 data-endspeed="1000"
                                 data-endeasing="Power4.easeIn" style=""><img src="/images/slider/rev/cizgi/cizgi.png" alt=""></div>




						</li>
                        

					</ul>
				</div>
			</div><!-- END REVOLUTION SLIDER -->

		</section>

		<!-- Content
		============================================= -->
		<section id="content">

			<div class="content-wrap">



                <div class="container clearfix">



                    <div class="heading-block center">
                        <h2><span>Panaromik</span> Albüm Modellerimiz</h2>
                        <span>Albüm modellerimizden bazıları</span>
                    </div>
                    
                    <div class="center">
                        <div class="col-md-4 nobottommargin">
                        <div class="feature-box media-box">
                            <div class="fbox-media">
                                <img src="/images/main/lena.jpg" alt="Lena">
                            </div>
                            <div class="fbox-desc">
                                <h3>Lena Kapak</h3>
                                <p>Fotoğraf kapaklı ahşap albüm.</p>
                            </div>
                        </div>
                    </div>

                        <div class="col-md-4 nobottommargin">
                        <div class="feature-box media-box">
                            <div class="fbox-media">
                                <img src="/images/main/nirvana.JPG" alt="Nirvana">
                            </div>
                            <div class="fbox-desc">
                                <h3>Nirvana Kapak</h3>
                                <p>Fotoğraf kapaklı ahşap albüm.</p>
                            </div>
                        </div>
                    </div>
                    
                        <div class="col-md-4 nobottommargin">
                        <div class="feature-box media-box">
                            <div class="fbox-media">
                                <img src="/images/main/perla.JPG" alt="Perla">
                            </div>
                            <div class="fbox-desc">
                                <h3>Perla Kapak</h3>
                                <p>Fotoğraf kapaklı ahşap albüm.</p>
                            </div>
                        </div>
                    </div>
                    
                    </div>

                    <div class="clear"></div>
                    
                    
                    
                    <div class="center" style="margin-top:50px">
                        <div class="col-md-4 nobottommargin">
                            <div class="feature-box media-box">
                                <div class="fbox-media">
                                    <img src="/images/main/viyola.JPG" alt="Viyola">
                                </div>
                                <div class="fbox-desc">
                                    <h3>Viyola Kapak</h3>
                                    <p>Fotoğraf kapaklı ahşap albüm.</p>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4 nobottommargin">
                            <div class="feature-box media-box">
                                <div class="fbox-media">
                                    <img src="/images/main/tanny.JPG" alt="Tanny">
                                </div>
                                <div class="fbox-desc">
                                    <h3>Tanny Kapak</h3>
                                    <p>Fotoğraf kapaklı ve metal isim şeritli bebek albümü.</p>
                                </div>
                            </div>
                        </div>
                    
                        <div class="col-md-4 nobottommargin">
                            <div class="feature-box media-box">
                                <div class="fbox-media">
                                    <img src="/images/main/bondigo.JPG" alt="Bondigo">
                                </div>
                                <div class="fbox-desc">
                                    <h3>Bondigo Kapak</h3>
                                    <p>Fotoğraf kapaklı bebek albümü.</p>
                                </div>
                            </div>
                        </div>
                    
                    </div>

                    <div class="clear"></div>

                </div>



			</div>

		</section><!-- #content end -->


            <!--Modal: modalCookie-->
        <div id="myModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-center25">
                <!--Content-->
                <div class="modal-content">
                    <!--Body-->
                    <div class="modal-body">
                        <div class="row d-flex" style="margin:20px">
                            <h5 style="margin-top:20px ">Değerli müşterilerimiz,</h5>
                            <h6>Döviz piyasalası ve hammadde fiyatlarındaki ani değişimler sebebiyle maliyet artışlarını dengeleyebilmek, yaşanan mağduriyetleri giderebilmek ve öngörülebilir sabit fiyat politikası oluşturabilmek için 1 Şubat 2022 tarihinden itibaren fiyatlarımız güncel döviz kuru üzerinden hesaplanacaktır.</h6> 
                        </div>

                    </div>
                             <div class="modal-footer">
                                <button data-dismiss="modal" class="btn btn-default">KAPAT</button>
                            </div>
                </div>
                <!--/.Content-->
            </div>
        </div>
        <!--Modal: modalCookie-->

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="contentBottom" Runat="Server">
</asp:Content>
