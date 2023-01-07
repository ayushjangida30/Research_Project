using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField]
    private float mainSpeed = 50f;

    [SerializeField]
    private float shiftAdd = 250f;
    [SerializeField]
    private float shiftMax = 1000f;

    [SerializeField]
    private float sensitivity = 0.25f;

    private Vector3 lastMouse;

    private float totalRun;

    private int mode = -1;
    private TMPro.TextMeshProUGUI modeText;

    private bool isTeleport;
    private float positionStep;
    private float rotationStep;
    private Vector3 targetPosition;
    private Vector3 targetRotation;

    private void Start() {
        lastMouse = new Vector3(255, 255, 255);

        totalRun = 1.0f;

        mode = 0;

        modeText = GameObject.Find("/UI/CameraMode").GetComponent<TMPro.TextMeshProUGUI>();
        modeText.text = "Exploration Mode";

        isTeleport = false;
        targetPosition = Vector3.zero;
    }

    private void Update() {
        if(isTeleport) {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, positionStep * Time.deltaTime);

            if(targetRotation == Vector3.zero) {
                transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, Vector3.forward, rotationStep * Time.deltaTime, 0f));
            }
            else {
                transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, targetRotation, rotationStep * Time.deltaTime, 0f));
            }

            if(targetPosition == transform.position) {
                isTeleport = false;
            }
        }
    }

    private void FixedUpdate() {
        if(isTeleport) {
            return;
        }

        if(Input.GetMouseButtonDown(1)) {
            lastMouse = Input.mousePosition;
        }

        if(Input.GetMouseButton(1)) {
            lastMouse = Input.mousePosition - lastMouse;
            lastMouse = new Vector3(-1 * lastMouse.y * sensitivity, lastMouse.x * sensitivity, 0);
            lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
            transform.eulerAngles = lastMouse;

            lastMouse = Input.mousePosition;
        }

        Vector3 displacement = GetBaseInput();

        if(Input.GetKey(KeyCode.LeftShift)) {
            totalRun += Time.deltaTime;

            displacement = displacement * totalRun * shiftAdd;
            displacement.x = Mathf.Clamp(displacement.x, -1 * shiftMax, shiftMax);
            displacement.y = Mathf.Clamp(displacement.y, -1 * shiftMax, shiftMax);
            displacement.y = Mathf.Clamp(displacement.z, -1 * shiftMax, shiftMax);
        }
        else {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);

            displacement = displacement * mainSpeed;
        }

        displacement = displacement * Time.deltaTime;

        Vector3 newPosition = transform.position;

        if(Input.GetKey(KeyCode.Space)) {
            transform.Translate(displacement);

            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;

            transform.position = newPosition;
        }
        else {
            transform.Translate(displacement);
        }

        Vector3 terrainHeight = GlobalMethods.Instance.SnapToTerrainHeightmap(transform.position);

        if(mode == 0) {
            if(transform.position.y < terrainHeight.y) {
                transform.position = terrainHeight;
            }
        }
        else if(mode == 1) {
            transform.position = terrainHeight + (Vector3.up * GlobalProperties.Instance.ViewerHeight);

            if(Input.GetKey(KeyCode.Escape)) {
                SetMode(0);
            }
        }
    }

    public int GetMode() {
        return mode;
    }

    public void SetMode(int mode) {
        this.mode = mode;

        if(mode == 0) {
            modeText.text = "Exploration Mode";
        }
        else if(mode == 1) {
            modeText.text = "First-person Mode (Press ESC to escape.)";
        }
    }

    public void Teleport(Vector3 position) {
        isTeleport = true;
        positionStep = (position - transform.position).magnitude / GlobalProperties.Instance.CameraTeleportTime;
        rotationStep = Vector3.Angle(Vector3.forward, transform.forward) * Mathf.Deg2Rad / GlobalProperties.Instance.CameraTeleportTime;
        targetPosition = position;
        targetRotation = Vector3.zero;
    }

    public void Teleport(Vector3 position, Vector3 rotation) {
        isTeleport = true;
        positionStep = (position - transform.position).magnitude / GlobalProperties.Instance.CameraTeleportTime;
        rotationStep = Vector3.Angle((rotation - transform.position), transform.forward) * Mathf.Deg2Rad / GlobalProperties.Instance.CameraTeleportTime;
        targetPosition = position;
        targetRotation = rotation;
    }

    private Vector3 GetBaseInput() {
        Vector3 velocity = Vector3.zero;

        if(Input.GetKey(KeyCode.D)) {
            velocity += new Vector3(1, 0, 0);
        }
        if(Input.GetKey(KeyCode.A)) {
            velocity -= new Vector3(1, 0, 0);
        }
        if(Input.GetKey(KeyCode.E)) {
            velocity += new Vector3(0, 1, 0);
        }
        if(Input.GetKey(KeyCode.Q)) {
            velocity -= new Vector3(0, 1, 0);
        }
        if(Input.GetKey(KeyCode.W)) {
            velocity += new Vector3(0, 0, 1);
        }
        if(Input.GetKey(KeyCode.S)) {
            velocity -= new Vector3(0, 0, 1);
        }

        return velocity;
    }
}
