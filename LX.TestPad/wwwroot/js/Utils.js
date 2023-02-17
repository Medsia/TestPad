function isWhiteSpaceString(str) {
    var reWhiteSpace = new RegExp("/^\s+$/");
    if (reWhiteSpace.test(str)) {
        return true;
    }
    return false;
}