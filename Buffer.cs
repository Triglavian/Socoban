using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Buffer
{
	private int m_Width;	//buffer width
	private int m_Height;	//buffer height
	public char[,] m_BackBuffer = null;    //back buffer 
	public char[] m_OutBuffer = null;		//outstream buffer
	public Buffer(int p_Width, int p_Height)	//initialize buffer
	{
		m_Width = p_Width + 1;
		m_Height = p_Height;
		m_BackBuffer = new char[m_Height, m_Width];
		m_OutBuffer = new char[m_Height * m_Width];
		Console.CursorVisible = false;
	}
	public void ClearBackBuffer()	//clear buffer before render new buffer
	{
		for (int i = 0; i < m_Height; ++i) 
		{
			for (int j = 0; j < m_Width; ++j) 
			{
				m_BackBuffer[i, j] = ' ';
			}
		}
	}
	public void ConvertBackBufferToOutBuffer()	//convert back buffer to outstream buffer
	{
		for (int i = 0; i < m_Height; ++i) 
		{
			for (int j = 0; j < m_Width - 1; ++j)
			{
				m_OutBuffer[i * m_Width + j] = m_BackBuffer[i, j];
			}
			m_OutBuffer[(i + 1) * m_Width - 1] = '\n';
		}
	}
}