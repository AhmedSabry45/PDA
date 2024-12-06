$(document).ready(function () {
    $("#searchDropdown").select2();
});

function validateInput(input) {
    var value = input.value.trim();
    var lengthValid = value.length === 12;
    var formatValid = /^(FT|TT)[A-Za-z0-9-. _]*$/.test(value);

    var errorLengthElement = document.getElementById("error-length");
    var errorFormatElement = document.getElementById("error-format");

    if (value === "") {
        errorLengthElement.style.display = "none";
        errorFormatElement.style.display = "none";
        return false;
    }

    errorLengthElement.style.display = lengthValid ? "none" : "block";
    errorFormatElement.style.display = formatValid ? "none" : "block";

    return lengthValid && formatValid;
}

function validateForm() {
    var input = document.getElementById("AcknowledgeNumber");
    return validateInput(input);
}
