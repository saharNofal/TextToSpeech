using Google.Cloud.TextToSpeech.V1;

namespace TextToSpeechApp
{
    internal static class SpeechWithGoogle
    {

        internal static async Task TextToSpeechWithGoogle(string inputText, string outputFile, string apiKey)
        {
            // Create the TextToSpeechClient using the API key
            var clientBuilder = new TextToSpeechClientBuilder();
            clientBuilder.CredentialsPath = apiKey;
            var client = await clientBuilder.BuildAsync();

            // Set up the synthesis input
            var synthesisInput = new SynthesisInput
            {
                Text = inputText
            };

            // Set up the voice configuration
            var voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "fr-FR"
            };
            var audioConfig = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000
            };

            // Perform the synthesis
            var response = await client.SynthesizeSpeechAsync(synthesisInput, voiceSelection, audioConfig);

            // Write the audio to a file
            using (var output = File.Create(outputFile))
            {
                response.AudioContent.WriteTo(output);
            }
        }
    }
}