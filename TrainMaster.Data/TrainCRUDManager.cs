﻿using System.Linq;
using TrainMaster.Data.Models;

namespace TrainMaster.Data
{
    public class TrainCRUDManager
    {
        TrainMasterDbContext trainMasterDbContext = new TrainMasterDbContext();
       
        //add in both table at once
        public void AddInTrainAndDaysSchedular(TrainDetail trainDetail, DaysSchedular daysSchedular)
        {
            var trainDetailObj = new TrainDetail
            {
                TrainNumber = trainDetail.TrainNumber,
                TrainName = trainDetail.TrainName,
                FromStation = trainDetail.FromStation,
                ToStaion = trainDetail.ToStaion,
                JourneyStime = trainDetail.JourneyStime,
                JourneyEtime = trainDetail.JourneyEtime,
                DaysSchedular = daysSchedular
            };
            trainMasterDbContext.TrainDetails.Add(trainDetailObj);
            trainMasterDbContext.SaveChanges();
        }

        #region Saperate-funct-to-add
        public void AddInTrainDetails(TrainDetail trainDetails)
        {
            var trainDetail = new TrainDetail
            {
                TrainNumber = trainDetails.TrainNumber,
                TrainName = trainDetails.TrainName,
                FromStation = trainDetails.FromStation,
                ToStaion = trainDetails.ToStaion,
                JourneyStime = trainDetails.JourneyStime,
                JourneyEtime = trainDetails.JourneyEtime,
            };

            trainMasterDbContext.TrainDetails.Add(trainDetail);
            trainMasterDbContext.SaveChanges();

        }
        public void AddInDaysShedualar(DaysSchedular daysSchedular)
        {
            var daysSchdual = new DaysSchedular
            {
                TrainNo = daysSchedular.TrainNo,
                Monday = daysSchedular.Monday,
                Tuesday = daysSchedular.Tuesday,
                Wednesday = daysSchedular.Wednesday,
                Thusday = daysSchedular.Thusday,
                Friday = daysSchedular.Friday,
                Saturday = daysSchedular.Saturday,
                Sunday = daysSchedular.Sunday,

            };
            trainMasterDbContext.DaysSchedulars.Add(daysSchdual);
            trainMasterDbContext.SaveChanges();
            Console.WriteLine("Inserted");
        }
        #endregion


        public void UpdateInTrainDetails(int trainNumber, TrainDetail updatedDetail)
        {
            var trainDetail = trainMasterDbContext.TrainDetails.Where(td => td.TrainNumber == trainNumber).FirstOrDefault();
            if (trainDetail != null)
            {
                //trainDetail.TrainName = updatedDetail.TrainName;
                //trainDetail.FromStation = updatedDetail.FromStation;
                //trainDetail.ToStaion = updatedDetail.ToStaion;
                trainDetail.JourneyStime = updatedDetail.JourneyStime;
                //trainDetail.JourneyEtime = updatedDetail.JourneyEtime;

                trainMasterDbContext.TrainDetails.Update(trainDetail);
                trainMasterDbContext.SaveChanges();
                Console.WriteLine("Updated");
            }
            else
                Console.WriteLine($"Train number: {trainNumber} is not found");
        }

        public void DeleteInTrainsDetails(int trainNumber)
        {
            var trainDetail = trainMasterDbContext.TrainDetails.Where(td => td.TrainNumber == trainNumber).FirstOrDefault();
            if (trainDetail != null)
            {
                trainMasterDbContext.TrainDetails.Remove(trainDetail);
                trainMasterDbContext.SaveChanges();
                Console.WriteLine("Deleted");
            }
            else
                Console.WriteLine($"Train number: {trainNumber} is not found");
        }

        public void SearchByTrainNumber(int trainNumber)
        {
            var trainDetail = trainMasterDbContext.TrainDetails.Where(td => td.TrainNumber == trainNumber).FirstOrDefault();
            if (trainDetail != null)
            {
                Console.WriteLine($"Train Name: {trainDetail.TrainName}");
                Console.WriteLine($"From Station: {trainDetail.FromStation}");
                Console.WriteLine($"To Station: {trainDetail.ToStaion}");
                Console.WriteLine($"JurneySTime: {trainDetail.JourneyStime}");
                Console.WriteLine($"JurneyETime: {trainDetail.JourneyEtime}");

            }
            else
                Console.WriteLine($"Train number: {trainNumber} is not found");

        }

        public void SearchByFromAndToStation(string from ,string to)
        {
            var trainDetail = trainMasterDbContext.TrainDetails.Where(td => td.FromStation == from && td.ToStaion==to).ToList();
            if (trainDetail != null)
            {
                foreach (var item in trainDetail)
                {
                    Console.WriteLine($"Train no. {item.TrainNumber},TrainName: {item.TrainName},JourneySTime: {item.JourneyStime},   JourneyETime: {item.JourneyEtime}");
                }
            }
            else
            {
                Console.WriteLine($"No details available for train station from {from} to station {to}");
            }
        }


    }
}
