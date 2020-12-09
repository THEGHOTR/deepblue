using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Liminal.Examples
{
    /// Just by implementing IPointerClickHandler like any UI, you can click on objects
    public class Interactable : MonoBehaviour, IPointerClickHandler
    {
        public UnityEvent OnClick;

        public AudioSource audiodata;

        public AudioClip clip;

        public BubbleMovement movement;

        public ParticleSystem particle1;

        public ParticleSystem particle2;

        public Vector3 ground;

        [SerializeField] BubbleTracker tracker;

        void Start()
        {
            tracker = FindObjectOfType<BubbleTracker>();

            audiodata = GetComponent<AudioSource>();

            movement = GetComponent<BubbleMovement>();

            particle1 = GetComponentInChildren<ParticleSystem>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick.Invoke();
        }

        void DestroyThis()
        {           
            audiodata.Play();

            GetComponent<MeshRenderer>().enabled = false;

            GetComponent<SphereCollider>().enabled = false;

            ground = movement.ground;

            particle1.transform.position = ground;

            particle1.Play();

            particle2.Play();

            Destroy(this.gameObject, audiodata.clip.length);

            tracker.BubblePopped();
        }
    }
}
