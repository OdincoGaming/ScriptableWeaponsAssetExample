using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ColorChanger : MonoBehaviour, IGameEventListener<GameObject>
{
    [SerializeField] Color[] colors;
    [SerializeField] [Range(0.1f, 2f)] float fadeSpeed = 0.5f;
    [SerializeField] GameObjectEvent gameObjectEvent;
    private Renderer rend;
    private int lastIndex;
    private Coroutine cr;
    private int currentindex;
    private Color color;

    public Color Color => color;

    private void OnEnable() => gameObjectEvent.RegisterListener(this);
    private void OnDisable() => gameObjectEvent.UnregisterListener(this);
    private void Awake() => rend = GetComponent<Renderer>();

    public void OnEventRaised(GameObject item)
    {
        while (currentindex == lastIndex)
            currentindex = UnityEngine.Random.Range(0, colors.Length - 1);

        color = colors[currentindex];
        rend.material.color = color;

        rend.material.EnableKeyword("_EMISSION");
        rend.material.SetColor("_EmissionColor", color);
        if (cr != null)
            StopCoroutine(cr);
        cr = StartCoroutine(FadeEmission(color));
        lastIndex = System.Array.IndexOf(colors, color);
    }


    /*private void OnTriggerEnter(Collider other)
    {

    }*/

    IEnumerator FadeEmission(Color c)
    {

        float elapsedTime = 0;
        float intensity;

        while (elapsedTime < fadeSpeed)
        {
            intensity = Mathf.Lerp(2, 0, (elapsedTime / fadeSpeed));
            elapsedTime += Time.deltaTime;
            rend.material.SetColor("_EmissionColor", c * intensity);
            yield return null;
        }

        rend.material.SetColor("_EmissionColor", c * 0);

        yield return null;
    }
}
