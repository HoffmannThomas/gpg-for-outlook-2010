namespace GPG4OutlookLib.Methods
{
    public class Decrypt : Method
    {
        public Decrypt()
            : base()
        {
            this.commandLine.Append("--decrypt ");
        }
    }
}
