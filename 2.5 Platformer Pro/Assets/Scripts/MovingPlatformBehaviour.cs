using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{

    [Header("MovingPlatformBehaviour Variable")]
    [SerializeField] private float _moving_speed = 3f;
    [SerializeField] private Vector3 _pointA, _pointB;
    Vector3 m_TargetPosition;

    private void Awake()
    {

        

    }

    void FixedUpdate()
    {

        MovingPlatformMovement();
        
    }

    #region PlatformMovement

    void MovingPlatformMovement()
    {

        float step = _moving_speed * Time.deltaTime;


        if (this.transform.position == _pointA)
        {

            m_TargetPosition = _pointB;

        }
        else if (this.transform.position == _pointB)
        {

            m_TargetPosition = _pointA;

        }

        this.transform.position = Vector3.MoveTowards(this.transform.position, m_TargetPosition, step);

    }

    #endregion

    #region OnTriggerEnter, OnTriggerStay, OnTriggerExit 

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            other.transform.parent = this.transform;

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {

            other.transform.parent = null;

        }

    }

    #endregion

}
