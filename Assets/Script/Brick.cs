using UnityEngine.UI;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health;
    public SpriteRenderer spriteRenderer;
    public Sprite[] states;
    public bool unBreakAble;
    public int points = 10;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        ResetBrick();
    }
    private void Hit()
    {
        if (unBreakAble)
        {
            return;
        }
        health--;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            spriteRenderer.sprite = states[health - 1];
        }
        FindObjectOfType<GameManager>().Score(this);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ball")
        {
            Hit();

        }
    }
    public void ResetBrick()
    {
        gameObject.SetActive(true);
        if (!unBreakAble)
        {
            health = states.Length;
            spriteRenderer.sprite = states[health - 1];
        }
    }
}
