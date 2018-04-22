using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachineSimulator
{
	class State
	{
		private string name;
		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}


		private bool final;
		public bool Final
		{
			get
			{
				return final;
			}
		}

		public State(string name, bool final)
		{
			this.name = name;
			this.final = final;
		}
	}
}
