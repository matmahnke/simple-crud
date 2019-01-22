function confirmarExclusao(id) {
    var resposta = confirm("Você deseja excluir?");
    if (resposta) {
        $.ajax({
            type: "POST",
            url: "/Quarto/Delete/",
            ajaxasync: true,
            data: { ID: id },
            success: function (data) {
                alert(data.Message);
            },
            error: function (data) {
                alert(data.Message);
            }
        });
    }
    return false;
}