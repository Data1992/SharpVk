// The MIT License (MIT)
// 
// Copyright (c) Andrew Armstrong/FacticiusVir 2018
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
    /// Opaque handle to a physical device object.
    /// </summary>
    public partial class PhysicalDevice
    {
        internal readonly SharpVk.Interop.PhysicalDevice handle; 
        
        internal readonly CommandCache commandCache; 
        
        internal readonly SharpVk.Instance parent; 
        
        internal PhysicalDevice(SharpVk.Instance parent, SharpVk.Interop.PhysicalDevice handle)
        {
            this.handle = handle;
            this.parent = parent;
            this.commandCache = parent.commandCache;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.Interop.PhysicalDevice RawHandle => this.handle;
        
        /// <summary>
        /// Reports capabilities of a physical device.
        /// </summary>
        public unsafe SharpVk.PhysicalDeviceFeatures GetFeatures()
        {
            try
            {
                SharpVk.PhysicalDeviceFeatures result = default(SharpVk.PhysicalDeviceFeatures);
                SharpVk.Interop.PhysicalDeviceFeatures marshalledFeatures = default(SharpVk.Interop.PhysicalDeviceFeatures);
                SharpVk.Interop.VkPhysicalDeviceGetFeaturesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetFeaturesDelegate>("vkGetPhysicalDeviceFeatures", "");
                commandDelegate(this.handle, &marshalledFeatures);
                result = SharpVk.PhysicalDeviceFeatures.MarshalFrom(&marshalledFeatures);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Lists physical device's format capabilities.
        /// </summary>
        public unsafe SharpVk.FormatProperties GetFormatProperties(SharpVk.Format format)
        {
            try
            {
                SharpVk.FormatProperties result = default(SharpVk.FormatProperties);
                SharpVk.FormatProperties marshalledFormatProperties = default(SharpVk.FormatProperties);
                SharpVk.Interop.VkPhysicalDeviceGetFormatPropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetFormatPropertiesDelegate>("vkGetPhysicalDeviceFormatProperties", "");
                commandDelegate(this.handle, format, &marshalledFormatProperties);
                result = marshalledFormatProperties;
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Lists physical device's image format capabilities.
        /// </summary>
        public unsafe SharpVk.ImageFormatProperties GetImageFormatProperties(SharpVk.Format format, SharpVk.ImageType type, SharpVk.ImageTiling tiling, SharpVk.ImageUsageFlags usage, SharpVk.ImageCreateFlags? flags = default(SharpVk.ImageCreateFlags?))
        {
            try
            {
                SharpVk.ImageFormatProperties result = default(SharpVk.ImageFormatProperties);
                SharpVk.ImageCreateFlags marshalledFlags = default(SharpVk.ImageCreateFlags);
                SharpVk.ImageFormatProperties marshalledImageFormatProperties = default(SharpVk.ImageFormatProperties);
                if (flags != null)
                {
                    marshalledFlags = flags.Value;
                }
                else
                {
                    marshalledFlags = default(SharpVk.ImageCreateFlags);
                }
                SharpVk.Interop.VkPhysicalDeviceGetImageFormatPropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetImageFormatPropertiesDelegate>("vkGetPhysicalDeviceImageFormatProperties", "");
                Result methodResult = commandDelegate(this.handle, format, type, tiling, usage, marshalledFlags, &marshalledImageFormatProperties);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = marshalledImageFormatProperties;
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Returns properties of a physical device.
        /// </summary>
        public unsafe SharpVk.PhysicalDeviceProperties GetProperties()
        {
            try
            {
                SharpVk.PhysicalDeviceProperties result = default(SharpVk.PhysicalDeviceProperties);
                SharpVk.Interop.PhysicalDeviceProperties marshalledProperties = default(SharpVk.Interop.PhysicalDeviceProperties);
                SharpVk.Interop.VkPhysicalDeviceGetPropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetPropertiesDelegate>("vkGetPhysicalDeviceProperties", "");
                commandDelegate(this.handle, &marshalledProperties);
                result = SharpVk.PhysicalDeviceProperties.MarshalFrom(&marshalledProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Reports properties of the queues of the specified physical device.
        /// </summary>
        public unsafe SharpVk.QueueFamilyProperties[] GetQueueFamilyProperties()
        {
            try
            {
                SharpVk.QueueFamilyProperties[] result = default(SharpVk.QueueFamilyProperties[]);
                uint queueFamilyPropertyCount = default(uint);
                SharpVk.QueueFamilyProperties* marshalledQueueFamilyProperties = default(SharpVk.QueueFamilyProperties*);
                SharpVk.Interop.VkPhysicalDeviceGetQueueFamilyPropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetQueueFamilyPropertiesDelegate>("vkGetPhysicalDeviceQueueFamilyProperties", "");
                commandDelegate(this.handle, &queueFamilyPropertyCount, marshalledQueueFamilyProperties);
                marshalledQueueFamilyProperties = (SharpVk.QueueFamilyProperties*)(Interop.HeapUtil.Allocate<SharpVk.QueueFamilyProperties>((uint)(queueFamilyPropertyCount)));
                commandDelegate(this.handle, &queueFamilyPropertyCount, marshalledQueueFamilyProperties);
                if (marshalledQueueFamilyProperties != null)
                {
                    var fieldPointer = new SharpVk.QueueFamilyProperties[(uint)(queueFamilyPropertyCount)];
                    for(int index = 0; index < (uint)(queueFamilyPropertyCount); index++)
                    {
                        fieldPointer[index] = marshalledQueueFamilyProperties[index];
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Reports memory information for the specified physical device.
        /// </summary>
        public unsafe SharpVk.PhysicalDeviceMemoryProperties GetMemoryProperties()
        {
            try
            {
                SharpVk.PhysicalDeviceMemoryProperties result = default(SharpVk.PhysicalDeviceMemoryProperties);
                SharpVk.Interop.PhysicalDeviceMemoryProperties marshalledMemoryProperties = default(SharpVk.Interop.PhysicalDeviceMemoryProperties);
                SharpVk.Interop.VkPhysicalDeviceGetMemoryPropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetMemoryPropertiesDelegate>("vkGetPhysicalDeviceMemoryProperties", "");
                commandDelegate(this.handle, &marshalledMemoryProperties);
                result = SharpVk.PhysicalDeviceMemoryProperties.MarshalFrom(&marshalledMemoryProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Create a new device instance.
        /// </summary>
        /// <param name="flags">
        /// Reserved for future use.
        /// </param>
        /// <param name="queueCreateInfos">
        /// </param>
        /// <param name="enabledLayerNames">
        /// ppEnabledLayerNames is deprecated and ignored.
        /// </param>
        /// <param name="enabledExtensionNames">
        /// An array of enabledExtensionCount strings containing the names of
        /// extensions to enable for the created device.
        /// </param>
        /// <param name="enabledFeatures">
        /// Null or a PhysicalDeviceFeatures structure that contains boolean
        /// indicators of all the features to be enabled.
        /// </param>
        /// <param name="physicalDeviceFeatures2">
        /// Extension struct
        /// </param>
        /// <param name="deviceGroupDeviceCreateInfo">
        /// Extension struct
        /// </param>
        /// <param name="deviceMemoryOverallocationCreateInfoAmd">
        /// Extension struct
        /// </param>
        /// <param name="allocator">
        /// An optional AllocationCallbacks instance that controls host memory
        /// allocation.
        /// </param>
        public unsafe SharpVk.Device CreateDevice(ArrayProxy<SharpVk.DeviceQueueCreateInfo>? queueCreateInfos, ArrayProxy<string>? enabledLayerNames, ArrayProxy<string>? enabledExtensionNames, SharpVk.DeviceCreateFlags? flags = default(SharpVk.DeviceCreateFlags?), SharpVk.PhysicalDeviceFeatures? enabledFeatures = default(SharpVk.PhysicalDeviceFeatures?), SharpVk.PhysicalDeviceFeatures2? physicalDeviceFeatures2 = null, SharpVk.DeviceGroupDeviceCreateInfo? deviceGroupDeviceCreateInfo = null, SharpVk.Amd.DeviceMemoryOverallocationCreateInfo? deviceMemoryOverallocationCreateInfoAmd = null, SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Device result = default(SharpVk.Device);
                SharpVk.Interop.DeviceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.DeviceCreateInfo*);
                void* nextPointer = default(void*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Device marshalledDevice = default(SharpVk.Interop.Device);
                if (physicalDeviceFeatures2 != null)
                {
                    SharpVk.Interop.PhysicalDeviceFeatures2* extensionPointer = default(SharpVk.Interop.PhysicalDeviceFeatures2*);
                    extensionPointer = (SharpVk.Interop.PhysicalDeviceFeatures2*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PhysicalDeviceFeatures2>());
                    physicalDeviceFeatures2.Value.MarshalTo(extensionPointer);
                    extensionPointer->Next = nextPointer;
                    nextPointer = extensionPointer;
                }
                if (deviceGroupDeviceCreateInfo != null)
                {
                    SharpVk.Interop.DeviceGroupDeviceCreateInfo* extensionPointer = default(SharpVk.Interop.DeviceGroupDeviceCreateInfo*);
                    extensionPointer = (SharpVk.Interop.DeviceGroupDeviceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DeviceGroupDeviceCreateInfo>());
                    deviceGroupDeviceCreateInfo.Value.MarshalTo(extensionPointer);
                    extensionPointer->Next = nextPointer;
                    nextPointer = extensionPointer;
                }
                if (deviceMemoryOverallocationCreateInfoAmd != null)
                {
                    SharpVk.Interop.Amd.DeviceMemoryOverallocationCreateInfo* extensionPointer = default(SharpVk.Interop.Amd.DeviceMemoryOverallocationCreateInfo*);
                    extensionPointer = (SharpVk.Interop.Amd.DeviceMemoryOverallocationCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Amd.DeviceMemoryOverallocationCreateInfo>());
                    deviceMemoryOverallocationCreateInfoAmd.Value.MarshalTo(extensionPointer);
                    extensionPointer->Next = nextPointer;
                    nextPointer = extensionPointer;
                }
                marshalledCreateInfo = (SharpVk.Interop.DeviceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DeviceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.DeviceCreateInfo;
                marshalledCreateInfo->Next = nextPointer;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.DeviceCreateFlags);
                }
                marshalledCreateInfo->QueueCreateInfoCount = (uint)(Interop.HeapUtil.GetLength(queueCreateInfos));
                if (queueCreateInfos.IsNull())
                {
                    marshalledCreateInfo->QueueCreateInfos = null;
                }
                else
                {
                    if (queueCreateInfos.Value.Contents == ProxyContents.Single)
                    {
                        marshalledCreateInfo->QueueCreateInfos = (SharpVk.Interop.DeviceQueueCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.DeviceQueueCreateInfo>());
                        queueCreateInfos.Value.GetSingleValue().MarshalTo(&*(SharpVk.Interop.DeviceQueueCreateInfo*)(marshalledCreateInfo->QueueCreateInfos));
                    }
                    else
                    {
                        var fieldPointer = (SharpVk.Interop.DeviceQueueCreateInfo*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.DeviceQueueCreateInfo>(Interop.HeapUtil.GetLength(queueCreateInfos.Value)).ToPointer());
                        for(int index = 0; index < (uint)(Interop.HeapUtil.GetLength(queueCreateInfos.Value)); index++)
                        {
                            queueCreateInfos.Value[index].MarshalTo(&fieldPointer[index]);
                        }
                        marshalledCreateInfo->QueueCreateInfos = fieldPointer;
                    }
                }
                marshalledCreateInfo->EnabledLayerCount = (uint)(Interop.HeapUtil.GetLength(enabledLayerNames));
                marshalledCreateInfo->EnabledLayerNames = Interop.HeapUtil.MarshalTo(enabledLayerNames);
                marshalledCreateInfo->EnabledExtensionCount = (uint)(Interop.HeapUtil.GetLength(enabledExtensionNames));
                marshalledCreateInfo->EnabledExtensionNames = Interop.HeapUtil.MarshalTo(enabledExtensionNames);
                if (enabledFeatures != null)
                {
                    marshalledCreateInfo->EnabledFeatures = (SharpVk.Interop.PhysicalDeviceFeatures*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PhysicalDeviceFeatures>());
                    enabledFeatures.Value.MarshalTo(marshalledCreateInfo->EnabledFeatures);
                }
                else
                {
                    marshalledCreateInfo->EnabledFeatures = default(SharpVk.Interop.PhysicalDeviceFeatures*);
                }
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                SharpVk.Interop.VkPhysicalDeviceCreateDeviceDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceCreateDeviceDelegate>("vkCreateDevice", "");
                Result methodResult = commandDelegate(this.handle, marshalledCreateInfo, marshalledAllocator, &marshalledDevice);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Device(this, marshalledDevice);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Returns properties of available physical device extensions.
        /// </summary>
        public unsafe SharpVk.ExtensionProperties[] EnumerateDeviceExtensionProperties(string layerName)
        {
            try
            {
                SharpVk.ExtensionProperties[] result = default(SharpVk.ExtensionProperties[]);
                uint propertyCount = default(uint);
                SharpVk.Interop.ExtensionProperties* marshalledProperties = default(SharpVk.Interop.ExtensionProperties*);
                SharpVk.Interop.VkPhysicalDeviceEnumerateDeviceExtensionPropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceEnumerateDeviceExtensionPropertiesDelegate>("vkEnumerateDeviceExtensionProperties", "");
                Result methodResult = commandDelegate(this.handle, Interop.HeapUtil.MarshalTo(layerName), &propertyCount, marshalledProperties);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                marshalledProperties = (SharpVk.Interop.ExtensionProperties*)(Interop.HeapUtil.Allocate<SharpVk.Interop.ExtensionProperties>((uint)(propertyCount)));
                commandDelegate(this.handle, Interop.HeapUtil.MarshalTo(layerName), &propertyCount, marshalledProperties);
                if (marshalledProperties != null)
                {
                    var fieldPointer = new SharpVk.ExtensionProperties[(uint)(propertyCount)];
                    for(int index = 0; index < (uint)(propertyCount); index++)
                    {
                        fieldPointer[index] = SharpVk.ExtensionProperties.MarshalFrom(&marshalledProperties[index]);
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Returns properties of available physical device layers.
        /// </summary>
        public unsafe SharpVk.LayerProperties[] EnumerateDeviceLayerProperties()
        {
            try
            {
                SharpVk.LayerProperties[] result = default(SharpVk.LayerProperties[]);
                uint propertyCount = default(uint);
                SharpVk.Interop.LayerProperties* marshalledProperties = default(SharpVk.Interop.LayerProperties*);
                SharpVk.Interop.VkPhysicalDeviceEnumerateDeviceLayerPropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceEnumerateDeviceLayerPropertiesDelegate>("vkEnumerateDeviceLayerProperties", "");
                Result methodResult = commandDelegate(this.handle, &propertyCount, marshalledProperties);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                marshalledProperties = (SharpVk.Interop.LayerProperties*)(Interop.HeapUtil.Allocate<SharpVk.Interop.LayerProperties>((uint)(propertyCount)));
                commandDelegate(this.handle, &propertyCount, marshalledProperties);
                if (marshalledProperties != null)
                {
                    var fieldPointer = new SharpVk.LayerProperties[(uint)(propertyCount)];
                    for(int index = 0; index < (uint)(propertyCount); index++)
                    {
                        fieldPointer[index] = SharpVk.LayerProperties.MarshalFrom(&marshalledProperties[index]);
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// Retrieve properties of an image format applied to sparse images.
        /// </summary>
        public unsafe SharpVk.SparseImageFormatProperties[] GetSparseImageFormatProperties(SharpVk.Format format, SharpVk.ImageType type, SharpVk.SampleCountFlags samples, SharpVk.ImageUsageFlags usage, SharpVk.ImageTiling tiling)
        {
            try
            {
                SharpVk.SparseImageFormatProperties[] result = default(SharpVk.SparseImageFormatProperties[]);
                uint propertyCount = default(uint);
                SharpVk.SparseImageFormatProperties* marshalledProperties = default(SharpVk.SparseImageFormatProperties*);
                SharpVk.Interop.VkPhysicalDeviceGetSparseImageFormatPropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetSparseImageFormatPropertiesDelegate>("vkGetPhysicalDeviceSparseImageFormatProperties", "");
                commandDelegate(this.handle, format, type, samples, usage, tiling, &propertyCount, marshalledProperties);
                marshalledProperties = (SharpVk.SparseImageFormatProperties*)(Interop.HeapUtil.Allocate<SharpVk.SparseImageFormatProperties>((uint)(propertyCount)));
                commandDelegate(this.handle, format, type, samples, usage, tiling, &propertyCount, marshalledProperties);
                if (marshalledProperties != null)
                {
                    var fieldPointer = new SharpVk.SparseImageFormatProperties[(uint)(propertyCount)];
                    for(int index = 0; index < (uint)(propertyCount); index++)
                    {
                        fieldPointer[index] = marshalledProperties[index];
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.PhysicalDeviceFeatures2 GetFeatures2()
        {
            try
            {
                SharpVk.PhysicalDeviceFeatures2 result = default(SharpVk.PhysicalDeviceFeatures2);
                SharpVk.Interop.PhysicalDeviceFeatures2 marshalledFeatures = default(SharpVk.Interop.PhysicalDeviceFeatures2);
                SharpVk.Interop.VkPhysicalDeviceGetFeatures2Delegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetFeatures2Delegate>("vkGetPhysicalDeviceFeatures2", "");
                commandDelegate(this.handle, &marshalledFeatures);
                result = SharpVk.PhysicalDeviceFeatures2.MarshalFrom(&marshalledFeatures);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.PhysicalDeviceProperties2 GetProperties2()
        {
            try
            {
                SharpVk.PhysicalDeviceProperties2 result = default(SharpVk.PhysicalDeviceProperties2);
                SharpVk.Interop.PhysicalDeviceProperties2 marshalledProperties = default(SharpVk.Interop.PhysicalDeviceProperties2);
                SharpVk.Interop.VkPhysicalDeviceGetProperties2Delegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetProperties2Delegate>("vkGetPhysicalDeviceProperties2", "");
                commandDelegate(this.handle, &marshalledProperties);
                result = SharpVk.PhysicalDeviceProperties2.MarshalFrom(&marshalledProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.FormatProperties2 GetFormatProperties2(SharpVk.Format format)
        {
            try
            {
                SharpVk.FormatProperties2 result = default(SharpVk.FormatProperties2);
                SharpVk.Interop.FormatProperties2 marshalledFormatProperties = default(SharpVk.Interop.FormatProperties2);
                SharpVk.Interop.VkPhysicalDeviceGetFormatProperties2Delegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetFormatProperties2Delegate>("vkGetPhysicalDeviceFormatProperties2", "");
                commandDelegate(this.handle, format, &marshalledFormatProperties);
                result = SharpVk.FormatProperties2.MarshalFrom(&marshalledFormatProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.ImageFormatProperties2 GetImageFormatProperties2(SharpVk.PhysicalDeviceImageFormatInfo2 imageFormatInfo)
        {
            try
            {
                SharpVk.ImageFormatProperties2 result = default(SharpVk.ImageFormatProperties2);
                SharpVk.Interop.PhysicalDeviceImageFormatInfo2* marshalledImageFormatInfo = default(SharpVk.Interop.PhysicalDeviceImageFormatInfo2*);
                SharpVk.Interop.ImageFormatProperties2 marshalledImageFormatProperties = default(SharpVk.Interop.ImageFormatProperties2);
                marshalledImageFormatInfo = (SharpVk.Interop.PhysicalDeviceImageFormatInfo2*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PhysicalDeviceImageFormatInfo2>());
                imageFormatInfo.MarshalTo(marshalledImageFormatInfo);
                SharpVk.Interop.VkPhysicalDeviceGetImageFormatProperties2Delegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetImageFormatProperties2Delegate>("vkGetPhysicalDeviceImageFormatProperties2", "");
                Result methodResult = commandDelegate(this.handle, marshalledImageFormatInfo, &marshalledImageFormatProperties);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = SharpVk.ImageFormatProperties2.MarshalFrom(&marshalledImageFormatProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.QueueFamilyProperties2[] GetQueueFamilyProperties2()
        {
            try
            {
                SharpVk.QueueFamilyProperties2[] result = default(SharpVk.QueueFamilyProperties2[]);
                uint queueFamilyPropertyCount = default(uint);
                SharpVk.Interop.QueueFamilyProperties2* marshalledQueueFamilyProperties = default(SharpVk.Interop.QueueFamilyProperties2*);
                SharpVk.Interop.VkPhysicalDeviceGetQueueFamilyProperties2Delegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetQueueFamilyProperties2Delegate>("vkGetPhysicalDeviceQueueFamilyProperties2", "");
                commandDelegate(this.handle, &queueFamilyPropertyCount, marshalledQueueFamilyProperties);
                marshalledQueueFamilyProperties = (SharpVk.Interop.QueueFamilyProperties2*)(Interop.HeapUtil.Allocate<SharpVk.Interop.QueueFamilyProperties2>((uint)(queueFamilyPropertyCount)));
                commandDelegate(this.handle, &queueFamilyPropertyCount, marshalledQueueFamilyProperties);
                if (marshalledQueueFamilyProperties != null)
                {
                    var fieldPointer = new SharpVk.QueueFamilyProperties2[(uint)(queueFamilyPropertyCount)];
                    for(int index = 0; index < (uint)(queueFamilyPropertyCount); index++)
                    {
                        fieldPointer[index] = SharpVk.QueueFamilyProperties2.MarshalFrom(&marshalledQueueFamilyProperties[index]);
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.PhysicalDeviceMemoryProperties2 GetMemoryProperties2()
        {
            try
            {
                SharpVk.PhysicalDeviceMemoryProperties2 result = default(SharpVk.PhysicalDeviceMemoryProperties2);
                SharpVk.Interop.PhysicalDeviceMemoryProperties2 marshalledMemoryProperties = default(SharpVk.Interop.PhysicalDeviceMemoryProperties2);
                SharpVk.Interop.VkPhysicalDeviceGetMemoryProperties2Delegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetMemoryProperties2Delegate>("vkGetPhysicalDeviceMemoryProperties2", "");
                commandDelegate(this.handle, &marshalledMemoryProperties);
                result = SharpVk.PhysicalDeviceMemoryProperties2.MarshalFrom(&marshalledMemoryProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.SparseImageFormatProperties2[] GetSparseImageFormatProperties2(SharpVk.PhysicalDeviceSparseImageFormatInfo2 formatInfo)
        {
            try
            {
                SharpVk.SparseImageFormatProperties2[] result = default(SharpVk.SparseImageFormatProperties2[]);
                uint propertyCount = default(uint);
                SharpVk.Interop.PhysicalDeviceSparseImageFormatInfo2* marshalledFormatInfo = default(SharpVk.Interop.PhysicalDeviceSparseImageFormatInfo2*);
                SharpVk.Interop.SparseImageFormatProperties2* marshalledProperties = default(SharpVk.Interop.SparseImageFormatProperties2*);
                marshalledFormatInfo = (SharpVk.Interop.PhysicalDeviceSparseImageFormatInfo2*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PhysicalDeviceSparseImageFormatInfo2>());
                formatInfo.MarshalTo(marshalledFormatInfo);
                SharpVk.Interop.VkPhysicalDeviceGetSparseImageFormatProperties2Delegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetSparseImageFormatProperties2Delegate>("vkGetPhysicalDeviceSparseImageFormatProperties2", "");
                commandDelegate(this.handle, marshalledFormatInfo, &propertyCount, marshalledProperties);
                marshalledProperties = (SharpVk.Interop.SparseImageFormatProperties2*)(Interop.HeapUtil.Allocate<SharpVk.Interop.SparseImageFormatProperties2>((uint)(propertyCount)));
                commandDelegate(this.handle, marshalledFormatInfo, &propertyCount, marshalledProperties);
                if (marshalledProperties != null)
                {
                    var fieldPointer = new SharpVk.SparseImageFormatProperties2[(uint)(propertyCount)];
                    for(int index = 0; index < (uint)(propertyCount); index++)
                    {
                        fieldPointer[index] = SharpVk.SparseImageFormatProperties2.MarshalFrom(&marshalledProperties[index]);
                    }
                    result = fieldPointer;
                }
                else
                {
                    result = null;
                }
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.ExternalBufferProperties GetExternalBufferProperties(SharpVk.PhysicalDeviceExternalBufferInfo externalBufferInfo)
        {
            try
            {
                SharpVk.ExternalBufferProperties result = default(SharpVk.ExternalBufferProperties);
                SharpVk.Interop.PhysicalDeviceExternalBufferInfo* marshalledExternalBufferInfo = default(SharpVk.Interop.PhysicalDeviceExternalBufferInfo*);
                SharpVk.Interop.ExternalBufferProperties marshalledExternalBufferProperties = default(SharpVk.Interop.ExternalBufferProperties);
                marshalledExternalBufferInfo = (SharpVk.Interop.PhysicalDeviceExternalBufferInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PhysicalDeviceExternalBufferInfo>());
                externalBufferInfo.MarshalTo(marshalledExternalBufferInfo);
                SharpVk.Interop.VkPhysicalDeviceGetExternalBufferPropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetExternalBufferPropertiesDelegate>("vkGetPhysicalDeviceExternalBufferProperties", "");
                commandDelegate(this.handle, marshalledExternalBufferInfo, &marshalledExternalBufferProperties);
                result = SharpVk.ExternalBufferProperties.MarshalFrom(&marshalledExternalBufferProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.ExternalFenceProperties GetExternalFenceProperties(SharpVk.PhysicalDeviceExternalFenceInfo externalFenceInfo)
        {
            try
            {
                SharpVk.ExternalFenceProperties result = default(SharpVk.ExternalFenceProperties);
                SharpVk.Interop.PhysicalDeviceExternalFenceInfo* marshalledExternalFenceInfo = default(SharpVk.Interop.PhysicalDeviceExternalFenceInfo*);
                SharpVk.Interop.ExternalFenceProperties marshalledExternalFenceProperties = default(SharpVk.Interop.ExternalFenceProperties);
                marshalledExternalFenceInfo = (SharpVk.Interop.PhysicalDeviceExternalFenceInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PhysicalDeviceExternalFenceInfo>());
                externalFenceInfo.MarshalTo(marshalledExternalFenceInfo);
                SharpVk.Interop.VkPhysicalDeviceGetExternalFencePropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetExternalFencePropertiesDelegate>("vkGetPhysicalDeviceExternalFenceProperties", "");
                commandDelegate(this.handle, marshalledExternalFenceInfo, &marshalledExternalFenceProperties);
                result = SharpVk.ExternalFenceProperties.MarshalFrom(&marshalledExternalFenceProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public unsafe SharpVk.ExternalSemaphoreProperties GetExternalSemaphoreProperties(SharpVk.PhysicalDeviceExternalSemaphoreInfo externalSemaphoreInfo)
        {
            try
            {
                SharpVk.ExternalSemaphoreProperties result = default(SharpVk.ExternalSemaphoreProperties);
                SharpVk.Interop.PhysicalDeviceExternalSemaphoreInfo* marshalledExternalSemaphoreInfo = default(SharpVk.Interop.PhysicalDeviceExternalSemaphoreInfo*);
                SharpVk.Interop.ExternalSemaphoreProperties marshalledExternalSemaphoreProperties = default(SharpVk.Interop.ExternalSemaphoreProperties);
                marshalledExternalSemaphoreInfo = (SharpVk.Interop.PhysicalDeviceExternalSemaphoreInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.PhysicalDeviceExternalSemaphoreInfo>());
                externalSemaphoreInfo.MarshalTo(marshalledExternalSemaphoreInfo);
                SharpVk.Interop.VkPhysicalDeviceGetExternalSemaphorePropertiesDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.VkPhysicalDeviceGetExternalSemaphorePropertiesDelegate>("vkGetPhysicalDeviceExternalSemaphoreProperties", "");
                commandDelegate(this.handle, marshalledExternalSemaphoreInfo, &marshalledExternalSemaphoreProperties);
                result = SharpVk.ExternalSemaphoreProperties.MarshalFrom(&marshalledExternalSemaphoreProperties);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
    }
}
