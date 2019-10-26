var sgl = {
    get: function (url, callback, params) {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                callback(this.responseText);
            }
        };
        xhttp.open("GET", url + params == undefined ? "" : "?"+params, true);
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
            var nombreToken = "_RequestVerificationToken";
//            var token = params.elements.namedItem(nombreToken);
            xhttp.setRequestHeader(nombreToken, token);
            xhttp.send(formData);
        }
    },
    ajax: function (metodo, url, callback, params) {
        if (metodo.toUpperCase() == 'POST') {
            this.post(url, callback, params);
        } else if (metodo.toUpperCase() == 'GET') {
            this.get(url, callback, params);
        }
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