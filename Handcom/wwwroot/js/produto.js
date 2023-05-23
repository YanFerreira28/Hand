function CallFunction() {
    $.ajax({
        url: "/filtro",
        type: 'GET',
        data: { filter: $("#filter").val() },
        success: function (data) {
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}