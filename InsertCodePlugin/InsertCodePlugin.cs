using System;
using System.Windows.Forms;
using WindowsLive.Writer.Api;

namespace InsertCodePlugin
{
	[WriterPlugin("20EBE225-94E1-462f-BB68-04E7D24E632D", "Code",
		Description = "Insert Code in your blog posts.",
		PublisherUrl = "https://github.com/JeremySkinner/InsertCode",
		ImagePath = "Images.InsertCode.png")]
	[InsertableContentSource("Code")]
	public class InsertCodePlugin : SmartContentSource
	{
		/*public override DialogResult CreateContent(IWin32Window dialogOwner, ref string newContent)
		{
			var insertForm = new InsertCodeInsertForm();

			using (insertForm)
			{
				var result = insertForm.ShowDialog();

				if (result == DialogResult.OK)
				{
					newContent = insertForm.Code;
				}

				return result;
			}
		}*/

		public override DialogResult CreateContent(IWin32Window dialogOwner, ISmartContent newContent) {
			var settings = new Settings(newContent.Properties);

			using (var insertForm = new InsertCodeInsertForm()) {
				var result = insertForm.ShowDialog();

				if (result == DialogResult.OK) {
					settings.UpdateFromForm(insertForm);
				}

				return result;
			}
		}

		public override string GeneratePublishHtml(ISmartContent content, IPublishingContext publishingContext)
		{
			var settings = new Settings(content.Properties);
			return settings.Format.FormatCode(settings.SourceCode, embedStylesheet: settings.EmbedStylesheet, alternate: settings.HighlightAlternateLines, lineNumbers: settings.ShowLineNumbers);
		}

		public override string GenerateEditorHtml(ISmartContent content, IPublishingContext publishingContext) 
		{
			var settings = new Settings(content.Properties);
			// Always want to embed stylesheet for editor markup.
			return settings.Format.FormatCode(settings.SourceCode, embedStylesheet: true, alternate: settings.HighlightAlternateLines, lineNumbers: settings.ShowLineNumbers);
		}

		public override SmartContentEditor CreateEditor(ISmartContentEditorSite editorSite)
		{
			return new PluginContentEditor();
		}

	}
}