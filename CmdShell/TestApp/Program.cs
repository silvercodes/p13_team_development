


using CmdShell;


Application app = new Application();
// Add command
app.Run();





class CleanCommand : Command
{
    public override string Signature => "clean {path} {--depth|d=:Finding depth} {--report|r=report.json:Make the report}";

    public override string Description => "Clean the specific files";
    public override string Help => "https://google.com";


    public override void Execute()
    {
        Console.WriteLine("Command OK");



    }
}


