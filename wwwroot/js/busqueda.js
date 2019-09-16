var elementdiv = document.getElementsByClassName("search-box");
for(var i = 0 ; i < elementdiv.length ; i++ )
{
    elementdiv[i].addEventListener("mouseover", divhover);
    elementdiv[i].addEventListener("mouseout", divout);
}

function divhover(event){
    var target = event.currentTarget;
    var inputs = target.getElementsByClassName("search-txt");
    inputs[0].focus();
}

function divout(event){
    var target = event.currentTarget;
    var inputs = target.getElementsByClassName("search-txt");
    inputs[0].blur();
}