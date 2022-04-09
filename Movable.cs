using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Movable : Unit
{
	//unit modified ghost position
	public int m_ModifX { get; set; }
	public int m_ModifY { get; set; }
	public Movable()
	{
		m_X = m_ModifX = 0;
		m_Y = m_ModifY = 0;
	}
	public Movable(int p_X, int p_Y)
	{
		m_X = m_ModifX = p_X;
		m_Y = m_ModifY = p_Y;
	}
	public void Push(ConsoleKeyInfo p_Key)	//push ghost position
	{
		switch (p_Key.Key)	//moving direction swtich
		{
			//left
			case ConsoleKey.A:
			case ConsoleKey.LeftArrow:
				--m_ModifX;	//move ghost to left
				break;
			//up
			case ConsoleKey.W:
			case ConsoleKey.UpArrow:
				--m_ModifY;	//move ghost to up
				break;
			//right
			case ConsoleKey.D:
			case ConsoleKey.RightArrow:
				++m_ModifX;	//move ghost to right
				break;
			//down
			case ConsoleKey.S:
			case ConsoleKey.DownArrow:
				++m_ModifY;	//move ghost to down
				break;
		}
	}
	public void PushUnit()
	{
		m_X = m_ModifX;
		m_Y = m_ModifY;
	}
}
