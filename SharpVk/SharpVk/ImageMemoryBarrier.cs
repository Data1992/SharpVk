// The MIT License (MIT)
// 
// Copyright (c) Andrew Armstrong/FacticiusVir 2016
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// This file was automatically generated and should not be edited directly.

using System;

namespace SharpVk
{
    /// <summary>
    /// <para>
    /// Structure specifying the parameters of an image memory barrier.
    /// </para>
    /// <para>
    /// If pname:oldLayout differs from pname:newLayout, a layout transition
    /// occurs as part of the image memory barrier, affecting the data
    /// contained in the region of the image defined by the
    /// pname:subresourceRange. If pname:oldLayout is
    /// ename:VK_IMAGE_LAYOUT_UNDEFINED, then the data is undefined after the
    /// layout transition. This may: allow a more efficient transition, since
    /// the data may: be discarded. The layout transition must: occur after all
    /// operations using the old layout are completed and before all operations
    /// using the new layout are started. This is achieved by ensuring that
    /// there is a memory dependency between previous accesses and the layout
    /// transition, as well as between the layout transition and subsequent
    /// accesses, where the layout transition occurs between the two halves of
    /// a memory dependency in an image memory barrier.
    /// </para>
    /// <para>
    /// Layout transitions that are performed via image memory barriers are
    /// automatically ordered against other layout transitions, including those
    /// that occur as part of a render pass instance.
    /// </para>
    /// <para>
    /// [NOTE] .Note ==== See &lt;&lt;resources-image-layouts&gt;&gt; for
    /// details on available image layouts and their usages. ====
    /// </para>
    /// </summary>
    public struct ImageMemoryBarrier
    {
        /// <summary>
        /// pname:srcAccessMask is a bitmask of the classes of memory accesses
        /// performed by the first set of commands that will participate in the
        /// dependency.
        /// </summary>
        public AccessFlags SourceAccessMask
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:dstAccessMask is a bitmask of the classes of memory accesses
        /// performed by the second set of commands that will participate in
        /// the dependency.
        /// </summary>
        public AccessFlags DestinationAccessMask
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:oldLayout describes the current layout of the image
        /// subresource(s).
        /// </summary>
        public ImageLayout OldLayout
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:newLayout describes the new layout of the image
        /// subresource(s).
        /// </summary>
        public ImageLayout NewLayout
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:srcQueueFamilyIndex is the queue family that is relinquishing
        /// ownership of the image subresource(s) to another queue, or
        /// ename:VK_QUEUE_FAMILY_IGNORED if there is no transfer of
        /// ownership).
        /// </summary>
        public uint SourceQueueFamilyIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:dstQueueFamilyIndex is the queue family that is acquiring
        /// ownership of the image subresource(s) from another queue, or
        /// ename:VK_QUEUE_FAMILY_IGNORED if there is no transfer of
        /// ownership).
        /// </summary>
        public uint DestinationQueueFamilyIndex
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:image is a handle to the image whose backing memory is
        /// affected by the barrier.
        /// </summary>
        public Image Image
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:subresourceRange describes an area of the backing memory for
        /// pname:image (see &lt;&lt;resources-image-views&gt;&gt; for the
        /// description of sname:VkImageSubresourceRange), as well as the set
        /// of image subresources whose image layouts are modified.
        /// </summary>
        public ImageSubresourceRange SubresourceRange
        {
            get;
            set;
        }
        
        internal unsafe Interop.ImageMemoryBarrier Pack()
        {
            Interop.ImageMemoryBarrier result = default(Interop.ImageMemoryBarrier);
            result.SType = StructureType.ImageMemoryBarrier;
            result.Image = this.Image?.Pack() ?? Interop.Image.Null;
            result.SourceAccessMask = this.SourceAccessMask;
            result.DestinationAccessMask = this.DestinationAccessMask;
            result.OldLayout = this.OldLayout;
            result.NewLayout = this.NewLayout;
            result.SourceQueueFamilyIndex = this.SourceQueueFamilyIndex;
            result.DestinationQueueFamilyIndex = this.DestinationQueueFamilyIndex;
            result.SubresourceRange = this.SubresourceRange;
            return result;
        }
        
        internal unsafe Interop.ImageMemoryBarrier* MarshalTo()
        {
            return (Interop.ImageMemoryBarrier*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
        }
    }
}
