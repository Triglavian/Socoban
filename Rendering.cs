using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Rendering
{
	Field m_Field = null;
	Buffer m_Buffer = null;
	UnitManagement m_UnitManager = null;
	private const string m_ToolTip = "ESC = Exit";
	public Rendering(UnitManagement p_UnitManagement, Field p_Field)
	{
		m_Field = p_Field;
		m_Buffer = new Buffer(40, 25);
		m_UnitManager = p_UnitManagement;
	}
	private void RenderBackBuffer(int p_Stage)	//render back buffer from field data
	{
		m_Buffer.ClearBackBuffer();
		m_Field.RenderFieldStatus(m_Field.CurrentField(p_Stage), m_Buffer.m_BackBuffer);
		m_UnitManager.GetCurrentStageHoles(p_Stage).RenderHolesData(m_Buffer.m_BackBuffer);
		m_UnitManager.GetCurrentStageBoxes(p_Stage).RenderBoxesData(m_Buffer.m_BackBuffer);
		m_UnitManager.GetCurrentStagePlayer(p_Stage).RenderPlayerData(m_Buffer.m_BackBuffer);
		RenderTooltip();
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
	private void RenderTooltip()	//rendering tool tip
	{
		for(int i = 0; i<m_ToolTip.ToCharArray().Length; ++i)
		{
			m_Buffer.m_BackBuffer[11, 0 + i] = m_ToolTip.ToCharArray()[i];
		}
	}
	public void Draw(int p_Stage)	//print buffer to screen
	{
		RenderBuffer(p_Stage);
		//init cursor pos before and after print
		Console.SetCursorPosition(0, 0);
		Console.WriteLine(m_Buffer.m_OutBuffer);
		Console.SetCursorPosition(0, 0);
	}
	public void ClearMsg()	//clear message
	{
		m_Buffer.ClearBackBuffer();
		m_Buffer.ConvertBackBufferToOutBuffer();
		Console.SetCursorPosition(0, 0);
		Console.WriteLine(m_Buffer.m_OutBuffer);
		Console.SetCursorPosition(0, 0);
		Console.WriteLine("\n\n\n\n\n\tGameClear");
	}
}