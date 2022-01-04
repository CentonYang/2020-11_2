using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessBlock : MonoBehaviour
{
    public float Speed = 5;
    public GameObject theBlock;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "DeadBlock";
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 12)
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
        else
            Invoke("Spawn", Random.Range(3000, 6000) * 0.001f);
        Speed = 5 + (GameObject.Find("Player").GetComponent<Player>().Score / 10);
    }

    void Spawn()
    {
        Instantiate(theBlock, new Vector2(Random.Range(-400, 401) * 0.01f, -12), transform.rotation);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.name == "Player")
        {
            Other.gameObject.GetComponent<Player>().Score = Other.gameObject.GetComponent<Player>().Score > 2 ? Other.gameObject.GetComponent<Player>().Score - 2 : 0;
        }
    }

}
