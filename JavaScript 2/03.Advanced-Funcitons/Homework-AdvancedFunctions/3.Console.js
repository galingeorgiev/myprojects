function testConsole() {
    var specialConsole = (function () {
        function writeLine() {
            var numberOfArgs = arguments.length;
            if (numberOfArgs === 0) {
                console.log("empty");
            }
            else if (numberOfArgs === 1) {
                console.log(arguments[0]);
            }
            else {
                console.log(stringFormat(arguments));
            }
        }

        function writeError() {
            var numberOfArgs = arguments.length;
            if (numberOfArgs === 0) {
                console.log("empty");
            }
            else if (numberOfArgs === 1) {
                console.log(arguments[0]);
            }
            else {
                console.log(stringFormat(arguments));
            }
        }

        function writeWarning() {
            var numberOfArgs = arguments.length;
            if (numberOfArgs === 0) {
                console.log("empty");
            }
            else if (numberOfArgs === 1) {
                console.log(arguments[0]);
            }
            else {
                console.log(stringFormat(arguments));
            }
        }

        function stringFormat(args) {
            var format = args[0];
            var formatedString = "";
            var valueInPlaceholder = 0;
            var i = 0;
            for (i = 0; i < format.length ; i++) {
                if (format[i] === '{' & format[i + 2] === '}') {
                    valueInPlaceholder = parseInt(format[i + 1]) + 1;
                    formatedString = formatedString + args[valueInPlaceholder];
                    i = i + 2;
                }
                else {
                    formatedString = formatedString + format[i];
                }
            }

            return formatedString;
        }

        return {
            writeLine: writeLine,
            writeError: writeError,
            writeWarning: writeWarning
        };
    })();

    specialConsole.writeLine("Message: hello");
    //logs to the console "Message: hello"
    specialConsole.writeLine("Message: {0}", "hello");
    //logs to the console "Message: hello"
    specialConsole.writeError("Error: {0}", "Something happened");
    specialConsole.writeWarning("Warning: {0}", "A warning");

}