console.log("hit js!");

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
        url: "https://home/api/sentiment",
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
        type: "get",
        data: text.value,
        dataType: "html",
        url: "https://home/api/sentiment",
        success: function(data) {
            console.log("successful get, data= " + data);
        },
        error: function(data) {
            console.log("error= " + data);
        },
    });
}

function clearFile() {
    var file = document.getElementById("file");
    file.value = null;
}