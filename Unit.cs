using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Unit	//all unit parent class
{
	//unit position
	protected int m_X { get; set; }

	protected int m_Y { get; set; }

	public void SetUnitPosition(int p_X, int p_Y)	//set unit position
	{
		m_X = p_X;
		m_Y = p_Y;
	}
	public int GetXPosition()	//get unit's x position
	{
		return m_X;
	}
	public int GetYPosition()	//get unit's y position
	{
		return m_Y;
	}
}

