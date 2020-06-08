﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTrigger : MonoBehaviour{

    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            PlayerController.sharedInstance.Kill();
        }
    }
}
