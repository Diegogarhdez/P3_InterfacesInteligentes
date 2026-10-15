using UnityEngine;
using UnityEngine.InputSystem;

public class Lanzador : MonoBehaviour {
  public float fuerzaLanzamiento = 10f;
  private Rigidbody rb;

  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void Update() {
    if (Keyboard.current != null && Keyboard.current.xKey.wasPressedThisFrame) {
      rb.AddForce(Vector3.forward * fuerzaLanzamiento, ForceMode.Impulse);
      Debug.Log(gameObject.name + " ha sido lanzado.");
    }
  }
}