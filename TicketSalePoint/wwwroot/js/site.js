// Write your JavaScript code.

function sellTicketForm(e) {
    $('body').load('/home/sellForm?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
}


function sellTicket(e) {
    e.preventDefault();
    $('input[type="text"]').each(function (name, value) {
        alert(name);
    });

    //$('body').load('/home/sell?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
}


