using System;
using System.Collections.Generic;
using System.IO;
using Gtk;

public partial class MainWindow : Gtk.Window
{
	DirectoryInfo currentDirectory;
	List<FileInfo> currentFileList;
	FileInfo currentFile;
	int originalFileWidth;
	int originalFileHeight;
	int fileIndex;
	bool IsImageLoaded;
	bool IsVideoLoaded;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		IsImageLoaded = false;
		IsVideoLoaded = false;

		Build();

		originalFileWidth = 0;
		originalFileHeight = 0;
		currentFileList = new List<FileInfo>();
	}

	private void SetMedia(ref FileInfo file)
	{
		if (IsImage(file.Extension))
		{
			imgCenter.Pixbuf = new Gdk.Pixbuf(file.FullName);
			currentFile = file;

			ResizeImage();

			IsImageLoaded = true;
			IsVideoLoaded = false; 
		}
		else if (IsGif(file.Extension))
		{
			imgCenter.Pixbuf = null;
			imgCenter.PixbufAnimation = new Gdk.PixbufAnimation(file.FullName);

			currentFile = file;

			ResizeImage();

			IsImageLoaded = true;
			IsVideoLoaded = false; 
		}
	}

	private void SetMedia(string filepath)
	{
		FileInfo file = new FileInfo(filepath);

		if (IsImage(file.Extension))
		{
			imgCenter.Pixbuf = new Gdk.Pixbuf(file.FullName);
			currentFile = file;

			ResizeImage();

			IsImageLoaded = true;
			IsVideoLoaded = false;
		}
		else if (IsGif(file.Extension))
		{
			imgCenter.Pixbuf = null;
			imgCenter.PixbufAnimation = new Gdk.PixbufAnimation(file.FullName);

			currentFile = file;

			ResizeImage();

			IsImageLoaded = true;
			IsVideoLoaded = false;
		}


		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
	}

	private bool IsValid(string extension)
	{
		if (IsImage(extension))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private bool IsImage(string extension)
	{
		if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".tif" || extension == ".bmp")
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private bool IsGif(string extension)
	{
		if (extension == ".gif")
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private bool IsVideo(string extension)
	{
		if (extension == ".webm" || extension == ".mp4" || extension == ".aac" || extension == ".ffv1" || extension == ".wmv" || extension == ".h264")
		{
			return true;
		}
		else
		{
			return false;
		}	 }

	private void ResizeImage(/*int width, int height*/)
	{
		if (originalFileWidth > originalFileHeight)
		{
			if (imgCenter.Pixbuf != null)
			{
				int newWidth, newHeight;
				int height = imgCenter.Pixbuf.Height;
				int width = imgCenter.Pixbuf.Width;

				Gdk.Region visibleRegion = imgCenter.GdkWindow.VisibleRegion;
				Gdk.Rectangle rectangle = visibleRegion.GetRectangles()[0];
				newHeight = rectangle.Height;
				newWidth = rectangle.Width;
				imgCenter.Pixbuf = new Gdk.Pixbuf(currentFile.FullName, newWidth, newHeight);
			}

			//double scaleFactor = width / originalFileWidth;
			//int newWidth = width;
			//int newHeight = (int)Math.Truncate(scaleFactor * originalFileHeight);

			//if (imgCenter.Pixbuf == null)
			//	return;
			//imgCenter.Pixbuf = imgCenter.Pixbuf.ScaleSimple(newWidth, newHeight, Gdk.InterpType.Bilinear);
		}
		else
		{
			if (imgCenter.Pixbuf != null)
			{
				int newWidth, newHeight;
				int height = imgCenter.Pixbuf.Height;
				int width = imgCenter.Pixbuf.Width;

				Gdk.Region visibleRegion = imgCenter.GdkWindow.VisibleRegion;
				Gdk.Rectangle rectangle = visibleRegion.GetRectangles()[0];
				newHeight = rectangle.Height;
				newWidth = rectangle.Width;
				imgCenter.Pixbuf = new Gdk.Pixbuf(currentFile.FullName, newWidth, newHeight);
			}

			//double scaleFactor = (double)height / (double)originalFileHeight;
			//int newWidth = (int)Math.Truncate(scaleFactor * originalFileWidth);
			//int newHeight = height;

			//if (imgCenter.Pixbuf == null)
			//	return;
			//imgCenter.Pixbuf = imgCenter.Pixbuf.ScaleSimple(newWidth, newHeight, Gdk.InterpType.Bilinear);
		}
	}

	protected override bool OnConfigureEvent(Gdk.EventConfigure evnt)
	{
		
		Title = evnt.Width + ", " + evnt.Height;
		//ResizeImage(/*evnt.Width, evnt.Height*/);

		return base.OnConfigureEvent(evnt);
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}


}
