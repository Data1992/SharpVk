﻿//The MIT License (MIT)
//
//Copyright (c) Andrew Armstrong/FacticiusVir 2016
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

using System;

namespace SharpVk
{

	public struct AllocationCallbacks
	{

		public IntPtr UserData
		{
			get;
			set;
		}

        internal unsafe Interop.AllocationCallbacks Pack()
        {
            var result = new Interop.AllocationCallbacks();
			result.UserData = this.UserData.ToPointer();

            return result;
        }

		internal unsafe Interop.AllocationCallbacks* MarshalTo()
        {
            return (Interop.AllocationCallbacks*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct AndroidSurfaceCreateInfo
	{

		public AndroidSurfaceCreateFlags Flags
		{
			get;
			set;
		}

		public IntPtr Window
		{
			get;
			set;
		}

        internal unsafe Interop.AndroidSurfaceCreateInfo Pack()
        {
            var result = new Interop.AndroidSurfaceCreateInfo();
			result.SType = StructureType.AndroidSurfaceCreateInfo;
			result.Window = (IntPtr*)Interop.HeapUtil.AllocateAndMarshal(this.Window);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.AndroidSurfaceCreateInfo* MarshalTo()
        {
            return (Interop.AndroidSurfaceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct ApplicationInfo
	{

		public string ApplicationName
		{
			get;
			set;
		}

		public Version ApplicationVersion
		{
			get;
			set;
		}

		public string EngineName
		{
			get;
			set;
		}

		public Version EngineVersion
		{
			get;
			set;
		}

		public Version ApiVersion
		{
			get;
			set;
		}

        internal unsafe Interop.ApplicationInfo Pack()
        {
            var result = new Interop.ApplicationInfo();
			result.SType = StructureType.ApplicationInfo;
			result.ApplicationName = Interop.HeapUtil.MarshalTo(this.ApplicationName);
			result.EngineName = Interop.HeapUtil.MarshalTo(this.EngineName);
			result.ApplicationVersion = this.ApplicationVersion;
			result.EngineVersion = this.EngineVersion;
			result.ApiVersion = this.ApiVersion;

            return result;
        }

		internal unsafe Interop.ApplicationInfo* MarshalTo()
        {
            return (Interop.ApplicationInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct BindSparseInfo
	{

		public Semaphore[] WaitSemaphores
		{
			get;
			set;
		}

		public SparseBufferMemoryBindInfo[] BufferBinds
		{
			get;
			set;
		}

		public SparseImageOpaqueMemoryBindInfo[] ImageOpaqueBinds
		{
			get;
			set;
		}

		public SparseImageMemoryBindInfo[] ImageBinds
		{
			get;
			set;
		}

		public Semaphore[] SignalSemaphores
		{
			get;
			set;
		}

        internal unsafe Interop.BindSparseInfo Pack()
        {
            var result = new Interop.BindSparseInfo();
			result.SType = StructureType.BindSparseInfo;
			
			//WaitSemaphores
			if (this.WaitSemaphores != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.Semaphore>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.Semaphore>(this.WaitSemaphores.Length);
			    for (int index = 0; index < this.WaitSemaphores.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.WaitSemaphores[index].Pack(), pointer + (size * index), false);
			    }
			    result.WaitSemaphores = (Interop.Semaphore*)pointer.ToPointer();
			}
			else
			{
			    result.WaitSemaphores = null;
			}
			
			//BufferBinds
			if (this.BufferBinds != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.SparseBufferMemoryBindInfo>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.SparseBufferMemoryBindInfo>(this.BufferBinds.Length);
			    for (int index = 0; index < this.BufferBinds.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.BufferBinds[index].Pack(), pointer + (size * index), false);
			    }
			    result.BufferBinds = (Interop.SparseBufferMemoryBindInfo*)pointer.ToPointer();
			}
			else
			{
			    result.BufferBinds = null;
			}
			
			//ImageOpaqueBinds
			if (this.ImageOpaqueBinds != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.SparseImageOpaqueMemoryBindInfo>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.SparseImageOpaqueMemoryBindInfo>(this.ImageOpaqueBinds.Length);
			    for (int index = 0; index < this.ImageOpaqueBinds.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.ImageOpaqueBinds[index].Pack(), pointer + (size * index), false);
			    }
			    result.ImageOpaqueBinds = (Interop.SparseImageOpaqueMemoryBindInfo*)pointer.ToPointer();
			}
			else
			{
			    result.ImageOpaqueBinds = null;
			}
			
			//ImageBinds
			if (this.ImageBinds != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.SparseImageMemoryBindInfo>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.SparseImageMemoryBindInfo>(this.ImageBinds.Length);
			    for (int index = 0; index < this.ImageBinds.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.ImageBinds[index].Pack(), pointer + (size * index), false);
			    }
			    result.ImageBinds = (Interop.SparseImageMemoryBindInfo*)pointer.ToPointer();
			}
			else
			{
			    result.ImageBinds = null;
			}
			
			//SignalSemaphores
			if (this.SignalSemaphores != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.Semaphore>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.Semaphore>(this.SignalSemaphores.Length);
			    for (int index = 0; index < this.SignalSemaphores.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.SignalSemaphores[index].Pack(), pointer + (size * index), false);
			    }
			    result.SignalSemaphores = (Interop.Semaphore*)pointer.ToPointer();
			}
			else
			{
			    result.SignalSemaphores = null;
			}
			result.WaitSemaphoreCount = (uint)(this.WaitSemaphores?.Length ?? 0);
			result.BufferBindCount = (uint)(this.BufferBinds?.Length ?? 0);
			result.ImageOpaqueBindCount = (uint)(this.ImageOpaqueBinds?.Length ?? 0);
			result.ImageBindCount = (uint)(this.ImageBinds?.Length ?? 0);
			result.SignalSemaphoreCount = (uint)(this.SignalSemaphores?.Length ?? 0);

            return result;
        }

		internal unsafe Interop.BindSparseInfo* MarshalTo()
        {
            return (Interop.BindSparseInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct BufferCreateInfo
	{

		public BufferCreateFlags Flags
		{
			get;
			set;
		}

		public ulong Size
		{
			get;
			set;
		}

		public BufferUsageFlags Usage
		{
			get;
			set;
		}

		public SharingMode SharingMode
		{
			get;
			set;
		}

		public uint[] QueueFamilyIndices
		{
			get;
			set;
		}

        internal unsafe Interop.BufferCreateInfo Pack()
        {
            var result = new Interop.BufferCreateInfo();
			result.SType = StructureType.BufferCreateInfo;
			result.QueueFamilyIndices = this.QueueFamilyIndices == null ? null : Interop.HeapUtil.MarshalTo(this.QueueFamilyIndices);
			result.QueueFamilyIndexCount = (uint)(this.QueueFamilyIndices?.Length ?? 0);
			result.Flags = this.Flags;
			result.Size = this.Size;
			result.Usage = this.Usage;
			result.SharingMode = this.SharingMode;

            return result;
        }

		internal unsafe Interop.BufferCreateInfo* MarshalTo()
        {
            return (Interop.BufferCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct BufferMemoryBarrier
	{

		public AccessFlags SourceAccessMask
		{
			get;
			set;
		}

		public AccessFlags DestinationAccessMask
		{
			get;
			set;
		}

		public uint SourceQueueFamilyIndex
		{
			get;
			set;
		}

		public uint DestinationQueueFamilyIndex
		{
			get;
			set;
		}

		public Buffer Buffer
		{
			get;
			set;
		}

		public ulong Offset
		{
			get;
			set;
		}

		public ulong Size
		{
			get;
			set;
		}

        internal unsafe Interop.BufferMemoryBarrier Pack()
        {
            var result = new Interop.BufferMemoryBarrier();
			result.SType = StructureType.BufferMemoryBarrier;
			result.Buffer = this.Buffer?.Pack() ?? Interop.Buffer.Null;
			result.SourceAccessMask = this.SourceAccessMask;
			result.DestinationAccessMask = this.DestinationAccessMask;
			result.SourceQueueFamilyIndex = this.SourceQueueFamilyIndex;
			result.DestinationQueueFamilyIndex = this.DestinationQueueFamilyIndex;
			result.Offset = this.Offset;
			result.Size = this.Size;

            return result;
        }

		internal unsafe Interop.BufferMemoryBarrier* MarshalTo()
        {
            return (Interop.BufferMemoryBarrier*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct BufferViewCreateInfo
	{

		public BufferViewCreateFlags Flags
		{
			get;
			set;
		}

		public Buffer Buffer
		{
			get;
			set;
		}

		public Format Format
		{
			get;
			set;
		}

		public ulong Offset
		{
			get;
			set;
		}

		public ulong Range
		{
			get;
			set;
		}

        internal unsafe Interop.BufferViewCreateInfo Pack()
        {
            var result = new Interop.BufferViewCreateInfo();
			result.SType = StructureType.BufferViewCreateInfo;
			result.Buffer = this.Buffer?.Pack() ?? Interop.Buffer.Null;
			result.Flags = this.Flags;
			result.Format = this.Format;
			result.Offset = this.Offset;
			result.Range = this.Range;

            return result;
        }

		internal unsafe Interop.BufferViewCreateInfo* MarshalTo()
        {
            return (Interop.BufferViewCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct CommandBufferAllocateInfo
	{

		public CommandPool CommandPool
		{
			get;
			set;
		}

		public CommandBufferLevel Level
		{
			get;
			set;
		}

		public uint CommandBufferCount
		{
			get;
			set;
		}

        internal unsafe Interop.CommandBufferAllocateInfo Pack()
        {
            var result = new Interop.CommandBufferAllocateInfo();
			result.SType = StructureType.CommandBufferAllocateInfo;
			result.CommandPool = this.CommandPool?.Pack() ?? Interop.CommandPool.Null;
			result.Level = this.Level;
			result.CommandBufferCount = this.CommandBufferCount;

            return result;
        }

		internal unsafe Interop.CommandBufferAllocateInfo* MarshalTo()
        {
            return (Interop.CommandBufferAllocateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct CommandBufferBeginInfo
	{

		public CommandBufferUsageFlags Flags
		{
			get;
			set;
		}

		public CommandBufferInheritanceInfo? InheritanceInfo
		{
			get;
			set;
		}

        internal unsafe Interop.CommandBufferBeginInfo Pack()
        {
            var result = new Interop.CommandBufferBeginInfo();
			result.SType = StructureType.CommandBufferBeginInfo;
			result.InheritanceInfo = this.InheritanceInfo == null ? null : this.InheritanceInfo.Value.MarshalTo();
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.CommandBufferBeginInfo* MarshalTo()
        {
            return (Interop.CommandBufferBeginInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct CommandBufferInheritanceInfo
	{

		public RenderPass RenderPass
		{
			get;
			set;
		}

		public uint Subpass
		{
			get;
			set;
		}

		public Framebuffer Framebuffer
		{
			get;
			set;
		}

		public Bool32 OcclusionQueryEnable
		{
			get;
			set;
		}

		public QueryControlFlags QueryFlags
		{
			get;
			set;
		}

		public QueryPipelineStatisticFlags PipelineStatistics
		{
			get;
			set;
		}

        internal unsafe Interop.CommandBufferInheritanceInfo Pack()
        {
            var result = new Interop.CommandBufferInheritanceInfo();
			result.SType = StructureType.CommandBufferInheritanceInfo;
			result.RenderPass = this.RenderPass?.Pack() ?? Interop.RenderPass.Null;
			result.Framebuffer = this.Framebuffer?.Pack() ?? Interop.Framebuffer.Null;
			result.Subpass = this.Subpass;
			result.OcclusionQueryEnable = this.OcclusionQueryEnable;
			result.QueryFlags = this.QueryFlags;
			result.PipelineStatistics = this.PipelineStatistics;

            return result;
        }

		internal unsafe Interop.CommandBufferInheritanceInfo* MarshalTo()
        {
            return (Interop.CommandBufferInheritanceInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct CommandPoolCreateInfo
	{

		public CommandPoolCreateFlags Flags
		{
			get;
			set;
		}

		public uint QueueFamilyIndex
		{
			get;
			set;
		}

        internal unsafe Interop.CommandPoolCreateInfo Pack()
        {
            var result = new Interop.CommandPoolCreateInfo();
			result.SType = StructureType.CommandPoolCreateInfo;
			result.Flags = this.Flags;
			result.QueueFamilyIndex = this.QueueFamilyIndex;

            return result;
        }

		internal unsafe Interop.CommandPoolCreateInfo* MarshalTo()
        {
            return (Interop.CommandPoolCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct ComputePipelineCreateInfo
	{

		public PipelineCreateFlags Flags
		{
			get;
			set;
		}

		public PipelineShaderStageCreateInfo Stage
		{
			get;
			set;
		}

		public PipelineLayout Layout
		{
			get;
			set;
		}

		public Pipeline BasePipelineHandle
		{
			get;
			set;
		}

		public int BasePipelineIndex
		{
			get;
			set;
		}

        internal unsafe Interop.ComputePipelineCreateInfo Pack()
        {
            var result = new Interop.ComputePipelineCreateInfo();
			result.SType = StructureType.ComputePipelineCreateInfo;
			result.Stage = this.Stage.Pack();
			result.Layout = this.Layout?.Pack() ?? Interop.PipelineLayout.Null;
			result.BasePipelineHandle = this.BasePipelineHandle?.Pack() ?? Interop.Pipeline.Null;
			result.Flags = this.Flags;
			result.BasePipelineIndex = this.BasePipelineIndex;

            return result;
        }

		internal unsafe Interop.ComputePipelineCreateInfo* MarshalTo()
        {
            return (Interop.ComputePipelineCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct CopyDescriptorSet
	{

		public DescriptorSet SourceSet
		{
			get;
			set;
		}

		public uint SourceBinding
		{
			get;
			set;
		}

		public uint SourceArrayElement
		{
			get;
			set;
		}

		public DescriptorSet DestinationSet
		{
			get;
			set;
		}

		public uint DestinationBinding
		{
			get;
			set;
		}

		public uint DestinationArrayElement
		{
			get;
			set;
		}

		public uint DescriptorCount
		{
			get;
			set;
		}

        internal unsafe Interop.CopyDescriptorSet Pack()
        {
            var result = new Interop.CopyDescriptorSet();
			result.SType = StructureType.CopyDescriptorSet;
			result.SourceSet = this.SourceSet?.Pack() ?? Interop.DescriptorSet.Null;
			result.DestinationSet = this.DestinationSet?.Pack() ?? Interop.DescriptorSet.Null;
			result.SourceBinding = this.SourceBinding;
			result.SourceArrayElement = this.SourceArrayElement;
			result.DestinationBinding = this.DestinationBinding;
			result.DestinationArrayElement = this.DestinationArrayElement;
			result.DescriptorCount = this.DescriptorCount;

            return result;
        }

		internal unsafe Interop.CopyDescriptorSet* MarshalTo()
        {
            return (Interop.CopyDescriptorSet*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DebugMarkerMarkerInfo
	{

		public string MarkerName
		{
			get;
			set;
		}

		public float[] Color
		{
			get;
			set;
		}

        internal unsafe Interop.DebugMarkerMarkerInfo Pack()
        {
            var result = new Interop.DebugMarkerMarkerInfo();
			result.SType = StructureType.DebugMarkerMarkerInfo;
			result.MarkerName = Interop.HeapUtil.MarshalTo(this.MarkerName);

            return result;
        }

		internal unsafe Interop.DebugMarkerMarkerInfo* MarshalTo()
        {
            return (Interop.DebugMarkerMarkerInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DebugMarkerObjectNameInfo
	{

		public DebugReportObjectType ObjectType
		{
			get;
			set;
		}

		public ulong Object
		{
			get;
			set;
		}

		public string ObjectName
		{
			get;
			set;
		}

        internal unsafe Interop.DebugMarkerObjectNameInfo Pack()
        {
            var result = new Interop.DebugMarkerObjectNameInfo();
			result.SType = StructureType.DebugMarkerObjectNameInfo;
			result.ObjectName = Interop.HeapUtil.MarshalTo(this.ObjectName);
			result.ObjectType = this.ObjectType;
			result.Object = this.Object;

            return result;
        }

		internal unsafe Interop.DebugMarkerObjectNameInfo* MarshalTo()
        {
            return (Interop.DebugMarkerObjectNameInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DebugMarkerObjectTagInfo
	{

		public DebugReportObjectType ObjectType
		{
			get;
			set;
		}

		public ulong Object
		{
			get;
			set;
		}

		public ulong TagName
		{
			get;
			set;
		}

		public byte[] Tag
		{
			get;
			set;
		}

        internal unsafe Interop.DebugMarkerObjectTagInfo Pack()
        {
            var result = new Interop.DebugMarkerObjectTagInfo();
			result.SType = StructureType.DebugMarkerObjectTagInfo;
			result.Tag = this.Tag == null ? null : Interop.HeapUtil.MarshalTo(this.Tag);
			result.TagSize = (UIntPtr)(this.Tag?.Length ?? 0);
			result.ObjectType = this.ObjectType;
			result.Object = this.Object;
			result.TagName = this.TagName;

            return result;
        }

		internal unsafe Interop.DebugMarkerObjectTagInfo* MarshalTo()
        {
            return (Interop.DebugMarkerObjectTagInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DebugReportCallbackCreateInfo
	{

		public DebugReportFlags Flags
		{
			get;
			set;
		}

		public IntPtr UserData
		{
			get;
			set;
		}

        internal unsafe Interop.DebugReportCallbackCreateInfo Pack()
        {
            var result = new Interop.DebugReportCallbackCreateInfo();
			result.SType = StructureType.DebugReportCallbackCreateInfo;
			result.UserData = this.UserData.ToPointer();
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.DebugReportCallbackCreateInfo* MarshalTo()
        {
            return (Interop.DebugReportCallbackCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DedicatedAllocationBufferCreateInfo
	{

		public Bool32 DedicatedAllocation
		{
			get;
			set;
		}

        internal unsafe Interop.DedicatedAllocationBufferCreateInfo Pack()
        {
            var result = new Interop.DedicatedAllocationBufferCreateInfo();
			result.SType = StructureType.DedicatedAllocationBufferCreateInfo;
			result.DedicatedAllocation = this.DedicatedAllocation;

            return result;
        }

		internal unsafe Interop.DedicatedAllocationBufferCreateInfo* MarshalTo()
        {
            return (Interop.DedicatedAllocationBufferCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DedicatedAllocationImageCreateInfo
	{

		public Bool32 DedicatedAllocation
		{
			get;
			set;
		}

        internal unsafe Interop.DedicatedAllocationImageCreateInfo Pack()
        {
            var result = new Interop.DedicatedAllocationImageCreateInfo();
			result.SType = StructureType.DedicatedAllocationImageCreateInfo;
			result.DedicatedAllocation = this.DedicatedAllocation;

            return result;
        }

		internal unsafe Interop.DedicatedAllocationImageCreateInfo* MarshalTo()
        {
            return (Interop.DedicatedAllocationImageCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DedicatedAllocationMemoryAllocateInfo
	{

		public Image Image
		{
			get;
			set;
		}

		public Buffer Buffer
		{
			get;
			set;
		}

        internal unsafe Interop.DedicatedAllocationMemoryAllocateInfo Pack()
        {
            var result = new Interop.DedicatedAllocationMemoryAllocateInfo();
			result.SType = StructureType.DedicatedAllocationMemoryAllocateInfo;
			result.Image = this.Image?.Pack() ?? Interop.Image.Null;
			result.Buffer = this.Buffer?.Pack() ?? Interop.Buffer.Null;

            return result;
        }

		internal unsafe Interop.DedicatedAllocationMemoryAllocateInfo* MarshalTo()
        {
            return (Interop.DedicatedAllocationMemoryAllocateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DescriptorBufferInfo
	{

		public Buffer Buffer
		{
			get;
			set;
		}

		public ulong Offset
		{
			get;
			set;
		}

		public ulong Range
		{
			get;
			set;
		}

        internal unsafe Interop.DescriptorBufferInfo Pack()
        {
            var result = new Interop.DescriptorBufferInfo();
			result.Buffer = this.Buffer?.Pack() ?? Interop.Buffer.Null;
			result.Offset = this.Offset;
			result.Range = this.Range;

            return result;
        }

		internal unsafe Interop.DescriptorBufferInfo* MarshalTo()
        {
            return (Interop.DescriptorBufferInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DescriptorImageInfo
	{

		public Sampler Sampler
		{
			get;
			set;
		}

		public ImageView ImageView
		{
			get;
			set;
		}

		public ImageLayout ImageLayout
		{
			get;
			set;
		}

        internal unsafe Interop.DescriptorImageInfo Pack()
        {
            var result = new Interop.DescriptorImageInfo();
			result.Sampler = this.Sampler?.Pack() ?? Interop.Sampler.Null;
			result.ImageView = this.ImageView?.Pack() ?? Interop.ImageView.Null;
			result.ImageLayout = this.ImageLayout;

            return result;
        }

		internal unsafe Interop.DescriptorImageInfo* MarshalTo()
        {
            return (Interop.DescriptorImageInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DescriptorPoolCreateInfo
	{

		public DescriptorPoolCreateFlags Flags
		{
			get;
			set;
		}

		public uint MaxSets
		{
			get;
			set;
		}

		public DescriptorPoolSize[] PoolSizes
		{
			get;
			set;
		}

        internal unsafe Interop.DescriptorPoolCreateInfo Pack()
        {
            var result = new Interop.DescriptorPoolCreateInfo();
			result.SType = StructureType.DescriptorPoolCreateInfo;
			
			//PoolSizes
			if (this.PoolSizes != null)
			{
			    result.PoolSizes = (DescriptorPoolSize*)Interop.HeapUtil.Allocate<DescriptorPoolSize>(this.PoolSizes.Length).ToPointer();
			    for (int index = 0; index < this.PoolSizes.Length; index++)
			    {
			        result.PoolSizes[index] = this.PoolSizes[index];
			    }
			}
			else
			{
			    result.PoolSizes = null;
			}
			result.PoolSizeCount = (uint)(this.PoolSizes?.Length ?? 0);
			result.Flags = this.Flags;
			result.MaxSets = this.MaxSets;

            return result;
        }

		internal unsafe Interop.DescriptorPoolCreateInfo* MarshalTo()
        {
            return (Interop.DescriptorPoolCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DescriptorSetAllocateInfo
	{

		public DescriptorPool DescriptorPool
		{
			get;
			set;
		}

		public DescriptorSetLayout[] SetLayouts
		{
			get;
			set;
		}

        internal unsafe Interop.DescriptorSetAllocateInfo Pack()
        {
            var result = new Interop.DescriptorSetAllocateInfo();
			result.SType = StructureType.DescriptorSetAllocateInfo;
			result.DescriptorPool = this.DescriptorPool?.Pack() ?? Interop.DescriptorPool.Null;
			
			//SetLayouts
			if (this.SetLayouts != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.DescriptorSetLayout>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.DescriptorSetLayout>(this.SetLayouts.Length);
			    for (int index = 0; index < this.SetLayouts.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.SetLayouts[index].Pack(), pointer + (size * index), false);
			    }
			    result.SetLayouts = (Interop.DescriptorSetLayout*)pointer.ToPointer();
			}
			else
			{
			    result.SetLayouts = null;
			}
			result.DescriptorSetCount = (uint)(this.SetLayouts?.Length ?? 0);

            return result;
        }

		internal unsafe Interop.DescriptorSetAllocateInfo* MarshalTo()
        {
            return (Interop.DescriptorSetAllocateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DescriptorSetLayoutBinding
	{

		public uint Binding
		{
			get;
			set;
		}

		public DescriptorType DescriptorType
		{
			get;
			set;
		}

		public ShaderStageFlags StageFlags
		{
			get;
			set;
		}

		public Sampler[] ImmutableSamplers
		{
			get;
			set;
		}

        internal unsafe Interop.DescriptorSetLayoutBinding Pack()
        {
            var result = new Interop.DescriptorSetLayoutBinding();
			
			//ImmutableSamplers
			if (this.ImmutableSamplers != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.Sampler>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.Sampler>(this.ImmutableSamplers.Length);
			    for (int index = 0; index < this.ImmutableSamplers.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.ImmutableSamplers[index].Pack(), pointer + (size * index), false);
			    }
			    result.ImmutableSamplers = (Interop.Sampler*)pointer.ToPointer();
			}
			else
			{
			    result.ImmutableSamplers = null;
			}
			result.DescriptorCount = (uint)(this.ImmutableSamplers?.Length ?? 0);
			result.Binding = this.Binding;
			result.DescriptorType = this.DescriptorType;
			result.StageFlags = this.StageFlags;

            return result;
        }

		internal unsafe Interop.DescriptorSetLayoutBinding* MarshalTo()
        {
            return (Interop.DescriptorSetLayoutBinding*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DescriptorSetLayoutCreateInfo
	{

		public DescriptorSetLayoutCreateFlags Flags
		{
			get;
			set;
		}

		public DescriptorSetLayoutBinding[] Bindings
		{
			get;
			set;
		}

        internal unsafe Interop.DescriptorSetLayoutCreateInfo Pack()
        {
            var result = new Interop.DescriptorSetLayoutCreateInfo();
			result.SType = StructureType.DescriptorSetLayoutCreateInfo;
			
			//Bindings
			if (this.Bindings != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.DescriptorSetLayoutBinding>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.DescriptorSetLayoutBinding>(this.Bindings.Length);
			    for (int index = 0; index < this.Bindings.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.Bindings[index].Pack(), pointer + (size * index), false);
			    }
			    result.Bindings = (Interop.DescriptorSetLayoutBinding*)pointer.ToPointer();
			}
			else
			{
			    result.Bindings = null;
			}
			result.BindingCount = (uint)(this.Bindings?.Length ?? 0);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.DescriptorSetLayoutCreateInfo* MarshalTo()
        {
            return (Interop.DescriptorSetLayoutCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DeviceCreateInfo
	{

		public DeviceCreateFlags Flags
		{
			get;
			set;
		}

		public DeviceQueueCreateInfo[] QueueCreateInfos
		{
			get;
			set;
		}

		public string[] EnabledLayerNames
		{
			get;
			set;
		}

		public string[] EnabledExtensionNames
		{
			get;
			set;
		}

		public PhysicalDeviceFeatures EnabledFeatures
		{
			get;
			set;
		}

        internal unsafe Interop.DeviceCreateInfo Pack()
        {
            var result = new Interop.DeviceCreateInfo();
			result.SType = StructureType.DeviceCreateInfo;
			
			//QueueCreateInfos
			if (this.QueueCreateInfos != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.DeviceQueueCreateInfo>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.DeviceQueueCreateInfo>(this.QueueCreateInfos.Length);
			    for (int index = 0; index < this.QueueCreateInfos.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.QueueCreateInfos[index].Pack(), pointer + (size * index), false);
			    }
			    result.QueueCreateInfos = (Interop.DeviceQueueCreateInfo*)pointer.ToPointer();
			}
			else
			{
			    result.QueueCreateInfos = null;
			}
			result.EnabledLayerNames = this.EnabledLayerNames == null ? null : Interop.HeapUtil.MarshalTo(this.EnabledLayerNames);
			result.EnabledExtensionNames = this.EnabledExtensionNames == null ? null : Interop.HeapUtil.MarshalTo(this.EnabledExtensionNames);
			result.EnabledFeatures = (PhysicalDeviceFeatures*)Interop.HeapUtil.AllocateAndMarshal(this.EnabledFeatures);
			result.QueueCreateInfoCount = (uint)(this.QueueCreateInfos?.Length ?? 0);
			result.EnabledLayerCount = (uint)(this.EnabledLayerNames?.Length ?? 0);
			result.EnabledExtensionCount = (uint)(this.EnabledExtensionNames?.Length ?? 0);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.DeviceCreateInfo* MarshalTo()
        {
            return (Interop.DeviceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DeviceQueueCreateInfo
	{

		public DeviceQueueCreateFlags Flags
		{
			get;
			set;
		}

		public uint QueueFamilyIndex
		{
			get;
			set;
		}

		public float[] QueuePriorities
		{
			get;
			set;
		}

        internal unsafe Interop.DeviceQueueCreateInfo Pack()
        {
            var result = new Interop.DeviceQueueCreateInfo();
			result.SType = StructureType.DeviceQueueCreateInfo;
			result.QueuePriorities = this.QueuePriorities == null ? null : Interop.HeapUtil.MarshalTo(this.QueuePriorities);
			result.QueueCount = (uint)(this.QueuePriorities?.Length ?? 0);
			result.Flags = this.Flags;
			result.QueueFamilyIndex = this.QueueFamilyIndex;

            return result;
        }

		internal unsafe Interop.DeviceQueueCreateInfo* MarshalTo()
        {
            return (Interop.DeviceQueueCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DisplayModeCreateInfo
	{

		public DisplayModeCreateFlags Flags
		{
			get;
			set;
		}

		public DisplayModeParameters Parameters
		{
			get;
			set;
		}

        internal unsafe Interop.DisplayModeCreateInfo Pack()
        {
            var result = new Interop.DisplayModeCreateInfo();
			result.SType = StructureType.DisplayModeCreateInfo;
			result.Flags = this.Flags;
			result.Parameters = this.Parameters;

            return result;
        }

		internal unsafe Interop.DisplayModeCreateInfo* MarshalTo()
        {
            return (Interop.DisplayModeCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DisplayModeProperties
	{

		public DisplayMode DisplayMode
		{
			get;
			set;
		}

		public DisplayModeParameters Parameters
		{
			get;
			set;
		}

		internal unsafe DisplayModeProperties Unpack(Interop.DisplayModeProperties value)
		{
			return MarshalFrom(&value);
		}

		internal static unsafe DisplayModeProperties MarshalFrom(Interop.DisplayModeProperties* value)
		{
            var result = new DisplayModeProperties();

			result.Parameters = value->Parameters;

			return result;
		}
	}

	public struct DisplayPlaneProperties
	{

		public Display CurrentDisplay
		{
			get;
			set;
		}

		public uint CurrentStackIndex
		{
			get;
			set;
		}

		internal unsafe DisplayPlaneProperties Unpack(Interop.DisplayPlaneProperties value)
		{
			return MarshalFrom(&value);
		}

		internal static unsafe DisplayPlaneProperties MarshalFrom(Interop.DisplayPlaneProperties* value)
		{
            var result = new DisplayPlaneProperties();

			result.CurrentStackIndex = value->CurrentStackIndex;

			return result;
		}
	}

	public struct DisplayPresentInfo
	{

		public Rect2D SourceRect
		{
			get;
			set;
		}

		public Rect2D DestinationRect
		{
			get;
			set;
		}

		public Bool32 Persistent
		{
			get;
			set;
		}

        internal unsafe Interop.DisplayPresentInfo Pack()
        {
            var result = new Interop.DisplayPresentInfo();
			result.SType = StructureType.DisplayPresentInfo;
			result.SourceRect = this.SourceRect;
			result.DestinationRect = this.DestinationRect;
			result.Persistent = this.Persistent;

            return result;
        }

		internal unsafe Interop.DisplayPresentInfo* MarshalTo()
        {
            return (Interop.DisplayPresentInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct DisplayProperties
	{

		public Display Display
		{
			get;
			set;
		}

		public string DisplayName
		{
			get;
			set;
		}

		public Extent2D PhysicalDimensions
		{
			get;
			set;
		}

		public Extent2D PhysicalResolution
		{
			get;
			set;
		}

		public SurfaceTransformFlags SupportedTransforms
		{
			get;
			set;
		}

		public Bool32 PlaneReorderPossible
		{
			get;
			set;
		}

		public Bool32 PersistentContent
		{
			get;
			set;
		}

		internal unsafe DisplayProperties Unpack(Interop.DisplayProperties value)
		{
			return MarshalFrom(&value);
		}

		internal static unsafe DisplayProperties MarshalFrom(Interop.DisplayProperties* value)
		{
            var result = new DisplayProperties();

			result.DisplayName = Interop.HeapUtil.MarshalFrom(value->DisplayName);
			result.PhysicalDimensions = value->PhysicalDimensions;
			result.PhysicalResolution = value->PhysicalResolution;
			result.SupportedTransforms = value->SupportedTransforms;
			result.PlaneReorderPossible = value->PlaneReorderPossible;
			result.PersistentContent = value->PersistentContent;

			return result;
		}
	}

	public struct DisplaySurfaceCreateInfo
	{

		public DisplaySurfaceCreateFlags Flags
		{
			get;
			set;
		}

		public DisplayMode DisplayMode
		{
			get;
			set;
		}

		public uint PlaneIndex
		{
			get;
			set;
		}

		public uint PlaneStackIndex
		{
			get;
			set;
		}

		public SurfaceTransformFlags Transform
		{
			get;
			set;
		}

		public float GlobalAlpha
		{
			get;
			set;
		}

		public DisplayPlaneAlphaFlags AlphaMode
		{
			get;
			set;
		}

		public Extent2D ImageExtent
		{
			get;
			set;
		}

        internal unsafe Interop.DisplaySurfaceCreateInfo Pack()
        {
            var result = new Interop.DisplaySurfaceCreateInfo();
			result.SType = StructureType.DisplaySurfaceCreateInfo;
			result.DisplayMode = this.DisplayMode?.Pack() ?? Interop.DisplayMode.Null;
			result.Flags = this.Flags;
			result.PlaneIndex = this.PlaneIndex;
			result.PlaneStackIndex = this.PlaneStackIndex;
			result.Transform = this.Transform;
			result.GlobalAlpha = this.GlobalAlpha;
			result.AlphaMode = this.AlphaMode;
			result.ImageExtent = this.ImageExtent;

            return result;
        }

		internal unsafe Interop.DisplaySurfaceCreateInfo* MarshalTo()
        {
            return (Interop.DisplaySurfaceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct EventCreateInfo
	{

		public EventCreateFlags Flags
		{
			get;
			set;
		}

        internal unsafe Interop.EventCreateInfo Pack()
        {
            var result = new Interop.EventCreateInfo();
			result.SType = StructureType.EventCreateInfo;
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.EventCreateInfo* MarshalTo()
        {
            return (Interop.EventCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct ExtensionProperties
	{

		public string ExtensionName
		{
			get;
			set;
		}

		public Version SpecVersion
		{
			get;
			set;
		}

		internal unsafe ExtensionProperties Unpack(Interop.ExtensionProperties value)
		{
			return MarshalFrom(&value);
		}

		internal static unsafe ExtensionProperties MarshalFrom(Interop.ExtensionProperties* value)
		{
            var result = new ExtensionProperties();

			result.ExtensionName = System.Text.Encoding.UTF8.GetString(Interop.HeapUtil.MarshalFrom(value->ExtensionName, (int)Constants.MaxExtensionNameSize, true));
			result.SpecVersion = value->SpecVersion;

			return result;
		}
	}

	public struct FenceCreateInfo
	{

		public FenceCreateFlags Flags
		{
			get;
			set;
		}

        internal unsafe Interop.FenceCreateInfo Pack()
        {
            var result = new Interop.FenceCreateInfo();
			result.SType = StructureType.FenceCreateInfo;
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.FenceCreateInfo* MarshalTo()
        {
            return (Interop.FenceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct FramebufferCreateInfo
	{

		public FramebufferCreateFlags Flags
		{
			get;
			set;
		}

		public RenderPass RenderPass
		{
			get;
			set;
		}

		public ImageView[] Attachments
		{
			get;
			set;
		}

		public uint Width
		{
			get;
			set;
		}

		public uint Height
		{
			get;
			set;
		}

		public uint Layers
		{
			get;
			set;
		}

        internal unsafe Interop.FramebufferCreateInfo Pack()
        {
            var result = new Interop.FramebufferCreateInfo();
			result.SType = StructureType.FramebufferCreateInfo;
			result.RenderPass = this.RenderPass?.Pack() ?? Interop.RenderPass.Null;
			
			//Attachments
			if (this.Attachments != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.ImageView>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.ImageView>(this.Attachments.Length);
			    for (int index = 0; index < this.Attachments.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.Attachments[index].Pack(), pointer + (size * index), false);
			    }
			    result.Attachments = (Interop.ImageView*)pointer.ToPointer();
			}
			else
			{
			    result.Attachments = null;
			}
			result.AttachmentCount = (uint)(this.Attachments?.Length ?? 0);
			result.Flags = this.Flags;
			result.Width = this.Width;
			result.Height = this.Height;
			result.Layers = this.Layers;

            return result;
        }

		internal unsafe Interop.FramebufferCreateInfo* MarshalTo()
        {
            return (Interop.FramebufferCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct GraphicsPipelineCreateInfo
	{

		public PipelineCreateFlags Flags
		{
			get;
			set;
		}

		public PipelineShaderStageCreateInfo[] Stages
		{
			get;
			set;
		}

		public PipelineVertexInputStateCreateInfo? VertexInputState
		{
			get;
			set;
		}

		public PipelineInputAssemblyStateCreateInfo? InputAssemblyState
		{
			get;
			set;
		}

		public PipelineTessellationStateCreateInfo? TessellationState
		{
			get;
			set;
		}

		public PipelineViewportStateCreateInfo? ViewportState
		{
			get;
			set;
		}

		public PipelineRasterizationStateCreateInfo? RasterizationState
		{
			get;
			set;
		}

		public PipelineMultisampleStateCreateInfo? MultisampleState
		{
			get;
			set;
		}

		public PipelineDepthStencilStateCreateInfo? DepthStencilState
		{
			get;
			set;
		}

		public PipelineColorBlendStateCreateInfo? ColorBlendState
		{
			get;
			set;
		}

		public PipelineDynamicStateCreateInfo? DynamicState
		{
			get;
			set;
		}

		public PipelineLayout Layout
		{
			get;
			set;
		}

		public RenderPass RenderPass
		{
			get;
			set;
		}

		public uint Subpass
		{
			get;
			set;
		}

		public Pipeline BasePipelineHandle
		{
			get;
			set;
		}

		public int BasePipelineIndex
		{
			get;
			set;
		}

        internal unsafe Interop.GraphicsPipelineCreateInfo Pack()
        {
            var result = new Interop.GraphicsPipelineCreateInfo();
			result.SType = StructureType.GraphicsPipelineCreateInfo;
			
			//Stages
			if (this.Stages != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.PipelineShaderStageCreateInfo>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.PipelineShaderStageCreateInfo>(this.Stages.Length);
			    for (int index = 0; index < this.Stages.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.Stages[index].Pack(), pointer + (size * index), false);
			    }
			    result.Stages = (Interop.PipelineShaderStageCreateInfo*)pointer.ToPointer();
			}
			else
			{
			    result.Stages = null;
			}
			result.VertexInputState = this.VertexInputState == null ? null : this.VertexInputState.Value.MarshalTo();
			result.InputAssemblyState = this.InputAssemblyState == null ? null : this.InputAssemblyState.Value.MarshalTo();
			result.TessellationState = this.TessellationState == null ? null : this.TessellationState.Value.MarshalTo();
			result.ViewportState = this.ViewportState == null ? null : this.ViewportState.Value.MarshalTo();
			result.RasterizationState = this.RasterizationState == null ? null : this.RasterizationState.Value.MarshalTo();
			result.MultisampleState = this.MultisampleState == null ? null : this.MultisampleState.Value.MarshalTo();
			result.DepthStencilState = this.DepthStencilState == null ? null : this.DepthStencilState.Value.MarshalTo();
			result.ColorBlendState = this.ColorBlendState == null ? null : this.ColorBlendState.Value.MarshalTo();
			result.DynamicState = this.DynamicState == null ? null : this.DynamicState.Value.MarshalTo();
			result.Layout = this.Layout?.Pack() ?? Interop.PipelineLayout.Null;
			result.RenderPass = this.RenderPass?.Pack() ?? Interop.RenderPass.Null;
			result.BasePipelineHandle = this.BasePipelineHandle?.Pack() ?? Interop.Pipeline.Null;
			result.StageCount = (uint)(this.Stages?.Length ?? 0);
			result.Flags = this.Flags;
			result.Subpass = this.Subpass;
			result.BasePipelineIndex = this.BasePipelineIndex;

            return result;
        }

		internal unsafe Interop.GraphicsPipelineCreateInfo* MarshalTo()
        {
            return (Interop.GraphicsPipelineCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct ImageBlit
	{

		public ImageSubresourceLayers SourceSubresource
		{
			get;
			set;
		}

		public Offset3D[] SourceOffsets
		{
			get;
			set;
		}

		public ImageSubresourceLayers DestinationSubresource
		{
			get;
			set;
		}

		public Offset3D[] DestinationOffsets
		{
			get;
			set;
		}

        internal unsafe Interop.ImageBlit Pack()
        {
            var result = new Interop.ImageBlit();
			result.SourceSubresource = this.SourceSubresource;
			result.DestinationSubresource = this.DestinationSubresource;

            return result;
        }

		internal unsafe Interop.ImageBlit* MarshalTo()
        {
            return (Interop.ImageBlit*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct ImageCreateInfo
	{

		public ImageCreateFlags Flags
		{
			get;
			set;
		}

		public ImageType ImageType
		{
			get;
			set;
		}

		public Format Format
		{
			get;
			set;
		}

		public Extent3D Extent
		{
			get;
			set;
		}

		public uint MipLevels
		{
			get;
			set;
		}

		public uint ArrayLayers
		{
			get;
			set;
		}

		public SampleCountFlags Samples
		{
			get;
			set;
		}

		public ImageTiling Tiling
		{
			get;
			set;
		}

		public ImageUsageFlags Usage
		{
			get;
			set;
		}

		public SharingMode SharingMode
		{
			get;
			set;
		}

		public uint[] QueueFamilyIndices
		{
			get;
			set;
		}

		public ImageLayout InitialLayout
		{
			get;
			set;
		}

        internal unsafe Interop.ImageCreateInfo Pack()
        {
            var result = new Interop.ImageCreateInfo();
			result.SType = StructureType.ImageCreateInfo;
			result.QueueFamilyIndices = this.QueueFamilyIndices == null ? null : Interop.HeapUtil.MarshalTo(this.QueueFamilyIndices);
			result.QueueFamilyIndexCount = (uint)(this.QueueFamilyIndices?.Length ?? 0);
			result.Flags = this.Flags;
			result.ImageType = this.ImageType;
			result.Format = this.Format;
			result.Extent = this.Extent;
			result.MipLevels = this.MipLevels;
			result.ArrayLayers = this.ArrayLayers;
			result.Samples = this.Samples;
			result.Tiling = this.Tiling;
			result.Usage = this.Usage;
			result.SharingMode = this.SharingMode;
			result.InitialLayout = this.InitialLayout;

            return result;
        }

		internal unsafe Interop.ImageCreateInfo* MarshalTo()
        {
            return (Interop.ImageCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct ImageMemoryBarrier
	{

		public AccessFlags SourceAccessMask
		{
			get;
			set;
		}

		public AccessFlags DestinationAccessMask
		{
			get;
			set;
		}

		public ImageLayout OldLayout
		{
			get;
			set;
		}

		public ImageLayout NewLayout
		{
			get;
			set;
		}

		public uint SourceQueueFamilyIndex
		{
			get;
			set;
		}

		public uint DestinationQueueFamilyIndex
		{
			get;
			set;
		}

		public Image Image
		{
			get;
			set;
		}

		public ImageSubresourceRange SubresourceRange
		{
			get;
			set;
		}

        internal unsafe Interop.ImageMemoryBarrier Pack()
        {
            var result = new Interop.ImageMemoryBarrier();
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

	public struct ImageViewCreateInfo
	{

		public ImageViewCreateFlags Flags
		{
			get;
			set;
		}

		public Image Image
		{
			get;
			set;
		}

		public ImageViewType ViewType
		{
			get;
			set;
		}

		public Format Format
		{
			get;
			set;
		}

		public ComponentMapping Components
		{
			get;
			set;
		}

		public ImageSubresourceRange SubresourceRange
		{
			get;
			set;
		}

        internal unsafe Interop.ImageViewCreateInfo Pack()
        {
            var result = new Interop.ImageViewCreateInfo();
			result.SType = StructureType.ImageViewCreateInfo;
			result.Image = this.Image?.Pack() ?? Interop.Image.Null;
			result.Flags = this.Flags;
			result.ViewType = this.ViewType;
			result.Format = this.Format;
			result.Components = this.Components;
			result.SubresourceRange = this.SubresourceRange;

            return result;
        }

		internal unsafe Interop.ImageViewCreateInfo* MarshalTo()
        {
            return (Interop.ImageViewCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct InstanceCreateInfo
	{

		public InstanceCreateFlags Flags
		{
			get;
			set;
		}

		public ApplicationInfo? ApplicationInfo
		{
			get;
			set;
		}

		public string[] EnabledLayerNames
		{
			get;
			set;
		}

		public string[] EnabledExtensionNames
		{
			get;
			set;
		}

        internal unsafe Interop.InstanceCreateInfo Pack()
        {
            var result = new Interop.InstanceCreateInfo();
			result.SType = StructureType.InstanceCreateInfo;
			result.ApplicationInfo = this.ApplicationInfo == null ? null : this.ApplicationInfo.Value.MarshalTo();
			result.EnabledLayerNames = this.EnabledLayerNames == null ? null : Interop.HeapUtil.MarshalTo(this.EnabledLayerNames);
			result.EnabledExtensionNames = this.EnabledExtensionNames == null ? null : Interop.HeapUtil.MarshalTo(this.EnabledExtensionNames);
			result.EnabledLayerCount = (uint)(this.EnabledLayerNames?.Length ?? 0);
			result.EnabledExtensionCount = (uint)(this.EnabledExtensionNames?.Length ?? 0);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.InstanceCreateInfo* MarshalTo()
        {
            return (Interop.InstanceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct LayerProperties
	{

		public string LayerName
		{
			get;
			set;
		}

		public Version SpecVersion
		{
			get;
			set;
		}

		public Version ImplementationVersion
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		internal unsafe LayerProperties Unpack(Interop.LayerProperties value)
		{
			return MarshalFrom(&value);
		}

		internal static unsafe LayerProperties MarshalFrom(Interop.LayerProperties* value)
		{
            var result = new LayerProperties();

			result.LayerName = System.Text.Encoding.UTF8.GetString(Interop.HeapUtil.MarshalFrom(value->LayerName, (int)Constants.MaxExtensionNameSize, true));
			result.Description = System.Text.Encoding.UTF8.GetString(Interop.HeapUtil.MarshalFrom(value->Description, (int)Constants.MaxDescriptionSize, true));
			result.SpecVersion = value->SpecVersion;
			result.ImplementationVersion = value->ImplementationVersion;

			return result;
		}
	}

	public struct MappedMemoryRange
	{

		public DeviceMemory Memory
		{
			get;
			set;
		}

		public ulong Offset
		{
			get;
			set;
		}

		public ulong Size
		{
			get;
			set;
		}

        internal unsafe Interop.MappedMemoryRange Pack()
        {
            var result = new Interop.MappedMemoryRange();
			result.SType = StructureType.MappedMemoryRange;
			result.Memory = this.Memory?.Pack() ?? Interop.DeviceMemory.Null;
			result.Offset = this.Offset;
			result.Size = this.Size;

            return result;
        }

		internal unsafe Interop.MappedMemoryRange* MarshalTo()
        {
            return (Interop.MappedMemoryRange*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct MemoryAllocateInfo
	{

		public ulong AllocationSize
		{
			get;
			set;
		}

		public uint MemoryTypeIndex
		{
			get;
			set;
		}

        internal unsafe Interop.MemoryAllocateInfo Pack()
        {
            var result = new Interop.MemoryAllocateInfo();
			result.SType = StructureType.MemoryAllocateInfo;
			result.AllocationSize = this.AllocationSize;
			result.MemoryTypeIndex = this.MemoryTypeIndex;

            return result;
        }

		internal unsafe Interop.MemoryAllocateInfo* MarshalTo()
        {
            return (Interop.MemoryAllocateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct MemoryBarrier
	{

		public AccessFlags SourceAccessMask
		{
			get;
			set;
		}

		public AccessFlags DestinationAccessMask
		{
			get;
			set;
		}

        internal unsafe Interop.MemoryBarrier Pack()
        {
            var result = new Interop.MemoryBarrier();
			result.SType = StructureType.MemoryBarrier;
			result.SourceAccessMask = this.SourceAccessMask;
			result.DestinationAccessMask = this.DestinationAccessMask;

            return result;
        }

		internal unsafe Interop.MemoryBarrier* MarshalTo()
        {
            return (Interop.MemoryBarrier*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct MirSurfaceCreateInfo
	{

		public MirSurfaceCreateFlags Flags
		{
			get;
			set;
		}

		public IntPtr Connection
		{
			get;
			set;
		}

		public IntPtr MirSurface
		{
			get;
			set;
		}

        internal unsafe Interop.MirSurfaceCreateInfo Pack()
        {
            var result = new Interop.MirSurfaceCreateInfo();
			result.SType = StructureType.MirSurfaceCreateInfo;
			result.Connection = (IntPtr*)Interop.HeapUtil.AllocateAndMarshal(this.Connection);
			result.MirSurface = (IntPtr*)Interop.HeapUtil.AllocateAndMarshal(this.MirSurface);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.MirSurfaceCreateInfo* MarshalTo()
        {
            return (Interop.MirSurfaceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PhysicalDeviceLimits
	{

		public uint MaxImageDimension1D
		{
			get;
			set;
		}

		public uint MaxImageDimension2D
		{
			get;
			set;
		}

		public uint MaxImageDimension3D
		{
			get;
			set;
		}

		public uint MaxImageDimensionCube
		{
			get;
			set;
		}

		public uint MaxImageArrayLayers
		{
			get;
			set;
		}

		public uint MaxTexelBufferElements
		{
			get;
			set;
		}

		public uint MaxUniformBufferRange
		{
			get;
			set;
		}

		public uint MaxStorageBufferRange
		{
			get;
			set;
		}

		public uint MaxPushConstantsSize
		{
			get;
			set;
		}

		public uint MaxMemoryAllocationCount
		{
			get;
			set;
		}

		public uint MaxSamplerAllocationCount
		{
			get;
			set;
		}

		public ulong BufferImageGranularity
		{
			get;
			set;
		}

		public ulong SparseAddressSpaceSize
		{
			get;
			set;
		}

		public uint MaxBoundDescriptorSets
		{
			get;
			set;
		}

		public uint MaxPerStageDescriptorSamplers
		{
			get;
			set;
		}

		public uint MaxPerStageDescriptorUniformBuffers
		{
			get;
			set;
		}

		public uint MaxPerStageDescriptorStorageBuffers
		{
			get;
			set;
		}

		public uint MaxPerStageDescriptorSampledImages
		{
			get;
			set;
		}

		public uint MaxPerStageDescriptorStorageImages
		{
			get;
			set;
		}

		public uint MaxPerStageDescriptorInputAttachments
		{
			get;
			set;
		}

		public uint MaxPerStageResources
		{
			get;
			set;
		}

		public uint MaxDescriptorSetSamplers
		{
			get;
			set;
		}

		public uint MaxDescriptorSetUniformBuffers
		{
			get;
			set;
		}

		public uint MaxDescriptorSetUniformBuffersDynamic
		{
			get;
			set;
		}

		public uint MaxDescriptorSetStorageBuffers
		{
			get;
			set;
		}

		public uint MaxDescriptorSetStorageBuffersDynamic
		{
			get;
			set;
		}

		public uint MaxDescriptorSetSampledImages
		{
			get;
			set;
		}

		public uint MaxDescriptorSetStorageImages
		{
			get;
			set;
		}

		public uint MaxDescriptorSetInputAttachments
		{
			get;
			set;
		}

		public uint MaxVertexInputAttributes
		{
			get;
			set;
		}

		public uint MaxVertexInputBindings
		{
			get;
			set;
		}

		public uint MaxVertexInputAttributeOffset
		{
			get;
			set;
		}

		public uint MaxVertexInputBindingStride
		{
			get;
			set;
		}

		public uint MaxVertexOutputComponents
		{
			get;
			set;
		}

		public uint MaxTessellationGenerationLevel
		{
			get;
			set;
		}

		public uint MaxTessellationPatchSize
		{
			get;
			set;
		}

		public uint MaxTessellationControlPerVertexInputComponents
		{
			get;
			set;
		}

		public uint MaxTessellationControlPerVertexOutputComponents
		{
			get;
			set;
		}

		public uint MaxTessellationControlPerPatchOutputComponents
		{
			get;
			set;
		}

		public uint MaxTessellationControlTotalOutputComponents
		{
			get;
			set;
		}

		public uint MaxTessellationEvaluationInputComponents
		{
			get;
			set;
		}

		public uint MaxTessellationEvaluationOutputComponents
		{
			get;
			set;
		}

		public uint MaxGeometryShaderInvocations
		{
			get;
			set;
		}

		public uint MaxGeometryInputComponents
		{
			get;
			set;
		}

		public uint MaxGeometryOutputComponents
		{
			get;
			set;
		}

		public uint MaxGeometryOutputVertices
		{
			get;
			set;
		}

		public uint MaxGeometryTotalOutputComponents
		{
			get;
			set;
		}

		public uint MaxFragmentInputComponents
		{
			get;
			set;
		}

		public uint MaxFragmentOutputAttachments
		{
			get;
			set;
		}

		public uint MaxFragmentDualSourceAttachments
		{
			get;
			set;
		}

		public uint MaxFragmentCombinedOutputResources
		{
			get;
			set;
		}

		public uint MaxComputeSharedMemorySize
		{
			get;
			set;
		}

		public uint[] MaxComputeWorkGroupCount
		{
			get;
			set;
		}

		public uint MaxComputeWorkGroupInvocations
		{
			get;
			set;
		}

		public uint[] MaxComputeWorkGroupSize
		{
			get;
			set;
		}

		public uint SubPixelPrecisionBits
		{
			get;
			set;
		}

		public uint SubTexelPrecisionBits
		{
			get;
			set;
		}

		public uint MipmapPrecisionBits
		{
			get;
			set;
		}

		public uint MaxDrawIndexedIndexValue
		{
			get;
			set;
		}

		public uint MaxDrawIndirectCount
		{
			get;
			set;
		}

		public float MaxSamplerLodBias
		{
			get;
			set;
		}

		public float MaxSamplerAnisotropy
		{
			get;
			set;
		}

		public uint MaxViewports
		{
			get;
			set;
		}

		public uint[] MaxViewportDimensions
		{
			get;
			set;
		}

		public float[] ViewportBoundsRange
		{
			get;
			set;
		}

		public uint ViewportSubPixelBits
		{
			get;
			set;
		}

		public UIntPtr MinMemoryMapAlignment
		{
			get;
			set;
		}

		public ulong MinTexelBufferOffsetAlignment
		{
			get;
			set;
		}

		public ulong MinUniformBufferOffsetAlignment
		{
			get;
			set;
		}

		public ulong MinStorageBufferOffsetAlignment
		{
			get;
			set;
		}

		public int MinTexelOffset
		{
			get;
			set;
		}

		public uint MaxTexelOffset
		{
			get;
			set;
		}

		public int MinTexelGatherOffset
		{
			get;
			set;
		}

		public uint MaxTexelGatherOffset
		{
			get;
			set;
		}

		public float MinInterpolationOffset
		{
			get;
			set;
		}

		public float MaxInterpolationOffset
		{
			get;
			set;
		}

		public uint SubPixelInterpolationOffsetBits
		{
			get;
			set;
		}

		public uint MaxFramebufferWidth
		{
			get;
			set;
		}

		public uint MaxFramebufferHeight
		{
			get;
			set;
		}

		public uint MaxFramebufferLayers
		{
			get;
			set;
		}

		public SampleCountFlags FramebufferColorSampleCounts
		{
			get;
			set;
		}

		public SampleCountFlags FramebufferDepthSampleCounts
		{
			get;
			set;
		}

		public SampleCountFlags FramebufferStencilSampleCounts
		{
			get;
			set;
		}

		public SampleCountFlags FramebufferNoAttachmentsSampleCounts
		{
			get;
			set;
		}

		public uint MaxColorAttachments
		{
			get;
			set;
		}

		public SampleCountFlags SampledImageColorSampleCounts
		{
			get;
			set;
		}

		public SampleCountFlags SampledImageIntegerSampleCounts
		{
			get;
			set;
		}

		public SampleCountFlags SampledImageDepthSampleCounts
		{
			get;
			set;
		}

		public SampleCountFlags SampledImageStencilSampleCounts
		{
			get;
			set;
		}

		public SampleCountFlags StorageImageSampleCounts
		{
			get;
			set;
		}

		public uint MaxSampleMaskWords
		{
			get;
			set;
		}

		public Bool32 TimestampComputeAndGraphics
		{
			get;
			set;
		}

		public float TimestampPeriod
		{
			get;
			set;
		}

		public uint MaxClipDistances
		{
			get;
			set;
		}

		public uint MaxCullDistances
		{
			get;
			set;
		}

		public uint MaxCombinedClipAndCullDistances
		{
			get;
			set;
		}

		public uint DiscreteQueuePriorities
		{
			get;
			set;
		}

		public float[] PointSizeRange
		{
			get;
			set;
		}

		public float[] LineWidthRange
		{
			get;
			set;
		}

		public float PointSizeGranularity
		{
			get;
			set;
		}

		public float LineWidthGranularity
		{
			get;
			set;
		}

		public Bool32 StrictLines
		{
			get;
			set;
		}

		public Bool32 StandardSampleLocations
		{
			get;
			set;
		}

		public ulong OptimalBufferCopyOffsetAlignment
		{
			get;
			set;
		}

		public ulong OptimalBufferCopyRowPitchAlignment
		{
			get;
			set;
		}

		public ulong NonCoherentAtomSize
		{
			get;
			set;
		}

		internal unsafe PhysicalDeviceLimits Unpack(Interop.PhysicalDeviceLimits value)
		{
			return MarshalFrom(&value);
		}

		internal static unsafe PhysicalDeviceLimits MarshalFrom(Interop.PhysicalDeviceLimits* value)
		{
            var result = new PhysicalDeviceLimits();

			result.MaxComputeWorkGroupCount = Interop.HeapUtil.MarshalFrom(value->MaxComputeWorkGroupCount, 3);
			result.MaxComputeWorkGroupSize = Interop.HeapUtil.MarshalFrom(value->MaxComputeWorkGroupSize, 3);
			result.MaxViewportDimensions = Interop.HeapUtil.MarshalFrom(value->MaxViewportDimensions, 2);
			result.ViewportBoundsRange = Interop.HeapUtil.MarshalFrom(value->ViewportBoundsRange, 2);
			result.PointSizeRange = Interop.HeapUtil.MarshalFrom(value->PointSizeRange, 2);
			result.LineWidthRange = Interop.HeapUtil.MarshalFrom(value->LineWidthRange, 2);
			result.MaxImageDimension1D = value->MaxImageDimension1D;
			result.MaxImageDimension2D = value->MaxImageDimension2D;
			result.MaxImageDimension3D = value->MaxImageDimension3D;
			result.MaxImageDimensionCube = value->MaxImageDimensionCube;
			result.MaxImageArrayLayers = value->MaxImageArrayLayers;
			result.MaxTexelBufferElements = value->MaxTexelBufferElements;
			result.MaxUniformBufferRange = value->MaxUniformBufferRange;
			result.MaxStorageBufferRange = value->MaxStorageBufferRange;
			result.MaxPushConstantsSize = value->MaxPushConstantsSize;
			result.MaxMemoryAllocationCount = value->MaxMemoryAllocationCount;
			result.MaxSamplerAllocationCount = value->MaxSamplerAllocationCount;
			result.BufferImageGranularity = value->BufferImageGranularity;
			result.SparseAddressSpaceSize = value->SparseAddressSpaceSize;
			result.MaxBoundDescriptorSets = value->MaxBoundDescriptorSets;
			result.MaxPerStageDescriptorSamplers = value->MaxPerStageDescriptorSamplers;
			result.MaxPerStageDescriptorUniformBuffers = value->MaxPerStageDescriptorUniformBuffers;
			result.MaxPerStageDescriptorStorageBuffers = value->MaxPerStageDescriptorStorageBuffers;
			result.MaxPerStageDescriptorSampledImages = value->MaxPerStageDescriptorSampledImages;
			result.MaxPerStageDescriptorStorageImages = value->MaxPerStageDescriptorStorageImages;
			result.MaxPerStageDescriptorInputAttachments = value->MaxPerStageDescriptorInputAttachments;
			result.MaxPerStageResources = value->MaxPerStageResources;
			result.MaxDescriptorSetSamplers = value->MaxDescriptorSetSamplers;
			result.MaxDescriptorSetUniformBuffers = value->MaxDescriptorSetUniformBuffers;
			result.MaxDescriptorSetUniformBuffersDynamic = value->MaxDescriptorSetUniformBuffersDynamic;
			result.MaxDescriptorSetStorageBuffers = value->MaxDescriptorSetStorageBuffers;
			result.MaxDescriptorSetStorageBuffersDynamic = value->MaxDescriptorSetStorageBuffersDynamic;
			result.MaxDescriptorSetSampledImages = value->MaxDescriptorSetSampledImages;
			result.MaxDescriptorSetStorageImages = value->MaxDescriptorSetStorageImages;
			result.MaxDescriptorSetInputAttachments = value->MaxDescriptorSetInputAttachments;
			result.MaxVertexInputAttributes = value->MaxVertexInputAttributes;
			result.MaxVertexInputBindings = value->MaxVertexInputBindings;
			result.MaxVertexInputAttributeOffset = value->MaxVertexInputAttributeOffset;
			result.MaxVertexInputBindingStride = value->MaxVertexInputBindingStride;
			result.MaxVertexOutputComponents = value->MaxVertexOutputComponents;
			result.MaxTessellationGenerationLevel = value->MaxTessellationGenerationLevel;
			result.MaxTessellationPatchSize = value->MaxTessellationPatchSize;
			result.MaxTessellationControlPerVertexInputComponents = value->MaxTessellationControlPerVertexInputComponents;
			result.MaxTessellationControlPerVertexOutputComponents = value->MaxTessellationControlPerVertexOutputComponents;
			result.MaxTessellationControlPerPatchOutputComponents = value->MaxTessellationControlPerPatchOutputComponents;
			result.MaxTessellationControlTotalOutputComponents = value->MaxTessellationControlTotalOutputComponents;
			result.MaxTessellationEvaluationInputComponents = value->MaxTessellationEvaluationInputComponents;
			result.MaxTessellationEvaluationOutputComponents = value->MaxTessellationEvaluationOutputComponents;
			result.MaxGeometryShaderInvocations = value->MaxGeometryShaderInvocations;
			result.MaxGeometryInputComponents = value->MaxGeometryInputComponents;
			result.MaxGeometryOutputComponents = value->MaxGeometryOutputComponents;
			result.MaxGeometryOutputVertices = value->MaxGeometryOutputVertices;
			result.MaxGeometryTotalOutputComponents = value->MaxGeometryTotalOutputComponents;
			result.MaxFragmentInputComponents = value->MaxFragmentInputComponents;
			result.MaxFragmentOutputAttachments = value->MaxFragmentOutputAttachments;
			result.MaxFragmentDualSourceAttachments = value->MaxFragmentDualSourceAttachments;
			result.MaxFragmentCombinedOutputResources = value->MaxFragmentCombinedOutputResources;
			result.MaxComputeSharedMemorySize = value->MaxComputeSharedMemorySize;
			result.MaxComputeWorkGroupInvocations = value->MaxComputeWorkGroupInvocations;
			result.SubPixelPrecisionBits = value->SubPixelPrecisionBits;
			result.SubTexelPrecisionBits = value->SubTexelPrecisionBits;
			result.MipmapPrecisionBits = value->MipmapPrecisionBits;
			result.MaxDrawIndexedIndexValue = value->MaxDrawIndexedIndexValue;
			result.MaxDrawIndirectCount = value->MaxDrawIndirectCount;
			result.MaxSamplerLodBias = value->MaxSamplerLodBias;
			result.MaxSamplerAnisotropy = value->MaxSamplerAnisotropy;
			result.MaxViewports = value->MaxViewports;
			result.ViewportSubPixelBits = value->ViewportSubPixelBits;
			result.MinMemoryMapAlignment = value->MinMemoryMapAlignment;
			result.MinTexelBufferOffsetAlignment = value->MinTexelBufferOffsetAlignment;
			result.MinUniformBufferOffsetAlignment = value->MinUniformBufferOffsetAlignment;
			result.MinStorageBufferOffsetAlignment = value->MinStorageBufferOffsetAlignment;
			result.MinTexelOffset = value->MinTexelOffset;
			result.MaxTexelOffset = value->MaxTexelOffset;
			result.MinTexelGatherOffset = value->MinTexelGatherOffset;
			result.MaxTexelGatherOffset = value->MaxTexelGatherOffset;
			result.MinInterpolationOffset = value->MinInterpolationOffset;
			result.MaxInterpolationOffset = value->MaxInterpolationOffset;
			result.SubPixelInterpolationOffsetBits = value->SubPixelInterpolationOffsetBits;
			result.MaxFramebufferWidth = value->MaxFramebufferWidth;
			result.MaxFramebufferHeight = value->MaxFramebufferHeight;
			result.MaxFramebufferLayers = value->MaxFramebufferLayers;
			result.FramebufferColorSampleCounts = value->FramebufferColorSampleCounts;
			result.FramebufferDepthSampleCounts = value->FramebufferDepthSampleCounts;
			result.FramebufferStencilSampleCounts = value->FramebufferStencilSampleCounts;
			result.FramebufferNoAttachmentsSampleCounts = value->FramebufferNoAttachmentsSampleCounts;
			result.MaxColorAttachments = value->MaxColorAttachments;
			result.SampledImageColorSampleCounts = value->SampledImageColorSampleCounts;
			result.SampledImageIntegerSampleCounts = value->SampledImageIntegerSampleCounts;
			result.SampledImageDepthSampleCounts = value->SampledImageDepthSampleCounts;
			result.SampledImageStencilSampleCounts = value->SampledImageStencilSampleCounts;
			result.StorageImageSampleCounts = value->StorageImageSampleCounts;
			result.MaxSampleMaskWords = value->MaxSampleMaskWords;
			result.TimestampComputeAndGraphics = value->TimestampComputeAndGraphics;
			result.TimestampPeriod = value->TimestampPeriod;
			result.MaxClipDistances = value->MaxClipDistances;
			result.MaxCullDistances = value->MaxCullDistances;
			result.MaxCombinedClipAndCullDistances = value->MaxCombinedClipAndCullDistances;
			result.DiscreteQueuePriorities = value->DiscreteQueuePriorities;
			result.PointSizeGranularity = value->PointSizeGranularity;
			result.LineWidthGranularity = value->LineWidthGranularity;
			result.StrictLines = value->StrictLines;
			result.StandardSampleLocations = value->StandardSampleLocations;
			result.OptimalBufferCopyOffsetAlignment = value->OptimalBufferCopyOffsetAlignment;
			result.OptimalBufferCopyRowPitchAlignment = value->OptimalBufferCopyRowPitchAlignment;
			result.NonCoherentAtomSize = value->NonCoherentAtomSize;

			return result;
		}
	}

	public struct PhysicalDeviceMemoryProperties
	{

		public MemoryType[] MemoryTypes
		{
			get;
			set;
		}

		public MemoryHeap[] MemoryHeaps
		{
			get;
			set;
		}

		internal unsafe PhysicalDeviceMemoryProperties Unpack(Interop.PhysicalDeviceMemoryProperties value)
		{
			return MarshalFrom(&value);
		}

		internal static unsafe PhysicalDeviceMemoryProperties MarshalFrom(Interop.PhysicalDeviceMemoryProperties* value)
		{
            var result = new PhysicalDeviceMemoryProperties();

			result.MemoryTypes = new MemoryType[value->MemoryTypeCount];
			MemoryType* MemoryTypesPointer = &value->MemoryTypes;
			for (int index = 0; index < value->MemoryTypeCount; index++)
			{
			    result.MemoryTypes[index] = *MemoryTypesPointer;
			    MemoryTypesPointer++;
			}
			result.MemoryHeaps = new MemoryHeap[value->MemoryHeapCount];
			MemoryHeap* MemoryHeapsPointer = &value->MemoryHeaps;
			for (int index = 0; index < value->MemoryHeapCount; index++)
			{
			    result.MemoryHeaps[index] = *MemoryHeapsPointer;
			    MemoryHeapsPointer++;
			}

			return result;
		}
	}

	public struct PhysicalDeviceProperties
	{

		public Version ApiVersion
		{
			get;
			set;
		}

		public Version DriverVersion
		{
			get;
			set;
		}

		public uint VendorID
		{
			get;
			set;
		}

		public uint DeviceID
		{
			get;
			set;
		}

		public PhysicalDeviceType DeviceType
		{
			get;
			set;
		}

		public string DeviceName
		{
			get;
			set;
		}

		public Guid PipelineCacheUUID
		{
			get;
			set;
		}

		public PhysicalDeviceLimits Limits
		{
			get;
			set;
		}

		public PhysicalDeviceSparseProperties SparseProperties
		{
			get;
			set;
		}

		internal unsafe PhysicalDeviceProperties Unpack(Interop.PhysicalDeviceProperties value)
		{
			return MarshalFrom(&value);
		}

		internal static unsafe PhysicalDeviceProperties MarshalFrom(Interop.PhysicalDeviceProperties* value)
		{
            var result = new PhysicalDeviceProperties();

			result.DeviceName = System.Text.Encoding.UTF8.GetString(Interop.HeapUtil.MarshalFrom(value->DeviceName, (int)Constants.MaxPhysicalDeviceNameSize, true));
			result.PipelineCacheUUID = new Guid(Interop.HeapUtil.MarshalFrom(value->PipelineCacheUUID, (int)Constants.UuidSize));
			result.Limits = PhysicalDeviceLimits.MarshalFrom(&value->Limits);
			result.ApiVersion = value->ApiVersion;
			result.DriverVersion = value->DriverVersion;
			result.VendorID = value->VendorID;
			result.DeviceID = value->DeviceID;
			result.DeviceType = value->DeviceType;
			result.SparseProperties = value->SparseProperties;

			return result;
		}
	}

	public struct PipelineCacheCreateInfo
	{

		public PipelineCacheCreateFlags Flags
		{
			get;
			set;
		}

		public byte[] InitialData
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineCacheCreateInfo Pack()
        {
            var result = new Interop.PipelineCacheCreateInfo();
			result.SType = StructureType.PipelineCacheCreateInfo;
			result.InitialData = this.InitialData == null ? null : Interop.HeapUtil.MarshalTo(this.InitialData);
			result.InitialDataSize = (UIntPtr)(this.InitialData?.Length ?? 0);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.PipelineCacheCreateInfo* MarshalTo()
        {
            return (Interop.PipelineCacheCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineColorBlendStateCreateInfo
	{

		public PipelineColorBlendStateCreateFlags Flags
		{
			get;
			set;
		}

		public Bool32 LogicOpEnable
		{
			get;
			set;
		}

		public LogicOp LogicOp
		{
			get;
			set;
		}

		public PipelineColorBlendAttachmentState[] Attachments
		{
			get;
			set;
		}

		public float[] BlendConstants
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineColorBlendStateCreateInfo Pack()
        {
            var result = new Interop.PipelineColorBlendStateCreateInfo();
			result.SType = StructureType.PipelineColorBlendStateCreateInfo;
			
			//Attachments
			if (this.Attachments != null)
			{
			    result.Attachments = (PipelineColorBlendAttachmentState*)Interop.HeapUtil.Allocate<PipelineColorBlendAttachmentState>(this.Attachments.Length).ToPointer();
			    for (int index = 0; index < this.Attachments.Length; index++)
			    {
			        result.Attachments[index] = this.Attachments[index];
			    }
			}
			else
			{
			    result.Attachments = null;
			}
			result.AttachmentCount = (uint)(this.Attachments?.Length ?? 0);
			result.Flags = this.Flags;
			result.LogicOpEnable = this.LogicOpEnable;
			result.LogicOp = this.LogicOp;

            return result;
        }

		internal unsafe Interop.PipelineColorBlendStateCreateInfo* MarshalTo()
        {
            return (Interop.PipelineColorBlendStateCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineDepthStencilStateCreateInfo
	{

		public PipelineDepthStencilStateCreateFlags Flags
		{
			get;
			set;
		}

		public Bool32 DepthTestEnable
		{
			get;
			set;
		}

		public Bool32 DepthWriteEnable
		{
			get;
			set;
		}

		public CompareOp DepthCompareOp
		{
			get;
			set;
		}

		public Bool32 DepthBoundsTestEnable
		{
			get;
			set;
		}

		public Bool32 StencilTestEnable
		{
			get;
			set;
		}

		public StencilOpState Front
		{
			get;
			set;
		}

		public StencilOpState Back
		{
			get;
			set;
		}

		public float MinDepthBounds
		{
			get;
			set;
		}

		public float MaxDepthBounds
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineDepthStencilStateCreateInfo Pack()
        {
            var result = new Interop.PipelineDepthStencilStateCreateInfo();
			result.SType = StructureType.PipelineDepthStencilStateCreateInfo;
			result.Flags = this.Flags;
			result.DepthTestEnable = this.DepthTestEnable;
			result.DepthWriteEnable = this.DepthWriteEnable;
			result.DepthCompareOp = this.DepthCompareOp;
			result.DepthBoundsTestEnable = this.DepthBoundsTestEnable;
			result.StencilTestEnable = this.StencilTestEnable;
			result.Front = this.Front;
			result.Back = this.Back;
			result.MinDepthBounds = this.MinDepthBounds;
			result.MaxDepthBounds = this.MaxDepthBounds;

            return result;
        }

		internal unsafe Interop.PipelineDepthStencilStateCreateInfo* MarshalTo()
        {
            return (Interop.PipelineDepthStencilStateCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineDynamicStateCreateInfo
	{

		public PipelineDynamicStateCreateFlags Flags
		{
			get;
			set;
		}

		public DynamicState[] DynamicStates
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineDynamicStateCreateInfo Pack()
        {
            var result = new Interop.PipelineDynamicStateCreateInfo();
			result.SType = StructureType.PipelineDynamicStateCreateInfo;
			
			//DynamicStates
			if (this.DynamicStates != null)
			{
			    result.DynamicStates = (DynamicState*)Interop.HeapUtil.Allocate<int>(this.DynamicStates.Length).ToPointer();
			    for (int index = 0; index < this.DynamicStates.Length; index++)
			    {
			        result.DynamicStates[index] = this.DynamicStates[index];
			    }
			}
			else
			{
			    result.DynamicStates = null;
			}
			result.DynamicStateCount = (uint)(this.DynamicStates?.Length ?? 0);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.PipelineDynamicStateCreateInfo* MarshalTo()
        {
            return (Interop.PipelineDynamicStateCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineInputAssemblyStateCreateInfo
	{

		public PipelineInputAssemblyStateCreateFlags Flags
		{
			get;
			set;
		}

		public PrimitiveTopology Topology
		{
			get;
			set;
		}

		public Bool32 PrimitiveRestartEnable
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineInputAssemblyStateCreateInfo Pack()
        {
            var result = new Interop.PipelineInputAssemblyStateCreateInfo();
			result.SType = StructureType.PipelineInputAssemblyStateCreateInfo;
			result.Flags = this.Flags;
			result.Topology = this.Topology;
			result.PrimitiveRestartEnable = this.PrimitiveRestartEnable;

            return result;
        }

		internal unsafe Interop.PipelineInputAssemblyStateCreateInfo* MarshalTo()
        {
            return (Interop.PipelineInputAssemblyStateCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineLayoutCreateInfo
	{

		public PipelineLayoutCreateFlags Flags
		{
			get;
			set;
		}

		public DescriptorSetLayout[] SetLayouts
		{
			get;
			set;
		}

		public PushConstantRange[] PushConstantRanges
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineLayoutCreateInfo Pack()
        {
            var result = new Interop.PipelineLayoutCreateInfo();
			result.SType = StructureType.PipelineLayoutCreateInfo;
			
			//SetLayouts
			if (this.SetLayouts != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.DescriptorSetLayout>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.DescriptorSetLayout>(this.SetLayouts.Length);
			    for (int index = 0; index < this.SetLayouts.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.SetLayouts[index].Pack(), pointer + (size * index), false);
			    }
			    result.SetLayouts = (Interop.DescriptorSetLayout*)pointer.ToPointer();
			}
			else
			{
			    result.SetLayouts = null;
			}
			
			//PushConstantRanges
			if (this.PushConstantRanges != null)
			{
			    result.PushConstantRanges = (PushConstantRange*)Interop.HeapUtil.Allocate<PushConstantRange>(this.PushConstantRanges.Length).ToPointer();
			    for (int index = 0; index < this.PushConstantRanges.Length; index++)
			    {
			        result.PushConstantRanges[index] = this.PushConstantRanges[index];
			    }
			}
			else
			{
			    result.PushConstantRanges = null;
			}
			result.SetLayoutCount = (uint)(this.SetLayouts?.Length ?? 0);
			result.PushConstantRangeCount = (uint)(this.PushConstantRanges?.Length ?? 0);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.PipelineLayoutCreateInfo* MarshalTo()
        {
            return (Interop.PipelineLayoutCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineMultisampleStateCreateInfo
	{

		public PipelineMultisampleStateCreateFlags Flags
		{
			get;
			set;
		}

		public SampleCountFlags RasterizationSamples
		{
			get;
			set;
		}

		public Bool32 SampleShadingEnable
		{
			get;
			set;
		}

		public float MinSampleShading
		{
			get;
			set;
		}

		public SampleMask[] SampleMask
		{
			get;
			set;
		}

		public Bool32 AlphaToCoverageEnable
		{
			get;
			set;
		}

		public Bool32 AlphaToOneEnable
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineMultisampleStateCreateInfo Pack()
        {
            var result = new Interop.PipelineMultisampleStateCreateInfo();
			result.SType = StructureType.PipelineMultisampleStateCreateInfo;
			
			//SampleMask
			if (this.SampleMask != null && Math.Ceiling((int)RasterizationSamples / (float)32) > 0)
			{
			    int length = (int)(Math.Ceiling((int)RasterizationSamples / (float)32));
			    result.SampleMask = (SampleMask*)Interop.HeapUtil.Allocate<SampleMask>(length).ToPointer();
			    for (int index = 0; index < length; index++)
			    {
			        result.SampleMask[index] = this.SampleMask[index];
			    }
			}
			else
			{
			    result.SampleMask = null;
			}
			result.Flags = this.Flags;
			result.RasterizationSamples = this.RasterizationSamples;
			result.SampleShadingEnable = this.SampleShadingEnable;
			result.MinSampleShading = this.MinSampleShading;
			result.AlphaToCoverageEnable = this.AlphaToCoverageEnable;
			result.AlphaToOneEnable = this.AlphaToOneEnable;

            return result;
        }

		internal unsafe Interop.PipelineMultisampleStateCreateInfo* MarshalTo()
        {
            return (Interop.PipelineMultisampleStateCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineRasterizationStateCreateInfo
	{

		public PipelineRasterizationStateCreateFlags Flags
		{
			get;
			set;
		}

		public Bool32 DepthClampEnable
		{
			get;
			set;
		}

		public Bool32 RasterizerDiscardEnable
		{
			get;
			set;
		}

		public PolygonMode PolygonMode
		{
			get;
			set;
		}

		public CullModeFlags CullMode
		{
			get;
			set;
		}

		public FrontFace FrontFace
		{
			get;
			set;
		}

		public Bool32 DepthBiasEnable
		{
			get;
			set;
		}

		public float DepthBiasConstantFactor
		{
			get;
			set;
		}

		public float DepthBiasClamp
		{
			get;
			set;
		}

		public float DepthBiasSlopeFactor
		{
			get;
			set;
		}

		public float LineWidth
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineRasterizationStateCreateInfo Pack()
        {
            var result = new Interop.PipelineRasterizationStateCreateInfo();
			result.SType = StructureType.PipelineRasterizationStateCreateInfo;
			result.Flags = this.Flags;
			result.DepthClampEnable = this.DepthClampEnable;
			result.RasterizerDiscardEnable = this.RasterizerDiscardEnable;
			result.PolygonMode = this.PolygonMode;
			result.CullMode = this.CullMode;
			result.FrontFace = this.FrontFace;
			result.DepthBiasEnable = this.DepthBiasEnable;
			result.DepthBiasConstantFactor = this.DepthBiasConstantFactor;
			result.DepthBiasClamp = this.DepthBiasClamp;
			result.DepthBiasSlopeFactor = this.DepthBiasSlopeFactor;
			result.LineWidth = this.LineWidth;

            return result;
        }

		internal unsafe Interop.PipelineRasterizationStateCreateInfo* MarshalTo()
        {
            return (Interop.PipelineRasterizationStateCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineRasterizationStateRasterizationOrder
	{

		public RasterizationOrder RasterizationOrder
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineRasterizationStateRasterizationOrder Pack()
        {
            var result = new Interop.PipelineRasterizationStateRasterizationOrder();
			result.SType = StructureType.PipelineRasterizationStateRasterizationOrder;
			result.RasterizationOrder = this.RasterizationOrder;

            return result;
        }

		internal unsafe Interop.PipelineRasterizationStateRasterizationOrder* MarshalTo()
        {
            return (Interop.PipelineRasterizationStateRasterizationOrder*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineShaderStageCreateInfo
	{

		public PipelineShaderStageCreateFlags Flags
		{
			get;
			set;
		}

		public ShaderStageFlags Stage
		{
			get;
			set;
		}

		public ShaderModule Module
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public SpecializationInfo? SpecializationInfo
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineShaderStageCreateInfo Pack()
        {
            var result = new Interop.PipelineShaderStageCreateInfo();
			result.SType = StructureType.PipelineShaderStageCreateInfo;
			result.Module = this.Module?.Pack() ?? Interop.ShaderModule.Null;
			result.Name = Interop.HeapUtil.MarshalTo(this.Name);
			result.SpecializationInfo = this.SpecializationInfo == null ? null : this.SpecializationInfo.Value.MarshalTo();
			result.Flags = this.Flags;
			result.Stage = this.Stage;

            return result;
        }

		internal unsafe Interop.PipelineShaderStageCreateInfo* MarshalTo()
        {
            return (Interop.PipelineShaderStageCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineTessellationStateCreateInfo
	{

		public PipelineTessellationStateCreateFlags Flags
		{
			get;
			set;
		}

		public uint PatchControlPoints
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineTessellationStateCreateInfo Pack()
        {
            var result = new Interop.PipelineTessellationStateCreateInfo();
			result.SType = StructureType.PipelineTessellationStateCreateInfo;
			result.Flags = this.Flags;
			result.PatchControlPoints = this.PatchControlPoints;

            return result;
        }

		internal unsafe Interop.PipelineTessellationStateCreateInfo* MarshalTo()
        {
            return (Interop.PipelineTessellationStateCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineVertexInputStateCreateInfo
	{

		public PipelineVertexInputStateCreateFlags Flags
		{
			get;
			set;
		}

		public VertexInputBindingDescription[] VertexBindingDescriptions
		{
			get;
			set;
		}

		public VertexInputAttributeDescription[] VertexAttributeDescriptions
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineVertexInputStateCreateInfo Pack()
        {
            var result = new Interop.PipelineVertexInputStateCreateInfo();
			result.SType = StructureType.PipelineVertexInputStateCreateInfo;
			
			//VertexBindingDescriptions
			if (this.VertexBindingDescriptions != null)
			{
			    result.VertexBindingDescriptions = (VertexInputBindingDescription*)Interop.HeapUtil.Allocate<VertexInputBindingDescription>(this.VertexBindingDescriptions.Length).ToPointer();
			    for (int index = 0; index < this.VertexBindingDescriptions.Length; index++)
			    {
			        result.VertexBindingDescriptions[index] = this.VertexBindingDescriptions[index];
			    }
			}
			else
			{
			    result.VertexBindingDescriptions = null;
			}
			
			//VertexAttributeDescriptions
			if (this.VertexAttributeDescriptions != null)
			{
			    result.VertexAttributeDescriptions = (VertexInputAttributeDescription*)Interop.HeapUtil.Allocate<VertexInputAttributeDescription>(this.VertexAttributeDescriptions.Length).ToPointer();
			    for (int index = 0; index < this.VertexAttributeDescriptions.Length; index++)
			    {
			        result.VertexAttributeDescriptions[index] = this.VertexAttributeDescriptions[index];
			    }
			}
			else
			{
			    result.VertexAttributeDescriptions = null;
			}
			result.VertexBindingDescriptionCount = (uint)(this.VertexBindingDescriptions?.Length ?? 0);
			result.VertexAttributeDescriptionCount = (uint)(this.VertexAttributeDescriptions?.Length ?? 0);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.PipelineVertexInputStateCreateInfo* MarshalTo()
        {
            return (Interop.PipelineVertexInputStateCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PipelineViewportStateCreateInfo
	{

		public PipelineViewportStateCreateFlags Flags
		{
			get;
			set;
		}

		public Viewport[] Viewports
		{
			get;
			set;
		}

		public Rect2D[] Scissors
		{
			get;
			set;
		}

        internal unsafe Interop.PipelineViewportStateCreateInfo Pack()
        {
            var result = new Interop.PipelineViewportStateCreateInfo();
			result.SType = StructureType.PipelineViewportStateCreateInfo;
			
			//Viewports
			if (this.Viewports != null)
			{
			    result.Viewports = (Viewport*)Interop.HeapUtil.Allocate<Viewport>(this.Viewports.Length).ToPointer();
			    for (int index = 0; index < this.Viewports.Length; index++)
			    {
			        result.Viewports[index] = this.Viewports[index];
			    }
			}
			else
			{
			    result.Viewports = null;
			}
			
			//Scissors
			if (this.Scissors != null)
			{
			    result.Scissors = (Rect2D*)Interop.HeapUtil.Allocate<Rect2D>(this.Scissors.Length).ToPointer();
			    for (int index = 0; index < this.Scissors.Length; index++)
			    {
			        result.Scissors[index] = this.Scissors[index];
			    }
			}
			else
			{
			    result.Scissors = null;
			}
			result.ViewportCount = (uint)(this.Viewports?.Length ?? 0);
			result.ScissorCount = (uint)(this.Scissors?.Length ?? 0);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.PipelineViewportStateCreateInfo* MarshalTo()
        {
            return (Interop.PipelineViewportStateCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct PresentInfo
	{

		public Semaphore[] WaitSemaphores
		{
			get;
			set;
		}

		public Swapchain[] Swapchains
		{
			get;
			set;
		}

		public uint[] ImageIndices
		{
			get;
			set;
		}

		public Result[] Results
		{
			get;
			set;
		}

        internal unsafe Interop.PresentInfo Pack()
        {
            var result = new Interop.PresentInfo();
			result.SType = StructureType.PresentInfo;
			
			//WaitSemaphores
			if (this.WaitSemaphores != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.Semaphore>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.Semaphore>(this.WaitSemaphores.Length);
			    for (int index = 0; index < this.WaitSemaphores.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.WaitSemaphores[index].Pack(), pointer + (size * index), false);
			    }
			    result.WaitSemaphores = (Interop.Semaphore*)pointer.ToPointer();
			}
			else
			{
			    result.WaitSemaphores = null;
			}
			
			//Swapchains
			if (this.Swapchains != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.Swapchain>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.Swapchain>(this.Swapchains.Length);
			    for (int index = 0; index < this.Swapchains.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.Swapchains[index].Pack(), pointer + (size * index), false);
			    }
			    result.Swapchains = (Interop.Swapchain*)pointer.ToPointer();
			}
			else
			{
			    result.Swapchains = null;
			}
			result.ImageIndices = this.ImageIndices == null ? null : Interop.HeapUtil.MarshalTo(this.ImageIndices);
			
			//Results
			if (this.Results != null)
			{
			    result.Results = (Result*)Interop.HeapUtil.Allocate<int>(this.Results.Length).ToPointer();
			    for (int index = 0; index < this.Results.Length; index++)
			    {
			        result.Results[index] = this.Results[index];
			    }
			}
			else
			{
			    result.Results = null;
			}
			result.WaitSemaphoreCount = (uint)(this.WaitSemaphores?.Length ?? 0);
			result.SwapchainCount = (uint)(this.ImageIndices?.Length ?? 0);

            return result;
        }

		internal unsafe Interop.PresentInfo* MarshalTo()
        {
            return (Interop.PresentInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct QueryPoolCreateInfo
	{

		public QueryPoolCreateFlags Flags
		{
			get;
			set;
		}

		public QueryType QueryType
		{
			get;
			set;
		}

		public uint QueryCount
		{
			get;
			set;
		}

		public QueryPipelineStatisticFlags PipelineStatistics
		{
			get;
			set;
		}

        internal unsafe Interop.QueryPoolCreateInfo Pack()
        {
            var result = new Interop.QueryPoolCreateInfo();
			result.SType = StructureType.QueryPoolCreateInfo;
			result.Flags = this.Flags;
			result.QueryType = this.QueryType;
			result.QueryCount = this.QueryCount;
			result.PipelineStatistics = this.PipelineStatistics;

            return result;
        }

		internal unsafe Interop.QueryPoolCreateInfo* MarshalTo()
        {
            return (Interop.QueryPoolCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct RenderPassBeginInfo
	{

		public RenderPass RenderPass
		{
			get;
			set;
		}

		public Framebuffer Framebuffer
		{
			get;
			set;
		}

		public Rect2D RenderArea
		{
			get;
			set;
		}

		public ClearValue[] ClearValues
		{
			get;
			set;
		}

        internal unsafe Interop.RenderPassBeginInfo Pack()
        {
            var result = new Interop.RenderPassBeginInfo();
			result.SType = StructureType.RenderPassBeginInfo;
			result.RenderPass = this.RenderPass?.Pack() ?? Interop.RenderPass.Null;
			result.Framebuffer = this.Framebuffer?.Pack() ?? Interop.Framebuffer.Null;
			
			//ClearValues
			if (this.ClearValues != null && this.ClearValues.Length > 0)
			{
			    int length = (int)(this.ClearValues.Length);
			    result.ClearValues = (ClearValue*)Interop.HeapUtil.Allocate<ClearValue>(length).ToPointer();
			    for (int index = 0; index < length; index++)
			    {
			        result.ClearValues[index] = this.ClearValues[index];
			    }
			}
			else
			{
			    result.ClearValues = null;
			}
			result.ClearValueCount = (uint)(this.ClearValues?.Length ?? 0);
			result.RenderArea = this.RenderArea;

            return result;
        }

		internal unsafe Interop.RenderPassBeginInfo* MarshalTo()
        {
            return (Interop.RenderPassBeginInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct RenderPassCreateInfo
	{

		public RenderPassCreateFlags Flags
		{
			get;
			set;
		}

		public AttachmentDescription[] Attachments
		{
			get;
			set;
		}

		public SubpassDescription[] Subpasses
		{
			get;
			set;
		}

		public SubpassDependency[] Dependencies
		{
			get;
			set;
		}

        internal unsafe Interop.RenderPassCreateInfo Pack()
        {
            var result = new Interop.RenderPassCreateInfo();
			result.SType = StructureType.RenderPassCreateInfo;
			
			//Attachments
			if (this.Attachments != null)
			{
			    result.Attachments = (AttachmentDescription*)Interop.HeapUtil.Allocate<AttachmentDescription>(this.Attachments.Length).ToPointer();
			    for (int index = 0; index < this.Attachments.Length; index++)
			    {
			        result.Attachments[index] = this.Attachments[index];
			    }
			}
			else
			{
			    result.Attachments = null;
			}
			
			//Subpasses
			if (this.Subpasses != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.SubpassDescription>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.SubpassDescription>(this.Subpasses.Length);
			    for (int index = 0; index < this.Subpasses.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.Subpasses[index].Pack(), pointer + (size * index), false);
			    }
			    result.Subpasses = (Interop.SubpassDescription*)pointer.ToPointer();
			}
			else
			{
			    result.Subpasses = null;
			}
			
			//Dependencies
			if (this.Dependencies != null)
			{
			    result.Dependencies = (SubpassDependency*)Interop.HeapUtil.Allocate<SubpassDependency>(this.Dependencies.Length).ToPointer();
			    for (int index = 0; index < this.Dependencies.Length; index++)
			    {
			        result.Dependencies[index] = this.Dependencies[index];
			    }
			}
			else
			{
			    result.Dependencies = null;
			}
			result.AttachmentCount = (uint)(this.Attachments?.Length ?? 0);
			result.SubpassCount = (uint)(this.Subpasses?.Length ?? 0);
			result.DependencyCount = (uint)(this.Dependencies?.Length ?? 0);
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.RenderPassCreateInfo* MarshalTo()
        {
            return (Interop.RenderPassCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SamplerCreateInfo
	{

		public SamplerCreateFlags Flags
		{
			get;
			set;
		}

		public Filter MagFilter
		{
			get;
			set;
		}

		public Filter MinFilter
		{
			get;
			set;
		}

		public SamplerMipmapMode MipmapMode
		{
			get;
			set;
		}

		public SamplerAddressMode AddressModeU
		{
			get;
			set;
		}

		public SamplerAddressMode AddressModeV
		{
			get;
			set;
		}

		public SamplerAddressMode AddressModeW
		{
			get;
			set;
		}

		public float MipLodBias
		{
			get;
			set;
		}

		public Bool32 AnisotropyEnable
		{
			get;
			set;
		}

		public float MaxAnisotropy
		{
			get;
			set;
		}

		public Bool32 CompareEnable
		{
			get;
			set;
		}

		public CompareOp CompareOp
		{
			get;
			set;
		}

		public float MinLod
		{
			get;
			set;
		}

		public float MaxLod
		{
			get;
			set;
		}

		public BorderColor BorderColor
		{
			get;
			set;
		}

		public Bool32 UnnormalizedCoordinates
		{
			get;
			set;
		}

        internal unsafe Interop.SamplerCreateInfo Pack()
        {
            var result = new Interop.SamplerCreateInfo();
			result.SType = StructureType.SamplerCreateInfo;
			result.Flags = this.Flags;
			result.MagFilter = this.MagFilter;
			result.MinFilter = this.MinFilter;
			result.MipmapMode = this.MipmapMode;
			result.AddressModeU = this.AddressModeU;
			result.AddressModeV = this.AddressModeV;
			result.AddressModeW = this.AddressModeW;
			result.MipLodBias = this.MipLodBias;
			result.AnisotropyEnable = this.AnisotropyEnable;
			result.MaxAnisotropy = this.MaxAnisotropy;
			result.CompareEnable = this.CompareEnable;
			result.CompareOp = this.CompareOp;
			result.MinLod = this.MinLod;
			result.MaxLod = this.MaxLod;
			result.BorderColor = this.BorderColor;
			result.UnnormalizedCoordinates = this.UnnormalizedCoordinates;

            return result;
        }

		internal unsafe Interop.SamplerCreateInfo* MarshalTo()
        {
            return (Interop.SamplerCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SemaphoreCreateInfo
	{

		public SemaphoreCreateFlags Flags
		{
			get;
			set;
		}

        internal unsafe Interop.SemaphoreCreateInfo Pack()
        {
            var result = new Interop.SemaphoreCreateInfo();
			result.SType = StructureType.SemaphoreCreateInfo;
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.SemaphoreCreateInfo* MarshalTo()
        {
            return (Interop.SemaphoreCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct ShaderModuleCreateInfo
	{

		public ShaderModuleCreateFlags Flags
		{
			get;
			set;
		}

		public UIntPtr CodeSize
		{
			get;
			set;
		}

		public uint[] Code
		{
			get;
			set;
		}

        internal unsafe Interop.ShaderModuleCreateInfo Pack()
        {
            var result = new Interop.ShaderModuleCreateInfo();
			result.SType = StructureType.ShaderModuleCreateInfo;
			result.Code = this.Code == null ? null : Interop.HeapUtil.MarshalTo(this.Code);
			result.Flags = this.Flags;
			result.CodeSize = this.CodeSize;

            return result;
        }

		internal unsafe Interop.ShaderModuleCreateInfo* MarshalTo()
        {
            return (Interop.ShaderModuleCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SparseBufferMemoryBindInfo
	{

		public Buffer Buffer
		{
			get;
			set;
		}

		public SparseMemoryBind[] Binds
		{
			get;
			set;
		}

        internal unsafe Interop.SparseBufferMemoryBindInfo Pack()
        {
            var result = new Interop.SparseBufferMemoryBindInfo();
			result.Buffer = this.Buffer?.Pack() ?? Interop.Buffer.Null;
			
			//Binds
			if (this.Binds != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.SparseMemoryBind>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.SparseMemoryBind>(this.Binds.Length);
			    for (int index = 0; index < this.Binds.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.Binds[index].Pack(), pointer + (size * index), false);
			    }
			    result.Binds = (Interop.SparseMemoryBind*)pointer.ToPointer();
			}
			else
			{
			    result.Binds = null;
			}
			result.BindCount = (uint)(this.Binds?.Length ?? 0);

            return result;
        }

		internal unsafe Interop.SparseBufferMemoryBindInfo* MarshalTo()
        {
            return (Interop.SparseBufferMemoryBindInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SparseImageMemoryBind
	{

		public ImageSubresource Subresource
		{
			get;
			set;
		}

		public Offset3D Offset
		{
			get;
			set;
		}

		public Extent3D Extent
		{
			get;
			set;
		}

		public DeviceMemory Memory
		{
			get;
			set;
		}

		public ulong MemoryOffset
		{
			get;
			set;
		}

		public SparseMemoryBindFlags Flags
		{
			get;
			set;
		}

        internal unsafe Interop.SparseImageMemoryBind Pack()
        {
            var result = new Interop.SparseImageMemoryBind();
			result.Memory = this.Memory?.Pack() ?? Interop.DeviceMemory.Null;
			result.Subresource = this.Subresource;
			result.Offset = this.Offset;
			result.Extent = this.Extent;
			result.MemoryOffset = this.MemoryOffset;
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.SparseImageMemoryBind* MarshalTo()
        {
            return (Interop.SparseImageMemoryBind*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SparseImageMemoryBindInfo
	{

		public Image Image
		{
			get;
			set;
		}

		public SparseImageMemoryBind[] Binds
		{
			get;
			set;
		}

        internal unsafe Interop.SparseImageMemoryBindInfo Pack()
        {
            var result = new Interop.SparseImageMemoryBindInfo();
			result.Image = this.Image?.Pack() ?? Interop.Image.Null;
			
			//Binds
			if (this.Binds != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.SparseImageMemoryBind>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.SparseImageMemoryBind>(this.Binds.Length);
			    for (int index = 0; index < this.Binds.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.Binds[index].Pack(), pointer + (size * index), false);
			    }
			    result.Binds = (Interop.SparseImageMemoryBind*)pointer.ToPointer();
			}
			else
			{
			    result.Binds = null;
			}
			result.BindCount = (uint)(this.Binds?.Length ?? 0);

            return result;
        }

		internal unsafe Interop.SparseImageMemoryBindInfo* MarshalTo()
        {
            return (Interop.SparseImageMemoryBindInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SparseImageOpaqueMemoryBindInfo
	{

		public Image Image
		{
			get;
			set;
		}

		public SparseMemoryBind[] Binds
		{
			get;
			set;
		}

        internal unsafe Interop.SparseImageOpaqueMemoryBindInfo Pack()
        {
            var result = new Interop.SparseImageOpaqueMemoryBindInfo();
			result.Image = this.Image?.Pack() ?? Interop.Image.Null;
			
			//Binds
			if (this.Binds != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.SparseMemoryBind>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.SparseMemoryBind>(this.Binds.Length);
			    for (int index = 0; index < this.Binds.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.Binds[index].Pack(), pointer + (size * index), false);
			    }
			    result.Binds = (Interop.SparseMemoryBind*)pointer.ToPointer();
			}
			else
			{
			    result.Binds = null;
			}
			result.BindCount = (uint)(this.Binds?.Length ?? 0);

            return result;
        }

		internal unsafe Interop.SparseImageOpaqueMemoryBindInfo* MarshalTo()
        {
            return (Interop.SparseImageOpaqueMemoryBindInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SparseMemoryBind
	{

		public ulong ResourceOffset
		{
			get;
			set;
		}

		public ulong Size
		{
			get;
			set;
		}

		public DeviceMemory Memory
		{
			get;
			set;
		}

		public ulong MemoryOffset
		{
			get;
			set;
		}

		public SparseMemoryBindFlags Flags
		{
			get;
			set;
		}

        internal unsafe Interop.SparseMemoryBind Pack()
        {
            var result = new Interop.SparseMemoryBind();
			result.Memory = this.Memory?.Pack() ?? Interop.DeviceMemory.Null;
			result.ResourceOffset = this.ResourceOffset;
			result.Size = this.Size;
			result.MemoryOffset = this.MemoryOffset;
			result.Flags = this.Flags;

            return result;
        }

		internal unsafe Interop.SparseMemoryBind* MarshalTo()
        {
            return (Interop.SparseMemoryBind*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SpecializationInfo
	{

		public SpecializationMapEntry[] MapEntries
		{
			get;
			set;
		}

		public byte[] Data
		{
			get;
			set;
		}

        internal unsafe Interop.SpecializationInfo Pack()
        {
            var result = new Interop.SpecializationInfo();
			
			//MapEntries
			if (this.MapEntries != null)
			{
			    result.MapEntries = (SpecializationMapEntry*)Interop.HeapUtil.Allocate<SpecializationMapEntry>(this.MapEntries.Length).ToPointer();
			    for (int index = 0; index < this.MapEntries.Length; index++)
			    {
			        result.MapEntries[index] = this.MapEntries[index];
			    }
			}
			else
			{
			    result.MapEntries = null;
			}
			result.Data = this.Data == null ? null : Interop.HeapUtil.MarshalTo(this.Data);
			result.MapEntryCount = (uint)(this.MapEntries?.Length ?? 0);
			result.DataSize = (UIntPtr)(this.Data?.Length ?? 0);

            return result;
        }

		internal unsafe Interop.SpecializationInfo* MarshalTo()
        {
            return (Interop.SpecializationInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SubmitInfo
	{

		public Semaphore[] WaitSemaphores
		{
			get;
			set;
		}

		public PipelineStageFlags[] WaitDestinationStageMask
		{
			get;
			set;
		}

		public CommandBuffer[] CommandBuffers
		{
			get;
			set;
		}

		public Semaphore[] SignalSemaphores
		{
			get;
			set;
		}

        internal unsafe Interop.SubmitInfo Pack()
        {
            var result = new Interop.SubmitInfo();
			result.SType = StructureType.SubmitInfo;
			
			//WaitSemaphores
			if (this.WaitSemaphores != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.Semaphore>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.Semaphore>(this.WaitSemaphores.Length);
			    for (int index = 0; index < this.WaitSemaphores.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.WaitSemaphores[index].Pack(), pointer + (size * index), false);
			    }
			    result.WaitSemaphores = (Interop.Semaphore*)pointer.ToPointer();
			}
			else
			{
			    result.WaitSemaphores = null;
			}
			
			//WaitDestinationStageMask
			if (this.WaitDestinationStageMask != null)
			{
			    result.WaitDestinationStageMask = (PipelineStageFlags*)Interop.HeapUtil.Allocate<int>(this.WaitDestinationStageMask.Length).ToPointer();
			    for (int index = 0; index < this.WaitDestinationStageMask.Length; index++)
			    {
			        result.WaitDestinationStageMask[index] = this.WaitDestinationStageMask[index];
			    }
			}
			else
			{
			    result.WaitDestinationStageMask = null;
			}
			
			//CommandBuffers
			if (this.CommandBuffers != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.CommandBuffer>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.CommandBuffer>(this.CommandBuffers.Length);
			    for (int index = 0; index < this.CommandBuffers.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.CommandBuffers[index].Pack(), pointer + (size * index), false);
			    }
			    result.CommandBuffers = (Interop.CommandBuffer*)pointer.ToPointer();
			}
			else
			{
			    result.CommandBuffers = null;
			}
			
			//SignalSemaphores
			if (this.SignalSemaphores != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.Semaphore>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.Semaphore>(this.SignalSemaphores.Length);
			    for (int index = 0; index < this.SignalSemaphores.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.SignalSemaphores[index].Pack(), pointer + (size * index), false);
			    }
			    result.SignalSemaphores = (Interop.Semaphore*)pointer.ToPointer();
			}
			else
			{
			    result.SignalSemaphores = null;
			}
			result.WaitSemaphoreCount = (uint)(this.WaitDestinationStageMask?.Length ?? 0);
			result.CommandBufferCount = (uint)(this.CommandBuffers?.Length ?? 0);
			result.SignalSemaphoreCount = (uint)(this.SignalSemaphores?.Length ?? 0);

            return result;
        }

		internal unsafe Interop.SubmitInfo* MarshalTo()
        {
            return (Interop.SubmitInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SubpassDescription
	{

		public SubpassDescriptionFlags Flags
		{
			get;
			set;
		}

		public PipelineBindPoint PipelineBindPoint
		{
			get;
			set;
		}

		public AttachmentReference[] InputAttachments
		{
			get;
			set;
		}

		public AttachmentReference[] ColorAttachments
		{
			get;
			set;
		}

		public AttachmentReference[] ResolveAttachments
		{
			get;
			set;
		}

		public AttachmentReference DepthStencilAttachment
		{
			get;
			set;
		}

		public uint[] PreserveAttachments
		{
			get;
			set;
		}

        internal unsafe Interop.SubpassDescription Pack()
        {
            var result = new Interop.SubpassDescription();
			
			//InputAttachments
			if (this.InputAttachments != null)
			{
			    result.InputAttachments = (AttachmentReference*)Interop.HeapUtil.Allocate<AttachmentReference>(this.InputAttachments.Length).ToPointer();
			    for (int index = 0; index < this.InputAttachments.Length; index++)
			    {
			        result.InputAttachments[index] = this.InputAttachments[index];
			    }
			}
			else
			{
			    result.InputAttachments = null;
			}
			
			//ColorAttachments
			if (this.ColorAttachments != null)
			{
			    result.ColorAttachments = (AttachmentReference*)Interop.HeapUtil.Allocate<AttachmentReference>(this.ColorAttachments.Length).ToPointer();
			    for (int index = 0; index < this.ColorAttachments.Length; index++)
			    {
			        result.ColorAttachments[index] = this.ColorAttachments[index];
			    }
			}
			else
			{
			    result.ColorAttachments = null;
			}
			
			//ResolveAttachments
			if (this.ResolveAttachments != null)
			{
			    result.ResolveAttachments = (AttachmentReference*)Interop.HeapUtil.Allocate<AttachmentReference>(this.ResolveAttachments.Length).ToPointer();
			    for (int index = 0; index < this.ResolveAttachments.Length; index++)
			    {
			        result.ResolveAttachments[index] = this.ResolveAttachments[index];
			    }
			}
			else
			{
			    result.ResolveAttachments = null;
			}
			result.DepthStencilAttachment = (AttachmentReference*)Interop.HeapUtil.AllocateAndMarshal(this.DepthStencilAttachment);
			result.PreserveAttachments = this.PreserveAttachments == null ? null : Interop.HeapUtil.MarshalTo(this.PreserveAttachments);
			result.InputAttachmentCount = (uint)(this.InputAttachments?.Length ?? 0);
			result.ColorAttachmentCount = (uint)(this.ColorAttachments?.Length ?? 0);
			result.PreserveAttachmentCount = (uint)(this.PreserveAttachments?.Length ?? 0);
			result.Flags = this.Flags;
			result.PipelineBindPoint = this.PipelineBindPoint;

            return result;
        }

		internal unsafe Interop.SubpassDescription* MarshalTo()
        {
            return (Interop.SubpassDescription*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct SwapchainCreateInfo
	{

		public SwapchainCreateFlags Flags
		{
			get;
			set;
		}

		public Surface Surface
		{
			get;
			set;
		}

		public uint MinImageCount
		{
			get;
			set;
		}

		public Format ImageFormat
		{
			get;
			set;
		}

		public ColorSpace ImageColorSpace
		{
			get;
			set;
		}

		public Extent2D ImageExtent
		{
			get;
			set;
		}

		public uint ImageArrayLayers
		{
			get;
			set;
		}

		public ImageUsageFlags ImageUsage
		{
			get;
			set;
		}

		public SharingMode ImageSharingMode
		{
			get;
			set;
		}

		public uint[] QueueFamilyIndices
		{
			get;
			set;
		}

		public SurfaceTransformFlags PreTransform
		{
			get;
			set;
		}

		public CompositeAlphaFlags CompositeAlpha
		{
			get;
			set;
		}

		public PresentMode PresentMode
		{
			get;
			set;
		}

		public Bool32 Clipped
		{
			get;
			set;
		}

		public Swapchain OldSwapchain
		{
			get;
			set;
		}

        internal unsafe Interop.SwapchainCreateInfo Pack()
        {
            var result = new Interop.SwapchainCreateInfo();
			result.SType = StructureType.SwapchainCreateInfo;
			result.Surface = this.Surface?.Pack() ?? Interop.Surface.Null;
			result.QueueFamilyIndices = this.QueueFamilyIndices == null ? null : Interop.HeapUtil.MarshalTo(this.QueueFamilyIndices);
			result.OldSwapchain = this.OldSwapchain?.Pack() ?? Interop.Swapchain.Null;
			result.QueueFamilyIndexCount = (uint)(this.QueueFamilyIndices?.Length ?? 0);
			result.Flags = this.Flags;
			result.MinImageCount = this.MinImageCount;
			result.ImageFormat = this.ImageFormat;
			result.ImageColorSpace = this.ImageColorSpace;
			result.ImageExtent = this.ImageExtent;
			result.ImageArrayLayers = this.ImageArrayLayers;
			result.ImageUsage = this.ImageUsage;
			result.ImageSharingMode = this.ImageSharingMode;
			result.PreTransform = this.PreTransform;
			result.CompositeAlpha = this.CompositeAlpha;
			result.PresentMode = this.PresentMode;
			result.Clipped = this.Clipped;

            return result;
        }

		internal unsafe Interop.SwapchainCreateInfo* MarshalTo()
        {
            return (Interop.SwapchainCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct WaylandSurfaceCreateInfo
	{

		public WaylandSurfaceCreateFlags Flags
		{
			get;
			set;
		}

		public IntPtr Display
		{
			get;
			set;
		}

		public IntPtr Surface
		{
			get;
			set;
		}

        internal unsafe Interop.WaylandSurfaceCreateInfo Pack()
        {
            var result = new Interop.WaylandSurfaceCreateInfo();
			result.SType = StructureType.WaylandSurfaceCreateInfo;
			result.Flags = this.Flags;
			result.Display = this.Display;
			result.Surface = this.Surface;

            return result;
        }

		internal unsafe Interop.WaylandSurfaceCreateInfo* MarshalTo()
        {
            return (Interop.WaylandSurfaceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct Win32SurfaceCreateInfo
	{

		public Win32SurfaceCreateFlags Flags
		{
			get;
			set;
		}

		public IntPtr Hinstance
		{
			get;
			set;
		}

		public IntPtr Hwnd
		{
			get;
			set;
		}

        internal unsafe Interop.Win32SurfaceCreateInfo Pack()
        {
            var result = new Interop.Win32SurfaceCreateInfo();
			result.SType = StructureType.Win32SurfaceCreateInfo;
			result.Flags = this.Flags;
			result.Hinstance = this.Hinstance;
			result.Hwnd = this.Hwnd;

            return result;
        }

		internal unsafe Interop.Win32SurfaceCreateInfo* MarshalTo()
        {
            return (Interop.Win32SurfaceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct WriteDescriptorSet
	{

		public DescriptorSet DestinationSet
		{
			get;
			set;
		}

		public uint DestinationBinding
		{
			get;
			set;
		}

		public uint DestinationArrayElement
		{
			get;
			set;
		}

		public DescriptorType DescriptorType
		{
			get;
			set;
		}

		public DescriptorImageInfo[] ImageInfo
		{
			get;
			set;
		}

		public DescriptorBufferInfo[] BufferInfo
		{
			get;
			set;
		}

		public BufferView[] TexelBufferView
		{
			get;
			set;
		}

        internal unsafe Interop.WriteDescriptorSet Pack()
        {
            var result = new Interop.WriteDescriptorSet();
			result.SType = StructureType.WriteDescriptorSet;
			result.DestinationSet = this.DestinationSet?.Pack() ?? Interop.DescriptorSet.Null;
			
			//ImageInfo
			if (this.ImageInfo != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.DescriptorImageInfo>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.DescriptorImageInfo>(this.ImageInfo.Length);
			    for (int index = 0; index < this.ImageInfo.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.ImageInfo[index].Pack(), pointer + (size * index), false);
			    }
			    result.ImageInfo = (Interop.DescriptorImageInfo*)pointer.ToPointer();
			}
			else
			{
			    result.ImageInfo = null;
			}
			
			//BufferInfo
			if (this.BufferInfo != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.DescriptorBufferInfo>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.DescriptorBufferInfo>(this.BufferInfo.Length);
			    for (int index = 0; index < this.BufferInfo.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.BufferInfo[index].Pack(), pointer + (size * index), false);
			    }
			    result.BufferInfo = (Interop.DescriptorBufferInfo*)pointer.ToPointer();
			}
			else
			{
			    result.BufferInfo = null;
			}
			
			//TexelBufferView
			if (this.TexelBufferView != null)
			{
			    int size = System.Runtime.InteropServices.Marshal.SizeOf<Interop.BufferView>();
			    IntPtr pointer = Interop.HeapUtil.Allocate<Interop.BufferView>(this.TexelBufferView.Length);
			    for (int index = 0; index < this.TexelBufferView.Length; index++)
			    {
			        System.Runtime.InteropServices.Marshal.StructureToPtr(this.TexelBufferView[index].Pack(), pointer + (size * index), false);
			    }
			    result.TexelBufferView = (Interop.BufferView*)pointer.ToPointer();
			}
			else
			{
			    result.TexelBufferView = null;
			}
			result.DescriptorCount = (uint)(this.TexelBufferView?.Length ?? 0);
			result.DestinationBinding = this.DestinationBinding;
			result.DestinationArrayElement = this.DestinationArrayElement;
			result.DescriptorType = this.DescriptorType;

            return result;
        }

		internal unsafe Interop.WriteDescriptorSet* MarshalTo()
        {
            return (Interop.WriteDescriptorSet*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct XcbSurfaceCreateInfo
	{

		public XcbSurfaceCreateFlags Flags
		{
			get;
			set;
		}

		public IntPtr Connection
		{
			get;
			set;
		}

		public IntPtr Window
		{
			get;
			set;
		}

        internal unsafe Interop.XcbSurfaceCreateInfo Pack()
        {
            var result = new Interop.XcbSurfaceCreateInfo();
			result.SType = StructureType.XcbSurfaceCreateInfo;
			result.Connection = (IntPtr*)Interop.HeapUtil.AllocateAndMarshal(this.Connection);
			result.Flags = this.Flags;
			result.Window = this.Window;

            return result;
        }

		internal unsafe Interop.XcbSurfaceCreateInfo* MarshalTo()
        {
            return (Interop.XcbSurfaceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}

	public struct XlibSurfaceCreateInfo
	{

		public XlibSurfaceCreateFlags Flags
		{
			get;
			set;
		}

		public IntPtr Dpy
		{
			get;
			set;
		}

		public IntPtr Window
		{
			get;
			set;
		}

        internal unsafe Interop.XlibSurfaceCreateInfo Pack()
        {
            var result = new Interop.XlibSurfaceCreateInfo();
			result.SType = StructureType.XlibSurfaceCreateInfo;
			result.Dpy = (IntPtr*)Interop.HeapUtil.AllocateAndMarshal(this.Dpy);
			result.Flags = this.Flags;
			result.Window = this.Window;

            return result;
        }

		internal unsafe Interop.XlibSurfaceCreateInfo* MarshalTo()
        {
            return (Interop.XlibSurfaceCreateInfo*)Interop.HeapUtil.AllocateAndMarshal(this.Pack()).ToPointer();
		}
	}
}