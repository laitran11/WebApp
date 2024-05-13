namespace WebApp
{
    public static class Helper
    {
        public static string RandomString(int len)
        {
            Random random = new Random();
            string pattern = "qwertyuiopasdfghjkxcvbnm123456789";
            char[] arr = new char[len];
            for(int i = 0; i< len; i++)
            {
                arr[i] = pattern[random.Next(pattern.Length)];
            }
            return string.Join(string.Empty, arr);
        }
    }
}
