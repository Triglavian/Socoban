using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UnitManagement
{
	public List<Holes> m_Holes = new List<Holes>();
	public List<Boxes> m_Boxes = new List<Boxes>();
	public List<Player> m_Player = new List<Player>();
	int m_Stages = 3;
	public UnitManagement()
	{
		//m_Holes = new Holes();
		//m_Boxes = new Boxes();
		m_Player.Add(new Player(5, 4));		//st1
		m_Player.Add(new Player(4, 4));		//st2
		m_Player.Add(new Player(2, 4));		//st3
		for (int i = 0; i < m_Stages; ++i)
		{
			m_Boxes.Add(new Boxes(i));
		}
		for(int i = 0; i<m_Stages; ++i)
		{
			m_Holes.Add(new Holes(i));
		}
	}
	public bool ValidatePlayerMovement(int[,] p_Field, int p_Stage)
	{
		if (p_Field[m_Player[p_Stage].GetModifYPosition(), m_Player[p_Stage].GetModifXPosition()] == 0)	return true;    //0 is road, movable
		else if (p_Field[m_Player[p_Stage].GetModifYPosition(), m_Player[p_Stage].GetModifXPosition()] == 1) return false;	//1 is wall, inmovable
		return false;
	}
	public int IsPushBox(List<Box> p_Box, int p_Stage)  //return pushable box index
	{
		for (int i = 0; i < p_Box.Count; ++i)
		{
			if ((p_Box[i].GetXPosition() == m_Player[p_Stage].GetModifXPosition()) &&
					(p_Box[i].GetYPosition() == m_Player[p_Stage].GetModifYPosition()))
			{
				return i;   //return index if ghost push box
			}
		}
		return -1;  //return -1 if ghost don't push box
	}
	private bool IsAnotherBoxBeyondTheBox(int p_Stage, Box p_Box, int p_BoxId)
	{
		for(int i = 0; i < m_Boxes[p_Stage].GetCurrentStageBoxes().Count; ++i)
		{
			if (i == p_BoxId) continue;
			if ((m_Boxes[p_Stage].GetCurrentStageBoxes()[i].GetXPosition() == p_Box.GetModifXPosition()) &&
				(m_Boxes[p_Stage].GetCurrentStageBoxes()[i].GetYPosition() == p_Box.GetModifYPosition())) return true;	//if another box is beyond the box now pushing
		}
		return false;
	}
	public void MoveBox(int p_Stage, int p_BoxId, int[,] p_Field, ConsoleKeyInfo p_Key)
	{
		Box box = m_Boxes[p_BoxId].GetCurrentStageBoxes()[p_BoxId];	//frontward box
		box.MoveGhost(p_Key);
		if ((p_Field[box.GetModifYPosition(), box.GetModifXPosition()] != 1) && (IsAnotherBoxBeyondTheBox(p_Stage, box, p_BoxId) == false)) //1 = wall
		{
			box.ConfirmMovement();
		}
		else
		{
			box.CancelMovement();
		}
	}
	public Movable GetCurrentStagePlayer(int p_Stage)   //get current stage's player data
	{
		return m_Player[p_Stage];
	}
}