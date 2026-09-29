using DVLD.DataAccess;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DVLD.Business
{
    public class TestAppointmentService
    {
        public static async Task<bool> AddNewAppointmentAsync(TestAppointment newAppointment)
        {
            newAppointment.AppointmentId = await TestAppointmentData.AddNewAppointmentAsync(newAppointment);
            return newAppointment.AppointmentId != -1;
        }
        public static async Task<bool> UpdateAppointmentAsync(TestAppointment updateAppointment)
        {
            return await TestAppointmentData.UpdateAppointmentAsync(updateAppointment);
        }

        public static async Task<List<TestAppointment>> GetAllAppointmentAsync(int localId, TestTypeEnum typeId)
        {
            return await TestAppointmentData.GetAllAppointmentAsync(localId, typeId);
        }

        public static async Task<int> GetTrialsAsync(int localId, TestTypeEnum typeId)
        {
            return await TestAppointmentData.GetTrialsAsync(localId, typeId);
        }

        public static async Task<TestAppointment?> FindAppointmentAsync(int appointmentId)
        {
            TestAppointment? appointment = await TestAppointmentData.FindAppointmentAsync(appointmentId);
            if (appointment != null)
                return appointment;
            return null;
        }

        public static async Task<TestAppointment?> GetLastTestAppointmentAsync(int localId, TestTypeEnum testType)
        {
            TestAppointment? appointment = await TestAppointmentData.GetLastTestAppointmentAsync(localId, testType);
            if (appointment != null)
                return appointment;
            return null;
        }

        public static async Task<bool> AppointmentIsLockAsync(int localId, TestTypeEnum typeId)
        {
            return await TestAppointmentData.AppointmentIsLockAsync(localId, typeId);
        }

        public static async Task<int> GetTestIdAsync(int appointmentId)
        {
            return await TestAppointmentData.GetTestIDAsync(appointmentId);
        }

    }
}
