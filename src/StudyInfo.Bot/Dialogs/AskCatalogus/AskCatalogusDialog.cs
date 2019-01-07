using Microsoft.Bot.Builder.Dialogs;
using StudyInfo.Bot.Dialogs.Shared;
using StudyInfo.Bot.StudyInfo;
using StudyInfo.Logic.Data;

namespace StudyInfo.Bot.Dialogs.AskCatalogus
{
    public class AskCatalogusDialog : StudyInfoDialog
    {
        public AskCatalogusDialog(BotServices botServices, IDatabaseService databaseService) : base(botServices, databaseService, nameof(AskCatalogusDialog))
        {
            InitialDialogId = nameof(AskCatalogusDialog);

            var course = new WaterfallStep[]
            {
            };
            AddDialog(new WaterfallDialog(InitialDialogId, course) { });
        }
    }
}
