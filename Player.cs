using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player : Movable
{
	private List<Movable> m_Player = new List<Movable>();	//all stages' player data
	private char m_PlayerChar = '@';	//player character
	public Player()	//set all stages' player position
	{
		m_Player.Add(new Movable(3, 4));	//st1
		m_Player.Add(new Movable(4, 4));	//st2
		m_Player.Add(new Movable(2, 4));	//st3
	}
	public void RenderPlayerData(int p_Stage, char[,] p_Buffer)  //set current datas of p_Stage's holes to back buffer
	{
		Movable CurrentStage = m_Player[p_Stage];
		p_Buffer[CurrentStage.GetYPosition(), CurrentStage.GetXPosition()] = m_PlayerChar;
	}
	public Movable GetCurrentStagePlayer(int p_Stage)	//get current stage's player data
	{
		return m_Player[p_Stage];
	}
	public int IsPushBox(List<Box> p_Box, int p_Stage)	//return pushable box index
	{
		for(int i = 0; i<p_Box.Count; ++i)
		{
			if (p_Box[i].GetXPosition() == m_Player[p_Stage].GetXPosition() &&
					p_Box[i].GetYPosition() == m_Player[p_Stage].GetYPosition()) 
			{
				return i;	//return index if ghost push box
			}
		}
		return -1;	//return -1 if ghost don't push box
	}
}
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,4,1,1,1},
//{1,1,1,1,1,1,3,1,1,1},
//{1,1,0,2,0,0,3,4,1,1},
//{1,1,1,1,1,0,0,0,1,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},

//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,0,1,1,1},
//{1,1,1,1,1,4,3,0,1,1},
//{1,1,0,2,0,0,3,4,1,1},
//{1,1,1,1,1,0,0,0,1,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},

//{1,1,1,1,1,1,1,1,1,1},	
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,0,4,0,1,1},
//{1,1,1,1,1,0,3,3,1,1},
//{1,1,0,0,0,0,0,4,1,1},
//{1,1,1,1,0,0,3,3,1,1},
//{1,1,1,1,1,1,0,4,4,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},
//{1,1,1,1,1,1,1,1,1,1},