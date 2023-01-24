using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace KullaniciIslemleri
{
    public partial class frmAnaEkran : Form
    {
        public frmAnaEkran()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string strSaglayici = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\data\data.accdb";
            OleDbConnection baglanti = new OleDbConnection(strSaglayici);
            baglanti.Open();

            string sorgu = "insert into Ogrenci(ogr_no,ad,soyad,tel) values(@ogr_no,@ad,@soyad,@tel)";
            OleDbCommand cmd = new OleDbCommand(sorgu, baglanti);

            cmd.Parameters.AddWithValue("ogr_no", textBox2.Text);
            cmd.Parameters.AddWithValue("ad", textBox3.Text);
            cmd.Parameters.AddWithValue("soyad", textBox4.Text);
            cmd.Parameters.AddWithValue("tel", textBox5.Text);
            cmd.ExecuteNonQuery();
            Listelee();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dataGridView1.Refresh();
            baglanti.Close();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string strSaglayici = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\data\data.accdb";
            OleDbConnection baglanti = new OleDbConnection(strSaglayici);
            baglanti.Open();
            string sorgu = "Delete from Ogrenci where ogr_no=@ogr_no";

            OleDbCommand cmd = new OleDbCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("ogr_no", textBox2.Text);
            cmd.ExecuteNonQuery();
            dataGridView1.Refresh();

        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string strSaglayici = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\data\data.accdb";
            OleDbConnection baglanti = new OleDbConnection(strSaglayici);
            baglanti.Open();

            string sorgu = "update Ogrenci set ad=@ad, soyad=@soyad where ogr_no=@ogr_no";
            OleDbCommand cmd = new OleDbCommand(sorgu, baglanti);

            cmd.Parameters.AddWithValue("ogr_no", textBox2.Text);
            cmd.Parameters.AddWithValue("ad", textBox3.Text);
            cmd.Parameters.AddWithValue("soyad", textBox4.Text);
            cmd.Parameters.AddWithValue("tel", textBox5.Text);
            cmd.ExecuteNonQuery();
            Listelee();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dataGridView1.Refresh();
            baglanti.Close();

        }

        private void btnKullaniciAra_Click(object sender, EventArgs e)
        {
            string strSaglayici = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\data\data.accdb";
            OleDbConnection baglanti = new OleDbConnection(strSaglayici);
            baglanti.Open();
            DataTable tbl = new DataTable();
            string vara, cumle;
            vara =textBox1.Text;
            cumle = "Select * from Ogrenci where ogr_no like '%" + textBox1.Text + "%'";
            OleDbDataAdapter adptr = new OleDbDataAdapter(cumle, baglanti);
            adptr.Fill(tbl);
            baglanti.Close();
            dataGridView1.DataSource = tbl;

            textBox1.Clear();
            

  
        }

        private void frmAnaEkran_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataDataSet.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.dataDataSet.Ogrenci);
            string strSaglayici = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\data\data.accdb";
            OleDbConnection baglanti = new OleDbConnection(strSaglayici);
            baglanti.Open();
            DataTable tablo = new DataTable();
            dataGridView1.DataSource = tablo;
            DataSet dtst = new DataSet();           
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * From Ogrenci", baglanti);
            adtr.Fill(dtst, "Ogrenci");
            dataGridView1.DataSource = dtst.Tables["Ogrenci"];
            adtr.Dispose();
            dataGridView1.Refresh();
            baglanti.Close();
        }

        private void Listelee()
        {
            string strSaglayici = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\data\data.accdb";
            OleDbConnection baglanti = new OleDbConnection(strSaglayici);
            baglanti.Open();
            string sql = "select * from Ogrenci";
            OleDbCommand komut = new OleDbCommand(sql, baglanti);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder();
            DataTable tablom = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            da.Fill(tablom);
            dataGridView1.DataSource = tablom;
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }





      
    }
}
