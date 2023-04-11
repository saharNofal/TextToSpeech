namespace TextToSpeechApp
{
    internal static class SpeechWithApi2
    {

        internal static async Task TextToSpeechWithApi2(string inputText, string outputFile, string apiKey)
        {
            // Set up the HTTP client and request headers
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);
            client.DefaultRequestHeaders.Add("Accept", "audio/wav");

            // Set up the request content
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"text", inputText},
                {"lang", "fr-FR"}
            });

            // Send the request and receive the response
            var response = await client.PostAsync("https://api2.com/text-to-speech", content);

            // Write the audio to a file
            using (var output = File.Create(outputFile))
            {
                var audioContent = await response.Content.ReadAsByteArrayAsync();
                output.Write(audioContent, 0, audioContent.Length);
            }
        }
    }
}