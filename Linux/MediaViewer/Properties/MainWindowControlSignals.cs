using System;
using System.Collections.Generic;
using System.IO;
using Gtk;


public partial class MainWindow
{
	protected void btnBrowse_Clicked(object sender, EventArgs e)
	{
		Gtk.FileChooserDialog win = new FileChooserDialog("Choose a File", this, FileChooserAction.Open, "Cancel", ResponseType.Cancel, "Open", ResponseType.Accept);

		if (win.Run() == (int)ResponseType.Accept)
		{
			currentFile = new FileInfo(win.Filename);
			imgCenter.Clear();

			currentDirectory = currentFile.Directory;
			currentFileList = new List<FileInfo>();

			foreach (FileInfo f in currentDirectory.GetFiles())
			{
				currentFileList.Add(f);
			}

			for (int i = 0; i < currentFileList.Count; i++)
			{
				if (currentFileList[i].FullName == currentFile.FullName)
				{
					fileIndex = i;
					break;
				}
			}

			if (IsImage(currentFile.Extension) || IsVideo(currentFile.Extension) || IsGif(currentFile.Extension))
			{
				SetMedia(ref currentFile);
			}

			this.Title = currentFile.Name;

			win.Hide();
		}
	}

	protected void btnOptions_Clicked(object sender, EventArgs e)
	{

	}

	protected void btnZoomIn_Clicked(object sender, EventArgs e)
	{
		if (IsImage(currentFile.Extension))
		{
			imgCenter.Pixbuf = new Gdk.Pixbuf(currentFile.FullName, imgCenter.Pixbuf.Width + 30, imgCenter.Pixbuf.Height + 30);
		}
		else if (IsGif(currentFile.Extension))
		{
			
		}
	}

	protected void btnZoomOut_Clicked(object sender, EventArgs e)
	{
		if (IsImage(currentFile.Extension))
		{
			imgCenter.Pixbuf = new Gdk.Pixbuf(currentFile.FullName, imgCenter.Pixbuf.Width - 30, imgCenter.Pixbuf.Height - 30);
		}
		else if (IsGif(currentFile.Extension))
		{
			
		}
	}

	protected void scroll_ButtonPress(object o, ButtonPressEventArgs args)
	{
		if (args.Event.Button == 3 && args.Event.Type == Gdk.EventType.ButtonPress)
		{
			ResizeImage();
		}
	}

	protected void btnLeft_Clicked(object sender, EventArgs e)
	{
		FileInfo file = null;

		//prevent use before file loaded
		if ((!IsImageLoaded) && (!IsVideoLoaded))
		{
			return;
		}

		//keeps edge cases from skipping the for loop
		if (fileIndex - 1 < 0)
		{
			fileIndex += currentFileList.Count;
		}

		for (int i = fileIndex - 1; i < currentFileList.Count && i >= 0; i--)
		{
			file = currentFileList[i];

			if (i - 1 < 0)
			{
				i += currentFileList.Count;
			}

			//full loop through every file with no valid files
			if (i == fileIndex)
			{
				return;
			}

			if (IsValid(file.Extension))
			{
				fileIndex = i;


				SetMedia(ref file);

				this.Title = file.Name;

				return;
			}
		}
	}

	protected void btnRight_Clicked(object sender, EventArgs e)
	{
		FileInfo file = null;

		if ((!IsImageLoaded) && (!IsVideoLoaded))
		{
			return;
		}

		if (fileIndex + 1 >= currentFileList.Count)
		{
			fileIndex -= currentFileList.Count;
		}

		for (int i = fileIndex + 1; i < currentFileList.Count && i >= 0; i++)
		{
			file = currentFileList[i];

			if (i + 1 >= currentFileList.Count)
			{
				i -= currentFileList.Count;
			}

			//full loop through directory contents
			if (i == fileIndex)
			{
				return;
			}

			if (IsValid(file.Extension))
			{
				fileIndex = i;

				SetMedia(ref file);

				return;
			}
		}
	}
}

