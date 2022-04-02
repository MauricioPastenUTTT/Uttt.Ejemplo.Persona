function isAlphabetKey(evt, field) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if ((charCode <= 93 && charCode >= 65) || (charCode <= 122 && charCode >= 97)) {

        return true;
    }
    alert("Only A-Z or a-z for " + field);
    return false;

}