// Write your JavaScript code.


function sellTicketForm(e) {
   // $('body').load('/home/sellForm?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
    
    var form = document.createElement("form");
    form.setAttribute("method", "GET");
    form.setAttribute("action", '/home/sellForm?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
    document.body.appendChild(form);

    var filters = document.createElement('input');
    filters.setAttribute('id', e.target.id.trim());
    filters.setAttribute('curEmissionId', e.target.getAttribute("curEmissionId"));
    form.appendChild(filters);
    form.submit();

}


function sellTicket(e) {
    e.preventDefault();
    $('input[type="text"]').each(function (name, value) {
        alert(name);
    });

    //$('body').load('/home/sell?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
}


