using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Newtonsoft.Json;
using Spamer;
using System.Windows.Media.Imaging;
using Spammer;
using System.Windows.Threading;

namespace Spamer2
{
    public partial class MainWindow : Window
    {
        Variablen vars = new Variablen();
        DatenKlasse Daten = new DatenKlasse();
        Random rnd = new Random();

        OpenFileDialog filedialog = new OpenFileDialog();
        StreamWriter LogWriter;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            Directory.CreateDirectory(vars.PathToFolder);
            LogWriter = new StreamWriter(vars.PathToLog, true);

            if (!System.IO.File.Exists(vars.PathToLog)) File.Create(vars.PathToLog);
            if (!System.IO.File.Exists(vars.PathToSetting))
            {
                File.Create(vars.PathToSetting);
            }

            InitializeComponent();
        }

        private void btnLos_Click(object sender, RoutedEventArgs e)
        {
            txtLogImProgramm.Text = "";
            txtFehlerimProgram.Text = "";

            pBFortschritt.Value = pBFortschritt.Minimum;
            vars.CurrentDurchläufe = 0;

            NeuerEintrag();

            if (Fehler()) return;

            //Setting the Timer settings
            timer.Interval = TimeSpan.FromMilliseconds(sldGeschwindigkeit.Value);

            txtLogImProgramm.Text += "[Waiting 2 secounds]\n";
            txtLogImProgramm.Text += "-------\n";
            txtLogImProgramm.Text += "[Prozess Startet]\n";
            Thread.Sleep(2000);

            vars.RandomZahl = rnd.Next(1111111111, int.MaxValue);
            if (cbRandom.IsChecked == true && CopyMethod.IsChecked == true) System.Windows.Clipboard.SetText(vars.RandomZahl.ToString());
            if (cbRandom.IsChecked == false && CopyMethod.IsChecked == true) System.Windows.Clipboard.SetText(txtEingabe.Text);


            timer.Tick += (object sender2, EventArgs e2) =>
            {
                if (vars.CurrentDurchläufe >= sldDurchläufe.Value)
                {
                    LogWriter.WriteLine("Vorgang erfolgreich abgeschlossen!");
                    txtLogImProgramm.Text += "Vorgang erfolgreich abgeschlossen!";
                    timer.Stop();
                    return;
                }

                if (CopyMethod.IsChecked == true)
                {
                    SendKeys.SendWait("^{v}" + ((cbEnter.IsChecked == true) ? "{ENTER}" : ""));
                }
                else if (WriteMethod.IsChecked == true)
                {
                    if (cbRandom.IsChecked == true)
                    {
                        SendKeys.SendWait(vars.RandomZahl + ((cbEnter.IsChecked == true) ? "{ENTER}" : ""));
                    }
                    else
                    {
                        SendKeys.SendWait(txtEingabe.Text + ((cbEnter.IsChecked == true) ? "{ENTER}" : ""));
                    }
                }

                pBFortschritt.Value++;
                vars.CurrentDurchläufe++;

                LogAusgabe();
            };
            timer.Start();
        }

        public void LogAusgabe()
        {
            if (cbRandom.IsChecked == true) LogWriter.WriteLine(">> Key [" + vars.CurrentDurchläufe + "] send: {" + vars.RandomZahl + "}");
            else LogWriter.WriteLine(">> Key [" + vars.CurrentDurchläufe + "] send: {" + txtEingabe.Text + "}");

            if (cbRandom.IsChecked == true) txtLogImProgramm.Text += ">> Key [" + vars.CurrentDurchläufe + "] send: {" + vars.RandomZahl + "}\n";
            else txtLogImProgramm.Text += ">> Key [" + vars.CurrentDurchläufe + "] send: {" + txtEingabe.Text + "}\n";

        }

        public bool Fehler()
        {
            bool returnvalue = false;
            txtFehlerimProgram.Text = "";
            if (txtEingabe.Text.Length == 0 && cbRandom.IsChecked == false)
            {
                LogWriter.WriteLine("> Fehler: Von dem Nutzer wurde keine Textliche Eingabe getätigt!");
                txtFehlerimProgram.Text += "> Fehler: Du hast keine Eingabe im Textfeld getätigt! \n";
                returnvalue = true;
                Console.Beep();
            }

            //Fehlermeldung KeineDurchläufe
            if (sldDurchläufe.Value <= 1)
            {
                LogWriter.WriteLine("> Fehler: Der Nutzer hat keine Anzahl von Durchläufen angegeben!");
                txtFehlerimProgram.Text += "> Fehler: Du hast keine Anzahl an Durchläufen angegeben! \n";
                returnvalue = true;
                Console.Beep();
            }

            //Fehler kein Intervall
            if (sldGeschwindigkeit.Value < 750 && cbAdvanced.IsChecked == false)
            {
                LogWriter.WriteLine("> Fehler: Der Nutzer hat kein Intervall angegeben!");
                txtFehlerimProgram.Text += "> Fehler: Der Nutzer hat kein Intervall angeben! \n";
                returnvalue = true;
                Console.Beep();
            }

            else if (sldGeschwindigkeit.Value < 10 && cbAdvanced.IsChecked == true)
            {
                LogWriter.WriteLine("> Fehler: Der Nutzer hat kein Intervall angegeben!");
                txtFehlerimProgram.Text += "> Fehler: Der Nutzer hat kein Intervall angeben! \n";
                returnvalue = true;
                Console.Beep();
            }
            return returnvalue;
        }

