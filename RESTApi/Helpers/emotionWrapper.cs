using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Console;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Emotion;

namespace RESTApi.Helpers
{
    public class EmotionWrapper
    {
        public async Task<List<string>> UploadAndDetectEmotions(string url)
        {
            string subscriptionKey = "7232af37ec0a4d229f7632462cb927a2";


            Console.WriteLine("EmotionServiceClient is created");

            EmotionServiceClient emotionServiceClient = new EmotionServiceClient(subscriptionKey);

            Console.WriteLine("Calling EmotionServiceClient.RecognizeAsync()...");
            try
            {
                Emotion[] emotionResult = await emotionServiceClient.RecognizeAsync(url);
                var moodPerFace = ListEmotionResult(emotionResult);
                return moodPerFace;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Dection failed. Please make sure that you have the right subscription key and proper URL to detect.");
                Console.WriteLine(exception.ToString());
                return null;
            }
        }

        public List<string> ListEmotionResult(Emotion[] emotionResult)
        {
            List<String> TopEmotionPerFace = new List<string>();
            if (emotionResult != null)
            {
                EmotionResultDisplay[] resultDisplay = new EmotionResultDisplay[8];
                for (int i = 0; i < emotionResult.Length; i++)
                {
                    Emotion emotion = emotionResult[i];
                    resultDisplay[0] = new EmotionResultDisplay { EmotionString = "Anger", Score = emotion.Scores.Anger };
                    resultDisplay[1] = new EmotionResultDisplay { EmotionString = "Contempt", Score = emotion.Scores.Contempt };
                    resultDisplay[2] = new EmotionResultDisplay { EmotionString = "Disgust", Score = emotion.Scores.Disgust };
                    resultDisplay[3] = new EmotionResultDisplay { EmotionString = "Fear", Score = emotion.Scores.Fear };
                    resultDisplay[4] = new EmotionResultDisplay { EmotionString = "Happiness", Score = emotion.Scores.Happiness };
                    resultDisplay[5] = new EmotionResultDisplay { EmotionString = "Neutral", Score = emotion.Scores.Neutral };
                    resultDisplay[6] = new EmotionResultDisplay { EmotionString = "Sadness", Score = emotion.Scores.Sadness };
                    resultDisplay[7] = new EmotionResultDisplay { EmotionString = "Surprise", Score = emotion.Scores.Surprise };

                    Array.Sort(resultDisplay, CompareDisplayResults);

                    String[] emotionStrings = new String[3];
                    for (int j = 0; j < 3; j++)
                    {
                        emotionStrings[j] = resultDisplay[j].EmotionString + ":" + resultDisplay[j].Score.ToString("0.000000"); ;
                    }
                    TopEmotionPerFace.Add(resultDisplay[0].EmotionString);
                }
                return TopEmotionPerFace;
            }

            return null;
        }

        private int CompareDisplayResults(EmotionResultDisplay result1, EmotionResultDisplay result2)
        {
            return ((result1.Score == result2.Score) ? 0 : ((result1.Score < result2.Score) ? 1 : -1));
        }

    }

    
}
