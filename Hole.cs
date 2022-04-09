using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Hole : Unit
{
	public Hole()
	{
		m_X = 0;
		m_Y = 0;
	}
	public Hole(int p_X, int p_Y)
	{
		m_X = p_X;
		m_Y = p_Y;
	}
	private bool ValidateStatus(int p_X, int p_Y)	//validate is any box on the hole
	{
		return (p_X == m_X && p_Y == m_Y);	//return true if any box is on the hole
	}
}