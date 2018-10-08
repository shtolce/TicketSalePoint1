// Write your JavaScript code.
function sellTicket(e) {
    //alert('/home/sell?id=' + e.target.id);
    $('body').load('/home/sell?id=' + e.target.id);
}
