using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UnitManagement
{
	public Holes m_Holes = null;
	public Boxes m_Boxes = null;
	public Player m_Player = null;
	public UnitManagement()
	{
		m_Holes = new Holes();
		m_Boxes = new Boxes();
		m_Player = new Player();
	}
}