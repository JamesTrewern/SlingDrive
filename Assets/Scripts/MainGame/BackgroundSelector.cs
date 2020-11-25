using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSelector : MonoBehaviour
{
    public PublicVariables Variables;
    public Sprite[] Sprites = new Sprite[3];
    private SpriteRenderer SpriteRender;
    void Start()
    {
        SpriteRender = this.GetComponent<SpriteRenderer>();
        SpriteRender.sprite = Sprites[Variables.GetBackground()];
    }
}
