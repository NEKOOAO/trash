using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDisplay : MonoBehaviour
{
    public Trash trash;
    private float s_width;
    private float pic_big=5;
    private SpriteRenderer SR;
    private BoxCollider2D BC;
    public void Show()
    {
        SR = this.GetComponent<SpriteRenderer>();
        BC = this.GetComponent<BoxCollider2D>();
        SR.sprite = trash.sprite;
        s_width = SR.bounds.size.x;
        SR.transform.localScale = new Vector2(pic_big/s_width, pic_big / s_width);
        BC.size = new Vector2( s_width / pic_big*1f,  s_width/ pic_big*1f);
    }
}
