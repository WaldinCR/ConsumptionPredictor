document.addEventListener('DOMContentLoaded', function () {
    var optTextarea = document.getElementById('optTextarea');
    var optInputs = document.getElementById('optInputs');
    var secTextarea = document.getElementById('seccionTextarea');
    var secInputs = document.getElementById('seccionInputs');
    var txtArea = document.getElementById('datosTextarea');
    var datosHidden = document.getElementById('datosHidden');
    var form = document.getElementById('formPrediccion');
    var contador = document.getElementById('contadorLineas');

    if (!form) return;

    optTextarea.addEventListener('change', function () {
        secTextarea.style.display = 'block';
        secInputs.style.display = 'none';
        txtArea.name = 'DatosIngreso';
        datosHidden.name = '';
    });

    optInputs.addEventListener('change', function () {
        secTextarea.style.display = 'none';
        secInputs.style.display = 'block';
        txtArea.name = '';
        datosHidden.name = 'DatosIngreso';
    });

    txtArea.addEventListener('input', function () {
        var n = this.value.split('\n').filter(function (l) { return l.trim().length > 0; }).length;
        contador.textContent = n + '/12 registros ingresados';
        contador.className = n === 12 ? 'form-text text-success fw-semibold' : 'form-text text-muted';
    });

    form.addEventListener('submit', function (e) {
        if (optInputs.checked) {
            var fechas = document.querySelectorAll('.campo-fecha');
            var valores = document.querySelectorAll('.campo-valor');
            var lineas = [];
            var errores = [];

            for (var i = 0; i < 12; i++) {
                var f = fechas[i].value.trim();
                var v = valores[i].value.trim();
                if (!f) errores.push('Fila ' + (i + 1) + ': fecha requerida');
                if (!v || isNaN(parseFloat(v))) errores.push('Fila ' + (i + 1) + ': consumo invalido');
                else if (parseFloat(v) < 0) errores.push('Fila ' + (i + 1) + ': consumo no puede ser negativo');
                if (f && v) lineas.push(f + ', ' + v);
            }

            if (errores.length > 0) {
                e.preventDefault();
                alert(errores.join('\n'));
                return;
            }
            datosHidden.value = lineas.join('\n');

        } else {
            var lineasTxt = txtArea.value.split('\n').filter(function (l) { return l.trim().length > 0; });

            if (lineasTxt.length !== 12) {
                e.preventDefault();
                alert('Debe ingresar exactamente 12 registros. Tiene: ' + lineasTxt.length);
                return;
            }

            for (var j = 0; j < lineasTxt.length; j++) {
                var partes = lineasTxt[j].split(',');
                if (partes.length !== 2) {
                    e.preventDefault();
                    alert('Fila ' + (j + 1) + ': formato invalido. Use: YYYY-MM-DD, consumo');
                    return;
                }
                var val = parseFloat(partes[1].trim());
                if (isNaN(val)) {
                    e.preventDefault();
                    alert('Fila ' + (j + 1) + ': consumo no es un numero valido');
                    return;
                }
                if (val < 0) {
                    e.preventDefault();
                    alert('Fila ' + (j + 1) + ': consumo no puede ser negativo');
                    return;
                }
            }
        }
    });
});
