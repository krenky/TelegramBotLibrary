using Telegram.Bot.Types;
using TelegramBotLibrary.Answers.Interface;

namespace TelegramBotLibrary.Handlers.Interface
{
    public interface IMessageHandler
    {
        Task<IAnswer> HandleMessageAsync(Message message, CancellationToken cancellationToken);
    }
}