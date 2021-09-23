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
sentence = Sentence(sys.argv[1])
classifier.predict(sentence)
# print sentence with predicted labels
print(sentence.labels[0])