using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotLibrary.AnswerMessages.Interface;
using TelegramBotLibrary.Answers.Interface;

namespace TelegramBotLibrary.Answers
{
    public class TextToTextAnswer : IAnswer
    {
        private IAnswerMessage answerMessage;
        private string clientTextMessage;

        public TextToTextAnswer(IAnswerMessage answerMessage, string clientTextMessage)
        {
            this.answerMessage = answerMessage ?? throw new ArgumentNullException(nameof(answerMessage));
            this.clientTextMessage = clientTextMessage ?? throw new ArgumentNullException(nameof(clientTextMessage));
        }

        public MessageType Type => MessageType.Text;

        public IAnswerMessage AnswerMessage { get => answerMessage; set => answerMessage = value; }
        public string ClientTextMessage { get => clientTextMessage; set => clientTextMessage = value; }

        public bool IsNeededThisAnwer(Message message)
        {
            return message.Text == ClientTextMessage;
        }
    }
}
