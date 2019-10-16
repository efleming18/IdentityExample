function check() {
    var answerValue = document.getElementById("realAnswer").value;
    var userInput = document.getElementById("ans").value;
    if (answerValue === userInput) {
        return true;
    }
    return false;
};