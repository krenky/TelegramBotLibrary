using Telegram.Bot.Types.Enums;

namespace TelegramBotLibrary.AnswerMessages.Interface
{
    /// <summary>
    /// Интерйес для отправки ответа
    /// </summary>
    public interface IAnswerMessage
    {
        /// <summary>
        /// Тип ответа на сообщение клиента
        /// </summary>
        public MessageType MessageType { get; }
    }
}
