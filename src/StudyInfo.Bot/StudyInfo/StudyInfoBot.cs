using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using StudyInfo.Bot.Dialogs.Dispatcher;
using StudyInfo.Logic.Data;

namespace StudyInfo.Bot.StudyInfo
{
    public class StudyInfoBot : IBot
    {
        private readonly BotServices _services;
        private readonly ConversationState _conversationState;
        private readonly UserState _userState;
        private readonly IBotTelemetryClient _telemetryClient;
        private readonly IDatabaseService _databaseService;
        private DialogSet _dialogs;

        /// <summary>
        /// Initializes a new instance of the <see cref="NlpDispatchBot"/> class.
        /// </summary>
        /// <param name="services">Services configured from the ".bot" file.</param>
        public StudyInfoBot(BotServices botServices, ConversationState conversationState, UserState userState, IDatabaseService databaseService, IBotTelemetryClient telemetryClient)
        {
            _conversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
            _userState = userState ?? throw new ArgumentNullException(nameof(userState));
            _services = botServices ?? throw new ArgumentNullException(nameof(botServices));
            _telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
            _databaseService = databaseService ?? throw new ArgumentNullException(nameof(databaseService));

            _dialogs = new DialogSet(_conversationState.CreateProperty<DialogState>(nameof(StudyInfoBot)));
            _dialogs.Add(new MainDialog(_services, _conversationState, _userState, _databaseService, _telemetryClient));
        }

        /// <summary>
        /// Run every turn of the conversation. Handles orchestration of messages.
        /// </summary>
        /// <param name="turnContext">Bot Turn Context.</param>
        /// <param name="cancellationToken">Task CancellationToken.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            // Client notifying this bot took to long to respond (timed out)
            if (turnContext.Activity.Code == EndOfConversationCodes.BotTimedOut)
            {
                _services.TelemetryClient.TrackTrace($"Timeout in {turnContext.Activity.ChannelId} channel: Bot took too long to respond.");
                return;
            }
            var dc = await _dialogs.CreateContextAsync(turnContext);
            if (dc.ActiveDialog != null)
            {
                var result = await dc.ContinueDialogAsync();
            }
            else
            {
                await dc.BeginDialogAsync(nameof(MainDialog));
            }
        }
    }
}