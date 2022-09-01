using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pacman : MonoBehaviour
{
    public Movement movement { get; private set; }
    public Controls pacControls { get; private set; }
    private InputAction controleMouvement { get;  set; }

    void OnEnable()
    {
        controleMouvement = pacControls.Controles.Movements;
        controleMouvement.Enable();
    }

    void OnDisable()
    {
        controleMouvement.Disable();
    }


    void Awake()
    {
        movement = GetComponent<Movement>();
        pacControls = new Controls();
    }

    void Update()
    {
        Vector2 dir = controleMouvement.ReadValue<Vector2>();
        if(dir[1]>0.5)
        {
            movement.ChangerDirection(Vector2.up);
        }
        else if(dir[1]<-0.5)
        {
            movement.ChangerDirection(Vector2.down);
        }
        else if(dir[0]>0.5)
        {
            movement.ChangerDirection(Vector2.right);
        }
        else if(dir[0]<-0.5)
        {
            movement.ChangerDirection(Vector2.left);
        }
    }
}
