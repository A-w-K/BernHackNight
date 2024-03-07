using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private SpriteRenderer parentSpriteRenderer;
    private BoxCollider2D jumpThroughTrigger;
    private void Awake()
    {
        parentSpriteRenderer = transform.parent.GetComponent<SpriteRenderer>();
        jumpThroughTrigger = GetComponent<BoxCollider2D>();
        jumpThroughTrigger.size = new Vector2(parentSpriteRenderer.size.x, parentSpriteRenderer.size.y);
    }



    private void OnTriggerEnter2D(Collider2D jumper)
    {
        Debug.Log("trigger enter");
        //make the platform ignore the jumper
        var platform = transform.parent;
        Physics2D.IgnoreCollision(jumper, platform.GetComponent<BoxCollider2D>());
    }

    private void OnTriggerExit2D(Collider2D jumper)
    {
        Debug.Log("trigger exit");
        //re-enable collision between jumper and platform, so we can stand on top again
        var platform = transform.parent;
        Physics2D.IgnoreCollision(jumper, platform.GetComponent<BoxCollider2D>(), false);
    }
}
