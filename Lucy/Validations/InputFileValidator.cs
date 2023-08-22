
namespace Lucyc
{
    public class InputFileValidator
    {
        private readonly string[]? _args;
        private readonly string? _fileExtension = ".lucy";

        public InputFileValidator(string[]? args)
        {
            _args = args;
        }

        public void ArgsValidator()
        {
            if (_args == null || _args.Length == 0)
                throw new ArgumentNullException("File .lucy not found");

            if (_args.Length > 1)
                throw new ArgumentNullException("The interpreter accepts only one parameter (the file .lucy parameter)");
        }
        public void InputFileValidadorType() 
        {
            if (Path.GetExtension(_args[0]) != _fileExtension)
                throw new ArgumentNullException("Only .lucy files are supported");

        }
    }
}
