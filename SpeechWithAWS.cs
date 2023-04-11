using System;
using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.Polly;
using Amazon.Polly.Model;


namespace TextToSpeech
{
    

    internal class SpeechWithAWS
    {
        internal static async Task TextToSpeechWithAWS(string inputText, string outputFile, string apiKey)
        {
            // Set up an Amazon Polly client with provided access key and secret key
            var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(apiKey, apiKey);
            var awsRegion = RegionEndpoint.USWest2; // Change to desired region
            var pollyClient = new AmazonPollyClient(awsCredentials, awsRegion);

            // Create SynthesizeSpeechRequest object with input text and desired output format and voice
            var synthesizeSpeechRequest = new SynthesizeSpeechRequest
            {
                Text = inputText,
                OutputFormat = OutputFormat.Mp3,
                VoiceId = VoiceId.Lea, // Change to desired voice
                LanguageCode = LanguageCode.FrFR // Change to desired language
            };

            // Send the request to Amazon Polly and receive the response
            using (var response = await pollyClient.SynthesizeSpeechAsync(synthesizeSpeechRequest))
            {
                // Save the audio stream from the response to the output file
                using (var audioStream = response.AudioStream)
                using (var fileStream = File.Create(outputFile))
                {
                    await audioStream.CopyToAsync(fileStream);
                }
            }

            Console.WriteLine($"Speech synthesis succeeded. Output written to {outputFile}.");
        }

      
    }

}
