/**
 * 
 */
package br.odb.gamerendering.rendering;

/**
 * @author monty
 * 
 */
public class ResourceIdentificator {

	public static final ResourceIdentificator BLANK = new ResourceIdentificator(-1);
	
	int resId;
	
	public ResourceIdentificator(int i) {
		this.resId = i;
	}
}
