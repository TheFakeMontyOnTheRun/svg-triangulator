using System;
using Gtk;
using System.Collections;
using System.Xml;


public partial class MainWindow: Gtk.Window
{	
	String currentFilename = "No file selected";
	bool modified = false;
	ArrayList shapes;
	public static int selected;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		updateTitleBar();
	}
	
	public void updateTitleBar() {
		
		String newTitle = "DecalTools - ";
		
		if ( modified )
			newTitle += "[modified] ";
		
		newTitle += currentFilename;
		
		this.Title = newTitle;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnBtnOpenClicked (object sender, EventArgs e)
	{



	}

	public ArrayList readSVG (String path)
	{
		ArrayList toReturn = new ArrayList ();

		java.util.ArrayList parsedPolys;
		parsedPolys = SVGTriangulate.SVGTriangulateUtils.readSVG (path);

		for (int c = 0; c < parsedPolys.size(); ++c) {

			br.odb.libsvg.ColoredPolygon poly = ( br.odb.libsvg.ColoredPolygon ) parsedPolys.get ( c );
			DecalTools.Shape shape = new DecalTools.Shape( poly, "path " + c );
			
			toReturn.Add( shape );
		}


		return toReturn;
	}

	public void updateComboBox ()
	{
		CellRendererText cell;
		ListStore store;
		
		cboShapes.Clear();

		cell = new CellRendererText();
		cboShapes.PackStart(cell, false );
		cboShapes.AddAttribute(cell, "text", 0);
		store = new ListStore(typeof (string));
		cboShapes.Model = store;

		for ( int c = 0; c < shapes.Count; ++c ) {
				
			store.AppendValues ( ( ( DecalTools.Shape ) shapes[ c ] ).getName() );
		}


		if ( shapes.Count > 0 ) 
			cboShapes.Active = 0;

	}

	protected void OnBtnTriangulateAndSaveClicked (object sender, EventArgs e)
	{


	}

	protected void OnBtnExitClicked (object sender, EventArgs e)
	{
		this.onQuitApp();
	}

	protected void OnSpnDepthChangeValue (object o, ChangeValueArgs args)
	{
	
	}

	protected void OnCboShapesChanged (object sender, EventArgs e)
	{
		DecalTools.Shape shape = ( DecalTools.Shape ) shapes[ cboShapes.Active ];
		spnDepth.Value = shape.getZ();
		selected = this.cboShapes.Active;
		QueueDraw();
	}

	protected void OnSpnDepthValueChanged (object sender, EventArgs e)
	{
		
		setZAs( ( byte ) spnDepth.Value );
	}
	
	public void setZAs( byte Z ) 
	{
		DecalTools.Shape shape = ( DecalTools.Shape ) shapes[ cboShapes.Active ];
		shape.setZ( Z );
		modified = true;
		updateTitleBar();
		QueueDraw();
	}

	protected void OnChkDrawIso3DToggled (object sender, EventArgs e)
	{
		isoDecalView.setDrawIn3D( !isoDecalView.isDrawingIn3D() );
		QueueDraw();
	}

	protected void OnBtnTriangulateAndSaveAsSVGClicked (object sender, EventArgs e)
	{

	}

	protected void OnOpenActionActivated (object sender, EventArgs e)
	{
		FileChooserDialog chooser = new FileChooserDialog( "Please select a Graphic to open ...",
		                                                  this,
		                                                  FileChooserAction.Open,
		                                                  "Cancel", ResponseType.Cancel,
		                                                  "Open", ResponseType.Accept );
		
				
			FileFilter filterSVG  = new FileFilter();
			filterSVG.Name = "SVG files";
			filterSVG.AddPattern("*.svg");
			chooser.AddFilter(filterSVG);
		
		if( chooser.Run() == ( int ) ResponseType.Accept ) {
			
			chooser.Hide();
			currentFilename = chooser.Filename.ToString();
			shapes = readSVG( chooser.Filename );
			
			if ( shapes.Count > 0 ) {
				
				isoDecalView.setShapes( shapes );
				updateComboBox();
				this.saveTriangulatedAsBinaryAction.Sensitive = true;
				this.saveTriangulatedAsSVGAction.Sensitive = true;
				this.SaveAsTriangulatedSVGAction.Sensitive = true;
				this.SaveTriangularedAsBinaryAction.Sensitive = true;

				this.saveAction.Sensitive = true;
				this.saveAsAction.Sensitive = true;
				this.spnDepth.Sensitive = true;
				this.cboShapes.Sensitive = true;		
				
			}
			
			QueueDraw();
		}	
		
		chooser.Destroy();
		modified = false;
		updateTitleBar();
	}


		private void onQuitApp() {
		
		if ( modified ) {

			MessageDialog md = new MessageDialog ( this, 
                                      DialogFlags.DestroyWithParent,
	                              MessageType.Question, 
                                      ButtonsType.YesNo, "You have unsaved changed. Do you want to save?");
				
			ResponseType result = (ResponseType)md.Run ();
			
			if (result == ResponseType.Yes) {
				this.save();	
			}

			md.Destroy();
		}
		this.Destroy();
	}

	protected void OnSaveTriangulatedAsSVGActionActivated (object sender, EventArgs e)
	{
		java.util.ArrayList triangulated = new java.util.ArrayList();
		java.util.ArrayList toProcess = new java.util.ArrayList();
		DecalTools.Shape shape;
		
		for (int c = 0; c < this.shapes.Count; ++c) {
			
			shape = ( DecalTools.Shape ) shapes[ c ];
			toProcess.add( shape.getColoredPolygon() );
		}
		
		triangulated = SVGTriangulate.SVGTriangulateUtils.splitIntoMonotones( toProcess );
		
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog( "Please name the file to save as SVG",
		                                                     this,
		                                                     FileChooserAction.Save,
		                                                     "Cancel",
		                                                     ResponseType.Cancel,
		                                                     "Save",
		                                                     ResponseType.Accept );	
		
			FileFilter filterSVG  = new FileFilter();
			filterSVG.Name = "SVG files";
			filterSVG.AddPattern("*.svg");
			fc.AddFilter(filterSVG);
			fc.Name = "output.svg";
			fc.DoOverwriteConfirmation = true;

		
		if ( fc.Run() == ( int )ResponseType.Accept ) {
			currentFilename = fc.Filename.ToString();
			SVGTriangulate.SVGTriangulateUtils.writeSVG( triangulated, currentFilename );
			modified = false;
			updateTitleBar();
		}	
		fc.Destroy();
	}



	protected void OnSaveTriangulatedAsBinaryActionActivated (object sender, EventArgs e)
	{
		java.util.ArrayList triangulated = new java.util.ArrayList();
		java.util.ArrayList toProcess = new java.util.ArrayList();
		java.util.ArrayList original = new java.util.ArrayList();
		DecalTools.Shape shape;
		
		for (int c = 0; c < this.shapes.Count; ++c) {
			
			shape = ( DecalTools.Shape ) shapes[ c ];
			toProcess.add( shape.getColoredPolygon() );
			original.add( shape.getColoredPolygon() );
		}
		
		triangulated = SVGTriangulate.SVGTriangulateUtils.splitIntoMonotones( toProcess );
		
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog( "Please name the file to save as binary",
		                                                     this,
		                                                     FileChooserAction.Save,
		                                                     "Cancel",
		                                                     ResponseType.Cancel,
		                                                     "Save",
		                                                     ResponseType.Accept );	 	
		
			FileFilter filterDecal  = new FileFilter();
			filterDecal.Name = "Binary decal files";
			filterDecal.AddPattern("*.bin");
			fc.AddFilter(filterDecal);
			fc.Name = "output.bin";
			fc.DoOverwriteConfirmation = true;
		
		if ( fc.Run() == ( int )ResponseType.Accept ) {
			
			currentFilename = fc.Filename.ToString();
			SVGTriangulate.SVGTriangulateUtils.writeBinary( triangulated, original,  currentFilename );
			modified = false;
			updateTitleBar();
		}	
		fc.Destroy();
		
	}


	protected void OnQuitActionActivated (object sender, EventArgs e)
	{
		this.onQuitApp();
		Application.Quit();
	}

	protected void OnHelpActionActivated (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}

	protected void OnImportTriangulatedBinaryDecalActivated (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}

	protected void OnIsoDecalViewScrollEvent (object o, ScrollEventArgs args)
	{
		throw new NotImplementedException ();
	}

	protected void OnScrollEvent (object o, ScrollEventArgs args)
	{
		if ( args.Event.Direction == Gdk.ScrollDirection.Down ) {
			
			this.setZAs( (byte)(this.spnDepth.Value + 1) );
		} else {
			this.setZAs( (byte)(this.spnDepth.Value - 1) );
		}
	}

	protected void OnSaveWithDepthsAsSVGActivated (object sender, System.EventArgs e)
	{
		saveAs();
		
	}
	
	public void saveAs() {
		
		java.util.ArrayList triangulated = new java.util.ArrayList();
		java.util.ArrayList toProcess = new java.util.ArrayList();
		DecalTools.Shape shape;
		
		for (int c = 0; c < this.shapes.Count; ++c) {
			
			shape = ( DecalTools.Shape ) shapes[ c ];
			toProcess.add( shape.getColoredPolygon() );
		}
		
		triangulated = toProcess;
		
		Gtk.FileChooserDialog fc = new Gtk.FileChooserDialog( "Please name the file to save as SVG",
		                                                     this,
		                                                     FileChooserAction.Save,
		                                                     "Cancel",
		                                                     ResponseType.Cancel,
		                                                     "Save",
		                                                     ResponseType.Accept );	
		
			FileFilter filterSVG  = new FileFilter();
			filterSVG.Name = "SVG files";
			filterSVG.AddPattern("*.svg");
			fc.AddFilter(filterSVG);
			fc.Name = "output.svg";
			fc.DoOverwriteConfirmation = true;

		
		if ( fc.Run() == ( int )ResponseType.Accept ) {
			
			currentFilename = fc.Filename.ToString();
			SVGTriangulate.SVGTriangulateUtils.writeSVG( triangulated, currentFilename );
			modified = false;
			updateTitleBar();
		}
		
		fc.Destroy();
	}	


	protected void OnSaveActionActivated (object sender, System.EventArgs e)
	{
		save();
	}
	
	public void save() {
		
		java.util.ArrayList triangulated = new java.util.ArrayList();
		java.util.ArrayList toProcess = new java.util.ArrayList();
		DecalTools.Shape shape;
		
		for (int c = 0; c < this.shapes.Count; ++c) {
			
			shape = ( DecalTools.Shape ) shapes[ c ];
			toProcess.add( shape.getColoredPolygon() );
		}
		
		triangulated = toProcess;
		SVGTriangulate.SVGTriangulateUtils.writeSVG( triangulated, currentFilename );
		modified = false;
		updateTitleBar();
	}
}

