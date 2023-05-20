//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Jam/PlayerInputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputMap"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""2500090d-52dc-4bca-a26a-553053f206f0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""27c8e93d-b736-45f1-ae80-cf5418290ee1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""ed00d1b9-ae40-44f1-a69c-672b97ca4555"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""23e55be3-57ed-44af-bf33-d8c406e4cc8f"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""5b4b7564-6c51-4eac-909c-f15a02f2e727"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b3bd9084-f0f0-4733-bcd8-874fb5e2d340"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1786a497-bc2f-4196-a61b-9697721d70a6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6b4b6b8c-e77f-4b30-b2d3-189f3fef5c7b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d7835d76-797c-42a2-a1e3-ec27f0d31421"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8dab4bb3-7d8d-4c4d-b184-f4b3e17226f1"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3849ea3c-a9a7-4981-a3b6-027cfbced19e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""OrthogonalMovement"",
            ""id"": ""52fe3e42-87b6-49a1-805e-1bf35cc44739"",
            ""actions"": [
                {
                    ""name"": ""UpDown"",
                    ""type"": ""Button"",
                    ""id"": ""2ee48d46-65af-4f5c-ab46-2e27c71a4da9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftRight"",
                    ""type"": ""Button"",
                    ""id"": ""9feb7501-148c-4df3-ae14-42f4c703056d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Trigger"",
                    ""type"": ""Button"",
                    ""id"": ""4cde5914-eccf-4d78-b53e-7bcee2f75cb6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""2eb49d3f-3be9-481c-9531-0946333d572f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""UpDown"",
                    ""id"": ""e448336b-c05d-4909-a967-8f7107544db4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ba731b87-0d4d-4076-a4c4-af339e7d3873"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""703867f7-4410-428a-9371-c8504a9f49bf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""832d6055-f202-430f-b0f4-224adca000cf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpDown"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""68dd228f-ae6a-437a-b8b5-615f77cb4d8e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6d378dd6-8f03-4522-a445-7b9451945d6f"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""UpDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftRight"",
                    ""id"": ""5d2e161e-b589-4b5d-985f-b40934a0078b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6e63b5aa-3ea0-4759-8779-5572743498b0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8d020352-a763-49fd-a542-f77b6a769208"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a32c58f3-2d23-4da0-886d-5547b5f99c66"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f20ead3c-1ba4-4bc6-9299-1e13b0c5ec38"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ff3df9e0-ba26-449b-8ddd-49d54b06c690"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""af4f01aa-b969-4e02-9013-3694eecacfc6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4021c3e-1dd0-4b40-a9d2-9eb3280aa423"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Trigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0e18d12-2220-4dbd-91b1-abd03aacea00"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b38bd65f-b955-408b-a045-fa526d479aef"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""57fb63af-6fda-447e-936b-096e3cb25b5b"",
            ""actions"": [
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""c60b231b-e8b8-4c24-b1c6-4ad3addf55d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Quit"",
                    ""type"": ""Button"",
                    ""id"": ""f635cfdd-3b47-440b-93a5-2a225315e5b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""ddd8b769-7e7f-4ced-9bde-1c2fbe5bb537"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Credits"",
                    ""type"": ""Button"",
                    ""id"": ""66c97458-a563-410c-979c-fdccaa5f5a46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""570ec78f-0bc5-498c-8a3d-093a0897b889"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d551deef-4627-4a5c-8962-2cad91c91831"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Quit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2cbde01b-b50d-4b0a-b385-6d97c35ce930"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f919034-1ee7-406b-847e-1e4bb37895a6"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Credits"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""baad71d9-ab18-4c68-bb54-734b02433b27"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""602d0425-796a-4a04-abb7-f8dab85d1a17"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MKB"",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MKB"",
            ""bindingGroup"": ""MKB"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Trigger = m_Movement.FindAction("Trigger", throwIfNotFound: true);
        // OrthogonalMovement
        m_OrthogonalMovement = asset.FindActionMap("OrthogonalMovement", throwIfNotFound: true);
        m_OrthogonalMovement_UpDown = m_OrthogonalMovement.FindAction("UpDown", throwIfNotFound: true);
        m_OrthogonalMovement_LeftRight = m_OrthogonalMovement.FindAction("LeftRight", throwIfNotFound: true);
        m_OrthogonalMovement_Trigger = m_OrthogonalMovement.FindAction("Trigger", throwIfNotFound: true);
        m_OrthogonalMovement_Exit = m_OrthogonalMovement.FindAction("Exit", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Start = m_Menu.FindAction("Start", throwIfNotFound: true);
        m_Menu_Quit = m_Menu.FindAction("Quit", throwIfNotFound: true);
        m_Menu_Pause = m_Menu.FindAction("Pause", throwIfNotFound: true);
        m_Menu_Credits = m_Menu.FindAction("Credits", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Trigger;
    public struct MovementActions
    {
        private @PlayerInputMap m_Wrapper;
        public MovementActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Trigger => m_Wrapper.m_Movement_Trigger;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Trigger.started += instance.OnTrigger;
            @Trigger.performed += instance.OnTrigger;
            @Trigger.canceled += instance.OnTrigger;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Trigger.started -= instance.OnTrigger;
            @Trigger.performed -= instance.OnTrigger;
            @Trigger.canceled -= instance.OnTrigger;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // OrthogonalMovement
    private readonly InputActionMap m_OrthogonalMovement;
    private List<IOrthogonalMovementActions> m_OrthogonalMovementActionsCallbackInterfaces = new List<IOrthogonalMovementActions>();
    private readonly InputAction m_OrthogonalMovement_UpDown;
    private readonly InputAction m_OrthogonalMovement_LeftRight;
    private readonly InputAction m_OrthogonalMovement_Trigger;
    private readonly InputAction m_OrthogonalMovement_Exit;
    public struct OrthogonalMovementActions
    {
        private @PlayerInputMap m_Wrapper;
        public OrthogonalMovementActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @UpDown => m_Wrapper.m_OrthogonalMovement_UpDown;
        public InputAction @LeftRight => m_Wrapper.m_OrthogonalMovement_LeftRight;
        public InputAction @Trigger => m_Wrapper.m_OrthogonalMovement_Trigger;
        public InputAction @Exit => m_Wrapper.m_OrthogonalMovement_Exit;
        public InputActionMap Get() { return m_Wrapper.m_OrthogonalMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OrthogonalMovementActions set) { return set.Get(); }
        public void AddCallbacks(IOrthogonalMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_OrthogonalMovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_OrthogonalMovementActionsCallbackInterfaces.Add(instance);
            @UpDown.started += instance.OnUpDown;
            @UpDown.performed += instance.OnUpDown;
            @UpDown.canceled += instance.OnUpDown;
            @LeftRight.started += instance.OnLeftRight;
            @LeftRight.performed += instance.OnLeftRight;
            @LeftRight.canceled += instance.OnLeftRight;
            @Trigger.started += instance.OnTrigger;
            @Trigger.performed += instance.OnTrigger;
            @Trigger.canceled += instance.OnTrigger;
            @Exit.started += instance.OnExit;
            @Exit.performed += instance.OnExit;
            @Exit.canceled += instance.OnExit;
        }

        private void UnregisterCallbacks(IOrthogonalMovementActions instance)
        {
            @UpDown.started -= instance.OnUpDown;
            @UpDown.performed -= instance.OnUpDown;
            @UpDown.canceled -= instance.OnUpDown;
            @LeftRight.started -= instance.OnLeftRight;
            @LeftRight.performed -= instance.OnLeftRight;
            @LeftRight.canceled -= instance.OnLeftRight;
            @Trigger.started -= instance.OnTrigger;
            @Trigger.performed -= instance.OnTrigger;
            @Trigger.canceled -= instance.OnTrigger;
            @Exit.started -= instance.OnExit;
            @Exit.performed -= instance.OnExit;
            @Exit.canceled -= instance.OnExit;
        }

        public void RemoveCallbacks(IOrthogonalMovementActions instance)
        {
            if (m_Wrapper.m_OrthogonalMovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IOrthogonalMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_OrthogonalMovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_OrthogonalMovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public OrthogonalMovementActions @OrthogonalMovement => new OrthogonalMovementActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private List<IMenuActions> m_MenuActionsCallbackInterfaces = new List<IMenuActions>();
    private readonly InputAction m_Menu_Start;
    private readonly InputAction m_Menu_Quit;
    private readonly InputAction m_Menu_Pause;
    private readonly InputAction m_Menu_Credits;
    public struct MenuActions
    {
        private @PlayerInputMap m_Wrapper;
        public MenuActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Start => m_Wrapper.m_Menu_Start;
        public InputAction @Quit => m_Wrapper.m_Menu_Quit;
        public InputAction @Pause => m_Wrapper.m_Menu_Pause;
        public InputAction @Credits => m_Wrapper.m_Menu_Credits;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void AddCallbacks(IMenuActions instance)
        {
            if (instance == null || m_Wrapper.m_MenuActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MenuActionsCallbackInterfaces.Add(instance);
            @Start.started += instance.OnStart;
            @Start.performed += instance.OnStart;
            @Start.canceled += instance.OnStart;
            @Quit.started += instance.OnQuit;
            @Quit.performed += instance.OnQuit;
            @Quit.canceled += instance.OnQuit;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Credits.started += instance.OnCredits;
            @Credits.performed += instance.OnCredits;
            @Credits.canceled += instance.OnCredits;
        }

        private void UnregisterCallbacks(IMenuActions instance)
        {
            @Start.started -= instance.OnStart;
            @Start.performed -= instance.OnStart;
            @Start.canceled -= instance.OnStart;
            @Quit.started -= instance.OnQuit;
            @Quit.performed -= instance.OnQuit;
            @Quit.canceled -= instance.OnQuit;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Credits.started -= instance.OnCredits;
            @Credits.performed -= instance.OnCredits;
            @Credits.canceled -= instance.OnCredits;
        }

        public void RemoveCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMenuActions instance)
        {
            foreach (var item in m_Wrapper.m_MenuActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MenuActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    private int m_MKBSchemeIndex = -1;
    public InputControlScheme MKBScheme
    {
        get
        {
            if (m_MKBSchemeIndex == -1) m_MKBSchemeIndex = asset.FindControlSchemeIndex("MKB");
            return asset.controlSchemes[m_MKBSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnTrigger(InputAction.CallbackContext context);
    }
    public interface IOrthogonalMovementActions
    {
        void OnUpDown(InputAction.CallbackContext context);
        void OnLeftRight(InputAction.CallbackContext context);
        void OnTrigger(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
        void OnStart(InputAction.CallbackContext context);
        void OnQuit(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnCredits(InputAction.CallbackContext context);
    }
}