using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public GameObject cut1;
    public GameObject cut2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="line")
        {
            GameObject c1 = Instantiate(cut1, transform.position, Quaternion.identity) as GameObject;
            GameObject c2 = Instantiate(cut2, new Vector3(transform.position.x-0.5f,transform.position.y,0),cut2.transform.rotation) as GameObject;

            c1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 2f), ForceMode2D.Impulse);
            c1.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2f, 2f), ForceMode2D.Impulse);

            c2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 2f), ForceMode2D.Impulse);
            c2.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-2f, 2f), ForceMode2D.Impulse);

            Destroy(gameObject);
        }
    }
}
