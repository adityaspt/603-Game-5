using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameSystems;

public class EventTriggerSet 
{
    public class eventTrigger : EventArgs //Should rename this class to specifically something related to barscene and the interact NPC event
    {
        public Person personReference; //Person reference
        public GameObject personGameobjectReference; //Need to have the reference of the actual game object
    }
}
