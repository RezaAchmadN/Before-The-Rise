using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changealpha : MonoBehaviour
{
    public float start;
    public float end;
    public Transform player;
    float alphaLevel = .0f;
    float xPos;

    public GameObject namePlace;
    bool namePlaceAppear = true;

    
    
    // Start is called before the first frame update
    void Start()
    {
        namePlace.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        xPos = player.transform.position.x;
        if(xPos>=end-10) alphaLevel = ((end-xPos)*.1f);
        else if(xPos>=start) alphaLevel = ((xPos-start)*.1f);
        GetComponent<SpriteRenderer>().color = new Color(1,1,1,alphaLevel);

        if(xPos>=start && namePlaceAppear)
        {
            namePlace.SetActive(true);
            namePlaceAppear = false;
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(namePlace);
    }
}
