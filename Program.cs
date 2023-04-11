using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Newtonsoft.Json.Linq;
using Google.Cloud.TextToSpeech.V1;
using System.Net.Http;
using System.Threading.Tasks;
using TextToSpeech;

namespace TextToSpeechApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Check that the correct number of arguments were provided
            if (args.Length != 4)
            {
                Console.WriteLine("Usage: TextToSpeechApp <api_name> <api_key> <input_file> <output_file>");
                Console.WriteLine("Available APIs: Azure, Google, AWS");
               var  val = Console.ReadLine();
                return;
            }

            // Parse the command-line arguments
            string apiName = args[0];
            string apiKey = args[1];
            string inputFile = args[2];
            string outputFile = args[3];

            // Load the input text from the file
            string inputText = File.ReadAllText(inputFile);

            // Choose the appropriate API based on the name provided
            switch (apiName.ToLower())
            {
                case "azure":
                    await AzureSpeech.TextToSpeechWithAzure(inputText, outputFile, apiKey);
                    break;

                case "AWS":
                    await SpeechWithAWS.TextToSpeechWithAWS(inputText, outputFile, apiKey);
                    break;

                case "Google":
                    await SpeechWithGoogle.TextToSpeechWithGoogle(inputText, outputFile, apiKey);
                    break;

                default:
                    Console.WriteLine("Invalid API name specified");
                    return;
            }

            Console.WriteLine("Text-to-speech conversion complete");
        }
    }


}
