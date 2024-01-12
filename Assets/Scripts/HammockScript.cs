using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammockScript : MonoBehaviour
{
    [SerializeField]
    private float _bounce = 20.0f;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            //Fling the player code here
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * _bounce, ForceMode.Impulse);
        }
    }
}
