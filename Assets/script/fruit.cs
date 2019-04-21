using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fruit : MonoBehaviour {
    
    private SpriteRenderer m_Sprite;
    private Rigidbody2D m_rigidbody;
    private BoxCollider2D m_boxCllider;
    private FRUIT_KIND fruit_kind;

    private bool iscut = false;

    internal FRUIT_KIND Fruit_kind
    {
        get
        {
            return fruit_kind;
        }

        set
        {
            fruit_kind = Fruit_kind;
        }
    }
    
    private FruitEffect fruitEffect;
    public List<Sprite> fruitImage = new List<Sprite>();
    public List<Sprite> cutImage = new List<Sprite>();

    // Use this for initialization
    void OnEnable() {
        iscut = false;
        fruit_kind = (FRUIT_KIND)Random.Range(0, 7);
        m_boxCllider = GetComponent<BoxCollider2D>();
        m_Sprite = GetComponent<SpriteRenderer>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_Sprite.sprite = fruitImage[(int)fruit_kind];
        int num = Random.Range(0, 2);
        int num2 = Random.Range(0, 2);
        if (num == 0)
        {
            Vector2 rangeX;
            if (num2 == 0)
            {
                num2 = -1;
                rangeX = new Vector2(6.0f, 9.0f);
            }
            else
                rangeX = new Vector2(-6.0f, -9.0f);
            transform.position = new Vector3(num2 * 5, Random.Range(-2.0f, 5.0f), 0.0f);
            m_rigidbody.velocity = new Vector2(Random.Range(rangeX.x, rangeX.y), Random.Range(3.0f, 6.0f));
        }
        else
        {
            transform.position = new Vector3(0.0f, -5.0f, 0.0f);
            m_rigidbody.velocity = new Vector2(Random.Range(-4.0f, 4.0f), Random.Range(11.0f, 14.0f));
        }
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            ObjectPool.Instance.PushToPool("Fruit", gameObject);
        }
        if (collision.gameObject.tag == "Mouse")
        {
            if (iscut == true) return;

            if (fruit_kind == FRUIT_KIND.SIGARET)
            {
                GameManager.instance.end = true;
                Time.timeScale = 0;
                return;
            }
            m_Sprite.sprite = cutImage[(int)fruit_kind];
            m_rigidbody.velocity = new Vector3(0, 0, 0);
            GameManager.instance.Nowfruit = fruit_kind;
            GameManager.instance.EffectPos = transform.position;
            ObjectPool.Instance.PopFromPool("FruitEffect", ObjectPool.Instance.transform).SetActive(true);
            iscut = true;
        }
    }
}
