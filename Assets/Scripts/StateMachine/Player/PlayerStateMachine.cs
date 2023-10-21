using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    //Okunabilir fakat sadece özel olarak ayarlanabilir. Input Handler koruma amacýyla bu þekilde public olarak açtým.
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
