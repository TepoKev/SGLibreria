var doc = document;
var elementdiv = doc.getElementsByClassName("search-box");
for(var i = 0 ; i < elementdiv.length ; i++ )
{
    elementdiv[i].addEventListener("mouseover", divhover);
    nHover = 0;
    elementdiv[i].addEventListener("mouseout", divout);
    nOut = 0;
}

function divhover(event){
    var target = null;
    if(event.currentTarget.className == "search-box"){
    target = event.currentTarget;
    }else{
    return;
    }
    console.log("TargetHov:");
    console.log(target);
    var inputs = target.getElementsByClassName("search-txt");
    if(inputs.length > 0) {
    inputs[0].focus();
    }
}

function divout(event){
    var target = null;
    if(event.currentTarget.className == "search-box"){
    target = event.currentTarget;
    }else{
    return;
    }
    console.log("TargetOut:");
    console.log(target);
    var inputs = target.getElementsByClassName("search-txt");
    if(inputs.length > 0) {
    inputs[0].blur();
    }
}