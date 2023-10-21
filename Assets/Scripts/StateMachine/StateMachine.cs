using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState;

    private void Update()
    {
        if (currentState != null){
            currentState.Tick(Time.deltaTime);
            
        }
        //Alternatif yol -- currentState?.Tick(Time.deltaTime);
    }

    public void SwitchState(State newState)
    {
        if (currentState != null)
        { //eðer bir state varsa çýk
            currentState.Exit();
        }
        //haricinde yeni state e geç
        currentState = newState;
        currentState.Enter();
    }
}
