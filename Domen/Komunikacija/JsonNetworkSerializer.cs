using System.Net.Sockets;
using System.Text.Json;

namespace Common.Komunikacija
{
    /// <summary>
    /// Serijalizuje i šalje/prima objekte kao JSON preko mrežnog socket-a -
    /// koristi se i na strani servera i na strani klijenta za komunikaciju.
    /// </summary>
    public class JsonNetworkSerializer
    {
        private readonly Socket s;
        private NetworkStream stream;
        private StreamReader reader;
        private StreamWriter writer;

        /// <summary>Kreira serijalizator nad datim socket-om i otvara tok za čitanje/pisanje.</summary>
        /// <param name="s">Povezani socket preko kog se šalju i primaju podaci.</param>
        public JsonNetworkSerializer(Socket s)
        {
            this.s = s;
            stream = new NetworkStream(s);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }

        /// <summary>Serijalizuje dati objekat u JSON i šalje ga preko mreže.</summary>
        /// <param name="z">Objekat koji se šalje (npr. Zahtev ili Odgovor).</param>
        public void Send(object z)
        {
            writer.WriteLine(JsonSerializer.Serialize(z));
        }

        /// <summary>Čita jednu JSON poruku sa mreže i deserijalizuje je u dati tip.</summary>
        /// <typeparam name="T">Tip u koji se poruka deserijalizuje.</typeparam>
        /// <returns>Deserijalizovani objekat.</returns>
        public T Receive<T>()
        {
            string json = reader.ReadLine()!;
            return JsonSerializer.Deserialize<T>(json)!;
        }

        /// <summary>Konvertuje generički objekat (npr. JsonElement primljen unutar Zahtev/Odgovor) u konkretan tip - radi i za klase i za proste tipove (int, decimal...).</summary>
        /// <typeparam name="T">Ciljni tip u koji se podaci konvertuju.</typeparam>
        /// <param name="podaci">Sirovi podaci za konverziju, ili null.</param>
        /// <returns>Konvertovani objekat, ili default vrednost tipa T ako su ulazni podaci null.</returns>
        public T? ReadType<T>(object? podaci)
        {
            if (podaci == null) return default;
            return JsonSerializer.Deserialize<T>((JsonElement)podaci);
        }

        /// <summary>Zatvara mrežni tok i pridružene čitač/pisač.</summary>
        public void Close()
        {
            stream.Close();
            reader.Close();
            writer.Close();
        }
    }
}
