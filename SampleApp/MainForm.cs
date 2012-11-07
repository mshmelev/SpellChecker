using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SampleApp
{
	public partial class MainForm : Form
	{
		public MainForm ()
		{
			InitializeComponent ();
		}

		private void MainForm_Load (object sender, EventArgs e)
		{
		}

		private void btnSuggest_Click (object sender, EventArgs e)
		{
			var sc = new SpellChecker.SpellChecker ();
			var suggestions= sc.SuggestCorrectedWords (tbWord.Text);
			lbSuggestions.DataSource = suggestions.Select (s => s.Text).ToArray();
		}
	}
}
