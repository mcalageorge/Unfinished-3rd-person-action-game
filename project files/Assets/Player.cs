using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject arm;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float speed = 5f;
    float backSpeed = 2f;
    float sideSpeed = 150f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -sideSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, sideSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-backSpeed * Time.deltaTime, 0,0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            RaycastHit hit;
            Ray attackRay = new Ray(transform.position, transform.TransformDirection(Vector3.right));

            if(Physics.Raycast(attackRay, out hit, 4f))
            {
                if (hit.collider.tag == "enemy")
                {
                    print("attacked");
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
    void Attack() 
    {
        arm.transform.Rotate(0,0, -90f);
        StartCoroutine(AttackRewind(0.11f));
       
    }
    IEnumerator AttackRewind(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        arm.transform.Rotate(0, 0, -270f);
    }
}
