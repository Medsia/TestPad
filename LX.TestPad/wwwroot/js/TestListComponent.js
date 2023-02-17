﻿let api = '../../api/';
let _inCallback = false;

let loadingImgId = "";
let testListId = "";
let searchInputId = "";

let isAdmin = false;

function testListInit(loadingImageDivId, testListDivId, searchInputElementId, isOnAdminPage) {
    loadingImgId = loadingImageDivId;
    testListId = testListDivId;
    searchInputId = searchInputElementId;
    isAdmin = isOnAdminPage;

    $("div#" + loadingImgId).hide();

    _inCallback = false;

    loadAllTests();
}


function loadAllTests() {
    if (!_inCallback) {
        _inCallback = true;

        document.getElementById(testListId).innerHTML = "";

        $('div#' + loadingImgId).show();

        $.ajax({
            type: 'GET',
            url: api + 'tests',
            success: function (data, textstatus) {
                if (data.length > 0) {
                    $.each(data, function (index, item) {
                        spawnTests(item);
                    } )
                }

                _inCallback = false;
                $("div#" + loadingImgId).hide();
            }
        });
    }
}


function loadAllTestsByRequest() {
    if (!_inCallback) {

        var searchRequest = document.getElementById(searchInputId).value.replace(/\s+/, " ");
        if (isWhiteSpaceString(searchRequest)) { return; }

        document.getElementById(testListId).innerHTML = "";
        $('div#' + loadingImgId).show();
        _inCallback = true;

        var encodedURL = encodeURIComponent(searchRequest);

        $.ajax({
            type: 'GET',
            url: api + 'tests/filter?request=' + encodedURL,
            success: function (data, textstatus) {
                if (data.length > 0) {
                    $.each(data, function (index, item) {
                        spawnTests(item);
                    } )
                }
                else {
                    _inCallback = false;
                    loadAllTests();
                }

                _inCallback = false;
                $("div#" + loadingImgId).hide();
            },
            error: function (e) {
                loadAllTests();
            },
        });
    }
}


function spawnTests(item) {
    let htmlLine = '';

    if (isAdmin) {
        htmlLine = '<div class="test" style="border: 0">' +
            '<ul class="list-group" style="height: 285px;  max-width: 250px; ">' +
            '<li class="list-group-item" style="height: 40px">' +
            '<p class="test-title">' + item.name + '</p>' +
            '</li>' +
            '<li class="list-group-item" style="text-overflow: ellipsis; max-width: 250px; min-height: 135px">' +
            '<p class="product-desc" style="word-wrap: break-word; width: 200px; max-height: 100%; text-overflow: ellipsis; overflow: hidden;">' + item.description + '</p>' +
            '</li>' +
            '<li class="list-group-item">' +
            '<form action="Admin/TestDetails/' + item.id + '">' +
            '<button type="submit" class="btn btn-success">Show</button>' +
            '</form>' +
            '</li>' +
            '<li class="list-group-item">' +
            '<form action="/Admin/CopyTest" method="post">' +
            '<input type="hidden" name="selectedTestId" value="' + item.id + '" />' + 
            '<button type="submit" class="btn btn-success">Copy and Edit as new</button>' +
            '</form>' +
            '</li>' +
            '</ul>' +
            '</div>'
    }
    else {
        htmlLine = '<div class="test" style="border: 0">' +
            '<ul class="list-group" style="height: 230px;  max-width: 250px; ">' +
            '<li class="list-group-item" style="height: 40px">' +
            '<p class="test-title">' + item.name + '</p>' +
            '</li>' +
            '<li class="list-group-item" style="text-overflow: ellipsis; max-width: 250px; height: 135px">' +
            '<p class="product-desc" style="word-wrap: break-word; width: 200px; max-height: 100%; text-overflow: ellipsis; overflow: hidden;">' + item.description + '</p>' +
            '</li>' +
            '<li class="list-group-item">' +
            '<form>' +
            '<button formaction="Test/' + item.id + '" type="submit" class="btn btn-success">Start</button>' +
            '</form>' +
            '</li>' +
            '</ul>' +
            '</div>'
    }
    
    $("#" + testListId).append(htmlLine);
}