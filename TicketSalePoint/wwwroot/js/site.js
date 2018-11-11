// Write your JavaScript code.


function sellTicketForm(e) {
//    $('container body-content').load('/home/sellForm?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));

    var form = document.createElement("form");
    document.body.appendChild(form);
    form.method = "POST";
    //alert('/home/sellForm?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
    form.action = '/home/sellForm';
    
    var element1 = document.createElement("input");

    element1.name = 'id';
    element1.type = 'hidden';
    element1.value = e.target.id.trim();
    form.appendChild(element1);
    var element2 = document.createElement("input");
    element2.name = 'curEmissionId';
    element2.type = 'hidden';
    element2.value = e.target.getAttribute("curEmissionId");
    form.appendChild(element2);
    
    form.submit();


}


function sellTicket(e) {
    e.preventDefault();
    $('input[type="text"]').each(function (name, value) {
        alert(name);
    });

    //$('body').load('/home/sell?id=' + e.target.id.trim() + '&curEmissionId=' + e.target.getAttribute("curEmissionId"));
}


