using Microsoft.CognitiveServices.Speech;

namespace TextToSpeechApp
{
    internal static class AzureSpeech
    {
 
        internal static async Task TextToSpeechWithAzure(string inputText, string outputFile, string apiKey)
        {
            // Configure the Azure Speech Service client
            var config = SpeechConfig.FromSubscription(apiKey, "westus2");
            config.SpeechSynthesisLanguage = "fr-FR";

            // Open a file for the output audio
            using (var audioOutput = Microsoft.CognitiveServices.Speech.Audio.AudioConfig.FromWavFileOutput(outputFile))
            {
                // Create a synthesizer object and convert the text to speech
                using (var synthesizer = new SpeechSynthesizer(config, audioOutput))
                {
                    var result = await synthesizer.SpeakTextAsync(inputText);
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        Console.WriteLine($"Speech synthesis succeeded. Output written to {outputFile}.");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"Speech synthesis was cancelled: {cancellation.Reason}. Error details: {cancellation.ErrorDetails}");
                    }
                }
            }
        }

        internal static async Task TextToSpeechWithAzure(string inputText, string outputFile, string apiKey, string region, string language )
        {
            // Configure the Azure Speech Service client
            var config = SpeechConfig.FromSubscription(apiKey, region);
            config.SpeechSynthesisLanguage = language;

            // Open a file for the output audio
            using (var audioOutput = Microsoft.CognitiveServices.Speech.Audio.AudioConfig.FromWavFileOutput(outputFile))
            {
                // Create a synthesizer object and convert the text to speech
                using (var synthesizer = new SpeechSynthesizer(config, audioOutput))
                {
                    var result = await synthesizer.SpeakTextAsync(inputText);
                    if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                    {
                        Console.WriteLine($"Speech synthesis succeeded. Output written to {outputFile}.");
                    }
                    else if (result.Reason == ResultReason.Canceled)
                    {
                        var cancellation = SpeechSynthesisCancellationDetails.FromResult(result);
                        Console.WriteLine($"Speech synthesis was cancelled: {cancellation.Reason}. Error details: {cancellation.ErrorDetails}");
                    }
                }
            }
        }
    }
}


