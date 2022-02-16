<%@ Control Language="C#" AutoEventWireup="true" CodeFile="languageBar.ascx.cs" Inherits="languageBar" %>

		  <div class="btn-group language btn-select">
			<a class="btn dropdown-toggle btn-default" role="button" data-toggle="dropdown" href="#">
			  <span class="hidden-xs"><asp:Label ID="lblLanguage" runat="server" Text="<%$ Resources:strings, headerlanguage%>"></asp:Label></span><span class="visible-xs"><asp:Label ID="lblLangKisaltma" runat="server" Text=""></asp:Label></span><!-- 
			  -->: <asp:Label ID="lblSelectedLangName" runat="server" Text=""></asp:Label>
			  <span class="caret"></span>
			</a>
			<ul class="dropdown-menu">
                <asp:Repeater ID="rpt" runat="server">
                    <ItemTemplate>

                <li><a href="/Dil-Secimi/<%#Eval("language_culture") %> "><img src="<%#Eval("language_flag") %>" alt="<%#Eval("language_name")%>"><%#Eval("language_name")%></a></li>

                    </ItemTemplate>
                </asp:Repeater>
			</ul>
		  </div>