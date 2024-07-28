using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LivseyAttack1 : AttackBase
    {
        private const float Delay = 3f;

        [SerializeField]
        private Shell _shell;

        private List<Shell> _shells = new List<Shell>();

        public override IEnumerator Execute()
        {
            var attack = Instantiate(_shell, transform);
            _shells.Add(attack);
            yield return new WaitForSeconds(Delay);
        }

        public override IEnumerator Cancel()
        {
            Destroy(_shells[0].gameObject);
            yield return new WaitForSeconds(1);
        }
    }
}