
using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class OnTouchInteraction : MonoBehaviour
    {
        private Interactable interactable;
        private AudioSource _audio;

        [Header("Animation")]
        public GameObject AnimatedGameObject;

        [SerializeField]
        public string AnimationStateName;
        Animator anim;

        [Header("Interactable Sphere")]
        private Vector3 target; //taget position for translation in y-axis
        public float TargetYPos = 24;
        [SerializeField]
        private float speed = 1;
        [SerializeField]
        private bool disappearOnHover = false;

        //-------------------------------------------------
        void Awake()
        {   
            anim = AnimatedGameObject.GetComponent<Animator>();
            interactable = this.GetComponent<Interactable>();
            _audio = this.GetComponent<AudioSource>();
            target = new Vector3(this.transform.position.x, TargetYPos, this.transform.position.z);
        }

        //-------------------------------------------------
        // Called when a Hand starts hovering over this object
        //-------------------------------------------------
        private void OnHandHoverBegin(Hand hand)
        {
            if(this.gameObject.GetComponent<Animator>() != null){
                this.gameObject.GetComponent<Animator>().enabled = false;
            }

            if (this.gameObject.tag == "Sphere" && disappearOnHover)
            {
                if (anim != null)
                {
                    anim.Play(AnimationStateName);
                }
                this.GetComponent<MeshRenderer>().enabled = false;
                this.transform.position = new Vector3(this.transform.position.x, TargetYPos, this.transform.position.z); // set y üosition to a fixed position
                //transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed); //move towards a fixed y postion  
                _audio.Play();
                //StartCoroutine("waitTillAudioFinish"); //deactivate gameobject once the audio is played
            }
        }

        IEnumerator waitTillAudioFinish()
        {
            yield return new WaitForSeconds(_audio.clip.length);
            this.gameObject.SetActive(false);
        }

        //-------------------------------------------------
        // Called every Update() while a Hand is hovering over this object
        //-------------------------------------------------
        private void HandHoverUpdate(Hand hand)
        {
            GrabTypes startingGrabType = hand.GetGrabStarting();
            if (startingGrabType != GrabTypes.None && this.gameObject.tag == "Sphere")
            {
                if (anim != null)
                {
                    anim.Play(AnimationStateName);
                }
                this.GetComponent<MeshRenderer>().enabled = false;
                this.transform.position = new Vector3(this.transform.position.x, TargetYPos, this.transform.position.z);
                if(_audio != null){
                    _audio.Play();
                }
            }
        }

        private bool lastHovering = false;
        private void Update()
        {
            if (interactable.isHovering != lastHovering) //save on the .tostrings a bit
            {
                lastHovering = interactable.isHovering;
            }
        }
    }
}