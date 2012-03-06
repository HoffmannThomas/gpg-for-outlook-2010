namespace GPG4OutlookLib.Methods
{
    public class Verify : Method
    {
        public Verify() : base()
        {
            this.commandLine.Append("--verify ");
        }
    }
}
