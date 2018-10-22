var isSubmitAllowed;
function validatePass() {
    $('form input').each(function (index, elem)
    {
        if (elem.className == 'orderRowId1' || elem.className == 'orderRowId2')
        {
            $(elem).rules("add",
            {
                min: 10,
                max: 20,
                required: true,
                messages:
                {
                    max: "больше 20",
                    min: "меньше 10"
                }
            })
        }
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
            },
            errorElement: "tr",
            errorClass: "errorMessages",
            validClass: "success"
        });
    validatePass();
    $('form').submit(function()
    {
        var areAllFieldsValid = true;
        $('form input').each(function(e)
        {
            $('form input').validate().element($(this));
            var attr = $(this).attr('aria-invalid');
            if (typeof attr !== typeof undefined)
            {
                if ($(this).attr('aria-invalid') && (this.type != 'hidden'))
                    areAllFieldsValid = false;
            }
        });
        alert(areAllFieldsValid);
        return (areAllFieldsValid);
    });

});  //document.Ready()

function ticketsNumberChange()
{
    var ticketNumber = $("#ticketNumber").val();
    $(".OrderTableTemplate tr:gt(2)").remove();
    for (i = 1; i <= ticketNumber - 1; i++)
    {
        var newOrderTemplateRow = $(".orderRowTemplate").clone().removeClass("orderRowTemplate");
        newOrderTemplateRow.appendTo(".OrderTableTemplate").fadeIn();
    }
    validatePass();
    $('form input').each(function (e)
    {
            $('form').validate().element($(this));
    });

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

    validatePass();

    $('form input').each(function (e)
    {
        $('form').validate().element($(this));
    });

}





