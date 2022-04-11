using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class GetValidKey
{
	KeyValidationCondition m_ValidateKey = null;
	public GetValidKey()
	{
		m_ValidateKey = new KeyValidationCondition();	//key validation conditions
		
	}
	public ConsoleKeyInfo? GetOnlyValidKey()	//get valid key value or null
	{
		ConsoleKeyInfo? Key = GetKey();	//get key info if press any key
		if ((Key != null) && (m_ValidateKey.ValidateDirectionKeyCondition(Key.Value) == true)) return Key;	//return key data if get valid key
		return null;
	}
	private ConsoleKeyInfo? GetKey()	//get key info if press any key
	{
		if (Console.KeyAvailable)
		{
			ConsoleKeyInfo key = Console.ReadKey();
			return key;
		}
		return null;
	}
}