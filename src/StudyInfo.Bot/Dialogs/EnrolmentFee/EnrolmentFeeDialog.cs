using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using StudyInfo.Bot.Dialogs.Shared;
using StudyInfo.Bot.StudyInfo;
using StudyInfo.Logic.Data;

namespace StudyInfo.Bot.Dialogs.EnrolmentFee
{
    public class EnrolmentFeeDialog : StudyInfoDialog
    {
        private IDatabaseService _databaseService;
        private BotServices _botServices;
        private static EnrolmentFeeResponses _response = new EnrolmentFeeResponses();

        public EnrolmentFeeDialog(BotServices botServices, IDatabaseService databaseService) : base(botServices, databaseService, nameof(EnrolmentFeeDialog))
        {
            _databaseService = databaseService;
            _botServices = botServices;

            InitialDialogId = nameof(EnrolmentFeeDialog);

            var escalate = new WaterfallStep[]
            {
                SendNameTeacher,
            };

            AddDialog(new WaterfallDialog(InitialDialogId, escalate));
        }


    }
}
