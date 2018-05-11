using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserAction  {

	void MoveTo (float x, float z);
	int GetScore ();
	bool GetGameover ();
}
