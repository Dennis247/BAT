﻿namespace BAT.api.Utils.Helpers
{
    public class QueryGenerator
    {
   



        //public static string GenerateQuery(List<ProcessingQuery> queries)
        //{

        //    string query = "";

        //    //use lower and higher value when values are just 2 and they are numbers
        //    int higherRange = 0;
        //    int lowerRange = 0;


        //    //use OR values when you have more than one comma delimiters
        //    List<string> ORValues = new List<string>();

        //    string exactValue = "";

           

        //    //what drives the condition should be the value

        //    var firstPArt = queries[0];
        //    var firstValueJoin = firstPArt.Value.Split(',').ToList();
        //    if(firstValueJoin.Count == 1)
        //    {
        //        exactValue = firstValueJoin[0];
        //    }
        //    else if (firstValueJoin.Count == 2
        //        && firstValueJoin[0].All(char.IsDigit) && firstValueJoin[1].All(char.IsDigit))
        //    {

        //          lowerRange = int.Parse(firstValueJoin[0]);
        //          higherRange = int.Parse(firstValueJoin[1]);
                
        //    }
        //    else if (firstValueJoin.Count > 1)
        //    {
        //        ORValues = firstValueJoin;
        //    }

        //    var firstQuery = "";
        //    if(exactValue != "")
        //    {
        //        firstQuery = $"select * from UserDatas where {firstPArt.Field} == '{exactValue}' ";
        //        query = firstQuery;
        //    }
        //    if (ORValues.Any()) 
        //    {
        //        firstQuery = $"select * from UserDatas where ";
        //        string orPart = "";
        //        for (int i = 0; i < ORValues.Count; i++)
        //        {
        //            orPart += $"{firstPArt.Field} = '{ORValues[i]}' OR" ;
        //        }

        //        orPart = orPart.TrimEnd('R').TrimEnd('O');
        //        query = firstQuery + orPart;



        //    }
        //    if(higherRange >0)
        //    {
        //        firstQuery = $"select * from UserDatas where ";
        //        string betweenPart = "";
        //        for (int i = 0; i < ORValues.Count; i++)
        //        {
        //            betweenPart= $"{firstPArt.Field} >= {lowerRange} &&  {firstPArt.Field}<= {higherRange} ";
        //        }
        //        query = firstQuery + betweenPart;

        //    }
        //}
        
    }


    public class ProcessingQuery
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string Condition { get; set; }
        public string Connector { get; set; }

    }


}
