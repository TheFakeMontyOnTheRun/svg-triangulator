
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action OpenSVGAction;
	private global::Gtk.Action saveTriangulatedAsSVGAction;
	private global::Gtk.Action saveTriangulatedAsBinaryAction;
	private global::Gtk.Action FileAction;
	private global::Gtk.Action OpenSVGToolbarAction;
	private global::Gtk.Action SaveAsTriangulatedSVGAction;
	private global::Gtk.Action SaveTriangularedAsBinaryAction;
	private global::Gtk.Action QuitAction;
	private global::Gtk.Action HelpAction;
	private global::Gtk.Action ShowAboutDialogAction;
	private global::Gtk.Action ImportTriangulatedBinaryDecal;
	private global::Gtk.Action saveAsAction;
	private global::Gtk.Action saveAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar1;
	private global::Gtk.Toolbar toolbar1;
	private global::Gtk.HBox hbox1;
	private global::DecalTools.IsoDecalView isoDecalView;
	private global::Gtk.VBox vbox3;
	private global::Gtk.SpinButton spnDepth;
	private global::Gtk.ComboBox cboShapes;
	private global::Gtk.ComboBox combobox1;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.OpenSVGAction = new global::Gtk.Action ("OpenSVGAction", null, null, "gtk-open");
		w1.Add (this.OpenSVGAction, null);
		this.saveTriangulatedAsSVGAction = new global::Gtk.Action ("saveTriangulatedAsSVGAction", null, null, "gtk-floppy");
		this.saveTriangulatedAsSVGAction.Sensitive = false;
		w1.Add (this.saveTriangulatedAsSVGAction, null);
		this.saveTriangulatedAsBinaryAction = new global::Gtk.Action ("saveTriangulatedAsBinaryAction", null, null, "gtk-convert");
		this.saveTriangulatedAsBinaryAction.Sensitive = false;
		w1.Add (this.saveTriangulatedAsBinaryAction, null);
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
		this.OpenSVGToolbarAction = new global::Gtk.Action ("OpenSVGToolbarAction", global::Mono.Unix.Catalog.GetString ("Open"), null, "gtk-open");
		this.OpenSVGToolbarAction.IsImportant = true;
		this.OpenSVGToolbarAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Open");
		w1.Add (this.OpenSVGToolbarAction, "o");
		this.SaveAsTriangulatedSVGAction = new global::Gtk.Action ("SaveAsTriangulatedSVGAction", global::Mono.Unix.Catalog.GetString ("Save triangulated as SVG"), null, "gtk-save-as");
		this.SaveAsTriangulatedSVGAction.IsImportant = true;
		this.SaveAsTriangulatedSVGAction.Sensitive = false;
		this.SaveAsTriangulatedSVGAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Save triangulated as SVG");
		w1.Add (this.SaveAsTriangulatedSVGAction, "s");
		this.SaveTriangularedAsBinaryAction = new global::Gtk.Action ("SaveTriangularedAsBinaryAction", global::Mono.Unix.Catalog.GetString ("Save triangulated as binary"), null, "gtk-save-as");
		this.SaveTriangularedAsBinaryAction.IsImportant = true;
		this.SaveTriangularedAsBinaryAction.Sensitive = false;
		this.SaveTriangularedAsBinaryAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Save triangulated as binary");
		w1.Add (this.SaveTriangularedAsBinaryAction, null);
		this.QuitAction = new global::Gtk.Action ("QuitAction", global::Mono.Unix.Catalog.GetString ("Quit"), null, "gtk-quit");
		this.QuitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Quit");
		w1.Add (this.QuitAction, null);
		this.HelpAction = new global::Gtk.Action ("HelpAction", global::Mono.Unix.Catalog.GetString ("Help"), null, null);
		this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Help");
		w1.Add (this.HelpAction, null);
		this.ShowAboutDialogAction = new global::Gtk.Action ("ShowAboutDialogAction", global::Mono.Unix.Catalog.GetString ("About"), null, "gtk-help");
		this.ShowAboutDialogAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("About");
		w1.Add (this.ShowAboutDialogAction, null);
		this.ImportTriangulatedBinaryDecal = new global::Gtk.Action ("ImportTriangulatedBinaryDecal", global::Mono.Unix.Catalog.GetString ("Import triangulated binary decal"), null, "gtk-convert");
		this.ImportTriangulatedBinaryDecal.ShortLabel = global::Mono.Unix.Catalog.GetString ("Import triangulated binary decal");
		w1.Add (this.ImportTriangulatedBinaryDecal, null);
		this.saveAsAction = new global::Gtk.Action ("saveAsAction", global::Mono.Unix.Catalog.GetString ("Save as..."), null, "gtk-save-as");
		this.saveAsAction.Sensitive = false;
		this.saveAsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Save with depths as SVG");
		w1.Add (this.saveAsAction, null);
		this.saveAction = new global::Gtk.Action ("saveAction", global::Mono.Unix.Catalog.GetString ("Save"), null, "gtk-save");
		this.saveAction.Sensitive = false;
		this.saveAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Save");
		w1.Add (this.saveAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='OpenSVGToolbarAction' action='OpenSVGToolbarAction'/><menuitem name='ImportTriangulatedBinaryDecal' action='ImportTriangulatedBinaryDecal'/><menuitem name='saveAction' action='saveAction'/><menuitem name='saveAsAction' action='saveAsAction'/><menuitem name='SaveAsTriangulatedSVGAction' action='SaveAsTriangulatedSVGAction'/><menuitem name='SaveTriangularedAsBinaryAction' action='SaveTriangularedAsBinaryAction'/><menuitem name='QuitAction' action='QuitAction'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='ShowAboutDialogAction' action='ShowAboutDialogAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><toolbar name='toolbar1'><toolitem name='OpenSVGAction' action='OpenSVGAction'/><toolitem name='saveTriangulatedAsSVGAction' action='saveTriangulatedAsSVGAction'/><toolitem name='saveTriangulatedAsBinaryAction' action='saveTriangulatedAsBinaryAction'/></toolbar></ui>");
		this.toolbar1 = ((global::Gtk.Toolbar)(this.UIManager.GetWidget ("/toolbar1")));
		this.toolbar1.Name = "toolbar1";
		this.toolbar1.ShowArrow = false;
		this.vbox1.Add (this.toolbar1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.toolbar1]));
		w3.Position = 1;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.isoDecalView = new global::DecalTools.IsoDecalView ();
		this.isoDecalView.WidthRequest = 800;
		this.isoDecalView.HeightRequest = 480;
		this.isoDecalView.Name = "isoDecalView";
		this.hbox1.Add (this.isoDecalView);
		global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.isoDecalView]));
		w4.Position = 0;
		w4.Expand = false;
		w4.Fill = false;
		// Container child hbox1.Gtk.Box+BoxChild
		this.vbox3 = new global::Gtk.VBox ();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.spnDepth = new global::Gtk.SpinButton (0, 100, 1);
		this.spnDepth.Sensitive = false;
		this.spnDepth.CanFocus = true;
		this.spnDepth.Name = "spnDepth";
		this.spnDepth.Adjustment.PageIncrement = 10;
		this.spnDepth.ClimbRate = 1;
		this.spnDepth.Numeric = true;
		this.vbox3.Add (this.spnDepth);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.spnDepth]));
		w5.Position = 0;
		w5.Expand = false;
		w5.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.cboShapes = global::Gtk.ComboBox.NewText ();
		this.cboShapes.Sensitive = false;
		this.cboShapes.Name = "cboShapes";
		this.vbox3.Add (this.cboShapes);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.cboShapes]));
		w6.Position = 1;
		w6.Expand = false;
		w6.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.combobox1 = global::Gtk.ComboBox.NewText ();
		this.combobox1.Name = "combobox1";
		this.vbox3.Add (this.combobox1);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.combobox1]));
		w7.Position = 2;
		w7.Expand = false;
		w7.Fill = false;
		this.hbox1.Add (this.vbox3);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox3]));
		w8.Position = 1;
		w8.Expand = false;
		w8.Fill = false;
		this.vbox1.Add (this.hbox1);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
		w9.Position = 2;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 947;
		this.DefaultHeight = 570;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.ScrollEvent += new global::Gtk.ScrollEventHandler (this.OnScrollEvent);
		this.OpenSVGAction.Activated += new global::System.EventHandler (this.OnOpenActionActivated);
		this.saveTriangulatedAsSVGAction.Activated += new global::System.EventHandler (this.OnSaveTriangulatedAsSVGActionActivated);
		this.saveTriangulatedAsBinaryAction.Activated += new global::System.EventHandler (this.OnSaveTriangulatedAsBinaryActionActivated);
		this.OpenSVGToolbarAction.Activated += new global::System.EventHandler (this.OnOpenActionActivated);
		this.SaveAsTriangulatedSVGAction.Activated += new global::System.EventHandler (this.OnSaveTriangulatedAsSVGActionActivated);
		this.SaveTriangularedAsBinaryAction.Activated += new global::System.EventHandler (this.OnSaveTriangulatedAsBinaryActionActivated);
		this.QuitAction.Activated += new global::System.EventHandler (this.OnQuitActionActivated);
		this.ShowAboutDialogAction.Activated += new global::System.EventHandler (this.OnHelpActionActivated);
		this.ImportTriangulatedBinaryDecal.Activated += new global::System.EventHandler (this.OnImportTriangulatedBinaryDecalActivated);
		this.saveAsAction.Activated += new global::System.EventHandler (this.OnSaveWithDepthsAsSVGActivated);
		this.saveAction.Activated += new global::System.EventHandler (this.OnSaveActionActivated);
		this.isoDecalView.ScrollEvent += new global::Gtk.ScrollEventHandler (this.OnIsoDecalViewScrollEvent);
		this.spnDepth.ChangeValue += new global::Gtk.ChangeValueHandler (this.OnSpnDepthChangeValue);
		this.spnDepth.ValueChanged += new global::System.EventHandler (this.OnSpnDepthValueChanged);
		this.cboShapes.Changed += new global::System.EventHandler (this.OnCboShapesChanged);
	}
}
