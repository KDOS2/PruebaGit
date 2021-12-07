

window.onload = isPostBack;

function isPostBack() {    
    cancelEdition();
}

function Editar(idMovie, movieName, genderId, duration) {
    $("#id").val(idMovie);
    $("#MovieName").val(movieName);
    $("#Duration").val(duration);
    $("#GenderId").val(genderId);
    $("#cancelEdit").css("display", "block");
}