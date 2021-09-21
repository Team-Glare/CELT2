var apiBaseUrl = 'http://localhost:64188/';

function analyzeFile() {
    var file = document.getElementById("file");

    if (file.files.length == 0) {
        window.alert("Choose file to analyze");
        return;
    }

    var formData = new FormData();
    formData.append('file', file.files[0]);

    $.ajax({
        type: "POST",
        url: apiBaseUrl + "sentiment/text/file",
        data: formData,
        processData: false,
        contentType: false,
        success: function(data) {
            $("#result").text(response);
        },
        error: function(err) {
            console.log("error= " + err);
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
        url: apiBaseUrl + "sentiment/text",
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