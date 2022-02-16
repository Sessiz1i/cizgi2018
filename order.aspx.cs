using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SqlConnections;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;

public partial class order : System.Web.UI.Page
{
    public int orderID
    {
        get
        {
            if (this.ViewState["orderID"] == null)
                return 0;

            return (int) this.ViewState["orderID"];
        }
        set { this.ViewState["orderID"] = value; }
    }

    public int memberID
    {
        get
        {
            if (this.ViewState["memberID"] == null)
                return 0;

            return (int) this.ViewState["memberID"];
        }
        set { this.ViewState["memberID"] = value; }
    }

    public int secilenSeri
    {
        get
        {
            if (this.ViewState["secilenSeri"] == null)
                return 0;

            return (int) this.ViewState["secilenSeri"];
        }
        set { this.ViewState["secilenSeri"] = value; }
    }

    public string secilenSeriAdi
    {
        get
        {
            if (this.ViewState["secilenSeriAdi"] == null)
                return "";

            return (string) this.ViewState["secilenSeriAdi"];
        }
        set { this.ViewState["secilenSeriAdi"] = value; }
    }

    public int secilenOlcu
    {
        get
        {
            if (this.ViewState["secilenOlcu"] == null)
                return 0;

            return (int) this.ViewState["secilenOlcu"];
        }
        set { this.ViewState["secilenOlcu"] = value; }
    }

    public string secilenOlcuAdi
    {
        get
        {
            if (this.ViewState["secilenOlcuAdi"] == null)
                return "";

            return (string) this.ViewState["secilenOlcuAdi"];
        }
        set { this.ViewState["secilenOlcuAdi"] = value; }
    }

    public int secilenPaket
    {
        get
        {
            if (this.ViewState["secilenPaket"] == null)
                return 0;

            return (int) this.ViewState["secilenPaket"];
        }
        set { this.ViewState["secilenPaket"] = value; }
    }

    public int secilenKapak
    {
        get
        {
            if (this.ViewState["secilenKapak"] == null)
                return 0;

            return (int) this.ViewState["secilenKapak"];
        }
        set { this.ViewState["secilenKapak"] = value; }
    }

    public string secilenKapakAdi
    {
        get
        {
            if (this.ViewState["secilenKapakAdi"] == null)
                return "";

            return (string) this.ViewState["secilenKapakAdi"];
        }
        set { this.ViewState["secilenKapakAdi"] = value; }
    }

    public int secilenKumas
    {
        get
        {
            if (this.ViewState["secilenKumas"] == null)
                return 0;

            return (int) this.ViewState["secilenKumas"];
        }
        set { this.ViewState["secilenKumas"] = value; }
    }

    public string secilenKumasAdi
    {
        get
        {
            if (this.ViewState["secilenKumasAdi"] == null)
                return "";

            return (string) this.ViewState["secilenKumasAdi"];
        }
        set { this.ViewState["secilenKumasAdi"] = value; }
    }
    public int secilenAhsap
    {
        get
        {
            if (this.ViewState["secilenAhsap"] == null)
                return 0;

            return (int)this.ViewState["secilenAhsap"];
        }
        set { this.ViewState["secilenAhsap"] = value; }
    }
    public string secilenAhsapAdi
    {
        get
        {
            if (this.ViewState["secilenAhsapAdi"] == null)
                return "";

            return (string)this.ViewState["secilenAhsapAdi"];
        }
        set { this.ViewState["secilenAhsapAdi"] = value; }
    }


    public string grupAdi
    {
        get
        {
            if (this.ViewState["grupAdi"] == null)
                return "";

            return (string) this.ViewState["grupAdi"];
        }
        set { this.ViewState["grupAdi"] = value; }
    }

    public int grupEkstraID
    {
        get
        {
            if (this.ViewState["grupEkstraID"] == null)
                return 0;

            return (int) this.ViewState["grupEkstraID"];
        }
        set { this.ViewState["grupEkstraID"] = value; }
    }

