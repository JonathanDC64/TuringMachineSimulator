using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
	class Program
	{
		static void Main(string[] args)
		{

			// Turing Machine for the language:
			// L = {0^n1^n : n >= 1}

			State[] q = {
				new State("q0", false),
				new State("q1", false),
				new State("q2", false),
				new State("q3", false),
				new State("q4", true)
			};

			HashSet<State> states = new HashSet<State>(q);
			

			HashSet<char> alphabet = new HashSet<char>();
			alphabet.Add('0');
			alphabet.Add('1');

			char blank = ' ';

			HashSet<char> tape_symbols = new HashSet<char>();
			tape_symbols.Add('0');
			tape_symbols.Add('1');
			tape_symbols.Add('X');
			tape_symbols.Add('Y');
			tape_symbols.Add(blank);

			State start_state = q[0];
			
			TuringMachine M = new TuringMachine(states,alphabet,tape_symbols,start_state,blank);

			M.AddTransition(new TransitionInput(q[0], '0') , new TransitionOutput(q[1], 'X', Directions.Right));
			M.AddTransition(new TransitionInput(q[1], '0'), new TransitionOutput(q[1], '0', Directions.Right));
			M.AddTransition(new TransitionInput(q[1], 'Y'), new TransitionOutput(q[1], 'Y', Directions.Right));
			M.AddTransition(new TransitionInput(q[1], '1'), new TransitionOutput(q[2], 'Y', Directions.Left));
			M.AddTransition(new TransitionInput(q[2], 'Y'), new TransitionOutput(q[1], 'Y', Directions.Left));
			M.AddTransition(new TransitionInput(q[2], '0'), new TransitionOutput(q[2], '0', Directions.Left));
			M.AddTransition(new TransitionInput(q[2], 'X'), new TransitionOutput(q[0], 'X', Directions.Right));
			M.AddTransition(new TransitionInput(q[0], 'Y'), new TransitionOutput(q[3], 'Y', Directions.Right));
			M.AddTransition(new TransitionInput(q[3], 'Y'), new TransitionOutput(q[3], 'Y', Directions.Right));
			M.AddTransition(new TransitionInput(q[3], blank), new TransitionOutput(q[4], blank, Directions.Right));

			M.Execute("00001111", false);

			Console.WriteLine();
		}
	}
}
