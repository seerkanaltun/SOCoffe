using SOCoffe.Class;
using SOCoffe.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SOCoffe
{
    public partial class Form1 : Form
    {
        public static List<Personel> calisanPersonel = new List<Personel>();
        public static List<Personel> bostaPersonel = new List<Personel>();

        int toplamSure1 = 0; int toplamSure2 = 0; int toplamSure3 = 0; int toplamSure4 = 0;

        Baristalar barista1 = new Baristalar("Aslıhan", true);
        Baristalar barista2 = new Baristalar("Ahmetiye", true);
        Baristalar barista3 = new Baristalar("Serkan", true);
        Baristalar barista4 = new Baristalar("Onur", true);

        #region İçeceklerin Belirlenmesi
        public static List<Icecekler> icecekler = new List<Icecekler>()
        {
            new Icecekler(){IcecekAdi="Filtre Kahve",IcecekFiyati=26.00M ,HazirlanmaSuresi=25,Tur=IcecekTuru.Kahveler},
            new Icecekler(){IcecekAdi="Flat White",IcecekFiyati=30.00M,HazirlanmaSuresi=35,Tur=IcecekTuru.Kahveler},
            new Icecekler(){IcecekAdi="Caffè Latte",IcecekFiyati=30.00M,HazirlanmaSuresi=45,Tur=IcecekTuru.Kahveler},
            new Icecekler(){IcecekAdi="White Choclate Mocha",IcecekFiyati=30.00M,HazirlanmaSuresi=50,Tur=IcecekTuru.Kahveler},
            new Icecekler(){IcecekAdi="Caramel Macchiato",IcecekFiyati=30.00M,HazirlanmaSuresi=60,Tur=IcecekTuru.Kahveler},
            new Icecekler(){IcecekAdi="Cappuccino",IcecekFiyati=30.00M,HazirlanmaSuresi=53,Tur=IcecekTuru.Kahveler},

        };
        #endregion
        
        #region Ekstra Malzemelerin Belirlenmesi
        public static List<EkstraMalzemeler> ekstraMalzeme = new List<EkstraMalzemeler>()
        {
            new EkstraMalzemeler{EkstraMalzemeAdi="Laktozsuz Süt", EkstraMalzemeFiyati=0.60M,EkstraSure=2},
            new EkstraMalzemeler{EkstraMalzemeAdi="Soya Sütü", EkstraMalzemeFiyati=0.70M,EkstraSure=11},
            new EkstraMalzemeler{EkstraMalzemeAdi="Normal Süt", EkstraMalzemeFiyati=0.50M,EkstraSure=13},
            new EkstraMalzemeler{EkstraMalzemeAdi="Karamel", EkstraMalzemeFiyati=2.50M,EkstraSure=8},
            new EkstraMalzemeler{EkstraMalzemeAdi="Fındık", EkstraMalzemeFiyati=2.50M,EkstraSure=7},
            new EkstraMalzemeler{EkstraMalzemeAdi="Çikolata", EkstraMalzemeFiyati=2.00M,EkstraSure=6}
        };
        #endregion

        public Form1()
        {
            InitializeComponent();
        }
     
     
        private void label1_Click(object sender, EventArgs e)
        {

        }





        private void btnSiparisiOnayla_Click_1(object sender, EventArgs e)
        {

            if (bostaPersonel.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show($"Toplam sipariş tutarı : {TutarHesapla().ToString("c2")}\r\nSatın almayı tamamlamak istiyor musunuz ?", "Sipariş Bilgisi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    lblToplamTutar.Text = "₺0.00";
                    lbxData.Items.Clear();

                    if (progressBar1.Value == 0)
                    {
                        timer1.Start();
                        barista1.BostaMi = false;
                        calisanPersonel.Add(barista1);
                        bostaPersonel.Remove(barista1);
                        button1.Text = $"Siparişiniz Hazırlanıyor... Toplam Hazırlanma Süresi : {toplamSure1} Saniye.";
                        button1.BackColor = Color.Brown;
                    }
                    else if (progressBar2.Value == 0)
                    {
                        timer2.Start();
                        barista2.BostaMi = false;
                        calisanPersonel.Add(barista2);
                        bostaPersonel.Remove(barista2);
                        button2.Text = $"Siparişiniz Hazırlanıyor... Toplam Hazırlanma Süresi : {toplamSure2} Saniye.";
                        button2.BackColor = Color.Brown;
                    }
                    else if (progressBar3.Value == 0)
                    {
                        timer3.Start();
                        barista3.BostaMi = false;
                        calisanPersonel.Add(barista3);
                        bostaPersonel.Remove(barista3);
                        button3.Text = $"Siparişiniz Hazırlanıyor... Toplam Hazırlanma Süresi : {toplamSure2} Saniye.";
                        button3.BackColor = Color.Brown;
                    }
                    else if (progressBar4.Value == 0)
                    {
                        timer4.Start();
                        barista4.BostaMi = false;
                        calisanPersonel.Add(barista4);
                        bostaPersonel.Remove(barista4);
                        button4.Text = $"Siparişiniz Hazırlanıyor... Toplam Hazırlanma Süresi : {toplamSure2} Saniye.";
                        button4.BackColor = Color.Brown;
                    }


                }
            }
            else
            {
                MessageBox.Show("Şuan Uygun Personelimiz Yoktur. Lütfen Siparişler Hazır Olana Kadar Bekleyiniz...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
                          
        private void Form1_Load(object sender, EventArgs e)
        {

            int x = 20;
            int y = 16;
            int adet = 0;
            foreach (var item in icecekler)
            {
                
                comboBox1.Items.Add(item);
            }

            comboBox1.SelectedIndex = 0;
            foreach (var item in ekstraMalzeme)
            {
                adet++;

                if (adet % 4 == 0)
                {
                    x += 150;
                    y = 16;
                    CheckBox checkbox = new CheckBox();
                    checkbox.Text = item.EkstraMalzemeAdi;
                    checkbox.Tag = item;
                    checkbox.Location = new Point(x, y);
                    checkbox.Height = 30;
                    checkbox.Width = 250;
                    panel1.Controls.Add(checkbox);
                }
                else if (adet < 5)
                {
                    CheckBox checkbox = new CheckBox();
                    checkbox.Text = item.EkstraMalzemeAdi;
                    checkbox.Tag = item;
                    checkbox.Location = new Point(x, y);
                    checkbox.Height = 30;
                    checkbox.Width = 150;
                    panel1.Controls.Add(checkbox);
                    y += 35;
                }
                else
                {
                    y += 35;
                    CheckBox checkbox = new CheckBox();
                    checkbox.Text = item.EkstraMalzemeAdi;
                    checkbox.Tag = item;
                    checkbox.Location = new Point(x, y);
                    checkbox.Height = 30;
                    checkbox.Width = 250;
                    panel1.Controls.Add(checkbox);
                }
            }
            bostaPersonel.Add(barista1);
            bostaPersonel.Add(barista2);
            bostaPersonel.Add(barista3);
            bostaPersonel.Add(barista4);
        }
        
        
        private void btnSiparisiEkle_Click_1(object sender, EventArgs e)
        {
            if (bostaPersonel.Count > 0)
            {
                List<EkstraMalzemeler> secilenEkstraMalzemeler = new List<EkstraMalzemeler>();
                Siparisler yeniSiparis = new Siparisler();
                yeniSiparis.SeciliIcecek = (Icecekler)comboBox1.SelectedItem;
                if (rbKucuk.Checked)
                    yeniSiparis.IcecekBoyutu = Boyut.Kucuk;
                else if (rbOrta.Checked)
                    yeniSiparis.IcecekBoyutu = Boyut.Orta;
                else
                    yeniSiparis.IcecekBoyutu = Boyut.Buyuk;

                foreach (CheckBox item in panel1.Controls)
                {
                    if (item.Checked)
                    {
                        secilenEkstraMalzemeler.Add((EkstraMalzemeler)item.Tag);
                    }
                }
                yeniSiparis.EkstraMalzeme = secilenEkstraMalzemeler;
                yeniSiparis.Adet = (int)numericUpDown1.Value;
                yeniSiparis.Hesapla();

                lbxData.Items.Add(yeniSiparis);
                TutarHesapla();
                
                if (toplamSure1 == 0 || progressBar1.Value == 0)
                {
                    toplamSure1 += (yeniSiparis.SeciliIcecek.HazirlanmaSuresi) * yeniSiparis.Adet;
                    foreach (var item in secilenEkstraMalzemeler)
                    {
                        toplamSure1 += item.EkstraSure;
                    }
                }
                else if (toplamSure2 == 0 || progressBar2.Value == 0)
                {
                    toplamSure2 += (yeniSiparis.SeciliIcecek.HazirlanmaSuresi) * yeniSiparis.Adet;
                    foreach (var item in secilenEkstraMalzemeler)
                    {
                        toplamSure2 += item.EkstraSure;
                    }
                }
                else if (toplamSure3 == 0 || progressBar3.Value == 0)
                {
                    toplamSure3 += (yeniSiparis.SeciliIcecek.HazirlanmaSuresi) * yeniSiparis.Adet;
                    foreach (var item in secilenEkstraMalzemeler)
                    {
                        toplamSure3 += item.EkstraSure;
                    }
                }
                else if (toplamSure4 == 0 || progressBar4.Value == 0)
                {
                    toplamSure4 += (yeniSiparis.SeciliIcecek.HazirlanmaSuresi) * yeniSiparis.Adet;
                    foreach (var item in secilenEkstraMalzemeler)
                    {
                        toplamSure4 += item.EkstraSure;
                    }
                }

                Temizle();
            }
            else if (bostaPersonel.Count == 0)
            {
                MessageBox.Show("Şuan Uygun Personelimiz Yoktur. Lütfen Siparişler Hazır Olana Kadar Bekleyiniz...", "SO Coffee Özür Diler", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
                if (progressBar1.Value == progressBar1.Maximum || progressBar1.Value > progressBar1.Maximum)
                {
                    timer1.Stop();
                    SiparisKontrolEt();
                    toplamSure1 = 0;
                    progressBar1.Value = 0;
                }
                else if (progressBar1.Value != progressBar1.Maximum)
                {
                    try
                    {
                        progressBar1.Value += progressBar1.Maximum / toplamSure1;
                    }
                    catch (Exception)
                    {

                        progressBar1.Value = 100;
                    }
                }
            
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
           
                if (progressBar2.Value == progressBar2.Maximum || progressBar2.Value > progressBar2.Maximum)
                {
                    timer2.Stop();
                    SiparisKontrolEt();
                    toplamSure2 = 0;
                    progressBar2.Value = 0;
                }
                else if (progressBar2.Value != progressBar2.Maximum)
                {
                    try
                    {
                        progressBar2.Value += progressBar2.Maximum / toplamSure2;
                    }
                    catch (Exception)
                    {

                        progressBar2.Value = 100;
                    }
                }
            
        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
           
                if (progressBar3.Value == progressBar3.Maximum || progressBar3.Value > progressBar3.Maximum)
                {
                    timer3.Stop();
                    SiparisKontrolEt();
                    toplamSure3 = 0;
                    progressBar3.Value = 0;
                }
                else if (progressBar3.Value != progressBar3.Maximum)
                {
                    try
                    {
                        progressBar3.Value += progressBar3.Maximum / toplamSure3;
                    }
                    catch (Exception)
                    {

                        progressBar3.Value = 100;
                    }
                }
            
        }

        private void timer4_Tick_1(object sender, EventArgs e)
        {
           
                if (progressBar4.Value == progressBar4.Maximum || progressBar4.Value > progressBar4.Maximum)
                {
                    timer4.Stop();
                    SiparisKontrolEt();
                    toplamSure4 = 0;
                    progressBar4.Value = 0;
                }
                else if (progressBar4.Value != progressBar4.Maximum)
                {
                    try
                    {
                        progressBar4.Value += progressBar4.Maximum / toplamSure4;
                    }
                    catch (Exception)
                    {

                        progressBar4.Value = 100;
                    }
                }
            
        }
        #region Methodlar

        private decimal TutarHesapla()
        {
            decimal toplamTutar = 0;
            for (int i = 0; i < lbxData.Items.Count; i++)
            {
                Siparisler gelenSiparis = (Siparisler)lbxData.Items[i];
                toplamTutar += gelenSiparis.ToplamTutar;
            }
            lblToplamTutar.Text = toplamTutar.ToString("c2");
            return toplamTutar;
        }
        private void Temizle()
        {
            comboBox1.SelectedIndex = 0;
            rbKucuk.Checked = true;
            rbOrta.Checked = false;
            rbBuyuk.Checked = false;
            foreach (CheckBox item in panel1.Controls)
            {
                item.Checked = false;
            }
            numericUpDown1.Value = 1;
        }
        public void SiparisKontrolEt()
        {
            if (progressBar1.Value >= 100)
            {
                
                button1.BackColor = Color.Green;
                button1.Text = "UYGUN";
                bostaPersonel.Add(barista1);
                calisanPersonel.Remove(barista1);
                button1.BackColor = Color.Red;
                

            }
            if (progressBar2.Value >= 100)
            {

                button2.BackColor = Color.Green;
                button2.Text = "UYGUN";
                bostaPersonel.Add(barista2);
                calisanPersonel.Remove(barista2);
                button2.BackColor = Color.Red;
            }
            if (progressBar3.Value >= 100)
            {

                button3.BackColor = Color.Green;
                button3.Text = "UYGUN";
                bostaPersonel.Add(barista3);
                calisanPersonel.Remove(barista3);
                button3.BackColor = Color.Red;
            }
            if (progressBar4.Value >= 100)
            {

                button4.BackColor = Color.Green;
                button4.Text = "UYGUN";
                bostaPersonel.Add(barista4);
                calisanPersonel.Remove(barista4);
                button4.BackColor = Color.Red;
            }

        }
        #endregion
    }
}