    public int ahsapZorunlu
    {
        get
        {
            if (this.ViewState["ahsapZorunlu"] == null)
                return 0;

            return (int)this.ViewState["ahsapZorunlu"];
        }
        set { this.ViewState["ahsapZorunlu"] = value; }
    }
    public int kapakZorunlu
    {
        get
        {
            if (this.ViewState["kapakZorunlu"] == null)
                return 0;

            return (int)this.ViewState["kapakZorunlu"];
        }
        set { this.ViewState["kapakZorunlu"] = value; }
    }
    public int tarihZorunlu
    {
        get
        {
            if (this.ViewState["tarihZorunlu"] == null)
                return 0;

            return (int)this.ViewState["tarihZorunlu"];
        }
        set { this.ViewState["tarihZorunlu"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            orderID = 1;
            memberID = 805;
            seriListesi();
            siparisBilgileriEkstra();
            search.Value = "";
            Page.Title = "Sipariş Sayfası";
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        // Bind Your Repeater here
    }

    public void seriListesi()
    {
        linkButtonProcessDegis(1);


        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "Select * from polcu_kategori where polcu_kategori_active=1 order by polcu_kategori_sira ASC", s))
            {
                SqlDataReader r = c.ExecuteReader();

                rptSeriList.DataSource = r;
                rptSeriList.DataBind();
            }
        }
    }

    public void seriSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "seriEkle")
        {
            string[] commandArgss = e.CommandArgument.ToString().Split(new char[] {','});

            secilenOlcu = 0;
            secilenKapak = 0;
            secilenKumas = 0;
            secilenSeri = Convert.ToInt32(commandArgss[0]);
            secilenSeriAdi = commandArgss[1];

            seriListesi();

            foreach (RepeaterItem item in rptSeriList.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lb = (LinkButton) item.FindControl("lnkButtonSeriSec");

                    string[] lbCA = lb.CommandArgument.ToString().Split(new char[] {','});

                    if (Convert.ToInt32(lbCA[0]) == secilenSeri)
                    {
                        lb.CommandName = "seriCikart";
                        lb.CssClass += " active  pulse animated";


                        lnkIlerle1.Enabled = true;
                        lnkIlerle1.Text = "Sonraki Adım  &rArr;";
                        lnkIlerle1.CssClass = "button button-3d fright";

                        lnkIlerle2.Enabled = false;
                        lnkIlerle2.Text = "Seçim Yapınız...";
                        lnkIlerle2.CssClass = "button-deactive button-red button button-3d fright";

                        linkButtonProcessDegis(1);

                        paketDbYaz(secilenPaket, "Cikart");
                        siparisBilgileriPaket();
                        siparisBilgileriGetir();
                    }
                }
            }
        }

        else if (e.CommandName == "seriCikart")
        {
            linkButtonProcessDegis(1);
            secilenSeri = 0;
            secilenOlcu = 0;
            secilenKapak = 0;
            secilenKumas = 0;
            secilenSeriAdi = "";
            lnkIlerle1.Enabled = false;
            lnkIlerle1.Text = "Seçim Yapınız...";
            lnkIlerle1.CssClass = "button-deactive button-red button button-3d fright";
            seriListesi();
            paketDbYaz(secilenPaket, "Cikart");
            siparisBilgileriPaket();
            siparisBilgileriGetir();
        }

        ekstraSepetTemizle();
    }

    protected void lnkIlerle1_Click(object sender, EventArgs e)
    {
        olcuGetir(secilenSeri);
        linkButtonProcessDegis(2);
    }

    public void olcuGetir(int olcu)
    {
        linkButtonProcessDegis(2);

        pnlSeriList.Visible = false;
        pnlOlculer.Visible = true;

        int olcuTipi = Convert.ToInt32(olcu);

        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT [paketolcu_id], [paketolcu_isim], [paketolcu_active], [paketolcu_tip], [paketolcu_sira] FROM[dbo].[paketolcu] where[paketolcu_tip]=@paketolcu_tip order by[paketolcu_sira] ASC",
                    s))
            {
                c.Parameters.AddWithValue("@paketolcu_tip", olcuTipi);
                SqlDataReader r = c.ExecuteReader();

                rptOlculer.DataSource = r;
                rptOlculer.DataBind();
            }
        }
    }

    public void olcuSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "olcuEkle")
        {
            string[] commandArgss = e.CommandArgument.ToString().Split(new char[] {','});

            secilenPaket = 0;
            secilenKapak = 0;
            secilenKumas = 0;
            secilenOlcu = Convert.ToInt32(commandArgss[0]);
            secilenOlcuAdi = commandArgss[1];

            olcuGetir(secilenSeri);

            foreach (RepeaterItem item in rptOlculer.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lb = (LinkButton) item.FindControl("lnkButtonOlcuSec");

                    string[] lbCA = lb.CommandArgument.ToString().Split(new char[] {','});

                    if (Convert.ToInt32(lbCA[0]) == secilenOlcu)
                    {
                        lb.CssClass += " active pulse animated";
                        lb.CommandName = "olcuCikart";

                        lnkIlerle2.Enabled = true;
                        lnkIlerle2.Text = "Sonraki Adım  &rArr;";
                        lnkIlerle2.CssClass = "button button-3d fright";

                        lnkIlerle3.Enabled = false;
                        lnkIlerle3.Text = "Seçim Yapınız...";
                        lnkIlerle3.CssClass = "button-deactive button-red button button-3d fright";

                        linkButtonProcessDegis(2);
                        paketDbYaz(secilenPaket, "Cikart");
                        siparisBilgileriPaket();
                        siparisBilgileriGetir();
                    }
                }
            }
        }

        else if (e.CommandName == "olcuCikart")
        {
            linkButtonProcessDegis(2);
            secilenOlcu = 0;
            secilenKapak = 0;
            secilenKumas = 0;
            secilenOlcuAdi = "";
            lnkIlerle2.Enabled = false;
            lnkIlerle2.Text = "Seçim Yapınız...";
            lnkIlerle2.CssClass = "button-deactive button-red button button-3d fright";
            olcuGetir(secilenSeri);
            paketDbYaz(secilenPaket, "Cikart");
            siparisBilgileriPaket();
            siparisBilgileriGetir();
        }

        ekstraSepetTemizle();
    }

    protected void lnkIlerle2_Click(object sender, EventArgs e)
    {
        linkButtonProcessDegis(3);
        paketGetir(secilenOlcu);
        pnlOlculer.Visible = false;
        pnlSeriList.Visible = false;
        pnlPaketler.Visible = true;
    }

    protected void lnlGerile2_Click(object sender, EventArgs e)
    {
        linkButtonProcessDegis(1);
        pnlOlculer.Visible = false;
        pnlSeriList.Visible = true;
    }

    public void paketGetir(int olcuID)
    {
        //int olcuTipi = Convert.ToInt32(e.CommandArgument);

        //secilenOlcu = olcuTipi;

        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT [paket_id], [paket_adi_tr], [paket_fotonew], [paket_sira_no], [paket_olcu], [paket_active],[paket_fiyatYeni] FROM[dbo].[paket] where [paket_olcu]=@paket_olcu and[paket_active] = 1 order by[paket_sira_no] ASC",
                    s))
            {
                c.Parameters.AddWithValue("@paket_olcu", olcuID);
                SqlDataReader r = c.ExecuteReader();

                rptPaketler.DataSource = r;
                rptPaketler.DataBind();
            }
        }
    }

    public void paketGetirRefresh()
    {
        //int olcuTipi = Convert.ToInt32(e.CommandArgument);

        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT [paket_id], [paket_adi_tr], [paket_fotonew], [paket_sira_no], [paket_olcu], [paket_active],[paket_fiyatYeni] FROM[dbo].[paket] where [paket_olcu]=@paket_olcu and[paket_active] = 1 order by[paket_sira_no] ASC",
                    s))
            {
                c.Parameters.AddWithValue("@paket_olcu", secilenOlcu);
                SqlDataReader r = c.ExecuteReader();

                rptPaketler.DataSource = r;
                rptPaketler.DataBind();
            }
        }
    }


    public void paketSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "paketEkle")
        {
            secilenKapak = 0;
            secilenKumas = 0;

            secilenPaket = Convert.ToInt32(e.CommandArgument);

            paketDbYaz(secilenPaket, "Ekle");
            siparisBilgileriPaket();

            paketGetirRefresh();

            foreach (RepeaterItem item in rptPaketler.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    ImageButton ib = (ImageButton) item.FindControl("imgBtnPaketSec");
                    Label title = (Label) item.FindControl("CartTitle");
                    Panel panel = (Panel) item.FindControl("paketPanel");
                    // Panel heading = (Panel) item.FindControl("paketPanelPeading");


                    if (Convert.ToInt32(ib.CommandArgument) == secilenPaket)
                    {
                        panel.CssClass += " paket-active kapak-pulse animated";
                        // heading.CssClass += " heading-active";
                        title.Text += " <i class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                        ib.CommandName = "paketCikart";
                        ib.CssClass += " active";


                        lnkIlerle3.Enabled = true;
                        lnkIlerle3.Text = "Sonraki Adım  &rArr;";
                        lnkIlerle3.CssClass = "button button-3d fright";
                        lnkIlerle4.Enabled = false;
                        lnkIlerle4.Text = "Seçim Yapınız...";
                        lnkIlerle4.CssClass = "button-deactive button-red button button-3d fright";
                        linkButtonProcessDegis(3);
                    }
                }
            }
        }

        else if (e.CommandName == "paketCikart")
        {
            paketDbYaz(secilenPaket, "Cikart");
            linkButtonProcessDegis(3);
            secilenPaket = 0;
            secilenKapak = 0;
            secilenKumas = 0;
            lnkIlerle3.Enabled = false;
            lnkIlerle3.Text = "Seçim yapınız...";
            lnkIlerle3.CssClass = "button-deactive button-red button button-3d fright";
            paketGetirRefresh();
            siparisBilgileriPaket();
        }

        ekstraSepetTemizle();
    }

    public void paketDbYaz(int paketID, string islem)
    {
        if (islem == "Ekle")
        {
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = cstring.ConnStr();
                c.Open();

                double fiyatYeni = 0;
                double fiyatIskontolu = 0;

                using (SqlCommand f = new SqlCommand("Select paket_fiyatYeni from paket where paket_id=@paket_id", c))
                {
                    f.Parameters.AddWithValue("@paket_id", paketID);

                    SqlDataReader r = f.ExecuteReader();
                    r.Read();

                    fiyatYeni = Convert.ToDouble(r["paket_fiyatYeni"]);
                    fiyatIskontolu = Convert.ToDouble(fiyatlar.fiyatBul.paketFiyat(paketID, memberID, "TL", 2));
                }

                using (SqlCommand s = new SqlCommand(
                    "IF NOT EXISTS(SELECT 1 from ordercartpaket where ordercartpaket_onumber=" + orderID + ")" +
                    " Insert INTO ordercartpaket (ordercartpaket_paketid, ordercartpaket_nfiyat, ordercartpaket_ifiyat, ordercartpaket_onumber, ordercartpaket_member, ordercartpaket_tarih) VALUES(@ordercartpaket_paketid, @ordercartpaket_nfiyat, @ordercartpaket_ifiyat, @ordercartpaket_onumber, @ordercartpaket_member, @ordercartpaket_tarih)" +
                    " else" +
                    " UPDATE ordercartpaket SET ordercartpaket_paketid=@ordercartpaket_paketid, ordercartpaket_nfiyat=@ordercartpaket_nfiyat, ordercartpaket_ifiyat=@ordercartpaket_ifiyat, ordercartpaket_onumber=@ordercartpaket_onumber, ordercartpaket_member=@ordercartpaket_member, ordercartpaket_tarih=@ordercartpaket_tarih WHERE ordercartpaket_onumber=" +
                    orderID + "", c))
                {
                    s.Parameters.AddWithValue("@ordercartpaket_paketid", secilenPaket);
                    s.Parameters.AddWithValue("@ordercartpaket_nfiyat", fiyatYeni);
                    s.Parameters.AddWithValue("@ordercartpaket_ifiyat", fiyatIskontolu);
                    s.Parameters.AddWithValue("@ordercartpaket_onumber", orderID);
                    s.Parameters.AddWithValue("@ordercartpaket_member", memberID);
                    s.Parameters.AddWithValue("@ordercartpaket_tarih", DateTime.Now);

                    s.ExecuteNonQuery();
                }
            }
        }

        else
        {
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = cstring.ConnStr();
                c.Open();

                using (SqlCommand s =
                    new SqlCommand("Delete from ordercartpaket where ordercartpaket_onumber=" + orderID + "", c))
                {
                    s.ExecuteNonQuery();
                }
            }
        }
    }

    protected void lnkIlerle3_Click(object sender, EventArgs e)
    {
        linkButtonProcessDegis(4);
        pnlPaketler.Visible = false;
        pnlKapaklar.Visible = true;
        kapakListesi(secilenPaket);
    }

    protected void lnlGerile3_Click(object sender, EventArgs e)
    {
        linkButtonProcessDegis(2);
        pnlPaketler.Visible = false;
        pnlOlculer.Visible = true;
    }

    public void kapakListesi(int paketID)
    {
        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT dbo.nurun.nurun_adi, dbo.nurunimage.nurunimage_path, dbo.nuruniliski.nuruniliski_paket, dbo.nurunimage.nurunimage_sira, dbo.nurun.nurun_sactive, dbo.nurun.nurun_kapakZorunlu, dbo.nurun.nurun_ahsapZorunlu, dbo.nurun.nurun_tarihZorunlu, dbo.nurun.nurun_id FROM  dbo.nurun INNER JOIN dbo.nuruniliski ON dbo.nurun.nurun_id = dbo.nuruniliski.nuruniliski_urun INNER JOIN dbo.nurunimage ON dbo.nurun.nurun_id = dbo.nurunimage.nurunimage_urunid WHERE(dbo.nuruniliski.nuruniliski_paket = @nuruniliski_paket) AND (dbo.nurunimage.nurunimage_sira = 1) AND (dbo.nurunimage.nurunimage_active = 1) AND(dbo.nurun.nurun_sactive = 1) order by dbo.nurun.nurun_adi ASC",
                    s))
            {
                c.Parameters.AddWithValue("@nuruniliski_paket", paketID);
                SqlDataReader r = c.ExecuteReader();

                rptKapaklar.DataSource = r;
                rptKapaklar.DataBind();
            }
        }
    }

    private DataTable kapakDT = new DataTable();
    public void kapakSec(Object Sender, RepeaterCommandEventArgs e)
    {
        string searchValue = "";

        if (e.CommandName == "kapakEkle")
        {
            secilenKumas = 0;
            secilenKapak = 0;

            searchValue = search.Value;

            string[] commandArgss = e.CommandArgument.ToString().Split(new char[] {','});

            secilenKapak = Convert.ToInt32(commandArgss[0]);
            secilenKapakAdi = commandArgss[1];

            kapakListesi(secilenPaket);
            urunKontrol(secilenKapak);

            search.Value = searchValue;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp55", "handelSearch('" + searchValue + "');", true);

            foreach (RepeaterItem item in rptKapaklar.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton si = (LinkButton) item.FindControl("searchInput");
                    LinkButton lb = (LinkButton) item.FindControl("lnkBtnKapakYazi");
                    ImageButton ib = (ImageButton) item.FindControl("imgBtnKapakFoto");
                    Panel pnl = (Panel) item.FindControl("kapakPanel");
                    Label lbl = (Label) item.FindControl("kapakLabel");
                    LinkButton lbEkle = (LinkButton)item.FindControl("lnkBtnKapakYazi");

                    string[] lbCA = lb.CommandArgument.ToString().Split(new char[] {','});
                    string[] IbCA = ib.CommandArgument.ToString().Split(new char[] {','});

                    if (Convert.ToInt32(lbCA[0]) == secilenKapak || Convert.ToInt32(IbCA[0]) == secilenKapak)
                    {
                        lbl.Text += "&nbsp;<i style=\"pointer-event:none\" class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                        lbl.ForeColor = System.Drawing.Color.Crimson;
                        lb.CommandName = "kapakCikart";
                        ib.CommandName = "kapakCikart";
                        pnl.CssClass = "thumbnail order-kapak kapak-active pulse animated";
                        lbEkle.Text = "<i style=\"pointer-events: none\" class=\"fas fa-cart-arrow-down fa-lg\"></i>&nbsp;Çıkart";
                        lbEkle.ForeColor = System.Drawing.Color.Crimson;


                        lnkIlerle4.Enabled = true;
                        lnkIlerle4.Text = "Sonraki Adım  &rArr;";
                        lnkIlerle4.CssClass = "button button-3d fright";
                        lnkIlerle5.Enabled = false;
                        lnkIlerle5.Text = "Seçim Yapınız...";
                        lnkIlerle5.CssClass = "button-deactive button-red button button-3d fright";
                        linkButtonProcessDegis(4);
                        siparisBilgileriGetir();
                    }
                }
            }
        }

        else if (e.CommandName == "kapakCikart")
        {
            searchValue = "";

            linkButtonProcessDegis(4);
            secilenKapak = 0;
            secilenKapakAdi = "";
            secilenKumas = 0;
            secilenKumasAdi = "";
            lnkIlerle4.Enabled = false;
            lnkIlerle4.Text = "Seçim Yapınız...";
            lnkIlerle4.CssClass = "button-deactive button-red button button-3d fright";
            kapakListesi(secilenPaket);
            siparisBilgileriGetir();

            ahsapZorunlu = 0;
            kapakZorunlu = 0;
            tarihZorunlu = 0;

            search.Value = searchValue;

            ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp56", "handelSearch('" + searchValue + "');", true);
        }

        else if (e.CommandName == "kapakDetay")
        {
            searchValue = search.Value;

            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = cstring.ConnStr();
                c.Open();

                using (SqlCommand kk = new SqlCommand("Select nurun_adi, nurun_kapakSablon from nurun where nurun_id=@nurun_id", c))
                {
                    kk.Parameters.AddWithValue("nurun_id", e.CommandArgument);

                    SqlDataReader rr = kk.ExecuteReader();

                    if (rr.HasRows)
                    {
                        rr.Read();

                        lblModalKapakAdi.InnerText = rr["nurun_adi"].ToString();
                        if (rr["nurun_kapakSablon"] != DBNull.Value || !string.IsNullOrEmpty(rr["nurun_kapakSablon"].ToString()))
                        {
                            lblModalKapakSablon.Visible = true;
                            lblModalKapakSablon.HRef = "/sablon/" + rr["nurun_kapakSablon"].ToString();
                        }
                        else
                        {
                            lblModalKapakSablon.Visible = false;
                        }

                    }
                }

                using (SqlCommand k = new SqlCommand("SELECT [nurunimage_id], [nurunimage_path], [nurunimage_urunid], [nurunimage_sira], [nurunimage_active] FROM[dbo].[nurunimage] where [nurunimage_urunid]=@nurunimage_urunid and [nurunimage_active]=1 order by [nurunimage_sira] ASC", c))
                {
                    k.Parameters.AddWithValue("nurunimage_urunid", e.CommandArgument);
                 
                    SqlDataAdapter da = new SqlDataAdapter(k);
                    da.Fill(kapakDT);

                    rptKapakModal.DataSource = kapakDT;
                    rptKapakModal.DataBind();

                    rptKapakModal2.DataSource = kapakDT;
                    rptKapakModal2.DataBind();

                    Thread.Sleep(100);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp12478", "openKModal();", true);

                    search.Value = searchValue;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp57", "handelSearch('" + searchValue + "');", true);
                }

            }
        }
    }

    public void urunKontrol(int kapakIDS)
    {
        using (SqlConnection c = new SqlConnection())
        {
            c.ConnectionString = cstring.ConnStr();
            c.Open();

            using (SqlCommand s = new SqlCommand("SELECT [nurun_kapakZorunlu], [nurun_ahsapZorunlu], [nurun_tarihZorunlu] FROM [dbo].[nurun] where nurun_id=@nurun_id", c))
            {
                s.Parameters.AddWithValue("@nurun_id", kapakIDS);

                SqlDataReader r = s.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();

                    ahsapZorunlu = Convert.ToInt32(r["nurun_ahsapZorunlu"]);
                    kapakZorunlu = Convert.ToInt32(r["nurun_kapakZorunlu"]);
                    tarihZorunlu = Convert.ToInt32(r["nurun_tarihZorunlu"]);
                }

                else
                {
                    ahsapZorunlu = 0;
                    kapakZorunlu = 0;
                    tarihZorunlu = 0;
                }
            }
        }
    }

    protected void lnkIlerle4_Click(object sender, EventArgs e)
    {
        pnlKapaklar.Visible = false;
        pnlKumaslar.Visible = true;
        //pnlKumasImg.Visible = true;

        kumasKapakListesi();
        kumasListesi();
        ahsapListesi();
        linkButtonProcessDegis(5);
    }

    protected void lnlGerile4_Click(object sender, EventArgs e)
    {
        linkButtonProcessDegis(3);
        pnlPaketler.Visible = true;
        pnlKapaklar.Visible = false;
    }

    private DataTable dataTable = new DataTable();

    public void kumasKapakListesi()
    {
        //using (SqlConnection s = new SqlConnection())
        //{
        //    s.ConnectionString = cstring.ConnStr();
        //    s.Open();

        //    using (SqlCommand c =
        //        new SqlCommand(
        //            "SELECT [nurunimage_id], [nurunimage_path], [nurunimage_urunid], [nurunimage_sira], [nurunimage_active] FROM[dbo].[nurunimage] where [nurunimage_urunid]=@nurunimage_urunid and [nurunimage_active]=1 order by [nurunimage_sira] ASC",
        //            s))
        //    {
        //        c.Parameters.AddWithValue("@nurunimage_urunid", secilenKapak);
        //        //SqlDataReader r = c.ExecuteReader();

        //        SqlDataAdapter da = new SqlDataAdapter(c);
        //        da.Fill(dataTable);

        //        rptKumasKapak.DataSource = dataTable;
        //        rptKumasKapak.DataBind();
        //        rptKumasKapak1.DataSource = dataTable;
        //        rptKumasKapak1.DataBind();
        //    }
        //}
    }

    public void kumasListesi()
    {
        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT dbo.nkumaslar.nkumaslar_id, dbo.nkumaslar.nkumaslar_adi, dbo.nkumaslar.nkumaslar_active, dbo.nkumaslar.nkumaslar_path, dbo.nkumaslar.nkumaslar_sira, dbo.nkumasiliski.nkumasiliski_urun FROM  dbo.nkumaslar INNER JOIN                         dbo.nkumasiliski ON dbo.nkumaslar.nkumaslar_id = dbo.nkumasiliski.nkumasiliski_kumas WHERE(dbo.nkumasiliski.nkumasiliski_urun = @nkumasiliski_urun) AND(dbo.nkumaslar.nkumaslar_active = 1) order by nkumaslar_sira ASC",
                    s))
            {
                c.Parameters.AddWithValue("@nkumasiliski_urun", secilenKapak);
                SqlDataReader r = c.ExecuteReader();

                rptKumaslar.DataSource = r;
                rptKumaslar.DataBind();
            }
        }
    }

    public void kumasSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "kumasEkle")
        {
            secilenKumas = 0;
            secilenKumasAdi = "";

            string[] commandArgss = e.CommandArgument.ToString().Split(new char[] {','});

            secilenKumas = Convert.ToInt32(commandArgss[0]);
            secilenKumasAdi = commandArgss[1];

            kumasListesi();
            

            foreach (RepeaterItem item in rptKumaslar.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lb = (LinkButton) item.FindControl("lnkBtnKumas");
                    ImageButton ib = (ImageButton) item.FindControl("imgBtnKumas");
                    Panel pnl = (Panel) item.FindControl("kumas");

                    string[] lbCA = lb.CommandArgument.ToString().Split(new char[] {','});
                    string[] IbCA = ib.CommandArgument.ToString().Split(new char[] {','});

                    if (Convert.ToInt32(lbCA[0]) == secilenKumas || Convert.ToInt32(IbCA[0]) == secilenKumas)
                    {
                        //lb.Text = " Seçildi!";
                        //lb.Font.Bold = true;
                        pnl.CssClass += " kumas-active";
                        // lb.ForeColor = System.Drawing.Color.Crimson;
                        lb.CommandName = "kumasCikart";
                        ib.CommandName = "kumasCikart";
                        ib.CssClass += " flip animated";
                        lb.CssClass += " flip animated";
                        //pnl.CssClass = "thumbnail order-kapak kapak-active";

                        kademe5Butonlar();

                        linkButtonProcessDegis(5);
                        siparisBilgileriGetir();
                    }
                }
            }
        }

        else if (e.CommandName == "kumasCikart")
        {
            linkButtonProcessDegis(5);
            secilenKumas = 0;
            secilenKumasAdi = "";
            kademe5Butonlar();
            kumasListesi();
            siparisBilgileriGetir();
        }
    }


    public void ahsapListesi()
    {
        if (ahsapZorunlu == 1)
        {
            ahsaplar.Visible = true;
            using (SqlConnection s = new SqlConnection())
            {
                s.ConnectionString = cstring.ConnStr();
                s.Open();

                using (SqlCommand c =
                    new SqlCommand(
                        "SELECT dbo.nahsap.nahsap_id, dbo.nahsap.nahsap_adi, dbo.nahsap.nahsap_kisaad, dbo.nahsap.nahsap_image, dbo.nahsap.nahsap_active, dbo.nahsapiliski.nahsapiliski_urun FROM dbo.nahsap INNER JOIN dbo.nahsapiliski ON dbo.nahsap.nahsap_id = dbo.nahsapiliski.nahsapiliski_ahsap WHERE(dbo.nahsap.nahsap_active = 1) AND(dbo.nahsapiliski.nahsapiliski_urun=@nahsapiliski_urun) order by dbo.nahsap.nahsap_sira ASC",
                        s))
                {
                    c.Parameters.AddWithValue("@nahsapiliski_urun", secilenKapak);
                    SqlDataReader r = c.ExecuteReader();

                    rptAhsap.DataSource = r;
                    rptAhsap.DataBind();
                }
            }
        }
        else
        {
            ahsaplar.Visible = false;
        }

    }

    public void ahsapSec(Object Sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "ahsapEkle")
        {
            secilenAhsap = 0;
            secilenAhsapAdi = "";

            string[] commandArgss = e.CommandArgument.ToString().Split(new char[] { ',' });

            secilenAhsap = Convert.ToInt32(commandArgss[0]);
            secilenAhsapAdi = commandArgss[1];

            ahsapListesi();

            foreach (RepeaterItem item in rptAhsap.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    LinkButton lb = (LinkButton)item.FindControl("lnkBtnAhsap");
                    ImageButton ib = (ImageButton)item.FindControl("imgBtnAhsap");
                    Panel pnl = (Panel)item.FindControl("ahsapPanel");

                    string[] lbCA = lb.CommandArgument.ToString().Split(new char[] { ',' });
                    string[] IbCA = ib.CommandArgument.ToString().Split(new char[] { ',' });

                    if (Convert.ToInt32(lbCA[0]) == secilenAhsap || Convert.ToInt32(IbCA[0]) == secilenAhsap)
                    {
                        pnl.CssClass += " kapak-active pulse animated";
                        lb.Text += "&nbsp;<i style=\"pointer-event:none\" class=\"fa fa-check\" aria-hidden=\"true\"></i>";
                        lb.ForeColor = System.Drawing.Color.Crimson;
                        lb.CommandName = "ahsapCikart";
                        ib.CommandName = "ahsapCikart";
                        kademe5Butonlar();

                        linkButtonProcessDegis(5);
                        siparisBilgileriGetir();
                    }
                }
            }
        }

        else if (e.CommandName == "ahsapCikart")
        {
            linkButtonProcessDegis(5);
            secilenAhsap = 0;
            secilenAhsapAdi = "";
            kademe5Butonlar();
            ahsapListesi();
            siparisBilgileriGetir();
        }
    }

    public void kademe5Butonlar()
    {
        if (secilenAhsap != 0 && secilenKumas != 0 && ahsapZorunlu == 1)
        {
            lnkIlerle5.Enabled = true;
            lnkIlerle5.Text = "Sonraki Adım  &rArr;";
            lnkIlerle5.CssClass = "button button-3d fright";
        }

        else if (secilenKumas != 0 && ahsapZorunlu == 0)
        {
            lnkIlerle5.Enabled = true;
            lnkIlerle5.Text = "Sonraki Adım  &rArr;";
            lnkIlerle5.CssClass = "button button-3d fright";
        }
        else
        {
            lnkIlerle5.Enabled = false;
            lnkIlerle5.Text = "Seçim Yapınız...";
            lnkIlerle5.CssClass = "button-deactive button-red button button-3d fright";
        }



    }
    protected void lnlIlerle5_Click(object sender, EventArgs e)
    {
        linkButtonProcessDegis(6);
        pnlKumaslar.Visible = false;
        //pnlKumasImg.Visible = false;
        pnlEkstralar.Visible = true;
        ekstraListesi();
        ekstraGruplarDefault();
    }

    protected void lnlGerile5_Click(object sender, EventArgs e)
    {
        kapakListesi(secilenPaket);
        linkButtonProcessDegis(4);
        pnlKumaslar.Visible = false;
        //pnlKumasImg.Visible = false;
        pnlKapaklar.Visible = true;
    }

    public void ekstraGruplarDefault()
    {
        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT top 1 dbo.npaketextragruplar.npaketextragruplar_id, dbo.npaketextragruplar.npaketextragruplar_adi, dbo.npaketextragruplar.npaketextragruplar_sira FROM dbo.npaketextragruplar INNER JOIN dbo.paketextra ON dbo.npaketextragruplar.npaketextragruplar_id = dbo.paketextra.paketextra_ngrup INNER JOIN dbo.paketextraalt ON dbo.paketextra.paketextra_id = dbo.paketextraalt.paketextraalt_iliski WHERE(dbo.npaketextragruplar.npaketextragruplar_active = 1) AND (dbo.paketextraalt.paketextraalt_paket=@paketextraalt_paket) order by dbo.npaketextragruplar.npaketextragruplar_sira ASC",
                    s))
            {
                c.Parameters.AddWithValue("@paketextraalt_paket", secilenPaket);
                SqlDataReader r = c.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();

                    if (grupEkstraID == 0)
                    {
                        grupEkstraID = Convert.ToInt32(r["npaketextragruplar_id"]);
                    }
                }

                ekstraListeSec();
            }
        }
    }

    public void ekstraGruplar()
    {
        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT distinct dbo.npaketextragruplar.npaketextragruplar_id, dbo.npaketextragruplar.npaketextragruplar_adi, dbo.npaketextragruplar.npaketextragruplar_sira FROM            dbo.npaketextragruplar INNER JOIN dbo.paketextra ON dbo.npaketextragruplar.npaketextragruplar_id = dbo.paketextra.paketextra_ngrup INNER JOIN dbo.paketextraalt ON dbo.paketextra.paketextra_id = dbo.paketextraalt.paketextraalt_iliski WHERE(dbo.npaketextragruplar.npaketextragruplar_active = 1) AND(dbo.paketextraalt.paketextraalt_paket =@paketextraalt_paket)  order by 3",
                    s))
            {
                c.Parameters.AddWithValue("@paketextraalt_paket", secilenPaket);
                SqlDataReader r = c.ExecuteReader();

                rptEkstraGruplar.DataSource = r;
                rptEkstraGruplar.DataBind();
            }
        }
    }

    public void ekstraListesi()
    {
        ekstraGruplar();

        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT [npaketextragruplar_id], [npaketextragruplar_adi], [npaketextragruplar_aciklama], [npaketextragruplar_sira],[npaketextragruplar_active] FROM[dbo].[npaketextragruplar] where [npaketextragruplar_active]=1 order by [npaketextragruplar_sira] ASC",
                    s))
            {
                SqlDataReader r = c.ExecuteReader();

                ParentRepeater.DataSource = r;
                ParentRepeater.DataBind();
            }
        }
    }

    public void ekstraListeSec()
    {
        //ScriptManager.RegisterStartupScript(this, GetType(), "ekstraListeGrupSec", "extraTab('tab-responsive-5');", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "popUp2455", "extraTab('" + grupEkstraID + "');", true);
    }

    protected void ItemBound(object sender, RepeaterItemEventArgs args)
    {
        int grupID = 0;

        if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
        {
            HiddenField hf = (HiddenField) args.Item.FindControl("hdnPaketGruplarID");
            HiddenField hfAdi = (HiddenField) args.Item.FindControl("hdnPaketGruplarIDAdi");

            grupID = Convert.ToInt32(hf.Value);
            grupAdi = hfAdi.Value;

            Repeater childRepeater = (Repeater) args.Item.FindControl("ChildRepeater");

            using (SqlConnection s = new SqlConnection())
            {
                s.ConnectionString = cstring.ConnStr();
                s.Open();

                using (SqlCommand c =
                    new SqlCommand(
                        "SELECT dbo.paketextraalt.paketextraalt_paket, dbo.paketextra.paketextra_id, dbo.paketextra.paketextra_adi, dbo.paketextra.paketextra_image, dbo.paketextra.paketextra_fiyatYeni, dbo.paketextra.paketextra_ngrup,                    dbo.paketextra.paketextra_sira, dbo.paketextra.paketextra_aciklama, dbo.paketextra.paketextra_active FROM            dbo.paketextraalt INNER JOIN dbo.paketextra ON dbo.paketextraalt.paketextraalt_iliski = dbo.paketextra.paketextra_id WHERE(dbo.paketextraalt.paketextraalt_paket=@paketextraalt_paket) AND (dbo.paketextra.paketextra_active = 1) AND (dbo.paketextra.paketextra_ngrup=@paketextra_ngrup) order by paketextra_ngrup, paketextra_sira ASC",
                        s))
                {
                    c.Parameters.AddWithValue("@paketextraalt_paket", secilenPaket);
                    c.Parameters.AddWithValue("@paketextra_ngrup", grupID);
                    SqlDataReader r = c.ExecuteReader();

                    if (r.HasRows)
                    {
                        childRepeater.Visible = true;
                        childRepeater.DataSource = r;
                        childRepeater.DataBind();
                    }
                    else
                    {
                        childRepeater.Visible = false;
                        childRepeater.DataSource = r;
                        childRepeater.DataBind();
                    }
                }
            }
        }
    }


    public void ekstraSec(Object Sender, RepeaterCommandEventArgs e)
    {
        int ekstraID = Convert.ToInt32(e.CommandArgument);
        string ekstraAdi = "";

        using (SqlConnection c = new SqlConnection())
        {
            c.ConnectionString = cstring.ConnStr();
            c.Open();

            double fiyatYeni = 0;
            double fiyatIskontolu = 0;
            int adet = 0;

            using (SqlCommand f =
                new SqlCommand(
                    "Select paketextra_adi, paketextra_fiyatYeni, paketextra_ngrup from paketextra where paketextra_id=@paketextra_id",
                    c))
            {
                f.Parameters.AddWithValue("@paketextra_id", ekstraID);

                SqlDataReader r = f.ExecuteReader();
                r.Read();

                ekstraAdi = r["paketextra_adi"].ToString();
                fiyatYeni = Convert.ToDouble(r["paketextra_fiyatYeni"]);
                fiyatIskontolu =
                    Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(secilenPaket, ekstraID,
                        Convert.ToInt32(memberID), "TL", 2));
                grupEkstraID = Convert.ToInt32(r["paketextra_ngrup"]);
            }

            using (SqlCommand ff =
                new SqlCommand(
                    "SELECT * from ordercartekstra where ordercartekstra_onumber=" + orderID +
                    " and ordercartekstra_ekstraid=" + ekstraID + "", c))
            {
                SqlDataReader rr = ff.ExecuteReader();

                if (rr.HasRows)
                {
                    rr.Read();

                    if (e.CommandName == "ekstraEkle")
                    {
                        adet = Convert.ToInt32(rr["ordercartekstra_adet"]) + 1;
                    }
                    else
                    {
                        adet = Convert.ToInt32(rr["ordercartekstra_adet"]) - 1;
                    }
                }
                else
                {
                    if (e.CommandName == "ekstraEkle")
                    {
                        adet = 1;
                    }
                    else
                    {
                        adet = 0;
                    }
                }
            }

            if (adet == 0)
            {
                try
                {
                    using (SqlCommand f =
                        new SqlCommand(
                            "Delete from ordercartekstra where ordercartekstra_onumber=" + orderID +
                            " and ordercartekstra_ekstraid=" + ekstraID + "", c))
                    {
                        f.Parameters.AddWithValue("@paketextra_id", ekstraID);
                        f.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                using (SqlCommand s = new SqlCommand(
                    "IF NOT EXISTS(SELECT 1 from ordercartekstra where ordercartekstra_onumber=" + orderID +
                    " and ordercartekstra_ekstraid=" + ekstraID + ")" +
                    " INSERT INTO [dbo].[ordercartekstra] (ordercartekstra_ekstraid, ordercartekstra_ekstraadi, ordercartekstra_nfiyat, ordercartekstra_ifiyat, ordercartekstra_onumber, ordercartekstra_member, ordercartekstra_tarih, ordercartekstra_adet) VALUES (@ordercartekstra_ekstraid, @ordercartekstra_ekstraadi, @ordercartekstra_nfiyat, @ordercartekstra_ifiyat, @ordercartekstra_onumber, @ordercartekstra_member, @ordercartekstra_tarih, @ordercartekstra_adet)" +
                    " else" +
                    " UPDATE dbo.ordercartekstra SET ordercartekstra_ekstraid=@ordercartekstra_ekstraid, ordercartekstra_ekstraadi=@ordercartekstra_ekstraadi, ordercartekstra_nfiyat=@ordercartekstra_nfiyat, ordercartekstra_ifiyat=@ordercartekstra_ifiyat, ordercartekstra_onumber=@ordercartekstra_onumber, ordercartekstra_member=@ordercartekstra_member, ordercartekstra_tarih=@ordercartekstra_tarih, ordercartekstra_adet=@ordercartekstra_adet WHERE ordercartekstra_onumber=" +
                    orderID + " and ordercartekstra_ekstraid=" + ekstraID + "", c))
                {
                    s.Parameters.AddWithValue("@ordercartekstra_ekstraid", ekstraID);
                    s.Parameters.AddWithValue("@ordercartekstra_ekstraadi", ekstraAdi);
                    s.Parameters.AddWithValue("@ordercartekstra_nfiyat", fiyatYeni * adet);
                    s.Parameters.AddWithValue("@ordercartekstra_ifiyat", fiyatIskontolu * adet);
                    s.Parameters.AddWithValue("@ordercartekstra_onumber", orderID);
                    s.Parameters.AddWithValue("@ordercartekstra_member", memberID);
                    s.Parameters.AddWithValue("@ordercartekstra_tarih", DateTime.Now);
                    s.Parameters.AddWithValue("@ordercartekstra_adet", adet);
                    s.ExecuteNonQuery();
                }
            }
        }

        ekstraListesi();
        siparisBilgileriEkstra();
        ekstraListeSec();
    }

    public void ekstraSecCart(Object Sender, RepeaterCommandEventArgs e)
    {
        int ekstraID = Convert.ToInt32(e.CommandArgument);
        string ekstraAdi = "";

        using (SqlConnection c = new SqlConnection())
        {
            c.ConnectionString = cstring.ConnStr();
            c.Open();

            double fiyatYeni = 0;
            double fiyatIskontolu = 0;
            int adet = 0;

            using (SqlCommand f =
                new SqlCommand(
                    "Select paketextra_adi, paketextra_fiyatYeni, paketextra_ngrup from paketextra where paketextra_id=@paketextra_id",
                    c))
            {
                f.Parameters.AddWithValue("@paketextra_id", ekstraID);

                SqlDataReader r = f.ExecuteReader();
                r.Read();

                ekstraAdi = r["paketextra_adi"].ToString();
                fiyatYeni = Convert.ToDouble(r["paketextra_fiyatYeni"]);
                fiyatIskontolu =
                    Convert.ToDouble(fiyatlar.fiyatBul.paketExtraFiyat(secilenPaket, ekstraID,
                        Convert.ToInt32(memberID), "TL", 2));
                grupEkstraID = Convert.ToInt32(r["paketextra_ngrup"]);
            }

            using (SqlCommand ff =
                new SqlCommand(
                    "SELECT * from ordercartekstra where ordercartekstra_onumber=" + orderID +
                    " and ordercartekstra_ekstraid=" + ekstraID + "", c))
            {
                SqlDataReader rr = ff.ExecuteReader();

                if (rr.HasRows)
                {
                    rr.Read();

                    if (e.CommandName == "ekstraEkleCart")
                    {
                        adet = Convert.ToInt32(rr["ordercartekstra_adet"]) + 1;
                    }
                    else
                    {
                        adet = Convert.ToInt32(rr["ordercartekstra_adet"]) - 1;
                    }
                }
                else
                {
                    if (e.CommandName == "ekstraEkleCart")
                    {
                        adet = 1;
                    }
                    else
                    {
                        adet = 0;
                    }
                }
            }

            if (adet == 0)
            {
                try
                {
                    using (SqlCommand f =
                        new SqlCommand(
                            "Delete from ordercartekstra where ordercartekstra_onumber=" + orderID +
                            " and ordercartekstra_ekstraid=" + ekstraID + "", c))
                    {
                        f.Parameters.AddWithValue("@paketextra_id", ekstraID);
                        f.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                }
            }
            else
            {
                using (SqlCommand s = new SqlCommand(
                    "IF NOT EXISTS(SELECT 1 from ordercartekstra where ordercartekstra_onumber=" + orderID +
                    " and ordercartekstra_ekstraid=" + ekstraID + ")" +
                    " INSERT INTO [dbo].[ordercartekstra] (ordercartekstra_ekstraid, ordercartekstra_ekstraadi, ordercartekstra_nfiyat, ordercartekstra_ifiyat, ordercartekstra_onumber, ordercartekstra_member, ordercartekstra_tarih, ordercartekstra_adet) VALUES (@ordercartekstra_ekstraid, @ordercartekstra_ekstraadi, @ordercartekstra_nfiyat, @ordercartekstra_ifiyat, @ordercartekstra_onumber, @ordercartekstra_member, @ordercartekstra_tarih, @ordercartekstra_adet)" +
                    " else" +
                    " UPDATE dbo.ordercartekstra SET ordercartekstra_ekstraid=@ordercartekstra_ekstraid, ordercartekstra_ekstraadi=@ordercartekstra_ekstraadi, ordercartekstra_nfiyat=@ordercartekstra_nfiyat, ordercartekstra_ifiyat=@ordercartekstra_ifiyat, ordercartekstra_onumber=@ordercartekstra_onumber, ordercartekstra_member=@ordercartekstra_member, ordercartekstra_tarih=@ordercartekstra_tarih, ordercartekstra_adet=@ordercartekstra_adet WHERE ordercartekstra_onumber=" +
                    orderID + " and ordercartekstra_ekstraid=" + ekstraID + "", c))
                {
                    s.Parameters.AddWithValue("@ordercartekstra_ekstraid", ekstraID);
                    s.Parameters.AddWithValue("@ordercartekstra_ekstraadi", ekstraAdi);
                    s.Parameters.AddWithValue("@ordercartekstra_nfiyat", fiyatYeni * adet);
                    s.Parameters.AddWithValue("@ordercartekstra_ifiyat", fiyatIskontolu * adet);
                    s.Parameters.AddWithValue("@ordercartekstra_onumber", orderID);
                    s.Parameters.AddWithValue("@ordercartekstra_member", memberID);
                    s.Parameters.AddWithValue("@ordercartekstra_tarih", DateTime.Now);
                    s.Parameters.AddWithValue("@ordercartekstra_adet", adet);
                    s.ExecuteNonQuery();
                }
            }
        }

        ekstraListesi();
        siparisBilgileriEkstra();
        ekstraListeSec();
    }

    public string ekstraFiyatKarsilastir(string fiyat1, string fiyat2)
    {
        string donus = "";

        if (Convert.ToDouble(fiyat1) != Convert.ToDouble(fiyat2))
        {
            donus = Convert.ToDouble(fiyat1).ToString("N") + "&nbsp;<i class=\"fa fa-try\"></i>";
        }

        return donus;
    }


    public void ekstraSepetTemizle()
    {
        try
        {
            using (SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = cstring.ConnStr();
                c.Open();

                using (SqlCommand s =
                    new SqlCommand(
                        "DELETE FROM [dbo].[ordercartekstra] WHERE ordercartekstra_onumber=@ordercartekstra_onumber and ordercartekstra_member=@ordercartekstra_member ",
                        c))
                {
                    s.Parameters.AddWithValue("@ordercartekstra_onumber", orderID);
                    s.Parameters.AddWithValue("@ordercartekstra_member", memberID);
                    s.ExecuteNonQuery();
                }
            }
        }
        catch (Exception)
        {
        }

        ekstraListesi();
        siparisBilgileriEkstra();
        ekstraListeSec();
    }

    public string mevcutEkstraSayi(int ekstraID)
    {
        string donus = "0";

        using (SqlConnection c = new SqlConnection())
        {
            c.ConnectionString = cstring.ConnStr();
            c.Open();

            using (SqlCommand ff =
                new SqlCommand(
                    "SELECT * from ordercartekstra where ordercartekstra_onumber=" + orderID +
                    " and ordercartekstra_ekstraid=" + ekstraID + "", c))
            {
                SqlDataReader rr = ff.ExecuteReader();

                if (rr.HasRows)
                {
                    rr.Read();

                    donus = rr["ordercartekstra_adet"].ToString();
                }
                else
                {
                    donus = "0";
                }
            }
        }

        return donus;
    }

    protected void lnlIlerle6_Click(object sender, EventArgs e)
    {
    }

    protected void lnlGerile6_Click(object sender, EventArgs e)
    {
        kapakListesi(secilenPaket);
        linkButtonProcessDegis(5);
        pnlKumaslar.Visible = true;
        //pnlKumasImg.Visible = true;
        pnlEkstralar.Visible = false;
    }


    public string olcuButonRenklendir(int olcuID)
    {
        string donus = "";

        if (olcuID == secilenOlcu)
        {
            donus = " active";
        }
        else
        {
            donus = "";
        }

        return donus;
    }

    public string isActive(int state, int olcuID)
    {
        if (olcuID == state)
            return "btn-serial-size active";
        else
            return "btn-serial-size";
    }

    public string paketPanelRenklendir(int paketID)
    {
        string donus = "";

        if (paketID == secilenPaket)
        {
            //  donus = "paket-panel-heading heading-active";
        }
        else
        {
            //  donus = "paket-panel-heading";
        }

        return donus;
    }

    public void linkButtonProcessDegis(int butonID)
    {
        if (butonID == 1)
        {
            lnkBtnProcess1.Enabled = true;
            process1.Attributes["class"] = " active";
            process2.Attributes["class"] = "";
            process3.Attributes["class"] = "";
            process4.Attributes["class"] = "";
            process5.Attributes["class"] = "";
            process6.Attributes["class"] = "";
            process7.Attributes["class"] = "";
            process8.Attributes["class"] = "";
            process9.Attributes["class"] = "";
        }
        else if (butonID == 2)
        {
            lnkBtnProcess2.Enabled = true;
            process1.Attributes["class"] = "";
            process2.Attributes["class"] = " active";
            process3.Attributes["class"] = "";
            process4.Attributes["class"] = "";
            process5.Attributes["class"] = "";
            process6.Attributes["class"] = "";
            process7.Attributes["class"] = "";
            process8.Attributes["class"] = "";
            process9.Attributes["class"] = "";
        }
        else if (butonID == 3)
        {
            lnkBtnProcess3.Enabled = true;
            process1.Attributes["class"] = "";
            process2.Attributes["class"] = "";
            process3.Attributes["class"] = " active";
            process4.Attributes["class"] = "";
            process5.Attributes["class"] = "";
            process6.Attributes["class"] = "";
            process7.Attributes["class"] = "";
            process8.Attributes["class"] = "";
            process9.Attributes["class"] = "";
        }
        else if (butonID == 4)
        {
            lnkBtnProcess4.Enabled = true;
            process1.Attributes["class"] = "";
            process2.Attributes["class"] = "";
            process3.Attributes["class"] = "";
            process4.Attributes["class"] = "active";
            process5.Attributes["class"] = "";
            process6.Attributes["class"] = "";
            process7.Attributes["class"] = "";
            process8.Attributes["class"] = "";
            process9.Attributes["class"] = "";
        }
        else if (butonID == 5)
        {
            lnkBtnProcess5.Enabled = true;
            process1.Attributes["class"] = "";
            process2.Attributes["class"] = "";
            process3.Attributes["class"] = "";
            process4.Attributes["class"] = "";
            process5.Attributes["class"] = " active";
            process6.Attributes["class"] = "";
            process7.Attributes["class"] = "";
            process8.Attributes["class"] = "";
            process9.Attributes["class"] = "";
        }
        else if (butonID == 6)
        {
            lnkBtnProcess6.Enabled = true;
            process1.Attributes["class"] = "";
            process2.Attributes["class"] = "";
            process3.Attributes["class"] = "";
            process4.Attributes["class"] = "";
            process5.Attributes["class"] = "";
            process6.Attributes["class"] = " active";
            process7.Attributes["class"] = "";
            process8.Attributes["class"] = "";
            process9.Attributes["class"] = "";
        }
        else if (butonID == 7)
        {
            lnkBtnProcess7.Enabled = true;
            process1.Attributes["class"] = "";
            process2.Attributes["class"] = "";
            process3.Attributes["class"] = "";
            process4.Attributes["class"] = "";
            process5.Attributes["class"] = "";
            process6.Attributes["class"] = "";
            process7.Attributes["class"] = " active";
            process8.Attributes["class"] = "";
            process9.Attributes["class"] = "";
        }
        else if (butonID == 8)
        {
            lnkBtnProcess8.Enabled = true;
            process1.Attributes["class"] = "";
            process2.Attributes["class"] = "";
            process3.Attributes["class"] = "";
            process4.Attributes["class"] = "";
            process5.Attributes["class"] = "";
            process6.Attributes["class"] = "";
            process7.Attributes["class"] = "";
            process8.Attributes["class"] = " active";
            process9.Attributes["class"] = "";
        }
        else if (butonID == 9)
        {
            lnkBtnProcess9.Enabled = true;
            process1.Attributes["class"] = "";
            process2.Attributes["class"] = "";
            process3.Attributes["class"] = "";
            process4.Attributes["class"] = "";
            process5.Attributes["class"] = "";
            process6.Attributes["class"] = "";
            process7.Attributes["class"] = "";
            process8.Attributes["class"] = "";
            process9.Attributes["class"] = " active";
        }
    }

    public bool fiyatGosterIskontolu(string nfiyat, string ifiyat)
    {
        bool donus = false;

        if (nfiyat == ifiyat)
        {
            donus = false;
        }

        else
        {
            donus = true;
        }

        return donus;
    }

    public string paketAltGetir(int paketID)
    {
        paketAlt.paketAlt x = new paketAlt.paketAlt();

        return x.paketAltDon(paketID, 0);
    }

    public void siparisBilgileriGetir()
    {
        if (secilenSeri != 0)
        {
            dvSeriAdi.Visible = true;
            emptyCart.Visible = false;
            sepetSeriAdi.Text = secilenSeriAdi;
        }
        else
        {
            emptyCart.Visible = true;
            dvSeriAdi.Visible = false;
            sepetSeriAdi.Text = "";
        }

        if (secilenOlcu != 0)
        {
            dvOlcuAdi.Visible = true;
            sepetOlcuAdi.Text = secilenOlcuAdi;
        }
        else
        {
            dvOlcuAdi.Visible = false;
            sepetOlcuAdi.Text = "";
        }

        if (secilenKapak != 0)
        {
            dvKapakAdi.Visible = true;
            sepetKapakAdi.Text = secilenKapakAdi;
        }
        else
        {
            dvKapakAdi.Visible = false;
            sepetKapakAdi.Text = "";
        }

        if (secilenKumas != 0)
        {
            dvKumasAdi.Visible = true;
            sepetKumasAdi.Text = secilenKumasAdi;
        }
        else
        {
            dvKumasAdi.Visible = false;
            sepetKumasAdi.Text = "";
        }
        if (secilenAhsap != 0)
        {
            dvAhsapAdi.Visible = true;
            sepetAhsapAdi.Text = secilenAhsapAdi;
        }
        else
        {
            dvAhsapAdi.Visible = false;
            sepetAhsapAdi.Text = "";
        }
    }

    public void siparisBilgileriPaket()
    {
        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT dbo.paket.paket_adi_tr, dbo.ordercartpaket.ordercartpaket_nfiyat, dbo.ordercartpaket.ordercartpaket_ifiyat, dbo.ordercartpaket.ordercartpaket_onumber FROM dbo.paket INNER JOIN dbo.ordercartpaket ON dbo.paket.paket_id = dbo.ordercartpaket.ordercartpaket_paketid WHERE(dbo.ordercartpaket.ordercartpaket_onumber=@ordercartpaket_onumber)",
                    s))
            {
                c.Parameters.AddWithValue("@ordercartpaket_onumber", orderID);
                SqlDataReader r = c.ExecuteReader();

                if (r.HasRows)
                {
                    r.Read();

                    dvPaketAdi.Visible = true;

                    double yeniFiyat1 = Convert.ToDouble(r["ordercartpaket_nfiyat"]);
                    double yeniFiyat2 = Convert.ToDouble(r["ordercartpaket_ifiyat"]);

                    sepetPaketAdi.Text = r["paket_adi_tr"].ToString();
                    if (yeniFiyat1 == yeniFiyat2)
                    {
                        sepetPaketFiyat1.Text = "";
                        sepetPaketFiyat2.Text = yeniFiyat2.ToString("N") + "&nbsp;<i class=\"fa fa-try\"></i>";
                    }

                    else
                    {
                        sepetPaketFiyat1.Text =
                            yeniFiyat1.ToString("N") +
                            "&nbsp;<i class=\"fa fa-try\"></i>"; //iskonto varsa bu labelin fiyatı çizgili olacak
                        sepetPaketFiyat2.Text = yeniFiyat2.ToString("N") + "&nbsp;<i class=\"fa fa-try\"></i>";
                    }
                }

                else
                {
                    dvPaketAdi.Visible = false;

                    sepetPaketAdi.Text = "";
                    sepetPaketFiyat2.Text = "";
                }
            }
        }
    }

    public void siparisBilgileriEkstra()
    {
        using (SqlConnection s = new SqlConnection())
        {
            s.ConnectionString = cstring.ConnStr();
            s.Open();

            using (SqlCommand c =
                new SqlCommand(
                    "SELECT [ordercartekstra_id], [ordercartekstra_ekstraid], [ordercartekstra_ekstraadi], [ordercartekstra_adet], [ordercartekstra_nfiyat], [ordercartekstra_ifiyat], [ordercartekstra_onumber], [ordercartekstra_member] FROM[dbo].[ordercartekstra] where [ordercartekstra_onumber]=@ordercartekstra_onumber and ordercartekstra_member=@ordercartekstra_member order by [ordercartekstra_id] ASC",
                    s))
            {
                c.Parameters.AddWithValue("@ordercartekstra_onumber", orderID);
                c.Parameters.AddWithValue("@ordercartekstra_member", memberID);
                SqlDataReader r = c.ExecuteReader();

                if (r.HasRows)
                {
                    pnlEkstraAdi.Visible = true;

                    rptEkstraAdi.DataSource = r;
                    rptEkstraAdi.DataBind();
                }

                else
                {
                    pnlEkstraAdi.Visible = false;
                }
            }
        }
    }
}