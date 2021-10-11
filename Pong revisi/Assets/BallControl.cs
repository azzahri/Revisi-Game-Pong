using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    // Rigidbody 2D bola
    private Rigidbody2D rigidBody2D;

    // besar gaya awal
    public float xInitialForce;
    public float yInitialForce;

    public Vector2 TrajectoryOrigin;

    void ResetBall()
    {
        // reset posisi menjadi (0,0)
        transform.position = Vector2.zero;

        // reset kecepatan menjadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // tentuka nilai komponen y dari gaya dorong antara -y dan y
       // float randomInitialForceY = Random.Range(-yInitialForce, yInitialForce);

        // Tentukan nilai acak
        float randomDirection = Random.Range(0, 2);

        // jika nilai dibawah 1, bola bergerak kiri.
        // jika tidak, bola bergerak ke kanan
        if (randomDirection < 1.0f)
        {
            // gunakan gaya untuk menggerakkan bola
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yInitialForce));
        }

        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yInitialForce));
        }
    }

    void RestartGame()
    {
        // bola kembali ke posisi semula
        ResetBall();

        // setelah 2 detik, beri gaya ke bola
        Invoke("PushBall", 2);
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Mulai game
        RestartGame();

        TrajectoryOrigin = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TrajectoryOrigin = transform.position;
    }

    public Vector2 trajectoryOrigin
    {
        get { return TrajectoryOrigin; }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
