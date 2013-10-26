var validationControler = (function () {
    function isUsernameCorrect(username) {
        var isCorrect = true;

        if (username.length < 4 || username.length > 30) {
            isCorrect = false;
        }

        return isCorrect;
    }

    function isPasswordCorrect(password) {
        var isCorrect = true;

        if (password.length < 4 || password.length > 30) {
            isCorrect = false;
        }

        return isCorrect;
    }

    function isGuessNumberCorrect(guessNumber) {
        var isCorrect = true;
        var validNumbers = [true, true, true, true, true, true, true, true, true, true]
        if (guessNumber.length == 4) {
            for (var i = 0; i < 4; i++) {
                var currentDigit = parseInt(guessNumber[i]);
                if (!validNumbers[currentDigit] || currentDigit == 0) {
                    isCorrect = false;
                    break;
                }
                else {
                    validNumbers[currentDigit] = false;
                }
            }
        }
        else {
            isCorrect = false;
        }

        return isCorrect;
    }

    return {
        isUsernameCorrect: isUsernameCorrect,
        isPasswordCorrect: isPasswordCorrect,
        isGuessNumberCorrect: isGuessNumberCorrect
    }
}());