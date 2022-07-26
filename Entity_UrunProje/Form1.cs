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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db =new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.Tbl_Kategoriler.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Tbl_Kategoriler tbl_Kategoriler = new Tbl_Kategoriler();
            tbl_Kategoriler.kategoriAd = txtAd.Text;
            db.Tbl_Kategoriler.Add(tbl_Kategoriler);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var kategori = db.Tbl_Kategoriler.Find(x);
            db.Tbl_Kategoriler.Remove(kategori);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var kategori = db.Tbl_Kategoriler.Find(x);
            kategori.kategoriAd = txtAd.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme yapıldı");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var kategoriler = db.Tbl_Kategoriler.ToList();
            dataGridView1.DataSource = kategoriler;
        }
    }
}
