using System.Text;
using InsertCodePlugin.CSharpFormat;
using WindowsLive.Writer.Api;

namespace InsertCodePlugin
{
	public class Settings {
		IProperties props;

		public Settings(IProperties props) {
			this.props = props;
		}

		public SourceFormat Format {
			get {
				var formatName = props.GetString("__Language", string.Empty);
				return FormatFactory.GetFormat(formatName);
			}
			set {
				props.SetString("__Language", value.Name);
			}
		}

		public string SourceCode {
			get {
				return props.GetString("__Source", string.Empty);
			}
			set {
				props.SetString("__Source", value);
			}
		}

		public bool ShowLineNumbers
		{
			get { return props.GetBoolean("__ShowLineNumbers", false); }
			set { props.SetBoolean("__ShowLineNumbers", value); }
		}

		public bool HighlightAlternateLines
		{
			get { return props.GetBoolean("__AlternateLines", false); }
			set { props.SetBoolean("__AlternateLines",value); }
		}

		public bool EmbedStylesheet
		{
			get { return props.GetBoolean("__Embed", false); }
			set { props.SetBoolean("__Embed", value); }
		}

		public void UpdateFromForm(InsertCodeInsertForm form)
		{
			EmbedStylesheet = form.EmbedStylesheet;
			HighlightAlternateLines = form.HighlightAlternateLines;
			ShowLineNumbers = form.ShowLineNumbers;
			SourceCode = form.RawCode;
			Format = form.Format;
		}

		public void CopyToForm(InsertCodeInsertForm form)
		{
			form.Format = Format;
			form.RawCode = SourceCode;
			form.EmbedStylesheet = EmbedStylesheet;
			form.HighlightAlternateLines = HighlightAlternateLines;
			form.ShowLineNumbers = ShowLineNumbers;
		}
	}
}