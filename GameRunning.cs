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
		m_UnitManager.m_Player[m_Stage].MoveGhost(m_ValidKey.Value);    //player ghost move
		if (m_UnitManager.ValidatePlayerMovement(m_Field.CurrentField(m_Stage), m_Stage) == true)   //if player ghost movement is valid
		{
			m_BoxId = m_UnitManager.IsPushBox(m_UnitManager.m_Boxes[m_Stage].GetCurrentStageBoxes(), m_Stage);  //get pushable box index
			if (m_BoxId >= 0)
			{
				m_UnitManager.MoveBox(m_Stage, m_BoxId, m_Field.CurrentField(m_Stage), m_ValidKey.Value);   //move box if box is moveable
				m_UnitManager.m_Player[m_Stage].ConfirmMovement();   //confirm player movement 
			} 
		}
		else m_UnitManager.m_Player[m_Stage].CancelMovement();	//if immovable
		m_Render.Draw(m_Stage);
		m_ValidKey = null;
	}
}