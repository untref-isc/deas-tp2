namespace Service.Utils
{
    internal static class Extentions
    {
        internal static long GetSizeInKB(this FileInfo fileInfo)
        {
            return fileInfo.Length / 1024;
        }
    }
}