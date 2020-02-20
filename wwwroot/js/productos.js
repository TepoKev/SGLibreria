
sgl.get('ListaProductoAjax?'+sgl.serialize({boton: true}), refrescar);
function refrescar(data) {
    divProductos = sgl.q('#productos');
    divProductos.innerHTML = data;
    var divPaginador = sgl.q('#paginacion');
    divPaginador.innerHTML = sgl.createPagination(divProductos, "#resultados-filtro");
    //console.log(data);
};

var eventoClickPaginacion = sgl.q('#paginacion');
eventoClickPaginacion.addEventListener('click', clicka) ;
console.log(eventoClickPaginacion);
function clicka(e){
    e.preventDefault();
    if(e.target.tagName == 'UL') {
        return;
    }
    let child= e.target.firstElementChild , target = e.target;
    page = target.getAttribute('data-page') === null? child.getAttribute('data-page') : target.getAttribute('data-page');
    console.log(page, page.trim());
    if(page !== null && page.trim() !== '') {
        buscarProducto();        
    }
    //console.log(page);
}
let page;
var NombreOCodigo = sgl.q('#NombreOCodigo');
NombreOCodigo.focus();
NombreOCodigo.oninput = function (e) {
    page = 0;
    buscarProducto();
};
var IdCategoria;
var IdMarca;
function buscarProducto() {
    var params = {
        boton : true, 
        nombreOCodigo : NombreOCodigo.value,
        idCategoria: IdCategoria, 
        pagina: page, 
        idMarca: IdMarca
    };
    console.log(params);
    sgl.get('ListaProductoAjax', function (data) {
        divProductos = sgl.q('#productos');
        divProductos.innerHTML = data;
        refrescar(data);
    }, params);
}


var divProductos = sgl.q('#productos');
//clic la imagen del card activa un elemento
divProductos.addEventListener('click', function marcarProducto(evento) {
    var currentTarget = evento.currentTarget;
    var target = evento.target;
    var card;
    var cardFooter;
    if (target.matches('img')) {
        card = target.parentNode;
        cardFooter = card.querySelector('.card-footer');
        if (card.getAttribute('data-seleccionado') == 'true') {
            cardFooter.className = 'card-footer text-primary m-0';
            card.setAttribute('data-seleccionado', false);
        } else {
            cardFooter.className = 'card-footer bg-primary text-white m-0';
            card.setAttribute('data-seleccionado', true);
        }
    }
});

//clic en un boton levanta un modal y lo llena
divProductos.addEventListener('click', function (evento) {
    var currentTarget = evento.currentTarget;
    var target = evento.target;
    var idproducto;

    var card;

    if (target.matches('button[type=button') || target.matches('i')) {
        if (target.nodeName == 'I') {
            card = target.parentNode.parentNode.parentNode.parentNode;
            idproducto = target.parentNode.getAttribute('data-idproducto');
        } else {
            card = target.parentNode.parentNode.parentNode;
            idproducto = target.getAttribute('data-idproducto');
        }
        cargarProducto(idproducto, card);
    }
});

