using AnimalChat.Web.Models;
using OpenAI;

namespace AnimalChat.Web.Services
{
    public class ChatService(OpenAiService openAiService, StateService stateService)
    {
        // Cache of chat sessions.
        private static List<Session> Sessions = [];  

        private readonly OpenAiService _openAiService = openAiService;
        private readonly StateService _stateService = stateService;


        public async Task<Session> CreateNewChatSession(string name)
        {
            // Create a new session object.
            var session = new Session(name);

            // Add session to cache
            Sessions.Add(session);

            // Persist session to the database.
            await _stateService.InsertSession(session);

            return session;
        }


        private async Task<Message> CreateChatMessage(string userId, string sessionId, string promptText) 
        {
            //Calculate tokens for the user prompt message.
            var promptTokens = GetTokens(promptText); 

            //Create a new message object.
            Message chatMessage = new(sessionId, userId, promptTokens, promptText);

            // Add message to the session.
            var session = Sessions.FirstOrDefault(s => s.Id == sessionId);
            session?.Messages.Add(chatMessage);

            // Persist message to the database.
            await _stateService.InsertMessage(userId, chatMessage);

            return chatMessage;
        }

        public async Task<(string completionText, int completionTokens)> GetChatCompletion(string sessionId, string userPrompt)
        {
            var conversation = GetConversation(sessionId);
            return await _openAiService.GetChatCompletionAsync(sessionId, conversation); 
        }


        private string GetConversation(string sessionId)
        {
            var messages = GetMessages(sessionId);

            return messages.Aggregate("", (current, t) => current + t.Text + Environment.NewLine);
        }

        private static int GetTokens(string promptText)
        {
            return 0; // ToDo
        }

        public void ClearCache()
        {
            Sessions = [];
        }

        public List<Message> GetMessages(string sessionId)
        {
            var messages = Sessions.FirstOrDefault(s => s.Id == sessionId)?.Messages ?? [];
            return messages;
        }
    }
}
