namespace MacchineApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker_R = new System.ComponentModel.BackgroundWorker();
            this.pbx_strada = new System.Windows.Forms.PictureBox();
            this.pbx_red = new System.Windows.Forms.PictureBox();
            this.pbx_black = new System.Windows.Forms.PictureBox();
            this.backgroundWorker_N = new System.ComponentModel.BackgroundWorker();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_rivincita = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_strada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_black)).BeginInit();
            this.SuspendLayout();
            // 
            // backgroundWorker_R
            // 
            this.backgroundWorker_R.WorkerReportsProgress = true;
            this.backgroundWorker_R.WorkerSupportsCancellation = true;
            this.backgroundWorker_R.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker_R.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker_R.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pbx_strada
            // 
            this.pbx_strada.Image = global::MacchineApp1.Properties.Resources.road_trip_background_10864211;
            this.pbx_strada.Location = new System.Drawing.Point(0, -1);
            this.pbx_strada.Name = "pbx_strada";
            this.pbx_strada.Size = new System.Drawing.Size(1212, 453);
            this.pbx_strada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_strada.TabIndex = 0;
            this.pbx_strada.TabStop = false;
            this.pbx_strada.Click += new System.EventHandler(this.pbx_strada_Click);
            // 
            // pbx_red
            // 
            this.pbx_red.BackColor = System.Drawing.Color.Black;
            this.pbx_red.Image = global::MacchineApp1.Properties.Resources.macchinarossa;
            this.pbx_red.Location = new System.Drawing.Point(0, 61);
            this.pbx_red.Name = "pbx_red";
            this.pbx_red.Size = new System.Drawing.Size(240, 114);
            this.pbx_red.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_red.TabIndex = 1;
            this.pbx_red.TabStop = false;
            this.pbx_red.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pbx_black
            // 
            this.pbx_black.BackColor = System.Drawing.Color.Black;
            this.pbx_black.Image = global::MacchineApp1.Properties.Resources.macchinabianca;
            this.pbx_black.Location = new System.Drawing.Point(0, 271);
            this.pbx_black.Name = "pbx_black";
            this.pbx_black.Size = new System.Drawing.Size(240, 114);
            this.pbx_black.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbx_black.TabIndex = 2;
            this.pbx_black.TabStop = false;
            // 
            // backgroundWorker_N
            // 
            this.backgroundWorker_N.WorkerReportsProgress = true;
            this.backgroundWorker_N.WorkerSupportsCancellation = true;
            this.backgroundWorker_N.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker_N.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker_N.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(1227, 92);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "Inizio";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(1227, 169);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 4;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_rivincita
            // 
            this.btn_rivincita.Location = new System.Drawing.Point(1227, 247);
            this.btn_rivincita.Name = "btn_rivincita";
            this.btn_rivincita.Size = new System.Drawing.Size(75, 23);
            this.btn_rivincita.TabIndex = 5;
            this.btn_rivincita.Text = "Rivincita";
            this.btn_rivincita.UseVisualStyleBackColor = true;
            this.btn_rivincita.Click += new System.EventHandler(this.btn_rivincita_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 450);
            this.Controls.Add(this.btn_rivincita);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.pbx_black);
            this.Controls.Add(this.pbx_red);
            this.Controls.Add(this.pbx_strada);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbx_strada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_black)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker_R;
        private System.Windows.Forms.PictureBox pbx_strada;
        private System.Windows.Forms.PictureBox pbx_red;
        private System.Windows.Forms.PictureBox pbx_black;
        private System.ComponentModel.BackgroundWorker backgroundWorker_N;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_rivincita;
    }
}