        public void NeuerEintrag()
        {
            LogWriter.WriteLine("");
            LogWriter.WriteLine("[" + DateTime.Now + "]" + " Neuer Eintrag:");

            if (sldGeschwindigkeit.Value > 500)
            {
                LogWriter.WriteLine(">>> Das Intervall wurde von dem Nutzer auf " + sldGeschwindigkeit.Value + " Millisekunden gesetzt!");
            }

            if (sldDurchläufe.Value > 1)
            {
                LogWriter.WriteLine(">>> Die Anzahl der Durchläufe wurde von dem Nutzer auf " + sldDurchläufe.Value + " gesetzt!");
            }

            if (txtEingabe.Text.Length > 0 && cbRandom.IsChecked == false)
            {
                LogWriter.WriteLine(">>> Die Texteingabe wurde auf \"" + txtEingabe.Text + "\" gesetzt!");
            }

            else if (txtEingabe.Text.Length > 0 && cbRandom.IsChecked == true)
            {
                LogWriter.WriteLine(">>> Die Texteingabe wurde auf {Random} gesetzt!");
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            if (timer.IsEnabled)
            {
                LogWriter.WriteLine("Der Nutzer hat den Vorgang bei Stelle " + vars.CurrentDurchläufe + " abgebrochen!");
                txtLogImProgramm.Text += "Der Nutzer hat den Vorgang bei Stelle " + vars.CurrentDurchläufe + " abgebrochen! \n";
            }
        }

        private void sldDurchläufe_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newDurchläufe = 0;
            try
            {
                newDurchläufe = Convert.ToInt32(sldDurchläufe.Value);
            }

            catch (FormatException fe)
            {
                txtFehlerimProgram.Text += fe.Message + "\n";
            }
            Daten.Durchläufe = newDurchläufe;
            pBDurchläufe.Value = newDurchläufe;
            pBFortschritt.Maximum = sldDurchläufe.Value;
            txtAnzeigeDurchläufe.Text = newDurchläufe.ToString();
        }

        private void sldGeschwindigkeit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int newSpeed = 0;
            try {newSpeed = Convert.ToInt32(sldGeschwindigkeit.Value);}
            catch (FormatException fe2){ txtFehlerimProgram.Text += fe2.Message + "\n";}

