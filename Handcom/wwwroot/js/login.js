function CallFunctionLogin() {
    $.ajax({
        url: "/entrar",
        type: 'POST',
        data: { Email: $("#Email").val(), Password: $("#Password").val() },
        success: function (data) {
            window.location.href = "/Products/Index?userId=" + data.userId;
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

function CallFunctionRegister() {
    $.ajax({
        url: "/registrar",
        type: 'POST',
        data: { Email: $("#Email").val(), Password: $("#Password").val() },
        success: function (data) {
            window.location.href = "/Index";
        },
        error: function (data) {
            alert("verifique os dados informados");
        }
    });
}