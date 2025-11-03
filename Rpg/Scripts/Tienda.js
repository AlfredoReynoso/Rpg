const h2Oro = document.getElementById("OroDisponible");
const oroDisponible = parseFloat(h2Oro.getAttribute("data-oro")) || 0;
let filaItems = document.querySelectorAll('.fila-items');

filaItems.forEach(items => {
    const costoitem = items.querySelector('.costo-item');
    const btnComprar = items.querySelector('.btn‐comprar');

    if (costoitem.value > oroDisponible) {
        btnComprar.disabled = true;
    }

});






















