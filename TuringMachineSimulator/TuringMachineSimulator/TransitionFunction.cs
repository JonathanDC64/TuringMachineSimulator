using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
	class TransitionFunction
	{
		private Dictionary<TransitionInput, TransitionOutput> transitions;
		public Dictionary<TransitionInput, TransitionOutput> Transitions
		{
			get
			{
				return transitions;
			}
		}

		private Dictionary<Tuple<State, char>, TransitionInput> transition_inputs;

		public TransitionFunction()
		{
			transitions = new Dictionary<TransitionInput, TransitionOutput>();
			transition_inputs = new Dictionary<Tuple<State, char>, TransitionInput>();
		}

		public void AddTransition(TransitionInput input, TransitionOutput output)
		{
			transitions.Add(input, output);
			transition_inputs.Add(new Tuple<State, char>(input.State, input.Symbol), input);
		}

		public TransitionInput GetInput(State state, char symbol)
		{
			return transition_inputs[new Tuple<State, char>(state, symbol)];
		}
	}
}
