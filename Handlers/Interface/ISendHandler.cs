using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotLibrary.Answers.Interface;

namespace TelegramBotLibrary.Handlers.Interface
{
    public interface ISendHandler
    {
        Task HandleSendAsync(ITelegramBotClient botClient, Message message, IAnswer answer, CancellationToken cancellationToken);
    }
}