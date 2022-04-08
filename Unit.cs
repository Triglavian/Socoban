using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Unit
{
	private char m_Char	//character
	{
		get { return m_Char; }
		set { m_Char = value; }
	}
	protected bool m_IsMovable	//movable flag 
	{
		get { return m_IsMovable; }
		set { m_IsMovable = value; }
	}
	protected int m_X   //unit x position
	{
		get { return m_X; }
		set { m_X = value; }
	}
	protected int m_Y   //unit y position
	{
		get { return m_Y; }
		set { m_Y = value; }
	}
	public void SetUnitPos(int p_X, int p_Y)	//initialize unit position
	{
		m_X = p_X;
		m_Y = p_Y;
	}
	protected int m_ModifX   //unit modif x position
	{
		get { return m_ModifX; }
		set { m_ModifX = value; }
	}
	protected int m_ModifY   //unit modif y position
	{
		get { return m_ModifY; }
		set { m_ModifY = value; }
	}
	public void SetUnitModifPos(int p_X, int p_Y)    //set unit's temp modified pos
	{
		m_ModifX = p_X;
		m_ModifY = p_Y;
	}
}

