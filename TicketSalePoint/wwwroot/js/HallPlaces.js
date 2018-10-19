$(document).ready(function () {
    
    $("td[isSold=1]").css("backgroundColor", "orange");
    $("td[isSold=1]").removeAttr('onclick');
    

    $.validator.addClassRules({
        orderRowId1: {
            required: true,
            digits: true,
            min: 0,
            max: 100
        },
        orderRowId2: {
            required: true,
            digits: true,
            min: 0,
            max: 100
        }
    });


        $('#OrderForm').validate({
            rules: {
                kol: {
                    required: true,
                    digits: true,
                    min: 1,
                    max: 30
                }
                , kolChildren: {
                    required: true,
                    min: 1,
                    max: 30
                }
                , fIO: {
                    required: true
                }
                , phone: {
                    required: true
                }
                , fIOChildren: {
                    required: true
                }
                , age: {
                    required: true
                }

            },
            highlight: function (element, errorClass) {
                $(element).add($(element).parent()).addClass("invalidElem");
            },
            unhighlight: function (element, errorClass) {
                $(element).add($(element).parent()).removeClass("invalidElem");
            },
            errorElement: "tr",
            errorClass: "errorMessages",
            validClass: "success"
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





