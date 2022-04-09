using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Field
{
	private const int m_FieldWidth = 10;	//field width
	private const int m_FieldHeight = 10;	//field height
	private List<int[,]> m_Field = new List<int[,]>();  //field data list
	private const char Road = ' ';		//road character
	private const char Wall = '=';		//wall character
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
		{1,1,1,1,1,1,0,1,1,1},
		{1,1,1,1,1,1,0,1,1,1},
		{1,1,0,0,0,0,0,0,1,1},
		{1,1,1,1,1,0,0,0,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
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
	};
	private int[,] Stage2 = new int[m_FieldHeight, m_FieldWidth]
	{
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,0,1,1,1},
		{1,1,1,1,1,0,0,0,1,1},
		{1,1,0,0,0,0,0,0,1,1},
		{1,1,1,1,1,0,0,0,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
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
	};
	private int[,] Stage3 = new int[m_FieldHeight, m_FieldWidth]
	{
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,0,0,0,1,1},
		{1,1,1,1,1,0,0,0,1,1},
		{1,1,0,0,0,0,0,0,1,1},
		{1,1,1,1,0,0,0,0,1,1},
		{1,1,1,1,1,1,0,0,0,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,1,1,1,1,1,1,1,1},
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
	};
	public void RenderFieldStatus(int[,] p_Field, char[,] p_Buffer) //rendering field to back buffer
	{
		for (int i = 0; i < m_FieldHeight; ++i)
		{
			for (int j = 0; j < m_FieldHeight; ++j)
			{
				switch (p_Field[i, j])  //field status switch
				{
					case 0:
						p_Buffer[i, j] = Road;
						break;
					case 1:
						p_Buffer[i, j] = Wall;
						break;
				}
			}
		}
	}
	public void RenderFieldStatus(int p_Stage, char[,] p_Buffer) //rendering field to back buffer
	{
		for (int i = 0; i < m_FieldHeight; ++i)
		{
			for (int j = 0; j < m_FieldHeight; ++j)
			{
				switch (m_Field[p_Stage][i, j])  //field status switch
				{
					case 0:
						p_Buffer[i, j] = Road;
						break;
					case 1:
						p_Buffer[i, j] = Wall;
						break;
				}
			}
		}
	}
	public int[,] CurrentField(int p_Stage)	//return current stage map data
	{
		return m_Field[p_Stage];
	}
}


