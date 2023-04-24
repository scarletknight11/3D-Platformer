using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public GameObject coin;
    

    // Update is called once per frame
    void Update()
    {
        coin.transform.Rotate(0,15,0); 
    }
}
