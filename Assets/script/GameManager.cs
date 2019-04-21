using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject fruit;
    public float startWait;
    public float spawnWait;
    private Vector3 effectPos;
    private FRUIT_KIND nowfruit;
    public bool end;

    internal FRUIT_KIND Nowfruit
    {
        get
        {
            return nowfruit;
        }

        set
        {
            nowfruit = value;
        }
    }

    public Vector3 EffectPos
    {
        get
        {
            return effectPos;
        }

        set
        {
            effectPos = value;
        }
    }


    // Use this for initialization
    void Start () {
        instance = this;
        StartCoroutine(MakeFruit());
        end = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            if (end == true)
            {
                Time.timeScale = 1;
                Application.LoadLevel(0);
                end = false;
            }
        }
    }
    void OnMouseDown()
    {
        
    }
    private IEnumerator MakeFruit()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            ObjectPool.Instance.PopFromPool("Fruit", ObjectPool.Instance.transform).SetActive(true);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}
