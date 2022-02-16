using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace fiyatlar
{ 
public class fiyatBul
{

   public static string paketFiyat(int paketID, int musterID, string paraBirimi, int donusTipi) // 0-Paket liste sayfası için // 1-düz fiyat dönüşü 
    {

            string donus = "";

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sqlMem = "Select mid, m_iskonto from member where mid = @memberID";

            SqlCommand c = new SqlCommand(sqlMem, bag);
            c.Parameters.AddWithValue("@memberID", musterID);

            SqlDataReader rdr = c.ExecuteReader();

            rdr.Read();

            string sqlPaket = "";
            double iskFiyat;

            if (Convert.ToInt32(rdr["m_iskonto"]) == 0 || Convert.ToInt32(rdr["m_iskonto"]) == 2) // yeni/eski fiyat iskonto yok
            {
                sqlPaket = "Select paket_id, paket_fiyatYeni, paket_fiyat from paket where paket_id=@paketID";
                SqlCommand cp = new SqlCommand(sqlPaket, bag);
                cp.Parameters.AddWithValue("@paketID", paketID);

                SqlDataReader rdp = cp.ExecuteReader();

                rdp.Read();

                if (Convert.ToInt32(rdr["m_iskonto"]) == 0) // yeni fiyat iskontosuz
                {
                    if (donusTipi == 0)
                    {
                        donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyat")) + " " + Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }
                    else if (donusTipi == 1) 
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi;
                    }
                    else if (donusTipi == 2)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                    }
                    else if (donusTipi == 22)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                    }


                }

                else if (Convert.ToInt32(rdr["m_iskonto"]) == 2) // eski fiyat iskontosuz
                {
                    if (donusTipi == 0)
                    {
                        donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyat")) + " " + Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }
                    else if (donusTipi == 1)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi;
                    }
                    else if (donusTipi == 2)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                    }
                    else if (donusTipi == 22)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                    }
                }

                rdp.Close();
                cp.Dispose();
                bag.Dispose();

            }

            else if (Convert.ToInt32(rdr["m_iskonto"]) == 1 || Convert.ToInt32(rdr["m_iskonto"]) == 3) // yeni/eski fiyat iskonto var
            {

                sqlPaket = "Select paket_id, paket_fiyatYeni, paket_fiyat from paket where paket_id=@paketID";
                SqlCommand cp = new SqlCommand(sqlPaket, bag);
                cp.Parameters.AddWithValue("@paketID", paketID);

                SqlDataReader rdp = cp.ExecuteReader();

                rdp.Read();



                string sqlisk = "SELECT dbo.paket.paket_id, dbo.nisk.nisk_poran, dbo.nisk.nisk_active, dbo.nisk.nisk_member FROM  dbo.paketolcu INNER JOIN dbo.paket ON dbo.paketolcu.paketolcu_id = dbo.paket.paket_olcu INNER JOIN dbo.nisk ON dbo.paketolcu.paketolcu_tip = dbo.nisk.nisk_paketolcutip WHERE(dbo.paket.paket_id = @paket_id) AND(dbo.nisk.nisk_active = 1) AND(dbo.nisk.nisk_member = @nisk_member)";
                SqlCommand cd = new SqlCommand(sqlisk, bag);
                cd.Parameters.AddWithValue("@nisk_member", musterID);
                cd.Parameters.AddWithValue("@paket_id", paketID);

                SqlDataReader rdi = cd.ExecuteReader();

                rdi.Read();

                if (rdi.HasRows && Convert.ToDouble(rdi["nisk_poran"]) != 0)
                {
                    if (Convert.ToInt32(rdr["m_iskonto"]) == 1) // Yeni fiyat üzerinden iskonto hesaplaması
                        {
                            iskFiyat = (Convert.ToDouble(rdp["paket_fiyatYeni"])) - ((Convert.ToDouble(rdp["paket_fiyatYeni"]) / 100 ) * Convert.ToDouble(rdi["nisk_poran"]));
                            if (donusTipi == 0)
                            {
                                donus = "<strong class='text-danger'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyatOzel")) + " " + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                            }

                            else if (donusTipi == 1)
                            {
                                donus = "<span style='text-decoration: line-through;'>" + Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</span><strong class='text-danger'>" + iskFiyat.ToString("N") + " " + paraBirimi +"</strong>";
                            }
                            else if (donusTipi == 2)
                            {
                                donus = Convert.ToDouble(iskFiyat).ToString();
                            }
                            else if (donusTipi == 22) // iskontosuz fiyatı almaca
                            {
                                donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                            }

                    }

                    else if (Convert.ToInt32(rdr["m_iskonto"]) == 3) // Eski fiyat üzerinden iskonto hesaplaması
                    {
                        iskFiyat = (Convert.ToDouble(rdp["paket_fiyat"])) - ((Convert.ToDouble(rdp["paket_fiyat"]) / 100) * Convert.ToDouble(rdi["nisk_poran"]));
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-danger'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyatOzel")) + " " + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<span style='text-decoration: line-through;'>" + Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi + "</span><strong class='text-danger'>" + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(iskFiyat).ToString();
                        }
                        else if (donusTipi == 22) // iskontosuz fiyatı almaca
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                        }

                    }
                }

                else
                {
                    if (Convert.ToInt32(rdr["m_iskonto"]) == 1) // Yeni fiyat üzerinden iskonto hesaplaması
                    {
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyat")) + " " + Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                        }
                        else if (donusTipi == 22) // iskontosuz fiyatı almaca
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                        }
                    }

                    else if (Convert.ToInt32(rdr["m_iskonto"]) == 3) // Eski fiyat üzerinden iskonto hesaplaması
                    {
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyat")) + " " + Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                        }
                        else if (donusTipi == 22) // iskontosuz fiyatı almaca
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                        }
                    }

                }

            }

                return donus;
    }


        public static string paketExtraFiyat(int paketID, int paketextraID, int musterID, string paraBirimi, int donusTipi) // 0 Paket liste sayfası için
        {

            string donus = "";

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sqlMem = "Select mid, m_iskonto from member where mid = @memberID";

            SqlCommand c = new SqlCommand(sqlMem, bag);
            c.Parameters.AddWithValue("@memberID", musterID);

            SqlDataReader rdr = c.ExecuteReader();

            rdr.Read();

            string sqlPaket = "";
            double iskFiyat;

            if (Convert.ToInt32(rdr["m_iskonto"]) == 0 || Convert.ToInt32(rdr["m_iskonto"]) == 2) // yeni/eski fiyat iskonto yok
            {

                sqlPaket = "Select paketextra_id, paketextra_fiyat, paketextra_fiyatYeni from paketextra where paketextra_id=@paketextra_id ";
                SqlCommand cp = new SqlCommand(sqlPaket, bag);
                cp.Parameters.AddWithValue("@paketextra_id", paketextraID);

                SqlDataReader rdp = cp.ExecuteReader();

                rdp.Read();

                if (Convert.ToInt32(rdr["m_iskonto"]) == 0) // yeni fiyat iskontosuz
                {
                    if (donusTipi == 0)
                    {
                        donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyat")) + " " + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }

                    else if (donusTipi == 1)
                    {
                        donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }
                    else if (donusTipi == 2)
                    {
                        donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                    }
                    else if (donusTipi == 22)
                    {
                        donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                    }

                }

                else if (Convert.ToInt32(rdr["m_iskonto"]) == 2) // eski fiyat iskontosuz
                {
                    if (donusTipi == 0)
                    {
                        donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyat")) + " " + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }

                    else if (donusTipi == 1)
                    {
                        donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }
                    else if (donusTipi == 2)
                    {
                        donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                    }
                    else if (donusTipi == 22)
                    {
                        donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                    }
                }
            }

            else if (Convert.ToInt32(rdr["m_iskonto"]) == 1 || Convert.ToInt32(rdr["m_iskonto"]) == 3) // yeni/eski fiyat iskonto yok
            {



                sqlPaket = "Select paketextra_id, paketextra_fiyat, paketextra_fiyatYeni from paketextra where paketextra_id=@paketextra_id ";
                SqlCommand cp = new SqlCommand(sqlPaket, bag);
                cp.Parameters.AddWithValue("@paketextra_id", paketextraID);

                SqlDataReader rdp = cp.ExecuteReader();

                rdp.Read();



                string sqlisk = " SELECT dbo.paket.paket_id, dbo.nisk.nisk_active, dbo.nisk.nisk_member, dbo.paketextra.paketextra_iskonto, dbo.paketextra.paketextra_id, dbo.nisk.nisk_eoran FROM dbo.paketolcu INNER JOIN dbo.paket ON dbo.paketolcu.paketolcu_id = dbo.paket.paket_olcu INNER JOIN dbo.nisk ON dbo.paketolcu.paketolcu_tip = dbo.nisk.nisk_paketolcutip CROSS JOIN dbo.paketextra WHERE(dbo.paket.paket_id=@paket_id) AND(dbo.nisk.nisk_active = 1) AND(dbo.nisk.nisk_member=@nisk_member) AND(dbo.paketextra.paketextra_iskonto = 1) AND(dbo.paketextra.paketextra_id =@paketextra_id)";
                SqlCommand cd = new SqlCommand(sqlisk, bag);
                cd.Parameters.AddWithValue("@nisk_member", musterID);
                cd.Parameters.AddWithValue("@paket_id", paketID);
                cd.Parameters.AddWithValue("@paketextra_id", paketextraID);

                SqlDataReader rdi = cd.ExecuteReader();

                rdi.Read();


                if (rdi.HasRows && Convert.ToDouble(rdi["nisk_eoran"]) != 0)
                {
                    if (Convert.ToInt32(rdr["m_iskonto"]) == 1) // Yeni fiyat üzerinden iskonto hesaplaması
                    {
                        iskFiyat = (Convert.ToDouble(rdp["paketextra_fiyatYeni"])) - ((Convert.ToDouble(rdp["paketextra_fiyatYeni"]) / 100) * Convert.ToDouble(rdi["nisk_eoran"]));
                        if (donusTipi == 0)
                        {

                            donus = "<strong class='text-danger'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyatOzel")) + " " + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<span style='text-decoration: line-through;'>" + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</span><strong class='text-danger'>" + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(iskFiyat).ToString();
                        }
                        else if (donusTipi == 22)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                        }
                    }

                    else if (Convert.ToInt32(rdr["m_iskonto"]) == 3) // Eski fiyat üzerinden iskonto hesaplaması
                    {
                        iskFiyat = (Convert.ToDouble(rdp["paketextra_fiyat"])) - ((Convert.ToDouble(rdp["paketextra_fiyat"]) / 100) * Convert.ToDouble(rdi["nisk_eoran"]));
                        if (donusTipi == 0)
                        {

                            donus = "<strong class='text-danger'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyatOzel")) + " " + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<span style='text-decoration: line-through;'>" + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</span><strong class='text-danger'>" + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(iskFiyat).ToString();
                        }
                        else if (donusTipi == 22)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                        }
                    }
                }

                else
                {
                    if (Convert.ToInt32(rdr["m_iskonto"]) == 1) // Yeni fiyat üzerinden iskonto hesaplaması
                    {
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyat")) + " " + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                        }
                        else if (donusTipi == 22)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                        }
                    }

                    else if (Convert.ToInt32(rdr["m_iskonto"]) == 3) // Eski fiyat üzerinden iskonto hesaplaması
                    {
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyat")) + " " + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<strong class='text-info'>" + " " + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                        }
                        else if (donusTipi == 22)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                        }
                    }

                }


            }



                return donus;
        }




    public static string paketFiyatEski(int paketID, int musterID, string paraBirimi, int donusTipi) // 0-Paket liste sayfası için // 1-düz fiyat dönüşü 
    {

            string donus = "";

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sqlMem = "Select mid, m_iskonto from member where mid = @memberID";

            SqlCommand c = new SqlCommand(sqlMem, bag);
            c.Parameters.AddWithValue("@memberID", musterID);

            SqlDataReader rdr = c.ExecuteReader();

            rdr.Read();

            string sqlPaket = "";
            double iskFiyat;

            if (Convert.ToInt32(rdr["m_iskonto"]) == 0 || Convert.ToInt32(rdr["m_iskonto"]) == 2) // yeni/eski fiyat iskonto yok
            {
                sqlPaket = "Select paket_id, paket_fiyatYeni, paket_fiyat from paket where paket_id=@paketID";
                SqlCommand cp = new SqlCommand(sqlPaket, bag);
                cp.Parameters.AddWithValue("@paketID", paketID);

                SqlDataReader rdp = cp.ExecuteReader();

                rdp.Read();

                if (Convert.ToInt32(rdr["m_iskonto"]) == 0) // yeni fiyat iskontosuz
                {
                    if (donusTipi == 0)
                    {
                        donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyat")) + " " + Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }
                    else if (donusTipi == 1) 
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi;
                    }
                    else if (donusTipi == 2)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                    }
                    else if (donusTipi == 22)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                    }


                }

                else if (Convert.ToInt32(rdr["m_iskonto"]) == 2) // eski fiyat iskontosuz
                {
                    if (donusTipi == 0)
                    {
                        donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyat")) + " " + Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }
                    else if (donusTipi == 1)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi;
                    }
                    else if (donusTipi == 2)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                    }
                    else if (donusTipi == 22)
                    {
                        donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                    }
                }

                rdp.Close();
                cp.Dispose();
                bag.Dispose();

            }

            else if (Convert.ToInt32(rdr["m_iskonto"]) == 1 || Convert.ToInt32(rdr["m_iskonto"]) == 3) // yeni/eski fiyat iskonto var
            {

                sqlPaket = "Select paket_id, paket_fiyatYeni, paket_fiyat from paket where paket_id=@paketID";
                SqlCommand cp = new SqlCommand(sqlPaket, bag);
                cp.Parameters.AddWithValue("@paketID", paketID);

                SqlDataReader rdp = cp.ExecuteReader();

                rdp.Read();



                string sqlisk = " Select * from member_iskonto where isk_member=@memberID and isk_paket=@isk_paket";
                SqlCommand cd = new SqlCommand(sqlisk, bag);
                cd.Parameters.AddWithValue("@memberID", musterID);
                cd.Parameters.AddWithValue("@isk_paket", paketID);

                SqlDataReader rdi = cd.ExecuteReader();

                rdi.Read();

                if (rdi.HasRows)
                {
                    if (Convert.ToInt32(rdr["m_iskonto"]) == 1) // Yeni fiyat üzerinden iskonto hesaplaması
                        {
                            iskFiyat = Convert.ToDouble(rdp["paket_fiyatYeni"]) - Convert.ToDouble(rdi["isk_oran"]);
                            if (donusTipi == 0)
                            {
                                donus = "<strong class='text-danger'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyatOzel")) + " " + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                            }

                            else if (donusTipi == 1)
                            {
                                donus = "<span style='text-decoration: line-through;'>" + Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</span><strong class='text-danger'>" + iskFiyat.ToString("N") + " " + paraBirimi +"</strong>";
                            }
                            else if (donusTipi == 2)
                            {
                                donus = Convert.ToDouble(iskFiyat).ToString();
                            }
                            else if (donusTipi == 22) // iskontosuz fiyatı almaca
                            {
                                donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                            }

                    }

                    else if (Convert.ToInt32(rdr["m_iskonto"]) == 3) // Eski fiyat üzerinden iskonto hesaplaması
                    {
                        iskFiyat = Convert.ToDouble(rdp["paket_fiyat"]) - Convert.ToDouble(rdi["isk_oran"]);
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-danger'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyatOzel")) + " " + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<span style='text-decoration: line-through;'>" + Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi + "</span><strong class='text-danger'>" + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(iskFiyat).ToString();
                        }
                        else if (donusTipi == 22) // iskontosuz fiyatı almaca
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                        }

                    }
                }

                else
                {
                    if (Convert.ToInt32(rdr["m_iskonto"]) == 1) // Yeni fiyat üzerinden iskonto hesaplaması
                    {
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyat")) + " " + Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                        }
                        else if (donusTipi == 22) // iskontosuz fiyatı almaca
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyatYeni"]).ToString();
                        }
                    }

                    else if (Convert.ToInt32(rdr["m_iskonto"]) == 3) // Eski fiyat üzerinden iskonto hesaplaması
                    {
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketFiyat")) + " " + Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paket_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                        }
                        else if (donusTipi == 22) // iskontosuz fiyatı almaca
                        {
                            donus = Convert.ToDouble(rdp["paket_fiyat"]).ToString();
                        }
                    }

                }

            }

                return donus;
    }


        public static string paketExtraFiyatEski(int paketID, int paketextraID, int musterID, string paraBirimi, int donusTipi) // 0 Paket liste sayfası için
        {

            string donus = "";

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sqlMem = "Select mid, m_iskonto from member where mid = @memberID";

            SqlCommand c = new SqlCommand(sqlMem, bag);
            c.Parameters.AddWithValue("@memberID", musterID);

            SqlDataReader rdr = c.ExecuteReader();

            rdr.Read();

            string sqlPaket = "";
            double iskFiyat;

            if (Convert.ToInt32(rdr["m_iskonto"]) == 0 || Convert.ToInt32(rdr["m_iskonto"]) == 2) // yeni/eski fiyat iskonto yok
            {

                sqlPaket = "Select paketextra_id, paketextra_fiyat, paketextra_fiyatYeni from paketextra where paketextra_id=@paketextra_id ";
                SqlCommand cp = new SqlCommand(sqlPaket, bag);
                cp.Parameters.AddWithValue("@paketextra_id", paketextraID);

                SqlDataReader rdp = cp.ExecuteReader();

                rdp.Read();

                if (Convert.ToInt32(rdr["m_iskonto"]) == 0) // yeni fiyat iskontosuz
                {
                    if (donusTipi == 0)
                    {
                        donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyat")) + " " + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }

                    else if (donusTipi == 1)
                    {
                        donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }
                    else if (donusTipi == 2)
                    {
                        donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                    }
                    else if (donusTipi == 22)
                    {
                        donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                    }

                }

                else if (Convert.ToInt32(rdr["m_iskonto"]) == 2) // eski fiyat iskontosuz
                {
                    if (donusTipi == 0)
                    {
                        donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyat")) + " " + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }

                    else if (donusTipi == 1)
                    {
                        donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                    }
                    else if (donusTipi == 2)
                    {
                        donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                    }
                    else if (donusTipi == 22)
                    {
                        donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                    }
                }
            }

            else if (Convert.ToInt32(rdr["m_iskonto"]) == 1 || Convert.ToInt32(rdr["m_iskonto"]) == 3) // yeni/eski fiyat iskonto yok
            {



                sqlPaket = "Select paketextra_id, paketextra_fiyat, paketextra_fiyatYeni from paketextra where paketextra_id=@paketextra_id ";
                SqlCommand cp = new SqlCommand(sqlPaket, bag);
                cp.Parameters.AddWithValue("@paketextra_id", paketextraID);

                SqlDataReader rdp = cp.ExecuteReader();

                rdp.Read();



                string sqlisk = " select paketextraisk.paketextraisk_mid, paketextraisk.paketextraisk_paket, paketextraisk.paketextraisk_extraid, paketextraisk.paketextraisk_isk, member.mid from paketextraisk, member where paketextraisk.paketextraisk_mid=@memberID and paketextraisk.paketextraisk_paket=@paketID and paketextraisk.paketextraisk_extraid=@paketExtraID and member.mid=paketextraisk.paketextraisk_mid";
                SqlCommand cd = new SqlCommand(sqlisk, bag);
                cd.Parameters.AddWithValue("@memberID", musterID);
                cd.Parameters.AddWithValue("@paketID", paketID);
                cd.Parameters.AddWithValue("@paketExtraID", paketextraID);

                SqlDataReader rdi = cd.ExecuteReader();

                rdi.Read();


                if (rdi.HasRows)
                {
                    if (Convert.ToInt32(rdr["m_iskonto"]) == 1) // Yeni fiyat üzerinden iskonto hesaplaması
                    {
                        iskFiyat = Convert.ToDouble(rdp["paketextra_fiyatYeni"]) - Convert.ToDouble(rdi["paketextraisk_isk"]);
                        if (donusTipi == 0)
                        {

                            donus = "<strong class='text-danger'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyatOzel")) + " " + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<span style='text-decoration: line-through;'>" + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</span><strong class='text-danger'>" + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(iskFiyat).ToString();
                        }
                        else if (donusTipi == 22)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                        }
                    }

                    else if (Convert.ToInt32(rdr["m_iskonto"]) == 3) // Eski fiyat üzerinden iskonto hesaplaması
                    {
                        iskFiyat = Convert.ToDouble(rdp["paketextra_fiyat"]) - Convert.ToDouble(rdi["paketextraisk_isk"]);
                        if (donusTipi == 0)
                        {

                            donus = "<strong class='text-danger'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyatOzel")) + " " + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<span style='text-decoration: line-through;'>" + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</span><strong class='text-danger'>" + iskFiyat.ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(iskFiyat).ToString();
                        }
                        else if (donusTipi == 22)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                        }
                    }
                }

                else
                {
                    if (Convert.ToInt32(rdr["m_iskonto"]) == 1) // Yeni fiyat üzerinden iskonto hesaplaması
                    {
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyat")) + " " + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<strong class='text-info'>" + Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                        }
                        else if (donusTipi == 22)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyatYeni"]).ToString();
                        }
                    }

                    else if (Convert.ToInt32(rdr["m_iskonto"]) == 3) // Eski fiyat üzerinden iskonto hesaplaması
                    {
                        if (donusTipi == 0)
                        {
                            donus = "<strong class='text-info'>" + (string)(HttpContext.GetGlobalResourceObject("strings", "siparisPaketExtraFiyat")) + " " + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }

                        else if (donusTipi == 1)
                        {
                            donus = "<strong class='text-info'>" + " " + Convert.ToDouble(rdp["paketextra_fiyat"]).ToString("N") + " " + paraBirimi + "</strong>";
                        }
                        else if (donusTipi == 2)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                        }
                        else if (donusTipi == 22)
                        {
                            donus = Convert.ToDouble(rdp["paketextra_fiyat"]).ToString();
                        }
                    }

                }


            }



                return donus;
        }


        public static double calismaUCR(int paketID, string musteriID, int bolgeID, int yaprak, int donusTip) // çalışma ücretleri iskontoları ve fiyatlarını hesaplar
        {

            double donus = 0;

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();


            string sqlMem = "Select mid, m_iskonto from member where mid=@memberID";

            SqlCommand c = new SqlCommand(sqlMem, bag);
            c.Parameters.AddWithValue("@memberID", musteriID);

            SqlDataReader rdr = c.ExecuteReader();

            rdr.Read();

            string sqlCalismaUcr = "select * from calismaUcret where calismaUcret_bolge=@calismaUcret_bolge";
            SqlCommand f = new SqlCommand(sqlCalismaUcr, bag);
            f.Parameters.AddWithValue("@calismaUcret_bolge", bolgeID);

            SqlDataReader rCalisma = f.ExecuteReader();

            rCalisma.Read();


            if (Convert.ToInt32(rdr["m_iskonto"]) == 1 || Convert.ToInt32(rdr["m_iskonto"]) == 3)
            {
                string sqlC = "Select * from calismaIsk where calismaIsk_mid=@calismaIsk_mid";
                SqlCommand ya = new SqlCommand(sqlC, bag);
                ya.Parameters.AddWithValue("@calismaIsk_mid", musteriID);

                SqlDataReader rdrC = ya.ExecuteReader();

                if (rdrC.HasRows)
                {
                    rdrC.Read();

                    if (yaprak == 1)
                    {
                        if (donusTip == 1) // iskonto dondur
                        {
                            donus = Convert.ToDouble(rCalisma["calismaUcret_adet1"]) - Convert.ToDouble(rdrC["calismaIsk_1yapfiy"]);
                        }
                        else if (donusTip == 2) // tam fiyat dondur
                        {
                            donus = Convert.ToDouble(rCalisma["calismaUcret_adet1"]);
                        }
                        
                    }

                    else if (yaprak == 5)
                    {
                        if (donusTip == 1) // iskonto dondur
                        {
                            donus = Convert.ToDouble(rCalisma["calismaUcret_adet5"]) - Convert.ToDouble(rdrC["calismaIsk_5yapfiy"]);
                        }
                        else if (donusTip == 2) // iskonto dondur
                        {
                            donus = Convert.ToDouble(rCalisma["calismaUcret_adet5"]);
                        }
                    }

                    else if (yaprak == 10)
                    {
                        if (donusTip == 1)
                        {
                            donus = Convert.ToDouble(rCalisma["calismaUcret_adet10"]) - Convert.ToDouble(rdrC["calismaIsk_10yapfiy"]); // SAMİİİİİİİİİİİİİİİİİİ
                        }
                        else if (donusTip == 2)
                        {
                            donus = Convert.ToDouble(rCalisma["calismaUcret_adet10"]);
                        }

                    }
                }

                else
                {
                    if (yaprak == 1)
                    {
                        donus = Convert.ToDouble(rCalisma["calismaUcret_adet1"]);
                    }

                    else if (yaprak == 5)
                    {
                        donus = Convert.ToDouble(rCalisma["calismaUcret_adet5"]);
                    }

                    else if (yaprak == 10)
                    {
                        donus = Convert.ToDouble(rCalisma["calismaUcret_adet10"]);
                    }
                }
            }

            else
            {
                if (yaprak == 1)
                {
                    donus = Convert.ToDouble(rCalisma["calismaUcret_adet1"]);
                }

                else if (yaprak == 5)
                {
                    donus = Convert.ToDouble(rCalisma["calismaUcret_adet5"]);
                }

                else if (yaprak == 10)
                {
                    donus = Convert.ToDouble(rCalisma["calismaUcret_adet10"]);
                }
            }


            return donus;
        }

        public static double sayfaFiyat(int paketID, string musteriID)
        {
            double donus = 0;

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();


            string sqlMem = "Select mid, m_iskonto, paket_id, paket_sayfaFiyat from member, paket where mid=@memberID and paket_id=@paket_id";

            SqlCommand c = new SqlCommand(sqlMem, bag);
            c.Parameters.AddWithValue("@memberID", musteriID);
            c.Parameters.AddWithValue("@paket_id", paketID);


            SqlDataReader rdr = c.ExecuteReader();

            rdr.Read();

            if (Convert.ToInt32(rdr["m_iskonto"]) == 1 || Convert.ToInt32(rdr["m_iskonto"]) == 3)
            {

                string sqlCalismaUcr = "Select * from paketsayfaisk where paketsayfaisk_mid=@memberIDS and paketsayfaisk_paket=@paketsayfaisk_paket";
                SqlCommand f = new SqlCommand(sqlCalismaUcr, bag);
                f.Parameters.AddWithValue("@memberIDS", musteriID);
                f.Parameters.AddWithValue("@paketsayfaisk_paket", paketID);

                SqlDataReader rSayfa = f.ExecuteReader();

                if (rSayfa.HasRows)
                {
                    rSayfa.Read();

                    donus = Convert.ToDouble(rdr["paket_sayfaFiyat"]) - Convert.ToDouble(rSayfa["paketsayfaisk_oran"]);

                }

                else
                {
                    donus = Convert.ToDouble(rdr["paket_sayfaFiyat"]);
                }

            }

            else
            {
                donus = Convert.ToDouble(rdr["paket_sayfaFiyat"]);
            }

            return donus;
        }


        public static double sayfaFiyatTam(int paketID)
        {
            double donus = 0;

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();


            string sqlMem = "Select paket_id, paket_sayfaFiyat from paket where paket_id=@paket_id";

            SqlCommand c = new SqlCommand(sqlMem, bag);
            c.Parameters.AddWithValue("@paket_id", paketID);


            SqlDataReader rdr = c.ExecuteReader();

            rdr.Read();

            donus = Convert.ToDouble(rdr["paket_sayfaFiyat"]);


            return donus;
        }


        public static void siparisFiyatDetay(int siparisNo, double fiyat, double tamFiyat, double iskontoFiyat, int dataTipi)
        {

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();

            string sqlMem = "insert into siparisDetay(siparisDetay_siparisNo, siparisDetay_fiyat, siparisDetay_fiyatTam, siparisDetay_fiyatiskonto, siparisDetay_Tip) values(@siparisDetay_siparisNo, @siparisDetay_fiyat, @siparisDetay_fiyatTam, @siparisDetay_fiyatiskonto, @siparisDetay_Tip)";

            SqlCommand c = new SqlCommand(sqlMem, bag);
            c.Parameters.AddWithValue("@siparisDetay_siparisNo", siparisNo);
            c.Parameters.AddWithValue("@siparisDetay_fiyat", fiyat);
            c.Parameters.AddWithValue("@siparisDetay_fiyatTam", tamFiyat);
            c.Parameters.AddWithValue("@siparisDetay_fiyatiskonto", iskontoFiyat);
            c.Parameters.AddWithValue("@siparisDetay_Tip", dataTipi);

            c.ExecuteNonQuery();


        }

        public static double kagitYuzde(string musteriID, int paketNo, int kagitID, int donusTip)
        {
            double donus = 0;
            double kagitYuzde = 0;

            connectionStr.DBIslem x = new connectionStr.DBIslem();

            SqlConnection bag = x.Baglanti();


            string sqlMem = "Select mid, m_iskonto from member where mid=@memberID";

            SqlCommand c = new SqlCommand(sqlMem, bag);
            c.Parameters.AddWithValue("@memberID", musteriID);

            SqlDataReader rdr = c.ExecuteReader();

            rdr.Read();


            string sqlP = "select * from paket where paket_id=@paket_id";
            SqlCommand cp = new SqlCommand(sqlP, bag);
            cp.Parameters.AddWithValue("@paket_id", paketNo);

            SqlDataReader rp = cp.ExecuteReader();

            rp.Read();

            if (kagitID == 1)
            {
                kagitYuzde = 0;
            }

            else if (kagitID == 2)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_silkYuzde"]);
            }

            else if (kagitID == 3)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_sedefYuzde"]);
            }

            else if (kagitID == 5)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_kristalYuzde"]);
            }

            else if (kagitID == 6)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_metalikYuzde"]);
            }

            else if (kagitID == 7)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_prokristalYuzde"]);
            }

            else if (kagitID == 8)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_mattprintYuzde"]);
            }

            else if (kagitID == 9)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_fart270gbrightwhiteYuzde"]);
            }

            else if (kagitID == 10)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_fartsatin270gbirhgtwhiteYuzde"]);
            }

            else if (kagitID == 11)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_fartradiant270gwhiteYuzde"]);
            }

            else if (kagitID == 12)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_farttoscana210gnaturalwhiteYuzde"]);
            }

            else if (kagitID == 13)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_fartwatercolour240gnaturalwhiteYuzde"]);
            }

            else if (kagitID == 14)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_fartwhitevelvet270gwhiteYuzde"]);
            }

            else if (kagitID == 15)
            {
                kagitYuzde = Convert.ToDouble(rp["paket_softtouchYuzde"]);
            }




            if (Convert.ToInt32(rdr["m_iskonto"]) == 1 || Convert.ToInt32(rdr["m_iskonto"]) == 3)
            {

                string sqlCalismaUcr = "Select * from paketkagitisk where paketkagitisk_mid=@memberIDS and paketkagitisk_paket=@paketID and paketkagitisk_kagit=@kagit";
                SqlCommand f = new SqlCommand(sqlCalismaUcr, bag);
                f.Parameters.AddWithValue("@memberIDS", musteriID);
                f.Parameters.AddWithValue("@paketID", paketNo);
                f.Parameters.AddWithValue("@kagit", kagitID);

                SqlDataReader rSayfa = f.ExecuteReader();

                if (rSayfa.HasRows)
                {
                    rSayfa.Read();

                    if (donusTip == 1)
                    {
                        donus = kagitYuzde - Convert.ToDouble(rSayfa["paketkagitisk_oran"]);
                    }

                    else if (donusTip == 2)
                    {
                        donus = kagitYuzde;
                    }

                }

                else
                {
                    donus = kagitYuzde;
                }

            }

            else
            {
                donus = kagitYuzde;
            }


            return donus;
        }

    }
}