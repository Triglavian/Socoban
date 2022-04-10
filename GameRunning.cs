using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GameRunning
{
	UnitManagement m_UnitManager = null;    //unit manager object
	Field m_Field = null;
	GetValidKey m_Key = null;				//key validation object
	Rendering m_Render = null;              //rendering object
	ConsoleKeyInfo? m_ValidKey = null;
	int m_Stage;
	int m_BoxId;
	public GameRunning()
	{
		m_UnitManager = new UnitManagement();
		m_Field = new Field();
		m_Key = new GetValidKey();
		m_Render = new Rendering(m_UnitManager, m_Field);
		m_ValidKey = new ConsoleKeyInfo();
		m_Stage = 0;
		m_BoxId = -1;
	}
	public void Running()
	{
		m_ValidKey = m_Key.GetOnlyValidKey();
		if (m_ValidKey.Equals(ConsoleKey.Escape)) ; //back to level selection
		if (m_ValidKey == null)
		{
			m_Render.Draw(m_Stage);
			return;	//return if get invalid key
		}
		m_UnitManager.m_Player.GetCurrentStagePlayer(m_Stage).MoveGhost(m_ValidKey.Value);	//player ghost move
		m_BoxId = m_UnitManager.m_Player.IsPushBox(m_UnitManager.m_Boxes.GetCurrentStageBoxes(m_Stage), m_Stage);   //if player's ghost push a box, get the box's index
		if (m_BoxId >= 0)
		{
			m_UnitManager.m_Boxes.MoveBox(m_Stage, m_BoxId, m_Field.CurrentField(m_Stage), m_ValidKey.Value);   //move the box
			m_UnitManager.m_Player.GetCurrentStagePlayer(m_Stage).ConfirmMoveing();
		} else {
			m_UnitManager.m_Player.GetCurrentStagePlayer(m_Stage).CancelMoveing();
		}
		m_Render.Draw(m_Stage);
		m_ValidKey = null;
	}
}