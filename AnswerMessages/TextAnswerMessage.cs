using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotLibrary.AnswerMessages.Interface;

namespace TelegramBotLibrary.AnswerMessages
{
    /// <summary>
    /// Класс для отправка текстового ответа
    /// </summary>
    public class TextAnswerMessage : IAnswerMessage
    {
        public TextAnswerMessage(string text) 
        {
            Text = text;
            ParseMode = ParseMode.Html;
            IsDisableNotification = false;
            this.cancellationToken = cancellationToken;
        }

        public TextAnswerMessage(string text, ParseMode parseMode, bool isDisableNotification, int? replyToMessageId, IReplyMarkup replyMarkup, CancellationToken cancellationToken) : this(text)
        {
            ParseMode = parseMode;
            IsDisableNotification = isDisableNotification;
            ReplyToMessageId = replyToMessageId;
            ReplyMarkup = replyMarkup;
            this.cancellationToken = cancellationToken;
        }

        /// <summary>
        /// Тип ответа
        /// </summary>
        public MessageType MessageType => MessageType.Text;
        
        /// <summary>
        /// Токен отмены
        /// </summary>
        public CancellationToken cancellationToken { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Тип парсинга сообщения
        /// </summary>
        /// <example>
        /// <code> 
        /// ParseMode.MarkdownV2
        /// </code>
        /// </example>
        public ParseMode ParseMode { get; set; }

        /// <summary>
        /// Вкл\выкл уведомления
        /// </summary>
        public bool IsDisableNotification { get; set; }

        /// <summary>
        /// Id сообщения на который будет ссылаться ответ
        /// </summary>
        public int? ReplyToMessageId { get; set; }

        /// <summary>
        /// Кнопка под ответом
        /// </summary>
        /// <example>
        /// <code>
        /// new InlineKeyboardMarkup(
        /// InlineKeyboardButton.WithUrl(
        ///     text: "Check sendMessage method",
        ///     url: "https://core.telegram.org/bots/api#sendmessage")),
        /// </code>
        /// </example>
        public IReplyMarkup ReplyMarkup { get; set; }
    }
}
