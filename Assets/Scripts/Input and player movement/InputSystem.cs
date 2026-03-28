using UnityEngine;

/*
* This is the input system class. it is used for detecting and mapping inputs. 
* I am well aware Unity already has an input system, but this will simplify the process of changing the inputs during gameplay
* 
* For a new input just instantiate it, assign it a value, and add a getter and a setter in the "Getter and Setter" region.
*/
public class InputSystem : MonoBehaviour
{
    [SerializeField] private KeyCode moveForward, moveLeft, moveRight, moveBack, sprint, jump, crouch, fire1, fire2, interact, inventory;
    private KeyCode[] myKeys = new KeyCode[15];

    void Start()
    {
        moveForward = KeyCode.W;
        moveBack = KeyCode.S;
        moveLeft = KeyCode.A;
        moveRight = KeyCode.D;
        sprint = KeyCode.LeftShift;
        jump = KeyCode.Space;
        crouch = KeyCode.LeftControl;
        fire1 = KeyCode.Mouse0;
        fire2 = KeyCode.Mouse1;
        interact = KeyCode.F;
        inventory = KeyCode.Tab;

        myKeys[0] = moveForward;
        myKeys[1] = moveBack;
        myKeys[2] = moveLeft;
        myKeys[3] = moveRight;
        myKeys[4] = sprint;
        myKeys[5] = jump;
        myKeys[6] = crouch;
        myKeys[7] = fire1;
        myKeys[8] = fire2;
        myKeys[9] = interact;
        myKeys[10] = inventory;
    }

    #region Getters and setters
    //Forwards
    public KeyCode getForward()
    {

        return moveForward;
    }
    public void setforward(KeyCode input)
    {
        moveForward = input;
    }
    //backwards
    public KeyCode getBack()
    {

        return moveBack;
    }
    public void setBack(KeyCode input)
    {
        moveBack = input;
    }
    //Left
    public KeyCode getLeft()
    {

        return moveLeft;
    }
    public void setLeft(KeyCode input)
    {
        moveLeft = input;
    }
    //right
    public KeyCode getRight()
    {

        return moveRight;
    }
    public void setRight(KeyCode input)
    {
        moveRight = input;
    }
    //Sprint
    public KeyCode getSprint()
    {

        return sprint;
    }
    public void setSprint(KeyCode input)
    {
        sprint = input;
    }
    //Jump
    public KeyCode getJump()
    {

        return jump;
    }
    public void setJump(KeyCode input)
    {
        jump = input;
    }
    //Crouch
    public KeyCode getCrouch()
    {

        return crouch;
    }
    public void setCrouch(KeyCode input)
    {
        crouch = input;
    }
    //Fire1
    public KeyCode getFire1()
    {

        return fire1;
    }
    public void setFire1(KeyCode input)
    {
        fire1 = input;
    }
    //Fire2
    public KeyCode getFire2()
    {

        return fire2;
    }
    public void setFire2(KeyCode input)
    {
        fire2 = input;
    }
    //interact
    public KeyCode getInteract()
    {

        return interact;
    }
    public void setInteract(KeyCode input)
    {
        interact = input;
    }
    //drop Item
    public KeyCode getInventory()
    {

        return inventory;
    }
    public void setInventory(KeyCode input)
    {
        inventory = input;
    }

    #endregion

}
