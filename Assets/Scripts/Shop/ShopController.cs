using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public bool isAccessedByPlayer = false;

    private bool isOpen = false;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void ChangeShop()
    {
        Color color;
        if (isOpen)
        {
            color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
            isOpen = false;
        }
        else
        {
            color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 255f);
            isOpen = true;
        }
        spriteRenderer.color = color;
        gameObject.GetComponent<CircleCollider2D>().enabled = !gameObject.GetComponent<CircleCollider2D>().enabled;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") &&
            GameObject.FindGameObjectWithTag("RoundManager").GetComponent<RoundManager>().GetRoundState() 
            == GameObject.FindGameObjectWithTag("RoundManager").GetComponent<RoundManager>().peacefulState)
        {
            isAccessedByPlayer = true;
        }
    }
}
