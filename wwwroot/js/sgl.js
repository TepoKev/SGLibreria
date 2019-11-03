var sgl = {
    get: function (url, callback, params) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                callback.call(this, this.responseText);
            }
        };
        url = url + (params == undefined ? "" : "?"+params);
        xhttp.open("GET", url, true);
//        console.log(url);
//        console.log(params);
        xhttp.send();
    },
    post: function (url, callback, params, token) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                callback.call(this, this.responseText);
            }
        };
        xhttp.open("POST", url , true);
        if(params == undefined) {
            xhttp.send();
        } else {
            var formData = new FormData(params);
            var nombreToken = "__RequestVerificationToken";
//            var token = params.elements.namedItem(nombreToken);
            xhttp.setRequestHeader(nombreToken, token);
            xhttp.send(formData);
        }
    },
    query: function (selector) {
        return document.querySelectorAll(selector);
    },
    q: function (selector) {
        return document.querySelector(selector);
    },
    qAll: function (selector) {
        return document.querySelectorAll(selector);
    },
    //nombre del token usado por net core
    inputToken:  'input[name=__RequestVerificationToken]',
    headerToken: 'RequestVerificationToken', 
    ajax: function (metodo, url, callback, params) {
        if (metodo.toUpperCase() == 'POST') {
            this.post(url, callback, params);
        } else if (metodo.toUpperCase() == 'GET') {
            this.get(url, callback, params);
        }
    },
    //tempplate es el elemento html que debe contener los elementos <option>
    //destino es el elemento select
    //lista de objetos a agregar
    //cada item de la lista debe tener las propiedades name y value ya que se usaran para acceder
    //elem[name], elem[value]
    llenarCombo: function (template, destino, lista, name, value) {
        elems = template.content.querySelectorAll("option");
        //elems[0] es <option>
        elems[0].textContent = "... Seleccione ...";
        elems[0].value = "";
        var clon = document.importNode(template.content, true);
        destino.appendChild(clon);
  
        lista.forEach(function (item) {
          //se accedera al primer elemento ya que solo hay un elemento <option>
          elems[0].textContent = item[name];
          elems[0].value = item[value];
          var clon = document.importNode(template.content, true);
          destino.appendChild(clon);
        });
      },
    ajax2: function (config) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if(this.readyState == 4) {
                switch (this.status) {
                    //okay
                    case 200:
                        config.done.call(this, this.responseText);
                        break;
                    //fallo
                    default:
                        if(config.fail) {
                            config.fail.call(this);
                        }
                        break;
                }
            }
        };
        xhttp.open(config.method.toUpperCase(), config.url , true);
        if(config.headers != undefined) {
            for(var header in config.headers) {
                if (config.headers.hasOwnProperty(header)) {
                    xhttp.setRequestHeader(header, config.headers[header]);
                }
            }
        }
        if(config.data == undefined) {
            xhttp.send();
        } else {
//            console.log(config.data.elements);
//            console.log(config.headers);
//            xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
//            xhttp.setRequestHeader('RequestVerificationToken', config.headers['RequestVerificationToken']);
            var formData, params;
            if(config.data.nodeName == 'FORM') {
                formData = new FormData(config.data);
                params = new URLSearchParams(formData);
                xhttp.send(params);
            } else if(config.data instanceof FormData) {
                params = new URLSearchParams(config.data);
                xhttp.send(params);
            } else {
                //if is a literal object
                formData = new FormData();
                for(var property in config.data) {
                    if (config.data.hasOwnProperty(property)) {
                        formData.append(property, config.data[property]);
                    }
                }
                params = new URLSearchParams(formData);
                xhttp.send(params);
            }
        }
    },
    setDataSet: function (elem, attr) {
        if(attr != undefined) {
            for(var clave in attr) {
                if (attr.hasOwnProperty(clave)) {
                    elem.setAttribute('data-'+clave, attr[clave]);
                }
            }
        }
    },
    getDataSet: function (elem) {
        var obj = {};
        var listAttr = elem.attributes;
        var attr;
        for(var i = 0; i < listAttr.length; i++) {
            attr = listAttr[i];
            if(attr.nodeName.startsWith("data-")) {
                obj[attr.nodeName.substring(5)] = attr.nodeValue;
            }
        }
        return obj;
    },
    clearForm: function (myFormElement) {
        var elements = myFormElement.elements;
        myFormElement.reset();
        for (i = 0; i < elements.length; i++) {
            field_type = elements[i].type.toLowerCase();
            switch (field_type) {
                case "text":
                case "file":
                case "password":
                case "textarea":
                case "hidden":
                    elements[i].value = "";
                    break;
                case "radio":
                case "checkbox":
                    if (elements[i].checked) {
                        elements[i].checked = false;
                    }
                    break;
                case "select-one":
                case "select-multi":
                    elements[i].selectedIndex = 0;
                    break;
                default:
                    break;
            }
        }
    }
};
/*
(function () {
    sgl.ajax('get', 'formulario.html', function (data) {
        var elem = document.getElementById('salida');
        elem.innerHTML = data;
    });
})();
*/
/*
(function (){
    var elem = document.createElement('a');
    datos = {
        'nombres': "Diego",
        'apellidos': 'Palacios'
    };
    console.log(datos);
    sgl.setDataSet(elem, datos);
    console.log(elem);
    console.log(sgl.getDataSet(elem));
})();
*/