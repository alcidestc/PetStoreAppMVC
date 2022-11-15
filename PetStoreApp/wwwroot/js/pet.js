//actualizar categoria
$("#Category_Name").change(function () {
    console.log($(this).val());
});

//agregar fila para arreglo de fotos
$("#AgregarFilaPhotosUrl").click(function () {
    var rowCount = parseInt($("#total").val());
    rowCount++;
    $("#total").val(rowCount);
    var html = '';
    html += '<div id="inputRow" class="mb-3 input-group">';
    html += '<input type="text" name="PhotoUrls[' + (rowCount - 1) + ']" class="form-control" />';
    html += '<button id="RemoverFila" type="button" class="btn btn-outline-danger">Borrar</button>';
    html += '</div>';

    $('#NuevaFila').append(html);
});

$(document).on('click', '#RemoverFila', function () {
    var rowCount = parseInt($("#total").val());
    rowCount--;
    $("#total").val(rowCount);
    $(this).closest('#inputRow').remove();
});

//agregar fila para tags

$("#AgregarFilaTags").click(function () {
    var rowCount = parseInt($("#totalTags").val());
    rowCount++;
    $("#totalTags").val(rowCount);
    var html = '';
    html += '<div id="inputRowTags" class="mb-3 input-group">';
    html += '<input type="hidden" value="' + (rowCount - 1) + '" name="Tags[' + (rowCount - 1) + '].Id" class="form-control" />';
    html += '<input type="text" name="Tags[' + (rowCount - 1) + '].Name" class="form-control" />';
    html += '<button id="RemoverFilaTags" type="button" class="btn btn-outline-danger">Borrar</button>';
    html += '</div>';

    $('#NuevaFilaTags').append(html);
});

$(document).on('click', '#RemoverFilaTags', function () {
    var rowCount = parseInt($("#totalTags").val());
    rowCount--;
    $("#totalTags").val(rowCount);
    $(this).closest('#inputRowTags').remove();
});