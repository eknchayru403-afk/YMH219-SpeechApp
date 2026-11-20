namespace YMH219_SpeechApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblAktifDurum = new Label();
            grpTts = new GroupBox();
            lblSesSecimi = new Label();
            cmbSesler = new ComboBox();
            lblHiz = new Label();
            trkHiz = new TrackBar();
            lblHizDeger = new Label();
            rtbTtsMetin = new RichTextBox();
            btnTtsBaslat = new Button();
            btnTtsDuraklat = new Button();
            btnTtsDurdur = new Button();
            btnTtsTemizle = new Button();
            grpStt = new GroupBox();
            btnSttBaslat = new Button();
            btnSttDurdur = new Button();
            btnSttTemizle = new Button();
            btnSttKaydet = new Button();
            rtbSttSonuc = new RichTextBox();
            grpTts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkHiz).BeginInit();
            grpStt.SuspendLayout();
            SuspendLayout();

            // lblAktifDurum
            lblAktifDurum.BackColor = Color.FromArgb(230, 240, 250);
            lblAktifDurum.BorderStyle = BorderStyle.FixedSingle;
            lblAktifDurum.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAktifDurum.ForeColor = Color.DarkSlateBlue;
            lblAktifDurum.Location = new Point(15, 12);
            lblAktifDurum.Name = "lblAktifDurum";
            lblAktifDurum.Size = new Size(850, 32);
            lblAktifDurum.Text = "● Aktif İşlem: Hazır (Beklemede)";
            lblAktifDurum.TextAlign = ContentAlignment.MiddleLeft;

            // grpTts
            grpTts.Controls.Add(btnTtsTemizle);
            grpTts.Controls.Add(btnTtsDurdur);
            grpTts.Controls.Add(btnTtsDuraklat);
            grpTts.Controls.Add(btnTtsBaslat);
            grpTts.Controls.Add(rtbTtsMetin);
            grpTts.Controls.Add(lblHizDeger);
            grpTts.Controls.Add(trkHiz);
            grpTts.Controls.Add(lblHiz);
            grpTts.Controls.Add(cmbSesler);
            grpTts.Controls.Add(lblSesSecimi);
            grpTts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpTts.Location = new Point(15, 55);
            grpTts.Name = "grpTts";
            grpTts.Size = new Size(415, 420);
            grpTts.TabStop = false;
            grpTts.Text = "1. Text-to-Speech (Metni Sesli Okuma)";

            // lblSesSecimi
            lblSesSecimi.AutoSize = true;
            lblSesSecimi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSesSecimi.Location = new Point(15, 32);
            lblSesSecimi.Name = "lblSesSecimi";
            lblSesSecimi.Size = new Size(65, 15);
            lblSesSecimi.Text = "Ses Seçimi:";

            // cmbSesler
            cmbSesler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSesler.Font = new Font("Segoe UI", 9F);
            cmbSesler.FormattingEnabled = true;
            cmbSesler.Location = new Point(90, 28);
            cmbSesler.Name = "cmbSesler";
            cmbSesler.Size = new Size(308, 23);
            cmbSesler.SelectedIndexChanged += cmbSesler_SelectedIndexChanged;

            // lblHiz
            lblHiz.AutoSize = true;
            lblHiz.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHiz.Location = new Point(15, 68);
            lblHiz.Name = "lblHiz";
            lblHiz.Size = new Size(62, 15);
            lblHiz.Text = "Okuma Hızı:";

            // trkHiz
            trkHiz.Location = new Point(90, 62);
            trkHiz.Maximum = 10;
            trkHiz.Minimum = -10;
            trkHiz.Name = "trkHiz";
            trkHiz.Size = new Size(255, 45);
            trkHiz.TickFrequency = 2;
            trkHiz.Value = 0;
            trkHiz.Scroll += trkHiz_Scroll;

            // lblHizDeger
            lblHizDeger.AutoSize = true;
            lblHizDeger.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHizDeger.Location = new Point(352, 68);
            lblHizDeger.Name = "lblHizDeger";
            lblHizDeger.Size = new Size(42, 15);
            lblHizDeger.Text = "Normal";

            // rtbTtsMetin
            rtbTtsMetin.Font = new Font("Segoe UI", 10F);
            rtbTtsMetin.Location = new Point(15, 108);
            rtbTtsMetin.Name = "rtbTtsMetin";
            rtbTtsMetin.Size = new Size(383, 245);
            rtbTtsMetin.Text = "Merhaba, bu metin YMH 219 Görsel Programlama dersi Speech-to-Text ve Text-to-Speech uygulaması tarafından seslendirilmektedir.";

            // btnTtsBaslat
            btnTtsBaslat.BackColor = Color.SeaGreen;
            btnTtsBaslat.FlatStyle = FlatStyle.Flat;
            btnTtsBaslat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTtsBaslat.ForeColor = Color.White;
            btnTtsBaslat.Location = new Point(15, 368);
            btnTtsBaslat.Name = "btnTtsBaslat";
            btnTtsBaslat.Size = new Size(88, 34);
            btnTtsBaslat.Text = "Başlat";
            btnTtsBaslat.UseVisualStyleBackColor = false;
            btnTtsBaslat.Click += btnTtsBaslat_Click;

            // btnTtsDuraklat
            btnTtsDuraklat.BackColor = Color.DarkOrange;
            btnTtsDuraklat.Enabled = false;
            btnTtsDuraklat.FlatStyle = FlatStyle.Flat;
            btnTtsDuraklat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTtsDuraklat.ForeColor = Color.White;
            btnTtsDuraklat.Location = new Point(110, 368);
            btnTtsDuraklat.Name = "btnTtsDuraklat";
            btnTtsDuraklat.Size = new Size(95, 34);
            btnTtsDuraklat.Text = "Duraklat";
            btnTtsDuraklat.UseVisualStyleBackColor = false;
            btnTtsDuraklat.Click += btnTtsDuraklat_Click;

            // btnTtsDurdur
            btnTtsDurdur.BackColor = Color.IndianRed;
            btnTtsDurdur.Enabled = false;
            btnTtsDurdur.FlatStyle = FlatStyle.Flat;
            btnTtsDurdur.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTtsDurdur.ForeColor = Color.White;
            btnTtsDurdur.Location = new Point(212, 368);
            btnTtsDurdur.Name = "btnTtsDurdur";
            btnTtsDurdur.Size = new Size(88, 34);
            btnTtsDurdur.Text = "Durdur";
            btnTtsDurdur.UseVisualStyleBackColor = false;
            btnTtsDurdur.Click += btnTtsDurdur_Click;

            // btnTtsTemizle
            btnTtsTemizle.BackColor = Color.SlateGray;
            btnTtsTemizle.FlatStyle = FlatStyle.Flat;
            btnTtsTemizle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTtsTemizle.ForeColor = Color.White;
            btnTtsTemizle.Location = new Point(307, 368);
            btnTtsTemizle.Name = "btnTtsTemizle";
            btnTtsTemizle.Size = new Size(91, 34);
            btnTtsTemizle.Text = "Temizle";
            btnTtsTemizle.UseVisualStyleBackColor = false;
            btnTtsTemizle.Click += btnTtsTemizle_Click;

            // grpStt
            grpStt.Controls.Add(rtbSttSonuc);
            grpStt.Controls.Add(btnSttKaydet);
            grpStt.Controls.Add(btnSttTemizle);
            grpStt.Controls.Add(btnSttDurdur);
            grpStt.Controls.Add(btnSttBaslat);
            grpStt.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpStt.Location = new Point(450, 55);
            grpStt.Name = "grpStt";
            grpStt.Size = new Size(415, 420);
            grpStt.TabStop = false;
            grpStt.Text = "2. Speech-to-Text (Konuşmayı Metne Dönüştürme)";

            // btnSttBaslat
            btnSttBaslat.BackColor = Color.SeaGreen;
            btnSttBaslat.FlatStyle = FlatStyle.Flat;
            btnSttBaslat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSttBaslat.ForeColor = Color.White;
            btnSttBaslat.Location = new Point(15, 32);
            btnSttBaslat.Name = "btnSttBaslat";
            btnSttBaslat.Size = new Size(125, 34);
            btnSttBaslat.Text = "Dinlemeyi Başlat";
            btnSttBaslat.UseVisualStyleBackColor = false;
            btnSttBaslat.Click += btnSttBaslat_Click;

            // btnSttDurdur
            btnSttDurdur.BackColor = Color.IndianRed;
            btnSttDurdur.Enabled = false;
            btnSttDurdur.FlatStyle = FlatStyle.Flat;
            btnSttDurdur.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSttDurdur.ForeColor = Color.White;
            btnSttDurdur.Location = new Point(148, 32);
            btnSttDurdur.Name = "btnSttDurdur";
            btnSttDurdur.Size = new Size(125, 34);
            btnSttDurdur.Text = "Dinlemeyi Durdur";
            btnSttDurdur.UseVisualStyleBackColor = false;
            btnSttDurdur.Click += btnSttDurdur_Click;

            // btnSttTemizle
            btnSttTemizle.BackColor = Color.SlateGray;
            btnSttTemizle.FlatStyle = FlatStyle.Flat;
            btnSttTemizle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSttTemizle.ForeColor = Color.White;
            btnSttTemizle.Location = new Point(281, 32);
            btnSttTemizle.Name = "btnSttTemizle";
            btnSttTemizle.Size = new Size(117, 34);
            btnSttTemizle.Text = "Temizle";
            btnSttTemizle.UseVisualStyleBackColor = false;
            btnSttTemizle.Click += btnSttTemizle_Click;

            // rtbSttSonuc
            rtbSttSonuc.BackColor = Color.White;
            rtbSttSonuc.Font = new Font("Consolas", 9.5F);
            rtbSttSonuc.Location = new Point(15, 80);
            rtbSttSonuc.Name = "rtbSttSonuc";
            rtbSttSonuc.ReadOnly = true;
            rtbSttSonuc.Size = new Size(383, 273);
            rtbSttSonuc.Text = "";

            // btnSttKaydet
            btnSttKaydet.BackColor = Color.SteelBlue;
            btnSttKaydet.FlatStyle = FlatStyle.Flat;
            btnSttKaydet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSttKaydet.ForeColor = Color.White;
            btnSttKaydet.Location = new Point(15, 368);
            btnSttKaydet.Name = "btnSttKaydet";
            btnSttKaydet.Size = new Size(383, 34);
            btnSttKaydet.Text = "Dönüştürülen Metni Kaydet (.txt)";
            btnSttKaydet.UseVisualStyleBackColor = false;
            btnSttKaydet.Click += btnSttKaydet_Click;

            // Form1
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(880, 490);
            Controls.Add(grpStt);
            Controls.Add(grpTts);
            Controls.Add(lblAktifDurum);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "YMH 219 - Speech-to-Text ve Text-to-Speech Uygulaması";
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
            grpTts.ResumeLayout(false);
            grpTts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkHiz).EndInit();
            grpStt.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblAktifDurum;
        private GroupBox grpTts;
        private Label lblSesSecimi;
        private ComboBox cmbSesler;
        private Label lblHiz;
        private TrackBar trkHiz;
        private Label lblHizDeger;
        private RichTextBox rtbTtsMetin;
        private Button btnTtsBaslat;
        private Button btnTtsDuraklat;
        private Button btnTtsDurdur;
        private Button btnTtsTemizle;
        private GroupBox grpStt;
        private Button btnSttBaslat;
        private Button btnSttDurdur;
        private Button btnSttTemizle;
        private Button btnSttKaydet;
        private RichTextBox rtbSttSonuc;
    }
}