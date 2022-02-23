using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10;
    private float posYBound = -3;
    public new Rigidbody2D rigidbody { get; private set; }
    public Vector2 direction { get; private set; }
    public float maxBounceAngle = 75f;
    private void Awake()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //rigidbody.AddForce(Vector2.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
    }
    //tính góc nảy cho bóng khi chạm vào thuyền.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float maxOffset = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.ballRb.velocity);
            float bounceAngle = (offset / maxOffset) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.ballRb.velocity = rotation * Vector2.up * ball.ballRb.velocity.magnitude;
        }
    }
    public void ResetPaddle()
    {
        transform.position = new Vector2(0f, transform.position.y);
    }

}
