/**
 * Handles all frontend functionality for the Sentiment Analyzer.
 *
 * Retrieves and validates input and sends it to be parsed by the server and
 * analyzed by the sentiment analyzer.
 * Displays results that are returned after analysis. Displays an error message
 * if analysis returns a result.
 *
 * @file   This files handles all frontend functionality for the Sentiment Analyzer
 * @author Matthew Sohacki
 * @since  1.0.1
 */

/* URL to send API requests to */
var apiBaseUrl = "https://celtapi.azurewebsites.net/";

/**
 * Takes the file from the id='file' input and sends it
 * to the file API to be be parsed by the server and analyzed
 * by the sentiment analyzer.
 * 
 * If there is no file in the input, a popup is displayed telling the user
 * to upload a file, and nothing is sent to be analyzed.
 * 
 * Displays the loading graphic while waiting for results to be returned.
 * The results of analysis or an error message is displayed, depending on what
 * the API returns.
 *
 */
function analyzeFile() {

    var file = document.getElementById("file");
    if (!validateInput("file", file)) return;

    loadingResults();

    var formData = new FormData();
    formData.append("file", file.files[0]);

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

/**
 * Takes the text from the id='text' input and sends it
 * to the text API to be be parsed by the server and analyzed
 * by the sentiment analyzer.
 * 
 * If there is no text in the input, a popup is displayed telling the user
 * to paste text in the input, and nothing is sent to be analyzed.
 * 
 * Displays the loading graphic while waiting for results to be returned.
 * The results of analysis or an error message is displayed, depending on what
 * the API returns.
 *
 */
function analyzeText() {

    var text = document.getElementById("text");
    if (!validateInput("text", text)) return;

    loadingResults();

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


/**
 * Checks that the given input contains a value and is not empty.
 * If the input is empty a popup is displayed telling the user to enter input.
 * 
 * @param  {String}  inputType the input type being analyzed (i.e. file, text)
 * @param            input the input to validate
 *  @return {Boolean} true if the input is not empty, false if it is
 */
function validateInput(inputType, input) {
    if (input.value.length == 0) {
        window.alert("Enter " + inputType + " to analyze");
        return false;
    }
    return true;
}

/**
 * Results enter a "loading" state. The results output is cleared,
 * the results output is hidden, and the loading graphic is displayed.
 * 
 */
function loadingResults() {
    document.getElementById("result").text = "";
    document.getElementById("results").style.display = "none";
    document.getElementById("loader").style.display = "block";
}

/**
 * Results are removed from a "loading" state. The results output is shown
 * and the loading graphic is hidden.
 * 
 */
function loadedResults() {
    document.getElementById("loader").style.display = "none";
    document.getElementById("results").style.display = "block";
}

/**
 * The file input id='file' is cleared.
 */
function clearFile() {
    var file = document.getElementById("file");
    file.value = null;
}