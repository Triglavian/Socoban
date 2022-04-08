using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Field
{
	private const int m_FieldWidth = 10;	//field width
	private const int m_FieldHeight = 10;	//field height
	private List<int[,]> m_Field = new List<int[,]>();	//field data list
	private char Road = ' ';		//0
	private char Wall = '=';		//1
	private char Player = '@';		//2
	private char Box = 'O';			//3
	private char Hole = 'X';		//4
	public Field()
	{
		m_Field.Add(Stage1);
		m_Field.Add(Stage2);
		m_Field.Add(Stage3);
	}
	private int[,] Stage1 = new int[m_FieldHeight, m_FieldWidth]
	{
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,4,1,1,1},
		{1,1,1,1,1,1,3,1,1,1},
		{1,1,0,2,0,0,3,4,1,1},
		{1,1,1,1,1,0,0,0,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
	};
	private int[,] Stage2 = new int[m_FieldHeight, m_FieldWidth]
	{
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,0,1,1,1},
		{1,1,1,1,1,4,3,0,1,1},
		{1,1,0,2,0,0,3,4,1,1},
		{1,1,1,1,1,0,0,0,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
	};
	private int[,] Stage3 = new int[m_FieldHeight, m_FieldWidth]
	{
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,0,4,0,1,1},
		{1,1,1,1,1,0,3,3,1,1},
		{1,1,0,0,0,0,0,4,1,1},
		{1,1,1,1,0,0,3,3,1,1},
		{1,1,1,1,1,1,0,4,4,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
	};
	public void RenderFieldStatus(int[,] p_Field, char[,] p_Buffer)	//rendering field to back buffer
	{
		for (int i = 0; i < m_FieldHeight; ++i) 
		{
			for (int j = 0; j < m_FieldHeight; ++j) 
			{
				switch (p_Field[i,j])	//field status switch
				{
					case 0:
						p_Buffer[i, j] = Road;
						break;
					case 1:
						p_Buffer[i, j] = Wall;
						break;
					case 2:
						p_Buffer[i, j] = Player;
						break;
					case 3:
						p_Buffer[i, j] = Box;
						break;
					case 4:
						p_Buffer[i, j] = Hole;
						break;
				}
			}
		}
	}
	public int[,] CurrentField(int p_Stage)	//return current stage map data
	{
		return m_Field[p_Stage];
	}
	public void SetPlayer(int p_X, int p_Y)
	{

	}
}


