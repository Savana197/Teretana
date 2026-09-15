using System.Diagnostics;
using System.Net.Sockets;
using Common.Domen;
using Common.Komunikacija;

namespace Server
{
    /// <summary>
    /// Opslužuje jednog povezanog klijenta - prima zahteve, prosleđuje ih
    /// kontroleru i šalje nazad odgovore, sve dok se konekcija ne prekine.
    /// </summary>
    internal class ClientHandler
    {
        private readonly Socket klijent;
        private readonly List<ClientHandler> klijenti;
        private readonly JsonNetworkSerializer serializer;

        /// <summary>Kreira handler za datog klijenta.</summary>
        /// <param name="klijent">Socket povezanog klijenta.</param>
        /// <param name="klijenti">Deljena lista svih trenutno povezanih klijenata.</param>
        public ClientHandler(Socket klijent, List<ClientHandler> klijenti)
        {
            this.klijent = klijent;
            this.klijenti = klijenti;
            serializer = new JsonNetworkSerializer(klijent);
        }

        /// <summary>Petlja koja prima zahteve od klijenta dok se konekcija ne prekine.</summary>
        public void Handle()
        {
            try
            {
                while (true)
                {
                    Zahtev zahtev = serializer.Receive<Zahtev>();
                    Odgovor odgovor = ProcesuirajZahtev(zahtev);
                    serializer.Send(odgovor);
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta: " + ex.Message);
            }
            catch (IOException ex)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta: " + ex.Message);
            }
            finally
            {
                klijenti.Remove(this);
                serializer.Close();
            }
        }

        /// <summary>Prosleđuje zahtev odgovarajućoj operaciji na kontroleru i pravi odgovor.</summary>
        /// <param name="zahtev">Primljeni zahtev od klijenta.</param>
        /// <returns>Odgovor sa rezultatom operacije ili opisom greške.</returns>
        private Odgovor ProcesuirajZahtev(Zahtev zahtev)
        {
            Odgovor odgovor = new Odgovor { Uspesno = true };
            try
            {
                switch (zahtev.Operacija)
                {
                    case Operacija.Prijava:
                        odgovor.Objekat = Kontroler.Instance.PrijaviSe(serializer.ReadType<Radnik>(zahtev.Objekat)!);
                        break;
                    case Operacija.KreirajRadnika:
                        Kontroler.Instance.KreirajRadnika(serializer.ReadType<Radnik>(zahtev.Objekat)!);
                        break;
                    case Operacija.PromeniRadnika:
                        Kontroler.Instance.PromeniRadnika(serializer.ReadType<Radnik>(zahtev.Objekat)!);
                        break;
                    case Operacija.DeaktivirajRadnika:
                        Kontroler.Instance.DeaktivirajRadnika(serializer.ReadType<int>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziRadnika:
                        odgovor.Objekat = Kontroler.Instance.PretraziRadnika(serializer.ReadType<string>(zahtev.Objekat)!);
                        break;
                    case Operacija.KreirajOsobu:
                        Kontroler.Instance.KreirajOsobu(serializer.ReadType<Osoba>(zahtev.Objekat)!);
                        break;
                    case Operacija.PromeniOsobu:
                        Kontroler.Instance.PromeniOsobu(serializer.ReadType<Osoba>(zahtev.Objekat)!);
                        break;
                    case Operacija.ObrisiOsobu:
                        Kontroler.Instance.ObrisiOsobu(serializer.ReadType<int>(zahtev.Objekat));
                        break;
                    case Operacija.PretraziOsobu:
                        odgovor.Objekat = Kontroler.Instance.PretraziOsobu(serializer.ReadType<string>(zahtev.Objekat)!);
                        break;
                    case Operacija.KreirajTrenera:
                        Kontroler.Instance.KreirajTrenera(serializer.ReadType<Trener>(zahtev.Objekat)!);
                        break;
                    case Operacija.ObrisiTrenera:
                        Kontroler.Instance.ObrisiTrenera(serializer.ReadType<int>(zahtev.Objekat));
                        break;
                    case Operacija.VratiSveTrenere:
                        odgovor.Objekat = Kontroler.Instance.VratiSveTrenere();
                        break;
                    case Operacija.KreirajClanstvo:
                        Kontroler.Instance.KreirajClanstvo(serializer.ReadType<Članstvo>(zahtev.Objekat)!);
                        break;
                    case Operacija.OtkaziClanstvo:
                        Kontroler.Instance.OtkaziClanstvo(serializer.ReadType<int>(zahtev.Objekat));
                        break;
                    case Operacija.IzracunajUkupnuCenuClanstva:
                        odgovor.Objekat = Kontroler.Instance.IzracunajUkupnuCenuClanstva(serializer.ReadType<int>(zahtev.Objekat));
                        break;
                    case Operacija.DodeliKvalifikacijuRadniku:
                        Kontroler.Instance.DodeliKvalifikacijuRadniku(serializer.ReadType<RadnikKvalifikacija>(zahtev.Objekat)!);
                        break;
                    case Operacija.VratiIstekleKvalifikacije:
                        odgovor.Objekat = Kontroler.Instance.VratiIsteklaKvalifikacije();
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                odgovor.Greska = ex.Message;
                odgovor.Uspesno = false;
            }
            return odgovor;
        }

        /// <summary>Zatvara socket ka klijentu.</summary>
        internal void Close()
        {
            klijent.Close();
        }
    }
}
