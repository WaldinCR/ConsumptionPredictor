document.addEventListener('DOMContentLoaded', function () {
    // Resaltar la tarjeta del modo seleccionado
    const select = document.querySelector('select[name="ModoSeleccionado"]');
    const cards = document.querySelectorAll('.card.h-100');

    function resaltarTarjeta() {
        cards.forEach(c => c.classList.remove('shadow'));
        const idx = parseInt(select.value) - 1;
        if (cards[idx]) cards[idx].classList.add('shadow');
    }

    if (select) {
        select.addEventListener('change', resaltarTarjeta);
        resaltarTarjeta();
    }
});
