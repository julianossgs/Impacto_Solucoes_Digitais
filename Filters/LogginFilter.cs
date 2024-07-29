namespace Impacto_Solucoes_Digitais.Filters
{
    public class LogginFilter
    {
        private readonly ILogger<LogginFilter> _logger;
        public LogginFilter(ILogger<LogginFilter> logger)
        {
            _logger = logger;
        }
    }
}
