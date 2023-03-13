function isWhiteSpaceString(str) {

    var strReplaced = document.getElementById(searchInputId).value.replace(/^\s+$/, '');
    if (strReplaced == '') {
        return true;
    }

    return false;
}