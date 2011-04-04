#region Licence

// Licensed under the Microsoft Public License. You may
// obtain a copy of the license at:
// 
// http://www.microsoft.com/opensource/licenses.mspx
// 
// By using this source code in any fashion, you are agreeing
// to be bound by the terms of the Microsoft Public License.
// 
// You must not remove this notice, or any other, from this software.
// 
// The original version of this project was written by Omar Shahine (http://insertcode.codeplex.com/)
// Modifications by Jeremy Skinner (http://www.jeremyskinner.co.uk)
// 
// The latest version of this file can be found at https://github.com/JeremySkinner/InsertCode

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using InsertCodePlugin.CSharpFormat;

namespace InsertCodePlugin
{
	/// <summary>
	/// Summary description for InsertCodeInsertForm.
	/// </summary>
	public class InsertCodeInsertForm : Form
	{
		public string RawCode
		{
			get { return textBox1.Text; }
			set { textBox1.Text = value; }
		}

		public SourceFormat Format
		{
			get { return (SourceFormat) comboBoxLanguage.SelectedItem; }
			set { comboBoxLanguage.SelectedItem = value; }
		}

		public bool EmbedStylesheet
		{
			get { return checkBoxEmbedStyle.Checked; }
			set { checkBoxEmbedStyle.Checked = value; }
		}


		public bool HighlightAlternateLines 
		{
			get { return checkBoxAlternateLineBackground.Checked; }
			set { checkBoxAlternateLineBackground.Checked = value; }
		}

		public bool ShowLineNumbers 
		{
			get { return checkBoxLineNumbers.Checked; }
			set { checkBoxLineNumbers.Checked = value; }
		}


		private Button buttonOK;
		private Button buttonCancel;
		private SplitContainer splitContainer1;
		private WebBrowser webBrowser1;
		private ComboBox comboBoxLanguage;
		private CheckBox checkBoxLineNumbers;
		private CheckBox checkBoxAlternateLineBackground;
		private Timer timer1;
		private TextBox textBox1;
		private Label label2;
		private Label label1;
		private CheckBox checkBoxEmbedStyle;
		private IContainer components;

		public InsertCodeInsertForm()
		{
			InitializeComponent();

			foreach(var format in FormatFactory.GetFormats())
			{
				comboBoxLanguage.Items.Add(format);
			}

			Load += delegate {
				this.timer1.Start();
				if (comboBoxLanguage.SelectedItem == null) comboBoxLanguage.SelectedIndex = 0;
			};

			checkBoxLineNumbers.CheckedChanged += delegate { Preview(); };
			checkBoxAlternateLineBackground.CheckedChanged += delegate { Preview(); };
			comboBoxLanguage.SelectedIndexChanged += delegate { Preview(); };
			timer1.Tick += delegate { Preview(); };

			buttonCancel.Click += delegate {
				DialogResult = DialogResult.Cancel;
				Close();
			};

			buttonOK.Click += delegate {
				DialogResult = DialogResult.OK;
				Close();
			};

		}

		private void Preview()
		{
			var showLineNumbers = checkBoxLineNumbers.Checked;
			var alternateBackgroundColours = checkBoxAlternateLineBackground.Checked;
			var formattedHtml = Format.FormatCode(RawCode, showLineNumbers, alternateBackgroundColours, embedStylesheet: true);
			
			this.webBrowser1.DocumentText = formattedHtml;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			this.components = new System.ComponentModel.Container();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
			this.checkBoxLineNumbers = new System.Windows.Forms.CheckBox();
			this.checkBoxAlternateLineBackground = new System.Windows.Forms.CheckBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.checkBoxEmbedStyle = new System.Windows.Forms.CheckBox();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(433, 577);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(64, 23);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "OK";
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(505, 577);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(64, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(13, 32);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.textBox1);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Size = new System.Drawing.Size(556, 539);
			this.splitContainer1.SplitterDistance = 161;
			this.splitContainer1.TabIndex = 0;
			this.splitContainer1.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(0, 13);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox1.Size = new System.Drawing.Size(556, 148);
			this.textBox1.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Code:";
			// 
			// webBrowser1
			// 
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(0, 13);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(556, 361);
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Preview:";
			// 
			// comboBoxLanguage
			// 
			this.comboBoxLanguage.DisplayMember = "Name";
			this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLanguage.FormattingEnabled = true;
			this.comboBoxLanguage.Location = new System.Drawing.Point(16, 6);
			this.comboBoxLanguage.Name = "comboBoxLanguage";
			this.comboBoxLanguage.Size = new System.Drawing.Size(169, 21);
			this.comboBoxLanguage.TabIndex = 1;
			// 
			// checkBoxLineNumbers
			// 
			this.checkBoxLineNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxLineNumbers.AutoSize = true;
			this.checkBoxLineNumbers.Location = new System.Drawing.Point(132, 581);
			this.checkBoxLineNumbers.Name = "checkBoxLineNumbers";
			this.checkBoxLineNumbers.Size = new System.Drawing.Size(86, 17);
			this.checkBoxLineNumbers.TabIndex = 2;
			this.checkBoxLineNumbers.Text = "line numbers";
			this.checkBoxLineNumbers.UseVisualStyleBackColor = true;
			// 
			// checkBoxAlternateLineBackground
			// 
			this.checkBoxAlternateLineBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxAlternateLineBackground.AutoSize = true;
			this.checkBoxAlternateLineBackground.Location = new System.Drawing.Point(224, 581);
			this.checkBoxAlternateLineBackground.Name = "checkBoxAlternateLineBackground";
			this.checkBoxAlternateLineBackground.Size = new System.Drawing.Size(148, 17);
			this.checkBoxAlternateLineBackground.TabIndex = 3;
			this.checkBoxAlternateLineBackground.Text = "alternate line background";
			this.checkBoxAlternateLineBackground.UseVisualStyleBackColor = true;
			// 
			// timer1
			// 
			this.timer1.Interval = 2000;
			// 
			// checkBoxEmbedStyle
			// 
			this.checkBoxEmbedStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.checkBoxEmbedStyle.AutoSize = true;
			this.checkBoxEmbedStyle.Location = new System.Drawing.Point(13, 581);
			this.checkBoxEmbedStyle.Name = "checkBoxEmbedStyle";
			this.checkBoxEmbedStyle.Size = new System.Drawing.Size(113, 17);
			this.checkBoxEmbedStyle.TabIndex = 6;
			this.checkBoxEmbedStyle.Text = "Embed StyleSheet";
			this.checkBoxEmbedStyle.UseVisualStyleBackColor = true;
			// 
			// InsertCodeInsertForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(577, 607);
			this.Controls.Add(this.checkBoxEmbedStyle);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.checkBoxAlternateLineBackground);
			this.Controls.Add(this.checkBoxLineNumbers);
			this.Controls.Add(this.comboBoxLanguage);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinimumSize = new System.Drawing.Size(585, 0);
			this.Name = "InsertCodeInsertForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Insert Code";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
	}
}