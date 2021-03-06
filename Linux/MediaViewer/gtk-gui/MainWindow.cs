
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.Table table1;

	private global::Gtk.Alignment alignment1;

	private global::Gtk.Table tblControls;

	private global::Gtk.Button btnFullscreen;

	private global::Gtk.Button btnLeft;

	private global::Gtk.Button btnRight;

	private global::Gtk.Table table4;

	private global::Gtk.Button btnBrowse;

	private global::Gtk.Button btnOptions;

	private global::Gtk.Table table5;

	private global::Gtk.Button btnZoomIn;

	private global::Gtk.Button btnZoomOut;

	private global::Gtk.ScrolledWindow scrolledwindow1;

	private global::Gtk.Image imgCenter;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(1)), false);
		this.table1.Name = "table1";
		this.table1.RowSpacing = ((uint)(6));
		this.table1.ColumnSpacing = ((uint)(6));
		// Container child table1.Gtk.Table+TableChild
		this.alignment1 = new global::Gtk.Alignment(0.5F, 0.5F, 1F, 1F);
		this.alignment1.Name = "alignment1";
		// Container child alignment1.Gtk.Container+ContainerChild
		this.tblControls = new global::Gtk.Table(((uint)(1)), ((uint)(5)), false);
		this.tblControls.Name = "tblControls";
		this.tblControls.RowSpacing = ((uint)(1));
		this.tblControls.ColumnSpacing = ((uint)(1));
		// Container child tblControls.Gtk.Table+TableChild
		this.btnFullscreen = new global::Gtk.Button();
		this.btnFullscreen.WidthRequest = 60;
		this.btnFullscreen.HeightRequest = 60;
		this.btnFullscreen.CanFocus = true;
		this.btnFullscreen.Name = "btnFullscreen";
		this.btnFullscreen.UseUnderline = true;
		this.btnFullscreen.Label = global::Mono.Unix.Catalog.GetString("FS");
		global::Gtk.Image w1 = new global::Gtk.Image();
		this.btnFullscreen.Image = w1;
		this.tblControls.Add(this.btnFullscreen);
		global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.tblControls[this.btnFullscreen]));
		w2.LeftAttach = ((uint)(2));
		w2.RightAttach = ((uint)(3));
		w2.XOptions = ((global::Gtk.AttachOptions)(4));
		w2.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child tblControls.Gtk.Table+TableChild
		this.btnLeft = new global::Gtk.Button();
		this.btnLeft.WidthRequest = 60;
		this.btnLeft.HeightRequest = 60;
		this.btnLeft.CanFocus = true;
		this.btnLeft.Name = "btnLeft";
		this.btnLeft.UseUnderline = true;
		this.btnLeft.Label = global::Mono.Unix.Catalog.GetString("<");
		global::Gtk.Image w3 = new global::Gtk.Image();
		this.btnLeft.Image = w3;
		this.tblControls.Add(this.btnLeft);
		global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.tblControls[this.btnLeft]));
		w4.XOptions = ((global::Gtk.AttachOptions)(4));
		w4.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child tblControls.Gtk.Table+TableChild
		this.btnRight = new global::Gtk.Button();
		this.btnRight.WidthRequest = 60;
		this.btnRight.HeightRequest = 60;
		this.btnRight.CanFocus = true;
		this.btnRight.Name = "btnRight";
		this.btnRight.UseUnderline = true;
		this.btnRight.Label = global::Mono.Unix.Catalog.GetString(">");
		global::Gtk.Image w5 = new global::Gtk.Image();
		this.btnRight.Image = w5;
		this.tblControls.Add(this.btnRight);
		global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.tblControls[this.btnRight]));
		w6.LeftAttach = ((uint)(4));
		w6.RightAttach = ((uint)(5));
		w6.XOptions = ((global::Gtk.AttachOptions)(4));
		w6.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child tblControls.Gtk.Table+TableChild
		this.table4 = new global::Gtk.Table(((uint)(2)), ((uint)(1)), false);
		this.table4.Name = "table4";
		this.table4.RowSpacing = ((uint)(6));
		this.table4.ColumnSpacing = ((uint)(6));
		// Container child table4.Gtk.Table+TableChild
		this.btnBrowse = new global::Gtk.Button();
		this.btnBrowse.WidthRequest = 30;
		this.btnBrowse.HeightRequest = 30;
		this.btnBrowse.CanFocus = true;
		this.btnBrowse.Name = "btnBrowse";
		this.btnBrowse.UseUnderline = true;
		this.btnBrowse.Label = global::Mono.Unix.Catalog.GetString("B");
		global::Gtk.Image w7 = new global::Gtk.Image();
		this.btnBrowse.Image = w7;
		this.table4.Add(this.btnBrowse);
		global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table4[this.btnBrowse]));
		w8.XOptions = ((global::Gtk.AttachOptions)(4));
		w8.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table4.Gtk.Table+TableChild
		this.btnOptions = new global::Gtk.Button();
		this.btnOptions.WidthRequest = 30;
		this.btnOptions.HeightRequest = 30;
		this.btnOptions.CanFocus = true;
		this.btnOptions.Name = "btnOptions";
		this.btnOptions.UseUnderline = true;
		this.btnOptions.Label = global::Mono.Unix.Catalog.GetString("O");
		global::Gtk.Image w9 = new global::Gtk.Image();
		this.btnOptions.Image = w9;
		this.table4.Add(this.btnOptions);
		global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table4[this.btnOptions]));
		w10.TopAttach = ((uint)(1));
		w10.BottomAttach = ((uint)(2));
		w10.XOptions = ((global::Gtk.AttachOptions)(4));
		w10.YOptions = ((global::Gtk.AttachOptions)(4));
		this.tblControls.Add(this.table4);
		global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.tblControls[this.table4]));
		w11.LeftAttach = ((uint)(1));
		w11.RightAttach = ((uint)(2));
		w11.XOptions = ((global::Gtk.AttachOptions)(4));
		w11.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child tblControls.Gtk.Table+TableChild
		this.table5 = new global::Gtk.Table(((uint)(2)), ((uint)(1)), false);
		this.table5.Name = "table5";
		this.table5.RowSpacing = ((uint)(6));
		this.table5.ColumnSpacing = ((uint)(6));
		// Container child table5.Gtk.Table+TableChild
		this.btnZoomIn = new global::Gtk.Button();
		this.btnZoomIn.WidthRequest = 30;
		this.btnZoomIn.HeightRequest = 30;
		this.btnZoomIn.CanFocus = true;
		this.btnZoomIn.Name = "btnZoomIn";
		this.btnZoomIn.UseUnderline = true;
		this.btnZoomIn.Label = global::Mono.Unix.Catalog.GetString("+");
		global::Gtk.Image w12 = new global::Gtk.Image();
		this.btnZoomIn.Image = w12;
		this.table5.Add(this.btnZoomIn);
		global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table5[this.btnZoomIn]));
		w13.XOptions = ((global::Gtk.AttachOptions)(4));
		w13.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table5.Gtk.Table+TableChild
		this.btnZoomOut = new global::Gtk.Button();
		this.btnZoomOut.WidthRequest = 30;
		this.btnZoomOut.HeightRequest = 30;
		this.btnZoomOut.CanFocus = true;
		this.btnZoomOut.Name = "btnZoomOut";
		this.btnZoomOut.UseUnderline = true;
		this.btnZoomOut.Label = global::Mono.Unix.Catalog.GetString("-");
		global::Gtk.Image w14 = new global::Gtk.Image();
		this.btnZoomOut.Image = w14;
		this.table5.Add(this.btnZoomOut);
		global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table5[this.btnZoomOut]));
		w15.TopAttach = ((uint)(1));
		w15.BottomAttach = ((uint)(2));
		w15.XOptions = ((global::Gtk.AttachOptions)(4));
		w15.YOptions = ((global::Gtk.AttachOptions)(4));
		this.tblControls.Add(this.table5);
		global::Gtk.Table.TableChild w16 = ((global::Gtk.Table.TableChild)(this.tblControls[this.table5]));
		w16.LeftAttach = ((uint)(3));
		w16.RightAttach = ((uint)(4));
		w16.XOptions = ((global::Gtk.AttachOptions)(4));
		w16.YOptions = ((global::Gtk.AttachOptions)(4));
		this.alignment1.Add(this.tblControls);
		this.table1.Add(this.alignment1);
		global::Gtk.Table.TableChild w18 = ((global::Gtk.Table.TableChild)(this.table1[this.alignment1]));
		w18.TopAttach = ((uint)(1));
		w18.BottomAttach = ((uint)(2));
		w18.XOptions = ((global::Gtk.AttachOptions)(1));
		w18.YOptions = ((global::Gtk.AttachOptions)(4));
		// Container child table1.Gtk.Table+TableChild
		this.scrolledwindow1 = new global::Gtk.ScrolledWindow();
		this.scrolledwindow1.CanFocus = true;
		this.scrolledwindow1.Name = "scrolledwindow1";
		this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child scrolledwindow1.Gtk.Container+ContainerChild
		global::Gtk.Viewport w19 = new global::Gtk.Viewport();
		w19.ShadowType = ((global::Gtk.ShadowType)(0));
		// Container child GtkViewport.Gtk.Container+ContainerChild
		this.imgCenter = new global::Gtk.Image();
		this.imgCenter.Name = "imgCenter";
		w19.Add(this.imgCenter);
		this.scrolledwindow1.Add(w19);
		this.table1.Add(this.scrolledwindow1);
		global::Gtk.Table.TableChild w22 = ((global::Gtk.Table.TableChild)(this.table1[this.scrolledwindow1]));
		w22.XOptions = ((global::Gtk.AttachOptions)(4));
		this.Add(this.table1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 400;
		this.DefaultHeight = 300;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
		this.scrolledwindow1.ButtonPressEvent += new global::Gtk.ButtonPressEventHandler(this.scroll_ButtonPress);
		this.btnZoomOut.Clicked += new global::System.EventHandler(this.btnZoomOut_Clicked);
		this.btnZoomIn.Clicked += new global::System.EventHandler(this.btnZoomIn_Clicked);
		this.btnOptions.Clicked += new global::System.EventHandler(this.btnOptions_Clicked);
		this.btnBrowse.Clicked += new global::System.EventHandler(this.btnBrowse_Clicked);
		this.btnRight.Clicked += new global::System.EventHandler(this.btnRight_Clicked);
		this.btnLeft.Clicked += new global::System.EventHandler(this.btnLeft_Clicked);
	}
}
