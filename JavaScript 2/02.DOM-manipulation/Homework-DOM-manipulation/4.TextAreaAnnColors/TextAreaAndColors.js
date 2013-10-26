function onChangeColors() {
    var fontColor = document.getElementById("fontColor").value;
    var backgroundColor = document.getElementById("backgroundColor").value;
    var textArea = document.getElementsByTagName('textarea')[0];
    textArea.style.backgroundColor = backgroundColor;
    textArea.style.color = fontColor;
}