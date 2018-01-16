using UnityEngine;

public class Bomb : MonoBehaviour {
    public float ThresholdForce = 2;
    public GameObject ExplosionPrefab;


    void Destruct()
    {
        GameObject.Destroy(gameObject);
    }

    void Boom()
    {
        PointEffector2D pe = gameObject.GetComponent<PointEffector2D>();
        pe.enabled = true;

        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.enabled = false;

        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);
        Invoke("Destruct", 0.1f);
    }

    internal void OnCollisionEnter2D(Collision2D x)
    {
        if (x.relativeVelocity.magnitude >= ThresholdForce)
        {
            Boom();
        }
    }
    
    
    
}
