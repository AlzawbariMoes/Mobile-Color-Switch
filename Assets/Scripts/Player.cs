using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpforce = 10f;
    public Rigidbody2D rb;
    public string currentColor;
    public SpriteRenderer sr;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMajenta;
    public Color colorPink;

    public GameObject WinnerPoint;

     



    private void Start()
    {
        SetRandomColor();
        WinnerPoint.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpforce;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag);

        if(collision.tag == "colorChanger")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }
        if(collision.tag != currentColor)
        {
            Debug.Log("GAMEOVER!!!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.tag == "WinnerPoint")
        {
            WinnerPoint.SetActive(true); 
        }

    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch(index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;

            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;   
                break;

            case 2:
                currentColor = "Magenta";
                sr.color = colorMajenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;

        }
    }


}
