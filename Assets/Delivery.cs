using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    bool hasPackage = false;

    [SerializeField] float destroyDelay = 0.3f;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision");
        Debug.Log(other.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked");
            hasPackage = true;

            Destroy(other .gameObject, destroyDelay);
            spriteRenderer.color = hasPackageColor;

        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Customer received");
            hasPackage = false;

            spriteRenderer.color = noPackageColor;
        }
    }
}
