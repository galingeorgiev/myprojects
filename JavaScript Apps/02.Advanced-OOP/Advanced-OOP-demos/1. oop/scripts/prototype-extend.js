(function() {
  if (!String.prototype.htmlEscape) {
    String.prototype.htmlEscape = function() {
      var escapedString = this.replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;");
        return escapedString;
    }
  }
}());

