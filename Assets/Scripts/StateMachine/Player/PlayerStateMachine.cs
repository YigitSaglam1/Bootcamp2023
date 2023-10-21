using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    //Okunabilir fakat sadece �zel olarak ayarlanabilir. Input Handler koruma amac�yla bu �ekilde public olarak a�t�m.
    [field: SerializeField] public InputHandler InputHandler { get; private set; }
    [field: SerializeField] public LayerMask GroundMask{ get; private set; }
    [field: SerializeField] public CharacterController CharacterController { get; private set; }
    [field: SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public float RiffleMovementSpeed{ get; private set; }

    public Camera MainCamera;

    [field: SerializeField,Header("GUN OPTIONS")]

    public Transform RiffleTip;

    [field: SerializeField, Header("ANIMATION DETECTION OPTIONS")]

    public AnimationDetection AnimationDetection;
    public bool isAnimationEnd;

    void Start()
    {
        SwitchState(new PlayerLocomotionState(this));
        MainCamera = Camera.main;
    }

    //private void Update()
    //{
    //    isAnimationEnd = AnimationDetection.IsAnimationEnd();
    //}


}
