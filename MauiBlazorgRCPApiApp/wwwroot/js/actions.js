function centerWindow(nameObj) {
    
    var elemento = document.getElementsByClassName(nameObj);
    var iddialog = elemento[0].getAttribute('id');
    var element = document.getElementById(iddialog);
    if (element) {       
        let windowWidth = window.innerWidth;
        let centerPosition = (windowWidth) / 2;
        element.style.width = `${centerPosition}px`;
    }
}



function Saludo(name) {
    console.log("Hello " + name);
    alert("Hello " + name);
}

