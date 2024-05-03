$(document).on("click", ".ktgEkle", async function () {//Anlık eklenmeme sorunu yaşıyorum bir şekiled çözmem lazım
    const { value: formValues } = await Swal.fire({
        title: "Kategori Ekle",
        html: '<input id="ktgAd" class="swal2-input">'
    });

   if (formValues) {
        // Değişken ismini düzelt
        var ktgAd = $("#ktgAd").val();
        $.ajax({
            type: 'POST',
            url: '/Kategori/EkleJson', // Controller ve action isimleri doğru mu kontrol et
            data: { "ktgAd": ktgAd },
            dataType: 'json',
            success: function (data) {
                var ktgId =  data.Result.Id;
                var ktgAd = '<td>' + data.Result.Ad + '</td>';
                var kitapAdeti = "<td>0</td>";
                var guncelleButon = "<td><button class='guncelle btn btn-custom' value='" +ktgId + "'>Güncelle</button></td>";
                var silButon = "<td><button class='sil btn btn-custom' value='" + ktgId + "'>Sil</button></td>";
                $("#example tbody").prepend('<tr>' + ktgAd + kitapAdeti + guncelleButon + silButon + '</tr>');
                Swal.fire({
                    icon: 'success',
                    title: 'Kategori Eklendi',
                    text: 'İşlem başarıyla gerçekleşti!'
                });

            },
        });
    }
});
//Ktg Ekle Son
$(document).on("click", ".guncelle", async function () {
    var ktgId = $(this).val();
    var ktgAdTd = $(this).closest("tr").find("td:first"); // td'yi almak için sütun için
    var ktgAd = ktgAdTd.html(); // htmt() yerine text() kullanılmalı
    const { value: formValues } = await Swal.fire({
        title: "Kategori Güncelle",
        html: '<input id="ktgAd" value="' + ktgAd + '" class="swal2-input">'
    });

    if (formValues) {
        ktgAd = $("#ktgAd").val();
        $.ajax({
            type: 'POST',
            url: '/Kategori/GuncelleJson',
            data: { "ktgId": ktgId, "ktgAd": ktgAd },
            dataType: 'json',
            success: function (data) {
                if (data === "1") {
                    ktgAdTd.html(ktgAd); // html() yerine text() kullanıl
                    Swal.fire({
                        icon: 'success',
                        title: 'Kategori Güncellendi',
                        text: 'İşlem başarıyla gerçekleşti!'
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Kategori Güncellenemedi',
                        text: 'İşlem sırasında sorun oluştu!'
                    });
                }
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Kategori Güncellenemedi',
                    text: 'İşlem sırasında sorun oluştu!'
                });
            }
        });
    }
});
//Ktg Güncelle Son
$(document).on("click", ".sil", async function () {
    var tr = $(this).parent("td").parent("tr");
    var ktgId = $(this).val();
    $.ajax({
        type: 'POST',
        url: '/Kategori/SilJson',
        data: { "ktgId": ktgId },
        dataType: 'json',
        success: function (data) {
            if (data === "1") {
                tr.remove();
                Swal.fire({
                    icon: 'success',
                    title: 'Kategori Silindi',
                    text: 'İşlem başarıyla gerçekleşti!'
                });
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Kategori Silinemedi',
                    text: 'İşlem sırasında sorun oluştu!'
                });
            }
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Kategori Silinemedi',
                text: 'İşlem sırasında sorun oluştu!'
            });
        }
    });
});
//Ktg Sil Son
$(document).on("click", ".yazarEkle", async function () {//Anlık eklenmeme sorunu yaşıyorum bir şekiled çözmem lazım
    const { value: formValues } = await Swal.fire({
        title: "Yazar Ekle",
        html: '<input id="yzrAd" class="swal2-input">'
    });

    if (formValues) {
        // Değişken ismini düzelt
        var yzrAd = $("#yzrAd").val();
        $.ajax({
            type: 'POST',
            url: '/Yazar/EkleJson', // Controller ve action isimleri doğru mu kontrol et
            data: { "yzrAd": yzrAd },
            dataType: 'json',
            success: function (data) {
                var yzrId = data.Result.Id;
                var yzrAd = '<td>' + data.Result.Ad + '</td>';
                var kitapAdeti = "<td>0</td>";
                var guncelleButon = "<td><button class='guncelle btn btn-custom' value='" + yzrId + "'>Güncelle</button></td>";
                var silButon = "<td><button class='sil btn btn-custom' value='" + yzrId + "'>Sil</button></td>";
                $("#example tbody").prepend('<tr>' + yzrAd + kitapAdeti + guncelleButon + silButon + '</tr>');
                Swal.fire({
                    icon: 'success',
                    title: 'Yazar Eklendi',
                    text: 'İşlem başarıyla gerçekleşti!'
                });

            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Yazar Eklenemedi',
                    text: 'İşlem sırasında sorun oluştu!'
                });
            }
        });
    }
});
//Yzr Ekle Son
$(document).on("click", ".yazarGuncelle", async function () {
    var yzrId = $(this).val();
    var yzrAdTd = $(this).closest("tr").find("td:first"); // td'yi almak için sütun için
    var yzrAd = yzrAdTd.html(); // htmt() yerine text() kullanılmalı
    const { value: formValues } = await Swal.fire({
        title: "Yazar Güncelle",
        html: '<input id="yzrAd" value="' + yzrAd + '" class="swal2-input">'
    });

    if (formValues) {
        yzrAd = $("#yzrAd").val();
        $.ajax({
            type: 'POST',
            url: '/Yazar/GuncelleJson',
            data: { "yzrId": yzrId, "yzrAd": yzrAd },
            dataType: 'json',
            success: function (data) {
                if (data === "1") {
                    yzrAdTd.html(yzrAd); // html() yerine text() kullanıl
                    Swal.fire({
                        icon: 'success',
                        title: 'Yazar Güncellendi',
                        text: 'İşlem başarıyla gerçekleşti!'
                    });
                } else {
                    Swal.fire({
                        icon: 'error',
                        title: 'Yazar Güncellenemedi',
                        text: 'İşlem sırasında sorun oluştu!'
                    });
                }
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Yazar Güncellenemedi',
                    text: 'İşlem sırasında sorun oluştu!'
                });
            }
        });
    }
});
//Yzr Güncelle Son
$(document).on("click", ".yazarSil", async function () {
    var tr = $(this).parent("td").parent("tr");
    var yazarId = $(this).val();
    $.ajax({
        type: 'POST',
        url: '/Yazar/SilJson',
        data: { "yazarId": yazarId },
        dataType: 'json',
        success: function (data) {
            if (data === "1") {
                tr.remove();
                Swal.fire({
                    icon: 'success',
                    title: 'Yazar Silindi',
                    text: 'İşlem başarıyla gerçekleşti!'
                });
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Yazar Silinemedi',
                    text: 'İşlem sırasında sorun oluştu!'
                });
            }
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Yazar Silinemedi',
                text: 'İşlem sırasında sorun oluştu!'
            });
        }
    });
});
//Yzr Sil Son
$(document).on("click", "#kategoriEkle", function () {
    var secilenKategoriAd = $("#kategoriler").val();
    if (secilenKategoriAd != null && secilenKategoriAd != "") {
        var secilenId = $("#kategoriler option:selected").attr("data-id");
        $("#eklenenKategoriler").append('<div id="' + secilenId + '" class="col-md-1 bg-primary kategoriSil" style="margin-right:2px; margin-bottom:2px;">' + secilenKategoriAd + '</div>');
        $("#kategoriler option:selected").remove();
    }
});
$(document).on("click", ".kategoriSil", function () {
    var id = $(this).attr("id");
    var kategoriAd = $(this).html();
    $("#kategoriler").append('<option data-id="' + id + '">' + kategoriAd + '</option>');
    $(this).remove();
});
$(document).on("click", "#kitapKaydet", function () {
    var degerler = {
        kategoriler: [],
        yazar: $("#yazar option:selected").attr("id"),
        kitapAd: $("#kitapAd").val(),
        kitapAdet: $("#kitapAdet").val(),
        kitapIsbn: $("#kitapIsbn").val()
    };

    $("#eklenenKategoriler div").each(function () {
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    });

    $.ajax({
        type: 'POST',
        url: '/Kitap/EkleJson',
        data: JSON.stringify(degerler),
        dataType: 'json',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    icon: 'success',
                    title: 'Kitap başarıyla eklendi',
                    text: 'İşlem başarılı'
                });
            }
            else if (gelenDeg == "bosOlamaz")
            {
                Swal.fire({
                    icon: 'error',
                    title: 'Alanlar Boş Kalamaz!!',
                    text: 'Lütfen Boş Alanları doldurunuz.'
                });
            }
        },
    });
});
//Ktp Kaydet Son