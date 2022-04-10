using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UnitManagement
{
	public Holes m_Holes = null;
	public Boxes m_Boxes = null;
	public Player m_Player = null;
	public UnitManagement()
	{
		m_Holes = new Holes();
		m_Boxes = new Boxes();
		m_Player = new Player();
	}
	public int IsPushBox(List<Box> p_Box, int p_Stage)  //return pushable box index
	{
		for (int i = 0; i < p_Box.Count; ++i)
		{
			if (p_Box[i].GetXPosition() == m_Player[p_Stage].GetXPosition() &&
					p_Box[i].GetYPosition() == m_Player[p_Stage].GetYPosition())
			{
				return i;   //return index if ghost push box
			}
		}
		return -1;  //return -1 if ghost don't push box
	}
	public void MoveBox(int p_Stage, int p_BoxId, int[,] p_Field, ConsoleKeyInfo p_Key)
	{
		Box box = m_Boxes[p_Stage][p_BoxId];
		box.MoveGhost(p_Key);
		if (p_Field[box.GetModifYPosition(), box.GetModifXPosition()] != 1) //1 = wall
		{
			box.ConfirmMoveing();
		} else
		{
			box.CancelMoveing();
		}
	}