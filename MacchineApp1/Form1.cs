using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacchineApp1
{
    public partial class Form1 : Form
    {
        #region controlli erroneamente dichiarati
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void pbx_strada_Click(object sender, EventArgs e)
        {

        }
        #endregion
        public int Traguardo //lunghezza della strada
        {
            get { return pbx_strada.Width; }
        }
        Automobile auto_rossa;
        Automobile auto_nera;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            //inizializzazione auto
            auto_rossa = new Automobile(pbx_red, "ROSSA", Traguardo);
            auto_nera = new Automobile(pbx_black, "NERA", Traguardo);
        }
        
        #region bgw
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgw = (BackgroundWorker)sender;
            Automobile auto = (Automobile)e.Argument;
            //finché una delle due auto non vince
            while (!(auto_rossa.Vittoria || auto_nera.Vittoria))
            {
                if (bgw.CancellationPending)
                {
                    //se viene premuto il pulsante stop
                    e.Result = (false, auto);
                    return;
                }
                else
                {
                    int spostamento = rnd.Next(1, 11);
                    //muovo l'auto
                    auto.Posizione += spostamento;
                    //mando al progress changed la posizione che l'auto deve avere
                    bgw.ReportProgress(auto.Posizione, auto);
                    Thread.Sleep(50);
                }
            }
            if (auto_rossa.Vittoria && auto_nera.Vittoria)
            {
                //se le auto pareggiano cancello uno dei due bgw
                backgroundWorker_N.CancelAsync();
            }

            //il bgw cancellato
            if (bgw.CancellationPending)
            {
                //chiama il pareggio
                Pareggio();
                //e ritorna falso
                e.Result = (false, auto);
                return;
            }

            //se non ci sono pareggi o cancellazioni, ritorno vero
            e.Result = (true, auto);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Automobile auto = (Automobile)e.UserState;
            //finché viene chiamato il progress changed (ovvero finché si è nel while)
            if (e.ProgressPercentage != -1) 
            {
                //muovo l'auto
                auto.Muovi();
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //quando ho finito il dowork
            btn_rivincita.Show();
            var (non_soppresso, auto) = (ValueTuple<bool, Automobile>)e.Result;
            //se il processo non è stato cancellato
            if (non_soppresso) 
            { 
                //e se l'auto ha vinto 
                if (auto.Vittoria)
                    //stampo che ha vinto
                    MessageBox.Show(auto.Nome + " HA VINTO");
                btn_start.Hide();
                btn_stop.Hide();
            }
            else
            {
                //se è stato cancellato riporto le auto a 0
                auto_rossa.Posizione = 0;
                auto_nera.Posizione = 0;
                auto_nera.Muovi();
                auto_rossa.Muovi();
            }
        }
        #endregion

        #region pulsanti e metodi
        private void Pareggio()
        {
            auto_rossa.Posizione = 0;
            auto_nera.Posizione = 0;
            MessageBox.Show("PAREGGIO");
        }

        private void btn_rivincita_Click(object sender, EventArgs e)
        {
            auto_rossa.Posizione = 0;
            auto_nera.Posizione = 0;
            auto_nera.Muovi();
            auto_rossa.Muovi();
            btn_start_Click(sender, e);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_rivincita.Hide();
            btn_start.Hide();
            btn_stop.Show();
            backgroundWorker_N.RunWorkerAsync(auto_nera);
            backgroundWorker_R.RunWorkerAsync(auto_rossa);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            btn_rivincita.Show();
            btn_start.Show();
            backgroundWorker_N.CancelAsync();
            backgroundWorker_R.CancelAsync();
        }
        #endregion
    }
    public class Automobile
    {
        int lunghezza_tracciato;
        PictureBox _pb; 
        Point _pos;
        public string Nome { get; private set; }
        public Automobile(PictureBox pb, string nome, int l_tracciato)
        {
            _pb = pb;
            lunghezza_tracciato = l_tracciato;
            Nome = nome;
        }
        public int Posizione //posizione dell'auto
        {
            get { return _pos.X; }
            set
            {
                _pos = new Point(value, _pb.Location.Y);
            }
        }
        public int Lunghezza //lunghezza orizziontale dell'auto
        {
            get { return _pb.Width; }
        }
        public bool Vittoria 
        {
            get { return _pos.X >= lunghezza_tracciato - _pb.Width ? true : false; }
        }

        private Point Pos //punto per settare la posizione della pb (è privato e usato solo nel metodo muovi)
        {
            get { return new Point(Posizione, _pb.Location.Y); }
        }
        public void Muovi()
        {
            //assegna alla pb la sua effettiva posizione
            _pb.Location = Pos;
        }
    }
}
