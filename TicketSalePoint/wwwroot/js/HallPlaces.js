var isSubmitAllowed;


// Write your JavaScript code.
/*
function sellTicketForm(e) {
//    $('body').load('/home/sellForm?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
    $('body').load('https://ticketsalepoint20181107014415.azurewebsites.net/home/sellForm?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
}


function sellTicket(e) {
    e.preventDefault();
    $('input[type="text"]').each(function (name, value) {
        alert(name);
    });

    //$('body').load('/home/sell?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
}

*/



function validatePass()
{
    $('form input').each(function (index, elem)
    {
        $("form").data('validator').resetForm();

        if (elem.id == 'ticketNumber' || elem.id == 'ticketNumberChildren')
        {
            $(elem).rules("add",
            {
                required: true,
                min: 1,
                max: 30,
                messages:
                {
                       required: "обязательное поле",
                       min: "некорретный ввод",
                       max: "<=30"
                }
            })
        };
        if (elem.className == 'orderRowId1' )
        {
            $(elem).rules("add",
            {
                required: true,
                minlength: 4,
                messages:
                {
                       required:  "обязательное поле_",
                       minlength: "Введите корректное имя"
                },
                highlight: function (element, errorClass)
                {
                    $(element).add($(element).parent()).addClass("invalidElem");
                },
                unhighlight: function (element, errorClass)
                {
                    $(element).add($(element).parent()).removeClass("invalidElem");
                }


            })
        };
        if (elem.className == 'orderRowId2') {
            $(elem).rules("add",
                {
                    required: true,
                    minlength: 10,
                    phoneUS: true,
                    messages:
                    {
                        required: "обязательное поле",
                        minlength: "Введите номер телефона"
                    },
                    highlight: function (element, errorClass)
                    {
                        $(element).add($(element).parent()).addClass("invalidElem");
                    },
                    unhighlight: function (element, errorClass)
                    {
                        $(element).add($(element).parent()).removeClass("invalidElem");
                    }

                })
        };
        if (elem.className == 'orderRowId1Ch') {
            $(elem).rules("add",
                {
                    required: true,
                    minlength: 4,
                    messages:
                        {
                            required: "обязательное поле",
                            minlength: "Введите правильное имя ребенка"
                        },
                    highlight: function (element, errorClass) {
                        $(element).add($(element).parent()).addClass("invalidElem");
                    },
                    unhighlight: function (element, errorClass) {
                        $(element).add($(element).parent()).removeClass("invalidElem");
                    }


                })
        };
        if (elem.className == 'orderRowId2Ch')
        {
            $(elem).rules("add",
                {
                    required: true,
                    min: 1,
                    max: 15,
                    messages:
                        {
                            required: "обязательное поле",
                            min: "неправильно введен возраст"
                        },
                    highlight: function (element, errorClass)
                    {
                        $(element).add($(element).parent()).addClass("invalidElem");
                    },
                    unhighlight: function (element, errorClass)
                    {
                        $(element).add($(element).parent()).removeClass("invalidElem");
                    }
                })
        };
    });
}


$(document).ready(function ()
{


    $("td[isSold=1]").css("backgroundColor", "orange");
    $("td[isSold=1]").removeAttr('onclick');
    $('form').validate(
    {
         highlight: function (element, errorClass)
         {
            $(element).add($(element).parent()).addClass("invalidElem");
         },
         unhighlight: function (element, errorClass)
         {
            $(element).add($(element).parent()).removeClass("invalidElem");
         }
    });

    jQuery.validator.addMethod('phoneUS', function (phone_number, element) {
        phone_number = phone_number.replace(/\s+/g, '');
        return this.optional(element) || phone_number.length > 9 &&
            phone_number.match(/^(8|\+7)\(\d{3}\)\d{7}$/);
    }, 'Please enter a valid phone number.'); 

    $('form').submit(function ()
    {
        var areAllFieldsValid = true;
        jQuery.validator.messages.required = "";
        $('form input').each(function (index, elem)
        {
            validatePass();
            if (!$(elem).valid())
            {
                areAllFieldsValid = false;
            }
        });
        return (areAllFieldsValid);
    });
    $('input').blur(function(e) {
        $('form').validate().element($(e.target));
    });

    $('#phone').mask('+7(000)0000000');


}); 


function ticketsNumberChange()
{
    var ticketNumber = $("#ticketNumber").val();
    $(".OrderTableTemplate tr:gt(2)").remove();
    for (i = 1; i <= ticketNumber - 1; i++)
    {
        var newOrderTemplateRow = $(".orderRowTemplate").clone().removeClass("orderRowTemplate");
        newOrderTemplateRow.appendTo(".OrderTableTemplate").fadeIn();
    }
}
function ticketsNumberChangeChildren()
{
    var ticketNumber = $("#ticketNumberChildren").val();
    $(".OrderTableTemplateChildren tr:gt(2)").remove();
    for (i = 1; i <= ticketNumber - 1; i++)
    {
        var newOrderTemplateRow = $(".orderRowTemplateChildren").clone().removeClass("orderRowTemplateChildren");
        newOrderTemplateRow.appendTo(".OrderTableTemplateChildren").fadeIn();
    }

}
