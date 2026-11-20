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
            _sentezleyici.SpeakAsync(metin);
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