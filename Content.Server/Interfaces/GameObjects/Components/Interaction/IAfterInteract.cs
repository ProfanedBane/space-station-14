using System;
using JetBrains.Annotations;
using Robust.Shared.GameObjects;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.Map;

namespace Content.Server.Interfaces.GameObjects.Components.Interaction
{
    /// <summary>
    /// This interface gives components a behavior when clicking on another object and no interaction occurs,
    /// at any range.
    /// </summary>
    public interface IAfterInteract
    {
        /// <summary>
        /// Called when we interact with nothing, or when we interact with an entity out of range that has no behavior
        /// </summary>
        void AfterInteract(AfterInteractEventArgs eventArgs);
    }

    public class AfterInteractEventArgs : EventArgs
    {
        public IEntity User { get; set; }
        public GridCoordinates ClickLocation { get; set; }
        public IEntity Target { get; set; }
    }

    /// <summary>
    ///     Raised when clicking on another object and no attack event was handled.
    /// </summary>
    [PublicAPI]
    public class AfterInteractMessage : EntitySystemMessage
    {
        /// <summary>
        ///     If this message has already been "handled" by a previous system.
        /// </summary>
        public bool Handled { get; set; }

        /// <summary>
        ///     Entity that triggered the attack.
        /// </summary>
        public IEntity User { get; }

        /// <summary>
        ///     Entity that the User attacked with.
        /// </summary>
        public IEntity ItemInHand { get; set; }

        /// <summary>
        ///     Entity that was attacked. This can be null if the attack did not click on an entity.
        /// </summary>
        public IEntity Attacked { get; }

        /// <summary>
        ///     Location that the user clicked outside of their interaction range.
        /// </summary>
        public GridCoordinates ClickLocation { get; }

        public AfterInteractMessage(IEntity user, IEntity itemInHand, IEntity attacked, GridCoordinates clickLocation)
        {
            User = user;
            Attacked = attacked;
            ClickLocation = clickLocation;
            ItemInHand = itemInHand;
        }
    }

}
