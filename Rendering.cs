﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Rendering
{
	Field m_Field = null;
	Buffer m_Buffer = null;
	Holes m_Holes = null;
	Boxes m_Boxes = null;
	Player m_Player = null;
	public Rendering()
	{
		m_Field = new Field();
		m_Buffer = new Buffer(40, 25);
		m_Holes = new Holes();
		m_Boxes = new Boxes();
		m_Player = new Player();
	}
	private void RenderBackBuffer(int p_Stage)	//render back buffer from field data
	{
		//m_Field.RenderFieldStatus(m_Field.CurrentField(p_Stage), m_Buffer.m_BackBuffer);
		m_Field.RenderFieldStatus(p_Stage, m_Buffer.m_BackBuffer);
		m_Holes.RenderHolesData(p_Stage, m_Buffer.m_BackBuffer);
		m_Boxes.RenderBoxesData(p_Stage, m_Buffer.m_BackBuffer);
		m_Player.RenderPlayerData(p_Stage, m_Buffer.m_BackBuffer);
	}
	private void RenderOutstreamBuffer()	//render outstream buffer from back buffer
	{
		m_Buffer.ConvertBackBufferToOutBuffer();
	}
	private void RenderBuffer(int p_Stage)  //render new buffer
	{
		RenderBackBuffer(p_Stage);	
		RenderOutstreamBuffer();

	}
	public void Draw(int p_Stage)	//print buffer to screen
	{
		RenderBuffer(p_Stage);
		//init cursor pos before and after print
		Console.SetCursorPosition(0, 0);
		Console.WriteLine(m_Buffer.m_OutBuffer);
		Console.SetCursorPosition(0, 0);
	}
}
