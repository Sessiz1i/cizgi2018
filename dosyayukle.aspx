<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="dosyayukle.aspx.cs" Inherits="dosyayukle" %>

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

<section id="page-title">

    <div class="container clearfix">
        <h1>Dosyanızı Yükleyin</h1>
            
    </div>

</section>

<section id="content">

<div class="content-wrap">

<div class="container clearfix">

<article class="col-sm-9 col-md-9 content">
<div class="my-account">

<asp:UpdatePanel ID="UpdatePanel2" runat="server">
<ContentTemplate>

    


                                           <div class="clearfix"></div>

                <div id="dosyaGonder">
                <asp:Panel ID="pnlUpload" runat="server" Visible="true">



                    <div id="uplForm" runat="server">

                    <div class="title-box" id="fileuplForm">
		                                    <h2 class="title"><strong><asp:Literal ID="Literal7" runat="server" Text=" <%$Resources:strings, siparisFileUplFormTitle %>"></asp:Literal></strong></h2>
                                    </div>
                

                        <ul>
                            <li><asp:Literal ID="Literal1" runat="server" Text=""></asp:Literal></li>
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

            


		  <div class="bottom-padding">

                    

		  </div>
		  

            
		</div>
      </article><!-- .content -->
	  
        <%--<uc1:memberRightBar runat="server" ID="memberRightBar" aktifSekme="2" />--%>


    </div>
  </div>
</section><!-- #main -->
                

    </ContentTemplate>
</asp:UpdatePanel>











    
    
    

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
                    url: "/dosyayukle.aspx/YeniBitis",
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
                            window.location = "/uye-sayfasi/yukleme-sonucu?code=" + obje.Code + "&err=0&siparis=" + obje.siparis;
                        }

                        else if (obje.Hata == '0')
                        {
                            window.location = "/uye-sayfasi/yukleme-sonucu?code=" + obje.Code + "&err=1&siparis=" + obje.siparis;
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



