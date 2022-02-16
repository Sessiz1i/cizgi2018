<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="sifreunutma.aspx.cs" Inherits="sifreunutma" %>

<%@ Register Src="~/updateProgress.ascx" TagPrefix="uc2" TagName="updateProgress" %>


<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" Runat="Server">

        <script src="/js/costum-js.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" Runat="Server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


<section id="main" class="login-register">
  <header class="page-header">
    <div class="container">
      <h2 class="title"><asp:Literal ID="litLoginTitle" runat="server" Text=" <%$Resources:strings, passForgettenTitle %>"></asp:Literal></h2>
    </div>	
  </header>

  <div class="container">
    <div class="row ">
        
		  <div class="col-xs-12 col-sm-6 col-md-6 col-centered" >
              
			<div class="form-box login-form form-validator">
               
			  <h3 class="title"><asp:Literal ID="litLoginTitle5" runat="server" Text=" <%$Resources:strings, passForgettenForm1 %>"></asp:Literal></h3>
			  <p><asp:Literal ID="litLoginTitle6" runat="server" Text="<%$Resources:strings, passForgettenForm2 %>"></asp:Literal></p>
			   <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnRetrievePass">
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
			  <div class="form-group">
				<label><asp:Literal ID="litUsernameLgn" runat="server" Text=" <%$Resources:strings, litUsernameLogin1 %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="usrUsername" runat="server" CssClass="form-control"></asp:TextBox>
				
              </div>
			  
			  <div class="form-group">
				<label><asp:Literal ID="litUsernameLgnPass" runat="server" Text=" <%$Resources:strings, registerFormEposta %>" ></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="usrEposta" runat="server" CssClass="form-control" ></asp:TextBox>               
              </div>
		  
<%--			  <div class="form-group">
				<label class="checkbox">
				  <input type="checkbox"> Remember password
				</label><asp:Panel ID="pnlLogin" runat="server"  Visible="true">
			  </div>--%>
			  
			  <div class="buttons-box clearfix">
                <asp:Button ID="btnRetrievePass" runat="server" Text="<%$Resources:strings, passForgettenForm3 %>" CssClass="btn btn-default" OnClick="btnRetrievePass_Click"/>			
               
				<span class="required"><b>*</b> <asp:Literal ID="ltnReqField" runat="server" Text=" <%$Resources:strings, litUsernameLogin3 %>"></asp:Literal></span>
			  </div>

              <div id="myModal2" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="padding-top:10%;">
                    <div class="modal-dialog modal-dialog-center25">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                                <h5 class="modal-title"><asp:Literal ID="loginErrTitle" runat="server"></asp:Literal></h5>
                            </div>
                            <div class="modal-body">
                                <p><asp:Label ID="loginErrDesc" runat="server" Text=""></asp:Label>                                   
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
                </asp:Panel>
			</div><!-- .form-box --></div>
		  </div>


	</div>	
      

  <!-- .container -->
</section><!-- #main -->

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" >

            <ProgressTemplate>

                <uc2:updateProgress runat="server" ID="updateProgress" />

            </ProgressTemplate>

        </asp:UpdateProgress>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBottom" Runat="Server">
</asp:Content>

