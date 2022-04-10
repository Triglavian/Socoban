using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Movable : Unit
{
	//unit modified ghost position
	protected int m_ModifX { get; set; }
	protected int m_ModifY { get; set; }
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
	public int GetModifXPosition()   //get unit's x position
	{
		return m_ModifX;
	}
	public int GetModifYPosition()   //get unit's y position
	{
		return m_ModifY;
	}
	public void MoveGhost(ConsoleKeyInfo p_Key)	//push ghost position
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
	public void ConfirmMovement()	//move unit follow the key direction
	{
		m_X = m_ModifX;
		m_Y = m_ModifY;
	}
	public void CancelMovement()	//cancel unit moving and get ghost back to current position
	{
		m_ModifX = m_X;
		m_ModifY = m_Y;
	}
}
