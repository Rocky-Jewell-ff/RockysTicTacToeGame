namespace TicTacToeLibrary.DataAccess
{
    public class GlobalConfig // This is completely not needed because we only have 1 data base. But! if you wanted to switch to a Sql data base you could use this class to easily do that.
    {
        public static IDataConnection Connection { get; private set; }//private set means only methods inside this GlobalConfig class can change the value of Connections
                                                                      //but everyone can read the vaule of connections (because its set to "get")
                                                                      //We made a list of dataConnections just in cause we want multiple ways to save our data such as Database or textfile.
        public static void InitializeConnection(DatabaseType db)
        {
            if (db == DatabaseType.TextFile)
            {
                TextConnector text = new TextConnector(); // creates a new instance of the class TextConnection and calls it text.
                Connection = (text); // Connection is the List<IDataConnection> and we are adding the information created in the class "text" into that list.
            }
        }
    }
}
