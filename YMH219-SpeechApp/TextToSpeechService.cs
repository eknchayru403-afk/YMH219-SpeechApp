using System;
using System.Collections.Generic;
using System.Speech.Synthesis;

namespace YMH219_SpeechApp
{
    public class TextToSpeechService : IDisposable
    {
        private readonly SpeechSynthesizer _sentezleyici;

        public bool KonusuyorMu => _sentezleyici.State == SynthesizerState.Speaking;
        public bool DuraklatildiMi => _sentezleyici.State == SynthesizerState.Paused;

        public event Action KonusmaTamamlandi;

        public TextToSpeechService()
        {
            _sentezleyici = new SpeechSynthesizer();
            _sentezleyici.SetOutputToDefaultAudioDevice();
            _sentezleyici.SpeakCompleted += (s, e) => KonusmaTamamlandi?.Invoke();
        }

        public List<string> YukluSesleriGetir()
        {
            List<string> sesler = new List<string>();
            foreach (var ses in _sentezleyici.GetInstalledVoices())
            {
                if (ses.Enabled)
                {
                    sesler.Add(ses.VoiceInfo.Name);
                }
            }
            return sesler;
        }

        public void SesSec(string sesAdi)
        {
            if (!string.IsNullOrWhiteSpace(sesAdi))
            {
                _sentezleyici.SelectVoice(sesAdi);
            }
        }

        public void HizAyarla(int hiz)
        {
            _sentezleyici.Rate = Math.Clamp(hiz, -10, 10);
        }

        public void Oku(string metin)
        {
            if (string.IsNullOrWhiteSpace(metin)) return;

            _sentezleyici.SpeakAsyncCancelAll();
            _sentezleyici.SetOutputToDefaultAudioDevice();

            // Yüklü ses Türkçe değilse (örn. Microsoft Zira Desktop) Türkçe karakterlerin okumayı durdurmaması için normalize et
            string seciliDil = _sentezleyici.Voice?.Culture?.TwoLetterISOLanguageName ?? "en";
            string okunacakMetin = seciliDil == "tr" ? metin : TurkceKarakterleriDuzelt(metin);

            _sentezleyici.SpeakAsync(okunacakMetin);
        }

        private string TurkceKarakterleriDuzelt(string metin)
        {
            return metin
                .Replace('ı', 'i').Replace('İ', 'I')
                .Replace('ğ', 'g').Replace('Ğ', 'G')
                .Replace('ü', 'u').Replace('Ü', 'U')
                .Replace('ş', 's').Replace('Ş', 'S')
                .Replace('ö', 'o').Replace('Ö', 'O')
                .Replace('ç', 'c').Replace('Ç', 'C');
        }

        public void DuraklatVeyaDevamEt()
        {
            if (_sentezleyici.State == SynthesizerState.Speaking)
            {
                _sentezleyici.Pause();
            }
            else if (_sentezleyici.State == SynthesizerState.Paused)
            {
                _sentezleyici.Resume();
            }
        }

        public void Durdur()
        {
            _sentezleyici.SpeakAsyncCancelAll();
        }

        public void Dispose()
        {
            try
            {
                _sentezleyici.SpeakAsyncCancelAll();
                _sentezleyici.Dispose();
            }
            catch { }
        }
    }
}