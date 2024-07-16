using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateaucollider : MonoBehaviour
{
    [SerializeField] private GameObject winntertext;
    public bool gewonnen = false;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "bodenflaeche")
        {
            Debug.Log("Collided");
            if (!gewonnen)
            {
                gewonnen = true;
                winntertext.SetActive(true);
            }
        }
    }
}
