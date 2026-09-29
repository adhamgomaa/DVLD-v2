using DVLD.DataAccess;
using DVLD.Shared.Entities;

namespace DVLD.Business
{
    public class ApplicationService
    {
        public static async Task<bool> AddNewAppAsync(Application newApp)
        {
            newApp.AppID = await ApplicationData.AddNewAppAsync(newApp);
            return newApp.AppID != -1;
        }

        public static async Task<bool> UpdateAppAsync(Application updateApp)
        {
            return await ApplicationData.UpdateAppAsync(updateApp);
        }

        public static async Task<Application?> FindAppAsync(int id)
        {
            Application? app = await ApplicationData.FindAppAsync(id);
            if (app != null)
                return app;
            return null;
        }

        public static async Task<bool> DeleteAppAsync(int id)
        {
            return await ApplicationData.DeleteAppAsync(id);
        }
    }
}
