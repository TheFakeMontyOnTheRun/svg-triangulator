using System;
using Gtk;
using System.Collections;

namespace DecalTools
{
	[System.ComponentModel.ToolboxItem(true)]
	public class IsoDecalView : Gtk.DrawingArea
	{

		ArrayList shapes;
		bool drawIn3D = true;

		public void setShapes (ArrayList shapes)
		{
			this.shapes = shapes;
		}


		public IsoDecalView ()
		{
			// Insert initialization code here.
		}

		protected override bool OnButtonPressEvent (Gdk.EventButton ev)
		{
			// Insert button press handling code here.
			return base.OnButtonPressEvent (ev);
		}

		protected override bool OnExposeEvent (Gdk.EventExpose ev)
		{
			base.OnExposeEvent (ev);

			Gdk.GC gc;
			int width;
			int height;
			ev.Window.GetSize (out width, out height);
			gc = new Gdk.GC( base.GdkWindow );

			gc.RgbFgColor = new Gdk.Color (128, 128, 128);
			GdkWindow.DrawRectangle ( gc, true, 0, 0, width, height );

			if (shapes != null) {

				for ( int c = 0; c < shapes.Count; ++c ) {

					Shape shape = ( Shape ) shapes[ c ];
					shape.draw( gc, ev.Window, drawIn3D, ( MainWindow.selected == c ) );
				}
			}

			gc.RgbFgColor = Style.BaseColors[ 0 ];

			return true;
		}

		protected override void OnSizeAllocated (Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated (allocation);
			// Insert layout code here.
		}

		public void setDrawIn3D( bool drawIn3D ) {

			this.drawIn3D = drawIn3D;

			if (shapes != null) {
				
				for ( int c = 0; c < shapes.Count; ++c ) {
					
					Shape shape = ( Shape ) shapes[ c ];
					shape.setZ( shape.getZ() );
				}
			}
		}
		 
		public bool isDrawingIn3D() {
			return this.drawIn3D;
		}

		protected void OnIsoDecalViewScrollEvent (object o, ScrollEventArgs args)
		{
			throw new NotImplementedException ();
		}


		protected override void OnSizeRequested (ref Gtk.Requisition requisition)
		{
			// Calculate desired size here.
			requisition.Height = 50;
			requisition.Width = 50;
		}
	}
}

