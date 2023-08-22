using Antlr4.Runtime;
using Lucy.Antlr;
using Lucy.Visitor;
using Lucyc;

class Program
{
    private static void Main(string[] args)
    {
        try
        {
            InputFileValidator fileValidator = new InputFileValidator(args);

            fileValidator.ArgsValidator();
            fileValidator.InputFileValidadorType();

            var fileName = args[0];

            var fileContents = File.ReadAllText(fileName);

            AntlrInputStream inputStream = new AntlrInputStream(fileContents);

            SpeakLexer speakLexer = new SpeakLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);

            SpeakParser speakParser = new SpeakParser(commonTokenStream);
            var speakContext = speakParser.program();

            SpeakVisitor visitor = new SpeakVisitor();
            visitor.Visit(speakContext);

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }
    }
}
