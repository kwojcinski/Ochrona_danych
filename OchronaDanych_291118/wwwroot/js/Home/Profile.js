﻿function deleteNote(id) {
    if (window.confirm("Czy na pewno chcesz usunąć tę notatkę?")) {
        $.ajax({
            url: "/Home/DeleteNote/" + id,
            method: "post"
        })
            .done(function (res) {
                location.reload();
            })
    }
}
var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};
$(document).ready(function () {
    var changed = getUrlParameter('c');
    if (changed === "True") {
        alert("Hasło zmienione pomyślnie");
    }

});