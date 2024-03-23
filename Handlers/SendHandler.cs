using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotLibrary.AnswerMessages;
using TelegramBotLibrary.Answers.Interface;
using TelegramBotLibrary.Handlers.Interface;

namespace TelegramBotLibrary.Handlers
{
    public class SendHandler : ISendHandler
    {
        public virtual async Task HandleSendAsync(ITelegramBotClient botClient, Message message, IAnswer answer, CancellationToken cancellationToken)
        {
            try
            {
                switch (answer.AnswerMessage.MessageType)
                {
                    case Telegram.Bot.Types.Enums.MessageType.Unknown:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Text:
                        {
                            TextAnswerMessage textAnswer = (TextAnswerMessage)answer.AnswerMessage;
                            await botClient.SendTextMessageAsync(
                            chatId: message.Chat,
                            text: textAnswer.Text,
                            parseMode: textAnswer.ParseMode,
                            disableNotification: textAnswer.IsDisableNotification,
                            replyToMessageId: message.MessageId,
                            replyMarkup: textAnswer.ReplyMarkup,
                            cancellationToken: cancellationToken);
                        }
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Photo:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Audio:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Video:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Voice:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Document:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Sticker:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Location:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Contact:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Venue:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Game:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoNote:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Invoice:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.SuccessfulPayment:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.WebsiteConnected:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatMembersAdded:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatMemberLeft:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatTitleChanged:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatPhotoChanged:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.MessagePinned:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatPhotoDeleted:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.GroupCreated:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.SupergroupCreated:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChannelCreated:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.MigratedToSupergroup:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.MigratedFromGroup:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Poll:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Dice:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.MessageAutoDeleteTimerChanged:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ProximityAlertTriggered:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.WebAppData:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoChatScheduled:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoChatStarted:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoChatEnded:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.VideoChatParticipantsInvited:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.Animation:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ForumTopicCreated:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ForumTopicClosed:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ForumTopicReopened:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ForumTopicEdited:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.GeneralForumTopicHidden:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.GeneralForumTopicUnhidden:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.WriteAccessAllowed:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.UserShared:
                        break;
                    case Telegram.Bot.Types.Enums.MessageType.ChatShared:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }
    }
}
