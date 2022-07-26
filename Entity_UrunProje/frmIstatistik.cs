using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_UrunProje
{
    public partial class frmIstatistik : Form
    {
        public frmIstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void frmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.Tbl_Kategoriler.Count().ToString();
            label3.Text = db.Tbl_Urun.Count().ToString();
            label5.Text = db.Tbl_Musteriler.Count(x => x.durum == true).ToString();
            label7.Text = db.Tbl_Musteriler.Count(x => x.durum == false).ToString();
            label13.Text = db.Tbl_Urun.Sum(x => x.urunStok).ToString();
            label21.Text = db.Tbl_Satıslar.Sum(x => x.fiyat).ToString();
            label11.Text = (from x in db.Tbl_Urun orderby x.urunFiyat descending select x.urunAd).FirstOrDefault();
            label9.Text = (from x in db.Tbl_Urun orderby x.urunFiyat ascending select x.urunAd).FirstOrDefault();
            label15.Text = db.Tbl_Urun.Count(x => x.urunKategori == 1).ToString();
            label17.Text = db.Tbl_Urun.Count(x => x.urunAd == "Buzdolabı").ToString();
            label23.Text = (from x in db.Tbl_Musteriler select x.sehir).Distinct().Count().ToString();
            label19.Text = db.MARKAGETİR().FirstOrDefault();
            
        }
    }
}
