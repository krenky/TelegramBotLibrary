using Telegram.Bot;
using Telegram.Bot.Polling;

namespace TelegramBotLibrary
{
    /// <summary>
    /// Класс телеграм бота
    /// </summary>
    /// <example>
    /// <code>
    /// internal class Program
    ///TelegramBotLibrary.Handlers.IUpdateHandler _updateHandler = new UpdateHandler(
    ///    new MessageHandler(
    ///        new List<IAnswer>()
    ///        {
    ///                new TextToTextAnswer(
    ///                    new TextAnswerMessage("Hello"),
    ///                    "Hi"
    ///                    )
    ///        }),
    ///    new SendHandler()
    ///    );
    ///TelegramBot botic = new TelegramBot(bot, _updateHandler);
    ///botic.Start();
    /// </code>
    /// </example>
    public class TelegramBot
    {
        ITelegramBotClient _bot;
        Handlers.Interface.IUpdateHandler _updateHandler;

        public TelegramBot(string token, Handlers.Interface.IUpdateHandler updateHandler)
        {
            if (token != null)
                this._bot = new TelegramBotClient(token);
            else
                throw new ArgumentNullException(nameof(token));
             _updateHandler = updateHandler;
        }

        public TelegramBot(ITelegramBotClient bot, Handlers.Interface.IUpdateHandler updateHandler)
        {
            if (bot != null)
                this._bot = bot;
            else
                throw new ArgumentNullException(nameof(bot));
            _updateHandler = updateHandler;
        }

        public virtual async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        public virtual void Start()
        {
            Console.WriteLine("Запущен бот " + _bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            _bot.StartReceiving(
                _updateHandler.HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}
