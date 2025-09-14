namespace APICatalogo.Loggin;

public class CustomerLogger : ILogger
{
    private readonly string loggerName;
    private readonly CustomLoggerProviderConfiguration loggerConfig;

    public CustomerLogger(string name, CustomLoggerProviderConfiguration config)
    {
        loggerName = name;
        loggerConfig = config;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel == loggerConfig.LogLevel;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, 
        Exception? exception, Func<TState, Exception?, string> formatter)
    {
        string mensagem = $"{logLevel.ToString()}: {eventId.Id} - {formatter(state, exception)}";

        EsceverTextoNoArquivo(mensagem);
    }

    private void EsceverTextoNoArquivo(string mensagem)
    {
        string caminhoArquivoLog = @"d:\dados\log\Paulo_log.txt";
        
        using (StreamWriter writer = new StreamWriter(caminhoArquivoLog, true))
        {
            try
            {
                writer.WriteLine(mensagem);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.Write("Erro no arquivo Log: " + e);
            }
        }
    }
}
