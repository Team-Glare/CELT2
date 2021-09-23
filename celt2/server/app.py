import os
from flask import Flask
from flask import request
import json
import random
# Boilerplate used from: https://flask.palletsprojects.com/en/2.0.x/quickstart/

# Define the Flask App
app = Flask(__name__)

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
    returned_data = { possible_labels[random_index]: random_value }
    return returned_data

if __name__ == '__main__':
    app.run()
