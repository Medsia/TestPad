function hasWhiteSpace(str) {
    var reWhiteSpace = new RegExp("/^\s+$/");
    return reWhiteSpace.test(str);
}