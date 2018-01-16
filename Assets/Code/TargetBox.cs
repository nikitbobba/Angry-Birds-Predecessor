using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TargetBox : MonoBehaviour
{
    /// <summary>
    /// Targets that move past this point score automatically.
    /// </summary>
    public static float OffScreen;

    internal void Start() {
        OffScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width-100, 0, 0)).x;
    }

    internal void Update()
    {
        if (transform.position.x > OffScreen)
            Scored();
    }

    private void Scored()
    {
        
        SpriteRenderer render = gameObject.GetComponent<SpriteRenderer>();
        float mass = gameObject.GetComponent<Rigidbody2D>().mass;
        if (render.color != Color.green)
        {
            ScoreKeeper.AddToScore(mass);
            render.color = Color.green;
        }
    }


    internal void OnCollisionEnter2D(Collision2D x)
    {
        if (x.gameObject.tag == "Ground")
        {
            Scored();
        }
    }
}
