using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPA_Copper_Demo_Controller : MonoBehaviour {

    public GameObject[] sets;
    public Animation[] bows;
    private int currentSet = 0;
    private bool isAnimating = false;

    // Update is called once per frame
    void Update()
    {
        //disabling innactive sets and enabling active set
        for (int i = 0; i < sets.Length; i++)
        {
            if (i != currentSet)
            {
                sets[i].SetActive(false);
            }
            else sets[i].SetActive(true);
        }


        //movement for the sets
        if (transform.position.x > -6f)
        {
            if (Input.GetKeyDown(key: KeyCode.LeftArrow))
            {
                transform.position = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
            }
        }

        if (transform.position.x < 8)
        {
            if (Input.GetKeyDown(key: KeyCode.RightArrow))
            {
                transform.position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
            }
        }

        if (currentSet < (sets.Length - 1))
        {
            if (Input.GetKeyDown(key: KeyCode.UpArrow))
            {
                currentSet += 1;
                transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
            }
        }

        if (currentSet > 0)
        {
            if (Input.GetKeyDown(key: KeyCode.DownArrow))
            {
                currentSet -= 1;
                transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            }
        }

        //bow animation logic
        if (isAnimating == false && Input.GetKeyDown(key: KeyCode.Space))
        {
            isAnimating = true;
            foreach (Animation i in bows)
            {
                i.Play();
            }
        }
        else if (isAnimating == true && Input.GetKeyDown(key: KeyCode.Space))
        {
            isAnimating = false;
            foreach (Animation i in bows)
            {
                i.Stop();
            }
        }
    }
}
