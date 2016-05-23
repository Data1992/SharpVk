﻿//The MIT License (MIT)
//
//Copyright (c) 2016 Andrew Armstrong/FacticiusVir
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
using System.Runtime.InteropServices;

namespace SharpVk.Interop
{
	public static unsafe class Commands
	{
		public const string VulkanDll = "vulkan-1.dll";

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkCreateInstance(InstanceCreateInfo* createInfo, AllocationCallbacks* allocator, Instance* instance);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkDestroyInstance(Instance instance, AllocationCallbacks* allocator);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkEnumeratePhysicalDevices(Instance instance, uint* physicalDeviceCount, PhysicalDevice* physicalDevices);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkGetPhysicalDeviceFeatures(PhysicalDevice physicalDevice, PhysicalDeviceFeatures* features);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkGetPhysicalDeviceFormatProperties(PhysicalDevice physicalDevice, Format format, FormatProperties* formatProperties);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkGetPhysicalDeviceImageFormatProperties(PhysicalDevice physicalDevice, Format format, ImageType type, ImageTiling tiling, ImageUsageFlags usage, ImageCreateFlags flags, ImageFormatProperties* imageFormatProperties);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkGetPhysicalDeviceProperties(PhysicalDevice physicalDevice, PhysicalDeviceProperties* properties);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkGetPhysicalDeviceQueueFamilyProperties(PhysicalDevice physicalDevice, uint* queueFamilyPropertyCount, QueueFamilyProperties* queueFamilyProperties);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkGetPhysicalDeviceMemoryProperties(PhysicalDevice physicalDevice, PhysicalDeviceMemoryProperties* memoryProperties);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern IntPtr vkGetInstanceProcAddr(Instance instance, char* name);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern IntPtr vkGetDeviceProcAddr(Device device, char* name);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkCreateDevice(PhysicalDevice physicalDevice, DeviceCreateInfo* createInfo, AllocationCallbacks* allocator, Device* device);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkDestroyDevice(Device device, AllocationCallbacks* allocator);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkEnumerateInstanceExtensionProperties(char* layerName, uint* propertyCount, ExtensionProperties* properties);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkEnumerateDeviceExtensionProperties(PhysicalDevice physicalDevice, char* layerName, uint* propertyCount, ExtensionProperties* properties);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkEnumerateInstanceLayerProperties(uint* propertyCount, LayerProperties* properties);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkEnumerateDeviceLayerProperties(PhysicalDevice physicalDevice, uint* propertyCount, LayerProperties* properties);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern void vkGetDeviceQueue(Device device, uint queueFamilyIndex, uint queueIndex, Queue* queue);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkQueueSubmit(Queue queue, uint submitCount, SubmitInfo* submits, Fence fence);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkQueueWaitIdle(Queue queue);

		[DllImport(VulkanDll, CallingConvention = CallingConvention.Winapi)]
		public static extern Result vkDeviceWaitIdle(Device device);

	}
}