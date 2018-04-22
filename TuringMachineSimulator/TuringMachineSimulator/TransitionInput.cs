using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
	class TransitionInput
	{
		private State state;
		public State State
		{
			get
			{
				return state;
			}
		}

		private char symbol;
		public char Symbol
		{
			get
			{
				return symbol;
			}
		}

		public TransitionInput(State state, char symbol)
		{
			this.state = state;
			this.symbol = symbol;
		}
	}
}
