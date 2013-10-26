/*==========================================*/
/*               CREATE CUSTOM EVENT
/*==========================================*/

var custom = new CustomEvent("clickTreeTime");

// attach Custom Event to DOM
var body = document.getElementsByTagName("body")[0];

body.addEventListener("clickTreeTime",function(){

    alert("You triger custom event");
},false);


var getButton = document.getElementById("button");

var counter = 0;
getButton.addEventListener('click',function(){

    counter++;
    if(counter == 3){
        // Triger Custom Event when condition is present
        counter = 0;
        body.dispatchEvent(custom);
    }
},false);