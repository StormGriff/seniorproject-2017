
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;

	private global::Gtk.Action FileAction;

	private global::Gtk.Action newAction;

	private global::Gtk.Action openAction;

	private global::Gtk.Action saveAction;

	private global::Gtk.Action saveAsAction;

	private global::Gtk.Action ExitAction;

	private global::Gtk.Action EditAction;

	private global::Gtk.Action undoAction;

	private global::Gtk.Action copyAction;

	private global::Gtk.Action cutAction;

	private global::Gtk.Action pasteAction;

	private global::Gtk.Table table2;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TextView txtBox;

	private global::Gtk.MenuBar mnuBar;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup("Default");
		this.FileAction = new global::Gtk.Action("FileAction", global::Mono.Unix.Catalog.GetString("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString("file");
		w1.Add(this.FileAction, null);
		this.newAction = new global::Gtk.Action("newAction", global::Mono.Unix.Catalog.GetString("New"), null, "gtk-new");
		this.newAction.ShortLabel = global::Mono.Unix.Catalog.GetString("New");
		w1.Add(this.newAction, null);
		this.openAction = new global::Gtk.Action("openAction", global::Mono.Unix.Catalog.GetString("Open..."), null, "gtk-open");
		this.openAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Open...");
		w1.Add(this.openAction, null);
		this.saveAction = new global::Gtk.Action("saveAction", global::Mono.Unix.Catalog.GetString("Save"), null, "gtk-save");
		this.saveAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Save");
		w1.Add(this.saveAction, null);
		this.saveAsAction = new global::Gtk.Action("saveAsAction", global::Mono.Unix.Catalog.GetString("Save As..."), null, "gtk-save-as");
		this.saveAsAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Save As...");
		w1.Add(this.saveAsAction, null);
		this.ExitAction = new global::Gtk.Action("ExitAction", global::Mono.Unix.Catalog.GetString("Exit"), null, null);
		this.ExitAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Exit");
		w1.Add(this.ExitAction, null);
		this.EditAction = new global::Gtk.Action("EditAction", global::Mono.Unix.Catalog.GetString("Edit"), null, null);
		this.EditAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Edit");
		w1.Add(this.EditAction, null);
		this.undoAction = new global::Gtk.Action("undoAction", global::Mono.Unix.Catalog.GetString("Undo"), null, "gtk-undo");
		this.undoAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Undo");
		w1.Add(this.undoAction, null);
		this.copyAction = new global::Gtk.Action("copyAction", global::Mono.Unix.Catalog.GetString("Copy"), null, "gtk-copy");
		this.copyAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Copy");
		w1.Add(this.copyAction, null);
		this.cutAction = new global::Gtk.Action("cutAction", global::Mono.Unix.Catalog.GetString("Cut"), null, "gtk-cut");
		this.cutAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Cut");
		w1.Add(this.cutAction, null);
		this.pasteAction = new global::Gtk.Action("pasteAction", global::Mono.Unix.Catalog.GetString("Paste"), null, "gtk-paste");
		this.pasteAction.ShortLabel = global::Mono.Unix.Catalog.GetString("Paste");
		w1.Add(this.pasteAction, null);
		this.UIManager.InsertActionGroup(w1, 0);
		this.AddAccelGroup(this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.table2 = new global::Gtk.Table(((uint)(2)), ((uint)(1)), false);
		this.table2.Name = "table2";
		this.table2.RowSpacing = ((uint)(6));
		this.table2.ColumnSpacing = ((uint)(6));
		// Container child table2.Gtk.Table+TableChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.txtBox = new global::Gtk.TextView();
		this.txtBox.CanFocus = true;
		this.txtBox.Name = "txtBox";
		this.txtBox.WrapMode = ((global::Gtk.WrapMode)(2));
		this.GtkScrolledWindow.Add(this.txtBox);
		this.table2.Add(this.GtkScrolledWindow);
		global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table2[this.GtkScrolledWindow]));
		w3.TopAttach = ((uint)(1));
		w3.BottomAttach = ((uint)(2));
		w3.XOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table2.Gtk.Table+TableChild
		this.UIManager.AddUiFromString(@"<ui><menubar name='mnuBar'><menu name='FileAction' action='FileAction'><menuitem name='newAction' action='newAction'/><menuitem name='openAction' action='openAction'/><menuitem name='saveAction' action='saveAction'/><menuitem name='saveAsAction' action='saveAsAction'/><separator/><menuitem name='ExitAction' action='ExitAction'/></menu><menu name='EditAction' action='EditAction'><menuitem name='undoAction' action='undoAction'/><separator/><menuitem name='copyAction' action='copyAction'/><menuitem name='cutAction' action='cutAction'/><menuitem name='pasteAction' action='pasteAction'/></menu></menubar></ui>");
		this.mnuBar = ((global::Gtk.MenuBar)(this.UIManager.GetWidget("/mnuBar")));
		this.mnuBar.Name = "mnuBar";
		this.table2.Add(this.mnuBar);
		global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table2[this.mnuBar]));
		w4.YOptions = ((global::Gtk.AttachOptions)(4));
		this.Add(this.table2);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 645;
		this.DefaultHeight = 452;
		this.Show();
		this.newAction.Activated += new global::System.EventHandler(this.mnuNewActivated);
		this.openAction.Activated += new global::System.EventHandler(this.mnuOpenActivated);
		this.saveAction.Activated += new global::System.EventHandler(this.mnuSaveActivated);
		this.saveAsAction.Activated += new global::System.EventHandler(this.mnuSaveAsActivated);
		this.ExitAction.Activated += new global::System.EventHandler(this.mnuExitActivate);
		this.undoAction.Activated += new global::System.EventHandler(this.mnuUndoActivated);
		this.copyAction.Activated += new global::System.EventHandler(this.txtCopyClipboard);
		this.cutAction.Activated += new global::System.EventHandler(this.txtCutClipboard);
		this.pasteAction.Activated += new global::System.EventHandler(this.txtPasteClipboard);
		this.txtBox.CutClipboard += new global::System.EventHandler(this.txtCutClipboard);
		this.txtBox.CopyClipboard += new global::System.EventHandler(this.txtCopyClipboard);
		this.txtBox.PasteClipboard += new global::System.EventHandler(this.txtPasteClipboard);
	}
}
