<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>
<%@ Register Src="~/updateProgress.ascx" TagPrefix="uc1" TagName="updateProgress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentStyle" Runat="Server">
            <script src="/js/costum-js.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentMid" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <!-- Page Title
		============================================= -->
		<section id="page-title">

			<div class="container clearfix">
				<h1>Üye Girişi</h1>

			</div>

		</section><!-- #page-title end -->

		<!-- Content
		============================================= -->
		<section id="content">

			<div class="content-wrap">

				<div class="container clearfix">

					<div class="accordion accordion-lg divcenter nobottommargin clearfix" style="max-width: 550px;">

						<div class="acctitle"><i class="acc-closed icon-lock3"></i><i class="acc-open icon-unlock"></i>Hesabınızla Giriş Yapın<asp:Label ID="lblRef" runat="server" Text=""></asp:Label></div>
						<div class="acc_content clearfix">
                             <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
          <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
							<%--<form id="login-form" name="login-form" class="nobottommargin" action="#" method="post">--%>
								<div class="col_full">
	                                  <label><asp:Literal ID="litUsernameLgn" runat="server" Text="Kullanıcı Adı"></asp:Literal>: <span class="required">*</span></label>
                                      <asp:TextBox ID="usrUsername" runat="server" CssClass="form-control"></asp:TextBox>
								</div>

								<div class="col_full">
                                         <label><asp:Literal ID="litUsernameLgnPass" runat="server" Text="Şifreniz" ></asp:Literal>: <span class="required">*</span></label>
                                         <asp:TextBox ID="usrPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>               
								</div>

								<div class="col_full nobottommargin">
									<asp:Button ID="btnLogin" runat="server" Text="Giriş Yap" CssClass="button button-3d button-black nomargin" OnClick="btnLogin_Click" />	

									<a href="/sifre-yenile" class="fright">Şifrenizi mi Unuttunuz?</a>
								</div>
							<%--</form>--%>

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
                                <button data-dismiss="modal" class="button button-3d button-black nomargin">OK</button>
                            </div>
                        </div>
                    </div>
                </div>

                </ContentTemplate>
              </asp:UpdatePanel>
                </asp:Panel>
						</div>

						<div class="acctitle"><i class="acc-closed icon-user4"></i><i class="acc-open icon-ok-sign"></i>Hesabınız Yok mu? Yeni Hesap Açmak İçin Tıklayın</div>
						<div class="acc_content clearfix">

  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
			  
              <div class="form-group">
				<label><asp:Literal ID="litRegisterUsr" runat="server" Text="<%$Resources:strings, registerFormUsername %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterUsername" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>
                               
              <div class="form-group">
				<label><asp:Literal ID="litRegisterIsim" runat="server" Text="<%$Resources:strings, registerFormIsim %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterIsim" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>

              <div class="form-group">
				<label><asp:Literal ID="litRegisterSoyisim" runat="server" Text="<%$Resources:strings, registerFormSoyisim %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterSoyisim" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>

              <div class="form-group">
				<label><asp:Literal ID="litRegisterEposta" runat="server" Text="<%$Resources:strings, registerFormEposta %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterEposta" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>

              <div class="form-group">
				<label><asp:Literal ID="litRegisterSifre" runat="server" Text="<%$Resources:strings, registerFormSifre %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterSifre" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>               
              </div>

              <div class="form-group">
				<label><asp:Literal ID="litRegisterSifre2" runat="server" Text="<%$Resources:strings, registerFormSifre2 %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterSifre2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>               
              </div>	

              <div class="form-group">
				<label><asp:Literal ID="litRegisterWeb" runat="server" Text="<%$Resources:strings, registerFormWeb %>"></asp:Literal>:</label>
                  <asp:TextBox ID="txtRegisterWeb" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>                                     

              <div class="form-group">
				<label><asp:Literal ID="litRegisterUlke" runat="server" Text="<%$Resources:strings, registerFormUlke %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:DropDownList ID="drpUlke" runat="server" OnSelectedIndexChanged="drpUlke_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True" CssClass="input-lg form-control">
                      <asp:ListItem Selected="True" Value="0" Text="<%$Resources:strings, registerFormUlkeSecin %>"></asp:ListItem>
                  </asp:DropDownList>              
              </div>                
                
              <div class="form-group">
				<label><asp:Literal ID="litRegisterSehir" runat="server" Text="<%$Resources:strings, registerFormSehir %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:DropDownList ID="drpSehir" runat="server" CssClass="input-lg form-control" AutoPostBack="True" ondatabound="MyListDataBound" >
                    <asp:ListItem Selected="True" Value="0" Text="<%$Resources:strings, registerFormSehirSecin %>"></asp:ListItem>
                  </asp:DropDownList>               
              </div>                

              <div class="form-group">
				<label><asp:Literal ID="litRegisterTel" runat="server" Text="<%$Resources:strings, registerFormTel %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterTel" runat="server" CssClass="form-control" ></asp:TextBox>               
              </div>	

              <div class="form-group">
				<label><asp:Literal ID="litRegisterAdres" runat="server" Text="<%$Resources:strings, registerFormAdres %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterAdres" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>               
              </div>                
                
              <h3 class="title"><asp:Literal ID="litRegisterTitleFirma" runat="server" Text="<%$Resources:strings, registerFormFirmaTitle %>"></asp:Literal></h3>
                
              <div class="form-group">
				<label><asp:Literal ID="litRegisterFirmaUnvan" runat="server" Text="<%$Resources:strings, registerFormFirmaUnvan %>"></asp:Literal>: </label>
                  <asp:TextBox ID="txtRegisterFirmaUnvan" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>   
                
              <div class="form-group">
				<label><asp:Literal ID="litRegisterFirmaIsim" runat="server" Text="<%$Resources:strings, registerFormFirmaFaturaIsim %>"></asp:Literal>: </label>
                  <asp:TextBox ID="txtRegisterFirmaIsım" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>                  
                
              <div class="form-group">
				<label><asp:Literal ID="litRegisterFirmaVergiD" runat="server" Text="<%$Resources:strings, registerFormFirmaVergiDairesi %>"></asp:Literal>: </label>
                  <asp:TextBox ID="txtRegisterFirmaVergiDaire" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>                  
                
              <div class="form-group">
				<label><asp:Literal ID="litRegisterFirmaVergiNo" runat="server" Text="<%$Resources:strings, registerFormFirmaVergiNumarasi %>"></asp:Literal>: </label>
                  <asp:TextBox ID="txtRegisterFirmaVergiNo" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>                  
                
              <div class="form-group">
				<label><asp:Literal ID="litRegisterFirmaTel" runat="server" Text="<%$Resources:strings, registerFormFirmaTel %>"></asp:Literal>:</label>
                  <asp:TextBox ID="txtRegisterFirmaTel" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>                  
                
              <div class="form-group">
				<label><asp:Literal ID="litRegisterFirmaAdres" runat="server" Text="<%$Resources:strings, registerFormFirmaAdres %>"></asp:Literal>: </label>
                  <asp:TextBox ID="txtRegisterFirmaAdres" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>               
              </div>                  
                	
              <div class="form-group">
				<label><asp:Literal ID="litUyelikSozlesmesi" runat="server" Text="<%$Resources:strings, registerFormFirmaUyelikSozlesmesiTitle %>"></asp:Literal>: </label>
                  <asp:TextBox ID="txtUyelikSozlesmesi" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="True"></asp:TextBox> 
              </div>   

                
			  <div class="form-group">
				<label class="checkbox">
                    <asp:CheckBox ID="chkUyelikSozlesmesi" runat="server" Text="<%$Resources:strings, registerFormSozlesme %>" />
				</label>
			  </div>

			  <div class="form-group">
				<label class="checkbox">
                    <asp:CheckBox ID="chkMailList" runat="server" Text="<%$Resources:strings, registerFormMailingList %>" Checked="True" />
				</label>
			  </div>

			  <div class="buttons-box clearfix">
                  <asp:Button ID="btnRegister" runat="server" Text="<%$Resources:strings, registerFormBtnRegister %>" CssClass="button button-3d button-black nomargin" OnClick="btnRegister_Click"/>				
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

				</div>

			</div>

		</section><!-- #content end -->

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" >

            <ProgressTemplate>

                <uc1:updateProgress runat="server" ID="updateProgress" />

            </ProgressTemplate>

        </asp:UpdateProgress>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentBottom" Runat="Server">
</asp:Content>

