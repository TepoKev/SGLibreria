var sgl = {
    get: function (url, callback, params) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                callback.call(this, this.responseText);
            }
        };
        if(typeof params === 'object') {
            url = url + '?' + sgl.serialize(params);
        } else {
            url = url + (params == undefined ? "" : "?" + params);
        }
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
        xhttp.open("POST", url, true);
        if (params == undefined) {
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
    inputToken: 'input[name=__RequestVerificationToken]',
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
            if (this.readyState == 4) {
                switch (this.status) {
                    //okay
                    case 200:
                        config.done.call(this, this.responseText);
                        break;
                    //fallo
                    default:
                        if (config.fail) {
                            config.fail.call(this);
                        }
                        break;
                }
            }
        };
        xhttp.open(config.method.toUpperCase(), config.url, true);
        if (config.headers != undefined) {
            for (var header in config.headers) {
                if (config.headers.hasOwnProperty(header)) {
                    xhttp.setRequestHeader(header, config.headers[header]);
                }
            }
        }
        if (config.data == undefined) {
            xhttp.send();
        } else {
            //            console.log(config.data.elements);
            //            console.log(config.headers);
            //            xhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            //            xhttp.setRequestHeader('RequestVerificationToken', config.headers['RequestVerificationToken']);
            var formData, params;
            if (config.data.nodeName == 'FORM') {
                formData = new FormData(config.data);
                xhttp.send(formData);
            } else if (config.data instanceof FormData) {
                xhttp.send(config.data);
            } else {
                //if is a literal object
                formData = new FormData();
                for (var property in config.data) {
                    if (config.data.hasOwnProperty(property)) {
                        formData.append(property, config.data[property]);
                    }
                }
                xhttp.send(formData);
            }
        }
    },
    setDataSet: function (elem, attr) {
        if (attr != undefined) {
            for (var clave in attr) {
                if (attr.hasOwnProperty(clave)) {
                    elem.setAttribute('data-' + clave, attr[clave]);
                }
            }
        }
    },
    getDataSet: function (elem) {
        var obj = {};
        var listAttr = elem.attributes;
        var attr;
        for (var i = 0; i < listAttr.length; i++) {
            attr = listAttr[i];
            if (attr.nodeName.startsWith("data-")) {
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

sgl.init = (function () {
    //por comodidad, para poder usar forEach, con HTMLCollection y NodeList
    HTMLCollection.prototype.forEach = Array.prototype.forEach;
    NodeList.prototype.forEach = Array.prototype.forEach;
})();

/**
 * https://stackoverflow.com/questions/1714786/query-string-encoding-of-a-javascript-object
 */
sgl.serialize = function (obj, prefix) {
    var str = [],
        p;
    for (p in obj) {
        if (obj.hasOwnProperty(p)) {
            var k = prefix ? prefix + "[" + p + "]" : p,
                v = obj[p];
            str.push((v !== null && typeof v === "object") ?
                serialize(v, k) :
                encodeURIComponent(k) + "=" + encodeURIComponent(v));
        }
    }
    return str.join("&");
}

/*
        let formData = new FormData(FrmProductoNuevo);
        var xhr = new XMLHttpRequest();
        xhr.onreadystatechange = function(FrmProductoNuevo) {
            if (this.readyState === 4 && this.status === 200) {
                alert('Posted using XMLHttpRequest');
            }
        };
        xhr.open('POST', 'RegistroCompra?handler=UnaPrueba', true);
        
        xhr.setRequestHeader("RequestVerificationToken", token.value);
        xhr.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
        
        xhr.send(formData);
*/
/**
 * https://gomakethings.com/how-to-create-your-own-vanilla-js-dom-manipulation-library-like-jquery/
 */
var $s = (function () {

    'use strict';

	/**
	 * Create the constructor
	 * @param {String} selector The selector to use
	 */
    var Constructor = function (selector) {
        if (!selector) {
            this.length = 0;
            return;
        }
        if (selector === 'document') {
            this.elems = [document];
            this.length = 1;
        } else if (selector === 'window') {
            this.elems = [window];
            this.length = 1;
        } else {
            this.elems = document.querySelectorAll(selector);
            this.length = this.elems.length;
        }
    };

	/**
	 * Do ajax stuff
	 * @param  {String} url The URL to get
	 */
    Constructor.prototype.ajax = function (url) {
        // Do some XHR/Fetch thing here
        console.log(url);
    };

	/**
	 * Run a callback on each item
	 * @param  {Function} callback The callback function to run
	 */
    Constructor.prototype.each = function (callback) {
        if (!callback || typeof callback !== 'function') return;
        for (var i = 0; i < this.elems.length; i++) {
            callback(this.elems[i], i);
        }
        return this;
    };

	/**
	 * Add a class to elements
	 * @param {String} className The class name
	 */
    Constructor.prototype.addClass = function (className) {
        this.each(function (item) {
            item.classList.add(className);
        });
        return this;
    };

	/**
	 * Remove a class to elements
	 * @param {String} className The class name
	 */
    Constructor.prototype.removeClass = function (className) {
        this.each(function (item) {
            item.classList.remove(className);
        });
        return this;
    };

    Constructor.prototype.html = function (innerHTML) {
        if (arguments.length == 0) {
            return items[0].innerHTML;
        } else {
            this.each(function (item) {
                item.innerHTML = innerHTML;
            });
        }
    }

    Constructor.prototype.text = function (text) {
        if (arguments.length == 0) {
            return items[0].innerText || items[0].textContent;
        } else {
            this.each(function (item) {
                item.innerText = text;
            });
        }
    }

    Constructor.prototype.val = function (value) {
        if (arguments.length == 0) {
            return items[0].value;
        } else {
            this.each(function (value) {
                item.value = value;
            });
        }
    }

	/**
	 * Instantiate a new constructor
	 */
    var instantiate = function (selector) {
        return new Constructor(selector);
    };

	/**
	 * Return the constructor instantiation
	 */
    return instantiate;

})();
/**
 * container: elemento HTML, que contiene un div id='resultados-filtro'
 */
sgl.createPagination = function (container, filtro) {
    let div = container.querySelector(filtro);
    if (div === null) {
        return '';
    }
    let total = parseInt(div.getAttribute('data-total')),
        currentPage = parseInt(div.getAttribute('data-current-page')),
        max = parseInt(div.getAttribute('data-max'));
    let pages = total / max;
    var i = 0;
    let elems = '';
    let disabled;
    disabled = currentPage > 0 ? '' : 'disabled';
    let prevPage = currentPage - 1;
    prevPage = prevPage < 0 ? '' : prevPage;
    elems += `<li class="page-item ${disabled}"><a class="page-link" data-page="${prevPage}" href="#">&lt;&lt;</a></li>`;
    for (; i < pages; i++) {
        if (i == currentPage) {
            elems += `<li class="page-item active"><a class="page-link" data-page="${i}" href="#">${i + 1}</a></li>`;
        } else {
            elems += `<li class="page-item"><a class="page-link" data-page="${i}" href="#">${i + 1}</a></li>`;
        }
    }
    //console.log(currentPage, i);
    let nextPage = currentPage + 1;
    disabled = currentPage < i - 1 ? '' : 'disabled';
    nextPage = nextPage < i ? nextPage : '';
    elems += `<li class="page-item ${disabled}"><a class="page-link" data-page="${nextPage}" href="#">&gt;&gt;</a></li>`;
    //console.log("paginacion: ", elems);
    return elems;
}