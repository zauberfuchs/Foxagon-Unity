using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Savepoint {

	private Vector3 _savePos;

	public Savepoint (Vector3 savePos) : this() 
	{
		this._savePos = savePos;
	}

	public Vector3 SavePos 
	{
		get
		{
			return _savePos;
		}
		set
		{
			_savePos = value;
		}
	}
}
