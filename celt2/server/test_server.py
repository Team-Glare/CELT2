import os
from flask import Flask
from flask import request
import requests
import pytest
import json
import sys
from server.app import create_app

@pytest.fixture
def client():
    app = create_app()
    yield app.test_client()

def test_alive(client):
    rv = client.get('/')
    assert rv.data.decode("utf-8") == 'Hello world!'

def test_neutral(client):
    rv = client.post('/sentiment/text', json={
        'sentimentText': 'test'
    })
    assert json.loads(rv.data.decode("utf-8"))["label"] == "POSITIVE (0.8788)"

def test_positive(client):
    rv = client.post('/sentiment/text', json={
        'sentimentText': 'Happy thoughts, bunnies, rainbows, all that jazz'
    })
    json_data = json.loads(rv.data.decode("utf-8"))["label"]
    assert json_data == "POSITIVE (0.9999)"

def test_negative(client):
    rv = client.post('/sentiment/text', json={
        'sentimentText': 'Depressing, anxious, so many bad things'
    })
    json_data = json.loads(rv.data.decode("utf-8"))["label"]
    assert json_data == "NEGATIVE (0.9999)"