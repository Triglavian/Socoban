using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Holes
{
	//private List<List<Hole>> m_Holes = new List<List<Hole>>();  //all stages' holes data
	////stackoverflow if use array
	//List<Hole> HoleStage1 = new List<Hole>();	//stage 1 holes data
	//List<Hole> HoleStage2 = new List<Hole>();	//stage 2 holes data
	//List<Hole> HoleStage3 = new List<Hole>();	//stage 3 holes data 
	//public Holes()  //set positions of all stages' holes
	//{
	//	//stage 1 holes
	//	HoleStage1.Add(new Hole(6, 2));
	//	HoleStage1.Add(new Hole(7, 4));
	//	m_Holes.Add(HoleStage1);
	//	//stage 2 holes
	//	HoleStage2.Add(new Hole(5, 3));
	//	HoleStage2.Add(new Hole(7, 4));
	//	m_Holes.Add(HoleStage2);
	//	//stage 3 holes
	//	HoleStage3.Add(new Hole(6, 2));
	//	HoleStage3.Add(new Hole(7, 4));
	//	HoleStage3.Add(new Hole(7, 6));
	//	HoleStage3.Add(new Hole(8, 6));
	//	m_Holes.Add(HoleStage3);
	//}
	public List<Hole> m_Holes = new List<Hole>();	//each stage's holes data
	private const char m_HoleChar = 'X';	//hole character
	public Holes()
	{
		m_Holes.Add(new Hole());
	}
	public Holes(int p_Stage)
	{
		switch (p_Stage)
		{
			case 0: //stage 1 holes
				m_Holes.Add(new Hole(6, 2));
				m_Holes.Add(new Hole(7, 4));
				break;
			case 1: //stage 2 holes
				m_Holes.Add(new Hole(5, 3));
				m_Holes.Add(new Hole(7, 4));
				break;
			case 2: //stage 3 holes
				m_Holes.Add(new Hole(6, 2));
				m_Holes.Add(new Hole(7, 4));
				m_Holes.Add(new Hole(7, 6));
				m_Holes.Add(new Hole(8, 6));
				break;
		}
	}
	public void RenderHolesData(char[,] p_Buffer)	//render current stage's holes data
	{
		for (int i = 0; i < m_Holes.Count; i++)	//loop as number of p_Stage's holes
		{
			p_Buffer[m_Holes[i].GetYPosition(), m_Holes[i].GetXPosition()] = m_HoleChar;
		}
	}
	public List<Hole> GetCurrentStageHoles(int p_Stage) //get current stage's holes data
	{
		return m_Holes;
	}
	public void RefreshHolesStatus(List<Box> p_Boxes)	//refresh hole status
	{
		for (int i = 0; i < m_Holes.Count; ++i) 
		{
			for (int j = 0; j < p_Boxes.Count; ++j)
			{
				if (((m_Holes[i].GetXPosition() == p_Boxes[j].GetXPosition()) && (m_Holes[i].GetYPosition() == p_Boxes[j].GetYPosition()))) { //if any box is on the hole
					m_Holes[i].SwitchFilled();	//switch to fill
				}
				//else //if any box is not on the hole
				//{
				//	m_Holes[i].SwitctEmpty();	//switch to empty
				//}
			}
		}
	}
	public bool IsCompleteStage()
	{
		for (int i = 0; i < m_Holes.Count; ++i) 
		{
			if (m_Holes[i].GetStatus() == false) return false;
		}
		return true;
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