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
    [field: SerializeField] public PlayerDamageHandler DamageHandler { get; private set; }
    [field: SerializeField] public float RiffleMovementSpeed{ get; private set; }
    [field: SerializeField] public Camera MainCamera { get; private set; }
    [field: SerializeField] public GunShoot gunShootScript { get; private set; }
    [field: SerializeField] public PauseMenuScript pauseMenuScript { get; private set; }

    [field: SerializeField,Header("GUN OPTIONS")]

    public Transform RiffleTip;

    [field: SerializeField, Header("ANIMATION DETECTION OPTIONS")]

    public AnimationDetection AnimationDetection;
    public SoundManager soundManager;
    public bool isAnimationEnd;



    private void OnEnable()
    {
        DamageHandler.OnDie += HandleDie;
    }
    private void OnDisable()
    {
        DamageHandler.OnDie -= HandleDie;
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.1f);
            soundManager.Load();
        }
        else
        {
            soundManager.Load();
        }
    }

    void Start()
    {
        SwitchState(new PlayerLocomotionState(this));
        MainCamera = Camera.main;
    }

    //private void Update()
    //{
    //    isAnimationEnd = AnimationDetection.IsAnimationEnd();
    //}

    private void HandleDie()
    {
        SwitchState(new PlayerDeathState(this));
    }

}
