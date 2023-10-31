using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int level;


    public bool isNew = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fruit")
        {
            if (collision.gameObject.GetComponent<Fruit>().level == level)
            {
                level += 999;
                Debug.Log("Merge fruit");
                Destroy(collision.gameObject);
                if (isNew)
                {
                    isNew = false;
                    GameManager.Instance.drop = false;
                }
                
                Vector3 targetPosition = (transform.position + collision.transform.position) / 2.0f;

                GameObject fruit = Instantiate(GameManager.Instance.fruits[collision.gameObject.GetComponent<Fruit>().level], targetPosition, Quaternion.identity);
                fruit.GetComponent<Fruit>().isNew = false;

                GameManager.Instance.RandomFruit();

                Destroy(gameObject);
                Destroy(collision.gameObject);
                

            }
            else
            {
                Debug.Log("Fruit collision");
                if (isNew)
                {
                    isNew = false;
                    GameManager.Instance.drop = false;
                    GameManager.Instance.RandomFruit();
                }
            }
        }
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("Touch ground");
            if (isNew)
            {
                isNew = false;
                GameManager.Instance.drop = false;
                GameManager.Instance.RandomFruit();
            }
        }
    }
}
