using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Boxes
{

	private List<Box> m_Boxes = new List<Box>();		//each stage's boxes data
	private const char m_BoxChar = 'O';		//box character
	public Boxes()	//don't use
	{
		m_Boxes.Add(new Box());
	}
	public Boxes(int p_Stage)  //don't use
	{
		switch (p_Stage) {
			case 0: //stage 1 boxes
				m_Boxes.Add(new Box(6, 3));
				m_Boxes.Add(new Box(6, 4));
				break;
			case 1:	//stage 2 boxes
				m_Boxes.Add(new Box(6, 3));
				m_Boxes.Add(new Box(6, 4));
				break;
			case 2:	//stage 3 boxes
				m_Boxes.Add(new Box(6, 3));
				m_Boxes.Add(new Box(7, 3));
				m_Boxes.Add(new Box(6, 5));
				m_Boxes.Add(new Box(7, 5));
				break;
		}
	}
	public void RenderBoxesData(char[,] p_Buffer)  //render current stage's boxes data
	{
		for (int i = 0; i < m_Boxes.Count; i++)    //loop as number of p_Stage's holes
		{
			p_Buffer[m_Boxes[i].GetYPosition(), m_Boxes[i].GetXPosition()] = m_BoxChar;
		}
	}
	public List<Box> GetCurrentStageBoxList()	//get current stage's boxes data
	{
		return m_Boxes;
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