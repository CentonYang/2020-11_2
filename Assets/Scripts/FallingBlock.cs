using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float Speed = 5;
    public GameObject theBlock;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        gameObject.name = "FallingBlock";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 12 && transform.position.y > -13)
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
        else
            Invoke("Spawn", Random.Range(2000, 8000) * 0.001f);
    }

    void Spawn()
    {
        Instantiate(theBlock, new Vector2(Random.Range(-400, 401) * 0.01f, -12), Quaternion.Euler(0, 0, 0));
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.name == "Player")
        {
            Invoke("Falling", 1);
        }
        Speed = 5 + (GameObject.Find("Player").GetComponent<Player>().Score / 10);
    }

    void Falling()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
