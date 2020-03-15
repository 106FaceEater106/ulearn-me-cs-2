using System;
using System.Collections.Generic;

namespace Incapsulation.Failures
{
    public class Failure
    {
        public enum FailureType
        {
            UnexpectedShutdown,
            ShortNonResponding,
            HardwareFailures,
            ConnectionProblems
        }

        public readonly Device Device;
        public readonly DateTime Date;
        public readonly FailureType Type;

        public bool IsSerious => Type == FailureType.UnexpectedShutdown
                              || Type == FailureType.HardwareFailures;

        public Failure(Device failedDevice, DateTime failureDate, FailureType failureType)
        {
            Device = failedDevice;
            Date = failureDate;
            Type = failureType;
        }
    }

    public class Device
    {
        public readonly int Id;
        public readonly string Name;

        public Device(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public static class ReportMaker
    {
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes,
            int[] deviceId,
            object[][] times,
            List<Dictionary<string, object>> devices)
        {
            DateTime date = new DateTime(year, month, day);
            var failureList = new List<Failure>();

            for (int i = 0; i < devices.Count; i++)
            {
                var failedDevice = new Device(deviceId[i], ((string)devices[i]["Name"]));
                var failureDate = new DateTime((int)times[i][2], (int)times[i][1], (int)times[i][0]);
                var failureType = (Failure.FailureType)failureTypes[i];
                failureList.Add(new Failure(failedDevice, failureDate, failureType));
            }

            var fromNewMethod = FindDevicesFailedBeforeDate(date, failureList);
            var result = new List<string>();
            foreach (var failure in fromNewMethod)
                result.Add(failure.Device.Name);
            return result;
        }

        public static List<Failure> FindDevicesFailedBeforeDate(DateTime date, List<Failure> failureList)
        {
            var resultList = new List<Failure>();
            foreach (var failure in failureList)
                if (failure.Date < date && failure.IsSerious)
                    resultList.Add(failure);
            return resultList;
        }
    }
}