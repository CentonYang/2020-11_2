using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed = 5;
    public float Score = 0;
    public Text Scoretxt;
    public Text Result;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, 0);
        if (transform.position.x < -6)
            transform.position = new Vector2(6, transform.position.y);
        else if (transform.position.x > 6)
            transform.position = new Vector2(-6, transform.position.y);
        GetComponent<Rigidbody2D>().gravityScale = 1 + Score / 10;
        Scoretxt.text = "分數：" + ((int)Score).ToString("000000000");
        if (transform.position.y > 11 || transform.position.y < -11)
        {
            Time.timeScale = 0;
            Result.text = "任意鍵重新開始";
            if (Input.anyKeyDown)
            {
                Result.text = "";
                Score = 0;
                Time.timeScale = 1;
                SceneManager.LoadScene("Game");
            }
        }
    }
}