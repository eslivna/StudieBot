using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyInfo.Bot.Extensions
{
    public static class ActivityExtensions
    {
        public static bool IsStartActivity(this Activity activity)
        {
            switch (activity.ChannelId)
            {
                case Channels.Skype:
                    {
                        if (activity.Type == ActivityTypes.ContactRelationUpdate && activity.Action == "add")
                        {
                            return true;
                        }

                        return false;
                    }

                case Channels.Directline:
                case Channels.Emulator:
                case Channels.Webchat:
                case Channels.Msteams:
                    {
                        if (activity.Type == ActivityTypes.ConversationUpdate)
                        {
                            // When bot is added to the conversation (triggers start only once per conversation)
                            if (activity.MembersAdded.Any(m => m.Id == activity.Recipient.Id))
                            {
                                return true;
                            }
                        }

                        return false;
                    }

                default:
                    {
                        return false;
                    }
            }
        }
        

        public static Activity GetReplyFromText(this Activity originalActivity, string fullReplyText)
        {
            var reply = JsonConvert.DeserializeObject<Activity>(fullReplyText);
            if (reply.Attachments == null)
                reply.Attachments = new List<Attachment>();

            originalActivity.SetReplyFields(reply);

            return reply;
        }

        public static void SetReplyFields(this Activity originalActivity, IMessageActivity reply)
        {
            var tempReply = originalActivity.CreateReply("");

            reply.ChannelId = tempReply.ChannelId;
            reply.Timestamp = tempReply.Timestamp;
            reply.From = tempReply.From;
            reply.Conversation = tempReply.Conversation;
            reply.Recipient = tempReply.Recipient;
            reply.Id = tempReply.Id;
            reply.ReplyToId = tempReply.ReplyToId;

            if (reply.Type == null)
                reply.Type = ActivityTypes.Message;
        }
    }
}