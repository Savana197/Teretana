using Common.Domen;

namespace Klijent
{
    /// <summary>
    /// Glavna forma klijenta - preko tabova nudi pristup svim sistemskim operacijama.
    /// </summary>
    public partial class MainForm : Form
    {
        private List<Radnik> poslednjiRezultatiRadnika = new();
        private List<Osoba> poslednjiRezultatiOsoba = new();
        private List<Trener> poslednjiRezultatiTrenera = new();

        public MainForm()
        {
            InitializeComponent();

            // ID polja se popunjavaju samo izborom iz liste rezultata pretrage - baza sama dodeljuje ID
            txtOsobaID.ReadOnly = true;
            txtRadnikID.ReadOnly = true;
            txtTrenerID.ReadOnly = true;

            btnPrijava.Click += btnPrijava_Click;

            btnRadnikKreiraj.Click += btnRadnikKreiraj_Click;
            btnRadnikPromeni.Click += btnRadnikPromeni_Click;
            btnRadnikDeaktiviraj.Click += btnRadnikDeaktiviraj_Click;
            btnRadnikPretrazi.Click += btnRadnikPretrazi_Click;

            btnOsobaKreiraj.Click += btnOsobaKreiraj_Click;
            btnOsobaPromeni.Click += btnOsobaPromeni_Click;
            btnOsobaObrisi.Click += btnOsobaObrisi_Click;
            btnOsobaPretrazi.Click += btnOsobaPretrazi_Click;

            btnTrenerKreiraj.Click += btnTrenerKreiraj_Click;
            btnTrenerPromeni.Click += btnTrenerPromeni_Click;
            btnTrenerPrikaziAktivne.Click += btnTrenerPrikaziAktivne_Click;

            btnClanstvoKreiraj.Click += btnClanstvoKreiraj_Click;
            btnClanstvoPronadjiAktivno.Click += btnClanstvoPronadjiAktivno_Click;
            btnClanstvoOtkazi.Click += btnClanstvoOtkazi_Click;
            btnClanstvoIzracunajCenu.Click += btnClanstvoIzracunajCenu_Click;
            btnStavkaDodajRed.Click += btnStavkaDodajRed_Click;
            btnStavkaSacuvaj.Click += btnStavkaSacuvaj_Click;

            btnKvalifikacijaKreiraj.Click += btnKvalifikacijaKreiraj_Click;
            btnDodeliKvalifikaciju.Click += btnDodeliKvalifikaciju_Click;

            lstRadnikRezultati.SelectedIndexChanged += lstRadnikRezultati_SelectedIndexChanged;
            lstOsobaRezultati.SelectedIndexChanged += lstOsobaRezultati_SelectedIndexChanged;
            lstTrenerRezultati.SelectedIndexChanged += lstTrenerRezultati_SelectedIndexChanged;
        }

        // ---------- Validacione pomocne metode ----------

        /// <summary>Prikazuje upozorenje da je polje obavezno i vraca fokus na njega.</summary>
        private bool ProveriObavezno(TextBox tb, string nazivPolja)
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show($"Polje '{nazivPolja}' je obavezno.", "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
                return false;
            }
            return true;
        }

        /// <summary>Proverava da tekst u polju predstavlja ispravan ceo broj.</summary>
        private bool ProveriCeoBroj(TextBox tb, string nazivPolja, out int vrednost)
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show($"Polje '{nazivPolja}' je obavezno.", "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
                vrednost = 0;
                return false;
            }
            if (!int.TryParse(tb.Text, out vrednost))
            {
                MessageBox.Show($"Polje '{nazivPolja}' mora biti ceo broj.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
                return false;
            }
            return true;
        }

        /// <summary>Proverava da tekst u polju predstavlja ispravan decimalni broj.</summary>
        private bool ProveriDecimalniBroj(TextBox tb, string nazivPolja, out decimal vrednost)
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show($"Polje '{nazivPolja}' je obavezno.", "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
                vrednost = 0;
                return false;
            }
            if (!decimal.TryParse(tb.Text, out vrednost))
            {
                MessageBox.Show($"Polje '{nazivPolja}' mora biti broj (npr. 100.50).", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb.Focus();
                return false;
            }
            return true;
        }

