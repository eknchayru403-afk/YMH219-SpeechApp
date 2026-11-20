# YMH 219 - Speech-to-Text ve Text-to-Speech Uygulaması

* **Öğrenci Adı Soyadı:** Hayrunnisa Ekinci
* **Öğrenci Numarası:** 240541043
* **Ders:** YMH 219 - Görsel Programlama / Nesne Yönelimli Programlama

## Proje Hakkında

Bu proje, C# Windows Forms (.NET 10.0) ve `System.Speech` kütüphanesi kullanılarak geliştirilmiş; yazılı metni sesli olarak okuyan (**Text-to-Speech**) ve mikrofondan alınan konuşmayı zaman damgalı metne dönüştüren (**Speech-to-Text**) nesne yönelimli bir masaüstü uygulamasıdır.

## Temel Özellikler & OOP Mimarisi

* **Text-to-Speech Servisi (`TextToSpeechService` Sınıfı):** `SpeechSynthesizer` bileşenini kapsüller; sistemde yüklü ses profillerini listeleme, konuşma hızı ayarı (`-10` ile `+10` arası), asenkron seslendirme (`SpeakAsync`), duraklatma/devam ettirme, durdurma ve `IDisposable` kaynak temizliği sağlar.
* **Speech-to-Text Servisi (`SpeechToTextService` Sınıfı):** `SpeechRecognitionEngine` altyapısını kapsüller; mikrofon ses girişini sürekli dinleme modunda (`RecognizeMode.Multiple`) işler, tanınan konuşmaları olay tabanlı (`Action<string>`) olarak arayüze iletir ve donanım/servis hatalarını güvenli biçimde yakalar.
* **Canlı İşlem Durumu Göstergesi:** Arayüzün üst bölümünde aktif çalışan mod (Seslendirme, Duraklatıldı, Mikrofon Dinleniyor, Hata) renk kodlu durum çubuğuyla anlık gösterilir.
* **Zaman Damgası ve Dosya Dışa Aktarımı:** Konuşma tanıma sonuçları `[HH:mm:ss]` saat bilgisiyle listelenir ve tek tıkla `.txt` dosyası olarak dışa aktarılabilir.

## Bilinen Sınırlamalar ve Geliştirme Notları

* Masaüstü `.NET System.Speech` (SAPI 5) altyapısı Windows işletim sisteminde yüklü olan yerel dil ve ses paketlerine bağlıdır; Türkçe konuşma tanıma paketi Windows masaüstü SAPI motorunda yerleşik bulunmadığından İngilizce (`en-US`) tanıma modeli kullanılmaktadır.
* Mikrofon donanımı bulunmayan veya ses hizmeti devre dışı olan sistemlerde konuşma tanıma özelliği çalışmaz ve kullanıcıya hata uyarısı gösterilir.

* 
## Kurulum ve Çalıştırma

1. Depoyu bilgisayarınıza klonlayın:
   ```bash
   git clone https://github.com/eknchayru403-afk/YMH219-SpeechApp.git
