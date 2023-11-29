namespace Pokemon
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnComenzar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.mxb = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.mxb)).BeginInit();
            this.SuspendLayout();
            // 
            // btnComenzar
            // 
            this.btnComenzar.BackColor = System.Drawing.Color.Transparent;
            this.btnComenzar.BackgroundImage = global::Pokemon.Properties.Resources.imgbin_pokemon_logo_png;
            this.btnComenzar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnComenzar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComenzar.FlatAppearance.BorderSize = 0;
            this.btnComenzar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnComenzar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnComenzar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComenzar.ForeColor = System.Drawing.Color.Transparent;
            this.btnComenzar.Location = new System.Drawing.Point(279, 104);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(496, 284);
            this.btnComenzar.TabIndex = 1;
            this.btnComenzar.UseVisualStyleBackColor = false;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::Pokemon.Properties.Resources.Exit;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(969, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(33, 33);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // mxb
            // 
            this.mxb.Enabled = true;
            this.mxb.Location = new System.Drawing.Point(401, 421);
            this.mxb.Name = "mxb";
            this.mxb.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mxb.OcxState")));
            this.mxb.Size = new System.Drawing.Size(252, 48);
            this.mxb.TabIndex = 65;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Pokemon.Properties.Resources.Fondo1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1014, 481);
            this.ControlBox = false;
            this.Controls.Add(this.mxb);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnComenzar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokemon";
            ((System.ComponentModel.ISupportInitialize)(this.mxb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Button btnCerrar;
        private AxWMPLib.AxWindowsMediaPlayer mxb;
    }
}