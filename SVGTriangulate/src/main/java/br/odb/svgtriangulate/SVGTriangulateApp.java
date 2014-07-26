/**
 * 
 */
package br.odb.svgtriangulate;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.OutputStream;

import br.odb.libsvg.SVGGraphic;
import br.odb.libsvg.SVGParsingUtils;

/**
 * 
 * @author Daniel "Monty" Monteiro
 */
public class SVGTriangulateApp {
	// -----------------------------------------------------------------------------
	/**
	 * 
	 */
	public static final String PARAM_TOKEN = "--";
	/**
	 * 
	 */
	public static final String INPUT_TOKEN = "input ";
	/**
	 * 
	 */
	public static final String OUTPUT_TOKEN = "output ";

	// -----------------------------------------------------------------------------
	/**
	 * 
	 * @param out
	 */
	public static void printShortPreambule(OutputStream out) {
		try {
			out.write("SVG Triangulator - 2011 - Daniel Monteiro ( DanielMonteiro@id.uff.br )\n"
					.getBytes());
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	// -----------------------------------------------------------------------------
	/**
	 * 
	 * @param out
	 */
	public static void printPreambule(OutputStream out) {
		try {
			out.write("Decomposes the shapes made of straight paths into simpler triangles.\n"
					.getBytes());
			out.write("3-Clause BSD license applies to the use and inspection of the source code of this applicaton.\n"
					.getBytes());
			out.write("USAGE: [JVM call procedure] SVGTriangulate --input file.svg --output file2.svg\n"
					.getBytes());
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	// -----------------------------------------------------------------------------
	/**
	 * 
	 * @param args
	 */
	public static void main(String[] args) {
//		String[] args = new String[ 4 ];
//		args[ 0 ] = "--input";
//		args[ 1 ] = "/home/monty/Desktop/drawing.svg";
//		args[ 2 ] = "--output";
//		args[ 3 ] = "/home/monty/out.svg";

		SVGGraphic original = null;
		SVGGraphic processed;

		String arg0 = null;
		String arg1 = null;
		String pathInput = null;
		String pathOutput = null;

		// <parameter processing>
		printShortPreambule(System.out);

		//------------------------		
		 if ( args.length != 4 ) {
			 printPreambule( System.out );
			 return;
		 }
		
		 arg0 = args[ 1 ];
		 arg1 = args[ 3 ];
		// ------------------------
		pathInput = arg0;
		pathOutput = arg1;

		// </parameter processing>
		// <reading the input file>
		System.out.println("Reading file:" + pathInput);
		try {
			original = SVGParsingUtils.readSVG( new FileInputStream( pathInput ) );
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		//DEBUG
		SVGParsingUtils.writeSVG( original, pathOutput + ".original.svg" );

		// </reading the input file>
		// <processing geometry>
		System.out.println("Processing geometry:");
		processed = SVGParsingUtils.splitIntoMonotones(original);
		// processed = original;
		// </processing geometry>
		// <writing the output file>
	
		
		if ( args[ 2 ].equals( "--binary" ) ) {
			System.out.println("Writing binary file:" + pathOutput);
			SVGParsingUtils.writeBinary(processed, original, pathOutput);
		} else if ( args[ 2 ].equals( "--output" ) ) {
			System.out.println("Writing file:" + pathOutput);
			SVGParsingUtils.writeSVG(processed, pathOutput);	
		}
		// ...
		System.out.println("Done!");
		// </writing the output file>
//		ArrayList<ColoredPolygon> piggyBacked = new ArrayList<ColoredPolygon>();
//		ColoredPolygon shape1 = new ColoredPolygon();
//		shape1.addPoint( 0 , 0 );
//		shape1.addPoint( 800 , 0 );
//		shape1.addPoint( 0 , 480 );
//		
//		shape1.color.set( 255, 128, 64, 32 );
//		
//		piggyBacked.add( shape1 );
//		writeSVG( piggyBacked, "/home/monty/piggyBack.svg" );
	}

}
// -----------------------------------------------------------------------------
