var apiBaseUrl = 'https://celtapi.azurewebsites.net/';

function analyzeFile() {

    loadingResults();

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
        crossDomain: true,
        success: function(response) {
            $("#result").text(response);
            loadedResults();
        },
        error: function(err) {
            console.log("error= " + err);
            $("#result").text("Could not load results");
            loadedResults();
        },
    });
}

function analyzeText() {

    loadingResults();

    var text = document.getElementById("text");

    if (text.value.length == 0) {
        window.alert("Enter text to analyze");
        return;
    }

    $.ajax({
        type: "POST",
        url: apiBaseUrl + "sentiment/text",
        data: JSON.stringify({ SentimentText: text.value }),
        contentType: "application/json",
        crossDomain: true,
        cache: false,
        success: function(response) {
            $("#result").text(response);
            loadedResults();
        },
        error: function(err) {
            console.log("error= " + err);
            $("#result").text("Could not load results");
            loadedResults();
        },
    });
}

function loadingResults() {
    document.getElementById("result").text = "";
    document.getElementById("loader").style.display = "block";
}

function loadedResults() {
    document.getElementById("loader").style.display = "none";
    document.getElementById("results").style.display = "block";
}

function clearFile() {
    var file = document.getElementById("file");
    file.value = null;
}