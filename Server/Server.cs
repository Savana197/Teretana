using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    /// <summary>
    /// TCP server koji prihvata konekcije klijenata i za svakog pokreće
    /// posebnu nit (ClientHandler) koja opslužuje njegove zahteve.
    /// </summary>
    internal class Server
    {
        private Socket socket;
        private List<ClientHandler> klijenti = new List<ClientHandler>();

        /// <summary>Kreira TCP socket spreman za pokretanje.</summary>
        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        /// <summary>Pokreće server - veže socket na port i počinje da prihvata klijente u pozadinskoj niti.</summary>
        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);

            socket.Bind(endPoint);
            socket.Listen(5);

            Thread acceptClientsThread = new Thread(AcceptClient);
            acceptClientsThread.IsBackground = true;
            acceptClientsThread.Start();
        }

        /// <summary>Petlja koja prihvata nove klijente i za svakog pokreće posebnu nit.</summary>
        public void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSoket = socket.Accept();
                    ClientHandler handler = new ClientHandler(klijentskiSoket, klijenti);
                    klijenti.Add(handler);
                    Thread nitKlijenta = new Thread(handler.Handle);
                    nitKlijenta.IsBackground = true;
                    nitKlijenta.Start();
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("SE>>> " + ex.Message);
            }
            catch (IOException ex)
            {
                Debug.WriteLine("IOE>>> " + ex.Message);
            }
        }

        /// <summary>Zaustavlja server - zatvara sve klijentske konekcije i glavni socket.</summary>
        internal void Stop()
        {
            foreach (var klijent in klijenti)
            {
                klijent.Close();
            }
            klijenti.Clear();
            socket?.Close();
        }
    }
}
