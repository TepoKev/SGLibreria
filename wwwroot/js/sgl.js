var sgl = {
    get: function (url, callback, params) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                callback(this.responseText);
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
                callback(this.responseText);
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
    ajax: function (metodo, url, callback, params) {
        if (metodo.toUpperCase() == 'POST') {
            this.post(url, callback, params);
        } else if (metodo.toUpperCase() == 'GET') {
            this.get(url, callback, params);
        }
    },
    ajax2: function (config) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if(this.readyState == 4) {
                switch (this.status) {
                    //okay
                    case 200:
                        config.done(this.responseText);
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
        xhttp.open(config.method, config.url , true);
        
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
            var formData = new FormData(config.data);
            var params = new URLSearchParams(formData);
            xhttp.send(params);
//            xhttp.send(new FormData(config.data));
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
                    elements[i].selectedIndex = -1;
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