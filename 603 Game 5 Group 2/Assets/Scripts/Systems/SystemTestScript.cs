using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystems;

public class SystemTestScript : MonoBehaviour {
    Party party;

    // Start is called before the first frame update
    void Start() {
        party = new Party();
        party.Hire(new Person());
        party.People[0].Equip(new Equipment("Fork", new[] { 5, 0, 5 }));
        Debug.Log(party.People[0].Name);
        Debug.Log(party.People[0].Title);
        Debug.Log("STR: " + party.People[0].Stats[0] + ", DEX: " + party.People[0].Stats[1] + ", INT: " + party.People[0].Stats[2]);
        Debug.Log("STR: " + party.People[0].RollStats()[0] + ", DEX: " + party.People[0].RollStats()[1] + ", INT: " + party.People[0].RollStats()[2]);
    }
}
