import os
import sys
from flask import Flask
from flask import request
import json
import random
import nltk.data
import subprocess
# Allows for access to model. The Dockerfile accounts for this.
print(os.path.dirname(os.path.dirname(os.path.realpath(__file__))))
sys.path.append(os.path.dirname(os.path.dirname(os.path.realpath(__file__))) + 'model')
try:
    from model.model import classify
except ModuleNotFoundError:
    from model import classify
# Boilerplate used from: https://flask.palletsprojects.com/en/2.0.x/quickstart/
# Define the Flask App
nltk.download('punkt', quiet=True)
tokenizer = nltk.data.load('tokenizers/punkt/english.pickle')
def create_app():
    app = Flask(__name__)
    # Define route, "/" specifies the landing page.
    @app.route("/", methods=['GET'])
    def hello_world():
        # Returns the entirety of the page; in this case, it is just the word "Test"
        return "Hello world!"

    @app.route("/sentiment/text", methods = ['POST'])
    def get_sentiment():
        print("Received request: " + str(request))
        model_path = "../model/model.py"
        passed_data = request.get_json()['sentimentText']
        print("Parsed data: " + str(passed_data))
        # parsed_sentences = tokenizer.tokenize(passed_data)
        # print("Tokenized sentences: " + str(parsed_sentences))
        print("Attempting to get sentiments from sentences...")

        all_sentiments = []
        # Currently, multiple sentences aren't supported by the API.
        # The server can implement this with the following:
        # for sentence in parsed_sentences:
            # out = classify(sentence)
            # all_sentiments.append(str(out))

        # For now, we will be using a single sentence:
        sentence = passed_data
        out = classify(sentence)
        # Reassigning all_sentiments here just to avoid having to rename
        # later variables
        all_sentiments = out

        print("Success, returning: " + str(all_sentiments))
        return json.dumps({'label': str(all_sentiments)})
    return app
app = create_app()

if __name__ == '__main__':
    app.run()
