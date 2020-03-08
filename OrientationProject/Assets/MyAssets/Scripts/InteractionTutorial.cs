//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
	public class InteractionTutorial : MonoBehaviour
    {
		public GameObject sphere;
		private MeshRenderer sphereMesh;
        private TextMesh generalText;

		private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & ( ~Hand.AttachmentFlags.SnapOnAttach ) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

        private Interactable interactable;

		//-------------------------------------------------
		void Awake()
		{
			sphereMesh = sphere.GetComponent<MeshRenderer>();


			var textMeshs = GetComponentsInChildren<TextMesh>();
            generalText = textMeshs[0];

            generalText.text = "Touch Sphere";

            interactable = this.GetComponent<Interactable>();
		}


		//-------------------------------------------------
		// Called when a Hand starts hovering over this object
		//-------------------------------------------------
		private void OnHandHoverBegin( Hand hand )
		{
			generalText.text = "Press Trigger Button";
		}


		//-------------------------------------------------
		// Called when a Hand stops hovering over this object
		//-------------------------------------------------
		private void OnHandHoverEnd( Hand hand )
		{
			generalText.text = "Touch sphere";
		}


		//-------------------------------------------------
		// Called every Update() while a Hand is hovering over this object
		//-------------------------------------------------
		private void HandHoverUpdate( Hand hand )
		{
            GrabTypes startingGrabType = hand.GetGrabStarting();
            bool isGrabEnding = hand.IsGrabEnding(this.gameObject);

            if (startingGrabType != GrabTypes.None)
                {
                    sphereMesh.enabled = false;
					generalText.text = "";
					Destroy(this.gameObject);
                }
		}



		//-------------------------------------------------
		// Called when this GameObject is detached from the hand
		//-------------------------------------------------
		private void OnDetachedFromHand( Hand hand )
		{
            generalText.text = string.Format("Detached: {0}", hand.name);
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
