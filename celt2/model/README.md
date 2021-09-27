# Model  

For the sentiment analysis of texts, we have used flair to implement the model. The reason Flair is exciting news for NLP is because a recent paper Contextual String Embeddings for Sequence Labelling from Zalando Research covers an approach that consistently outperforms previous state-of-the-art solutions. It’s implemented and fully supported in Flair and can be used to build text classifiers. The model is built in python. The model output the sentiment of each sentence passed to the model as a command line argument. The output are in this format Sentiment: (Probability). This model classifies each sentence as either positive or negative. So this is a binary classification. To install Flair you will need Python 3.6. The requirements to run the model are:  
flair==0.9
torch==1.8.2+cpu 
torchvision==0.9.2+cpu 
torchaudio===0.8.2 
This is provided in the requiremtns.txt file.
