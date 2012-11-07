namespace SampleApp
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
            this.lbSuggestions = new System.Windows.Forms.ListBox();
            this.tbWord = new System.Windows.Forms.TextBox();
            this.btnSuggest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbSuggestions
            // 
            this.lbSuggestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSuggestions.FormattingEnabled = true;
            this.lbSuggestions.Location = new System.Drawing.Point(86, 88);
            this.lbSuggestions.Name = "lbSuggestions";
            this.lbSuggestions.Size = new System.Drawing.Size(194, 173);
            this.lbSuggestions.TabIndex = 4;
            // 
            // tbWord
            // 
            this.tbWord.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWord.Location = new System.Drawing.Point(86, 24);
            this.tbWord.Name = "tbWord";
            this.tbWord.Size = new System.Drawing.Size(194, 20);
            this.tbWord.TabIndex = 1;
            // 
            // btnSuggest
            // 
            this.btnSuggest.Location = new System.Drawing.Point(86, 50);
            this.btnSuggest.Name = "btnSuggest";
            this.btnSuggest.Size = new System.Drawing.Size(75, 23);
            this.btnSuggest.TabIndex = 2;
            this.btnSuggest.Text = "&Suggest";
            this.btnSuggest.UseVisualStyleBackColor = true;
            this.btnSuggest.Click += new System.EventHandler(this.btnSuggest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Word:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Su&ggestions:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 271);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSuggest);
            this.Controls.Add(this.tbWord);
            this.Controls.Add(this.lbSuggestions);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "MainForm";
            this.Text = "SpellChecker Example";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lbSuggestions;
		private System.Windows.Forms.TextBox tbWord;
		private System.Windows.Forms.Button btnSuggest;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

