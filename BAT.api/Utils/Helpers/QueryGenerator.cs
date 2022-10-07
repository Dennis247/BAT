namespace BAT.api.Utils.Helpers
{
    public class QueryGenerator
    {


        public static string GenerateQuery(List<ProcessingQuery> queries)
        {
            string query = "";

            //use lower and higher value when values are just 2 and they are numbers
            int higherRange = 0;
            int lowerRange = 0;


            //use OR values when you have more than one comma delimiters
            List<string> ORValues = new List<string>();

            string exactValue = "";



            //what drives the condition should be the value


          //  #region first part of the query
            var firstPArt = queries[0];
            var firstValueJoin = firstPArt.Value.Split(',').ToList();
            if (firstValueJoin.Count == 1)
            {
                exactValue = firstValueJoin[0];
            }
            else if (firstValueJoin.Count == 2
                && firstValueJoin[0].All(char.IsDigit) && firstValueJoin[1].All(char.IsDigit))
            {

                lowerRange = int.Parse(firstValueJoin[0]);
                higherRange = int.Parse(firstValueJoin[1]);

            }
            else if (firstValueJoin.Count > 1)
            {
                ORValues = firstValueJoin;
            }

            var firstQuery = "";
            if (exactValue != "")
            {
                firstQuery = $"select * from UserDatas where {firstPArt.Field} = '{exactValue}' ";
                query = firstQuery;
            }
            if (ORValues.Any())
            {
                firstQuery = $"select * from UserDatas where ";
                string orPart = "";
                for (int i = 0; i < ORValues.Count; i++)
                {
                    orPart += $"{firstPArt.Field} = '{ORValues[i]}' OR ";
                }

                orPart = orPart.Remove(orPart.Length - 3);
                query = firstQuery + orPart;

            }
            if (higherRange > 0)
            {
                firstQuery = $"select * from UserDatas where ";
                string betweenPart = "";
                for (int i = 0; i < ORValues.Count; i++)
                {
                    betweenPart = $"{firstPArt.Field} >= {lowerRange} &&  {firstPArt.Field}<= {higherRange} ";
                }
                query = firstQuery + betweenPart;

            }
          
           
            queries.RemoveAt(0);
            string otherParts = generateOtherPartofQuery(queries);

            query = $"{query} {otherParts}";

            return query;

        }



        static string generateOtherPartofQuery(List<ProcessingQuery> queries)
        {

            //use lower and higher value when values are just 2 and they are numbers

            string result = "";

            for (int j = 0; j < queries.Count; j++)
            {
                string query = "";

                //use lower and higher value when values are just 2 and they are numbers
                int higherRange = 0;
                int lowerRange = 0;


                //use OR values when you have more than one comma delimiters
                List<string> ORValues = new List<string>();

                string exactValue = "";



                //what drives the condition should be the value

                #region first part of the query
                var firstPArt = queries[j];
                var firstValueJoin = firstPArt.Value.Split(',').ToList();
                if (firstValueJoin.Count == 1)
                {
                    exactValue = firstValueJoin[0];
                }
                else if (firstValueJoin.Count == 2
                    && firstValueJoin[0].All(char.IsDigit) && firstValueJoin[1].All(char.IsDigit))
                {

                    lowerRange = int.Parse(firstValueJoin[0]);
                    higherRange = int.Parse(firstValueJoin[1]);

                }
                else if (firstValueJoin.Count > 1)
                {
                    ORValues = firstValueJoin;
                }

                var firstQuery = "";
                if (exactValue != "")
                {
                    firstQuery = $"AND ({firstPArt.Field} = '{exactValue}') ";
                    query = firstQuery;
                }
                else if (ORValues.Any())
                {
                    firstQuery = $"AND ";
                    string orPart = "";
                    for (int i = 0; i < ORValues.Count; i++)
                    {
                        orPart += $"{firstPArt.Field} = '{ORValues[i]}' OR ";
                    }

                    orPart = orPart.Remove(orPart.Length - 3);
                    query = firstQuery + $" ({orPart})";

                }
                else if (higherRange > 0)
                {
                    firstQuery = $" AND ";
                    string betweenPart = "";

                    betweenPart = $"{firstPArt.Field} >= {lowerRange} AND  {firstPArt.Field}<= {higherRange} ";

                    query = firstQuery + $" ({betweenPart}) ";

                }
                #endregion

                result += $"{query}";



            }

            return result;

        }


    }



    public class ProcessingQuery
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string Condition { get; set; }
        public string Connector { get; set; }

    }

    public class ProcessFileRequest
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ProcessingQuery> processingQueries { get; set; }
    }




}
