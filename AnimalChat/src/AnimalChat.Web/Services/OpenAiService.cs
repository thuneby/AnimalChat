using OpenAI;
using OpenAI.Chat;

namespace AnimalChat.Web.Services
{
    public class OpenAiService(OpenAIClient client, string modelName)
    {
        /// <summary>
        /// System prompt to send with user prompts to instruct the model for chat session
        /// </summary>
        private readonly string _systemPrompt = @"
        You are an AI assistant that chats with children about their favourite animal.
        Provide answers as if you were chatting with a 10 year old child." + Environment.NewLine;


        public async Task<(string completionText, int completionTokens)> GetChatCompletionAsync(string sessionId, string userPrompt)
        {
            SystemChatMessage systemMessage = new(_systemPrompt);
            UserChatMessage userMessage = new(userPrompt);
            var messages = new List<ChatMessage> { systemMessage, userMessage };

            var chatClient = client.GetChatClient(modelName);
            var completion = await chatClient.CompleteChatAsync(messages);
            var response = completion.Value;
            var responseMessage = response.Content.ToString()?? "Error - No response";
            ;
            var tokens = response.Usage.TotalTokenCount;
            return (completionText: responseMessage,
                   completionTokens:tokens);
        }

    }
}
