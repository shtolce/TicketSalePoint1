// Write your JavaScript code.

function sellTicketForm(e) {
    $('body').load('/home/sellForm?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
}


function sellTicket(e) {
    $('body').load('/home/sell?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
}


