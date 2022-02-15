using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{

    [Space(5)]
    [Header("Coin System")]
    [SerializeField] private int coinScore = 10;

    [Space(5)]
    [Header("GameObject Caller")]
    private GameManager _gM;

    private void Awake()
    {

        _gM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    #region OnTriggerEnter, OnTriggerStay or OnTriggerExit

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            Destroy(this.gameObject);
            _gM.AddScore(coinScore);

        }

    }

    #endregion

}
