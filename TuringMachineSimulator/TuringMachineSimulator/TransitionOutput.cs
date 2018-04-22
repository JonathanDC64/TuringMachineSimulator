using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
	class TransitionOutput
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

		private Directions direction;
		public Directions Direction
		{
			get
			{
				return direction;
			}
		}
		public TransitionOutput(State state, char symbol, Directions direction)
		{
			this.state = state;
			this.symbol = symbol;
			this.direction = direction;
		}
	}
}
