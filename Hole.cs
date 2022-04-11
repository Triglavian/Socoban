using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Hole : Unit
{
	bool m_IsFilled;
	public Hole()
	{
		m_X = 0;
		m_Y = 0;
		m_IsFilled = false;
	}
	public Hole(int p_X, int p_Y)
	{
		m_X = p_X;
		m_Y = p_Y;
		m_IsFilled = false;
	}
	public void SwitchFilled()  //switch box status
	{
		m_IsFilled = true;
	}
	public void SwitctEmpty()  //switch box status
	{
		m_IsFilled = false;
	}
	public bool GetStatus() //get hole's status
	{
		return m_IsFilled;
	}
}