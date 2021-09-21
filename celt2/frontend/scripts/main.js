var apiBaseUrl = 'http://localhost:64188/';

function analyzeFile() {
    var file = document.getElementById("file");

    if (file.files.length == 0) {
        window.alert("Choose file to analyze");
        return;
    }

    $.ajax({
        type: "get",
        data: file.files[0],
        dataType: "html",
        url: apiBaseUrl + "api/sentiment",
        success: function(data) {
            console.log("successful get, data= " + data);
        },
        error: function(data) {
            console.log("error= " + data);
        },
    });
}

function analyzeText() {
    var text = document.getElementById("text");

    if (text.value.length == 0) {
        window.alert("Enter text to analyze");
        return;
    }

    $.ajax({
        type: "POST",
        url: apiBaseUrl + "api/sentiment",
        data: JSON.stringify({ SentimentText: text.value }),
        dataType: "json",
        contentType: "application/json",
        cache: false,
        success: function(response) {
            $("#result").text(response);
        },
        error: function(err) {
            console.log("error= " + err);
        },
    });
}

function clearFile() {
    var file = document.getElementById("file");
    file.value = null;
}