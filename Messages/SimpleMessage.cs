using Telegram.Bot.Types;

namespace TelegramBotLibrary.Messages
{
    public class SimpleMessage : IMessage
    {
        public SimpleMessage(string clientMessage, string answer)
        {
            ClientMessage = clientMessage ?? throw new ArgumentNullException(nameof(clientMessage));
            Answer = answer ?? throw new ArgumentNullException(nameof(answer));
        }

        public SimpleMessage(string clientMessage, string answer, IList<IMessage> messages) : this(clientMessage, answer)
        {
            Messages = messages;
        }

        public Update Update { get; }
        public string ClientMessage { get; set; }
        public string Answer { get; set; }
        public IList<IMessage> Messages { get; set; }

        public string GetMessage(Update update)
        {
            Action(update);
            return Answer;
        }

        public void Action(Update update)
        {

        }
    }
}
