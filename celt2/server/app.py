import os
import sys
from flask import Flask
from flask import request
import json
import random
import nltk.data
import subprocess

# Boilerplate used from: https://flask.palletsprojects.com/en/2.0.x/quickstart/
from server.model import classify
# Define the Flask App
app = Flask(__name__)
nltk.download('punkt', quiet=True)
tokenizer = nltk.data.load('tokenizers/punkt/english.pickle')

# Define route, "/" specifies the landing page.
@app.route("/")
def hello_world():
    # Returns the entirety of the page; in this case, it is just the word "Test"
    return "<p>Test</p>"

@app.route("/sentiment/text", methods = ['POST'])
def get_sentiment():
    print("Received request: " + str(request))
    model_path = "../model/model.py"
    passed_data = request.get_json()['sentimentText']
    print("Parsed data: " + str(passed_data))
    parsed_sentences = tokenizer.tokenize(passed_data)
    print("Tokenized sentences: " + str(parsed_sentences))
    all_sentiments = []
    print("Attempting to get sentiments from sentences...")
    for sentence in parsed_sentences:
        # process = subprocess.Popen(['python3', model_path, str(sentence)], stdout=subprocess.PIPE, stderr=subprocess.PIPE)
        # out, err = process.communicate()
        # out = out.decode("utf-8")
        out = classify(sentence)
        all_sentiments.append(str(out))
    print("Success, returning: " + str(all_sentiments))
    return json.dumps(all_sentiments)

if __name__ == '__main__':
    app.run()