//esta funcion recibe un id, y setea todos los datos JSON como data-ATRIBUTOS del card
function cargarProducto(idproducto, card) {
    var inputToken = sgl.q('#formToken ' + sgl.inputToken);
    //    console.log(sgl.headerToken, inputToken.value);
    var headers = { [sgl.headerToken]: inputToken.value };

    sgl.ajax2({
        method: 'post',
        url: 'ListaProducto?handler=Producto',
        headers: headers,
        data: { 'idproducto': idproducto },
        done: function (data) {
            var producto = JSON.parse(data);
            sgl.ajax2({
                method: 'post',
                url: 'ListaProducto?handler=CategoriasMarcas',
                headers: headers,
                done:function (categoriasMarcas) {
                    cargarCategoriasMarcas(categoriasMarcas, card, producto);
                },
                fail: function () { 
                    console.log(this); 
                }
            });
        },
        fail: function () { console.log(this) }
    });
}
// data es
function cargarCategoriasMarcas(data, card, producto) {
    var inputToken = sgl.q('#formToken ' + sgl.inputToken);
    //    console.log(sgl.headerToken, inputToken.value);
    var headers = { [sgl.headerToken]: inputToken.value };
    var obj = JSON.parse(data);
    sgl.setDataSet(card, producto);
    var datos = sgl.getDataSet(card);
    console.log(datos);
    //console.log(producto['idMarca'], producto['idCategoria'], producto);
    //console.log(obj);
    $('#modalProducto').modal('show');
    //llenarCategorias(obj.categorias);
    //llenarMarcas(obj.marcas);

    var comboCategorias = sgl.q('#comboCategorias'),
        comboMarcas = sgl.q('#comboMarcas');

    comboCategorias.innerHTML = '';
    comboMarcas.innerHTML = '';
    sgl.llenarCombo(
        sgl.q('#plantilla-option'),
        comboCategorias,
        obj.categorias,
        'nombre', 'id'
    );

    sgl.llenarCombo(
        sgl.q('#plantilla-option'),
        comboMarcas,
        obj.marcas,
        'nombre', 'id'
    );

    llenarFormProducto(producto);
}
function llenarFormProducto(producto) {

    sgl.q('#pdid').value = producto.id;
    sgl.q('#pdnombre').value = producto.nombre;
    sgl.q('#comboMarcas').value = producto.idMarca;
    sgl.q('#comboCategorias').value = producto.idCategoria;
    sgl.q('#pdcodigo').value = producto.codigo;
    sgl.q('#pddireccion').value = producto.descripcion;
    sgl.q('#pdstock').value = producto.stockMinimo;
    sgl.q('#pdfecha').value = producto.fechaVencimiento;

    var alerta = sgl.q('#alerta');
    alerta.style.display = 'none';
    alerta.innerHTML = '';
    var imagen = sgl.q('#imagen');
    var textoVistaPrevia = sgl.q('#textoVistaPrevia');
    var path = '';
    if (producto.idImagenNavigation && producto.idImagenNavigation.idRutaNavigation) {
        path = '/' + producto.idImagenNavigation.idRutaNavigation.nombre;
        path += '/' + producto.idImagenNavigation.nombre;
        textoVistaPrevia.style.display = 'none';
        imagen.style.display = 'block';
    } else {
        textoVistaPrevia.style.display = 'block';
        textoVistaPrevia.innerHTML = 'Vista previa';
        imagen.style.display = 'none';
    }
    imagen.src = path;

    console.log(producto);
    //
    // codigo para la imagen aquí
    //

}

var formModificar = sgl.q('#formModificarProducto');
var botonModificar = sgl.q('#btnAgregarProducto');
var pdimagenNuevo = sgl.q('#pdimagenNuevo');
pdimagenNuevo.onchange = function () {
    readURL(this);
    function readURL(input) {

        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                var imagen = sgl.q('#imagen');
                var textoVistaPrevia = sgl.q('#textoVistaPrevia');
                imagen.src = e.target.result;
                imagen.style.display = 'block';
                textoVistaPrevia.style.display = 'none';
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
};

//modificar producto
formModificar.onsubmit = function (evento) {
    //   console.log('evento submit llamado');
    evento.preventDefault();
    //   if(true) return false;
    var inputToken = sgl.q('#formToken ' + sgl.inputToken);
    var headers = { [sgl.headerToken]: inputToken.value };
    sgl.ajax2({
        url: "ListaProducto",
        method: "POST",
        data: new FormData(formModificar),
        done: function (data) {
            var obj = JSON.parse(data);
            var alerta = sgl.q('#alerta');
            $('#modalProducto').modal('hide');
            alerta.style.display = 'block';
            if (obj.error) {
                alerta.className = 'alert alert-danger';
                alerta.innerHTML = obj.error;
            } else if (obj.mensaje) {
                alerta.className = 'alert alert-primary';
                alerta.innerHTML = obj.mensaje;
            }
            sgl.get('ListaProductoAjax?Boton=true', refrescar);
            //cerrar la alerta automaticamente
            var timeoutID = window.setTimeout(function () {
                alerta.className = 'alert';
                alerta.style.display = 'none';
            }, 3000);

            console.log(data);
        },
        fail: function () {
            console.log('error: ');
            console.log(this);
        }
    });
}
var divCategorias = sgl.q('#categorias');
divCategorias.onclick = function (evento) {
    var target = evento.target;
    target = target.tagName === 'I' ? target.parentNode : target;
    var children = target.parentNode.children;
    console.log(children);
    children.forEach(element => {
        element.className = 'btn btn-sm btn-dark';
    });
    target.className = 'btn btn-sm btn-primary active';
    console.log(target);
    IdCategoria = target.getAttribute('data-idcategoria');
    console.log(IdCategoria);
    page = 0;
    buscarProducto();
}
var divMarcas = sgl.q('#marcas');
divMarcas.onclick = function (evento) {
    var target = evento.target;
    target = target.tagName === 'I' ? target.parentNode : target;
    var children = target.parentNode.children;
    console.log(children);
    children.forEach(element => {
        element.className = 'btn btn-sm btn-dark';
    });
    target.className = 'btn btn-sm btn-primary active';
    console.log(target);
    IdMarca = target.getAttribute('data-idmarca');
    console.log(IdMarca);
    page = 0;
    buscarProducto();
}