using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ScrollImage : MonoBehaviour
{
    
   
        private Image _image;
        [SerializeField] private Vector2 speed;
        void Start()
        {
            _image = GetComponent<Image>();
            _image.material = new Material(_image.material); //Clone the original material
        }
        void Update()
        {
            _image.material.mainTextureOffset += speed * Time.deltaTime;
        }
    
   
}
