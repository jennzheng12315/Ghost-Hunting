using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleScript : MonoBehaviour
{
    //private Vector3 mousePosition;
    //private float increase = 0;
    //private Vector2 direction;
    //private bool moveToPosition;
    //public float moveSpeed = 0.1f;
    public float rate;
    private Vector3 mousePos;

    // Use this for initialization
    void Start()
    {

    }

    //void OnMouseDrag()
    //{
    //    Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //    Ray ray;
    //    ray = Camera.main.ScreenPointToRay(mouse);
    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, 10))
    //    {
    //        if (hit.point.x < transform.position.x)
    //        {
                //Debug.Log("Left");
    //            gameObject.transform.Translate(Vector3.left * Time.deltaTime * rate);
    //        }
    //        else if (hit.point.x > transform.position.x)
    //        {
                //Debug.Log("Right");
    //            gameObject.transform.Translate(Vector3.right * Time.deltaTime * rate);
    //        }
    //   }

    //    if (Physics.Raycast(ray, out hit, 10))
    //    {
    //        Debug.Log("y: " + (hit.point.y+.3) + "; z: " + transform.position.z);
    //        if (hit.point.y + .3 > transform.position.z)
    //        {
                //Debug.Log("Up");
    //            gameObject.transform.Translate(Vector3.up * Time.deltaTime * rate);
    //       }

     //       else if (hit.point.y + .3 < transform.position.z)
     //       {
                //Debug.Log("Down");
     //           gameObject.transform.Translate(Vector3.down * Time.deltaTime * rate);
     //       }
     //   }
    // }

    //void OnMouseDrag()
    //{
        //moveToPosition = true;
        //mousePosition = Input.mousePosition;
        //mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    //}

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(Vector3.up *
            Time.deltaTime * rate);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime *
            rate);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime
            * rate);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime *
            rate);
        }
    }
}
