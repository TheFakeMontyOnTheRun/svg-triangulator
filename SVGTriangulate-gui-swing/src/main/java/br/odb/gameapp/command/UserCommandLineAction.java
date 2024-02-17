package br.odb.gameapp.command;


import br.odb.gameapp.ConsoleApplication;

import java.util.List;

public abstract class UserCommandLineAction {
	
	public class InvalidCommandRunException extends Exception {

		/**
		 * 
		 */
		private static final long serialVersionUID = 5986983118464310069L;
		
	}
	
	public abstract void run(ConsoleApplication application, String operands) throws Exception;

	@Override
	public abstract String toString();

    public abstract CommandParameterDefinition[] requiredOperands();

	public String getHelp() {

		StringBuilder commandsDefinition = new StringBuilder("");
		commandsDefinition.append( "(\n" );
		for ( CommandParameterDefinition c : requiredOperands() ) {
			commandsDefinition.append( c.toString() );
			commandsDefinition.append( " : " );
			commandsDefinition.append( c.getDescription() );
			commandsDefinition.append( "\n" );
		}
		commandsDefinition.append( ");" );

		return ">" + toString() + " : " + getDescription() + " " + commandsDefinition.toString();
	}

	protected abstract String getDescription();
}
