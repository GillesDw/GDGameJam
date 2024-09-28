using System.Collections.Generic;
using UnityEngine;

public class DNACount : MonoBehaviour, IInteractable
{
    BoxCollider coll;

    private void Start()
    {
        coll = GetComponent<BoxCollider>();
    }

    public void Interact()
    {
        coll.enabled = false;
        AddDNACount();  
    }

    public void AddDNACount()
    {
        DNAManager.AddDNACount();
    }
}
