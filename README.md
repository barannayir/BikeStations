
# BikeStations

BikeStationsApi projesi içinde bulundurduğu bike.json ve stations.json dosyaları için bir sunucu işlevi görüyor ve temel crud işlemleri bu proje üzerinden gerçekleşiyor.

BikeStationsMvc projesi REST protokolü ile bu apiden ilgili verileri çekip sunan proje işlevini görüyor. Temel iki sayfadan oluşuyor:
* listeleme/arama sayfası 
* yeni bisiklet ekleme sayfası

Listeleme sayfası veriyi alıp KnockoutJS aracılığıyla listeliyor, daha sonra jslinq aracılığıyla bu listelenen veride arama yapmamızı sağlıyor. Aynı zamanda Highcharts aracılığıyla istasyon/bisiklet bilgisini görselleştiriyor.

Yeni bisiklet ekleme sayfası REST iletişimle ilgili json dosyasına yeni bisiklet verisi eklememizi sağlıyor.
## Kullanılan Teknolojiler

* .Net 6
* KnockoutJS 
* Highcharts 
* JSLINQ
* Angular
  
