using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{

    [SerializeField] private GameObject topBuildings;
    [SerializeField] private GameObject bottomBuildings;
    public PostMovement postMovement;
    private float speed;
    


    // Start is called before the first frame update
    void Start()
    {
        speed = postMovement.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGameStarted())
            return;

        Vector2 move = new Vector2(-1, 0);
        Vector2 moveTop = new Vector2(-1, 0);
        topBuildings.transform.Translate(moveTop * Time.deltaTime * speed *.5f);
        bottomBuildings.transform.Translate(move * Time.deltaTime * speed*.5f);

        if (transform.position.x < -25)
        {
            topBuildings.transform.position = new Vector2(30, transform.position.y);
            bottomBuildings.transform.position = new Vector2(30, transform.position.y);
        }
    }
}
