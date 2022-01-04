using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    public GameObject thePoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.name == "Player")
        {
            Other.GetComponent<Player>().Score++;
            Instantiate(thePoint, new Vector2(Random.Range(-500, 501) * 0.01f, Random.Range(0, 601) * 0.01f), transform.rotation);
            Destroy(gameObject);
        }
    }
}
