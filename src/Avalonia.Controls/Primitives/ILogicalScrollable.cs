// Copyright (c) The Avalonia Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using System;
using Avalonia.VisualTree;

namespace Avalonia.Controls.Primitives
{
    /// <summary>
    /// Interface implemented by controls that handle their own scrolling when placed inside a 
    /// <see cref="ScrollViewer"/>.
    /// </summary>
    /// <remarks>
    /// Controls that implement this interface, when placed inside a <see cref="ScrollViewer"/>
    /// can override the physical scrolling behavior of the scroll viewer with logical scrolling.
    /// Physical scrolling means that the scroll viewer is a simple viewport onto a larger canvas
    /// whereas logical scrolling means that the scrolling is handled by the child control itself
    /// and it can choose to do handle the scroll information as it sees fit.
    /// </remarks>
    public interface ILogicalScrollable : IScrollable
    {
        /// <summary>
        /// Gets a value indicating whether logical scrolling is enabled on the control.
        /// </summary>
        bool IsLogicalScrollEnabled { get; }

        /// <summary>
        /// Gets or sets the scroll invalidation method.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method notifies the attached <see cref="ScrollViewer"/> of a change in 
        /// the <see cref="IScrollable.Extent"/>, <see cref="IScrollable.Offset"/> or 
        /// <see cref="IScrollable.Viewport"/> properties.
        /// </para>
        /// <para>
        /// This property is set by the parent <see cref="ScrollViewer"/> when the 
        /// <see cref="ILogicalScrollable"/> is placed inside it.
        /// </para>
        /// </remarks>
        Action InvalidateScroll { get; set; }

        /// <summary>
        /// Gets the size to scroll by, in logical units.
        /// </summary>
        Size ScrollSize { get; }

        /// <summary>
        /// Gets the size to page by, in logical units.
        /// </summary>
        Size PageScrollSize { get; }

        /// <summary>
        /// Attempts to bring a portion of the target visual into view by scrolling the content.
        /// </summary>
        /// <param name="target">The target visual.</param>
        /// <param name="targetRect">The portion of the target visual to bring into view.</param>
        /// <returns>True if the scroll offset was changed; otherwise false.</returns>
        bool BringIntoView(IVisual target, Rect targetRect);
    }
}
