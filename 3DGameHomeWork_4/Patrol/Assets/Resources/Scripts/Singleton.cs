using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:MonoBehaviour {
	protected static T instance;
	public static T GetInstance{
		get{ 
			if (instance == null)
				instance = (T)FindObjectOfType (typeof(T));
			return instance;
		}
	}
}
