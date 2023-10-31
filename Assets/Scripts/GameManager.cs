using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float timeCount;
    public GameObject[] fruits;
    public GameObject fruitContainer;
    public GameObject currentFruit;

    public bool drop = false;

    public int currentIndex = 123456;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    instance = singletonObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    void Start()
    {
        RandomFruit();
    }

    // Update is called once per frame
    void Update()
    {
        DropFruit();
    }
    void DropFruit()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !drop)
        {
            drop = true;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            mousePosition.y = fruitContainer.transform.position.y;
            Instantiate(currentFruit, mousePosition, Quaternion.identity);
        }
        if(drop)
        {
            fruitContainer.SetActive(false);
        }
        else
        {
            fruitContainer.SetActive(true);
        }
    }
    public void RandomFruit()
    {
        int index = Random.Range(0, fruits.Length - 1);
        currentIndex = index;
        currentFruit = fruits[index];
        fruitContainer.GetComponent<SpriteRenderer>().sprite = fruits[index].GetComponent<SpriteRenderer>().sprite;
    }
}
