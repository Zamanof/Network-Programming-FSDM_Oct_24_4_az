using System.Net;
using System.Net.Sockets;
using System.Text;

Socket client = new(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

var connectEp = new IPEndPoint(IPAddress.Loopback, 27001);

var message = """
    Çox keçmişəm bu dağlardan,
    Durna gözlü bulaqlardan;
    Eşitmişəm uzaqlardan
    Sakit axan arazları;
    Sınamışam dostu, yarı…

    El bilir ki, sən mənimsən,
    Yurdum, yuvam, məskənimsən,
    Anam, doğma vətənimsən!
    Ayrılarmı könül candan?
    Azərbaycan, Azərbaycan!

    Mən bir uşaq, sən bir ana,
    Odur ki, bağlıyam sana:
    Hankı səmtə, hankı yana
    Hey uçsam da yuvam sənsən,
    Elim, günüm, obam sənsən!

    Fəqət səndən gen düşəndə,
    Ayrılıq məndən düşəndə,
    Saçlarıma dən düşəndə
    Boğar aylar, illər məni,
    Qınamasın ellər məni.

    Dağlarının başı qardır,
    Ağ örpəyın buludlardır.
    Böyük bir keçmişin vardır;
    Bilinməyir yaşın sənin,
    Nələr çəkmiş başın sənin.

    Düşdün uğursuz dillərə,
    Nəhs aylara, nəhs illərə.
    Nəsillərdən nəsillərə
    Keçən bir şöhrətin vardır;
    Oğlun, qızın bəxtiyardır…

    Hey baxıram bu düzlərə,
    Ala gözlü gündüzlərə;
    Qara xallı ağ üzlərə
    Könül istər şeir yaza;
    Gəncləşirəm yaza-yaza…

    Bir tərəfin bəhri-Xəzər,
    Yaşılbaş sonalar gəzər;
    Xəyalım dolanar gəzər
    Gah Muğanı, gah Eldarı,
    Mənzil uzaq, ömür yarı!

    Sıra dağlar, gen dərələr,
    Ürək açan mənzərələr…
    Ceyran qaçar, cüyür mələr,
    Nə çoxdur oylağın sənin!
    Aranın, yaylağın sənin.

    Keç bu dağdan, bu arandan,
    Astaradan, Lənkərandan.
    Afrikadan, Hindistandan
    Qonaq gəlir bizə quşlar,
    Zülm əlindən qurtulmuşlar…

    Bu yerlərdə limon sarı,
    Əyir, salır budaqları;
    Dağlarının dümağ qarı
    Yaranmışdır qarlı qışdan,
    Bir səngərdir yaranışdan.

    Lənkəranın gülü rəng-rəng,
    Yurdumuzun qızları tək.
    Dəmlə çayı, tök ver görək,
    Anamın dilbər gəlini!
    Yadlara açma əlini.

    Sarı sünbül bizim çörək,
    Pambığımız çiçək-çiçək,
    Hər üzümdən bir şirə çək
    Səhər-səhər acqarına,
    Qüvvət olsun qollarına.

    Min Qazaxda köhlən ata,
    Yalmanına yata-yata,
    At qan tərə bata-bata,
    Göy yaylaqlar belinə qalx,
    Kəpəz dağdan Göy gölə bax!..

    Ey azad gün, azad insan,
    Doyunca iç bu bahardan!
    Bizim xalı-xalçalardan
    Sar çinarlar kölgəsinə,
    Alqış günəş ölkəsinə!

    Könlüm keçir Qarabağdan,
    Gah bu dağdan, gah o dağdan;
    Axşam üstü qoy uzaqdan
    Havalansın Xanın səsi,
    Qarabağın şikəstəsi.

    Gözəl Vətən! Mənan dərin,
    Beşiyisən gözəllərin
    Aşıq deyər sərin-sərin,
    Son günəşin qucağısan
    Şeir, sənət ocağısan.

    Ölməz könül, ölməz əsər
    Nizamilər, Füzulilər!
    Əlin qələm, sinən dəftər,
    De gəlsin hər nəyin vardır,
    Deyilən söz yadigardır.

    Bir dön bizım Bakıya bax,
    Sahilləri çıraq-çıraq,
    Buruqları hayqıraraq
    Nərə salır boz çollərə,
    İşıqlanır hər dağ, dərə.

    Nazlandıqca sərin külək
    Sahillərə sinə gərək,
    Bizim Bakı – bizim ürək!
    İşıqdadır qüvvət sözü,
    Səhərlərin ülkər gözü.

    Gözəl Vətən! O gün ki, sən
    Al bayraqlı bir səhərdən
    İlham aldın…yarandım mən.
    Gülür torpaq, gülür insan
    Qoca Şərqin qapısısan.

    El bilir ki, sən mənimsən,
    Yurdum, yuvam, məskənimsən,
    Anam, doğma vətənimsən!
    Ayrılarmı könül candan?
    Azərbaycan, Azərbaycan!
    """;

int count = 0;
while (true)
{
    var bytes = Encoding.UTF8
        .GetBytes(message[count++ % message.Length].ToString());
    Thread.Sleep(100);
    client.SendTo(bytes, connectEp);
}
