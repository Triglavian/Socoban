using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class KeyValidationCondition
{	
	//condisions, is possible to replace dictionary?
	public const ConsoleKey m_Left1 = ConsoleKey.A;
	public const ConsoleKey m_Left2 = ConsoleKey.LeftArrow;
	public const ConsoleKey m_Up1 = ConsoleKey.W;
	public const ConsoleKey m_Up2 = ConsoleKey.UpArrow;
	public const ConsoleKey m_Right1 = ConsoleKey.D;
	public const ConsoleKey m_Right2 = ConsoleKey.RightArrow;
	public const ConsoleKey m_Down1 = ConsoleKey.S;
	public const ConsoleKey m_Down2 = ConsoleKey.DownArrow;
	public const ConsoleKey m_Esc = ConsoleKey.Escape;
	public KeyValidationCondition() { }
	public bool ValidateKeyCondition(ConsoleKeyInfo p_Key)	//validate key 
	{
		switch (p_Key.Key)
		{
			//left
			case m_Left1:
			case m_Left2:
			//up
			case m_Up1:
			case m_Up2:
			//right
			case m_Right1:
			case m_Right2:
			//down
			case m_Down1:
			case m_Down2:
			//escape, back to stage selecttion
			case m_Esc:
				return true;	//valid keys
			//any other key
			default:
				break;
		}
		return false;	//invalide keys
	}
}