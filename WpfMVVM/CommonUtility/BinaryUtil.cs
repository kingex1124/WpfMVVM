using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM.CommonUtility
{
    /// <summary>
    /// 處理二進位資料的元件
    /// </summary>
    public class BinaryUtil
    {
        /// <summary>
        /// 建構子
        /// </summary>
        public BinaryUtil()
        {
        }

        /// <summary>
        /// 讀取資料流轉成二進位
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] BinaryReadToEnd(Stream stream)
        {
            byte[] numArray;
            long originalPosition = (long)0;
            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = (long)0;
            }
            try
            {
                byte[] readBuffer = new byte[4096];
                int totalByteRead = 0;
                while (true)
                {
                    int num = stream.Read(readBuffer, totalByteRead, (int)readBuffer.Length - totalByteRead);
                    int bytesRead = num;
                    if (num <= 0)
                    {
                        break;
                    }
                    totalByteRead = totalByteRead + bytesRead;
                    if (totalByteRead == (int)readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[(int)readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, (int)readBuffer.Length);
                            Buffer.SetByte(temp, totalByteRead, (byte)nextByte);
                            readBuffer = temp;
                            totalByteRead++;
                        }
                    }
                }
                byte[] buffer = readBuffer;
                if ((int)readBuffer.Length != totalByteRead)
                {
                    buffer = new byte[totalByteRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalByteRead);
                }
                numArray = buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
            return numArray;
        }
    }
}
