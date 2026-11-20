using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace YMH219_SpeechApp
{
    public partial class Form1 : Form
    {
        private readonly TextToSpeechService _ttsServisi;
        private readonly SpeechToTextService _sttServisi;

        public Form1()
        {
            InitializeComponent();
            _ttsServisi = new TextToSpeechService();
            _sttServisi = new SpeechToTextService();

            _ttsServisi.KonusmaTamamlandi += TtsServisi_KonusmaTamamlandi;
            _sttServisi.KonusmaTanindi += SttServisi_KonusmaTanindi;
            _sttServisi.HataOlustu += SttServisi_HataOlustu;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var sesler = _ttsServisi.YukluSesleriGetir();
                cmbSesler.Items.Clear();
                foreach (var ses in sesler)
                {
                    cmbSesler.Items.Add(ses);
                }

                if (cmbSesler.Items.Count > 0)
                {
                    cmbSesler.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ses motoru yüklenirken hata oluştu:\n{ex.Message}", "Ses Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbSesler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSesler.SelectedItem != null)
            {
                try
                {
                    _ttsServisi.SesSec(cmbSesler.SelectedItem.ToString());
                }
                catch { }
            }
        }

        private void trkHiz_Scroll(object sender, EventArgs e)
        {
            int hiz = trkHiz.Value;
            _ttsServisi.HizAyarla(hiz);
            lblHizDeger.Text = hiz == 0 ? "Normal" : (hiz > 0 ? $"+{hiz}" : hiz.ToString());
        }

        private void btnTtsBaslat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbTtsMetin.Text))
            {
                MessageBox.Show("Lütfen seslendirilecek bir metin girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _ttsServisi.Oku(rtbTtsMetin.Text);
                btnTtsBaslat.Enabled = false;
                btnTtsDuraklat.Enabled = true;
                btnTtsDuraklat.Text = "Duraklat";
                btnTtsDurdur.Enabled = true;
                DurumGuncelle("Text-to-Speech: Metin seslendiriliyor...", Color.SeaGreen);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Metin seslendirilemedi:\n{ex.Message}", "Seslendirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTtsDuraklat_Click(object sender, EventArgs e)
        {
            _ttsServisi.DuraklatVeyaDevamEt();
            if (_ttsServisi.DuraklatildiMi)
            {
                btnTtsDuraklat.Text = "Devam Et";
                DurumGuncelle("Text-to-Speech: Okuma duraklatıldı.", Color.DarkOrange);
            }
            else
            {
                btnTtsDuraklat.Text = "Duraklat";
                DurumGuncelle("Text-to-Speech: Metin seslendiriliyor...", Color.SeaGreen);
            }
        }

        private void btnTtsDurdur_Click(object sender, EventArgs e)
        {
            _ttsServisi.Durdur();
            TtsButonlariniSifirla();
            DurumGuncelle("Text-to-Speech: Okuma durduruldu.", Color.Crimson);
        }

        private void btnTtsTemizle_Click(object sender, EventArgs e)
        {
            _ttsServisi.Durdur();
            TtsButonlariniSifirla();
            rtbTtsMetin.Clear();
            DurumGuncelle("Hazır (Beklemede)", Color.DarkSlateBlue);
        }

        private void TtsServisi_KonusmaTamamlandi()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(TtsServisi_KonusmaTamamlandi));
                return;
            }

            TtsButonlariniSifirla();
            if (!_sttServisi.DinliyorMu)
            {
                DurumGuncelle("Text-to-Speech: Okuma tamamlandı.", Color.DarkSlateBlue);
            }
        }

        private void TtsButonlariniSifirla()
        {
            btnTtsBaslat.Enabled = true;
            btnTtsDuraklat.Enabled = false;
            btnTtsDuraklat.Text = "Duraklat";
            btnTtsDurdur.Enabled = false;
        }

        private void btnSttBaslat_Click(object sender, EventArgs e)
        {
            try
            {
                _sttServisi.DinlemeyiBaslat();
                btnSttBaslat.Enabled = false;
                btnSttDurdur.Enabled = true;
                DurumGuncelle($"Speech-to-Text: Mikrofon dinleniyor ({_sttServisi.AktifDil})...", Color.SeaGreen);
            }
            catch (Exception ex)
            {
                DurumGuncelle("Speech-to-Text: Mikrofon veya servis hatası!", Color.Crimson);
                MessageBox.Show($"Konuşma tanıma başlatılamadı:\n{ex.Message}\n\nLütfen mikrofon bağlantınızı ve Windows Konuşma Tanıma ayarlarını kontrol edin.", "Mikrofon / Servis Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSttDurdur_Click(object sender, EventArgs e)
        {
            _sttServisi.DinlemeyiDurdur();
            btnSttBaslat.Enabled = true;
            btnSttDurdur.Enabled = false;
            DurumGuncelle("Speech-to-Text: Dinleme durduruldu.", Color.Crimson);
        }

        private void btnSttTemizle_Click(object sender, EventArgs e)
        {
            rtbSttSonuc.Clear();
        }

        private void btnSttKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbSttSonuc.Text))
            {
                MessageBox.Show("Kaydedilecek dönüştürülmüş metin bulunmuyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Metin Dosyası (*.txt)|*.txt";
                sfd.FileName = $"KonusmaMetni_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, rtbSttSonuc.Text);
                    MessageBox.Show("Metin başarıyla dosyaya kaydedildi.", "Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SttServisi_KonusmaTanindi(string metin)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SttServisi_KonusmaTanindi), metin);
                return;
            }

            rtbSttSonuc.AppendText($"[{DateTime.Now:HH:mm:ss}] {metin}{Environment.NewLine}");
            rtbSttSonuc.ScrollToCaret();
        }

        private void SttServisi_HataOlustu(string hata)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SttServisi_HataOlustu), hata);
                return;
            }

            btnSttBaslat.Enabled = true;
            btnSttDurdur.Enabled = false;
            DurumGuncelle("Speech-to-Text: Dinleme sırasında hata oluştu.", Color.Crimson);
            MessageBox.Show($"Konuşma tanıma hatası:\n{hata}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DurumGuncelle(string mesaj, Color renk)
        {
            lblAktifDurum.Text = $"● Aktif İşlem: {mesaj}";
            lblAktifDurum.ForeColor = renk;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ttsServisi.Dispose();
            _sttServisi.Dispose();
        }
    }
}