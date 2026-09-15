using System.Net.Sockets;
using Common.Domen;
using Common.Komunikacija;

namespace Klijent
{
    /// <summary>
    /// Singleton preko kog klijent komunicira sa serverom - otvara konekciju
    /// i za svaku sistemsku operaciju šalje Zahtev i čita Odgovor.
    /// </summary>
    internal class Komunikacija
    {
        private static Komunikacija? instance;

        /// <summary>Jedina instanca klijentske komunikacije.</summary>
        public static Komunikacija Instance
        {
            get
            {
                if (instance == null) instance = new Komunikacija();
                return instance;
            }
        }

        private Komunikacija() { }

        private Socket socket;
        private JsonNetworkSerializer serializer;
        /// <summary>Trenutno prijavljeni radnik (postavlja se nakon uspešne prijave).</summary>
        public Radnik? PrijavljeniRadnik { get; private set; }

        /// <summary>Uspostavlja TCP konekciju ka serveru na 127.0.0.1:9999.</summary>
        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(socket);
        }

        private Odgovor PosaljiIPrimi(Operacija operacija, object? podaci)
        {
            Zahtev zahtev = new Zahtev { Operacija = operacija, Objekat = podaci! };
            serializer.Send(zahtev);
            Odgovor odgovor = serializer.Receive<Odgovor>();
            if (!odgovor.Uspesno)
            {
                throw new Exception(odgovor.Greska);
            }
            return odgovor;
        }
        /// <summary>Pronalazi aktivno članstvo date osobe.</summary>
        public Članstvo VratiAktivnoClanstvoOsobe(int osobaID)
        {
            Odgovor odgovor = PosaljiIPrimi(Operacija.VratiAktivnoClanstvoOsobe, osobaID);
            return serializer.ReadType<Članstvo>(odgovor.Objekat)!;
        }
        /// <summary>Vraća sve kvalifikacije.</summary>
        public List<Kvalifikacija> VratiSveKvalifikacije()
        {
            Odgovor odgovor = PosaljiIPrimi(Operacija.VratiSveKvalifikacije, null);
            return serializer.ReadType<List<Kvalifikacija>>(odgovor.Objekat)!;
        }
        /// <summary>Vraća sve kategorije.</summary>
        public List<Kategorija> VratiSveKategorije()
        {
            Odgovor odgovor = PosaljiIPrimi(Operacija.VratiSveKategorije, null);
            return serializer.ReadType<List<Kategorija>>(odgovor.Objekat)!;
        }
        /// <summary>Kreira novu kvalifikaciju.</summary>
        public void KreirajKvalifikaciju(Kvalifikacija kvalifikacija) => PosaljiIPrimi(Operacija.KreirajKvalifikaciju, kvalifikacija);

        /// <summary>Prijavljuje radnika na sistem.</summary>
        public Radnik Prijava(Radnik radnik)
        {
            Odgovor odgovor = PosaljiIPrimi(Operacija.Prijava, radnik);
            PrijavljeniRadnik = serializer.ReadType<Radnik>(odgovor.Objekat)!;
            return PrijavljeniRadnik;
        }

        /// <summary>Kreira novog radnika.</summary>
        public void KreirajRadnika(Radnik radnik) => PosaljiIPrimi(Operacija.KreirajRadnika, radnik);

        /// <summary>Menja podatke radnika.</summary>
        public void PromeniRadnika(Radnik radnik) => PosaljiIPrimi(Operacija.PromeniRadnika, radnik);

        /// <summary>Deaktivira radnika.</summary>
        public void DeaktivirajRadnika(int radnikID) => PosaljiIPrimi(Operacija.DeaktivirajRadnika, radnikID);

        /// <summary>Pretražuje radnike po imenu/prezimenu.</summary>
        public List<Radnik> PretraziRadnika(string kriterijum)
        {
            Odgovor odgovor = PosaljiIPrimi(Operacija.PretraziRadnika, kriterijum);
            return serializer.ReadType<List<Radnik>>(odgovor.Objekat)!;
        }
        
        /// <summary>Kreira novu osobu.</summary>
        public void KreirajOsobu(Osoba osoba) => PosaljiIPrimi(Operacija.KreirajOsobu, osoba);

        /// <summary>Menja podatke osobe.</summary>
        public void PromeniOsobu(Osoba osoba) => PosaljiIPrimi(Operacija.PromeniOsobu, osoba);

        /// <summary>Briše osobu.</summary>
        public void ObrisiOsobu(int osobaID) => PosaljiIPrimi(Operacija.ObrisiOsobu, osobaID);

        /// <summary>Pretražuje osobe po imenu/prezimenu/JMBG-u.</summary>
        public List<Osoba> PretraziOsobu(string kriterijum)
        {
            Odgovor odgovor = PosaljiIPrimi(Operacija.PretraziOsobu, kriterijum);
            return serializer.ReadType<List<Osoba>>(odgovor.Objekat)!;
        }

        /// <summary>Kreira novog trenera.</summary>
        public void KreirajTrenera(Trener trener) => PosaljiIPrimi(Operacija.KreirajTrenera, trener);

        /// <summary>Menja podatke trenera, uključujući status aktivnosti.</summary>
        public void PromeniTrenera(Trener trener) => PosaljiIPrimi(Operacija.PromeniTrenera, trener);

        /// <summary>Vraća sve aktivne trenere.</summary>
        public List<Trener> VratiSveAktivneTrenere()
        {
            Odgovor odgovor = PosaljiIPrimi(Operacija.VratiSveAktivneTrenere, null);
            return serializer.ReadType<List<Trener>>(odgovor.Objekat)!;
        }

        /// <summary>Kreira novo članstvo.</summary>
        public void KreirajClanstvo(Članstvo clanstvo) => PosaljiIPrimi(Operacija.KreirajClanstvo, clanstvo);

        /// <summary>Otkazuje članstvo.</summary>
        public void OtkaziClanstvo(int clanstvoID) => PosaljiIPrimi(Operacija.OtkaziClanstvo, clanstvoID);

        /// <summary>Izračunava ukupnu cenu (članarinu) za dato članstvo.</summary>
        public decimal IzracunajUkupnuCenuClanstva(int clanstvoID)
        {
            Odgovor odgovor = PosaljiIPrimi(Operacija.IzracunajUkupnuCenuClanstva, clanstvoID);
            return serializer.ReadType<decimal>(odgovor.Objekat);
        }

        /// <summary>Dodeljuje kvalifikaciju radniku.</summary>
        public void DodeliKvalifikacijuRadniku(RadnikKvalifikacija rk) => PosaljiIPrimi(Operacija.DodeliKvalifikacijuRadniku, rk);

        /// <summary>Dodaje stavku (trening) u okviru postojećeg članstva.</summary>
        public void DodajStavkuClanstva(StavkaČlanstva stavka) => PosaljiIPrimi(Operacija.DodajStavkuClanstva, stavka);
    }
}
