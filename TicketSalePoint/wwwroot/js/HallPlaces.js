$(document).ready(function () {
    
    $("td[isSold=1]").css("backgroundColor", "orange");
    $("td[isSold=1]").removeAttr('onclick');

    jQuery.validator.addMethod("checkMask", function (value, element) {
        return /\+\d{1}\(\d{3}\)\d{3}-\d{4}/g.test(value);
    });

    $.validator.addClassRules({
        orderRowId1: {
            minlength: "5"
        },
        orderRowId2: {
            checkMask: true
        }
        
    });
    $('form').validate();   

//    $('.orderRowId2').mask("+7(999)999-9999", { autoclear: false });

    $('form').submit(
        function(e) {
            $('form').validate().element($(e.target));

        });


});  //document.Ready()

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





