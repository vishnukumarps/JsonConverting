﻿using AppFormsJsonParser.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFormsJsonParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        // GET: api/<ConvertController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ConvertController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConvertController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConvertController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConvertController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
        [Route("/GetFormJsonFromUrl")]
        public List<LWControl> GetFormJsonFromUrl()
        {
            try
            {
                var client = new RestClient("https://dev.cunextgen.com/ApprenderNew/api/values/default/B48A1D14-D4FE-4E41-8E8E-877BC595A01D");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                var parentJson = JsonConvert.DeserializeObject<ParentJson>(response.Content.ToString());

                var formJson = JsonConvert.DeserializeObject<List<LWControl>>(parentJson.FormJson);
                // Console.WriteLine(unescapedJsonString);
                return formJson;
            }
            catch (Exception ex)
            {


            }
            return null;
        }
    }
}
