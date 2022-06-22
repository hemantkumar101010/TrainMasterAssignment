using TrainMaster.Data;
using TrainMaster.Data.Models;

public class Program
{
    public static void Main()
    {
        TrainCRUDManager crud = new TrainCRUDManager();

        DateTime dtStart,dtEnd;
        DateTime.TryParse("22/06/2022 7:00:00 AM", out dtStart);
        DateTime.TryParse("22/06/2022 6:00:00 PM", out dtEnd);

        TrainDetail obj = new TrainDetail
        {
            TrainNumber= 504,TrainName="Pune Express",FromStation="Pune",ToStaion="Goa",JourneyStime= dtStart,
            JourneyEtime= dtEnd
        };

        //days schedular
        DaysSchedular daysSchedular = new DaysSchedular
        {
            TrainNo = 504,
            Monday = true,
            Tuesday = false,
            Wednesday = true,
            Thusday = false,
            Friday = true,
            Saturday = false,
            Sunday = true
        };
        
        crud.AddInTrainAndDaysSchedular(obj, daysSchedular);

       //crud.AddInTrainDetails(obj);

        //update
        DateTime.TryParse("22/06/2022 12:30:00 AM", out dtStart);
        obj.JourneyStime = dtStart;
        //crud.UpdateInTrainDetails(500,obj);


        //delete
        //crud.DeleteInTrainsDetails(500);

        //dearch by train number
        //crud.SearchByTrainNumber(502);

        //method to search by from station and to station
        string fromStation = "Delhi", toStation = "UP";
        //crud.SearchByFromAndToStation(fromStation, toStation);



        //days schedular table
        DaysSchedular daysSchedular1 = new DaysSchedular
        {
            TrainNo = 503,Monday=false,Tuesday=false,Wednesday=false,Thusday=false,Friday=true,Saturday=false,Sunday=false   
        };

       // crud.AddInDaysShedualar(daysSchedular);


    }
}