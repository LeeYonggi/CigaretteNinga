using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static readonly object padlock = new object();
	// Use this for initialization
	
    public Singleton()
    {
    }
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                    Debug.Log("There's no active" + typeof(T) + "is this scene");
            }
            return instance;

        }
    }
}
