using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotLibrary.AnswerMessages.Interface;

namespace TelegramBotLibrary.Answers.Interface
{
    /// <summary>
    /// Ответ.
    /// </summary>
    public interface IAnswer
    {
        /// <summary>
        /// Тип запроса клиента
        /// </summary>
        public MessageType Type { get; }

        /// <summary>
        /// Ответ на запрос
        /// </summary>
        public IAnswerMessage AnswerMessage { get; }

        /// <summary>
        /// проверка нужен этот ответ
        /// </summary>
        /// <param name="message">Сообщение клиента</param>
        /// <returns></returns>
        public bool IsNeededThisAnwer(Message message);

    }
}
