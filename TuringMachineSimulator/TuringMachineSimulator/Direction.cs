using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
	public enum Directions
	{
		Left,
		Right
	}

	class Direction
	{
		private Directions direction;

		public Directions get()
		{
			return direction;
		}

		public Direction(Directions d)
		{
			direction = d;

		}
	}
}
