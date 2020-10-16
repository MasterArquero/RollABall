using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float ForceMultiplier;

    private float _moveHorizontal, _moveVertical;
    private Rigidbody _rigibody;
    private bool isJumping = false;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        _rigibody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            _rigibody.AddForce(0, 5f, 0, ForceMode.Impulse);
        }
    }
    // 60 times per second
    private void FixedUpdate()
    {
        _moveHorizontal = Input.GetAxis("Horizontal") * ForceMultiplier;
        _moveVertical = Input.GetAxis("Vertical") * ForceMultiplier;
        
        _rigibody.AddForce(_moveHorizontal, 0, _moveVertical);
    }
   
    private void OnCollisionEnter(Collision other)
    {
        isJumping = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }
}
