using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBotLibrary.Messages;
using Telegram.Bot.Types.Enums;

namespace TelegramBotLibrary
{
    /// <summary>
    /// Класс телеграм бота
    /// </summary>
    /// <example>
    /// <code>
    /// internal class Program
    ///{
    ///    static ITelegramBotClient bot = new TelegramBotClient("Token");
    ///
    ///
    ///    static void Main(string[] args)
    ///    {
    ///        Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);
    ///        IList<IMessage> messages = new List<IMessage>() { new SimpleMessage("hello", "hello pedic") };
    ///        TelegramBot botic = new TelegramBot(bot, messages);
    ///        botic.Start();
    ///    }
    ///}
    /// </code>
    /// </example>
public class TelegramBot
    {
        ITelegramBotClient bot;
        IList<IMessage> messages;
        IMessage prevMessage;

        public TelegramBot(string token, IList<IMessage> messages)
        {
            if (token != null)
                this.bot = new TelegramBotClient(token);
            else
                throw new ArgumentNullException(nameof(token));
            this.messages = messages;
        }

        public TelegramBot(ITelegramBotClient bot, IList<IMessage> messages)
        {
            if (bot != null)
                this.bot = bot;
            else
                throw new ArgumentNullException(nameof(bot));
            this.messages = messages;
        }

        public virtual async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    {
                        IList<IMessage> allowedMessages;
                        if (prevMessage != null && prevMessage.Messages.Count != 0)
                        {
                            allowedMessages = prevMessage.Messages;
                        }
                        else
                        {
                            allowedMessages = messages;
                        }
                        IMessage answerMessage = GetMessage(update, allowedMessages);
                        if (answerMessage == null)
                        {
                            await botClient.SendTextMessageAsync(update.Message.Chat, "Команда недоступна");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(update.Message.Chat, answerMessage.Answer);
                            prevMessage = answerMessage;
                        }
                    }
                    break;
            }
            
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
        }

        public virtual IMessage GetMessage(Update update, IList<IMessage> messages)
        {
            IMessage currentMessage = messages
                        .FirstOrDefault(x => x.ClientMessage == update.Message.Text.ToLower());
            if (currentMessage != null)
            {
                return currentMessage.GetMessage(update);
            }
            else
            {
                return null;
            }
        }

        public virtual async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        public virtual void Start()
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}
