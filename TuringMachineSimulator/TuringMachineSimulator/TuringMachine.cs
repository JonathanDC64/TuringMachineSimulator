using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{

	class TuringMachine
	{
		private HashSet<State> states;
		private HashSet<char> alphabet;
		private HashSet<char> tape_symbols;
		private TransitionFunction transition_function;
		private State start_state;
		private char blank;
		private HashSet<State> final_states;
		public TuringMachine(HashSet<State> states, HashSet<char> alphabet, HashSet<char> tape_symbols, State start_state, char blank)
		{
			this.states = states;
			this.alphabet = alphabet;
			this.tape_symbols = tape_symbols;
			this.start_state = start_state;
			this.blank = blank;
			var final_states = from state in states where state.Final == true select state;
			this.transition_function = new TransitionFunction();
			this.final_states = new HashSet<State>();
			foreach(State state in final_states)
			{
				this.final_states.Add(state);
			}
		}

		public void AddTransition(TransitionInput input, TransitionOutput output)
		{
			transition_function.AddTransition(input, output);
		}

		public string Execute(string input, bool print_trace)
		{
			StringBuilder tape = new StringBuilder(input);
			int pos = 0;
			State current_state = this.start_state;

			Console.WriteLine($"Initial Tape State : {tape.ToString()}");

			// Turing machine iterator
			while (true)
			{
				State prev_state = current_state;
				char tape_symbol = tape[pos];
				TransitionOutput output = transition_function.Transitions[transition_function.GetInput(current_state, tape_symbol)];
				tape[pos] = output.Symbol;
				pos += (output.Direction == Directions.Left) ? -1 : 1;
				string dir = (output.Direction == Directions.Left) ? "Left" : "Right";
				current_state = output.State;
				if (pos < 0)
				{
					tape.Insert(0, this.blank);
				}
				else if(pos >= tape.Length)
				{
					tape.Insert(tape.Length, this.blank);
				}
				Console.WriteLine($"Current State is \'{prev_state.Name}\', Read a symbol \'{tape_symbol}\', Transitioned to state \'{current_state.Name}\', Wrote Symbol \'{output.Symbol}\', Moved Tape {dir}");
				Console.WriteLine($"New State of tape : Pos is \'{pos}\', Content is : \'{tape.ToString()}\'");
				Console.WriteLine();

				// String was accepted
				if (current_state.Final)
				{
					Console.WriteLine($"String was accepted, Final contents : \'{tape.ToString()}\'");
					return tape.ToString();
				}
			}
		}
	}
}
