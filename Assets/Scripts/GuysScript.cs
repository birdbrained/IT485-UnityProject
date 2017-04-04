using UnityEngine;
using System.Collections;

public class GuysScript : MonoBehaviour 
{
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ChangeSprite(Sprite lemonLime)
    {
        sr.sprite = lemonLime;
    }

}
