using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEnemy : MonoBehaviour
{

    [ColorUsage(true, true)]
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private float flashtime = 0.25f;

    private SpriteRenderer[] _spriteRenderers;
    private Material[] _materials;
    private Coroutine _FlashCoroutine;
    // Start is called before the first frame update

    private void Awake()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        Init();
    }
    
    public void CallDamageFlash()
    {
        _FlashCoroutine = StartCoroutine(DamageFlash());
    }
    private void Init()
    {
        _materials = new Material[_spriteRenderers.Length];

        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _materials[i] = _spriteRenderers[i].material;
        }

    }

    private IEnumerator DamageFlash()
    {
        SetFlashColor();
       
        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < flashtime)
        {
            elapsedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(0.001f, 0, (elapsedTime / flashtime));
            SetFlashAmount(currentFlashAmount);
            yield return null;
        }

    }

    private void SetFlashColor()
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetColor("_FlashColor", _flashColor);
        }
    }

    private void SetFlashAmount(float amount)
    {
        for(int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetFloat("_FlashAmount", amount);
        }

    }
}
  
