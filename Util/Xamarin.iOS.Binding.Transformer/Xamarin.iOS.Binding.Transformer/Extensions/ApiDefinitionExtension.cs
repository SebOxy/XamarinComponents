﻿using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Xamarin.iOS.Binding.Transformer
{
    public static class ApiDefinitionExtension
    {
        public static void WriteToFile(this ApiDefinition target, string fileName)
        {
            var serializer = new XmlSerializer(typeof(ApiDefinition));

            var xWriterSetting = new XmlWriterSettings()
            {
                OmitXmlDeclaration = true,
                Indent = true,
            };

            using (StreamWriter str = new StreamWriter(fileName))
            using (XmlWriter xml = XmlWriter.Create(str, xWriterSetting))
            {
                serializer.Serialize(xml, target, target.XmlNamespaces);
            }
        }
    }
}