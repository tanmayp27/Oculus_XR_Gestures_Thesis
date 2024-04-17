using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTouch : MonoBehaviour
{
    [SerializeField] private HandTouch handTouch;
    [SerializeField] private AudioClip pinchSound;
    [SerializeField] private AudioClip releaseSound;
    [SerializeField] private AudioSource audioSource;

    public bool _hasPinched;
    private bool _isIndexFingerPinching;
    private float _pinchStrength;
    private OVRHand.TrackingConfidence _trackingConfidence;

    void Update() => PinchDetector(handTouch.rightHand);

    void PinchDetector(OVRHand hand)
    {
        _pinchStrength = hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        _isIndexFingerPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        _trackingConfidence = hand.GetFingerConfidence(OVRHand.HandFinger.Index);

        if (handTouch.CurrentTarget)
        {
            Material currentMaterial = handTouch.CurrentTarget.GetComponent<Renderer>().material;
            currentMaterial.SetFloat("_Metallic", _pinchStrength);
        }

        if (!_hasPinched && _isIndexFingerPinching && _trackingConfidence == OVRHand.TrackingConfidence.High && handTouch.CurrentTarget)
        {
            _hasPinched = true;
            handTouch.showRaycast = true;
            if (audioSource != null)
            {
                audioSource.PlayOneShot(pinchSound);
            }
        }
        else if (_hasPinched && !_isIndexFingerPinching)
        {
            _hasPinched = false;
            handTouch.showRaycast = false;
            if (audioSource != null)
            {
                audioSource.PlayOneShot(releaseSound);
            }
        }
    }

}
