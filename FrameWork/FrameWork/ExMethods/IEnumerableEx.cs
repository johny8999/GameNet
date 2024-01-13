namespace FrameWork.ExMethods
{
    public static class EnumerableEx
    {
        public static string JoinStr(this IEnumerable<string> lstStr, string sperator)
        {
            return string.Join(sperator, lstStr);
        }
    }
}
