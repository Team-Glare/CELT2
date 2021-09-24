# -*- coding: utf-8 -*-
"""
Created on Wed Sep  8 00:51:48 2021

@author: user
"""
import sys
import flair
from flair.models import TextClassifier
from flair.data import Sentence
classifier = TextClassifier.load('en-sentiment')
def classify(data):
    sentence = Sentence(data)
    classifier.predict(sentence)
    return sentence.labels[0]
# print sentence with predicted labels
#print(sentence.labels[0])
