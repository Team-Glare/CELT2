import os
from flask import Flask
from flask import request
# Boilerplate used from: https://flask.palletsprojects.com/en/2.0.x/quickstart/

# Define the Flask App
app = Flask(__name__)

# Define route, "/" specifies the landing page.
@app.route("/")
def hello_world():
    # Returns the entirety of the page; in this case, it is just the word "Test"
    return "<p>Test</p>"

@app.route("/submit_string")
def accept_string():
    data = request.get_json()
    return "JSON: " + str(data) + " accepted

if __name__ == '__main__':
    app.run()
