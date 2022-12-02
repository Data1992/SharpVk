using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;

namespace SharpVk.Generator
{
    public class VkXmlCache
        : IVkXmlCache
    {
        private readonly string tempFilePath;
        private readonly Lazy<XDocument> vkXml;

        public VkXmlCache(string tempFilePath)
        {
            this.tempFilePath = tempFilePath;

            if (!Directory.Exists(this.tempFilePath))
            {
                Directory.CreateDirectory(this.tempFilePath);
            }

            this.vkXml = new Lazy<XDocument>(LoadVkXml);
        }

        public XDocument GetVkXml() => this.vkXml.Value;

        private XDocument LoadVkXml()
        {
            string tempFile = Path.Combine(this.tempFilePath, "vk.xml");

            if (!File.Exists(tempFile) || File.GetLastWriteTimeUtc(tempFile) + TimeSpan.FromDays(1) < DateTime.UtcNow)
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(tempFile));

                    var client = new HttpClient();
                    var response = client.GetAsync("https://raw.githubusercontent.com/KhronosGroup/Vulkan-Docs/main/xml/vk.xml");

                    using (var vkXmlResponse = response.Result)
                    {
                        if (File.Exists(tempFile))
                        {
                            File.Delete(tempFile);
                        }

                        using (var fileStream = File.OpenWrite(tempFile))
                        {
                            vkXmlResponse.Content.ReadAsStream().CopyTo(fileStream);
                        }
                    }
                }
                catch
                {
                }
            }

            return XDocument.Load(tempFile);
        }
    }
}