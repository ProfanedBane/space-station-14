using System;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Interfaces.GameObjects;

namespace Content.Server.Interfaces.GameObjects.Components.Interaction
{
    /// <summary>
    /// This interface gives components behavior when using the entity in your hands
    /// </summary>
    public interface IUse
    {
        /// <summary>
        /// Called when we activate an object we are holding to use it
        /// </summary>
        /// <returns></returns>
        bool UseEntity(UseEntityEventArgs eventArgs);
    }

    public class UseEntityEventArgs : EventArgs
    {
        public IEntity User { get; set; }
    }

    /// <summary>
    ///     Raised when using the entity in your hands.
    /// </summary>
    [PublicAPI]
    public class UseInHandMessage : EntitySystemMessage
    {
        /// <summary>
        ///     If this message has already been "handled" by a previous system.
        /// </summary>
        public bool Handled { get; set; }

        /// <summary>
        ///     Entity holding the item in their hand.
        /// </summary>
        public IEntity User { get; }

        /// <summary>
        ///     Item that was used.
        /// </summary>
        public IEntity Used { get; }

        public UseInHandMessage(IEntity user, IEntity used)
        {
            User = user;
            Used = used;
        }
    }
}
