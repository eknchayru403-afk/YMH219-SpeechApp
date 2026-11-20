using System;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;

namespace YMH219_SpeechApp
{
    public class SpeechToTextService : IDisposable
    {
        private SpeechRecognitionEngine _tanimaMotoru;

        public bool DinliyorMu { get; private set; }
        public string AktifDil { get; private set; } = "Bilinmiyor";

        public event Action<string> KonusmaTanindi;
        public event Action<string> HataOlustu;

        public void DinlemeyiBaslat()
        {
            if (DinliyorMu) return;

            var yukluTaniyicilar = SpeechRecognitionEngine.InstalledRecognizers();
            if (yukluTaniyicilar.Count == 0)
            {
                throw new InvalidOperationException("Sistemde yüklü bir Windows Konuşma Tanıma (Speech Recognition) paketi bulunamadı.");
            }

            // Türkçe varsa öncelikle Türkçe, yoksa sistemdeki ilk uygun konuşma tanıyıcıyı seç
            RecognizerInfo secilen = yukluTaniyicilar
                .FirstOrDefault(r => r.Culture.Name.StartsWith("tr", StringComparison.OrdinalIgnoreCase))
                ?? yukluTaniyicilar.FirstOrDefault(r => r.Culture.Equals(CultureInfo.CurrentUICulture))
                ?? yukluTaniyicilar[0];

            AktifDil = secilen.Culture.DisplayName;

            _tanimaMotoru?.Dispose();
            _tanimaMotoru = new SpeechRecognitionEngine(secilen);
            _tanimaMotoru.LoadGrammar(new DictationGrammar());
            _tanimaMotoru.SetInputToDefaultAudioDevice();

            _tanimaMotoru.SpeechRecognized += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Result?.Text))
                {
                    KonusmaTanindi?.Invoke(e.Result.Text);
                }
            };

            _tanimaMotoru.RecognizeCompleted += (s, e) =>
            {
                if (e.Error != null)
                {
                    DinliyorMu = false;
                    HataOlustu?.Invoke(e.Error.Message);
                }
            };

            _tanimaMotoru.RecognizeAsync(RecognizeMode.Multiple);
            DinliyorMu = true;
        }

        public void DinlemeyiDurdur()
        {
            if (!DinliyorMu || _tanimaMotoru == null) return;

            try
            {
                _tanimaMotoru.RecognizeAsyncStop();
            }
            catch { }
            finally
            {
                DinliyorMu = false;
            }
        }

        public void Dispose()
        {
            try
            {
                DinlemeyiDurdur();
                _tanimaMotoru?.Dispose();
            }
            catch { }
        }
    }
}