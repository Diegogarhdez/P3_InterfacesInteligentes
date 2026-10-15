using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorPersonaje : MonoBehaviour {

  public float velocidad = 5f;
  private Rigidbody rigidbody;
  private Vector3 direccion;
  private Renderer miRenderer;
  private Color colorOriginal;
  public int dano = 0;

  void Start() {
    rigidbody = GetComponent<Rigidbody>();
    miRenderer = GetComponent<Renderer>();
    colorOriginal = miRenderer.material.color;
  }

  void Update() {
    float x = 0f;
    float z = 0f;
    if (Keyboard.current != null) {
      if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) x = 1f;
      if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) x = -1f;
      if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) z = 1f;
      if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) z = -1f;
    }
    direccion = new Vector3(x, 0f, z).normalized;
  }

  void FixedUpdate() {
    Vector3 movimiento = direccion * velocidad;
    movimiento.y = rigidbody.linearVelocity.y;
    rigidbody.linearVelocity = movimiento;
  }

  void OnCollisionEnter(Collision colision) {
    Debug.Log("Ha chocado contra: " + colision.gameObject.name);
    Renderer rendererObjeto = colision.gameObject.GetComponent<Renderer>();
    if (rendererObjeto != null) {
      rendererObjeto.material.color = Color.red; 
    }
  }

  void OnTriggerEnter(Collider otro) {
    if (otro.gameObject.name == "Cubo Color") {
      miRenderer.material.color = Color.magenta; 
      Debug.Log("Entrando en zona mágica: color cambiado");
    }
    else if (otro.gameObject.name == "Cubo Dano") {
      dano += 10;
      Debug.Log("Trampa daño: " + dano);
    }
  }
  void OnTriggerExit(Collider otro) {
    if (otro.gameObject.name == "Cubo Color") {
      miRenderer.material.color = colorOriginal;
      Debug.Log("Saliendo de la zona: color restaurado");
    }
  }
}
