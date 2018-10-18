$(document).ready(function () {
    
    $("td[isSold=1]").css("backgroundColor", "orange");
    $("td[isSold=1]").removeAttr('onclick');
    var newOrderTemplateRow = $(".orderRowTemplate").clone().removeClass("orderRowTemplate");
    newOrderTemplateRow.appendTo(".OrderTableTemplate").fadeIn();
    var newOrderTemplateRow = $(".orderRowTemplateChildren").clone().removeClass("orderRowTemplateChildren");
    newOrderTemplateRow.appendTo(".OrderTableTemplateChildren").fadeIn();
    $("form").validate({
        rules: {
            kol: { required: true }
            , ticketNumber: { required: true }

        }

    });


});

function ticketsNumberChange() {

    var ticketNumber = $("#ticketNumber").val();
    $(".OrderTableTemplate tr:gt(2)").remove();
    for (i = 1; i <= ticketNumber-1; i++) {
        var newOrderTemplateRow = $(".orderRowTemplate").clone().removeClass("orderRowTemplate");
        newOrderTemplateRow.appendTo(".OrderTableTemplate").fadeIn();
    }

} 

function ticketsNumberChangeChildren() {
    var ticketNumber = $("#ticketNumberChildren").val();
    $(".OrderTableTemplateChildren tr:gt(2)").remove();
    for (i = 1; i <= ticketNumber - 1; i++) {
        var newOrderTemplateRow = $(".orderRowTemplateChildren").clone().removeClass("orderRowTemplateChildren");
        newOrderTemplateRow.appendTo(".OrderTableTemplateChildren").fadeIn();
    }

}

