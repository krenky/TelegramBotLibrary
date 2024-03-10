using Telegram.Bot.Types;

namespace TelegramBotLibrary.Messages
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessage
    {

        /// <summary>
        /// Запрос клиента
        /// </summary>
        public string ClientMessage { get; set; }

        /// <summary>
        /// Ответ на <see cref="ClientMessage"/>
        /// </summary>
        public string Answer { get; set; }

        /// <summary>
        /// Возможные сообщения после отправки текущего <see cref="ClientMessage"/>
        /// </summary>
        public IList<IMessage> Messages { get; set; }

        public string GetMessage(Update update);

        /// <summary>
        /// Необходимое действие перед ответом
        /// </summary>
        protected internal void Action(Update update);
    }
}
