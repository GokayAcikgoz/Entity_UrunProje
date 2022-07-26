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
    public partial class frmUrun : Form
    {
        public frmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.Tbl_Urun
                                        select new
                                        {
                                            x.urunId,
                                            x.urunAd,
                                            x.urunMarka,
                                            x.urunFiyat,
                                            x.Tbl_Kategoriler.kategoriAd,
                                            x.urunDurum
                                        }
                                        ).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Urun t = new Tbl_Urun();
            t.urunAd = txtAd.Text;
            t.urunMarka = txtMarka.Text;
            t.urunStok = short.Parse(txtStok.Text);
            t.urunKategori = int.Parse(cmbKategori.SelectedValue.ToString());
            t.urunFiyat = decimal.Parse(txtFiyat.Text);
            t.urunDurum = true;
            db.Tbl_Urun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün sisteme kaydedildi");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var urun = db.Tbl_Urun.Find(x);

            db.Tbl_Urun.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var urun = db.Tbl_Urun.Find(x);

            urun.urunAd = txtAd.Text;
            urun.urunStok = short.Parse(txtStok.Text);
            urun.urunMarka = txtMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void frmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.Tbl_Kategoriler
                               select new
                               {
                                   x.kategoriId,
                                   x.kategoriAd
                               }
                               ).ToList();

            cmbKategori.ValueMember = "kategoriId";
            cmbKategori.DisplayMember = "kategoriAd";
            cmbKategori.DataSource = kategoriler;
        }
    }
}
