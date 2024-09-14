using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Exp : MonoBehaviour
{
    Player player;
    public float expAmount = 2f;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.AddExp(expAmount);
            Destroy(gameObject);
        }
    }
}
