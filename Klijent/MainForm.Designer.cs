namespace Klijent
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPrijava = new TabPage();
            lblStatusPrijave = new Label();
            btnPrijava = new Button();
            txtSifra = new TextBox();
            txtEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            tabRadnik = new TabPage();
            boxPretraga = new GroupBox();
            lstRadnikRezultati = new ListBox();
            txtRadnikPretraga = new TextBox();
            label8 = new Label();
            btnRadnikPretrazi = new Button();
            boxUnosIzmena = new GroupBox();
            txtRadnikPrezime = new TextBox();
            btnRadnikDeaktiviraj = new Button();
            label3 = new Label();
            btnRadnikPromeni = new Button();
            txtRadnikID = new TextBox();
            btnRadnikKreiraj = new Button();
            Ime = new Label();
            txtRadnikTelefon = new TextBox();
            label4 = new Label();
            txtRadnikSifra = new TextBox();
            label5 = new Label();
            txtRadnikEmail = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txtRadnikIme = new TextBox();
            tabOsoba = new TabPage();
            groupBox2 = new GroupBox();
            lstOsobaRezultati = new ListBox();
            txtOsobaPretraga = new TextBox();
            label18 = new Label();
            btnOsobaPretrazi = new Button();
            groupBox1 = new GroupBox();
            cmbOsobaKategorija = new ComboBox();
            label17 = new Label();
            label16 = new Label();
            dtpOsobaDatumRodjenja = new DateTimePicker();
            txtOsobaAdresa = new TextBox();
            label15 = new Label();
            txtOsobaPrezime = new TextBox();
            btnOsobaObrisi = new Button();
            label9 = new Label();
            btnOsobaPromeni = new Button();
            txtOsobaID = new TextBox();
            btnOsobaKreiraj = new Button();
            label10 = new Label();
            txtOsobaTelefon = new TextBox();
            label11 = new Label();
            txtOsobaJMBG = new TextBox();
            label12 = new Label();
            txtOsobaEmail = new TextBox();
            label13 = new Label();
            label14 = new Label();
            txtOsobaIme = new TextBox();
            tabTrener = new TabPage();
            groupBox4 = new GroupBox();
            lstTrenerRezultati = new ListBox();
            btnTrenerPrikaziAktivne = new Button();
            groupBox3 = new GroupBox();
            btnTrenerPromeni = new Button();
            chkTrenerAktivan = new CheckBox();
            txtTrenerTelefon = new TextBox();
            label25 = new Label();
            txtTrenerPrezime = new TextBox();
            label19 = new Label();
            txtTrenerID = new TextBox();
            btnTrenerKreiraj = new Button();
            label20 = new Label();
            txtTrenerGodineIskustva = new TextBox();
            label21 = new Label();
            txtTrenerSpecijalnost = new TextBox();
            label22 = new Label();
            txtTrenerEmail = new TextBox();
            label23 = new Label();
            label24 = new Label();
            txtTrenerIme = new TextBox();
            tabClanstvo = new TabPage();
            groupBox7 = new GroupBox();
            btnStavkaSacuvaj = new Button();
            btnStavkaDodajRed = new Button();
            dgvStavke = new DataGridView();
            colTrener = new DataGridViewComboBoxColumn();
            colVrstaTreninga = new DataGridViewComboBoxColumn();
            colBrojTermina = new DataGridViewTextBoxColumn();
            colCenaStavke = new DataGridViewTextBoxColumn();
            txtStavkaClanstvoID = new TextBox();
            label33 = new Label();
            groupBox6 = new GroupBox();
            lblClanstvoUkupnaCena = new Label();
            btnClanstvoIzracunajCenu = new Button();
            btnClanstvoOtkazi = new Button();
            txtClanstvoIDPronađeno = new TextBox();
            label32 = new Label();
            btnClanstvoPronadjiAktivno = new Button();
            txtClanstvoOsobaIDPretraga = new TextBox();
            label31 = new Label();
            groupBox5 = new GroupBox();
            dtpClanstvoDatumIsteka = new DateTimePicker();
            dtpClanstvoDatumPocetka = new DateTimePicker();
            txtClanstvoCena = new TextBox();
            label26 = new Label();
            label27 = new Label();
            btnClanstvoKreiraj = new Button();
            txtClanstvoOsobaID = new TextBox();
            label29 = new Label();
            label30 = new Label();
            tabKvalifikacija = new TabPage();
            groupBox9 = new GroupBox();
            btnKvalifikacijaKreiraj = new Button();
            txtKvalifikacijaNaziv = new TextBox();
            label39 = new Label();
            cmbKvalifikacijaNivo = new ComboBox();
            label38 = new Label();
            groupBox8 = new GroupBox();
            btnDodeliKvalifikaciju = new Button();
            dtpDodelaDatumIsteka = new DateTimePicker();
            dtpDodelaDatumSticanja = new DateTimePicker();
            cmbKvalifikacijaIzbor = new ComboBox();
            label40 = new Label();
            label37 = new Label();
            label36 = new Label();
            tabControl1.SuspendLayout();
            tabPrijava.SuspendLayout();
            tabRadnik.SuspendLayout();
            boxPretraga.SuspendLayout();
            boxUnosIzmena.SuspendLayout();
            tabOsoba.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabTrener.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            tabClanstvo.SuspendLayout();
            groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            tabKvalifikacija.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPrijava);
            tabControl1.Controls.Add(tabRadnik);
            tabControl1.Controls.Add(tabOsoba);
            tabControl1.Controls.Add(tabTrener);
            tabControl1.Controls.Add(tabClanstvo);
            tabControl1.Controls.Add(tabKvalifikacija);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabPrijava
            // 
            tabPrijava.Controls.Add(lblStatusPrijave);
            tabPrijava.Controls.Add(btnPrijava);
            tabPrijava.Controls.Add(txtSifra);
            tabPrijava.Controls.Add(txtEmail);
            tabPrijava.Controls.Add(label2);
            tabPrijava.Controls.Add(label1);
            tabPrijava.Location = new Point(4, 29);
            tabPrijava.Name = "tabPrijava";
            tabPrijava.Padding = new Padding(3);
            tabPrijava.Size = new Size(792, 417);
            tabPrijava.TabIndex = 0;
            tabPrijava.Text = "Prijava";
            tabPrijava.UseVisualStyleBackColor = true;
            // 
            // lblStatusPrijave
            // 
            lblStatusPrijave.AutoSize = true;
            lblStatusPrijave.Location = new Point(146, 118);
            lblStatusPrijave.Name = "lblStatusPrijave";
            lblStatusPrijave.Size = new Size(0, 20);
            lblStatusPrijave.TabIndex = 5;
            // 
            // btnPrijava
            // 
            btnPrijava.Location = new Point(24, 114);
            btnPrijava.Name = "btnPrijava";
            btnPrijava.Size = new Size(94, 29);
            btnPrijava.TabIndex = 4;
            btnPrijava.Text = "Prijava";
            btnPrijava.UseVisualStyleBackColor = true;
            // 
            // txtSifra
            // 
            txtSifra.Location = new Point(88, 62);
            txtSifra.Name = "txtSifra";
            txtSifra.PasswordChar = '*';
            txtSifra.Size = new Size(207, 27);
            txtSifra.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(88, 19);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(207, 27);
            txtEmail.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 65);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 1;
            label2.Text = "Šifra:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 22);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 0;
            label1.Text = "Email:";
            // 
            // tabRadnik
            // 
            tabRadnik.Controls.Add(boxPretraga);
            tabRadnik.Controls.Add(boxUnosIzmena);
            tabRadnik.Location = new Point(4, 29);
            tabRadnik.Name = "tabRadnik";
            tabRadnik.Padding = new Padding(3);
            tabRadnik.Size = new Size(792, 417);
            tabRadnik.TabIndex = 1;
            tabRadnik.Text = "Radnik";
            tabRadnik.UseVisualStyleBackColor = true;
            // 
            // boxPretraga
            // 
            boxPretraga.Controls.Add(lstRadnikRezultati);
            boxPretraga.Controls.Add(txtRadnikPretraga);
            boxPretraga.Controls.Add(label8);
            boxPretraga.Controls.Add(btnRadnikPretrazi);
            boxPretraga.Location = new Point(309, 6);
            boxPretraga.Name = "boxPretraga";
            boxPretraga.Size = new Size(475, 403);
            boxPretraga.TabIndex = 16;
            boxPretraga.TabStop = false;
            boxPretraga.Text = "Pretraga Radnika";
            // 
            // lstRadnikRezultati
            // 
            lstRadnikRezultati.FormattingEnabled = true;
            lstRadnikRezultati.Location = new Point(18, 100);
            lstRadnikRezultati.Name = "lstRadnikRezultati";
            lstRadnikRezultati.Size = new Size(439, 284);
            lstRadnikRezultati.TabIndex = 3;
            // 
            // txtRadnikPretraga
            // 
            txtRadnikPretraga.Location = new Point(121, 26);
            txtRadnikPretraga.Name = "txtRadnikPretraga";
            txtRadnikPretraga.Size = new Size(125, 27);
            txtRadnikPretraga.TabIndex = 2;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 29);
            label8.Name = "label8";
            label8.Size = new Size(96, 20);
            label8.TabIndex = 1;
            label8.Text = "Ime/Prezime:";
            // 
            // btnRadnikPretrazi
            // 
            btnRadnikPretrazi.Location = new Point(18, 62);
            btnRadnikPretrazi.Name = "btnRadnikPretrazi";
            btnRadnikPretrazi.Size = new Size(228, 29);
            btnRadnikPretrazi.TabIndex = 0;
            btnRadnikPretrazi.Text = "Pretraži";
            btnRadnikPretrazi.UseVisualStyleBackColor = true;
            // 
            // boxUnosIzmena
            // 
            boxUnosIzmena.Controls.Add(txtRadnikPrezime);
            boxUnosIzmena.Controls.Add(btnRadnikDeaktiviraj);
            boxUnosIzmena.Controls.Add(label3);
            boxUnosIzmena.Controls.Add(btnRadnikPromeni);
            boxUnosIzmena.Controls.Add(txtRadnikID);
            boxUnosIzmena.Controls.Add(btnRadnikKreiraj);
            boxUnosIzmena.Controls.Add(Ime);
            boxUnosIzmena.Controls.Add(txtRadnikTelefon);
            boxUnosIzmena.Controls.Add(label4);
            boxUnosIzmena.Controls.Add(txtRadnikSifra);
            boxUnosIzmena.Controls.Add(label5);
            boxUnosIzmena.Controls.Add(txtRadnikEmail);
            boxUnosIzmena.Controls.Add(label6);
            boxUnosIzmena.Controls.Add(label7);
            boxUnosIzmena.Controls.Add(txtRadnikIme);
            boxUnosIzmena.Location = new Point(8, 6);
            boxUnosIzmena.Name = "boxUnosIzmena";
            boxUnosIzmena.Size = new Size(295, 403);
            boxUnosIzmena.TabIndex = 15;
            boxUnosIzmena.TabStop = false;
            boxUnosIzmena.Text = "Unos/Izmena Radnika";
            // 
            // txtRadnikPrezime
            // 
            txtRadnikPrezime.Location = new Point(109, 89);
            txtRadnikPrezime.Name = "txtRadnikPrezime";
            txtRadnikPrezime.Size = new Size(125, 27);
            txtRadnikPrezime.TabIndex = 8;
            // 
            // btnRadnikDeaktiviraj
            // 
            btnRadnikDeaktiviraj.Location = new Point(19, 290);
            btnRadnikDeaktiviraj.Name = "btnRadnikDeaktiviraj";
            btnRadnikDeaktiviraj.Size = new Size(215, 29);
            btnRadnikDeaktiviraj.TabIndex = 14;
            btnRadnikDeaktiviraj.Text = "Deaktiviraj radnika";
            btnRadnikDeaktiviraj.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 29);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 0;
            label3.Text = "ID Radnika:";
            // 
            // btnRadnikPromeni
            // 
            btnRadnikPromeni.Location = new Point(19, 255);
            btnRadnikPromeni.Name = "btnRadnikPromeni";
            btnRadnikPromeni.Size = new Size(215, 29);
            btnRadnikPromeni.TabIndex = 13;
            btnRadnikPromeni.Text = "Promeni radnika";
            btnRadnikPromeni.UseVisualStyleBackColor = true;
            // 
            // txtRadnikID
            // 
            txtRadnikID.Location = new Point(109, 26);
            txtRadnikID.Name = "txtRadnikID";
            txtRadnikID.Size = new Size(125, 27);
            txtRadnikID.TabIndex = 1;
            // 
            // btnRadnikKreiraj
            // 
            btnRadnikKreiraj.Location = new Point(19, 220);
            btnRadnikKreiraj.Name = "btnRadnikKreiraj";
            btnRadnikKreiraj.Size = new Size(215, 29);
            btnRadnikKreiraj.TabIndex = 12;
            btnRadnikKreiraj.Text = "Kreiraj radnika";
            btnRadnikKreiraj.UseVisualStyleBackColor = true;
            // 
            // Ime
            // 
            Ime.AutoSize = true;
            Ime.Location = new Point(19, 62);
            Ime.Name = "Ime";
            Ime.Size = new Size(37, 20);
            Ime.TabIndex = 2;
            Ime.Text = "Ime:";
            // 
            // txtRadnikTelefon
            // 
            txtRadnikTelefon.Location = new Point(109, 177);
            txtRadnikTelefon.Name = "txtRadnikTelefon";
            txtRadnikTelefon.Size = new Size(125, 27);
            txtRadnikTelefon.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 92);
            label4.Name = "label4";
            label4.Size = new Size(65, 20);
            label4.TabIndex = 3;
            label4.Text = "Prezime:";
            // 
            // txtRadnikSifra
            // 
            txtRadnikSifra.Location = new Point(109, 147);
            txtRadnikSifra.Name = "txtRadnikSifra";
            txtRadnikSifra.PasswordChar = '*';
            txtRadnikSifra.Size = new Size(125, 27);
            txtRadnikSifra.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 121);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 4;
            label5.Text = "Email:";
            // 
            // txtRadnikEmail
            // 
            txtRadnikEmail.Location = new Point(109, 118);
            txtRadnikEmail.Name = "txtRadnikEmail";
            txtRadnikEmail.Size = new Size(125, 27);
            txtRadnikEmail.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 150);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 5;
            label6.Text = "Šifra:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 180);
            label7.Name = "label7";
            label7.Size = new Size(61, 20);
            label7.TabIndex = 6;
            label7.Text = "Telefon:";
            // 
            // txtRadnikIme
            // 
            txtRadnikIme.Location = new Point(109, 59);
            txtRadnikIme.Name = "txtRadnikIme";
            txtRadnikIme.Size = new Size(125, 27);
            txtRadnikIme.TabIndex = 7;
            // 
            // tabOsoba
            // 
            tabOsoba.Controls.Add(groupBox2);
            tabOsoba.Controls.Add(groupBox1);
            tabOsoba.Location = new Point(4, 29);
            tabOsoba.Name = "tabOsoba";
            tabOsoba.Padding = new Padding(3);
            tabOsoba.Size = new Size(792, 417);
            tabOsoba.TabIndex = 2;
            tabOsoba.Text = "Osoba";
            tabOsoba.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstOsobaRezultati);
            groupBox2.Controls.Add(txtOsobaPretraga);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(btnOsobaPretrazi);
            groupBox2.Location = new Point(367, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(417, 411);
            groupBox2.TabIndex = 17;
            groupBox2.TabStop = false;
            groupBox2.Text = "Pretraga Osobe";
            // 
            // lstOsobaRezultati
            // 
            lstOsobaRezultati.FormattingEnabled = true;
            lstOsobaRezultati.Location = new Point(18, 100);
            lstOsobaRezultati.Name = "lstOsobaRezultati";
            lstOsobaRezultati.Size = new Size(439, 284);
            lstOsobaRezultati.TabIndex = 3;
            // 
            // txtOsobaPretraga
            // 
            txtOsobaPretraga.Location = new Point(121, 26);
            txtOsobaPretraga.Name = "txtOsobaPretraga";
            txtOsobaPretraga.Size = new Size(125, 27);
            txtOsobaPretraga.TabIndex = 2;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(18, 29);
            label18.Name = "label18";
            label18.Size = new Size(96, 20);
            label18.TabIndex = 1;
            label18.Text = "Ime/Prezime:";
            // 
            // btnOsobaPretrazi
            // 
            btnOsobaPretrazi.Location = new Point(18, 62);
            btnOsobaPretrazi.Name = "btnOsobaPretrazi";
            btnOsobaPretrazi.Size = new Size(228, 29);
            btnOsobaPretrazi.TabIndex = 0;
            btnOsobaPretrazi.Text = "Pretraži";
            btnOsobaPretrazi.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmbOsobaKategorija);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(dtpOsobaDatumRodjenja);
            groupBox1.Controls.Add(txtOsobaAdresa);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(txtOsobaPrezime);
            groupBox1.Controls.Add(btnOsobaObrisi);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(btnOsobaPromeni);
            groupBox1.Controls.Add(txtOsobaID);
            groupBox1.Controls.Add(btnOsobaKreiraj);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtOsobaTelefon);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtOsobaJMBG);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(txtOsobaEmail);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(txtOsobaIme);
            groupBox1.Location = new Point(-4, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(365, 411);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Unos/Izmena Osobe";
            // 
            // cmbOsobaKategorija
            // 
            cmbOsobaKategorija.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOsobaKategorija.FormattingEnabled = true;
            cmbOsobaKategorija.Location = new Point(109, 58);
            cmbOsobaKategorija.Name = "cmbOsobaKategorija";
            cmbOsobaKategorija.Size = new Size(250, 28);
            cmbOsobaKategorija.TabIndex = 20;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(19, 281);
            label17.Name = "label17";
            label17.Size = new Size(69, 20);
            label17.TabIndex = 19;
            label17.Text = "Rođen/а:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(19, 246);
            label16.Name = "label16";
            label16.Size = new Size(58, 20);
            label16.TabIndex = 18;
            label16.Text = "Adresa:";
            // 
            // dtpOsobaDatumRodjenja
            // 
            dtpOsobaDatumRodjenja.Location = new Point(109, 276);
            dtpOsobaDatumRodjenja.Name = "dtpOsobaDatumRodjenja";
            dtpOsobaDatumRodjenja.Size = new Size(250, 27);
            dtpOsobaDatumRodjenja.TabIndex = 17;
            // 
            // txtOsobaAdresa
            // 
            txtOsobaAdresa.Location = new Point(109, 243);
            txtOsobaAdresa.Name = "txtOsobaAdresa";
            txtOsobaAdresa.Size = new Size(250, 27);
            txtOsobaAdresa.TabIndex = 17;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(19, 59);
            label15.Name = "label15";
            label15.Size = new Size(81, 20);
            label15.TabIndex = 15;
            label15.Text = "Kategorija:";
            // 
            // txtOsobaPrezime
            // 
            txtOsobaPrezime.Location = new Point(109, 122);
            txtOsobaPrezime.Name = "txtOsobaPrezime";
            txtOsobaPrezime.Size = new Size(250, 27);
            txtOsobaPrezime.TabIndex = 8;
            // 
            // btnOsobaObrisi
            // 
            btnOsobaObrisi.Location = new Point(19, 380);
            btnOsobaObrisi.Name = "btnOsobaObrisi";
            btnOsobaObrisi.Size = new Size(215, 29);
            btnOsobaObrisi.TabIndex = 14;
            btnOsobaObrisi.Text = "Obriši osobu";
            btnOsobaObrisi.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(19, 29);
            label9.Name = "label9";
            label9.Size = new Size(74, 20);
            label9.TabIndex = 0;
            label9.Text = "ID Osobe:";
            // 
            // btnOsobaPromeni
            // 
            btnOsobaPromeni.Location = new Point(19, 345);
            btnOsobaPromeni.Name = "btnOsobaPromeni";
            btnOsobaPromeni.Size = new Size(215, 29);
            btnOsobaPromeni.TabIndex = 13;
            btnOsobaPromeni.Text = "Promeni osobu";
            btnOsobaPromeni.UseVisualStyleBackColor = true;
            // 
            // txtOsobaID
            // 
            txtOsobaID.Location = new Point(109, 26);
            txtOsobaID.Name = "txtOsobaID";
            txtOsobaID.Size = new Size(250, 27);
            txtOsobaID.TabIndex = 1;
            // 
            // btnOsobaKreiraj
            // 
            btnOsobaKreiraj.Location = new Point(19, 310);
            btnOsobaKreiraj.Name = "btnOsobaKreiraj";
            btnOsobaKreiraj.Size = new Size(215, 29);
            btnOsobaKreiraj.TabIndex = 12;
            btnOsobaKreiraj.Text = "Kreiraj osobu";
            btnOsobaKreiraj.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(19, 95);
            label10.Name = "label10";
            label10.Size = new Size(37, 20);
            label10.TabIndex = 2;
            label10.Text = "Ime:";
            // 
            // txtOsobaTelefon
            // 
            txtOsobaTelefon.Location = new Point(109, 210);
            txtOsobaTelefon.Name = "txtOsobaTelefon";
            txtOsobaTelefon.Size = new Size(250, 27);
            txtOsobaTelefon.TabIndex = 11;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(19, 125);
            label11.Name = "label11";
            label11.Size = new Size(65, 20);
            label11.TabIndex = 3;
            label11.Text = "Prezime:";
            // 
            // txtOsobaJMBG
            // 
            txtOsobaJMBG.Location = new Point(109, 180);
            txtOsobaJMBG.Name = "txtOsobaJMBG";
            txtOsobaJMBG.Size = new Size(250, 27);
            txtOsobaJMBG.TabIndex = 10;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(19, 154);
            label12.Name = "label12";
            label12.Size = new Size(49, 20);
            label12.TabIndex = 4;
            label12.Text = "Email:";
            // 
            // txtOsobaEmail
            // 
            txtOsobaEmail.Location = new Point(109, 151);
            txtOsobaEmail.Name = "txtOsobaEmail";
            txtOsobaEmail.Size = new Size(250, 27);
            txtOsobaEmail.TabIndex = 9;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(19, 183);
            label13.Name = "label13";
            label13.Size = new Size(49, 20);
            label13.TabIndex = 5;
            label13.Text = "JMBG:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(19, 213);
            label14.Name = "label14";
            label14.Size = new Size(61, 20);
            label14.TabIndex = 6;
            label14.Text = "Telefon:";
            // 
            // txtOsobaIme
            // 
            txtOsobaIme.Location = new Point(109, 92);
            txtOsobaIme.Name = "txtOsobaIme";
            txtOsobaIme.Size = new Size(250, 27);
            txtOsobaIme.TabIndex = 7;
            // 
            // tabTrener
            // 
            tabTrener.Controls.Add(groupBox4);
            tabTrener.Controls.Add(groupBox3);
            tabTrener.Location = new Point(4, 29);
            tabTrener.Name = "tabTrener";
            tabTrener.Padding = new Padding(3);
            tabTrener.Size = new Size(792, 417);
            tabTrener.TabIndex = 3;
            tabTrener.Text = "Trener";
            tabTrener.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lstTrenerRezultati);
            groupBox4.Controls.Add(btnTrenerPrikaziAktivne);
            groupBox4.Location = new Point(309, 8);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(475, 403);
            groupBox4.TabIndex = 18;
            groupBox4.TabStop = false;
            groupBox4.Text = "Lista trenera";
            // 
            // lstTrenerRezultati
            // 
            lstTrenerRezultati.FormattingEnabled = true;
            lstTrenerRezultati.Location = new Point(6, 61);
            lstTrenerRezultati.Name = "lstTrenerRezultati";
            lstTrenerRezultati.Size = new Size(451, 324);
            lstTrenerRezultati.TabIndex = 3;
            // 
            // btnTrenerPrikaziAktivne
            // 
            btnTrenerPrikaziAktivne.Location = new Point(6, 26);
            btnTrenerPrikaziAktivne.Name = "btnTrenerPrikaziAktivne";
            btnTrenerPrikaziAktivne.Size = new Size(228, 29);
            btnTrenerPrikaziAktivne.TabIndex = 0;
            btnTrenerPrikaziAktivne.Text = "Prikaži aktivne";
            btnTrenerPrikaziAktivne.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnTrenerPromeni);
            groupBox3.Controls.Add(chkTrenerAktivan);
            groupBox3.Controls.Add(txtTrenerTelefon);
            groupBox3.Controls.Add(label25);
            groupBox3.Controls.Add(txtTrenerPrezime);
            groupBox3.Controls.Add(label19);
            groupBox3.Controls.Add(txtTrenerID);
            groupBox3.Controls.Add(btnTrenerKreiraj);
            groupBox3.Controls.Add(label20);
            groupBox3.Controls.Add(txtTrenerGodineIskustva);
            groupBox3.Controls.Add(label21);
            groupBox3.Controls.Add(txtTrenerSpecijalnost);
            groupBox3.Controls.Add(label22);
            groupBox3.Controls.Add(txtTrenerEmail);
            groupBox3.Controls.Add(label23);
            groupBox3.Controls.Add(label24);
            groupBox3.Controls.Add(txtTrenerIme);
            groupBox3.Location = new Point(8, 8);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(295, 403);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "Unos/Brisanje Trenera";
            // 
            // btnTrenerPromeni
            // 
            btnTrenerPromeni.Location = new Point(17, 329);
            btnTrenerPromeni.Name = "btnTrenerPromeni";
            btnTrenerPromeni.Size = new Size(217, 29);
            btnTrenerPromeni.TabIndex = 17;
            btnTrenerPromeni.Text = "Izmeni trenera";
            btnTrenerPromeni.UseVisualStyleBackColor = true;
            // 
            // chkTrenerAktivan
            // 
            chkTrenerAktivan.AutoSize = true;
            chkTrenerAktivan.Location = new Point(19, 253);
            chkTrenerAktivan.Name = "chkTrenerAktivan";
            chkTrenerAktivan.Size = new Size(80, 24);
            chkTrenerAktivan.TabIndex = 16;
            chkTrenerAktivan.Text = "Aktivan";
            chkTrenerAktivan.UseVisualStyleBackColor = true;
            // 
            // txtTrenerTelefon
            // 
            txtTrenerTelefon.Location = new Point(137, 149);
            txtTrenerTelefon.Name = "txtTrenerTelefon";
            txtTrenerTelefon.Size = new Size(152, 27);
            txtTrenerTelefon.TabIndex = 15;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(19, 153);
            label25.Name = "label25";
            label25.Size = new Size(61, 20);
            label25.TabIndex = 14;
            label25.Text = "Telefon:";
            // 
            // txtTrenerPrezime
            // 
            txtTrenerPrezime.Location = new Point(137, 89);
            txtTrenerPrezime.Name = "txtTrenerPrezime";
            txtTrenerPrezime.Size = new Size(152, 27);
            txtTrenerPrezime.TabIndex = 8;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(19, 29);
            label19.Name = "label19";
            label19.Size = new Size(80, 20);
            label19.TabIndex = 0;
            label19.Text = "ID Trenera:";
            // 
            // txtTrenerID
            // 
            txtTrenerID.Location = new Point(137, 26);
            txtTrenerID.Name = "txtTrenerID";
            txtTrenerID.Size = new Size(152, 27);
            txtTrenerID.TabIndex = 1;
            // 
            // btnTrenerKreiraj
            // 
            btnTrenerKreiraj.Location = new Point(19, 294);
            btnTrenerKreiraj.Name = "btnTrenerKreiraj";
            btnTrenerKreiraj.Size = new Size(215, 29);
            btnTrenerKreiraj.TabIndex = 12;
            btnTrenerKreiraj.Text = "Kreiraj trenera";
            btnTrenerKreiraj.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(19, 62);
            label20.Name = "label20";
            label20.Size = new Size(37, 20);
            label20.TabIndex = 2;
            label20.Text = "Ime:";
            // 
            // txtTrenerGodineIskustva
            // 
            txtTrenerGodineIskustva.Location = new Point(137, 215);
            txtTrenerGodineIskustva.Name = "txtTrenerGodineIskustva";
            txtTrenerGodineIskustva.Size = new Size(152, 27);
            txtTrenerGodineIskustva.TabIndex = 11;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(19, 92);
            label21.Name = "label21";
            label21.Size = new Size(65, 20);
            label21.TabIndex = 3;
            label21.Text = "Prezime:";
            // 
            // txtTrenerSpecijalnost
            // 
            txtTrenerSpecijalnost.Location = new Point(137, 182);
            txtTrenerSpecijalnost.Name = "txtTrenerSpecijalnost";
            txtTrenerSpecijalnost.Size = new Size(152, 27);
            txtTrenerSpecijalnost.TabIndex = 10;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(19, 121);
            label22.Name = "label22";
            label22.Size = new Size(49, 20);
            label22.TabIndex = 4;
            label22.Text = "Email:";
            // 
            // txtTrenerEmail
            // 
            txtTrenerEmail.Location = new Point(137, 118);
            txtTrenerEmail.Name = "txtTrenerEmail";
            txtTrenerEmail.Size = new Size(152, 27);
            txtTrenerEmail.TabIndex = 9;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(19, 185);
            label23.Name = "label23";
            label23.Size = new Size(92, 20);
            label23.TabIndex = 5;
            label23.Text = "Specijalnost:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(19, 218);
            label24.Name = "label24";
            label24.Size = new Size(115, 20);
            label24.TabIndex = 6;
            label24.Text = "Godine iskustva:";
            // 
            // txtTrenerIme
            // 
            txtTrenerIme.Location = new Point(137, 59);
            txtTrenerIme.Name = "txtTrenerIme";
            txtTrenerIme.Size = new Size(152, 27);
            txtTrenerIme.TabIndex = 7;
            // 
            // tabClanstvo
            // 
            tabClanstvo.Controls.Add(groupBox7);
            tabClanstvo.Controls.Add(groupBox6);
            tabClanstvo.Controls.Add(groupBox5);
            tabClanstvo.Location = new Point(4, 29);
            tabClanstvo.Name = "tabClanstvo";
            tabClanstvo.Padding = new Padding(3);
            tabClanstvo.Size = new Size(792, 417);
            tabClanstvo.TabIndex = 4;
            tabClanstvo.Text = "Članstvo";
            tabClanstvo.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(btnStavkaSacuvaj);
            groupBox7.Controls.Add(btnStavkaDodajRed);
            groupBox7.Controls.Add(dgvStavke);
            groupBox7.Controls.Add(txtStavkaClanstvoID);
            groupBox7.Controls.Add(label33);
            groupBox7.Location = new Point(526, 6);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(258, 403);
            groupBox7.TabIndex = 19;
            groupBox7.TabStop = false;
            groupBox7.Text = "Stavke članstva (treninzi)";
            // 
            // btnStavkaSacuvaj
            // 
            btnStavkaSacuvaj.Location = new Point(132, 256);
            btnStavkaSacuvaj.Name = "btnStavkaSacuvaj";
            btnStavkaSacuvaj.Size = new Size(120, 29);
            btnStavkaSacuvaj.TabIndex = 4;
            btnStavkaSacuvaj.Text = "Sačuvaj stavke";
            btnStavkaSacuvaj.UseVisualStyleBackColor = true;
            // 
            // btnStavkaDodajRed
            // 
            btnStavkaDodajRed.Location = new Point(6, 256);
            btnStavkaDodajRed.Name = "btnStavkaDodajRed";
            btnStavkaDodajRed.Size = new Size(120, 29);
            btnStavkaDodajRed.TabIndex = 3;
            btnStavkaDodajRed.Text = "Dodaj red";
            btnStavkaDodajRed.UseVisualStyleBackColor = true;
            // 
            // dgvStavke
            // 
            dgvStavke.AllowUserToAddRows = false;
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Columns.AddRange(new DataGridViewColumn[] { colTrener, colVrstaTreninga, colBrojTermina, colCenaStavke });
            dgvStavke.Location = new Point(6, 62);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.RowHeadersWidth = 51;
            dgvStavke.Size = new Size(246, 188);
            dgvStavke.TabIndex = 2;
            // 
            // colTrener
            // 
            colTrener.HeaderText = "Trener";
            colTrener.MinimumWidth = 6;
            colTrener.Name = "colTrener";
            colTrener.Resizable = DataGridViewTriState.True;
            colTrener.SortMode = DataGridViewColumnSortMode.Automatic;
            colTrener.Width = 125;
            // 
            // colVrstaTreninga
            // 
            colVrstaTreninga.HeaderText = "Vrsta treninga";
            colVrstaTreninga.Items.AddRange(new object[] { "Individualni", "Grupni" });
            colVrstaTreninga.MinimumWidth = 6;
            colVrstaTreninga.Name = "colVrstaTreninga";
            colVrstaTreninga.Resizable = DataGridViewTriState.True;
            colVrstaTreninga.SortMode = DataGridViewColumnSortMode.Automatic;
            colVrstaTreninga.Width = 125;
            // 
            // colBrojTermina
            // 
            colBrojTermina.HeaderText = "Broj termina";
            colBrojTermina.MinimumWidth = 6;
            colBrojTermina.Name = "colBrojTermina";
            colBrojTermina.Width = 125;
            // 
            // colCenaStavke
            // 
            colCenaStavke.HeaderText = "Cena";
            colCenaStavke.MinimumWidth = 6;
            colCenaStavke.Name = "colCenaStavke";
            colCenaStavke.Width = 125;
            // 
            // txtStavkaClanstvoID
            // 
            txtStavkaClanstvoID.Location = new Point(93, 26);
            txtStavkaClanstvoID.Name = "txtStavkaClanstvoID";
            txtStavkaClanstvoID.Size = new Size(125, 27);
            txtStavkaClanstvoID.TabIndex = 1;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(6, 29);
            label33.Name = "label33";
            label33.Size = new Size(84, 20);
            label33.TabIndex = 0;
            label33.Text = "ID članstva:";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lblClanstvoUkupnaCena);
            groupBox6.Controls.Add(btnClanstvoIzracunajCenu);
            groupBox6.Controls.Add(btnClanstvoOtkazi);
            groupBox6.Controls.Add(txtClanstvoIDPronađeno);
            groupBox6.Controls.Add(label32);
            groupBox6.Controls.Add(btnClanstvoPronadjiAktivno);
            groupBox6.Controls.Add(txtClanstvoOsobaIDPretraga);
            groupBox6.Controls.Add(label31);
            groupBox6.Location = new Point(297, 6);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(223, 403);
            groupBox6.TabIndex = 18;
            groupBox6.TabStop = false;
            groupBox6.Text = "Postojeće članstvo";
            // 
            // lblClanstvoUkupnaCena
            // 
            lblClanstvoUkupnaCena.AutoSize = true;
            lblClanstvoUkupnaCena.Location = new Point(12, 272);
            lblClanstvoUkupnaCena.Name = "lblClanstvoUkupnaCena";
            lblClanstvoUkupnaCena.Size = new Size(0, 20);
            lblClanstvoUkupnaCena.TabIndex = 7;
            // 
            // btnClanstvoIzracunajCenu
            // 
            btnClanstvoIzracunajCenu.Location = new Point(12, 227);
            btnClanstvoIzracunajCenu.Name = "btnClanstvoIzracunajCenu";
            btnClanstvoIzracunajCenu.Size = new Size(202, 29);
            btnClanstvoIzracunajCenu.TabIndex = 6;
            btnClanstvoIzracunajCenu.Text = "Izračunaj članarinu";
            btnClanstvoIzracunajCenu.UseVisualStyleBackColor = true;
            // 
            // btnClanstvoOtkazi
            // 
            btnClanstvoOtkazi.Location = new Point(12, 182);
            btnClanstvoOtkazi.Name = "btnClanstvoOtkazi";
            btnClanstvoOtkazi.Size = new Size(202, 29);
            btnClanstvoOtkazi.TabIndex = 5;
            btnClanstvoOtkazi.Text = "OtkažiČlanstvo";
            btnClanstvoOtkazi.UseVisualStyleBackColor = true;
            // 
            // txtClanstvoIDPronađeno
            // 
            txtClanstvoIDPronađeno.Location = new Point(12, 134);
            txtClanstvoIDPronađeno.Name = "txtClanstvoIDPronađeno";
            txtClanstvoIDPronađeno.ReadOnly = true;
            txtClanstvoIDPronađeno.Size = new Size(202, 27);
            txtClanstvoIDPronađeno.TabIndex = 4;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(9, 111);
            label32.Name = "label32";
            label32.Size = new Size(171, 20);
            label32.TabIndex = 3;
            label32.Text = "Pronađeno članstvo (ID):";
            // 
            // btnClanstvoPronadjiAktivno
            // 
            btnClanstvoPronadjiAktivno.Location = new Point(9, 62);
            btnClanstvoPronadjiAktivno.Name = "btnClanstvoPronadjiAktivno";
            btnClanstvoPronadjiAktivno.Size = new Size(205, 29);
            btnClanstvoPronadjiAktivno.TabIndex = 2;
            btnClanstvoPronadjiAktivno.Text = "Pronađi aktivno članstvo";
            btnClanstvoPronadjiAktivno.UseVisualStyleBackColor = true;
            // 
            // txtClanstvoOsobaIDPretraga
            // 
            txtClanstvoOsobaIDPretraga.Location = new Point(89, 26);
            txtClanstvoOsobaIDPretraga.Name = "txtClanstvoOsobaIDPretraga";
            txtClanstvoOsobaIDPretraga.Size = new Size(125, 27);
            txtClanstvoOsobaIDPretraga.TabIndex = 1;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(9, 29);
            label31.Name = "label31";
            label31.Size = new Size(74, 20);
            label31.TabIndex = 0;
            label31.Text = "ID Osobe:";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(dtpClanstvoDatumIsteka);
            groupBox5.Controls.Add(dtpClanstvoDatumPocetka);
            groupBox5.Controls.Add(txtClanstvoCena);
            groupBox5.Controls.Add(label26);
            groupBox5.Controls.Add(label27);
            groupBox5.Controls.Add(btnClanstvoKreiraj);
            groupBox5.Controls.Add(txtClanstvoOsobaID);
            groupBox5.Controls.Add(label29);
            groupBox5.Controls.Add(label30);
            groupBox5.Location = new Point(8, 6);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(282, 403);
            groupBox5.TabIndex = 17;
            groupBox5.TabStop = false;
            groupBox5.Text = "Novo članstvo";
            // 
            // dtpClanstvoDatumIsteka
            // 
            dtpClanstvoDatumIsteka.Location = new Point(137, 87);
            dtpClanstvoDatumIsteka.Name = "dtpClanstvoDatumIsteka";
            dtpClanstvoDatumIsteka.Size = new Size(139, 27);
            dtpClanstvoDatumIsteka.TabIndex = 17;
            // 
            // dtpClanstvoDatumPocetka
            // 
            dtpClanstvoDatumPocetka.Location = new Point(137, 58);
            dtpClanstvoDatumPocetka.Name = "dtpClanstvoDatumPocetka";
            dtpClanstvoDatumPocetka.Size = new Size(139, 27);
            dtpClanstvoDatumPocetka.TabIndex = 16;
            // 
            // txtClanstvoCena
            // 
            txtClanstvoCena.Location = new Point(137, 120);
            txtClanstvoCena.Name = "txtClanstvoCena";
            txtClanstvoCena.Size = new Size(139, 27);
            txtClanstvoCena.TabIndex = 15;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(19, 123);
            label26.Name = "label26";
            label26.Size = new Size(45, 20);
            label26.TabIndex = 14;
            label26.Text = "Cena:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(19, 29);
            label27.Name = "label27";
            label27.Size = new Size(84, 20);
            label27.TabIndex = 0;
            label27.Text = "Osoba (ID):";
            // 
            // btnClanstvoKreiraj
            // 
            btnClanstvoKreiraj.Location = new Point(19, 168);
            btnClanstvoKreiraj.Name = "btnClanstvoKreiraj";
            btnClanstvoKreiraj.Size = new Size(215, 29);
            btnClanstvoKreiraj.TabIndex = 13;
            btnClanstvoKreiraj.Text = "Kreiraj članstvo";
            btnClanstvoKreiraj.UseVisualStyleBackColor = true;
            // 
            // txtClanstvoOsobaID
            // 
            txtClanstvoOsobaID.Location = new Point(137, 26);
            txtClanstvoOsobaID.Name = "txtClanstvoOsobaID";
            txtClanstvoOsobaID.Size = new Size(139, 27);
            txtClanstvoOsobaID.TabIndex = 1;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(19, 63);
            label29.Name = "label29";
            label29.Size = new Size(63, 20);
            label29.TabIndex = 3;
            label29.Text = "Početak:";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(19, 92);
            label30.Name = "label30";
            label30.Size = new Size(46, 20);
            label30.TabIndex = 4;
            label30.Text = "Ističe:";
            // 
            // tabKvalifikacija
            // 
            tabKvalifikacija.Controls.Add(groupBox9);
            tabKvalifikacija.Controls.Add(groupBox8);
            tabKvalifikacija.Location = new Point(4, 29);
            tabKvalifikacija.Name = "tabKvalifikacija";
            tabKvalifikacija.Padding = new Padding(3);
            tabKvalifikacija.Size = new Size(792, 417);
            tabKvalifikacija.TabIndex = 5;
            tabKvalifikacija.Text = "Kvalifikacija";
            tabKvalifikacija.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(btnKvalifikacijaKreiraj);
            groupBox9.Controls.Add(txtKvalifikacijaNaziv);
            groupBox9.Controls.Add(label39);
            groupBox9.Controls.Add(cmbKvalifikacijaNivo);
            groupBox9.Controls.Add(label38);
            groupBox9.Location = new Point(8, 6);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(399, 403);
            groupBox9.TabIndex = 1;
            groupBox9.TabStop = false;
            groupBox9.Text = "Nova kvalifikacija";
            // 
            // btnKvalifikacijaKreiraj
            // 
            btnKvalifikacijaKreiraj.Location = new Point(18, 117);
            btnKvalifikacijaKreiraj.Name = "btnKvalifikacijaKreiraj";
            btnKvalifikacijaKreiraj.Size = new Size(212, 29);
            btnKvalifikacijaKreiraj.TabIndex = 4;
            btnKvalifikacijaKreiraj.Text = "Kreiraj kvalifikaciju";
            btnKvalifikacijaKreiraj.UseVisualStyleBackColor = true;
            // 
            // txtKvalifikacijaNaziv
            // 
            txtKvalifikacijaNaziv.Location = new Point(79, 35);
            txtKvalifikacijaNaziv.Name = "txtKvalifikacijaNaziv";
            txtKvalifikacijaNaziv.Size = new Size(151, 27);
            txtKvalifikacijaNaziv.TabIndex = 3;
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(18, 76);
            label39.Name = "label39";
            label39.Size = new Size(43, 20);
            label39.TabIndex = 2;
            label39.Text = "Nivo:";
            // 
            // cmbKvalifikacijaNivo
            // 
            cmbKvalifikacijaNivo.FormattingEnabled = true;
            cmbKvalifikacijaNivo.Location = new Point(79, 73);
            cmbKvalifikacijaNivo.Name = "cmbKvalifikacijaNivo";
            cmbKvalifikacijaNivo.Size = new Size(151, 28);
            cmbKvalifikacijaNivo.TabIndex = 1;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(18, 38);
            label38.Name = "label38";
            label38.Size = new Size(49, 20);
            label38.TabIndex = 0;
            label38.Text = "Naziv:";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(btnDodeliKvalifikaciju);
            groupBox8.Controls.Add(dtpDodelaDatumIsteka);
            groupBox8.Controls.Add(dtpDodelaDatumSticanja);
            groupBox8.Controls.Add(cmbKvalifikacijaIzbor);
            groupBox8.Controls.Add(label40);
            groupBox8.Controls.Add(label37);
            groupBox8.Controls.Add(label36);
            groupBox8.Location = new Point(413, 6);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(373, 405);
            groupBox8.TabIndex = 0;
            groupBox8.TabStop = false;
            groupBox8.Text = "Dodela kvalifikacije radniku";
            // 
            // btnDodeliKvalifikaciju
            // 
            btnDodeliKvalifikaciju.Location = new Point(26, 164);
            btnDodeliKvalifikaciju.Name = "btnDodeliKvalifikaciju";
            btnDodeliKvalifikaciju.Size = new Size(341, 29);
            btnDodeliKvalifikaciju.TabIndex = 9;
            btnDodeliKvalifikaciju.Text = "Dodeli kvalifikaciju";
            btnDodeliKvalifikaciju.UseVisualStyleBackColor = true;
            // 
            // dtpDodelaDatumIsteka
            // 
            dtpDodelaDatumIsteka.Location = new Point(160, 119);
            dtpDodelaDatumIsteka.Name = "dtpDodelaDatumIsteka";
            dtpDodelaDatumIsteka.ShowCheckBox = true;
            dtpDodelaDatumIsteka.Size = new Size(207, 27);
            dtpDodelaDatumIsteka.TabIndex = 8;
            // 
            // dtpDodelaDatumSticanja
            // 
            dtpDodelaDatumSticanja.Location = new Point(160, 76);
            dtpDodelaDatumSticanja.Name = "dtpDodelaDatumSticanja";
            dtpDodelaDatumSticanja.Size = new Size(207, 27);
            dtpDodelaDatumSticanja.TabIndex = 7;
            // 
            // cmbKvalifikacijaIzbor
            // 
            cmbKvalifikacijaIzbor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKvalifikacijaIzbor.FormattingEnabled = true;
            cmbKvalifikacijaIzbor.Location = new Point(160, 39);
            cmbKvalifikacijaIzbor.Name = "cmbKvalifikacijaIzbor";
            cmbKvalifikacijaIzbor.Size = new Size(207, 28);
            cmbKvalifikacijaIzbor.TabIndex = 6;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(26, 42);
            label40.Name = "label40";
            label40.Size = new Size(87, 20);
            label40.TabIndex = 5;
            label40.Text = "Kvalifikacija";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(26, 124);
            label37.Name = "label37";
            label37.Size = new Size(99, 20);
            label37.TabIndex = 3;
            label37.Text = "Datum isteka:";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(26, 81);
            label36.Name = "label36";
            label36.Size = new Size(111, 20);
            label36.TabIndex = 2;
            label36.Text = "Datum sticanja:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPrijava.ResumeLayout(false);
            tabPrijava.PerformLayout();
            tabRadnik.ResumeLayout(false);
            boxPretraga.ResumeLayout(false);
            boxPretraga.PerformLayout();
            boxUnosIzmena.ResumeLayout(false);
            boxUnosIzmena.PerformLayout();
            tabOsoba.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabTrener.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            tabClanstvo.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            tabKvalifikacija.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPrijava;
        private Label lblStatusPrijave;
        private Button btnPrijava;
        private TextBox txtSifra;
        private TextBox txtEmail;
        private Label label2;
        private Label label1;
        private TabPage tabRadnik;
        private TextBox txtRadnikIme;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label Ime;
        private TextBox txtRadnikID;
        private Label label3;
        private Button btnRadnikPromeni;
        private Button btnRadnikKreiraj;
        private TextBox txtRadnikTelefon;
        private TextBox txtRadnikSifra;
        private TextBox txtRadnikEmail;
        private TextBox txtRadnikPrezime;
        private Button btnRadnikDeaktiviraj;
        private GroupBox boxUnosIzmena;
        private GroupBox boxPretraga;
        private TextBox txtRadnikPretraga;
        private Label label8;
        private Button btnRadnikPretrazi;
        private ListBox lstRadnikRezultati;
        private TabPage tabOsoba;
        private GroupBox groupBox1;
        private Label label15;
        private TextBox txtOsobaPrezime;
        private Button btnOsobaObrisi;
        private Label label9;
        private Button btnOsobaPromeni;
        private TextBox txtOsobaID;
        private Button btnOsobaKreiraj;
        private Label label10;
        private TextBox txtOsobaTelefon;
        private Label label11;
        private TextBox txtOsobaJMBG;
        private Label label12;
        private TextBox txtOsobaEmail;
        private Label label13;
        private Label label14;
        private TextBox txtOsobaIme;
        private DateTimePicker dtpOsobaDatumRodjenja;
        private TextBox txtOsobaAdresa;
        private Label label17;
        private Label label16;
        private GroupBox groupBox2;
        private ListBox lstOsobaRezultati;
        private TextBox txtOsobaPretraga;
        private Label label18;
        private Button btnOsobaPretrazi;
        private TabPage tabTrener;
        private GroupBox groupBox3;
        private TextBox txtTrenerPrezime;
        private Label label19;
        private TextBox txtTrenerID;
        private Button btnTrenerKreiraj;
        private Label label20;
        private TextBox txtTrenerGodineIskustva;
        private Label label21;
        private TextBox txtTrenerSpecijalnost;
        private Label label22;
        private TextBox txtTrenerEmail;
        private Label label23;
        private Label label24;
        private TextBox txtTrenerIme;
        private TextBox txtTrenerTelefon;
        private Label label25;
        private GroupBox groupBox4;
        private ListBox lstTrenerRezultati;
        private Button btnTrenerPrikaziAktivne;
        private TabPage tabClanstvo;
        private GroupBox groupBox5;
        private TextBox txtClanstvoCena;
        private Label label26;
        private Label label27;
        private Button btnClanstvoKreiraj;
        private TextBox txtClanstvoOsobaID;
        private Label label29;
        private Label label30;
        private DateTimePicker dtpClanstvoDatumIsteka;
        private DateTimePicker dtpClanstvoDatumPocetka;
        private GroupBox groupBox6;
        private Label lblClanstvoUkupnaCena;
        private Button btnClanstvoIzracunajCenu;
        private Button btnClanstvoOtkazi;
        private TextBox txtClanstvoIDPronađeno;
        private Label label32;
        private Button btnClanstvoPronadjiAktivno;
        private TextBox txtClanstvoOsobaIDPretraga;
        private Label label31;
        private GroupBox groupBox7;
        private TextBox txtStavkaClanstvoID;
        private Label label33;
        private DataGridView dgvStavke;
        private DataGridViewComboBoxColumn colTrener;
        private DataGridViewComboBoxColumn colVrstaTreninga;
        private DataGridViewTextBoxColumn colBrojTermina;
        private DataGridViewTextBoxColumn colCenaStavke;
        private Button btnStavkaSacuvaj;
        private Button btnStavkaDodajRed;
        private TabPage tabKvalifikacija;
        private GroupBox groupBox8;
        private Label label37;
        private Label label36;
        private GroupBox groupBox9;
        private Label label38;
        private Button btnKvalifikacijaKreiraj;
        private TextBox txtKvalifikacijaNaziv;
        private Label label39;
        private ComboBox cmbKvalifikacijaNivo;
        private ComboBox cmbKvalifikacijaIzbor;
        private Label label40;
        private Button btnDodeliKvalifikaciju;
        private DateTimePicker dtpDodelaDatumIsteka;
        private DateTimePicker dtpDodelaDatumSticanja;
        private CheckBox chkTrenerAktivan;
        private Button btnTrenerPromeni;
        private ComboBox cmbOsobaKategorija;
    }
}
