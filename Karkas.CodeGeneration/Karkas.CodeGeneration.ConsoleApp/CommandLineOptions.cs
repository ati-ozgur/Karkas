using CommandLine;

// https://github.com/commandlineparser/commandline
public class CommandLineOptions
{
    [Option('v', "verbose", Required = false, HelpText = "Enable verbose output.")]
    public bool Verbose { get; set; }

    [Option('c', "connectionname", Required = true, HelpText = "Which connection name will be used in config.json")]
    public string ConnectionName { get; set; }

    [Option('f', "configfilename", Required = true, HelpText = "Which connection name will be used in config.json")]
    public string ConfigFileName { get; set; }

}