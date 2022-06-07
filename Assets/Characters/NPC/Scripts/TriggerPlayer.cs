using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayer : MonoBehaviour
{
    public List<AttackAIController> _controllers;



    private void OnTriggerEnter(Collider other)
    {
        _controllers.RemoveAll(AttackAIController => AttackAIController == null);
        if (other.GetComponent<Player>() != null)
        {
            foreach(AttackAIController controller in _controllers)
            {
               
                    controller.StartAttack();
               
               
            }
            gameObject.SetActive(false); 
        }
    }
}
