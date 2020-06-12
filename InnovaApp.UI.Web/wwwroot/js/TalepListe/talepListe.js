//$("LoadingStatus").html("Loading...");

//$.get("RequestOrder/GetTalepList", null, DataBind);
//function DataBind(TalepList) {
//    var SetData = $('#TalepListTable');
//    for (var i = 0; i < TalepList.length; i++) {

//        console.log(TalepList[i].guid)
//        var Data = "<tr class='row_'" + TalepList[i].Id + "'>" +
//            "<td>" + TalepList[i].sube + "</td>" +
//            "<td>" + TalepList[i].belgeNo + "</td>" +
//            "<td>" + TalepList[i].tarih + "</td>" +
//            "<td>" + TalepList[i].aciklama + "</td>" +
//            "<td>" + TalepList[i].belgeDurum + "</td>" +
//            "<td>" + "<a href='#' class='btn btn-block btn-info' onclick='EditTalep(" + TalepList[i].belgeNo + ")'><i class='far fa-eye'></i></span></a>" + "</td>"

//            "</tr>";
//        SetData.append(Data);
//        $("#LoadingStatus").html("  ");


//    }
//}

//$.get("RequestOrder/GetTalepList", null, DataBind);
//function DataBind(TalepList) {
//    console.log("asaasas");
//    console.log(TalepList.length);
//    var SetData = $('#SetTalepList');
//    for (var i = 0; i < TalepList.length; i++) {

//        console.log(TalepList[i].guid)
//        var Data = "<tr class='row_'" + TalepList[i].Id + "'>" +
//            "<td>" + TalepList[i].sira + "</td>" +
//            "<td>" + TalepList[i].stokKodu + "</td>" +
//            "<td>" + TalepList[i].stokAdi + "</td>" +
//            "<td>" + TalepList[i].birim + "</td>" +
//            "<td>" + TalepList[i].miktar + "</td>" +
//            "<td>" + "<a href='#' class='btn btn-warning' onclick='EditTalep(" + TalepList[i].id + ")'><i class='far fa-edit'></i> </span></a>" + "</td>" +
//            "<td>" + "<a href='#' class='btn btn-danger' onclick='DeleteTalep(" + TalepList[i].id + ")'><i class='far fa-trash-alt'></i> </span></a>" + "</td>" +
//            "</tr>";
//        SetData.append(Data);
//        $("#LoadingStatus").html("  ");


//    }
//}

//function TalepListele() {
//    $("LoadingStatus").html("Loading...");

//    $.get("RequestOrder/GetTalepList", null, DataBind);
//    function DataBind(TalepList) {
//        var SetData = $('#TalepListTable');
//        for (var i = 0; i < TalepList.length; i++) {

//            console.log(TalepList[i].guid)
//            var Data = "<tr class='row_'" + TalepList[i].Id + "'>" +
//                "<td>" + TalepList[i].sube + "</td>" +
//                "<td>" + TalepList[i].belgeNo + "</td>" +
//                "<td>" + TalepList[i].tarih + "</td>" +
//                "<td>" + TalepList[i].aciklama + "</td>" +
//                "<td>" + TalepList[i].belgeDurum + "</td>" +
//                "<td>" + "<a href='#' class='btn btn-block btn-info' onclick='EditTalep(" + TalepList[i].belgeNo + ")'><i class='far fa-eye'></i></span></a>" + "</td>"

//            "</tr>";
//            SetData.append(Data);
//            $("#LoadingStatus").html("  ");


//        }
//    }
//}

function TalepListele() {
    var data = $('#filterListForm').serialize();
    console.log(data);
    $.get("RequestOrder/GetTalepList", data, DataBind);
    $("#TalepListTable").empty();
    function DataBind(TalepList) {
        var SetData = $('#TalepListTable');
        for (var i = 0; i < TalepList.length; i++) {

            console.log(TalepList[i].guid)
            var Data = "<tr class='row_'" + TalepList[i].Id + "'>" +
                "<td>" + TalepList[i].sube + "</td>" +
                "<td>" + TalepList[i].belgeNo + "</td>" +
                "<td>" + TalepList[i].tarih + "</td>" +
                "<td>" + TalepList[i].aciklama + "</td>" +
                "<td>" + TalepList[i].belgeDurum + "</td>" +
                "<td>" + "<a href='RequestOrder/Detail/?belgeNo=" + TalepList[i].belgeNo + "' class='btn btn-block btn-info' ><i class='far fa-eye'></i></span></a>" + "</td>"

            "</tr>";
            SetData.append(Data);
            $("#LoadingStatus").html("  ");


        }
    }
}

function YeniTalep() {
    window.location.href = "/RequestOrder/Detail?belgeNo=&subeId=" + $("#drpSube").val();
}

function TalepFiltreTemizle() {
    $('#filterListForm').trigger("reset");
    $("#drpSube").val(1);
}


function AddNewTalep(TalepId) {
    $("#form")[0].reset();
    $("#ModalTitle").html("Yeni Kayıt Ekle");
    $("#MyModal").modal();
}