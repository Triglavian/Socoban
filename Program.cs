using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

class Program
{
	static void Main(string[] args)
	{
		bool GameStatus = true;
		GameRunning game = new GameRunning();
		while (GameStatus)
		{
			GameStatus = game.Running();
		}
	}
}

