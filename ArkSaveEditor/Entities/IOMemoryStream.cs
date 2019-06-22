using ArkSaveEditor.Deserializer.DotArk;
using ArkSaveEditor.Entities.LowLevel;
using ArkSaveEditor.Entities.LowLevel.DotArk;
using ArkSaveEditor.Serializer.DotArk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArkSaveEditor.Entities
{
    public class IOMemoryStream
    {
        public bool is_little_endian = true;

        public MemoryStream ms = new MemoryStream();

        public long position
        {
            get
            {
                return ms.Position;
            }
            set
            {
                ms.Position = value;
            }
        }

        public long length
        {
            get
            {
                return ms.Length;
            }
        }

        public IOMemoryStream(MemoryStream ms, bool is_little_endian)
        {
            this.ms = ms;
            this.is_little_endian = is_little_endian;
        }

        public IOMemoryStream(bool is_little_endian)
        {
            this.is_little_endian = is_little_endian;
            this.ms = new MemoryStream();
        }

        public void CopyFromBeginningTo(Stream s)
        {
            ms.Position = 0;
            ms.CopyTo(s);
        }

        public void CopyFromBeginningTo(IOMemoryStream s)
        {
            ms.Position = 0;
            ms.CopyTo(s.ms);
        }

        public byte[] CopyFromBeginning()
        {
            ms.Position = 0;
            byte[] buf = new byte[ms.Length];
            ms.Read(buf, 0, buf.Length);
            return buf;
        }

        //API deserialization
        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16(PrivateReadBytes(2), 0);
        }

        public short ReadShort()
        {
            return BitConverter.ToInt16(PrivateReadBytes(2), 0);
        }

        public DotArkLocationData ReadLocationData(DotArkDeserializer ds)
        {
            return DotArkLocationData.ReadLocationData(ds);
        }

        public ArkClassName ReadArkClassname(DotArkDeserializer ds)
        {
            return ArkClassName.ReadFromFile(ds);
        }

        public void DebugReadArkClassname(DotArkDeserializer ds)
        {
            long start = ms.Position;
            int u1 = ReadInt();
            int u2 = ReadInt();
            ms.Position = start;
            try
            {
                var e = ArkClassName.ReadFromFile(ds);
                Console.WriteLine($"[Classname Debug] Name={e.classname}, Index={e.index} ({u1}, {u2})");
            } catch
            {
                Console.WriteLine($"[Classname Debug] Failed ({u1}, {u2})");
            }
        }

        public void DebugReadArkClassnameStep(DotArkDeserializer ds)
        {
            long start = ms.Position;
            DebugReadArkClassname(ds);
            ms.Position = start + 4;
        }

        public ArkClassName ReadInlineArkClassname()
        {
            return ArkClassName.ReadFromFileInline(this);
        }

        public uint ReadUInt()
        {
            return BitConverter.ToUInt32(PrivateReadBytes(4), 0);
        }

        public int ReadInt()
        {
            return BitConverter.ToInt32(PrivateReadBytes(4), 0);
        }

        public ulong ReadULong()
        {
            byte[] buf = PrivateReadBytes(8);
            return BitConverter.ToUInt64(buf, 0);
        }

        public long ReadLong()
        {
            return BitConverter.ToInt64(PrivateReadBytes(4), 0);
        }

        public float ReadFloat()
        {
            return BitConverter.ToSingle(PrivateReadBytes(4), 0);
        }

        public double ReadDouble()
        {
            return BitConverter.ToDouble(PrivateReadBytes(8), 0);
        }

        public bool ReadIntBool()
        {
            int data = ReadInt();
            //This is really bad, Wildcard....
            if (data != 0 && data != 1)
                throw new Exception("Expected boolean, got " + data);
            return data == 1;
        }

        public bool ReadByteBool()
        {
            return ReadByte() != 0x00;
        }

        public string ReadUEString(int maxLen = int.MaxValue)
        {
            //Read length
            int length = this.ReadInt();
            if (length == 0)
                return "";

            //Validate length
            if (length > maxLen)
                throw new Exception("Failed to read null-terminated string; Length from file exceeded maximum length requested.");

            //My friend's arg broke this reader. Turns out extended characters use TWO bytes. I think if the length is negative, it's two bytes per character
            if (length < 0)
            {
                //Read this many bytes * 2
                byte[] buf = ReadBytes((-length * 2) - 1);

                //Read null byte, but discard
                byte nullByte1 = ReadByte();
                if (nullByte1 != 0x00)
                    throw new Exception("Failed to read null-terminated string; 1st terminator in 2-bytes-per-character string was not null!");

                //Convert to string
                return Encoding.Unicode.GetString(buf);
            } else
            {
                //Read this many bytes.
                byte[] buf = ReadBytes(length - 1);
                //Read null byte, but discard
                byte nullByte = ReadByte();
                if (nullByte != 0x00)
                    throw new Exception("Failed to read null-terminated string; Terminator was not null!");
                //Convert to string
                return Encoding.UTF8.GetString(buf);
            }
        }

        public byte[] ReadBytes(int length)
        {
            byte[] buf = new byte[length];
            ms.Read(buf, 0, length);
            return buf;
        }

        public byte ReadByte()
        {
            return ReadBytes(1)[0];
        }

        //Private deserialization API
        private byte[] PrivateReadBytes(int size)
        {
            //Read in from the buffer and respect the little endian setting.
            byte[] buf = new byte[size];
            //Read
            ms.Read(buf, 0, size);
            //Respect endians
            if (is_little_endian != BitConverter.IsLittleEndian)
                Array.Reverse(buf);
            return buf;
        }

        //Writing API
        public void WriteUShort(UInt16 i)
        {
            PrivateWriteBytes(BitConverter.GetBytes(i));
        }

        public void WriteShort(Int16 i)
        {
            PrivateWriteBytes(BitConverter.GetBytes(i));
        }

        public void WriteInt(Int32 i)
        {
            PrivateWriteBytes(BitConverter.GetBytes(i));
        }

        public void WriteIntBool(bool b)
        {
            int i = 0;
            if (b)
                i = 1;
            PrivateWriteBytes(BitConverter.GetBytes(i));
        }

        public void WriteUInt(UInt32 i)
        {
            PrivateWriteBytes(BitConverter.GetBytes(i));
        }

        public void WriteLong(Int64 i)
        {
            PrivateWriteBytes(BitConverter.GetBytes(i));
        }

        public void WriteULong(UInt64 i)
        {
            PrivateWriteBytes(BitConverter.GetBytes(i));
        }

        public void WriteUEString(string data)
        {
            //Convert the UTF-8
            byte[] buf = Encoding.UTF8.GetBytes(data);

            //Write the length
            WriteInt(buf.Length+1);

            //Write data
            ms.Write(buf, 0, buf.Length);

            //Write null terminator
            ms.WriteByte(0x00);
        }

        public void WriteArkClassname(ArkClassName c, DotArkSerializerInstance i)
        {
            c.WriteToDotArkFile(i, this);
        }

        public void WriteFloat(float value)
        {
            PrivateWriteBytes(BitConverter.GetBytes(value));
        }

        public void WriteDouble(double value)
        {
            PrivateWriteBytes(BitConverter.GetBytes(value));
        }

        public void WriteBytes(byte[] buf)
        {
            ms.Write(buf, 0, buf.Length);
        }

        public void WriteByte(byte buf)
        {
            ms.WriteByte(buf);
        }

        public void WriteLocationData(DotArkLocationData l)
        {
            l.WriteLocationData(this);
        }

        //Private writing API
        private void PrivateWriteBytes(byte[] buf)
        {
            //Respect endians
            if (is_little_endian != BitConverter.IsLittleEndian)
                Array.Reverse(buf);

            //Write
            ms.Write(buf, 0, buf.Length);
        }

    }
}
