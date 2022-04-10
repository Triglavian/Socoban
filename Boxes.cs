using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Boxes
{
	private List<List<Box>> m_Boxes = new List<List<Box>>();  //all stages' holes data
																//stackoverflow if use array
	List<Box> BoxStage1 = new List<Box>();	//stage 1 holes data
	List<Box> BoxStage2 = new List<Box>();	//stage 2 holes data
	List<Box> BoxStage3 = new List<Box>();	//stage 3 holes data 
	private const char m_BoxChar = 'O';		//box character
	public Boxes()  //set positions of all stages' holes
	{
		//stage 1 holes
		BoxStage1.Add(new Box(6, 3));
		BoxStage1.Add(new Box(6, 4));
		m_Boxes.Add(BoxStage1);
		//stage 2 holes
		BoxStage2.Add(new Box(6, 3));
		BoxStage2.Add(new Box(6, 4));
		m_Boxes.Add(BoxStage2);
		//stage 3 holes
		BoxStage3.Add(new Box(6, 3));
		BoxStage3.Add(new Box(7, 3));
		BoxStage3.Add(new Box(6, 5));
		BoxStage3.Add(new Box(7, 5));
		m_Boxes.Add(BoxStage3);
	}
	public void RenderBoxesData(int p_Stage, char[,] p_Buffer)  //set current datas of p_Stage's holes to back buffer
	{
		List<Box> CurrentStage = m_Boxes[p_Stage];
		for (int i = 0; i < CurrentStage.Count; i++)    //loop as number of p_Stage's holes
		{
			p_Buffer[CurrentStage[i].GetYPosition(), CurrentStage[i].GetXPosition()] = m_BoxChar;
		}
	}
	public List<Box> GetCurrentStageBoxes(int p_Stage)	//get current stage's boxes data
	{
		return m_Boxes[p_Stage];
	}
	public void MoveBox(int p_Stage, int p_BoxId, int[,] p_Field, ConsoleKeyInfo p_Key)
	{	Box box = m_Boxes[p_Stage][p_BoxId];
		box.MoveGhost(p_Key);
		if (p_Field[box.GetModifYPosition(), box.GetModifXPosition()] != 1) //1 = wall
		{
			box.ConfirmMoveing();
		}
		else
		{
			box.CancelMoveing();
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