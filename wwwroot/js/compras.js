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
                alert('click en producto');
            }
        }
    };
    this.iniciar();
    actualizar = function () {
        var
            sumaCantidad = 0,
            sumaPrecioCompra = 0,
            sumaPrecioVenta = 0;
        var rows = tbody.querySelectorAll('tr');
        var cols;
        var input;
        var data;
        for (let i = 0; i < rows.length; i++) {

            cols = rows[i].querySelectorAll('td');

            input = cols[1].querySelector('input');
            data = parseFloat(input.value);
            sumaCantidad += data;

            input = cols[2].querySelector('input');
            data = parseFloat(input.value);
            sumaPrecioCompra += data;

            labelUnitario = cols[2].querySelector('label');
            data = parseFloat(input.value);
            sumaPrecioCompra += data;

            input = cols[4].querySelector('input');
            data = parseFloat(input.value);
            sumaPrecioVenta += data;
        }

        if (!isNaN(sumaCantidad)) {
            colSumaCantidad.innerHTML = sumaCantidad;
        } else {
            colSumaCantidad.innerHTML = 'Datos incorrectos';
        }
        if (!isNaN(sumaPrecioCompra)) {
            colSumaPrecioCompra.innerHTML = sumaPrecioCompra;
        } else {
            colSumaPrecioCompra.innerHTML = 'Datos incorrectos';
        }
        if (!isNaN(sumaPrecioVenta)) {
            colSumaPrecioVenta.innerHTML = sumaPrecioVenta;
        } else {
            colSumaPrecioVenta.innerHTML = 'Datos incorrectos';
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
    var cantidad, precioUnitario, precioCompra;
    var data;
    var form = new FormData();
    var camposVacios = "No debe dejar campos vacios";
    var camposPositivos = "Solo debe ingresar valores positivos";
    var errores = [];
    for (let i = 0; i < rows.length; i++) {
        
        cols = rows[i].querySelectorAll('td');
        
        input = cols[0].querySelector('input[data-idproducto]');
        form.append('Detalles['+i+'].idproducto', input.value);
        data = parseInt(input.value);
        if(data <= 0 ) {
            errores.push(camposPositivos);
        }
        
        
        input = cols[1].querySelector('input[data-cantidad]');
        form.append('Detalles['+i+'].cantidad', input.value);
        data = parseInt(input.value);
        if(data <=0 ) {
            errores.push(camposPositivos);
        }
        sumaCantidad += data;
        cantidad = data;

        input = cols[2].querySelector('input[data-preciocompra]');
        form.append('Detalles['+i+'].precioCompra', input.value);
        data = parseFloat(input.value);
        if(data <=0 ) {
            errores.push(camposPositivos);
        }
        sumaPrecioCompra += data;
        precioCompra = data;

        precioUnitario = precioCompra / cantidad;
        labelUnitario = cols[3].querySelector('label');
        
        if(!isNaN(precioUnitario)) {
            labelUnitario.innerHTML = precioUnitario;
        } else {
            labelUnitario.innerHTML = '';
        }

        input = cols[4].querySelector('input[data-precioventa]');
        console.log(input);
        
        form.append('precioVenta', input.value);
        data = parseFloat(input.value);
        if(data <=0 ) {
            errores.push(camposPositivos);
        }
        sumaPrecioVenta += data;
    }

    var error = false;
    console.log(sumaCantidad, sumaPrecioCompra, sumaPrecioVenta);
    if ( !isNaN(sumaCantidad) && sumaCantidad > 0 ) {
        colSumaCantidad.innerHTML = sumaCantidad;
    } else {
        colSumaCantidad.innerHTML = '...';
        error = true;
    }
    if ( !isNaN(sumaPrecioCompra) && sumaPrecioCompra > 0) {
        colSumaPrecioCompra.innerHTML = sumaPrecioCompra;
    } else {
        colSumaPrecioCompra.innerHTML = '...';
        error = true;
    }
    if ( !isNaN(sumaPrecioVenta) && sumaPrecioVenta > 0  ) {
        colSumaPrecioVenta.innerHTML = sumaPrecioVenta;
    } else {
        colSumaPrecioVenta.innerHTML = '...';
        error = true;
    }

    var fecha, proveedor, documento;
    fecha = sgl.q('#cfecha');
    proveedor = sgl.q('#comboProveedores');

    form.append('Compra.fecha', fecha.value);
    form.append('Compra.idProveedor', proveedor.value);
    if(error || errores.length > 9) {
        console.log('error encontrado');
    } else {
        console.log('todo bien');
        var inputToken = sgl.q('#formToken '+sgl.inputToken);
        var headers = { [sgl.headerToken]: inputToken.value };

        sgl.ajax2({
            method: 'post',
            url: 'RegistroCompra',
            headers: headers,
            data: form,
            done: function procesarRespuesta(data) {

            }
        });
    }
};