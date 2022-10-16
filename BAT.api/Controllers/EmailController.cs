using BAT.api.Authorization;
using BAT.api.Models.Dtos.UserData;
using BAT.api.Services;
using BAT.api.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Mail;

namespace BAT.api.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class EmailController : BaseController
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [AllowAnonymous]
        [HttpGet("TestEmail")]
        public IActionResult TestEmail()
        {
            _emailService.SendEmailWithSendGrid(new Utils.Helpers.Message
            {
                To = new List<string> { "dosamuyimen@gmail.com" },
                Subject = "demo message",
                HtmlContent = "demo",
                PlainContent = "demo"
            });

            return Ok();
        }

        //[AllowAnonymous]
        //[HttpPost("TestQuery")]
        //public IActionResult TestQuery(MergeUserDataDto mergeUserDataDto)
        //{
        //    string selectPart = "select ";
       
        //        foreach (var item2 in mergeUserDataDto.MergeData)
        //        {
        //            var result =  item2.TableName +"." + string.Join($", {item2.TableName}.", item2.TabeleFields);
        //            selectPart += result +",";

        //        }
            

        //    selectPart = $"{selectPart.TrimEnd(',')} FROM {mergeUserDataDto.MergeData[0].TableName}";

        //    string InnerJoinPath = "";


        //    for (int i = mergeUserDataDto.MergeData.Count - 1; i >=0; i--)
        //    {
               
        //        if(i != 0)
        //        {
        //            for (int j = 0; j < mergeUserDataDto.FieldsForMerging.Count; j++)
        //            {
        //                InnerJoinPath += $"INNER JOIN {mergeUserDataDto.MergeData[i].TableName} ON" +
        //                    $" {mergeUserDataDto.MergeData[i].TableName}.{mergeUserDataDto.FieldsForMerging[j]} = {mergeUserDataDto.MergeData[i - 1].TableName}.{mergeUserDataDto.FieldsForMerging[j]},";
        //            }
        //        }
             
        //    }
        //    InnerJoinPath = InnerJoinPath.Trim(',');


        //    string orderBy = $"ORDER BY {mergeUserDataDto.MergeData[0].TableName}.{mergeUserDataDto.MergeData[0].TabeleFields[0]} ASC;";

        //    string query = $"{selectPart} {InnerJoinPath} {orderBy}";

        //    return Ok(query);
        //}



        [AllowAnonymous]
        [HttpPost("GenerateQuery")]
        public IActionResult GenerateQuery(List<ProcessingQuery> queries)
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
            #endregion


            #region other parts of the query 
             queries.RemoveAt(0);
            string otherParts = generateOtherPartofQuery(queries);

            query = $"{query} {otherParts}";
            
            #endregion
            return Ok(query);
        }


        string generateOtherPartofQuery(List<ProcessingQuery> queries)
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
            else    if (ORValues.Any())
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
}
