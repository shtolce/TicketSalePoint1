﻿// Write your JavaScript code.
function sellTicket(e) {

    $('body').load('/home/sell?id=' + e.target.id.trim() + '&EmissionId=' + e.target.getAttribute("EmissionId"));
}


