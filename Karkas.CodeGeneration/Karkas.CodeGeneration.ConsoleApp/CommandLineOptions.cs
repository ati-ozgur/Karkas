using CommandLine;

namespace Karkas.CodeGeneration.ConsoleApp;

// https://github.com/commandlineparser/commandline
public class CommandLineOptions
{
    [Option('v', "verbose", Required = false, HelpText = "Enable verbose output.")]
    public bool Verbose { get; set; }

    [Option('c', "connectionname", Required = true, HelpText = "Which connection name will be used in config.json")]
    public string ConnectionName { get; set; }

    string _configFileName = "karkas-config.json";

    [Option('f', "configfilename", Required = false, HelpText = "default configuration filename is karkas-config.json")]
    public string ConfigFileName
    {
        get
        {
            return _configFileName;
        }
        set
        {
            _configFileName = value;
        }
    }

    public override string ToString()
    {
        string result = $"ConfigFileName: {ConfigFileName}, ConnectionName: {ConnectionName}";
        return result;
    }

}
