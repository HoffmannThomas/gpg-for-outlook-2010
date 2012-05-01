namespace GPG4OutlookLib.Methods
{
    internal class Decrypt : Method
    {
        internal Decrypt()
            : base()
        {
            this.commandLine.Append("--decrypt ");
        }
    }
}
