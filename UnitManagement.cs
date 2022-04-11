using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UnitManagement
{
	private List<Holes> m_Holes = new List<Holes>();
	private List<Boxes> m_Boxes = new List<Boxes>();
	private List<Player> m_Player = new List<Player>();
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
	public int ValidatePlayerMovement(int[,] p_Field, int p_Stage)
	{
		if (p_Field[m_Player[p_Stage].GetModifYPosition(), m_Player[p_Stage].GetModifXPosition()] == 0)	return 0x1;    //0 is road, movable, return 0x1
		return 0x0;	//1 is wall, immovable, return 0x0
	}
	public int IsTryToPushBox(List<Box> p_Box, int p_Stage, out int p_BoxId)  //return is box pushable
	{
		p_BoxId = -1;
		for (int i = 0; i < p_Box.Count; ++i)
		{
			if ((p_Box[i].GetXPosition() == m_Player[p_Stage].GetModifXPosition()) &&
					(p_Box[i].GetYPosition() == m_Player[p_Stage].GetModifYPosition()))
			{
				p_BoxId = i;
				return 0x10;	//return 0x0 if a box is pushable
			}
		}
		return 0x0;  //return 0x0 if no box is pushable
	}
	public bool IsBoxPushable(int p_Stage, Box p_Box, int p_BoxId, int[,] p_Field)
	{
		if (p_BoxId < 0) return false;	//if invalid box id, return false
		for(int i = 0; i < m_Boxes[p_Stage].GetCurrentStageBoxList().Count; ++i)
		{
			if (i == p_BoxId) continue;
			if (((m_Boxes[p_Stage].GetCurrentStageBoxList()[i].GetXPosition() == p_Box.GetModifXPosition()) 
				&& (m_Boxes[p_Stage].GetCurrentStageBoxList()[i].GetYPosition() == p_Box.GetModifYPosition())) 
				|| (p_Field[m_Boxes[p_Stage].GetCurrentStageBoxList()[p_BoxId].GetModifYPosition(), 
				m_Boxes[p_Stage].GetCurrentStageBoxList()[p_BoxId].GetModifXPosition()] != 0)) return false;	//return 0x0 if any box is behind the box
		}
		return true;	//return 0x100 if box is pushable
	}
	public Player GetCurrentStagePlayer(int p_Stage)   //get current stage's player data
	{
		return m_Player[p_Stage];
	}
	public Boxes GetCurrentStageBoxes(int p_Stage)
	{
		return m_Boxes[p_Stage];
	}
	public Holes GetCurrentStageHoles(int p_Stage)
	{
		return m_Holes[p_Stage];
	}
}