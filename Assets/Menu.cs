using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public List<GameObject> Selected = new List<GameObject>();

    public void DeselectAll()
    {
        for (int i = 0; i < Selected.Count; i++)
        {
            Selected[i].SetActive(false);
        }
    }
}