            Daten.Speed = newSpeed;
            pBGEschwindigkeit.Value = newSpeed;
            txtAnzeigeGeschwindigkeit.Text = newSpeed.ToString();

        }

        private void btnLeeren_Click(object sender, RoutedEventArgs e)
        {
            var Löschen = new StreamWriter(vars.PathToLog, false);
            Löschen.WriteLine("");
            Löschen.Close();
        }

        private void btnÖffnen_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(vars.PathToLog);
        }

        private void txtFehlerimProgram_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Daten.CurrentText = txtEingabe.Text;
        }

        private void pBDurchläufe_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void pBGEschwindigkeit_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void txtAnzeigeDurchläufe_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            int NewDurchläufe = 0;

            try { NewDurchläufe = Convert.ToInt32(txtAnzeigeDurchläufe.Text);}
            catch (FormatException ey){txtFehlerimProgram.Text += ey.Message + "\n";}

            sldDurchläufe.Value = NewDurchläufe;
        }

        private void txtAnzeigeGeschwindigkeit_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            int NewSpeed = 0;

            try{ NewSpeed = Convert.ToInt32(txtAnzeigeGeschwindigkeit.Text); }
            catch (FormatException ey2){txtFehlerimProgram.Text += ey2.Message + "\n";}

            sldGeschwindigkeit.Value = NewSpeed;
        }

        private void cbAdvanced_Checked(object sender, RoutedEventArgs e)
        {
            Daten.Advanced = (bool) cbAdvanced.IsChecked;

            if (cbAdvanced.IsChecked == true)
            {
                sldDurchläufe.Maximum = 100000;
                pBDurchläufe.Maximum = 100000;
                
                sldGeschwindigkeit.Minimum = 10;
                pBGEschwindigkeit.Minimum = 10;

                sldGeschwindigkeit.SmallChange = 10;

                lblDurchläufeMaximum.Content = "100.000";
                lblGeschwindigkeitMinimum.Content = sldGeschwindigkeit.Minimum.ToString();
                return;

            }

            sldDurchläufe.Maximum = 400;
            pBDurchläufe.Maximum = 400;
            
            sldGeschwindigkeit.Maximum = 10000;
            sldGeschwindigkeit.SmallChange = 50;
            pBGEschwindigkeit.Maximum = 10000;

            sldGeschwindigkeit.Minimum = 750;
            pBGEschwindigkeit.Minimum = 750;


            lblDurchläufeMaximum.Content = sldDurchläufe.Maximum.ToString();
            lblGeschwindigkeitMinimum.Content = sldGeschwindigkeit.Minimum.ToString();
            
        }

        private void pBFortschritt_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pBFortschritt.Value == pBFortschritt.Maximum) { pBFortschritt.Foreground = Brushes.ForestGreen; return; }
            
            pBFortschritt.Foreground = Brushes.Red;
        }

        private void cbRandom_Checked(object sender, RoutedEventArgs e)
        {
            Daten.Random = (bool)cbRandom.IsChecked;
            if (cbRandom.IsChecked == true)
            {
                txtEingabe.IsEnabled = false;
                txtEingabe.Text = "Random checked!";
                return;
            }

            txtEingabe.IsEnabled = true;
            txtEingabe.Text = "";

        }

        private void Grid_Drop(object sender, System.Windows.DragEventArgs e) { }

        private void cbEnter_Checked(object sender, RoutedEventArgs e)
        {
            Daten.EnterNachAusgabe = true;
        }

        private void reset()
        {
            //Reset einstellen
        }

        private void btnResetAll_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void speichernn()
        {
            string JSONtoSave = JsonConvert.SerializeObject(Daten, Formatting.Indented);
            File.WriteAllText(vars.PathToSetting, JSONtoSave);
        }

        private void lesen()
        {
            string reatFile = File.ReadAllText(vars.PathToSetting);
            Daten = JsonConvert.DeserializeObject<DatenKlasse>(reatFile);

            if (Daten == null)
            {
                Daten = new DatenKlasse();
                return;
            }

            cbEnter.IsChecked = Daten.EnterNachAusgabe;
            cbRandom.IsChecked = Daten.Random;
            CopyMethod.IsChecked = (Daten.Type == "copy") ? true : false;
            WriteMethod.IsChecked = (Daten.Type == "write" || Daten.Type == null) ? true : false;
            cbAdvanced.IsChecked = Daten.Advanced;
            txtEingabe.Text = Daten.CurrentText;
            sldDurchläufe.Value = Daten.Durchläufe;
            sldGeschwindigkeit.Value = Daten.Speed;

            lblAktuellerPfadAnzeíge.Text = "Aktueller Pfad: \n" + (File.Exists(Daten.Background) ? Daten.Background.Replace(@"file:///", "") : "undefinded");
            if (Daten.Background == null) return;

            lblGeschwindigkeitMinimum.Content = ((bool)Daten.Advanced) ? "10" : "750";

            try
            {
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(Daten.Background);
                logo.EndInit();
                Bildbox.Source = logo;
                BildBoxMainPage.Source = logo;
            }
            catch (Exception e)
            {
                txtFehlerimProgram.Text = "Background-File-Path not found!";
            }
        }

        private void CopyMethod_Checked(object sender, RoutedEventArgs e)
        {
            Daten.Type = "copy";
        }

        private void btnChangeBackground_Click(object sender, RoutedEventArgs e)
        {

            filedialog.Multiselect = false;
            filedialog.Filter = "Hintergrund (*.jpeg)|*.jpeg|*.png|*jpg|Alle Datein (*.*)|*.*";
            filedialog.DefaultExt = "png";
            filedialog.ShowDialog();

            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            if (filedialog.FileName != null && filedialog.FileName != "")
            {
                logo.UriSource = new Uri(filedialog.FileName);
                Bildbox.Source = logo;
                BildBoxMainPage.Source = logo;
                logo.EndInit();
                Daten.Background = filedialog.FileName;
                lblAktuellerPfadAnzeíge.Text = "Aktueller Pfad: \n" + filedialog.FileName.Replace("file:///", "");
            }

        }

        private void WriteMethod_Checked(object sender, RoutedEventArgs e)
        {
            Daten.Type = "write";
        }

        private void Window_OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            speichernn();
            LogWriter.Close();
        }

        private void Window_gotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            lesen();
        }

        private void txtLogImProgramm_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            txtLogImProgramm.ScrollToEnd();
        }
    }
}