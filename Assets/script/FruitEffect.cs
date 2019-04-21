using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitEffect : MonoBehaviour {

    public List<Sprite> spriteImage = new List<Sprite>();
    private SpriteRenderer m_sprite;
    public float alphawait;
    private float alpha = 0.01f;

    private FRUIT_KIND fruit_kind;

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

    // Use this for initialization
    void OnEnable() {
        m_sprite = GetComponent<SpriteRenderer>();
        if (GameManager.instance)
        {
            fruit_kind = GameManager.instance.Nowfruit;
            m_sprite.sprite = spriteImage[(int)fruit_kind];
            m_sprite.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            transform.position = GameManager.instance.EffectPos;
            StartCoroutine(AlphaMinus());
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
    private IEnumerator AlphaMinus()
    {
        yield return new WaitForSeconds(3.0f);
        while (true)
        {
            m_sprite.color -= new Color(0, 0, 0, alpha);
            
            if (m_sprite.color.a < 0.1)
                ObjectPool.Instance.PushToPool("FruitEffect", gameObject, ObjectPool.Instance.transform);
            yield return new WaitForSeconds(alphawait);
        }
    }
}
