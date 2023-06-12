using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Vector2 pastPosition;
    public float velocity = 1f;
    //public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            //mousePosition agora - mousePosition passado
            Move(Input.mousePosition.x - pastPosition.x);
        }
        pastPosition = Input.mousePosition;
    }
    public void Move(float speed)
    {
        //rb.AddForce(Vector3.right * speed * Time.deltaTime * velocity);
        transform.position += Vector3.right * Time.deltaTime * speed * velocity;
    }
}
