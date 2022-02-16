<%@ Page Title="" Language="C#" MasterPageFile="~/cizgi.master" AutoEventWireup="true" CodeFile="memberupdate.aspx.cs" Inherits="memberUpdate" %>
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
            <h1>Üyelik Bilgileriniz</h1>
            
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
			  <h3 class="title"><asp:Literal ID="litRegisterTitle1" runat="server" Text="<%$Resources:strings, memberUpdateTitle %>"></asp:Literal></h3>
			  <p><asp:Literal ID="litRegisterTitle2" runat="server" Text="<%$Resources:strings, memberUpdateTitle2 %>"></asp:Literal></p>
			  
                               
              <div class="form-group">
				<label><asp:Literal ID="litRegisterIsim" runat="server" Text="<%$Resources:strings, registerFormIsim %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterIsim" runat="server" CssClass="form-control"></asp:TextBox>               
              </div>

              <div class="form-group">
				<label><asp:Literal ID="litRegisterSoyisim" runat="server" Text="<%$Resources:strings, registerFormSoyisim %>"></asp:Literal>: <span class="required">*</span></label>
                  <asp:TextBox ID="txtRegisterSoyisim" runat="server" CssClass="form-control"></asp:TextBox>               
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
                	
              

			  <div class="buttons-box clearfix">
                  <asp:Button ID="btnRegister" runat="server" Text="<%$Resources:strings, memberUpdateBtn %>" CssClass="btn btn-default" OnClick="btnRegister_Click"/>				
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

