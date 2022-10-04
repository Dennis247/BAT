using BAT.api.Authorization;
using BAT.api.Models.Dtos.UserData;
using BAT.api.Services;
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

        [AllowAnonymous]
        [HttpPost("TestQuery")]
        public IActionResult TestQuery(MergeUserDataDto mergeUserDataDto)
        {
            string selectPart = "select ";
       
                foreach (var item2 in mergeUserDataDto.MergeData)
                {
                    var result =  item2.TableName +"." + string.Join($", {item2.TableName}.", item2.TabeleFields);
                    selectPart += result +",";

                }
            

            selectPart = $"{selectPart.TrimEnd(',')} FROM {mergeUserDataDto.MergeData[0].TableName}";

            string InnerJoinPath = "";


            for (int i = mergeUserDataDto.MergeData.Count - 1; i >=0; i--)
            {
               
                if(i != 0)
                {
                    for (int j = 0; j < mergeUserDataDto.FieldsForMerging.Count; j++)
                    {
                        InnerJoinPath += $"INNER JOIN {mergeUserDataDto.MergeData[i].TableName} ON" +
                            $" {mergeUserDataDto.MergeData[i].TableName}.{mergeUserDataDto.FieldsForMerging[j]} = {mergeUserDataDto.MergeData[i - 1].TableName}.{mergeUserDataDto.FieldsForMerging[j]},";
                    }
                }
             
            }
            InnerJoinPath = InnerJoinPath.Trim(',');


            string orderBy = $"ORDER BY {mergeUserDataDto.MergeData[0].TableName}.{mergeUserDataDto.MergeData[0].TabeleFields[0]} ASC;";

            string query = $"{selectPart} {InnerJoinPath} {orderBy}";

            return Ok(query);
        }

     
    }
}
