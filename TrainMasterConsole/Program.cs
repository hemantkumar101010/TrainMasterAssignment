using TrainMaster.Data;
using TrainMaster.Data.Models;

public class Program
{
    public static void Main()
    {
        TrainCRUDManager crud = new TrainCRUDManager();

        DateTime dtStart,dtEnd;
        DateTime.TryParse("22/06/2022 10:00:00 AM", out dtStart);
        DateTime.TryParse("22/06/2022 6:00:00 PM", out dtEnd);

        TrainDetail obj = new TrainDetail
        {
            TrainNumber= 506,TrainName="MP Express",FromStation="MP",ToStaion="Goa",JourneyStime= dtStart,
            JourneyEtime= dtEnd
        };

        //days schedular
        DaysSchedular daysSchedular = new DaysSchedular
        {
            TrainNo = 506,
            Monday = true,
            Tuesday = true,
            Wednesday = true,
            Thusday = true,
            Friday = true,
            Saturday = false,
            Sunday = false
        };
        
        crud.AddInTrainAndDaysSchedular(obj, daysSchedular);

      // crud.AddInTrainDetails(obj);

        //update
        DateTime.TryParse("22/06/2022 12:30:00 AM", out dtStart);
        obj.JourneyStime = dtStart;
       // crud.UpdateInTrainDetails(506,obj);


        //delete
       // crud.DeleteInTrainsDetails(506);

        //search by train number
        //crud.SearchByTrainNumber(505);

        //method to search by from station and to station
        string fromStation = "Pune", toStation = "Goa";
        //crud.SearchByFromAndToStation(fromStation, toStation);



        //days schedular table
        DaysSchedular daysSchedular1 = new DaysSchedular
        {
            Monday=true,Tuesday=false,Wednesday=false,Thusday=false,Friday=true,Saturday=false,Sunday=false   
        };

        // crud.AddInDaysShedualar(daysSchedular);
    }
}