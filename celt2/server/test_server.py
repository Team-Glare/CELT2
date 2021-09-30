import os
from flask import Flask
from flask import request
import requests
import pytest
import json
import sys
from server.app import create_app

# Pytest fixtures are useful tools for calling resources
# over and over, without having to manually recreate them,
# eliminating the possibility of carry-over from previous tests,
# unless defined as such.
# This fixture receives the client returned from create_app
# in app.py
@pytest.fixture
def client():
    app = create_app()
    yield app.test_client()

# Test if the server is alive - go to the root address, see
# if it returns what we expect
def test_alive(client):
    rv = client.get('/')
    assert rv.data.decode("utf-8") == 'Hello world!'

# Test for a neutral statement; relatively straightforward,
# just pass "test" and see if it returns the expected value
def test_neutral(client):
    rv = client.post('/sentiment/text', json={
        'sentimentText': 'test'
    })
    assert json.loads(rv.data.decode("utf-8"))["label"] == "POSITIVE (0.8788)"

# Same as neutral, but for a happier sentiment
def test_positive(client):
    rv = client.post('/sentiment/text', json={
        'sentimentText': 'Happy thoughts, bunnies, rainbows, all that jazz'
    })
    json_data = json.loads(rv.data.decode("utf-8"))["label"]
    assert json_data == "POSITIVE (0.9999)"

# Same as neutral, but for a negative sentiment
def test_negative(client):
    rv = client.post('/sentiment/text', json={
        'sentimentText': 'Depressing, anxious, so many bad things'
    })
    json_data = json.loads(rv.data.decode("utf-8"))["label"]
    assert json_data == "NEGATIVE (0.9999)"
