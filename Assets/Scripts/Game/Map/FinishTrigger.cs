using R3;
using UnityEngine;

namespace BarrelHide.Game.Map
{
    public class FinishTrigger : MonoBehaviour
    {
        private readonly Subject<Collider> _triggerEnteredSubject = new();

        public Observable<Collider> TriggerEntered => _triggerEnteredSubject;

        private void OnTriggerEnter(Collider other)
        {
            _triggerEnteredSubject.OnNext(other);
        }
    }
}
