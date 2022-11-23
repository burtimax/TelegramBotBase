namespace BotApplication.BotStore.Helpers
{
    public class PhotoHelper
    {
        public static string GetPhotoFilePath(string fileName)
        {
            return $"{AppConstants.RootDir}\\photo\\{fileName}";
        }
        
        public static string GetPhotoFilePathByPhotoName(string photo)
        {
            return $"{AppConstants.RootDir}\\photo\\{photo}";
        }
        
        // public static string GetPhotoFileNameForUser(string userId)
        // {
        //     return $"{userId}.jpg";
        // }
    }
}