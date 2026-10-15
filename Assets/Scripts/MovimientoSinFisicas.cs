using UnityEngine;

public class MovimientoSinFisicas : MonoBehaviour {
  public Transform cilindroObjetivo;
  public GameObject cuboObstaculo;
  public float velocidad = 3f;

  private Collider miCollider;
  private Collider colliderDelCubo;
  private bool colorCambiado = false;

  void Start() {
    miCollider = GetComponent<Collider>();
    colliderDelCubo = cuboObstaculo.GetComponent<Collider>();
  }

  void Update() {
    transform.position = Vector3.MoveTowards(
      transform.position,
      cilindroObjetivo.position,
      velocidad * Time.deltaTime
    );

    if (!colorCambiado && miCollider.bounds.Intersects(colliderDelCubo.bounds)) {
      colorCambiado = true;
      Renderer renderCubo = cuboObstaculo.GetComponent<Renderer>();
      if (renderCubo != null) {
        renderCubo.material.color = Color.yellow;
        Debug.Log("¡Cubo alcanzado sin usar Rigidbody!");
      }
    }
  }
}