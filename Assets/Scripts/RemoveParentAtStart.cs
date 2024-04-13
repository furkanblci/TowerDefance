using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveParentAtStart : MonoBehaviour
{
  
    void Start()
    {
        transform.parent = null;
    }

}
