import os
from flask import Flask
from flask import request
import json
import random
import nltk.data
import subprocess
# Boilerplate used from: https://flask.palletsprojects.com/en/2.0.x/quickstart/

# Define the Flask App
app = Flask(__name__)
nltk.download('punkt')
tokenizer = nltk.data.load('tokenizers/punkt/english.pickle')

# Define route, "/" specifies the landing page.
@app.route("/")
def hello_world():
    # Returns the entirety of the page; in this case, it is just the word "Test"
    return "<p>Test</p>"

# Define the app route, so if we had http://localhost:5000/ as the landing page,
# this opens up the route http://localhost:5000/submit_string
# This accepts GET requests with a JSON content-type. Replies with a String
# containing the content they sent. For testing/debugging purposes.
@app.route("/submit_string", methods = ['POST'])
def accept_string():
    possible_labels = ['positive', 'negative', 'neutral']
    random_index = random.randint(0, len(possible_labels) - 1)
    random_value = random.randint(0, 100)
    returned_data = { "label": possible_labels[random_index], "value": random_value }
    return returned_data

@app.route("/get_sentiment", methods = ['GET'])
def get_sentiment():
    print("Received request: " + str(request))
    model_path = "../model/model.py"
    passed_data = request.get_json()
    parsed_sentences = tokenizer.tokenize(passed_data)
    print("Tokenized sentences: " + str(parsed_sentences))
    all_sentiments = []
    print("Attempting to get sentiments from sentences...")
    for sentence in parsed_sentences:
        process = subprocess.Popen(['python3', model_path, str(sentence)], stdout=subprocess.PIPE, stderr=subprocess.PIPE)
        out, err = process.communicate()
        print("Type of out: " + str(type(out)))
        out = out.decode("utf-8")
        out = out.splitlines()[-1]
        print("Out: " + str(out))
        all_sentiments.append(str(out))
    print("Success, returning: " + str(all_sentiments))
    return json.dumps(all_sentiments)

if __name__ == '__main__':
    app.run()
