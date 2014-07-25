using System;
using Gtk;
using br.odb.libsvg;

namespace DecalTools
{
	public class Shape
	{
		Gdk.Point[] points;
		Gdk.Point[] pointsZ0;
		ColoredPolygon p;

		byte z;

		byte r;
		byte g;
		byte b;
		byte a;

		string name;


		public String getName() {
			return name;
		}

		public byte getZ ()
		{
			return this.z;
		}

		public void setZ ( byte z )
		{
			this.z = z;
			p.z = z;
		}

		private Gdk.Point[] extractGdkPointsFromColoredPolygon (ColoredPolygon p, byte withZ, bool in3D )
		{
			if ( p == null || p.npoints == 0 )
				return null;
			
			Gdk.Point[] toReturn = new Gdk.Point[ p.xpoints.Length ];
			Gdk.Point point2D;
			Gdk.Point point3D;
			byte givenZ = withZ;

			for (int c = 0; c < p.xpoints.Length; ++c) {

				point2D = new Gdk.Point();
				point2D.X = ( int ) p.xpoints[ c ];
				point2D.Y = ( int ) p.ypoints[ c ];

				if ( in3D )
					point3D = transform2DPointToIso3D( point2D, withZ: givenZ );
				else
					point3D = point2D;

				toReturn[ c ] = point3D;
			}
			return toReturn;
		}

		private Gdk.Point transform2DPointToIso3D (Gdk.Point point2D, byte withZ )
		{

			Gdk.Point toReturn = new Gdk.Point();

			toReturn.X = point2D.X;
			toReturn.Y = ( point2D.Y ) - toReturn.X / 2;


			toReturn.X = ( toReturn.X / 2 ) + ( withZ / 2 );
			toReturn.Y =  240 + ( toReturn.Y / 2 ) + ( withZ / 2 );

			return toReturn;
		}


		public byte getR ()
		{
			return this.r;
		}

		public byte getG ()
		{
			return this.g;
		}

		public byte getB ()
		{
			return this.b;
		}

		public byte getA ()
		{
			return this.a;
		}

		public void draw (Gdk.GC gc, Gdk.Window window, bool in3D, bool selected )
		{
			points = extractGdkPointsFromColoredPolygon( p, withZ: z, in3D: in3D );
			pointsZ0 = extractGdkPointsFromColoredPolygon( p, withZ: 0, in3D: in3D );
			
			if ( points == null || pointsZ0 == null )
				return;
			
			gc.RgbFgColor = new Gdk.Color ( 0, 0, 0 );
			window.DrawPolygon (gc, false, pointsZ0);

			for (int c = 0; c < this.points.Length; ++c ) {
				window.DrawLine( gc, points[ c ].X, points[ c ].Y, pointsZ0[ c ].X, pointsZ0[ c ].Y );
			}

			gc.RgbFgColor = new Gdk.Color (r, g, b);
			window.DrawPolygon (gc, true, points);
			
			if ( selected ) {
				
				gc.RgbFgColor = new Gdk.Color ( (byte)( 255 - r ), (byte)( 255 - g ), 
				                               (byte)( 255 - b ) );
				window.DrawPolygon (gc, false, points);
			}
		}

		public ColoredPolygon getColoredPolygon ()
		{
			return p;
		}

		public Shape (ColoredPolygon p, String name)
		{
			if ( p.id != null )
				this.name = p.id;
			else
				this.name = name;
			
			this.p = p;
			this.z = (byte) p.z;
			
			if (p.color != null) {

				this.r = ( byte ) p.color.getR ();
				this.g = ( byte ) p.color.getG ();
				this.b = ( byte ) p.color.getB ();
				this.a = ( byte ) p.color.getA ();
			}

			setZ( z );
		}
	}
}

