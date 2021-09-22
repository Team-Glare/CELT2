import edu.stanford.nlp.pipeline.CoreDocument;
import edu.stanford.nlp.pipeline.CoreSentence;
import edu.stanford.nlp.pipeline.StanfordCoreNLP;

import java.util.List;

/**
 * Created by user on 9/8/2021.
 */
public class SentimentAnalysis {
    public static void main(String[] args) {
        StanfordCoreNLP stanfordCoreNLP = Pipeline.getPipeline();
        CoreDocument coreDocument = new CoreDocument(args[0]);
        stanfordCoreNLP.annotate(coreDocument);
        List<CoreSentence> sentences = coreDocument.sentences();
        int i = 1;
        float emotionTotal = 0, emotionCount = 0;
        for(CoreSentence sentence: sentences){
            String sentiment = sentence.sentiment();
            System.out.println(i+" "+sentiment+ " : " + sentence);
            emotionCount++;
            if(sentiment.equalsIgnoreCase("negative")){
                emotionTotal+=-1;
            }
            else if(sentiment.equalsIgnoreCase("very negative")){
                emotionTotal+=-2;
            }
            else if(sentiment.equalsIgnoreCase("positive")){
                emotionTotal+=1;
            }
            else if(sentiment.equalsIgnoreCase("very positive")){
                emotionTotal+=2;
            }
            i++;
        }
        if(emotionCount==0){
            System.out.println("Neutral");
        }
        else{
            float t = emotionTotal/emotionCount;
            System.out.println(t);
            if(t<-0.5)
                System.out.println("Negative");
            else if(t>0.5)
                System.out.println("Positive");
            else
               System.out.println("Neutral");
        }
    }
}
