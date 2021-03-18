using System;
using Microsoft.AspNetCore.Mvc;
using WinformSelfHostAPINetFramework.Model;

namespace WinformSelfHostAPINetFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResponse = new ServiceResponse<string>();
            serviceResponse.Success = true;

            string text = "";
            Program.MainForm.Invoke(new Action(() =>
            {
                text = Program.MainForm.textBox1.Text;
            }));
            serviceResponse.Data = text;
            return Ok(serviceResponse);
        }

        [HttpPost("{id}")]
        public IActionResult Get(string id)
        {
            var serviceResponse = new ServiceResponse<string>();
            serviceResponse.Success = true;

            Program.MainForm.Invoke(new Action(() =>
            {
                Program.MainForm.textBox1.Text = id;
            }));
            serviceResponse.Data = id;
            return Ok(serviceResponse);
        }
    }
}
