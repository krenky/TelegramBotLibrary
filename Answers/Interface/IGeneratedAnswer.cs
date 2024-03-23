using Telegram.Bot.Types;

namespace TelegramBotLibrary.Answers.Interface
{
    public interface IGeneratedAnswer : IAnswer
    {
        /// <summary>
        /// Генерация ответа (Например получение ответа от ИИ)
        /// </summary>
        /// <param name="message">Сообщение клиента</param>
        /// <returns></returns>
        public Task GaneratedAnswer(Message message);
    }
}