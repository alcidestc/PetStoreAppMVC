function inicializarFormularioOrders(urlObtenerPets) {
    $("#StatusPet").change(async function () {
        const valorSeleccionado = $(this).val();

        const respuesta = await fetch(urlObtenerPets, {
            method: "POST",
            body: valorSeleccionado,
            headers: {
                "Content-Type": "application/json"
            }
        });

        const json = await respuesta.json();
        const opciones = json.map(order => `<option value=${order.value}>${order.text}</options>`);
        $("#PetId").html(opciones);
    })
}