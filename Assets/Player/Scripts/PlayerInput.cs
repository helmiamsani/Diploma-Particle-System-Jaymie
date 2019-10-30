using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float mouseX;
    public float mouseY;
    public float moveToward;
    public float moveSide;
    public bool fire1;
    public bool scope;
    public bool run;
    public bool jump;
    public bool crouch;
    public bool getDown;
    public bool interact;

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X"); // Input for moving mouse on the X axis.
        mouseY = Input.GetAxis("Mouse Y"); // Input for moving mouse on the Y axis.
        moveToward = Input.GetAxis("Horizontal"); // Input for moving player toward.
        moveSide = Input.GetAxis("Vertical"); // Input for moving player backward.
        fire1 = Input.GetMouseButtonDown(0); // Input for firing.
        scope = Input.GetMouseButton(1); // Input for scoping.
        run = Input.GetKey(KeyCode.LeftShift); // Input for run.
        jump = Input.GetKeyDown(KeyCode.Space); // Input for jumping.
        crouch = Input.GetKeyDown(KeyCode.C); // Input for crouch.
        getDown = Input.GetKeyDown(KeyCode.LeftControl); // Input for getdown.
        interact = Input.GetKey(KeyCode.E); // Input for interact.
    }
}
