using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnPipe.Pipe
{

    public enum PipeSize
    {
        Small,
        Medium,
        Large
    }

    [DisallowMultipleComponent]
    public class Pipe : MonoBehaviour
    {
        [System.Serializable]
        public class PipeType
        {
            public PipeSize pipeSize;
            public float pipeScale;
        }

        public PipeType pipeType;

        private void OnTriggerEnter( Collider other )
        {
            if ( other.CompareTag( Tags.Player ) )
            {
                Player.PlayerBehavior playerBehavior = other.GetComponent<Player.PlayerBehavior>();
                Managers.EventManager.Invoke_OnMinimumSafeRadiusChange( pipeType.pipeScale );
                playerBehavior.RefreshPipeProperties( playerBehavior.currentPipeSize, pipeType );
                //update current pipe size
                playerBehavior.currentPipeSize = pipeType.pipeSize;
            }

        }

    }
}
