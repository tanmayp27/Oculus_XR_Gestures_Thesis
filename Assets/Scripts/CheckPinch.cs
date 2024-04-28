using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPinch : MonoBehaviour
{
    [SerializeField] private HandPointer handPointer;
    [SerializeField] private AudioClip pinchSound;
    [SerializeField] private AudioClip releaseSound;
    [SerializeField] private AudioSource audioSource;

    public bool _hasPinched=false;
    private bool _isIndexFingerPinching;
    private float _pinchStrength;
    private OVRHand.TrackingConfidence _trackingConfidence;

    void Update() => PinchDetector(handPointer.rightHand);

    void PinchDetector(OVRHand hand)
    {
        _pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        _isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        _trackingConfidence = hand.GetFingerConfidence(OVRHand.HandFinger.Index);

        if (handPointer.CurrentTarget)
        {
            Material currentMaterial = handPointer.CurrentTarget.GetComponent<Renderer>().material;
            currentMaterial.SetFloat("_Metallic", _pinchStrength);
        }

        if (!_hasPinched && _isIndexFingerPinching && _trackingConfidence == OVRHand.TrackingConfidence.High && handPointer.CurrentTarget)
        {
            _hasPinched = true;
            handPointer.checkHeld = true;
            /* if(!handPointer.showRaycast)
            {
                handPointer.showRaycast = true;
            } */
            
            if (audioSource != null)
            {
                audioSource.PlayOneShot(pinchSound);
            }
        }
        else if (_hasPinched && !_isIndexFingerPinching)
        {
            _hasPinched = false;
            handPointer.checkHeld = false;
            /* if (handPointer.showRaycast)
            {
                handPointer.showRaycast = false;
            } */
            
            if (audioSource != null)
            {
                audioSource.PlayOneShot(releaseSound);
            }
        }
    }

}
