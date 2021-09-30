#
# @license
# Copyright Team Glare. All Rights Reserved.
#
# Use of this source code is governed by an MIT-style license that can be
# found in the LICENSE file at https://github.com/Team-Glare/CELT2/blob/main/LICENSE
#
import os
import sys
from flask import Flask
from flask import request
import json
import random
import nltk.data
import subprocess

# Allows for access to model. The Dockerfile accounts for this.
sys.path.append(os.path.dirname(os.path.dirname(os.path.realpath(__file__))) + 'model')
try:
    from model.model import classify
except ModuleNotFoundError:
    from model import classify
# Boilerplate used from: https://flask.palletsprojects.com/en/2.0.x/quickstart/
# Download the tokenizer. Wasn't used in Phase 1, but can be used in the future
# for tokenizing sentences and doing a sentence-by-sentence sentiment analysis
nltk.download('punkt', quiet=True)
# Defines the aforementioned tokenizer
tokenizer = nltk.data.load('tokenizers/punkt/english.pickle')

# Create_app returns a functioning Flask server with all of the route
# definitions already included.
# This is also necessary for pytest

def create_app():
    # Create app with the filename.
    app = Flask(__name__)
    # Define route, "/" specifies the landing page.
    @app.route("/", methods=['GET'])
    def hello_world():
        # Returns "Hello world!". If you were to call this in a browser,
        # you would see "Hello world!" appear likely in the top left
        return "Hello world!"

    # Route for calling the model.
    @app.route("/sentiment/text", methods = ['POST'])
    def get_sentiment():
        # Parse the json from the request received
        passed_data = request.get_json()['sentimentText']

        # All sentiments and the commented-out code was implemented
        # for multiple sentences. As Phase 1 was decided to only use
        # single-sentence parsing, this will remain here until
        # the other components of the architecture are capable of
        # handling it.
        all_sentiments = []
        # for sentence in parsed_sentences:
            # out = classify(sentence)
            # all_sentiments.append(str(out))

        # For now, we will be using a single sentence:
        sentence = passed_data
        # Pass the sentence to the model
        out = classify(sentence)
        # Reassigning all_sentiments here just to avoid having to rename
        # later variables
        all_sentiments = out
        return json.dumps({'label': str(all_sentiments)})

    return app
app = create_app()

if __name__ == '__main__':
    app.run()
