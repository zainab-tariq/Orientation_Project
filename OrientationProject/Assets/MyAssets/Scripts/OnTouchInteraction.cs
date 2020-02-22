
using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
        //-------------------------------------------------------------------------
        [RequireComponent(typeof(Interactable))]
        public class OnTouchInteraction : MonoBehaviour
        {
            private Vector3 oldPosition;
            private Quaternion oldRotation;

            private float attachTime;

            private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

            private Interactable interactable;
            private AudioSource audio;

            public GameObject sphereAndLaser;

            [SerializeField]
            public string animationStateName;
            Animator anim;
        //-------------------------------------------------
        void Awake()
            {
                anim = sphereAndLaser.GetComponent<Animator>();
                interactable = this.GetComponent<Interactable>();
                audio = this.GetComponent<AudioSource>();
            }

            //-------------------------------------------------
            // Called when a Hand starts hovering over this object
            //-------------------------------------------------
            private void OnHandHoverBegin(Hand hand)
            {
                this.gameObject.GetComponent<Animator>().enabled = false;
                if(this.gameObject.tag == "StartSphere"){
                        anim.Play(animationStateName);
                        this.GetComponent<MeshRenderer>().enabled = false;
                        this.transform.position = new Vector3(this.transform.position.x, 27, this.transform.position.z);
                }

                audio.Play();
                //StartCoroutine("waitTillAudioFinish"); //deactivate gameobject once the audio is played
            }

            IEnumerator waitTillAudioFinish(){
                yield return new WaitForSeconds(audio.clip.length);
                this.gameObject.SetActive(false);
            }

            //-------------------------------------------------
            // Called when a Hand stops hovering over this object
            //-------------------------------------------------
            private void OnHandHoverEnd(Hand hand)
            {
       
            }


            //-------------------------------------------------
            // Called every Update() while a Hand is hovering over this object
            //-------------------------------------------------
            private void HandHoverUpdate(Hand hand)
            {
               
            }


            //-------------------------------------------------
            // Called when this GameObject becomes attached to the hand
            //-------------------------------------------------
            private void OnAttachedToHand(Hand hand)
            {
                
            }



            //-------------------------------------------------
            // Called when this GameObject is detached from the hand
            //-------------------------------------------------
            private void OnDetachedFromHand(Hand hand)
            {
                
            }


            //-------------------------------------------------
            // Called every Update() while this GameObject is attached to the hand
            //-------------------------------------------------
            private void HandAttachedUpdate(Hand hand)
            {
                
            }

            private bool lastHovering = false;
            private void Update()
            {
                if (interactable.isHovering != lastHovering) //save on the .tostrings a bit
                {
                    lastHovering = interactable.isHovering;
                }
            }


            //-------------------------------------------------
            // Called when this attached GameObject becomes the primary attached object
            //-------------------------------------------------
            private void OnHandFocusAcquired(Hand hand)
            {
            }


            //-------------------------------------------------
            // Called when another attached GameObject becomes the primary attached object
            //-------------------------------------------------
            private void OnHandFocusLost(Hand hand)
            {
            }
        }
}