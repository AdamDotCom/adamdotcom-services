﻿using System;
using System.ServiceModel.Channels;
using System.IO;

namespace AdamDotCom.Common.Service.Infrastructure.CSV
{
    public class CSVEncoder
    {
        private XmlToCvsTranslator xmlToCvsTranslator;

        public CSVEncoder()
        {
            xmlToCvsTranslator = new XmlToCvsTranslator();
        }

        public ArraySegment<byte> WriteMessage(MessageEncoder encoder, Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {
            MemoryStream stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            writer = xmlToCvsTranslator.Translate(message.GetReaderAtBodyContents(), writer);
            writer.Flush();

            byte[] messageBytes = stream.GetBuffer();
            int messageLength = (int)stream.Position;
            int totalLength = messageLength + messageOffset;
            byte[] totalBytes = bufferManager.TakeBuffer(totalLength);
            Array.Copy(messageBytes, 0, totalBytes, messageOffset, messageLength);

            ArraySegment<byte> byteArray = new ArraySegment<byte>(totalBytes, messageOffset, messageLength);
            writer.Close();

            return byteArray;
        }
    }
}