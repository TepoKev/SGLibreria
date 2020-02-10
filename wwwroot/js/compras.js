//tempplate es el elemento plantilla html
//dest es el elemento table
//lista de objetos a agregar
//data es el producto
var clonarNuevoDetalle = function (template, dest, data) {
    //traer todos los td
    elems = template.content.querySelectorAll("td");
    //encontrar el primer enlace
    var enlace = elems[0].querySelector('a');
    var inputId = elems[0].querySelector('input');
    enlace.setAttribute('data-idproducto', data.id);
    enlace.setAttribute('data-idproducto', data.id);
    inputId.value = data.id;
    enlace.textContent = data.nombre;
    var clon = document.importNode(template.content, true);
    dest.appendChild(clon);
}
//esta funcion solo requiere la data que se mostrara en la plantilla clonada
var agregarDetalle = function (data) {
    var plantilla = sgl.q('#fila-detalle');
    var destino = sgl.q('#tablaCompraFilas');
    clonarNuevoDetalle(plantilla, destino, data);
}

var formCompra = sgl.q('#registroCompra');


function Compras() {
    var table = this.table = sgl.q('#tablaCompra');
    var tbody = this.tbody = sgl.q('#tablaCompraFilas');
    var colSumaCantidad = this.colSumaCantidad = sgl.q('#sumaCantidad');
    var colSumaPrecioCompra = this.colSumaPrecioCompra = sgl.q('#sumaPrecioCompra');
    var colSumaPrecioVenta = this.colSumaPrecioVenta = sgl.q('#sumaPrecioVenta');

    this.iniciar = function () {
        table.oninput = cambioDetalle;
        table.onblur = cambioDetalle;
        function cambioDetalle(ev) {
            var target = ev.target,
                parent = ev.target.parentNode;
            if (target.matches('input')) {
                actualizar();
            }
        }
        table.onclick = function clickEnBoton(ev) {
            ev.preventDefault();
            var target = ev.target,
                parent = ev.target.parentNode,
                fila;
            if (parent.matches('a[data-tipobtn=eliminar]')) {
                target = parent;
            }
            if (target.matches('a[data-tipobtn=eliminar]')) {
                //padres: div td tr
                fila = target.parentNode.parentNode.parentNode;
                console.log(fila);
                tbody.removeChild(fila);

            } else if (target.matches('a[data-tipobtn=producto]')) {
                console.log('click en producto');
            }
        }
    };
    this.iniciar();
    actualizar = function () {
        var
            sumaCantidad = 0,
            sumaPrecioCompra = 0,
            sumaPrecioVenta = 0;
        var tbody = sgl.q('#tablaCompraFilas');
        var rows = tbody.querySelectorAll('tr');
        var cols;
        var input;
        var cantidad, precioUnitario, precioCompra, precioVenta;
        var data;
        var form = new FormData();
        var camposVacios = "No debe dejar campos vacios";
        var camposPositivos = "Solo debe ingresar valores positivos";
        var errores = [];
        for (let i = 0; i < rows.length; i++) {

            cols = rows[i].querySelectorAll('td');

            input = cols[0].querySelector('input[data-idproducto]');
            data = parseInt(input.value);
            form.append('Detalles[' + i + '].idproducto', data);
            if (data <= 0) {
                errores.push(camposPositivos);
            }

            input = cols[1].querySelector('input[data-cantidad]');
            data = parseInt(input.value);
            form.append('Detalles[' + i + '].cantidad', input.value);
            if (data <= 0) {
                errores.push(camposPositivos);
            }
            sumaCantidad += data;
            cantidad = data;

            input = cols[2].querySelector('input[data-preciocompra]');
            data = parseFloat(input.value);
            form.append('Detalles[' + i + '].precioCompra', input.value);
            if (data <= 0) {
                errores.push(camposPositivos);
            }
            sumaPrecioCompra += data;
            precioCompra = data;

            precioUnitario = precioCompra / cantidad;
            labelUnitario = cols[3].querySelector('label');

            if (!isNaN(precioUnitario)) {
                labelUnitario.innerHTML = precioUnitario.toFixed(2);
            } else {
                labelUnitario.innerHTML = '';
            }

            input = cols[4].querySelector('input[data-precioventa]');
            data = parseFloat(input.value);
            precioVenta = data;
            form.append('precioVenta', input.value);
            if (precioUnitario > precioVenta) {
                errores.push('El precio de venta debe ser mayor al precio de compra');
            }
            if (data <= 0) {
                errores.push(camposPositivos);
            }
            sumaPrecioVenta += data*cantidad;
        }

        var error = false;

        console.log(sumaCantidad, sumaPrecioCompra, sumaPrecioVenta);
        if (!isNaN(sumaCantidad) && sumaCantidad > 0) {
            colSumaCantidad.innerHTML = sumaCantidad;
        } else {
            colSumaCantidad.innerHTML = '...';
            error = true;
        }
        if (!isNaN(sumaPrecioCompra) && sumaPrecioCompra > 0) {
            colSumaPrecioCompra.innerHTML = sumaPrecioCompra;
        } else {
            colSumaPrecioCompra.innerHTML = '...';
            error = true;
        }
        if (!isNaN(sumaPrecioVenta) && sumaPrecioVenta > 0) {
            colSumaPrecioVenta.innerHTML = sumaPrecioVenta;
        } else {
            colSumaPrecioVenta.innerHTML = '...';
            error = true;
        }
    };

};
var compras = new Compras();
compras.iniciar();
console.log(compras);

