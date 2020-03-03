
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
        private bool is_disabled = false;
        public bool interacted
        {
            get { return is_disabled; }
        }
        private EndGame endGameScript;
        //-------------------------------------------------
        void Awake()
        {
            if (anim != null)
            {
                anim = AnimatedGameObject.GetComponent<Animator>();
            }
            interactable = this.GetComponent<Interactable>();
            if (_audio != null)
            {
                _audio = this.GetComponent<AudioSource>();
            }

            target = new Vector3(this.transform.position.x, TargetYPos, this.transform.position.z);

            GameObject endGameObject = GameObject.FindGameObjectWithTag("End");
            endGameScript = endGameObject.GetComponent<EndGame>();
        }

        //-------------------------------------------------
        // Called when a Hand starts hovering over this object
        //-------------------------------------------------
        private void OnHandHoverBegin(Hand hand)
        {
            if (this.gameObject.GetComponent<Animator>() != null)
            {
                this.gameObject.GetComponent<Animator>().enabled = false;
            }
            if (is_disabled == false)
            {
                if (this.gameObject.tag == "HoverSphere" && disappearOnHover)
                {
                    if (anim != null)
                    {
                        anim.Play(AnimationStateName);
                    }
                    this.GetComponent<MeshRenderer>().enabled = false;
                    if (_audio != null)
                    {
                        _audio.Play();
                    }
                    endGameScript.InteractionNumber += 1; // number of interactions
                    Debug.Log("interaction number: " + endGameScript.InteractionNumber);
                    //StartCoroutine("waitTillAudioFinish"); //deactivate gameobject once the audio is played
                    is_disabled = true;
                }
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
            if (is_disabled == false)
            {
                if (startingGrabType != GrabTypes.None && this.gameObject.tag == "Sphere")
                {
                    StartCoroutine("waitBeforeAnimationStarts");
                    if (anim != null)
                    {
                        anim.Play(AnimationStateName);
                    }
                    this.GetComponent<MeshRenderer>().enabled = false;
                    is_disabled = true;
                    if (_audio != null)
                    {
                        _audio.Play();
                    }
                }
            }
        }

        IEnumerator waitBeforeAnimationStarts()
        {
            yield return new WaitForSeconds(2);
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