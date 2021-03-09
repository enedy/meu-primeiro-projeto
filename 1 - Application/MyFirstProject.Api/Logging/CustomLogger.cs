using Microsoft.Extensions.Logging;
using System;

namespace MyFirstProject.Api.Logging
{
    public class CustomLogger : ILogger
    {
        readonly string _loggerName;
        readonly CustomLoggerProviderConfiguration _loggerConfig;
        public CustomLogger(string name, CustomLoggerProviderConfiguration config)
        {
            this._loggerName = name;
            this._loggerConfig = config;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            throw new NotImplementedException();
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            string mensagem = string.Format("{0}: {1} - {2}", logLevel.ToString(),
                eventId.Id, formatter(state, exception));
            SendRepositoryLog(mensagem);
        }
        private void SendRepositoryLog(string mensagem)
        {
            // FAZ A COMUNICACAO COM UM SERVIDOR DE LOGS (SENTRY POR EXEMPLO)
        }
    }
}