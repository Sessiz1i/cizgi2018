<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="memberUpdateMail.aspx.cs" Inherits="memberUpdateMail" %>

<%@ Register Src="~/updateProgress.ascx" TagPrefix="uc2" TagName="updateProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" Runat="Server">
    <link rel="stylesheet" href="/css/customizer/pages.css">
    <link rel="stylesheet" href="/css/customizer/shop-pages-customizer.css">
    <script src="/js/costum-js.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" Runat="Server">
    
       
    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <section id="page-title">

        <div class="container clearfix">
            <h1>Mail Güncelleme</h1>
            
        </div>

    </section>

<section id="main" class="page ">

  <div class="container">
    <div class="row">
      <article class="col-sm-9 col-md-9 content">
		<div class="my-account">


              <div class="col-xs-12 col-sm-12 col-md-12 box register">
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

			<div class="form-box register-form form-validator">
			  <h3 class="title"><asp:Literal ID="litRegisterTitle1" runat="server" Text="<%$Resources:strings, memberMailUpdateTitle %>"></asp:Literal></h3>
			  <p><asp:Literal ID="litRegisterTitle2" runat="server" Text="<%$Resources:strings, memberMailUpdateTitle2 %>"></asp:Literal></p>
			  
                               
              <div class="form-group">
				<label><asp:Literal ID="limemberPassUpdateOldPass" runat="server" Text="<%$Resources:strings, memberPassUpdateOldPass %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>               
              </div>

              <div class="form-group">
				<label><asp:Literal ID="littxtNewPass" runat="server" Text="<%$Resources:strings, memberMailUpdateMailCurrent %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtOldMail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>               
              </div>

              <div class="form-group">
				<label><asp:Literal ID="LitmemberMailUpdateMailNew" runat="server" Text="<%$Resources:strings, memberMailUpdateMailNew %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtNewMail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>               
              </div>
       
                	
              

			  <div class="buttons-box clearfix">
                  <asp:Button ID="btnRegister" runat="server" Text="<%$Resources:strings, memberMailUpdateMailBtn %>" CssClass="btn btn-default" OnClick="btnRegister_Click"/>				
				<span class="required"><b>*</b> <asp:Literal ID="litRegisterFormRequiredField" runat="server" Text="<%$Resources:strings, litUsernameLogin3 %>"></asp:Literal></span>
			  </div>
			</div><!-- .form-box -->

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

