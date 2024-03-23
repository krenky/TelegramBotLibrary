using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotLibrary.Answers.Interface;
using TelegramBotLibrary.Handlers.Interface;

namespace TelegramBotLibrary.Handlers
{
    /// <summary>
    /// Хендлер который обрабатывает разние типы <see cref="Update.Type"/>
    /// </summary>
    public class UpdateHandler : IUpdateHandler
    {
        IMessageHandler _messageHandler;
        ISendHandler _sendHandler;
        ILogger _logger;

        public UpdateHandler(IMessageHandler messageHandler,ISendHandler sendHandler, ILogger logger = null)
        {
            MessageHandler = messageHandler ?? throw new ArgumentNullException(nameof(messageHandler));
            SendHandler = sendHandler;
            Logger = logger/* ?? throw new ArgumentNullException(nameof(logger))*/;
        }

        public IMessageHandler MessageHandler { get => _messageHandler; set => _messageHandler = value; }
        public ISendHandler SendHandler { get => _sendHandler; set => _sendHandler = value; }
        public ILogger Logger { get => _logger; set => _logger = value; }
        

        public virtual async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                switch (update.Type)
                {
                    case UpdateType.Message:
                        {
                            IAnswer answer = await MessageHandler.HandleMessageAsync(update.Message, cancellationToken);
                            await _sendHandler.HandleSendAsync(botClient, update.Message, answer, cancellationToken);
                        }
                        break;
                    default:
                        {
                            Logger.LogInformation("Вызван неподерживаемый тип update", update.Type);
                        }
                        break;
                }
            }
            catch (Exception)
            {
                await botClient.SendTextMessageAsync(update.Message.Chat, "Сообщение недоступно");
                //throw;
            }
            
        }
    }
}