        /// <summary>Proverava da je korisnik prijavljen pre operacija koje zahtevaju prijavljenog radnika.</summary>
        private bool ProveriPrijavu()
        {
            if (Komunikacija.Instance.PrijavljeniRadnik == null)
            {
                MessageBox.Show("Morate prvo da se prijavite.", "Niste prijavljeni", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ---------- Ciscenje polja posle uspesne akcije ----------

        private void OcistiPoljaOsobe()
        {
            txtOsobaID.Clear();
            cmbOsobaKategorija.SelectedIndex = -1;
            txtOsobaIme.Clear();
            txtOsobaPrezime.Clear();
            txtOsobaJMBG.Clear();
            txtOsobaEmail.Clear();
            txtOsobaAdresa.Clear();
            txtOsobaTelefon.Clear();
            dtpOsobaDatumRodjenja.Value = DateTime.Today;
        }

        private void OcistiPoljaRadnika()
        {
            txtRadnikID.Clear();
            txtRadnikIme.Clear();
            txtRadnikPrezime.Clear();
            txtRadnikSifra.Clear();
            txtRadnikEmail.Clear();
            txtRadnikTelefon.Clear();
        }

        private void OcistiPoljaTrenera()
        {
            txtTrenerID.Clear();
            txtTrenerIme.Clear();
            txtTrenerPrezime.Clear();
            txtTrenerSpecijalnost.Clear();
            txtTrenerTelefon.Clear();
            txtTrenerEmail.Clear();
            txtTrenerGodineIskustva.Clear();
            chkTrenerAktivan.Checked = false;
        }

        // ---------- Prijava ----------

        private void btnPrijava_Click(object? sender, EventArgs e)
        {
            if (!ProveriObavezno(txtEmail, "Email") || !ProveriObavezno(txtSifra, "Šifra"))
            {
                return;
            }

            try
            {
                Radnik radnik = new Radnik
                {
                    Ime = "",
                    Prezime = "",
                    Sifra = txtSifra.Text,
                    Email = txtEmail.Text,
                    BrojTelefona = ""
                };
                Radnik prijavljeni = Komunikacija.Instance.Prijava(radnik);
                lblStatusPrijave.Text = $"Prijavljen: {prijavljeni.Ime} {prijavljeni.Prezime}";

                // ucitavamo sifarnike koji trebaju drugim tabovima tek nakon uspesne prijave
                UcitajTrenereUGrid();
                UcitajKvalifikacije();
                UcitajKategorije();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Radnik ----------

        private void btnRadnikKreiraj_Click(object? sender, EventArgs e)
        {
            if (!ProveriObavezno(txtRadnikIme, "Ime") ||
                !ProveriObavezno(txtRadnikPrezime, "Prezime") ||
                !ProveriObavezno(txtRadnikSifra, "Šifra") ||
                !ProveriObavezno(txtRadnikEmail, "Email") ||
                !ProveriObavezno(txtRadnikTelefon, "Broj telefona"))
            {
                return;
            }

            try
            {
                Radnik radnik = new Radnik
                {
                    Ime = txtRadnikIme.Text,
                    Prezime = txtRadnikPrezime.Text,
                    Sifra = txtRadnikSifra.Text,
                    Email = txtRadnikEmail.Text,
                    BrojTelefona = txtRadnikTelefon.Text
                };
                Komunikacija.Instance.KreirajRadnika(radnik);
                MessageBox.Show("Radnik kreiran.");
                OcistiPoljaRadnika();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRadnikPromeni_Click(object? sender, EventArgs e)
        {
            if (!ProveriCeoBroj(txtRadnikID, "ID radnika", out int radnikID) ||
                !ProveriObavezno(txtRadnikIme, "Ime") ||
                !ProveriObavezno(txtRadnikPrezime, "Prezime") ||
                !ProveriObavezno(txtRadnikSifra, "Šifra") ||
                !ProveriObavezno(txtRadnikEmail, "Email") ||
                !ProveriObavezno(txtRadnikTelefon, "Broj telefona"))
            {
                return;
            }

            try
            {
                Radnik radnik = new Radnik
                {
                    RadnikID = radnikID,
                    Ime = txtRadnikIme.Text,
                    Prezime = txtRadnikPrezime.Text,
                    Sifra = txtRadnikSifra.Text,
                    Email = txtRadnikEmail.Text,
                    BrojTelefona = txtRadnikTelefon.Text
                };
                Komunikacija.Instance.PromeniRadnika(radnik);
                MessageBox.Show("Radnik izmenjen.");
                OcistiPoljaRadnika();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRadnikDeaktiviraj_Click(object? sender, EventArgs e)
        {
            if (!ProveriCeoBroj(txtRadnikID, "ID radnika", out int radnikID))
            {
                return;
            }

            try
            {
                Komunikacija.Instance.DeaktivirajRadnika(radnikID);
                MessageBox.Show("Radnik deaktiviran.");
                OcistiPoljaRadnika();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRadnikPretrazi_Click(object? sender, EventArgs e)
        {
            try
            {
                List<Radnik> rezultati = Komunikacija.Instance.PretraziRadnika(txtRadnikPretraga.Text);
                poslednjiRezultatiRadnika = rezultati;

                lstRadnikRezultati.Items.Clear();
                foreach (Radnik r in rezultati)
                {
                    lstRadnikRezultati.Items.Add($"{r.RadnikID} - {r.Ime} {r.Prezime} ({r.Email})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Osoba ----------

        private void btnOsobaKreiraj_Click(object? sender, EventArgs e)
        {
            if (cmbOsobaKategorija.SelectedValue == null)
            {
                MessageBox.Show("Morate izabrati kategoriju.", "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ProveriObavezno(txtOsobaIme, "Ime") ||
                !ProveriObavezno(txtOsobaPrezime, "Prezime") ||
                !ProveriObavezno(txtOsobaJMBG, "JMBG") ||
                !ProveriObavezno(txtOsobaEmail, "Email") ||
                !ProveriObavezno(txtOsobaAdresa, "Adresa") ||
                !ProveriObavezno(txtOsobaTelefon, "Broj telefona"))
            {
                return;
            }

            try
            {
                Osoba osoba = new Osoba
                {
                    KategorijaID = (int)cmbOsobaKategorija.SelectedValue,
                    Ime = txtOsobaIme.Text,
                    Prezime = txtOsobaPrezime.Text,
                    JMBG = txtOsobaJMBG.Text,
                    DatumRodjenja = dtpOsobaDatumRodjenja.Value,
                    Email = txtOsobaEmail.Text,
                    Adresa = txtOsobaAdresa.Text,
                    BrojTelefona = txtOsobaTelefon.Text
                };
                Komunikacija.Instance.KreirajOsobu(osoba);
                MessageBox.Show("Osoba kreirana.");
                OcistiPoljaOsobe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>Puni ComboBox za izbor kategorije osobe listom svih kategorija.</summary>
        private void UcitajKategorije()
        {
            List<Kategorija> kategorije = Komunikacija.Instance.VratiSveKategorije();

            cmbOsobaKategorija.DataSource = kategorije;
            cmbOsobaKategorija.DisplayMember = "Naziv";
            cmbOsobaKategorija.ValueMember = "KategorijaID";
        }

        private void btnOsobaPromeni_Click(object? sender, EventArgs e)
        {
            if (!ProveriCeoBroj(txtOsobaID, "ID osobe", out int osobaID))
            {
                return;
            }

            if (cmbOsobaKategorija.SelectedValue == null)
            {
                MessageBox.Show("Morate izabrati kategoriju.", "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ProveriObavezno(txtOsobaIme, "Ime") ||
                !ProveriObavezno(txtOsobaPrezime, "Prezime") ||
                !ProveriObavezno(txtOsobaJMBG, "JMBG") ||
                !ProveriObavezno(txtOsobaEmail, "Email") ||
                !ProveriObavezno(txtOsobaAdresa, "Adresa") ||
                !ProveriObavezno(txtOsobaTelefon, "Broj telefona"))
            {
                return;
            }

            try
            {
                Osoba osoba = new Osoba
                {
                    OsobaID = osobaID,
                    KategorijaID = (int)cmbOsobaKategorija.SelectedValue,
                    Ime = txtOsobaIme.Text,
                    Prezime = txtOsobaPrezime.Text,
                    JMBG = txtOsobaJMBG.Text,
                    DatumRodjenja = dtpOsobaDatumRodjenja.Value,
                    Email = txtOsobaEmail.Text,
                    Adresa = txtOsobaAdresa.Text,
                    BrojTelefona = txtOsobaTelefon.Text
                };
                Komunikacija.Instance.PromeniOsobu(osoba);
                MessageBox.Show("Osoba izmenjena.");
                OcistiPoljaOsobe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOsobaObrisi_Click(object? sender, EventArgs e)
        {
            if (!ProveriCeoBroj(txtOsobaID, "ID osobe", out int osobaID))
            {
                return;
            }

            try
            {
                Komunikacija.Instance.ObrisiOsobu(osobaID);
                MessageBox.Show("Osoba obrisana.");
                OcistiPoljaOsobe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOsobaPretrazi_Click(object? sender, EventArgs e)
        {
            try
            {
                List<Osoba> rezultati = Komunikacija.Instance.PretraziOsobu(txtOsobaPretraga.Text);
                poslednjiRezultatiOsoba = rezultati;

                lstOsobaRezultati.Items.Clear();
                foreach (Osoba o in rezultati)
                {
                    lstOsobaRezultati.Items.Add($"{o.OsobaID} - {o.Ime} {o.Prezime} (JMBG: {o.JMBG})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Trener ----------

        private void btnTrenerKreiraj_Click(object? sender, EventArgs e)
        {
            if (!ProveriObavezno(txtTrenerIme, "Ime") ||
                !ProveriObavezno(txtTrenerPrezime, "Prezime") ||
                !ProveriObavezno(txtTrenerSpecijalnost, "Specijalnost") ||
                !ProveriObavezno(txtTrenerTelefon, "Broj telefona") ||
                !ProveriObavezno(txtTrenerEmail, "Email") ||
                !ProveriCeoBroj(txtTrenerGodineIskustva, "Godine iskustva", out int godineIskustva))
            {
                return;
            }

            try
            {
                Trener trener = new Trener
                {
                    Ime = txtTrenerIme.Text,
                    Prezime = txtTrenerPrezime.Text,
                    Specijalnost = txtTrenerSpecijalnost.Text,
                    BrojTelefona = txtTrenerTelefon.Text,
                    Email = txtTrenerEmail.Text,
                    GodineIskustva = godineIskustva,
                    Aktivan = chkTrenerAktivan.Checked
                };
                Komunikacija.Instance.KreirajTrenera(trener);
                MessageBox.Show("Trener kreiran.");
                OcistiPoljaTrenera();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrenerPromeni_Click(object? sender, EventArgs e)
        {
            if (!ProveriCeoBroj(txtTrenerID, "ID trenera", out int trenerID) ||
                !ProveriObavezno(txtTrenerIme, "Ime") ||
                !ProveriObavezno(txtTrenerPrezime, "Prezime") ||
                !ProveriObavezno(txtTrenerSpecijalnost, "Specijalnost") ||
                !ProveriObavezno(txtTrenerTelefon, "Broj telefona") ||
                !ProveriObavezno(txtTrenerEmail, "Email") ||
                !ProveriCeoBroj(txtTrenerGodineIskustva, "Godine iskustva", out int godineIskustva))
            {
                return;
            }

            try
            {
                Trener trener = new Trener
                {
                    TrenerID = trenerID,
                    Ime = txtTrenerIme.Text,
                    Prezime = txtTrenerPrezime.Text,
                    Specijalnost = txtTrenerSpecijalnost.Text,
                    BrojTelefona = txtTrenerTelefon.Text,
                    Email = txtTrenerEmail.Text,
                    GodineIskustva = godineIskustva,
                    Aktivan = chkTrenerAktivan.Checked
                };
                Komunikacija.Instance.PromeniTrenera(trener);
                MessageBox.Show("Trener izmenjen.");
                OcistiPoljaTrenera();

                // osvezi listu aktivnih trenera u grid-u za stavke (moglo se promeniti Aktivan)
                UcitajTrenereUGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrenerPrikaziAktivne_Click(object? sender, EventArgs e)
        {
            try
            {
                List<Trener> rezultati = Komunikacija.Instance.VratiSveAktivneTrenere();
                poslednjiRezultatiTrenera = rezultati;

                lstTrenerRezultati.Items.Clear();
                foreach (Trener t in rezultati)
                {
                    lstTrenerRezultati.Items.Add($"{t.TrenerID} - {t.Ime} {t.Prezime} ({t.Specijalnost})");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Clanstvo ----------

        private void btnClanstvoKreiraj_Click(object? sender, EventArgs e)
        {
            if (!ProveriPrijavu())
            {
                return;
            }

            if (!ProveriCeoBroj(txtClanstvoOsobaID, "ID osobe", out int osobaID) ||
                !ProveriDecimalniBroj(txtClanstvoCena, "Cena", out decimal cena))
            {
                return;
            }

            if (dtpClanstvoDatumIsteka.Value <= dtpClanstvoDatumPocetka.Value)
            {
                MessageBox.Show("Datum isteka mora biti posle datuma početka.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Članstvo clanstvo = new Članstvo
                {
                    OsobaID = osobaID,
                    RadnikID = Komunikacija.Instance.PrijavljeniRadnik!.RadnikID,
                    DatumPočetka = dtpClanstvoDatumPocetka.Value,
                    DatumIsteka = dtpClanstvoDatumIsteka.Value,
                    Cena = cena
                };
                Komunikacija.Instance.KreirajClanstvo(clanstvo);
                MessageBox.Show("Članstvo kreirano.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClanstvoPronadjiAktivno_Click(object? sender, EventArgs e)
        {
            if (!ProveriCeoBroj(txtClanstvoOsobaIDPretraga, "ID osobe", out int osobaID))
            {
                return;
            }

            try
            {
                Članstvo clanstvo = Komunikacija.Instance.VratiAktivnoClanstvoOsobe(osobaID);
                txtClanstvoIDPronađeno.Text = clanstvo.ČlanstvoID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClanstvoOtkazi_Click(object? sender, EventArgs e)
        {
            if (!ProveriCeoBroj(txtClanstvoIDPronađeno, "ID članstva (prvo pronađi aktivno članstvo)", out int clanstvoID))
            {
                return;
            }

            try
            {
                Komunikacija.Instance.OtkaziClanstvo(clanstvoID);
                MessageBox.Show("Članstvo otkazano.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClanstvoIzracunajCenu_Click(object? sender, EventArgs e)
        {
            if (!ProveriCeoBroj(txtClanstvoIDPronađeno, "ID članstva (prvo pronađi aktivno članstvo)", out int clanstvoID))
            {
                return;
            }

            try
            {
                decimal cena = Komunikacija.Instance.IzracunajUkupnuCenuClanstva(clanstvoID);
                lblClanstvoUkupnaCena.Text = $"Ukupna članarina: {cena}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStavkaDodajRed_Click(object? sender, EventArgs e)
        {
            dgvStavke.Rows.Add();
        }

        private void btnStavkaSacuvaj_Click(object? sender, EventArgs e)
        {
            if (!ProveriCeoBroj(txtStavkaClanstvoID, "ID članstva", out int clanstvoID))
            {
                return;
            }

            // prvi prolaz: validacija svih redova pre slanja - da ne posaljemo deo pa pukne na pola
            List<StavkaČlanstva> zaSlanje = new();

            for (int red = 0; red < dgvStavke.Rows.Count; red++)
            {
                DataGridViewRow r = dgvStavke.Rows[red];

                // prazan/nekorišćen red (nije izabran trener) se preskače
                if (r.Cells["colTrener"].Value == null)
                {
                    continue;
                }

                int brojReda = red + 1;

                if (r.Cells["colVrstaTreninga"].Value == null ||
                    !Enum.TryParse<VrstaTreninga>((string)r.Cells["colVrstaTreninga"].Value, out VrstaTreninga vrsta))
                {
                    MessageBox.Show($"Red {brojReda}: izaberite ispravnu vrstu treninga.", "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (r.Cells["colBrojTermina"].Value == null ||
                    !int.TryParse(r.Cells["colBrojTermina"].Value.ToString(), out int brojTermina))
                {
                    MessageBox.Show($"Red {brojReda}: broj termina mora biti ceo broj.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (r.Cells["colCenaStavke"].Value == null ||
                    !decimal.TryParse(r.Cells["colCenaStavke"].Value.ToString(), out decimal cenaStavke))
                {
                    MessageBox.Show($"Red {brojReda}: cena stavke mora biti broj.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                zaSlanje.Add(new StavkaČlanstva
                {
                    ČlanstvoID = clanstvoID,
                    TrenerID = (int)r.Cells["colTrener"].Value,
                    VrstaTreninga = vrsta,
                    BrojTermina = brojTermina,
                    CenaStavke = cenaStavke
                });
            }

            if (zaSlanje.Count == 0)
            {
                MessageBox.Show("Nema popunjenih redova za čuvanje.", "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                foreach (StavkaČlanstva stavka in zaSlanje)
                {
                    Komunikacija.Instance.DodajStavkuClanstva(stavka);
                }

                MessageBox.Show("Stavke sačuvane.");
                dgvStavke.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Kvalifikacija ----------

        private void btnKvalifikacijaKreiraj_Click(object? sender, EventArgs e)
        {
            if (!ProveriObavezno(txtKvalifikacijaNaziv, "Naziv"))
            {
                return;
            }

            if (cmbKvalifikacijaNivo.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati nivo kvalifikacije.", "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Kvalifikacija kvalifikacija = new Kvalifikacija
                {
                    Naziv = txtKvalifikacijaNaziv.Text,
                    Nivo = Enum.Parse<Nivo>(cmbKvalifikacijaNivo.SelectedItem.ToString()!)
                };
                Komunikacija.Instance.KreirajKvalifikaciju(kvalifikacija);
                MessageBox.Show("Kvalifikacija sačuvana.");

                // osvezi listu kvalifikacija za dodelu
                UcitajKvalifikacije();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDodeliKvalifikaciju_Click(object? sender, EventArgs e)
        {
            if (!ProveriPrijavu())
            {
                return;
            }

            if (cmbKvalifikacijaIzbor.SelectedItem == null)
            {
                MessageBox.Show("Morate izabrati kvalifikaciju.", "Nepotpuni podaci", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpDodelaDatumIsteka.Checked && dtpDodelaDatumIsteka.Value <= dtpDodelaDatumSticanja.Value)
            {
                MessageBox.Show("Datum isteka mora biti posle datuma sticanja.", "Neispravan unos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Kvalifikacija izabrana = (Kvalifikacija)cmbKvalifikacijaIzbor.SelectedItem;
                RadnikKvalifikacija rk = new RadnikKvalifikacija
                {
                    RadnikID = Komunikacija.Instance.PrijavljeniRadnik!.RadnikID,
                    KvalifikacijaID = izabrana.KvalifikacijaID,
                    DatumSticanja = dtpDodelaDatumSticanja.Value,
                    DatumIsteka = dtpDodelaDatumIsteka.Checked ? dtpDodelaDatumIsteka.Value : (DateTime?)null
                };
                Komunikacija.Instance.DodeliKvalifikacijuRadniku(rk);
                MessageBox.Show("Kvalifikacija dodeljena.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Pomocne metode za punjenje listi ----------

        /// <summary>Puni ComboBox kolonu trenera u gridu stavki listom aktivnih trenera.</summary>
        private void UcitajTrenereUGrid()
        {
            List<Trener> treneri = Komunikacija.Instance.VratiSveAktivneTrenere();
            var izvor = treneri.Select(t => new { t.TrenerID, Prikaz = $"{t.Ime} {t.Prezime}" }).ToList();

            colTrener.DataSource = izvor;
            colTrener.DisplayMember = "Prikaz";
            colTrener.ValueMember = "TrenerID";
        }

        /// <summary>Puni ComboBox za izbor kvalifikacije listom svih kvalifikacija.</summary>
        private void UcitajKvalifikacije()
        {
            List<Kvalifikacija> kvalifikacije = Komunikacija.Instance.VratiSveKvalifikacije();

            cmbKvalifikacijaIzbor.DataSource = kvalifikacije;
            cmbKvalifikacijaIzbor.DisplayMember = "Naziv";
            cmbKvalifikacijaIzbor.ValueMember = "KvalifikacijaID";
        }

        // ---------- Popunjavanje polja za izmenu iz izabranog rezultata pretrage ----------

        private void lstRadnikRezultati_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int i = lstRadnikRezultati.SelectedIndex;
            if (i < 0 || i >= poslednjiRezultatiRadnika.Count)
            {
                return;
            }

            Radnik r = poslednjiRezultatiRadnika[i];
            txtRadnikID.Text = r.RadnikID.ToString();
            txtRadnikIme.Text = r.Ime;
            txtRadnikPrezime.Text = r.Prezime;
            txtRadnikSifra.Text = r.Sifra;
            txtRadnikEmail.Text = r.Email;
            txtRadnikTelefon.Text = r.BrojTelefona;
        }

        private void lstOsobaRezultati_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int i = lstOsobaRezultati.SelectedIndex;
            if (i < 0 || i >= poslednjiRezultatiOsoba.Count)
            {
                return;
            }

            Osoba o = poslednjiRezultatiOsoba[i];
            txtOsobaID.Text = o.OsobaID.ToString();
            cmbOsobaKategorija.SelectedValue = o.KategorijaID;
            txtOsobaIme.Text = o.Ime;
            txtOsobaPrezime.Text = o.Prezime;
            txtOsobaJMBG.Text = o.JMBG;
            dtpOsobaDatumRodjenja.Value = o.DatumRodjenja;
            txtOsobaEmail.Text = o.Email;
            txtOsobaAdresa.Text = o.Adresa;
            txtOsobaTelefon.Text = o.BrojTelefona;
        }

        private void lstTrenerRezultati_SelectedIndexChanged(object? sender, EventArgs e)
        {
            int i = lstTrenerRezultati.SelectedIndex;
            if (i < 0 || i >= poslednjiRezultatiTrenera.Count)
            {
                return;
            }

            Trener t = poslednjiRezultatiTrenera[i];
            txtTrenerID.Text = t.TrenerID.ToString();
            txtTrenerIme.Text = t.Ime;
            txtTrenerPrezime.Text = t.Prezime;
            txtTrenerSpecijalnost.Text = t.Specijalnost;
            txtTrenerTelefon.Text = t.BrojTelefona;
            txtTrenerEmail.Text = t.Email;
            txtTrenerGodineIskustva.Text = t.GodineIskustva.ToString();
            chkTrenerAktivan.Checked = t.Aktivan;
        }
    }
}