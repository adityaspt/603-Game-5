using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;


public class PersonBlockUI : MonoBehaviour
{
    public Person person;
    [SerializeField]
    string personName = "";

    // Start is called before the first frame update
    void Start()
    {
        if (person != null)
            personName = person.Name;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
