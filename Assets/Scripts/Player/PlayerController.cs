using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerLevel level;
    private PlayerAbility ability;

    // Start is called before the first frame update
    void Start()
    {
        this.level = GetComponent<PlayerLevel>();
        this.ability = GetComponent<PlayerAbility>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
