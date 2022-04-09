using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Holes
{
	private List<List<Hole>> m_Holes = new List<List<Hole>>();  //all stages' holes data
	//stackoverflow if use array
	List<Hole> HoleStage1 = new List<Hole>();	//stage 1 holes data
	List<Hole> HoleStage2 = new List<Hole>();	//stage 2 holes data
	List<Hole> HoleStage3 = new List<Hole>();	//stage 3 holes data 
	private const char m_HoleChar = 'X';	//hole character
	public Holes()  //set positions of all stages' holes
	{
		//stage 1 holes
		HoleStage1.Add(new Hole(6, 2));
		HoleStage1.Add(new Hole(7, 4));
		m_Holes.Add(HoleStage1);
		//stage 2 holes
		HoleStage2.Add(new Hole(5, 3));
		HoleStage2.Add(new Hole(7, 4));
		m_Holes.Add(HoleStage2);
		//stage 3 holes
		HoleStage3.Add(new Hole(6, 2));
		HoleStage3.Add(new Hole(7, 4));
		HoleStage3.Add(new Hole(7, 6));
		HoleStage3.Add(new Hole(8, 6));
		m_Holes.Add(HoleStage3);
	}
	public void RenderHolesData(int p_Stage, char[,] p_Buffer)	//set current datas of p_Stage's holes to back buffer
	{
		List<Hole> CurrentStage = m_Holes[p_Stage];
		for (int i = 0; i < CurrentStage.Count; i++)	//loop as number of p_Stage's holes
		{
			p_Buffer[CurrentStage[i].GetYPosition(), CurrentStage[i].GetXPosition()] = m_HoleChar;
		}
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