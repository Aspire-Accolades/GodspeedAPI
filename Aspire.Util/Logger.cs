using Aspire.Constants;
using Microsoft.Extensions.Logging;

namespace Aspire.Util
{
  public class Logger
  {
    public ILogger<Logger> _logger { get; set; }
    public string _directoryPath
    {
      get
      {
        return Directory.GetCurrentDirectory() + Keys.LogPath;
      }
    }

    public bool _hasDirectory
    {
      get
      {
        return Directory.Exists(_directoryPath); 
      }
    }
    public string _filePath
    {
      get
      {
        return _directoryPath + Keys.LogFile;
      }
    }

    public Logger(ILogger<Logger> logger)
    {
      _logger = logger;
      if (!_hasDirectory)
      {
        Directory.CreateDirectory(_directoryPath);
      }
    }

    public void Log(string message)
    {
      try
      {
          using (StreamWriter writer = File.AppendText(_filePath))
          {
          string text = $"{DateTime.Now}: {message}";
          writer.WriteLine(text);

          _logger.LogInformation(text);
          }
      }
      catch (Exception ex)
      {
        if (ex.InnerException != null)
          Console.WriteLine(ex.InnerException.Message);
        else
          Console.WriteLine(ex.Message);
      }
    }

    public void Write()
    {
      
    }
  }
}