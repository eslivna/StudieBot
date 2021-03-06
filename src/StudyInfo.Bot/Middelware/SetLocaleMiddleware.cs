﻿using Microsoft.Bot.Builder;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace StudyInfo.Bot.Middleware
{
    public class SetLocaleMiddleware : IMiddleware
    {
        private readonly string defaultLocale;

        public SetLocaleMiddleware(string defaultDefaultLocale)
        {
            defaultLocale = defaultDefaultLocale;
        }

        public async Task OnTurnAsync(ITurnContext context, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            var cultureInfo = string.IsNullOrEmpty(context.Activity.Locale) ? new CultureInfo(defaultLocale) : new CultureInfo(context.Activity.Locale);

            CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture = cultureInfo;

            await next(cancellationToken).ConfigureAwait(false);
        }
    }
}
