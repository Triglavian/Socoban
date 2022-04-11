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
	/// <summary>
	/// player only movable = 0x1
	/// try to push a box = 0x100
	/// push
	/// </summary>
	public GameRunning()
	{
		m_UnitManager = new UnitManagement();
		m_Field = new Field();
		m_Key = new GetValidKey();
		m_Render = new Rendering(m_UnitManager, m_Field);
		m_ValidKey = new ConsoleKeyInfo();
		m_Stage = 2;
		m_BoxId = -1;
	}
	public bool Running()   //game logic
	{
		while (true) { 
			m_ValidKey = m_Key.GetOnlyValidKey();
			if (m_ValidKey.Equals(ConsoleKey.Escape)) return false; //exit program
			if (m_ValidKey == null)
			{
				m_Render.Draw(m_Stage);
				continue; //return if get invalid key
			}
			m_UnitManager.GetCurrentStagePlayer(m_Stage).MoveGhost(m_ValidKey.Value);    //player ghost move

			//m_MoveType = m_UnitManager.ValidatePlayerMovement(m_Field.CurrentField(m_Stage), m_Stage);
			switch (((m_UnitManager.ValidatePlayerMovement(m_Field.CurrentField(m_Stage), m_Stage))                                     //player movable
				| (m_UnitManager.IsTryToPushBox(m_UnitManager.GetCurrentStageBoxes(m_Stage).GetCurrentStageBoxList(), m_Stage, out m_BoxId)))) {        //is tring pushing box
				case 0x0:   //player immovable
					m_UnitManager.GetCurrentStagePlayer(m_Stage).CancelMovement();
					break;
				case 0x1:   //player movable
					m_UnitManager.GetCurrentStagePlayer(m_Stage).ConfirmMovement();
					break;
				case 0x11:  //player, box immovable
				case 0x111: //player movable, trying pushing box
					m_UnitManager.GetCurrentStageBoxes(m_Stage).GetCurrentStageBoxList()[m_BoxId].MoveGhost(m_ValidKey.Value);  //push box ghost
					break;
			}
			if ((m_BoxId >= 0) && (m_UnitManager.IsBoxPushable(m_Stage, m_UnitManager.GetCurrentStageBoxes(m_Stage).GetCurrentStageBoxList()[m_BoxId],
				m_BoxId, m_Field.CurrentField(m_Stage)) == true)) { //push box
				m_UnitManager.GetCurrentStageBoxes(m_Stage).GetCurrentStageBoxList()[m_BoxId].ConfirmMovement();
				m_UnitManager.GetCurrentStagePlayer(m_Stage).ConfirmMovement();
			}
			else if ((m_BoxId >= 0) && (m_UnitManager.IsBoxPushable(m_Stage, m_UnitManager.GetCurrentStageBoxes(m_Stage).GetCurrentStageBoxList()[m_BoxId],
				m_BoxId, m_Field.CurrentField(m_Stage)) == false))  //don't push box
			{
				m_UnitManager.GetCurrentStagePlayer(m_Stage).CancelMovement();
				m_UnitManager.GetCurrentStageBoxes(m_Stage).GetCurrentStageBoxList()[m_BoxId].CancelMovement();
			}
			m_UnitManager.GetCurrentStageHoles(m_Stage).RefreshHolesStatus(m_UnitManager.GetCurrentStageBoxes(m_Stage).GetCurrentStageBoxList());
			m_Render.Draw(m_Stage); //rendering
			if (m_UnitManager.GetCurrentStageHoles(m_Stage).IsCompleteStage() == true) m_Stage++;
			if(m_Stage > 2)
			{
				m_Render.ClearMsg();
				break;
			}
		}
		return false;
	}
}