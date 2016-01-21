
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerControls : MonoBehaviour {

    const string SOLID_MODEL = "CubePrototype02x02x02";
    const string LIQUID_MODEL = "PlatformPrototype02x01x02";
    const string GAS_MODEL = "StepsPrototype04x02x02";

    private Player m_pPlayer; // Reference to the ball controller.

    private Vector3 move;
    // the world-relative desired move direction, calculated from the camForward and user input.

    private Transform cam; // A reference to the main camera in the scenes transform
    private Vector3 camForward; // The current forward direction of the camera
    private bool jump; // whether the jump button is currently pressed

    private bool e; // whether the 'e' key is pressed
    private bool e_up;// is 'e' key released


    private int m_iState;
    
    private Mesh m_pSolidMesh;
    private Mesh m_pLiquidMesh;
    private Mesh m_pGasMesh;

    private bool jump_debounce = false;

    private void SetMesh( Mesh target_mesh )
    {
        GetComponent<MeshFilter>().mesh = target_mesh;
        if (target_mesh == m_pSolidMesh)
        {
            GetComponent<SphereCollider>().enabled = false;
            GetComponents<BoxCollider>()[1].enabled = true;
            GetComponents<BoxCollider>()[0].enabled = false;
            GetComponent<MeshCollider>().enabled = false;
        }
        if (target_mesh == m_pLiquidMesh)
        {
            GetComponent<SphereCollider>().enabled = false;
            GetComponents<BoxCollider>()[1].enabled = false;
            GetComponents<BoxCollider>()[0].enabled = true;
            GetComponent<MeshCollider>().enabled = false;
        }
        if (target_mesh == m_pGasMesh)
        {
            GetComponent<SphereCollider>().enabled = false;
            GetComponents<BoxCollider>()[0].enabled = false;
            GetComponents<BoxCollider>()[1].enabled = false;
            GetComponent<MeshCollider>().enabled = true;
        }
    }
    
    private void Awake()
    {

        GameObject o;

        o = Instantiate(Resources.Load(SOLID_MODEL)) as GameObject;
        m_pSolidMesh = o.GetComponent<MeshFilter>().mesh;
        o.SetActive(false);

        o = Instantiate(Resources.Load(LIQUID_MODEL)) as GameObject;
        m_pLiquidMesh = o.GetComponent<MeshFilter>().mesh;
        o.SetActive(false);

        o = Instantiate(Resources.Load(GAS_MODEL)) as GameObject;
        m_pGasMesh = o.GetComponent<MeshFilter>().mesh;
        o.SetActive(false);

        SetMesh(m_pSolidMesh);
            
        // Set up the reference.
       m_pPlayer = GetComponent<Player>();


        // get the transform of the main camera
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        else
        {
            Debug.LogWarning(
                "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
            // we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
        }
    }


    private void Update()
    {
        // Get the axis and jump input.

        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        jump = CrossPlatformInputManager.GetButton("Jump");
        bool e = Input.GetKey(KeyCode.E);

        if (!jump)
            jump_debounce = false;

        if (!e)
            e_up = false;
        
        if ( jump && !jump_debounce )
            jump_debounce = true;
        
        if (e && !e_up)
        {
            e_up = true;
            m_iState++;
            if (m_iState > 2)
                m_iState = 0;
            switch(m_iState)
            {
                case 0:
                    SetMesh(m_pSolidMesh);
                    break;
                case 1:
                    SetMesh(m_pLiquidMesh);
                    break;
                case 2:
                    SetMesh(m_pGasMesh);
                    break;
            }
        }

          
        // calculate move direction
        if (cam != null)
        {
            // calculate camera relative direction to move:
            camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
            move = (v * camForward + h * cam.right).normalized;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            move = (v * Vector3.forward + h * Vector3.right).normalized;
        }
    }


    private void FixedUpdate()
    {
        // Call the Move function of the ball controller
        m_pPlayer.Move(move, jump);
        jump = false;
    }

}
