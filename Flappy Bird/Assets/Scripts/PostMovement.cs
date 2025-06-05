using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
public class PostMovement : MonoBehaviour
{
    [SerializeField] private GameObject topPost;
    [SerializeField] private GameObject bottomPost;
    [SerializeField] private float xPos;
    [SerializeField] public float moveSpeed;
    private float startPos;
    private float timer;
    public bool gameStart = false;
    private float yGap = 8.5f;
    private bool haveShrunk = false;
    private bool haveSpedUp = false;
    private int lastShrinkScore = -1;

    void Start()
    {
        startPos = Random.Range(-7f, -1f);
        // Move bottom post
        bottomPost.transform.position = new Vector2(xPos, startPos);

        // Move top post (adjusted)
        topPost.transform.position = new Vector2(xPos, startPos + 8.5f);
    }
    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted())
            return;

        //Check position to send back to other side
        if (transform.position.x < -12)
        {
            startPos = Random.Range(-7f, -1f);
            bottomPost.transform.position = new Vector2(xPos, startPos);
            topPost.transform.position = new Vector2(xPos, startPos + yGap);

            haveShrunk = false;
        }

        //Timer
        if (Input.GetKey(KeyCode.Space) && !gameStart) 
        {
            gameStart = true;
        }
        if (gameStart)
        {
            timer += Time.deltaTime;
        }
        
        //When the different sets go off
        switch(gameObject.name)
        {
            case "Bot1 Electric Post1":
                if (timer > 0)
                {
                    movePipes();
                }
                break;
            case "Bot1 Electric Post2":
                if (timer > 3.5)
                {
                    movePipes();
                }
                break;
            case "Bot1 Electric Post3":
                if (timer > 7)
                {
                    movePipes();
                }
                break;
            case "Bot1 Electric Post4":
                if (timer > 10.5)
                {
                    movePipes();
                }
                break;
            default: break;
        }

        //Shrink gap
        int score = GameManager.Instance.getScore();
        if (score % 10 == 0 && score != 0 && score != lastShrinkScore && yGap > 6.75f)
        {
            yGap -= 0.25f;
            lastShrinkScore = score;
            // Don't reposition here!
        }

    }
    private void movePipes()
    {
        //Since flipped have to have two different move, moveTop
        Vector2 move = new Vector2(-1, 0);
        Vector2 moveTop = new Vector2(1, 0);
        topPost.transform.Translate(moveTop * Time.deltaTime * moveSpeed);
        bottomPost.transform.Translate(move * Time.deltaTime * moveSpeed);

        int score = GameManager.Instance.getScore();

        if (score % 5 == 0 && score != 0 && !haveSpedUp)
        {
            moveSpeed += 0.1f;
            haveSpedUp = true;
        }
        else if (score % 5 != 0)
        {
            haveSpedUp = false;
        }


    }
}
