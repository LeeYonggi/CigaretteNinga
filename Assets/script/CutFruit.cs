using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutFruit : MonoBehaviour {

    private FRUIT_KIND fruit_kind;
    public fruit p_fruit;


    // Use this for initialization
    void Start () {
        fruit_kind = p_fruit.Fruit_kind;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
