namespace FrameWork.ExMethods
{
    public static class StreamEx
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            int length = stream.Length > int.MaxValue ? int.MaxValue : Convert.ToInt32(stream.Length);
            byte[] buffer = new byte[length];
            stream.Read(buffer, 0, length);
            return buffer;
        }
    }
}
