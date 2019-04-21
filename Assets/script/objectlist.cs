using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class objectlist {

    public string objname = string.Empty;
    public GameObject prefeb = null;
    public int size = 0;

    [SerializeField]
    public List<GameObject> objlist = new List<GameObject>();

	// Use this for initialization
	public void Init (Transform transform = null) {
        for (int i = 0; i < size; i++)
            objlist.Add(CreateItem(transform));
	}

    public void PushToPool(GameObject item, Transform parent = null)
    {
        item.transform.SetParent(parent);
        item.SetActive(false);
        objlist.Add(item);
    }

    public GameObject PopFromPool(Transform parent = null)
    {
        if (objlist.Count == 0)
            objlist.Add(CreateItem(parent));
        GameObject item = objlist[0];
        objlist.RemoveAt(0);
        item.SetActive(true);

        return item;
    }

    private GameObject CreateItem(Transform transform)
    {
        GameObject item = Object.Instantiate(prefeb) as GameObject;
        item.name = objname;
        item.transform.SetParent(transform);
        item.SetActive(false);

        return item;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
