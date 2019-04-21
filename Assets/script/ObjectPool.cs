using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>{

    public List<objectlist> objpool = new List<objectlist>();


    // Use this for initialization
    void Awake () {
        for (int i = 0; i < objpool.Count; i++)
        {
            objpool[i].Init(transform);
        }
	}

    public bool PushToPool(string objname, GameObject item, Transform transform = null)
    {
        objectlist pool = GetPoolItem(objname);

        if (pool == null)
            return false;
        pool.PushToPool(item, transform == null ? transform : this.transform);
        return true;
    }

    public GameObject PopFromPool(string objname, Transform transform = null)
    {
        objectlist pool = GetPoolItem(objname);
        if (pool == null)
            return null;
        return pool.PopFromPool(transform);
    }

    private objectlist GetPoolItem(string objname)
    {
        for (int i = 0; i < objpool.Count; i++)
        {
            if (objpool[i].objname.Equals(objname))
                return objpool[i];
        }
        Debug.Log("GetPoolItem Error");
        return null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
