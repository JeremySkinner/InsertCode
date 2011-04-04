using System.Drawing;
using System.Windows.Forms;
using WindowsLive.Writer.Api;

namespace InsertCodePlugin
{
	public class PluginContentEditor : SmartContentEditor
	{
		private LinkLabel editCodeLink;

		public PluginContentEditor()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			this.editCodeLink = new LinkLabel();
			this.SuspendLayout();
			// 
			// editCodeLink
			// 
			this.editCodeLink.AutoSize = true;
			this.editCodeLink.Location = new Point(3, 10);
			this.editCodeLink.Name = "editCodeLink";
			this.editCodeLink.Size = new Size(53, 13);
			this.editCodeLink.TabIndex = 1;
			this.editCodeLink.TabStop = true;
			this.editCodeLink.Text = "Edit Code";
			this.editCodeLink.LinkClicked += this.editCodeLink_LinkClicked;
			// 
			// PluginContentEditor
			// 
			this.Controls.Add(this.editCodeLink);
			this.Name = "PluginContentEditor";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private void editCodeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var settings = new Settings(SelectedContent.Properties);

			using (var insertForm = new InsertCodeInsertForm()) {
				settings.CopyToForm(insertForm);
				var result = insertForm.ShowDialog();

				if (result == DialogResult.OK) {
					settings.UpdateFromForm(insertForm);
				}

				OnContentEdited();
			}
		}
	}
}