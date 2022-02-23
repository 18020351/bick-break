using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ballRb;
    public float speed = 300;
    public Text textScore;
    public Text textLive;
    private void Awake()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ResetBall();
    }
    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2(Random.Range(-1f, 1f), -1f);
        ballRb.AddForce(force.normalized * speed);
    }
    public void ResetBall()
    {
        transform.position = Vector2.zero;
        ballRb.velocity = Vector2.zero;
        Invoke(nameof(SetRandomTrajectory), 1f);
    }
    private void Update()
    {
        int score = FindObjectOfType<GameManager>().score;
        int live = FindObjectOfType<GameManager>().lives;
        textScore.text = "Score: " + score;
        textLive.text = "Lives: " + live;
    }
}
