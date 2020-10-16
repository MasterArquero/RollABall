using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (.2f, 80f, 15f) * Time.deltaTime);
    }
}
