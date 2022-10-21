using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Line : MonoBehaviour
{
    int vertexCount = 0;
    bool mouseDown = false;
    LineRenderer line;
    public GameObject explosion;
    

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    [System.Obsolete]
    private void Update()
    {
       if(Application.platform == RuntimePlatform.Android)
        {
            if(Input.touchCount > 0)
            {
                
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    line.SetVertexCount(vertexCount + 1);
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    line.SetPosition(vertexCount, mousePos);
                    vertexCount++;

                    BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
                    box.transform.position = line.transform.position;
                    box.size = new Vector2(0.1f, 0.1f);
                }

                if(Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    vertexCount = 0;
                    line.SetVertexCount(0);
                    //each collider in this array, we are storing that in this box variable
                    //and then we are destroying that.
                    BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
                    foreach (BoxCollider2D box in colliders)
                    {
                        Destroy(box);
                    }
                }
            }
        }

        //else if(Application.platform == RuntimePlatform.WindowsPlayer)
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseDown = true;
            }

            if (mouseDown)
            {
                line.SetVertexCount(vertexCount + 1);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(vertexCount, mousePos);
                vertexCount++;

                BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
                box.transform.position = line.transform.position;
                box.size = new Vector2(0.1f, 0.1f);
            }
            if (Input.GetMouseButtonUp(0))
            {
                mouseDown = false;
                vertexCount = 0;
                line.SetVertexCount(0);
                //each collider in this array, we are storing that in this box variable
                //and then we are destroying that.
                BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
                foreach (BoxCollider2D box in colliders)
                {
                    Destroy(box);
                }
           }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="bomb")
        {
            GameObject exp = Instantiate(explosion, collision.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            StartCoroutine(GameManager.instance.WaitForGameOverText(exp));

        }
    }

   

    

}
