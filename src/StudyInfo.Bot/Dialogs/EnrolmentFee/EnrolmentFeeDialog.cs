using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using StudyInfo.Bot.Dialogs.Shared;
using StudyInfo.Bot.StudyInfo;
using StudyInfo.Logic.Data;

namespace StudyInfo.Bot.Dialogs.EnrolmentFee
{
    public class EnrolmentFeeDialog : StudyInfoDialog
    {
        private IDatabaseService _databaseService;
        private BotServices _botServices;
        private static EnrolmentFeeResponses _responder = new EnrolmentFeeResponses();

        public EnrolmentFeeDialog(BotServices botServices, IDatabaseService databaseService) : base(botServices, databaseService, nameof(EnrolmentFeeDialog))
        {
            _databaseService = databaseService;
            _botServices = botServices;

            InitialDialogId = nameof(EnrolmentFeeDialog);

            var enrolmentFee = new WaterfallStep[]
            {
                AskStudentType
            };

            AddDialog(new WaterfallDialog(InitialDialogId, enrolmentFee));
        }

        private async Task<DialogTurnResult> AskStudentType (WaterfallStepContext sc, CancellationToken cancellationToken)
        {

            //await sc.PromptAsync(DialogIds.StudentTypePrompt, new PromptOptions()
            //{
            //    Prompt = await _responder.RenderTemplate(sc.Context, sc.Context.Activity.Locale, EnrolmentFeeResponses.ResponseIds.StudentTypePrompt),
            //    Choices = ChoiceFactory.ToChoices(new List<string> { "Niet-Beursstudent", "Beursstudent", "Bijna Beursstudent"})
            //});
            return await sc.EndDialogAsync();
        }
    }
}
