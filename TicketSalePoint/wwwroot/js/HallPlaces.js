$(document).ready(function () {
    
    if ($("td, .hallPlaces").attr('isSold')==1) {
        alert($(this).attr('id'));
        $("td, .hallPlaces").css("backgroundColor", "yellow");
    }


});