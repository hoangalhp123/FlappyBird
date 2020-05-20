using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgrMove : MonoBehaviour
{
    private GameObject obj;
    public float speedMove;
    public float moveRange;
    private Vector3 oldVector;
    private bool isStopBgr = false;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        speedMove = 3;
        moveRange = 20.5f;
        oldVector = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopBgr) {
            obj.transform.Translate(new Vector3(-1 * Time.deltaTime * speedMove, 0, 0));
            if (Vector3.Distance(oldVector, obj.transform.position) > moveRange)
            {
                obj.transform.position = oldVector;
            }
        }
        
    }

    public void StopBgr()
    {
        speedMove = 0;
    }
}
