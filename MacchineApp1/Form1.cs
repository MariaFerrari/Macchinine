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
        public Form1()
        {
            InitializeComponent();
            //inizializzazione auto
            auto_rossa = new Automobile(pbx_red, "ROSSA", Traguardo);
            auto_nera = new Automobile(pbx_black, "NERA", Traguardo);
        }
        private bool Vittoria() 
        {

            return auto_rossa.Vittoria || auto_nera.Vittoria;
        }
        
        #region bgw
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgw = (BackgroundWorker)sender;
            Automobile auto = (Automobile)e.Argument;
            Random rnd = new Random();
            //finché una delle due auto non vince
            while (!Vittoria())
            {
                if (bgw.CancellationPending)
                {
                    //se viene premuto il pulsante stop
                    e.Result = false;
                    return;
                }
                else
                {
                    int spostamento = rnd.Next(1, 11);
                    //muovo l'auto
                    auto.Posizione += spostamento;
                    //mando al progress changed la posizione che l'auto deve avere
                    bgw.ReportProgress(auto.Posizione, auto);
                    Thread.Sleep(100);
                }
            }

            //un'auto è arrivata senza che il pulsante stop sia stato premuto
            if (bgw.CancellationPending)
            {
                //se viene premuto il pulsante stop
                e.Result = false;
                return;
            }
            e.Result = true;

        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Automobile auto = (Automobile)e.UserState;
            if (e.ProgressPercentage != Traguardo - auto.Lunghezza) //l'auto non arriva alla fine
            {
                auto.Muovi();
                Refresh();
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btn_rivincita.Show();
            var cancellato=!(bool)e.Result; //e.Result è falso se viene cancellato quindi lo nego
            if (cancellato)
            {
                //se è stato cancellato riporto le auto a 0
                auto_rossa.Posizione = 0;
                auto_nera.Posizione = 0;
                Refresh();
            }
            else 
            {
                //altrimenti mostro le messagebox
                if (auto_rossa.Vittoria && auto_nera.Vittoria)
                    MessageBox.Show("PAREGGIO");
                else
                if (auto_rossa.Vittoria)
                    MessageBox.Show("ROSSA HA VINTO");
                else MessageBox.Show("NERA HA VINTO");
                btn_start.Hide();
            }
        }
        #endregion

        private void btn_rivincita_Click(object sender, EventArgs e)
        {
            auto_rossa.Posizione = 0;
            auto_nera.Posizione = 0;
            Refresh();
            btn_start_Click(sender, e);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_rivincita.Hide();
            btn_start.Hide();
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

        private void btn_pos_Click(object sender, EventArgs e)
        {
            auto_rossa.Posizione = 0;
            auto_nera.Posizione = 0;
            Refresh();
        }
    }
    public class Automobile
    {
        int _fine;
        PictureBox _pb;
        Point _pos;
        public string Nome { get; private set; }
        public Automobile(PictureBox pb, string nome, int l_tracciato)
        {
            _pb = pb;
            _fine = l_tracciato;
        }
        public int Posizione
        {
            get { return _pos.X; }
            set
            {
                _pos = new Point(value, _pb.Location.Y);
            }
        }
        public int Lunghezza
        {
            get { return _pb.Width; }
        }
        public bool Vittoria
        {
            get { return _pos.X >= _fine-_pb.Width ? true : false; }
        }
        
        private Point Pos
        {
            get { return new Point(Posizione, _pb.Location.Y); }
        }
        public void Muovi()
        {
            _pb.Location = Pos;
        }
        //public override bool Equals(object obj)
        //{
        //    Automobile auto = obj as Automobile;
        //    if (auto == null) return false;
        //    return auto.Nome == this.Nome;
        //}
    }
}
