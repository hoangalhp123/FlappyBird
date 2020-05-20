using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    private GameObject obj;
    public float speedMove;

    public float minY;
    public float maxY;
    public float oldPosition;
    private bool isStartGame = false;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        speedMove = 5;
        oldPosition = 4;
        minY = -1;
        maxY = 1;
        obj.transform.position = new Vector3(obj.transform.position.x, Random.Range(minY, maxY + 1), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isStartGame = true;
        }
        if (isStartGame)
        {
            obj.transform.Translate(new Vector3(-1 * Time.deltaTime * speedMove, 0, 0));
        }
        
    }

    public void StopWall()
    {
        speedMove = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ResetWall"))
        {
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
        }

    }

}
