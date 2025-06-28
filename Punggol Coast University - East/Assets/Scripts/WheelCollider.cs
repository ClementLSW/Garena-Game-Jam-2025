using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCollider : MonoBehaviour
{
    public int colliderIndex;

    public GameObject collider1;
    public GameObject collider8;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AnswerBox")
        {
            if (colliderIndex == 4)
            {
                other.gameObject.GetComponent<AnswerBoxControl>().isAnswer = true;
            }
            else
            {
                other.gameObject.GetComponent<AnswerBoxControl>().isAnswer = false;
            }

            if (colliderIndex == 1 || colliderIndex == 2 || colliderIndex == 6 || colliderIndex == 7 || colliderIndex == 8)
            {
                //other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                other.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    //public void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "AnswerBox")
    //    {
    //        if (colliderIndex == 2)
    //        {
    //            other.gameObject.transform.position = collider8.transform.position;
    //            other.gameObject.GetComponent<AnswerBoxControl>().boxPosition = 8;
    //        }
    //        if (colliderIndex == 7)
    //        {
    //            other.gameObject.transform.position = collider1.transform.position;
    //            other.gameObject.GetComponent<AnswerBoxControl>().boxPosition = 1;
    //        }
    //    }
    //}
}