using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	private string file;
	private bool isTextChanged;
	private Gtk.Clipboard clipboard;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		file = null;
		isTextChanged = false;

		txtBox.Buffer.Changed += new EventHandler(onTextChangedEvent);
	}


	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void mnuExitActivate(object sender, EventArgs e)
	{
		Gtk.Main.Quit();
	}

	protected void mnuNewActivated(object sender, EventArgs e)
	{
		this.txtBox.Buffer.Text = "";
		this.file = "";
	}

	protected void mnuOpenActivated(object sender, EventArgs e)
	{
		Gtk.FileChooserDialog win = new FileChooserDialog("Choose a File", this, FileChooserAction.Open, "Cancel", ResponseType.Cancel, "Open", ResponseType.Accept);

		if (win.Run() == (int)ResponseType.Accept)
		{
			System.IO.FileStream fs = new System.IO.FileStream(win.Filename, System.IO.FileMode.Open);
			System.IO.StreamReader sr = new System.IO.StreamReader(fs);
			this.file = win.Filename;

			System.IO.FileInfo file = new System.IO.FileInfo(this.file);
			if (file.Extension == ".txt")
			{
				txtBox.Buffer.Text = sr.ReadToEnd();
			}

			fs.Close();
			sr.Close();

			isTextChanged = false;
		}

		win.Hide();
	}

	protected void mnuSaveActivated(object sender, EventArgs e)
	{
		if (isTextChanged)
		{
			if (file == null)
			{
				mnuSaveAsActivated(sender, e);
			}
			else
			{
				System.IO.FileStream fs = new System.IO.FileStream(this.file, System.IO.FileMode.Open);
				System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);

				sw.Write(txtBox.Buffer.Text);
				sw.Flush();

				isTextChanged = false;

				sw.Close();
				fs.Close();
			}
		}
	}

	protected void mnuSaveAsActivated(object sender, EventArgs e)
	{
		if (isTextChanged)
		{
			Gtk.FileChooserDialog win = new FileChooserDialog("Save File", this, FileChooserAction.Save, "Cancel", ResponseType.Cancel, "Save", ResponseType.Accept);

			if (win.Run() == (int)ResponseType.Accept)
			{
				System.IO.FileStream fs = new System.IO.FileStream(win.Filename, System.IO.FileMode.OpenOrCreate);
				System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
				this.file = win.Filename;

				sw.Write(txtBox.Buffer.Text);
				sw.Flush();

				sw.Close();
				fs.Close();

				isTextChanged = false;
			}

			win.Hide();
		}
	}

	void onTextChangedEvent(object sender, EventArgs e)
	{
		isTextChanged = true;
	}

	protected void mnuUndoActivated(object sender, EventArgs e)
	{
		
	}

	protected void txtCutClipboard(object sender, EventArgs e)
	{
		txtBox.Buffer.CutClipboard(clipboard, true);
	}

	protected void txtCopyClipboard(object sender, EventArgs e)
	{
		txtBox.Buffer.CopyClipboard(clipboard);
	}

	protected void txtPasteClipboard(object sender, EventArgs e)
	{
		try
		{
			txtBox.Buffer.PasteClipboard(clipboard);
		}
		catch (Exception ex)
		{
			MessageDialog dia = new MessageDialog(this, DialogFlags.NoSeparator, MessageType.Error, ButtonsType.Close, "", null);
			dia.Text = ex.Message;
			dia.Show();

		}
	}
}