formCompra.onsubmit = function enviarFormCompra(ev) {
    ev.preventDefault();

    var colSumaCantidad = sgl.q('#sumaCantidad')
    var colSumaPrecioCompra = sgl.q('#sumaPrecioCompra');
    var colSumaPrecioVenta = sgl.q('#sumaPrecioVenta');
    var
        sumaCantidad = 0,
        sumaPrecioCompra = 0,
        sumaPrecioVenta = 0;
    var tbody = sgl.q('#tablaCompraFilas');
    var rows = tbody.querySelectorAll('tr');
    var cols;
    var input;
    var cantidad, precioUnitario, precioCompra, precioVenta;
    var data;
    var form = new FormData();
    var camposVacios = "No debe dejar campos vacios";
    var camposPositivos = "Solo debe ingresar valores positivos";
    var errores = [];
    for (let i = 0; i < rows.length; i++) {

        cols = rows[i].querySelectorAll('td');

        input = cols[0].querySelector('input[data-idproducto]');
        data = parseInt(input.value);
        form.append('Detalles[' + i + '].idproducto', data);
        if (data <= 0) {
            errores.push(camposPositivos);
        }

        input = cols[1].querySelector('input[data-cantidad]');
        data = parseInt(input.value);
        form.append('Detalles[' + i + '].cantidad', input.value);
        if (data <= 0) {
            errores.push(camposPositivos);
        }
        sumaCantidad += data;
        cantidad = data;

        input = cols[2].querySelector('input[data-preciocompra]');
        data = parseFloat(input.value);
        form.append('Detalles[' + i + '].precioCompra', input.value);
        if (data <= 0) {
            errores.push(camposPositivos);
        }
        sumaPrecioCompra += data;
        precioCompra = data;

        precioUnitario = precioCompra / cantidad;
        labelUnitario = cols[3].querySelector('label');

        if (!isNaN(precioUnitario)) {
            labelUnitario.innerHTML = precioUnitario;
        } else {
            labelUnitario.innerHTML = '';
        }

        input = cols[4].querySelector('input[data-precioventa]');
        data = parseFloat(input.value);
        precioVenta = data;
        form.append('precioVenta', input.value);
        if (precioUnitario > precioVenta) {
            errores.push('El precio de venta debe ser mayor al precio de compra');
        }
        if (data <= 0) {
            errores.push(camposPositivos);
        }
        sumaPrecioVenta += data*cantidad;
    }//fin de la validacion de cada detalle

    var error = false;

    console.log(sumaCantidad, sumaPrecioCompra, sumaPrecioVenta);
    if (!isNaN(sumaCantidad) && sumaCantidad > 0) {
        colSumaCantidad.innerHTML = sumaCantidad;
    } else {
        colSumaCantidad.innerHTML = '...';
        error = true;
    }
    if (!isNaN(sumaPrecioCompra) && sumaPrecioCompra > 0) {
        colSumaPrecioCompra.innerHTML = sumaPrecioCompra;
    } else {
        colSumaPrecioCompra.innerHTML = '...';
        error = true;
    }
    if (!isNaN(sumaPrecioVenta) && sumaPrecioVenta > 0) {
        colSumaPrecioVenta.innerHTML = sumaPrecioVenta;
    } else {
        colSumaPrecioVenta.innerHTML = '...';
        error = true;
    }

    var fecha, proveedor, comprobante;
    fecha = sgl.q('#cfecha');
    proveedor = sgl.q('#comboProveedores');
    comprobante = sgl.q('#docComprobante');
    if(fecha.value == '' || proveedor.value == '' || comprobante.files.length == 0) {
       return false; 
    }
    form.append('Compra.fecha', fecha.value);
    form.append('Compra.idProveedor', proveedor.value);
    form.append('Comprobante', comprobante.files[0]);

    if (error == true || errores.length > 0) {
        console.log('error encontrado');
    } else {
        console.log('todo bien');
        var inputToken = sgl.q('#formToken ' + sgl.inputToken);
        var headers = { [sgl.headerToken]: inputToken.value };

        sgl.ajax2({
            method: 'post',
            url: 'RegistroCompra',
            headers: headers,
            data: form,
            done: function procesarRespuesta(texto) {
				//redireccion via JS
                location.href = '/Compras/ListaCompra';
            }, 
			fail: function () {
				//aqui codigo si falla
			}
        });
    }
};