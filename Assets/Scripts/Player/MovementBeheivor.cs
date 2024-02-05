using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBeheivor : MonoBehaviour
{
    private Rigidbody2D _rb=null;
    [SerializeField]
    private float velocity;

    private void Start()
    {
        if(TryGetComponent(out Rigidbody2D _o))
        {
            _rb = _o;

        }
       // _rb = GetComponent<Rigidbody2D>();
       // TryGetComponent(out Rigidbody2D _rb) ;
    }
    public void Move(Vector3 direction)
    {
        transform.position = transform.position + velocity * direction * Time.deltaTime;
    }

    public void Move(float vel, Vector3 dir)
    {
        transform.position = transform.position + vel * dir * Time.deltaTime;
    }
    public void MovePosition(Vector3 direction)
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + velocity * direction * Time.deltaTime);
    }
    public void MoveRB(Vector3 direction)
    {
        if(_rb!=null)
        {


            _rb.velocity = direction;


        }
    }
    public float GetVelocity()
    {
        return velocity;
    }
}
