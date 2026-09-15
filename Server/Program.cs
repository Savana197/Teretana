namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
            Console.WriteLine("Server je pokrenut na portu 9999. Pritisni Enter za izlaz.");
            Console.ReadLine();
            server.Stop();
        }
    }
}